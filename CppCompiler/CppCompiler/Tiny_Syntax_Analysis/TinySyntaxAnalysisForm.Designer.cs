namespace CppCompiler
{
    partial class TinySyntaxAnalysisForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TinySyntaxAnalysisForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnSaveSourceCode = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnDisplaySyntaxTree = new System.Windows.Forms.ToolStripButton();
            this.rtxtSourceFileContent = new System.Windows.Forms.RichTextBox();
            this.rtxtSyntaxTree = new System.Windows.Forms.RichTextBox();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.lblSourceFile = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.lblEditTinySourceCode = new System.Windows.Forms.Label();
            this.lblSyntaxTree = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnSaveSourceCode,
            this.toolStripSeparator1,
            this.tsbtnDisplaySyntaxTree});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(933, 40);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnSaveSourceCode
            // 
            this.tsbtnSaveSourceCode.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSaveSourceCode.Image")));
            this.tsbtnSaveSourceCode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSaveSourceCode.Name = "tsbtnSaveSourceCode";
            this.tsbtnSaveSourceCode.Size = new System.Drawing.Size(96, 37);
            this.tsbtnSaveSourceCode.Text = "保存源代码文件";
            this.tsbtnSaveSourceCode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnSaveSourceCode.Click += new System.EventHandler(this.tsbtnSaveSourceCode_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 40);
            // 
            // tsbtnDisplaySyntaxTree
            // 
            this.tsbtnDisplaySyntaxTree.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnDisplaySyntaxTree.Image")));
            this.tsbtnDisplaySyntaxTree.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDisplaySyntaxTree.Name = "tsbtnDisplaySyntaxTree";
            this.tsbtnDisplaySyntaxTree.Size = new System.Drawing.Size(108, 37);
            this.tsbtnDisplaySyntaxTree.Text = "查看生成的语法树";
            this.tsbtnDisplaySyntaxTree.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnDisplaySyntaxTree.Click += new System.EventHandler(this.tsbtnDisplaySyntaxTree_Click);
            // 
            // rtxtSourceFileContent
            // 
            this.rtxtSourceFileContent.Location = new System.Drawing.Point(12, 148);
            this.rtxtSourceFileContent.Name = "rtxtSourceFileContent";
            this.rtxtSourceFileContent.Size = new System.Drawing.Size(445, 466);
            this.rtxtSourceFileContent.TabIndex = 1;
            this.rtxtSourceFileContent.Text = "";
            // 
            // rtxtSyntaxTree
            // 
            this.rtxtSyntaxTree.Location = new System.Drawing.Point(478, 148);
            this.rtxtSyntaxTree.Name = "rtxtSyntaxTree";
            this.rtxtSyntaxTree.ReadOnly = true;
            this.rtxtSyntaxTree.Size = new System.Drawing.Size(443, 466);
            this.rtxtSyntaxTree.TabIndex = 2;
            this.rtxtSyntaxTree.Text = "";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtFilePath.Location = new System.Drawing.Point(147, 71);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(637, 23);
            this.txtFilePath.TabIndex = 3;
            // 
            // lblSourceFile
            // 
            this.lblSourceFile.AutoSize = true;
            this.lblSourceFile.Location = new System.Drawing.Point(38, 74);
            this.lblSourceFile.Name = "lblSourceFile";
            this.lblSourceFile.Size = new System.Drawing.Size(103, 17);
            this.lblSourceFile.TabIndex = 4;
            this.lblSourceFile.Text = "Tiny源代码文件：";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(791, 71);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 5;
            this.btnSelect.Text = "选择";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // lblEditTinySourceCode
            // 
            this.lblEditTinySourceCode.AutoSize = true;
            this.lblEditTinySourceCode.Location = new System.Drawing.Point(12, 128);
            this.lblEditTinySourceCode.Name = "lblEditTinySourceCode";
            this.lblEditTinySourceCode.Size = new System.Drawing.Size(156, 17);
            this.lblEditTinySourceCode.TabIndex = 6;
            this.lblEditTinySourceCode.Text = "编辑/查看Tiny源代码文件：";
            // 
            // lblSyntaxTree
            // 
            this.lblSyntaxTree.AutoSize = true;
            this.lblSyntaxTree.Location = new System.Drawing.Point(475, 128);
            this.lblSyntaxTree.Name = "lblSyntaxTree";
            this.lblSyntaxTree.Size = new System.Drawing.Size(92, 17);
            this.lblSyntaxTree.TabIndex = 7;
            this.lblSyntaxTree.Text = "对应的语法树：";
            // 
            // TinySyntaxAnalysisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 637);
            this.Controls.Add(this.lblSyntaxTree);
            this.Controls.Add(this.lblEditTinySourceCode);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.lblSourceFile);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.rtxtSyntaxTree);
            this.Controls.Add(this.rtxtSourceFileContent);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "TinySyntaxAnalysisForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TINY扩充语言的语法分析";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.RichTextBox rtxtSourceFileContent;
        private System.Windows.Forms.RichTextBox rtxtSyntaxTree;
        private System.Windows.Forms.ToolStripButton tsbtnSaveSourceCode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbtnDisplaySyntaxTree;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label lblSourceFile;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Label lblEditTinySourceCode;
        private System.Windows.Forms.Label lblSyntaxTree;
    }
}