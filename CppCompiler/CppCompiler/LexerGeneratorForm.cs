using CppCompiler.Lexical_Analysis;
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
    public partial class LexerGeneratorForm : Form
    {
        public LexerGeneratorForm()
        {
            InitializeComponent();
            lblHint.ForeColor = Color.Red;
        }

        private void tsbtnReadAndConvert_Click(object sender, EventArgs e)
        {
            NFAStateNode.counter = 1;
            DFAStateNode.counter = 1;
            dgvNFA.Rows.Clear();
            dgvDFA.Rows.Clear();
            dgvMinDFA.Rows.Clear();

            String regex = txtRegex.Text;


            if (regex != null && regex != "")
            {
                NFA nfa = new NFA(new RegularExpression(regex));
                List<NFAStateNode> NFAAllStateNodes = nfa.AllStateNodes;
                List<char> NFARoutes = new List<char>();
                NFARoutes.AddRange(nfa.Alphabet);
                NFARoutes.Add(NFA.NULL_CHAR);

                dgvNFA.ColumnCount = 1 + NFARoutes.Count;

                int rowIndex = dgvNFA.Rows.Add();
                dgvNFA.Rows[rowIndex].Cells[0].Value = " ";
                for(int i = 0; i < NFARoutes.Count; i++)
                {
                    dgvNFA.Rows[rowIndex].Cells[i + 1].Value = NFARoutes.ElementAt(i) + "";
                }

                foreach(NFAStateNode node in NFAAllStateNodes)
                {
                    int rowIndex1 = dgvNFA.Rows.Add();
                    dgvNFA.Rows[rowIndex1].Cells[0].Value = "状态 " + node.Id;

                    for (int i = 0; i < NFARoutes.Count; i++)
                    {
                        if (node.Pass(NFARoutes.ElementAt(i)).Count == 0)
                        {
                            dgvNFA.Rows[rowIndex1].Cells[i + 1].Value = "空";
                        }
                        else
                        {
                            StringBuilder cellContent = new StringBuilder();
                            cellContent.Append("{");

                            bool isFirst = true;
                            foreach(NFAStateNode destNode in node.Pass(NFARoutes.ElementAt(i)))
                            {
                                if(isFirst)
                                {
                                    cellContent.Append(destNode.Id + "");
                                    isFirst = false;
                                }
                                else
                                {
                                    cellContent.Append(", " + destNode.Id);
                                }
                            }

                            cellContent.Append("}");

                            dgvNFA.Rows[rowIndex1].Cells[i + 1].Value = cellContent.ToString();
                        }
                    }
                }


                DFA dfa = new DFA(nfa);
                List<DFAStateNode> DFAAllStateNodes = dfa.AllStateNodes;
                List<char> DFARoutes = dfa.GetAlphabet();

                dgvDFA.ColumnCount = 1 + DFARoutes.Count;

                int rowIndex2 = dgvDFA.Rows.Add();
                dgvDFA.Rows[rowIndex2].Cells[0].Value = " ";
                for (int i = 0; i < DFARoutes.Count; i++)
                {
                    dgvDFA.Rows[rowIndex2].Cells[i + 1].Value = DFARoutes.ElementAt(i) + "";
                }

                foreach (DFAStateNode node in DFAAllStateNodes)
                {
                    int rowIndex3 = dgvDFA.Rows.Add();
                    dgvDFA.Rows[rowIndex3].Cells[0].Value = "状态 " + node.Id;

                    for (int i = 0; i < DFARoutes.Count; i++)
                    {
                        DFAStateNode destNode = node.Pass(DFARoutes.ElementAt(i));

                        if (destNode == null)
                        {
                            dgvDFA.Rows[rowIndex3].Cells[i + 1].Value = "空";
                        }
                        else
                        {
                            dgvDFA.Rows[rowIndex3].Cells[i + 1].Value = destNode.Id + "";
                        }
                    }
                }


                dfa.MiniMize();
                List<DFAStateNode> minDFAAllStateNodes = dfa.MinDFAAllStateNodes;
                List<char> minDFARoutes = dfa.GetAlphabet();

                dgvMinDFA.ColumnCount = 1 + minDFARoutes.Count;

                int rowIndex4 = dgvMinDFA.Rows.Add();
                dgvMinDFA.Rows[rowIndex4].Cells[0].Value = " ";
                for (int i = 0; i < minDFARoutes.Count; i++)
                {
                    dgvMinDFA.Rows[rowIndex4].Cells[i + 1].Value = minDFARoutes.ElementAt(i) + "";
                }

                foreach (DFAStateNode node in minDFAAllStateNodes)
                {
                    int rowIndex5 = dgvMinDFA.Rows.Add();
                    dgvMinDFA.Rows[rowIndex5].Cells[0].Value = "状态 " + node.Id;

                    for (int i = 0; i < minDFARoutes.Count; i++)
                    {
                        DFAStateNode destNode = node.Pass(minDFARoutes.ElementAt(i));

                        if (destNode == null)
                        {
                            dgvMinDFA.Rows[rowIndex5].Cells[i + 1].Value = "空";
                        }
                        else
                        {
                            dgvMinDFA.Rows[rowIndex5].Cells[i + 1].Value = destNode.Id + "";
                        }
                    }
                }

            }
            else
            {
                MessageBox.Show("请输入正则表达式！", "错误", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }


           
        }

        private void tsbtnGenerateLexer_Click(object sender, EventArgs e)
        {
            String regex = txtRegex.Text;

            if (regex != null && regex != "")
            {
                NFA nfa = new NFA(new RegularExpression(regex));
                DFA dfa = new DFA(nfa);
                dfa.MiniMize();

                Lexer lexer = new Lexer(dfa);
                LexerForm lexerForm = new LexerForm(lexer.GeneratedSourceCode.ToString());
                lexerForm.Show();
            }
            else
            {
                MessageBox.Show("请输入正则表达式！", "错误", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }

        private void tsbtnImportRegex_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt文件(*.txt)|*.txt";
            openFileDialog.Title = "请选择包含正则表达式的文本文件";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                DisplayRegex(openFileDialog.FileName);
            }
        }

        /// <summary>
        /// 显示导入的文本文件的内容（包含正则表达式）
        /// </summary>
        /// <param name="fileNameWithFullPath"></param>
        private void DisplayRegex(string fileNameWithFullPath)
        {
            string regex = "";

            FileStream fileStream = new FileStream(fileNameWithFullPath, FileMode.Open, FileAccess.Read, FileShare.Read);
            StreamReader streamReader = new StreamReader(fileStream);
            regex = streamReader.ReadLine();

            if (regex != null && regex != "")
            {
                txtRegex.Text = regex;
            }
            else
            {
                MessageBox.Show("导入的文本文件为空，请重新输入正则表达式！", "错误", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }

            streamReader.Close();
            fileStream.Close();
        }

      
    }
}
