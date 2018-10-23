﻿using System;
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

        private void btnAbout_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.Show();
        }
    }
}