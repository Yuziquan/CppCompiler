namespace CppCompiler
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.lblApplicationName = new System.Windows.Forms.Label();
            this.btnLexicalAnalysis = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblApplicationName
            // 
            this.lblApplicationName.AutoSize = true;
            this.lblApplicationName.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblApplicationName.Location = new System.Drawing.Point(198, 30);
            this.lblApplicationName.Name = "lblApplicationName";
            this.lblApplicationName.Size = new System.Drawing.Size(221, 22);
            this.lblApplicationName.TabIndex = 0;
            this.lblApplicationName.Text = "C++源文件编译器的模拟程序";
            // 
            // btnLexicalAnalysis
            // 
            this.btnLexicalAnalysis.BackColor = System.Drawing.SystemColors.Control;
            this.btnLexicalAnalysis.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLexicalAnalysis.Location = new System.Drawing.Point(232, 73);
            this.btnLexicalAnalysis.Name = "btnLexicalAnalysis";
            this.btnLexicalAnalysis.Size = new System.Drawing.Size(145, 29);
            this.btnLexicalAnalysis.TabIndex = 1;
            this.btnLexicalAnalysis.Text = "词法分析";
            this.btnLexicalAnalysis.UseVisualStyleBackColor = false;
            this.btnLexicalAnalysis.Click += new System.EventHandler(this.btnLexicalAnalysis_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.BackColor = System.Drawing.SystemColors.Control;
            this.btnAbout.Location = new System.Drawing.Point(232, 251);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(144, 29);
            this.btnAbout.TabIndex = 2;
            this.btnAbout.Text = "关于";
            this.btnAbout.UseVisualStyleBackColor = false;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(618, 350);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnLexicalAnalysis);
            this.Controls.Add(this.lblApplicationName);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "主菜单";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblApplicationName;
        private System.Windows.Forms.Button btnLexicalAnalysis;
        private System.Windows.Forms.Button btnAbout;
    }
}

