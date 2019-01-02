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
    public partial class LL1AnalysisForm : Form
    {
        public LL1AnalysisForm()
        {
            InitializeComponent();
        }

        private void tsbtnImportGrammarFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt文件(*.txt)|*.txt";
            openFileDialog.Title = "请选择需要导入的文法规则文件";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                rtxtGrammar.Text = "";

                String fileName = openFileDialog.FileName;

                string oneLineCode = "";

                FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);

                StreamReader streamReader = new StreamReader(fileStream);

                while ((oneLineCode = streamReader.ReadLine()) != null)
                {
                    rtxtGrammar.Text += oneLineCode + "\r\n";
                }

                streamReader.Close();
                fileStream.Close();
            }
        }

        private void tsbtnSaveGrammarAsFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "当前文法规则保存为";
            saveFileDialog.Filter = "txt文件(*.txt)|*.txt";
            saveFileDialog.InitialDirectory = Application.StartupPath;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.FileName = "grammar.txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                String grammar = rtxtGrammar.Text.ToString();

                StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
                streamWriter.Write(grammar);
                streamWriter.Close();
            }
        }

        private void tsbtnCheckGrammar_Click(object sender, EventArgs e)
        {
            LL1Helper.CheckGrammar(rtxtGrammar);
        }

        private void tsbtnLeftRecursionRemoval_Click(object sender, EventArgs e)
        {
            LL1Helper.LeftRecursionRemoval(rtxtLeftRecursionRemoval);
        }

        private void tsbtnLeftFactoring_Click(object sender, EventArgs e)
        {
            LL1Helper.LeftFactoring(rtxtLeftFactoring);
        }

        private void tsbtnGenerateLL1ParsingTable_Click(object sender, EventArgs e)
        {
            LL1Helper.GenerateLL1ParsingTable(dgvLL1ParsingTable);
        }

        private void tsbtnInputSentence_Click(object sender, EventArgs e)
        {
            InputSentenceForm inputSentenceForm = new InputSentenceForm();
            inputSentenceForm.Show();
        }

        private void btnInputEmptyString_Click(object sender, EventArgs e)
        {
            rtxtGrammar.Text += "ε";
        }
    }
}
