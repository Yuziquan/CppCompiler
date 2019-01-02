namespace CppCompiler
{
    partial class InputSentenceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputSentenceForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnLL1Parsing = new System.Windows.Forms.ToolStripButton();
            this.dgvLL1Parsing = new System.Windows.Forms.DataGridView();
            this.lblLL1Parsing = new System.Windows.Forms.Label();
            this.txtSentence = new System.Windows.Forms.TextBox();
            this.lblInputSentence = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLL1Parsing)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnLL1Parsing});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(933, 40);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnLL1Parsing
            // 
            this.tsbtnLL1Parsing.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnLL1Parsing.Image")));
            this.tsbtnLL1Parsing.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnLL1Parsing.Name = "tsbtnLL1Parsing";
            this.tsbtnLL1Parsing.Size = new System.Drawing.Size(87, 37);
            this.tsbtnLL1Parsing.Text = "执行LL(1)分析";
            this.tsbtnLL1Parsing.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnLL1Parsing.Click += new System.EventHandler(this.tsbtnLL1Parsing_Click);
            // 
            // dgvLL1Parsing
            // 
            this.dgvLL1Parsing.AllowUserToAddRows = false;
            this.dgvLL1Parsing.AllowUserToDeleteRows = false;
            this.dgvLL1Parsing.AllowUserToResizeRows = false;
            this.dgvLL1Parsing.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvLL1Parsing.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvLL1Parsing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLL1Parsing.ColumnHeadersVisible = false;
            this.dgvLL1Parsing.Location = new System.Drawing.Point(14, 127);
            this.dgvLL1Parsing.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvLL1Parsing.Name = "dgvLL1Parsing";
            this.dgvLL1Parsing.ReadOnly = true;
            this.dgvLL1Parsing.RowHeadersVisible = false;
            this.dgvLL1Parsing.RowTemplate.Height = 23;
            this.dgvLL1Parsing.Size = new System.Drawing.Size(905, 493);
            this.dgvLL1Parsing.TabIndex = 1;
            // 
            // lblLL1Parsing
            // 
            this.lblLL1Parsing.AutoSize = true;
            this.lblLL1Parsing.Location = new System.Drawing.Point(15, 101);
            this.lblLL1Parsing.Name = "lblLL1Parsing";
            this.lblLL1Parsing.Size = new System.Drawing.Size(95, 17);
            this.lblLL1Parsing.TabIndex = 2;
            this.lblLL1Parsing.Text = "LL(1)分析过程：";
            // 
            // txtSentence
            // 
            this.txtSentence.Location = new System.Drawing.Point(284, 59);
            this.txtSentence.Name = "txtSentence";
            this.txtSentence.Size = new System.Drawing.Size(383, 23);
            this.txtSentence.TabIndex = 3;
            // 
            // lblInputSentence
            // 
            this.lblInputSentence.AutoSize = true;
            this.lblInputSentence.Location = new System.Drawing.Point(150, 61);
            this.lblInputSentence.Name = "lblInputSentence";
            this.lblInputSentence.Size = new System.Drawing.Size(128, 17);
            this.lblInputSentence.TabIndex = 4;
            this.lblInputSentence.Text = "请输入待分析的语句：";
            // 
            // InputSentenceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 637);
            this.Controls.Add(this.lblInputSentence);
            this.Controls.Add(this.txtSentence);
            this.Controls.Add(this.lblLL1Parsing);
            this.Controls.Add(this.dgvLL1Parsing);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "InputSentenceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "输入待分析的语句";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLL1Parsing)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnLL1Parsing;
        private System.Windows.Forms.DataGridView dgvLL1Parsing;
        private System.Windows.Forms.Label lblLL1Parsing;
        private System.Windows.Forms.TextBox txtSentence;
        private System.Windows.Forms.Label lblInputSentence;
    }
}