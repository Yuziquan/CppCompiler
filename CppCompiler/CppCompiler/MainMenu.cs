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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnLexicalAnalysis_Click(object sender, EventArgs e)
        {
            LexicalAnalysisForm lexicalAnalysisForm = new LexicalAnalysisForm();
            lexicalAnalysisForm.Show();
        }

  
        private void btnLexerGenerator_Click(object sender, EventArgs e)
        {
            LexerGeneratorForm lexerGeneratorForm = new LexerGeneratorForm();
            lexerGeneratorForm.Show();
        }

        private void btnTinySyntaxAnalysis_Click(object sender, EventArgs e)
        {
            TinySyntaxAnalysisForm tinySyntaxAnalysisForm = new TinySyntaxAnalysisForm();
            tinySyntaxAnalysisForm.Show();
        }


        private void btnLL1Analysis_Click(object sender, EventArgs e)
        {
            LL1AnalysisForm lL1AnalysisForm = new LL1AnalysisForm();
            lL1AnalysisForm.Show();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.Show();
        }

    }
}
