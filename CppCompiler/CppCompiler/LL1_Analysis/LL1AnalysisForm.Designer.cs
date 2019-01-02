namespace CppCompiler
{
    partial class LL1AnalysisForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LL1AnalysisForm));
            this.label1 = new System.Windows.Forms.Label();
            this.rtxtGrammar = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnImportGrammarFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnSaveGrammarAsFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnCheckGrammar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnLeftRecursionRemoval = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnLeftFactoring = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnGenerateLL1ParsingTable = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnInputSentence = new System.Windows.Forms.ToolStripButton();
            this.lblEditGrammar = new System.Windows.Forms.Label();
            this.rtxtLeftRecursionRemoval = new System.Windows.Forms.RichTextBox();
            this.dgvLL1ParsingTable = new System.Windows.Forms.DataGridView();
            this.rtxtLeftFactoring = new System.Windows.Forms.RichTextBox();
            this.lblLeftRecursionRemoval = new System.Windows.Forms.Label();
            this.lblLeftFactoring = new System.Windows.Forms.Label();
            this.lblParsingTable = new System.Windows.Forms.Label();
            this.btnInputEmptyString = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLL1ParsingTable)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 0;
            // 
            // rtxtGrammar
            // 
            this.rtxtGrammar.Location = new System.Drawing.Point(12, 71);
            this.rtxtGrammar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtxtGrammar.Name = "rtxtGrammar";
            this.rtxtGrammar.Size = new System.Drawing.Size(275, 229);
            this.rtxtGrammar.TabIndex = 1;
            this.rtxtGrammar.Text = "";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnImportGrammarFile,
            this.toolStripSeparator1,
            this.tsbtnSaveGrammarAsFile,
            this.toolStripSeparator2,
            this.tsbtnCheckGrammar,
            this.toolStripSeparator3,
            this.tsbtnLeftRecursionRemoval,
            this.toolStripSeparator4,
            this.tsbtnLeftFactoring,
            this.toolStripSeparator5,
            this.tsbtnGenerateLL1ParsingTable,
            this.toolStripSeparator6,
            this.tsbtnInputSentence});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(933, 40);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnImportGrammarFile
            // 
            this.tsbtnImportGrammarFile.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnImportGrammarFile.Image")));
            this.tsbtnImportGrammarFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnImportGrammarFile.Name = "tsbtnImportGrammarFile";
            this.tsbtnImportGrammarFile.Size = new System.Drawing.Size(108, 37);
            this.tsbtnImportGrammarFile.Text = "导入文法规则文件";
            this.tsbtnImportGrammarFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnImportGrammarFile.Click += new System.EventHandler(this.tsbtnImportGrammarFile_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 40);
            // 
            // tsbtnSaveGrammarAsFile
            // 
            this.tsbtnSaveGrammarAsFile.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSaveGrammarAsFile.Image")));
            this.tsbtnSaveGrammarAsFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSaveGrammarAsFile.Name = "tsbtnSaveGrammarAsFile";
            this.tsbtnSaveGrammarAsFile.Size = new System.Drawing.Size(132, 37);
            this.tsbtnSaveGrammarAsFile.Text = "保存文法规则到文件中";
            this.tsbtnSaveGrammarAsFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnSaveGrammarAsFile.Click += new System.EventHandler(this.tsbtnSaveGrammarAsFile_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 40);
            // 
            // tsbtnCheckGrammar
            // 
            this.tsbtnCheckGrammar.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnCheckGrammar.Image")));
            this.tsbtnCheckGrammar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnCheckGrammar.Name = "tsbtnCheckGrammar";
            this.tsbtnCheckGrammar.Size = new System.Drawing.Size(132, 37);
            this.tsbtnCheckGrammar.Text = "预处理并检查文法规则";
            this.tsbtnCheckGrammar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnCheckGrammar.Click += new System.EventHandler(this.tsbtnCheckGrammar_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 40);
            // 
            // tsbtnLeftRecursionRemoval
            // 
            this.tsbtnLeftRecursionRemoval.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnLeftRecursionRemoval.Image")));
            this.tsbtnLeftRecursionRemoval.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnLeftRecursionRemoval.Name = "tsbtnLeftRecursionRemoval";
            this.tsbtnLeftRecursionRemoval.Size = new System.Drawing.Size(72, 37);
            this.tsbtnLeftRecursionRemoval.Text = "消除左递归";
            this.tsbtnLeftRecursionRemoval.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnLeftRecursionRemoval.Click += new System.EventHandler(this.tsbtnLeftRecursionRemoval_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 40);
            // 
            // tsbtnLeftFactoring
            // 
            this.tsbtnLeftFactoring.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnLeftFactoring.Image")));
            this.tsbtnLeftFactoring.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnLeftFactoring.Name = "tsbtnLeftFactoring";
            this.tsbtnLeftFactoring.Size = new System.Drawing.Size(96, 37);
            this.tsbtnLeftFactoring.Text = "消除左公共因子";
            this.tsbtnLeftFactoring.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnLeftFactoring.Click += new System.EventHandler(this.tsbtnLeftFactoring_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 40);
            // 
            // tsbtnGenerateLL1ParsingTable
            // 
            this.tsbtnGenerateLL1ParsingTable.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnGenerateLL1ParsingTable.Image")));
            this.tsbtnGenerateLL1ParsingTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnGenerateLL1ParsingTable.Name = "tsbtnGenerateLL1ParsingTable";
            this.tsbtnGenerateLL1ParsingTable.Size = new System.Drawing.Size(99, 37);
            this.tsbtnGenerateLL1ParsingTable.Text = "生成LL(1)分析表";
            this.tsbtnGenerateLL1ParsingTable.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnGenerateLL1ParsingTable.Click += new System.EventHandler(this.tsbtnGenerateLL1ParsingTable_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 40);
            // 
            // tsbtnInputSentence
            // 
            this.tsbtnInputSentence.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnInputSentence.Image")));
            this.tsbtnInputSentence.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnInputSentence.Name = "tsbtnInputSentence";
            this.tsbtnInputSentence.Size = new System.Drawing.Size(108, 37);
            this.tsbtnInputSentence.Text = "输入待分析的语句";
            this.tsbtnInputSentence.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnInputSentence.Click += new System.EventHandler(this.tsbtnInputSentence_Click);
            // 
            // lblEditGrammar
            // 
            this.lblEditGrammar.AutoSize = true;
            this.lblEditGrammar.Location = new System.Drawing.Point(4, 48);
            this.lblEditGrammar.Name = "lblEditGrammar";
            this.lblEditGrammar.Size = new System.Drawing.Size(215, 17);
            this.lblEditGrammar.TabIndex = 3;
            this.lblEditGrammar.Text = "编辑/查看文法规则：(支持 ε 表示空串)";
            // 
            // rtxtLeftRecursionRemoval
            // 
            this.rtxtLeftRecursionRemoval.Location = new System.Drawing.Point(319, 71);
            this.rtxtLeftRecursionRemoval.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtxtLeftRecursionRemoval.Name = "rtxtLeftRecursionRemoval";
            this.rtxtLeftRecursionRemoval.ReadOnly = true;
            this.rtxtLeftRecursionRemoval.Size = new System.Drawing.Size(284, 229);
            this.rtxtLeftRecursionRemoval.TabIndex = 4;
            this.rtxtLeftRecursionRemoval.Text = "";
            // 
            // dgvLL1ParsingTable
            // 
            this.dgvLL1ParsingTable.AllowUserToAddRows = false;
            this.dgvLL1ParsingTable.AllowUserToDeleteRows = false;
            this.dgvLL1ParsingTable.AllowUserToResizeRows = false;
            this.dgvLL1ParsingTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvLL1ParsingTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvLL1ParsingTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLL1ParsingTable.ColumnHeadersVisible = false;
            this.dgvLL1ParsingTable.Location = new System.Drawing.Point(12, 336);
            this.dgvLL1ParsingTable.Name = "dgvLL1ParsingTable";
            this.dgvLL1ParsingTable.ReadOnly = true;
            this.dgvLL1ParsingTable.RowHeadersVisible = false;
            this.dgvLL1ParsingTable.RowTemplate.Height = 23;
            this.dgvLL1ParsingTable.Size = new System.Drawing.Size(906, 293);
            this.dgvLL1ParsingTable.TabIndex = 5;
            // 
            // rtxtLeftFactoring
            // 
            this.rtxtLeftFactoring.Location = new System.Drawing.Point(636, 71);
            this.rtxtLeftFactoring.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtxtLeftFactoring.Name = "rtxtLeftFactoring";
            this.rtxtLeftFactoring.ReadOnly = true;
            this.rtxtLeftFactoring.Size = new System.Drawing.Size(287, 229);
            this.rtxtLeftFactoring.TabIndex = 6;
            this.rtxtLeftFactoring.Text = "";
            // 
            // lblLeftRecursionRemoval
            // 
            this.lblLeftRecursionRemoval.AutoSize = true;
            this.lblLeftRecursionRemoval.Location = new System.Drawing.Point(322, 52);
            this.lblLeftRecursionRemoval.Name = "lblLeftRecursionRemoval";
            this.lblLeftRecursionRemoval.Size = new System.Drawing.Size(80, 17);
            this.lblLeftRecursionRemoval.TabIndex = 7;
            this.lblLeftRecursionRemoval.Text = "消除左递归：";
            // 
            // lblLeftFactoring
            // 
            this.lblLeftFactoring.AutoSize = true;
            this.lblLeftFactoring.Location = new System.Drawing.Point(634, 52);
            this.lblLeftFactoring.Name = "lblLeftFactoring";
            this.lblLeftFactoring.Size = new System.Drawing.Size(104, 17);
            this.lblLeftFactoring.TabIndex = 8;
            this.lblLeftFactoring.Text = "消除左公共因子：";
            // 
            // lblParsingTable
            // 
            this.lblParsingTable.AutoSize = true;
            this.lblParsingTable.Location = new System.Drawing.Point(14, 314);
            this.lblParsingTable.Name = "lblParsingTable";
            this.lblParsingTable.Size = new System.Drawing.Size(83, 17);
            this.lblParsingTable.TabIndex = 9;
            this.lblParsingTable.Text = "LL(1)分析表：";
            // 
            // btnInputEmptyString
            // 
            this.btnInputEmptyString.Location = new System.Drawing.Point(216, 43);
            this.btnInputEmptyString.Name = "btnInputEmptyString";
            this.btnInputEmptyString.Size = new System.Drawing.Size(75, 24);
            this.btnInputEmptyString.TabIndex = 10;
            this.btnInputEmptyString.Text = "输入ε";
            this.btnInputEmptyString.UseVisualStyleBackColor = true;
            this.btnInputEmptyString.Click += new System.EventHandler(this.btnInputEmptyString_Click);
            // 
            // LL1AnalysisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 637);
            this.Controls.Add(this.dgvLL1ParsingTable);
            this.Controls.Add(this.btnInputEmptyString);
            this.Controls.Add(this.lblParsingTable);
            this.Controls.Add(this.lblLeftFactoring);
            this.Controls.Add(this.lblLeftRecursionRemoval);
            this.Controls.Add(this.rtxtLeftFactoring);
            this.Controls.Add(this.rtxtLeftRecursionRemoval);
            this.Controls.Add(this.lblEditGrammar);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.rtxtGrammar);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "LL1AnalysisForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LL(1)分析器";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLL1ParsingTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtxtGrammar;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnImportGrammarFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbtnSaveGrammarAsFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbtnCheckGrammar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbtnLeftRecursionRemoval;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbtnLeftFactoring;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tsbtnGenerateLL1ParsingTable;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton tsbtnInputSentence;
        private System.Windows.Forms.Label lblEditGrammar;
        private System.Windows.Forms.RichTextBox rtxtLeftRecursionRemoval;
        private System.Windows.Forms.DataGridView dgvLL1ParsingTable;
        private System.Windows.Forms.RichTextBox rtxtLeftFactoring;
        private System.Windows.Forms.Label lblLeftRecursionRemoval;
        private System.Windows.Forms.Label lblLeftFactoring;
        private System.Windows.Forms.Label lblParsingTable;
        private System.Windows.Forms.Button btnInputEmptyString;
    }
}