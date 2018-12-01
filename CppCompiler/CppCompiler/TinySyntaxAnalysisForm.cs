using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CppCompiler.Tiny_Syntax_Analysis;

namespace CppCompiler
{
    public partial class TinySyntaxAnalysisForm : Form
    {
        public TinySyntaxAnalysisForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 显示Tiny源文件的内容
        /// </summary>
        /// <param name="sourceFileFullName"></param>
        private void DisplaySourceFileContent(string sourceFileFullName)
        {
            rtxtSourceFileContent.ForeColor = Color.Blue;

            // 获取文件拓展名
            string fileExtensionName = Path.GetExtension(sourceFileFullName);

            if (fileExtensionName == ".tiny")
            {
                string oneLineCode = "";

                FileStream fileStream = new FileStream(sourceFileFullName, FileMode.Open, FileAccess.Read, FileShare.Read);

                StreamReader streamReader = new StreamReader(fileStream);

                while ((oneLineCode = streamReader.ReadLine()) != null)
                {
                    rtxtSourceFileContent.Text += oneLineCode + "\r\n";
                }

                streamReader.Close();
                fileStream.Close();
            }
            else
            {
                MessageBox.Show("仅支持后缀名为.tiny的文件！", "错误", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// 显示语法树
        /// </summary>
        /// <param name="sourceFileFullName"></param>
        private void DisplaySyntaxTree(string sourceFileFullName)
        {
            // 获取文件拓展名
            string fileExtensionName = Path.GetExtension(sourceFileFullName);

            if (fileExtensionName == ".txt")
            {
                string oneLineCode = "";

                FileStream fileStream = new FileStream(sourceFileFullName, FileMode.Open, FileAccess.Read, FileShare.Read);

                StreamReader streamReader = new StreamReader(fileStream);

                while ((oneLineCode = streamReader.ReadLine()) != null)
                {
                    rtxtSyntaxTree.Text += oneLineCode + "\r\n";
                }

                streamReader.Close();
                fileStream.Close();
            }
            else
            {
                MessageBox.Show("仅支持后缀名为.txt的文件！", "错误", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }


 

        private void tsbtnSaveSourceCode_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "源代码文件保存为";
            saveFileDialog.Filter = "tiny源程序(*.tiny)|*.tiny";
            saveFileDialog.InitialDirectory = Application.StartupPath;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.FileName = "tiny_source_code.tiny";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                String tinySourceCode = rtxtSourceFileContent.Text.ToString();

                StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
                streamWriter.Write(tinySourceCode);
                streamWriter.Close();
            }
        }

        private void tsbtnDisplaySyntaxTree_Click(object sender, EventArgs e)
        {
            String sourceFileName = "tiny_source_code.tiny";
            String syntaxTreeFileName = "syntax_tree.txt";

            String tinySourceCode = rtxtSourceFileContent.Text.ToString();

            StreamWriter streamWriter = new StreamWriter(sourceFileName);
            streamWriter.Write(tinySourceCode);
            streamWriter.Close();

            GetSyntaxTree.getSyntaxTree(sourceFileName.ToCharArray(), syntaxTreeFileName.ToCharArray());

            rtxtSyntaxTree.Text = "";

            DisplaySyntaxTree(syntaxTreeFileName);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "tiny文件(*.tiny)|*.tiny";
            openFileDialog.Title = "请选择tiny源文件";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = openFileDialog.FileName;

                rtxtSourceFileContent.Text = "";
  
                DisplaySourceFileContent(txtFilePath.Text);
            }
        }
    }
}
