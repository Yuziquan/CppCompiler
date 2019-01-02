using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CppCompiler
{
    public partial class LexerForm : Form
    {
        String generatedSourceCode;

        public LexerForm(String generatedSourceCode)
        {
            InitializeComponent();
            this.generatedSourceCode = generatedSourceCode;
            rtxtLexerCode.Text = generatedSourceCode;
        }


        private void tsbtnSaveLexerCode_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "生成的词法分析程序保存为";
            saveFileDialog.Filter = "c源程序(*.c)|*.c";
            saveFileDialog.InitialDirectory = Application.StartupPath;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.FileName = "Lexical_Analysis_Code.c";
            
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
                streamWriter.Write(generatedSourceCode);
                streamWriter.Close();
            }
        }
    }
}
