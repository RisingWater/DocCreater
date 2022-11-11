using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aspose.Words;
using Aspose.Words.Tables;
using System.Security.Cryptography;
using System.IO;
using System.Collections;
using System.Threading;
using Microsoft.Win32;

namespace DocCreaterUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadToReg();
        }

        private void LoadToReg()
        {
            RegistryKey hklm = Registry.CurrentUser;
            RegistryKey hkConfig = hklm.OpenSubKey(@"SOFTWARE\DocCreater", true);
            if (hkConfig != null)
            {
                object project = hkConfig.GetValue("Project");
                if (project != null)
                {
                    ProjectName.Text = project.ToString();
                }

                project = hkConfig.GetValue("TemplatePath");
                if (project != null)
                {
                    TemplatePath.Text = project.ToString();
                }

                project = hkConfig.GetValue("ProjectPath");
                if (project != null)
                {
                    ProjectPath.Text = project.ToString();
                }

                UpdateGenDocButton();
            }
        }

        private void SaveToReg()
        {
            RegistryKey hklm = Registry.CurrentUser;
            RegistryKey hkConfig = hklm.OpenSubKey(@"SOFTWARE\DocCreater", true);
            if (hkConfig == null)
            {
                hkConfig = hklm.CreateSubKey(@"SOFTWARE\DocCreater");
            }

            hkConfig.SetValue("Project", ProjectName.Text);
            hkConfig.SetValue("TemplatePath", TemplatePath.Text);
            hkConfig.SetValue("ProjectPath", ProjectPath.Text);

            hkConfig.Close();
            hklm.Close();
        }

        private string Encrypt(string FileName)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            FileStream file = new FileStream(FileName, FileMode.Open);
            byte[] md5data = md5.ComputeHash(file);
            md5.Clear();
            String str = "";
            for (int i = 0; i < md5data.Length; i++)
            {
                str += md5data[i].ToString("x").PadLeft(2, '0');
            }
            return str;
        }

        private void GetFileList(ArrayList filelist, String path)
        {
            DirectoryInfo d = new DirectoryInfo(path);

            FileSystemInfo[] fsinfos = d.GetFileSystemInfos();
            foreach (FileSystemInfo fsinfo in fsinfos)
            {
                if (fsinfo is DirectoryInfo)
                {
                    if (fsinfo.Name != "depends")
                    {
                        GetFileList(filelist, fsinfo.FullName);
                    }
                }
                else
                {
                    if (fsinfo.Extension == ".exe"
                        || fsinfo.Extension == ".dat"
                        || fsinfo.Extension == ".rpm"
                        || fsinfo.Extension == ".deb"
                        || fsinfo.Extension == ".apk"
                        || fsinfo.Extension == ".pkg")
                    {
                        FileInfo fi = new FileInfo(fsinfo.FullName);
                        filelist.Add(fi);
                    }
                }
            }
        }

        private Row CreateRow(int columnCount, string[] columnValues, Document doc)
        {
            Row r = new Row(doc);
            for (int i = 0; i < columnCount; i++)
            {
                if (columnValues.Length > i)
                {
                    Cell cell = CreateCell(columnValues[i], doc);
                    r.Cells.Add(cell);
                }
                else
                {
                    Cell cell = CreateCell("", doc);
                    r.Cells.Add(cell);
                }

            }
            return r;
        }

        private Cell CreateCell(string value, Document doc)
        {
            Cell c = new Cell(doc);
            Paragraph p = new Paragraph(doc);
            p.AppendChild(new Run(doc, value));
            c.AppendChild(p);
            return c;
        }

        private void UpdateGenDocButton()
        {
            if (!string.IsNullOrEmpty(TemplatePath.Text)
                && !string.IsNullOrEmpty(ProjectPath.Text)
                && !string.IsNullOrEmpty(ProjectName.Text))
            {
                GenDoc.Enabled = true;
            }
            else
            {
                GenDoc.Enabled = false;
            }
        }

        private void Log(String str)
        {
            logBox.Items.Add(str);
            logBox.SelectedIndex = logBox.Items.Count - 1;
        }

        private void SelectTemplate_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "模板文件 |*.doc;*.docx";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
                TemplatePath.Text = filePath;
                Log("已选择模板文件：" + TemplatePath.Text);
                UpdateGenDocButton();
            }
        }

        private void SelectProject_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;

            FolderBrowserDialog openFileDialog = new FolderBrowserDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.SelectedPath;
                ProjectPath.Text = filePath;
                Log("已选择模板文件：" + ProjectPath.Text);
                UpdateGenDocButton();
            }
        }

        private void GenDoc_Click(object sender, EventArgs e)
        {
            SaveToReg();

            string OutputFileName = "Daas-T-010-01[" + ProjectName.Text + "]版本开发文档[" + DateTime.Now.ToString("yyyymmdd") + "].doc";
            string OutputFilePath = ProjectPath.Text + "\\doc\\";
            Log("开始生成文档：" + OutputFileName);
            Log("文档保存路径：" + OutputFilePath);

            string TemplatePathStr = TemplatePath.Text;
            string InputPathStr = ProjectPath.Text;

            GenDocBar.Value = 0;
            GenDocBar.Minimum = 0;

            ProjectName.Enabled = false;
            SelectTemplate.Enabled = false;
            SelectProject.Enabled = false;
            GenDoc.Enabled = false;

            Thread GenDocThread = new Thread(
                delegate()
                {
                    GenDocument(TemplatePathStr, InputPathStr, OutputFilePath + OutputFileName);
                }
            );

            GenDocThread.IsBackground = true;
            GenDocThread.Start();
        }

        private void GenDocument(string TemplatePathStr, string InputPathStr, string OutputFilePath)
        {
            Document doc = new Document(TemplatePathStr);
            DocumentBuilder mainDocBuilder = new DocumentBuilder(doc);

            ArrayList filelist = new ArrayList();
            GetFileList(filelist, InputPathStr + "/server");
            GetFileList(filelist, InputPathStr + "/client");

            GenDocBar.Maximum = filelist.Count;

            mainDocBuilder.MoveToBookmark("FILELIST", true, true);

            mainDocBuilder.StartTable();

            mainDocBuilder.InsertCell();
            mainDocBuilder.Write("文件名");

            mainDocBuilder.InsertCell();
            mainDocBuilder.Write("文件大小");

            mainDocBuilder.InsertCell();
            mainDocBuilder.Write("校验和/MD5值");

            mainDocBuilder.InsertCell();
            mainDocBuilder.Write("使用说明");

            mainDocBuilder.EndRow();

            foreach (FileInfo fi in filelist)
            {
                mainDocBuilder.InsertCell();
                mainDocBuilder.Write(fi.Name);

                mainDocBuilder.InsertCell();
                mainDocBuilder.Write(fi.Length.ToString());

                string md5 = Encrypt(fi.FullName);

                mainDocBuilder.InsertCell();
                mainDocBuilder.Write(md5);

                mainDocBuilder.InsertCell();
                mainDocBuilder.Write("安装使用");

                mainDocBuilder.EndRow();

                Log("文件: " + fi.FullName + " 大小：" + fi.Length.ToString() + " MD5: " + md5);

                GenDocBar.Value++;
            }

            Table table = mainDocBuilder.EndTable();
            table.AutoFit(AutoFitBehavior.AutoFitToWindow);

            doc.Save(OutputFilePath);

            Log("成功生成文档：" + OutputFilePath);

            ProjectName.Enabled = true;
            SelectTemplate.Enabled = true;
            SelectProject.Enabled = true;
            GenDoc.Enabled = true;
        }

        private void ProjectName_TextChanged(object sender, EventArgs e)
        {
            UpdateGenDocButton();
        }
    }
}
