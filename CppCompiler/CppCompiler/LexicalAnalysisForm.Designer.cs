namespace CppCompiler
{
    partial class LexicalAnalysisForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LexicalAnalysisForm));
            this.lblSourceFile = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.lblSourceFileContent = new System.Windows.Forms.Label();
            this.lblScanResult = new System.Windows.Forms.Label();
            this.tsLexicalAnalysis = new System.Windows.Forms.ToolStrip();
            this.tsbtnScanSourceFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnSaveScanResult = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnCompress = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnSaveCompressResult = new System.Windows.Forms.ToolStripButton();
            this.rtxtScanResult = new System.Windows.Forms.RichTextBox();
            this.rtxtSourceFileContent = new System.Windows.Forms.RichTextBox();
            this.tsLexicalAnalysis.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSourceFile
            // 
            this.lblSourceFile.AutoSize = true;
            this.lblSourceFile.Location = new System.Drawing.Point(50, 68);
            this.lblSourceFile.Name = "lblSourceFile";
            this.lblSourceFile.Size = new System.Drawing.Size(82, 17);
            this.lblSourceFile.TabIndex = 0;
            this.lblSourceFile.Text = "C++源文件：";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtFilePath.Location = new System.Drawing.Point(183, 65);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(637, 23);
            this.txtFilePath.TabIndex = 1;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(852, 65);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 2;
            this.btnSelect.Text = "选择";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // lblSourceFileContent
            // 
            this.lblSourceFileContent.AutoSize = true;
            this.lblSourceFileContent.Location = new System.Drawing.Point(30, 135);
            this.lblSourceFileContent.Name = "lblSourceFileContent";
            this.lblSourceFileContent.Size = new System.Drawing.Size(106, 17);
            this.lblSourceFileContent.TabIndex = 5;
            this.lblSourceFileContent.Text = "C++源文件内容：";
            // 
            // lblScanResult
            // 
            this.lblScanResult.AutoSize = true;
            this.lblScanResult.Location = new System.Drawing.Point(548, 135);
            this.lblScanResult.Name = "lblScanResult";
            this.lblScanResult.Size = new System.Drawing.Size(116, 17);
            this.lblScanResult.TabIndex = 6;
            this.lblScanResult.Text = "词法分析扫描结果：";
            // 
            // tsLexicalAnalysis
            // 
            this.tsLexicalAnalysis.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnScanSourceFile,
            this.toolStripSeparator1,
            this.tsbtnSaveScanResult,
            this.toolStripSeparator2,
            this.tsbtnCompress,
            this.toolStripSeparator3,
            this.tsbtnSaveCompressResult});
            this.tsLexicalAnalysis.Location = new System.Drawing.Point(0, 0);
            this.tsLexicalAnalysis.Name = "tsLexicalAnalysis";
            this.tsLexicalAnalysis.Size = new System.Drawing.Size(984, 40);
            this.tsLexicalAnalysis.TabIndex = 7;
            this.tsLexicalAnalysis.Text = "toolStrip1";
            // 
            // tsbtnScanSourceFile
            // 
            this.tsbtnScanSourceFile.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnScanSourceFile.Image")));
            this.tsbtnScanSourceFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnScanSourceFile.Name = "tsbtnScanSourceFile";
            this.tsbtnScanSourceFile.Size = new System.Drawing.Size(60, 37);
            this.tsbtnScanSourceFile.Text = "扫描文件";
            this.tsbtnScanSourceFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnScanSourceFile.Click += new System.EventHandler(this.tsbtnScanSourceFile_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 40);
            // 
            // tsbtnSaveScanResult
            // 
            this.tsbtnSaveScanResult.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSaveScanResult.Image")));
            this.tsbtnSaveScanResult.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSaveScanResult.Name = "tsbtnSaveScanResult";
            this.tsbtnSaveScanResult.Size = new System.Drawing.Size(84, 37);
            this.tsbtnSaveScanResult.Text = "保存扫描结果";
            this.tsbtnSaveScanResult.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnSaveScanResult.Click += new System.EventHandler(this.tsbtnSaveScanResult_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 40);
            // 
            // tsbtnCompress
            // 
            this.tsbtnCompress.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnCompress.Image")));
            this.tsbtnCompress.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnCompress.Name = "tsbtnCompress";
            this.tsbtnCompress.Size = new System.Drawing.Size(60, 37);
            this.tsbtnCompress.Text = "压缩文件";
            this.tsbtnCompress.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnCompress.Click += new System.EventHandler(this.tsbtnCompress_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 40);
            // 
            // tsbtnSaveCompressResult
            // 
            this.tsbtnSaveCompressResult.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSaveCompressResult.Image")));
            this.tsbtnSaveCompressResult.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSaveCompressResult.Name = "tsbtnSaveCompressResult";
            this.tsbtnSaveCompressResult.Size = new System.Drawing.Size(84, 37);
            this.tsbtnSaveCompressResult.Text = "保存压缩结果";
            this.tsbtnSaveCompressResult.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnSaveCompressResult.Click += new System.EventHandler(this.tsbtnSaveCompressResult_Click);
            // 
            // rtxtScanResult
            // 
            this.rtxtScanResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rtxtScanResult.Location = new System.Drawing.Point(551, 164);
            this.rtxtScanResult.Name = "rtxtScanResult";
            this.rtxtScanResult.ReadOnly = true;
            this.rtxtScanResult.Size = new System.Drawing.Size(421, 474);
            this.rtxtScanResult.TabIndex = 4;
            this.rtxtScanResult.Text = "";
            // 
            // rtxtSourceFileContent
            // 
            this.rtxtSourceFileContent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rtxtSourceFileContent.BackColor = System.Drawing.SystemColors.Control;
            this.rtxtSourceFileContent.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.rtxtSourceFileContent.Location = new System.Drawing.Point(33, 164);
            this.rtxtSourceFileContent.Name = "rtxtSourceFileContent";
            this.rtxtSourceFileContent.ReadOnly = true;
            this.rtxtSourceFileContent.Size = new System.Drawing.Size(483, 474);
            this.rtxtSourceFileContent.TabIndex = 3;
            this.rtxtSourceFileContent.Text = "";
            // 
            // LexicalAnalysisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.tsLexicalAnalysis);
            this.Controls.Add(this.lblScanResult);
            this.Controls.Add(this.lblSourceFileContent);
            this.Controls.Add(this.rtxtScanResult);
            this.Controls.Add(this.rtxtSourceFileContent);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.lblSourceFile);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "LexicalAnalysisForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "词法分析";
            this.Load += new System.EventHandler(this.LexicalAnalysisForm_Load);
            this.tsLexicalAnalysis.ResumeLayout(false);
            this.tsLexicalAnalysis.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSourceFile;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Label lblSourceFileContent;
        private System.Windows.Forms.Label lblScanResult;
        private System.Windows.Forms.ToolStrip tsLexicalAnalysis;
        private System.Windows.Forms.ToolStripButton tsbtnScanSourceFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbtnCompress;
        private System.Windows.Forms.RichTextBox rtxtScanResult;
        private System.Windows.Forms.RichTextBox rtxtSourceFileContent;
        private System.Windows.Forms.ToolStripButton tsbtnSaveScanResult;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbtnSaveCompressResult;
    }
}