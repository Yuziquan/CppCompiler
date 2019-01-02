using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CppCompiler
{
    public partial class InputSentenceForm : Form
    {
        public InputSentenceForm()
        {
            InitializeComponent();
        }

        private void tsbtnLL1Parsing_Click(object sender, EventArgs e)
        {
            if (!LL1Helper.isChecked)
            {
                MessageBox.Show("请先执行文法的预处理和检查操作！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }

            if (LL1Helper.existedLeftRecursion && LL1Helper.existedLeftFactor)
            {
                MessageBox.Show("当前文法规则存在左递归和左公共因子，需要先消除！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }
            else if (LL1Helper.existedLeftRecursion)
            {
                MessageBox.Show("当前文法规则存在左递归，需要先消除！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }
            else if (LL1Helper.existedLeftFactor)
            {
                MessageBox.Show("当前文法规则存在左公共因子，需要先消除！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }

            if(!LL1Helper.isTableGenerated)
            {
                MessageBox.Show("当前文法规则的LL(1)分析表还未生成，需要先生成该表！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }

            String sentence = txtSentence.Text;

            if(sentence.Equals(""))
            {
                MessageBox.Show("输入语句不能为空！", "错误", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                LL1Helper.DisplayLL1Parsing(sentence, dgvLL1Parsing);
            }
            
        }
    }
}
