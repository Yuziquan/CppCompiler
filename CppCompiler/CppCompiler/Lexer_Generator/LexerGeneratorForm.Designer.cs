namespace CppCompiler
{
    partial class LexerGeneratorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LexerGeneratorForm));
            this.tsLexerGenerator = new System.Windows.Forms.ToolStrip();
            this.tsbtnImportRegex = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnReadAndConvert = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnGenerateLexer = new System.Windows.Forms.ToolStripButton();
            this.dgvNFA = new System.Windows.Forms.DataGridView();
            this.dgvDFA = new System.Windows.Forms.DataGridView();
            this.dgvMinDFA = new System.Windows.Forms.DataGridView();
            this.lblNFA = new System.Windows.Forms.Label();
            this.lblDFA = new System.Windows.Forms.Label();
            this.lblMinDFA = new System.Windows.Forms.Label();
            this.txtRegex = new System.Windows.Forms.TextBox();
            this.lblRegex = new System.Windows.Forms.Label();
            this.lblHint = new System.Windows.Forms.Label();
            this.tsLexerGenerator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNFA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDFA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMinDFA)).BeginInit();
            this.SuspendLayout();
            // 
            // tsLexerGenerator
            // 
            this.tsLexerGenerator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnImportRegex,
            this.toolStripSeparator1,
            this.tsbtnReadAndConvert,
            this.toolStripSeparator2,
            this.tsbtnGenerateLexer});
            this.tsLexerGenerator.Location = new System.Drawing.Point(0, 0);
            this.tsLexerGenerator.Name = "tsLexerGenerator";
            this.tsLexerGenerator.Size = new System.Drawing.Size(1355, 40);
            this.tsLexerGenerator.TabIndex = 0;
            this.tsLexerGenerator.Text = "toolStrip1";
            // 
            // tsbtnImportRegex
            // 
            this.tsbtnImportRegex.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnImportRegex.Image")));
            this.tsbtnImportRegex.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnImportRegex.Name = "tsbtnImportRegex";
            this.tsbtnImportRegex.Size = new System.Drawing.Size(144, 37);
            this.tsbtnImportRegex.Text = "从文件中导入正则表达式";
            this.tsbtnImportRegex.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnImportRegex.Click += new System.EventHandler(this.tsbtnImportRegex_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 40);
            // 
            // tsbtnReadAndConvert
            // 
            this.tsbtnReadAndConvert.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnReadAndConvert.Image")));
            this.tsbtnReadAndConvert.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnReadAndConvert.Name = "tsbtnReadAndConvert";
            this.tsbtnReadAndConvert.Size = new System.Drawing.Size(156, 37);
            this.tsbtnReadAndConvert.Text = "读取正则表达式并执行转换";
            this.tsbtnReadAndConvert.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnReadAndConvert.Click += new System.EventHandler(this.tsbtnReadAndConvert_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 40);
            // 
            // tsbtnGenerateLexer
            // 
            this.tsbtnGenerateLexer.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnGenerateLexer.Image")));
            this.tsbtnGenerateLexer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnGenerateLexer.Name = "tsbtnGenerateLexer";
            this.tsbtnGenerateLexer.Size = new System.Drawing.Size(108, 37);
            this.tsbtnGenerateLexer.Text = "生成词法分析程序";
            this.tsbtnGenerateLexer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnGenerateLexer.Click += new System.EventHandler(this.tsbtnGenerateLexer_Click);
            // 
            // dgvNFA
            // 
            this.dgvNFA.AllowUserToAddRows = false;
            this.dgvNFA.AllowUserToDeleteRows = false;
            this.dgvNFA.AllowUserToResizeRows = false;
            this.dgvNFA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvNFA.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvNFA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNFA.ColumnHeadersVisible = false;
            this.dgvNFA.Location = new System.Drawing.Point(12, 152);
            this.dgvNFA.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvNFA.Name = "dgvNFA";
            this.dgvNFA.ReadOnly = true;
            this.dgvNFA.RowHeadersVisible = false;
            this.dgvNFA.RowTemplate.Height = 23;
            this.dgvNFA.Size = new System.Drawing.Size(413, 410);
            this.dgvNFA.TabIndex = 1;
            // 
            // dgvDFA
            // 
            this.dgvDFA.AllowUserToAddRows = false;
            this.dgvDFA.AllowUserToDeleteRows = false;
            this.dgvDFA.AllowUserToResizeRows = false;
            this.dgvDFA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDFA.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDFA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDFA.ColumnHeadersVisible = false;
            this.dgvDFA.Location = new System.Drawing.Point(431, 152);
            this.dgvDFA.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvDFA.Name = "dgvDFA";
            this.dgvDFA.ReadOnly = true;
            this.dgvDFA.RowHeadersVisible = false;
            this.dgvDFA.RowTemplate.Height = 23;
            this.dgvDFA.Size = new System.Drawing.Size(452, 410);
            this.dgvDFA.TabIndex = 2;
            // 
            // dgvMinDFA
            // 
            this.dgvMinDFA.AllowUserToAddRows = false;
            this.dgvMinDFA.AllowUserToDeleteRows = false;
            this.dgvMinDFA.AllowUserToResizeRows = false;
            this.dgvMinDFA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvMinDFA.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvMinDFA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMinDFA.ColumnHeadersVisible = false;
            this.dgvMinDFA.Location = new System.Drawing.Point(889, 152);
            this.dgvMinDFA.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvMinDFA.Name = "dgvMinDFA";
            this.dgvMinDFA.ReadOnly = true;
            this.dgvMinDFA.RowHeadersVisible = false;
            this.dgvMinDFA.RowTemplate.Height = 23;
            this.dgvMinDFA.Size = new System.Drawing.Size(458, 410);
            this.dgvMinDFA.TabIndex = 3;
            // 
            // lblNFA
            // 
            this.lblNFA.AutoSize = true;
            this.lblNFA.Location = new System.Drawing.Point(12, 131);
            this.lblNFA.Name = "lblNFA";
            this.lblNFA.Size = new System.Drawing.Size(104, 17);
            this.lblNFA.TabIndex = 4;
            this.lblNFA.Text = "NFA状态转换表：";
            // 
            // lblDFA
            // 
            this.lblDFA.AutoSize = true;
            this.lblDFA.Location = new System.Drawing.Point(428, 131);
            this.lblDFA.Name = "lblDFA";
            this.lblDFA.Size = new System.Drawing.Size(103, 17);
            this.lblDFA.TabIndex = 5;
            this.lblDFA.Text = "DFA状态转换表：";
            // 
            // lblMinDFA
            // 
            this.lblMinDFA.AutoSize = true;
            this.lblMinDFA.Location = new System.Drawing.Point(886, 131);
            this.lblMinDFA.Name = "lblMinDFA";
            this.lblMinDFA.Size = new System.Drawing.Size(139, 17);
            this.lblMinDFA.TabIndex = 6;
            this.lblMinDFA.Text = "最小化DFA状态转换表：";
            // 
            // txtRegex
            // 
            this.txtRegex.Location = new System.Drawing.Point(245, 59);
            this.txtRegex.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRegex.Name = "txtRegex";
            this.txtRegex.Size = new System.Drawing.Size(826, 23);
            this.txtRegex.TabIndex = 7;
            // 
            // lblRegex
            // 
            this.lblRegex.AutoSize = true;
            this.lblRegex.Location = new System.Drawing.Point(68, 62);
            this.lblRegex.Name = "lblRegex";
            this.lblRegex.Size = new System.Drawing.Size(116, 17);
            this.lblRegex.TabIndex = 8;
            this.lblRegex.Text = "请输入正则表达式：";
            // 
            // lblHint
            // 
            this.lblHint.AutoSize = true;
            this.lblHint.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblHint.Location = new System.Drawing.Point(68, 93);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(739, 17);
            this.lblHint.TabIndex = 9;
            this.lblHint.Text = "注意：该正则表达式仅支持操作数(a~z、A~Z、0~9)和运算符( |  .  *  (  ) )，其他字符将被视为非法字符。输入样例：a(a|b)*、1a2(c" +
    "|4)。";
            // 
            // LexerGeneratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1355, 570);
            this.Controls.Add(this.lblHint);
            this.Controls.Add(this.lblRegex);
            this.Controls.Add(this.txtRegex);
            this.Controls.Add(this.lblMinDFA);
            this.Controls.Add(this.lblDFA);
            this.Controls.Add(this.lblNFA);
            this.Controls.Add(this.dgvMinDFA);
            this.Controls.Add(this.dgvDFA);
            this.Controls.Add(this.dgvNFA);
            this.Controls.Add(this.tsLexerGenerator);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "LexerGeneratorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "词法分析器生成器";
            this.tsLexerGenerator.ResumeLayout(false);
            this.tsLexerGenerator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNFA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDFA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMinDFA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsLexerGenerator;
        private System.Windows.Forms.ToolStripButton tsbtnImportRegex;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbtnReadAndConvert;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbtnGenerateLexer;
        private System.Windows.Forms.DataGridView dgvNFA;
        private System.Windows.Forms.DataGridView dgvDFA;
        private System.Windows.Forms.DataGridView dgvMinDFA;
        private System.Windows.Forms.Label lblNFA;
        private System.Windows.Forms.Label lblDFA;
        private System.Windows.Forms.Label lblMinDFA;
        private System.Windows.Forms.TextBox txtRegex;
        private System.Windows.Forms.Label lblRegex;
        private System.Windows.Forms.Label lblHint;
    }
}