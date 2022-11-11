namespace DocCreaterUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SelectTemplate = new System.Windows.Forms.Button();
            this.TemplatePath = new System.Windows.Forms.TextBox();
            this.ProjectPath = new System.Windows.Forms.TextBox();
            this.SelectProject = new System.Windows.Forms.Button();
            this.logBox = new System.Windows.Forms.ListBox();
            this.GenDoc = new System.Windows.Forms.Button();
            this.ProjectName = new System.Windows.Forms.TextBox();
            this.PorjectNameLabel = new System.Windows.Forms.Label();
            this.TemplateLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.GenDocBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // SelectTemplate
            // 
            this.SelectTemplate.Location = new System.Drawing.Point(350, 40);
            this.SelectTemplate.Name = "SelectTemplate";
            this.SelectTemplate.Size = new System.Drawing.Size(109, 23);
            this.SelectTemplate.TabIndex = 0;
            this.SelectTemplate.Text = "选择模板";
            this.SelectTemplate.UseVisualStyleBackColor = true;
            this.SelectTemplate.Click += new System.EventHandler(this.SelectTemplate_Click);
            // 
            // TemplatePath
            // 
            this.TemplatePath.Enabled = false;
            this.TemplatePath.Location = new System.Drawing.Point(71, 41);
            this.TemplatePath.Name = "TemplatePath";
            this.TemplatePath.Size = new System.Drawing.Size(273, 21);
            this.TemplatePath.TabIndex = 1;
            // 
            // ProjectPath
            // 
            this.ProjectPath.Enabled = false;
            this.ProjectPath.Location = new System.Drawing.Point(71, 70);
            this.ProjectPath.Name = "ProjectPath";
            this.ProjectPath.Size = new System.Drawing.Size(273, 21);
            this.ProjectPath.TabIndex = 2;
            // 
            // SelectProject
            // 
            this.SelectProject.Location = new System.Drawing.Point(350, 69);
            this.SelectProject.Name = "SelectProject";
            this.SelectProject.Size = new System.Drawing.Size(109, 23);
            this.SelectProject.TabIndex = 3;
            this.SelectProject.Text = "选择项目目录";
            this.SelectProject.UseVisualStyleBackColor = true;
            this.SelectProject.Click += new System.EventHandler(this.SelectProject_Click);
            // 
            // logBox
            // 
            this.logBox.FormattingEnabled = true;
            this.logBox.HorizontalScrollbar = true;
            this.logBox.ItemHeight = 12;
            this.logBox.Location = new System.Drawing.Point(14, 100);
            this.logBox.Name = "logBox";
            this.logBox.Size = new System.Drawing.Size(570, 280);
            this.logBox.TabIndex = 4;
            // 
            // GenDoc
            // 
            this.GenDoc.Enabled = false;
            this.GenDoc.Location = new System.Drawing.Point(465, 12);
            this.GenDoc.Name = "GenDoc";
            this.GenDoc.Size = new System.Drawing.Size(119, 80);
            this.GenDoc.TabIndex = 5;
            this.GenDoc.Text = "生成文档";
            this.GenDoc.UseVisualStyleBackColor = true;
            this.GenDoc.Click += new System.EventHandler(this.GenDoc_Click);
            // 
            // ProjectName
            // 
            this.ProjectName.Location = new System.Drawing.Point(71, 12);
            this.ProjectName.Name = "ProjectName";
            this.ProjectName.Size = new System.Drawing.Size(388, 21);
            this.ProjectName.TabIndex = 6;
            this.ProjectName.TextChanged += new System.EventHandler(this.ProjectName_TextChanged);
            // 
            // PorjectNameLabel
            // 
            this.PorjectNameLabel.AutoSize = true;
            this.PorjectNameLabel.Location = new System.Drawing.Point(12, 16);
            this.PorjectNameLabel.Name = "PorjectNameLabel";
            this.PorjectNameLabel.Size = new System.Drawing.Size(53, 12);
            this.PorjectNameLabel.TabIndex = 7;
            this.PorjectNameLabel.Text = "项目名称";
            // 
            // TemplateLabel
            // 
            this.TemplateLabel.AutoSize = true;
            this.TemplateLabel.Location = new System.Drawing.Point(12, 45);
            this.TemplateLabel.Name = "TemplateLabel";
            this.TemplateLabel.Size = new System.Drawing.Size(53, 12);
            this.TemplateLabel.TabIndex = 8;
            this.TemplateLabel.Text = "模板路径";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "项目目录";
            // 
            // GenDocBar
            // 
            this.GenDocBar.Location = new System.Drawing.Point(14, 384);
            this.GenDocBar.Name = "GenDocBar";
            this.GenDocBar.Size = new System.Drawing.Size(570, 23);
            this.GenDocBar.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 419);
            this.Controls.Add(this.GenDocBar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TemplateLabel);
            this.Controls.Add(this.PorjectNameLabel);
            this.Controls.Add(this.ProjectName);
            this.Controls.Add(this.GenDoc);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.SelectProject);
            this.Controls.Add(this.ProjectPath);
            this.Controls.Add(this.TemplatePath);
            this.Controls.Add(this.SelectTemplate);
            this.Name = "Form1";
            this.Text = "文档生成器";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SelectTemplate;
        private System.Windows.Forms.TextBox TemplatePath;
        private System.Windows.Forms.TextBox ProjectPath;
        private System.Windows.Forms.Button SelectProject;
        private System.Windows.Forms.ListBox logBox;
        private System.Windows.Forms.Button GenDoc;
        private System.Windows.Forms.TextBox ProjectName;
        private System.Windows.Forms.Label PorjectNameLabel;
        private System.Windows.Forms.Label TemplateLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar GenDocBar;
    }
}

