namespace CppCompiler
{
    partial class LexerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LexerForm));
            this.rtxtLexerCode = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnSaveLexerCode = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtxtLexerCode
            // 
            this.rtxtLexerCode.Location = new System.Drawing.Point(14, 71);
            this.rtxtLexerCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtxtLexerCode.Name = "rtxtLexerCode";
            this.rtxtLexerCode.ReadOnly = true;
            this.rtxtLexerCode.Size = new System.Drawing.Size(916, 577);
            this.rtxtLexerCode.TabIndex = 0;
            this.rtxtLexerCode.Text = "";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnSaveLexerCode});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(942, 40);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnSaveLexerCode
            // 
            this.tsbtnSaveLexerCode.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSaveLexerCode.Image")));
            this.tsbtnSaveLexerCode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSaveLexerCode.Name = "tsbtnSaveLexerCode";
            this.tsbtnSaveLexerCode.Size = new System.Drawing.Size(72, 37);
            this.tsbtnSaveLexerCode.Text = "保存源代码";
            this.tsbtnSaveLexerCode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnSaveLexerCode.Click += new System.EventHandler(this.tsbtnSaveLexerCode_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "生成的词法分析程序：";
            // 
            // LexerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 661);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.rtxtLexerCode);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "LexerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "词法分析程序（C语言描述）";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtxtLexerCode;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnSaveLexerCode;
        private System.Windows.Forms.Label label1;
    }
}