using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;


namespace CppCompiler
{
    public partial class LexicalAnalysisForm : Form
    {
        /// <summary>
        /// 关键字(不够的话，后期可以自行添加)
        /// </summary>
        private string[] keyword= {"include", "auto", "const", "double", "float", "int", "short", "struct", "unsigned", "enum",
          "break", "continue", "else", "for", "long", "signed", "switch", "void", "case", "default", "goto","register","sizeof", "typedef",
          "volatile", "char", "do", "extern", "if", "return", "static", "union", "while", "asm", "dynamic_cast", "bool", "explicit","new",
          "static_cast", "typeid", "catch", "false", "operator", "template", "typename", "class", "friend", "private", "this", "using",
          "const_cast", "inline","public","throw","virtual","delete","mutable","protected","true","wchar_t", "namespace",
          "reinterpret_cast", "try", "cin", "cout", "iostream. h", "iostream", "std", "stdio.h", "string.h", "endl"};


        /// <summary>
        /// 特殊符号
        /// </summary>
        private string[] specialWord = {",", ";", "(", ")", "{", "}", "#", "^", "?", ":", ".", "[", "]", "+", "-", "*", "/", "%",
            "=", ">", "<", "!", "~", "|", "&", "&&", "||", "==", ">=", "<=", "!=", "++", "--", "::", "<<", ">>", "+=", "-=", "*=",
            "/=", "%=", "&=", "^=", "->"};


        /// <summary>
        /// 标志当前扫描到的字符是否位于多行注释"/*...*/"中
        /// </summary>
        private bool commentFlag;


        /// <summary>
        /// 文件的扫描结果
        /// </summary>
        private ArrayList scanResult;


        /// <summary>
        /// 文件的压缩结果
        /// </summary>
        private StringBuilder compressResultStringBuilder;


        /// <summary>
        /// 文件是否已经扫描
        /// </summary>
        private bool isScanned;

        /// <summary>
        /// 文件是否已经压缩
        /// </summary>
        private bool isCompressed;



        public LexicalAnalysisForm()
        {
            InitializeComponent();
        }




        /// <summary>
        /// 显示源文件的内容
        /// </summary>
        /// <param name="sourceFileFullName"></param>
        private void DisplaySourceFileContent(string sourceFileFullName)
        {
            rtxtSourceFileContent.ForeColor = Color.Blue;

            // 获取文件拓展名
            string fileExtensionName = Path.GetExtension(sourceFileFullName);

            if (fileExtensionName == ".cpp")
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
                MessageBox.Show("仅支持后缀名为.cpp的文件！", "错误", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// 显示扫描结果
        /// </summary>
        private void DisplayScanResult()
        {
            rtxtScanResult.ForeColor = Color.Red;
            rtxtScanResult.Text = "";

            foreach(string s in scanResult)
            {
                rtxtScanResult.Text += (s + "\r\n");
            }
        }


        /// <summary>
        /// 显示压缩结果
        /// </summary>
        private void DisplayCompressResult()
        {
            rtxtScanResult.ForeColor = Color.Orange;
            rtxtScanResult.Text = "";

            rtxtScanResult.Text = compressResultStringBuilder.ToString();
        }


        /// <summary>
        /// 对一行字符串进行词法分析
        /// </summary>
        /// <param name="oneLineCode"></param>
        private void LexicalAnalysisOnOneLine(string oneLineCode)
        {
            // 字符串oneLineCode当前扫描的位置
            int curScanIndex = 0;

            // 如果当前扫描位置处于注释中
            if(commentFlag == true)
            {
                // 当前还未扫描到 "*/"
                while (((curScanIndex <= oneLineCode.Length - 1) && oneLineCode[curScanIndex] != '*')
                || ((curScanIndex < oneLineCode.Length - 1) && oneLineCode[curScanIndex] == '*' && oneLineCode[curScanIndex + 1] != '/'))
                {
                    // 继续后移
                    curScanIndex++;
                }

                // 该行字符串还未扫描完毕(也意味着多行注释在本行中结束)
                if (curScanIndex < oneLineCode.Length - 1)
                {
                    scanResult.Add("*/" + "\t\t" + "多行注释尾");

                    // 注释结束
                    commentFlag = false;

                    // 继续后移
                    curScanIndex += 2;
                }
            }

            // 该行字符串还未扫描完毕
            while (curScanIndex < oneLineCode.Length - 1)
            {
                // 过滤掉空格、制表符
                if (oneLineCode[curScanIndex] == ' ' || oneLineCode[curScanIndex] == '\t')
                {
                    curScanIndex++;
                    continue;
                }


                // 处理头文件名
                if((oneLineCode[curScanIndex] == '<' || oneLineCode[curScanIndex] == '"') 
                    && oneLineCode[0] == '#')
                {
                    scanResult.Add(oneLineCode[curScanIndex] + "\t\t" + "特殊符号");

                    curScanIndex++;

                    // 存放扫描到的头文件名
                    StringBuilder headerFileNameStringBuilder = new StringBuilder();
                    
                    // 头文件名还未扫描完毕
                    while(oneLineCode[curScanIndex] != '>' && oneLineCode[curScanIndex] != '"')
                    {
                        headerFileNameStringBuilder.Append(oneLineCode[curScanIndex++]);
                    }

                    scanResult.Add(headerFileNameStringBuilder.ToString() + "\t\t" + "关键字");

                    scanResult.Add(oneLineCode[curScanIndex] + "\t\t" + "特殊符号");

                    curScanIndex++;
                }
                // 扫描到单行注释"//xxxxx"
                else if(oneLineCode[curScanIndex] == '/' && oneLineCode[curScanIndex + 1] == '/')
                {
                    scanResult.Add("//" + "\t\t" + "单行注释");

                    // 直接整行跳过扫描
                    curScanIndex = oneLineCode.Length;
                }
                // 扫描到多行注释"/*...*/"头部的"/*"
                else if(oneLineCode[curScanIndex] == '/' && oneLineCode[curScanIndex + 1] == '*')
                {
                    scanResult.Add("/*" + "\t\t" + "多行注释头");

                    commentFlag = true;
                    curScanIndex += 2;

                    // 当前还未扫描到 "*/"
                    while (((curScanIndex <= oneLineCode.Length - 1) && oneLineCode[curScanIndex] != '*')
                    || ((curScanIndex < oneLineCode.Length - 1) && oneLineCode[curScanIndex] == '*' && oneLineCode[curScanIndex + 1] != '/'))
                    {
                        // 继续后移
                        curScanIndex++;
                    }

                    // 该行字符串还未扫描完毕(也意味着多行注释在本行中结束)
                    if (curScanIndex < oneLineCode.Length - 1)
                    {
                        scanResult.Add("*/" + "\t\t" + "多行注释尾");

                        // 注释结束
                        commentFlag = false;

                        // 继续后移
                        curScanIndex += 2;
                    }
                }
                // 扫描以字母、下划线开头的字符串(标识符/关键字只能以字母或下划线开头)
                else if(IsAlpha(oneLineCode[curScanIndex]) || oneLineCode[curScanIndex] == '_')
                {
                    // 存放扫描到的字符串
                    StringBuilder stringBuilder = new StringBuilder();

                    // 字符串还未扫描完毕（标识符/关键字可以由字母、数字、下划线组成）
                    while (IsAlpha(oneLineCode[curScanIndex]) || IsDigit(oneLineCode[curScanIndex]) || oneLineCode[curScanIndex] == '_')
                    {
                        stringBuilder.Append(oneLineCode[curScanIndex++]);
                    }

                    // 扫描到的字符串属于关键字
                    if(IsKeyword(stringBuilder.ToString()))
                    {
                        scanResult.Add(stringBuilder.ToString() + "\t\t" + "关键字");
                    }
                    // 扫描到的字符串属于标识符
                    else
                    {
                        scanResult.Add(stringBuilder.ToString() + "\t\t" + "标识符");
                    }
                }
                // 是否是数字（整数、浮点数、浮点数的科学计数表示法、数的不同机制表示，但不考虑+/-号）
                // 比如123、12.22、.12e3、1.233e2、0b1001、0xa3、074、
                else if(IsDigit(oneLineCode[curScanIndex]) || 
                    oneLineCode[curScanIndex] == '.'&& IsDigit(oneLineCode[curScanIndex + 1]))
                {
                    // 存放扫描到的数字
                    StringBuilder numberStringBuilder = new StringBuilder();

                    while(oneLineCode[curScanIndex] != ' '
                        && oneLineCode[curScanIndex] != '\t'
                        && oneLineCode[curScanIndex] != '\0'
                        && (!IsSpecialWord(oneLineCode[curScanIndex] + "")
                        || oneLineCode[curScanIndex] == '-'
                        || oneLineCode[curScanIndex] == '+'
                        || oneLineCode[curScanIndex] == '.'))
                    {
                        numberStringBuilder.Append(oneLineCode[curScanIndex++]);
                    }

                    scanResult.Add(numberStringBuilder.ToString() + "\t\t" + "数字");
                }
                // 是否是特殊符号
                else if(IsSpecialWord(oneLineCode[curScanIndex] + ""))
                {
                    StringBuilder specialWordStringBuilder = new StringBuilder();
                    specialWordStringBuilder.Append(oneLineCode[curScanIndex]);
                    specialWordStringBuilder.Append(oneLineCode[curScanIndex + 1]);

                    // 是两个字符的特殊符号
                    if(IsSpecialWord(specialWordStringBuilder.ToString()))
                    {
                        scanResult.Add(specialWordStringBuilder.ToString() + "\t\t" + "特殊符号");
                        curScanIndex += 2;
                    }
                    // 是一个字符的特殊符号
                    else
                    {
                        scanResult.Add(oneLineCode[curScanIndex++] + "\t\t" + "特殊符号");
                    }
                        
                }
                // 是否是字符或字符串
                else if(oneLineCode[curScanIndex]=='\'' || oneLineCode[curScanIndex] == '"')
                {
                    // 存放扫描到的字符或字符串
                    StringBuilder stringBuilder = new StringBuilder();

                    // 是字符（包括转义字符）
                    if(oneLineCode[curScanIndex] == '\'')
                    {
                        stringBuilder.Append(oneLineCode[curScanIndex++]);

                        while (oneLineCode[curScanIndex] != '\'')
                        {
                            stringBuilder.Append(oneLineCode[curScanIndex++]);
                        }

                        stringBuilder.Append(oneLineCode[curScanIndex]);

                        // 考虑到这种形式：str = '\''
                        if(oneLineCode[curScanIndex + 1] == '\'')
                        {
                            stringBuilder.Append(oneLineCode[++curScanIndex]);
                        }

                        scanResult.Add(stringBuilder.ToString() + "\t\t" + "字符");
                        curScanIndex++;
                    }
                    // 是字符串
                    else
                    {
                        stringBuilder.Append(oneLineCode[curScanIndex++]);

                        // 考虑到这种形式：str = "Hello \"world\"! "
                        while(oneLineCode[curScanIndex] != '"' || oneLineCode[curScanIndex - 1] == '\\')
                        {
                            stringBuilder.Append(oneLineCode[curScanIndex++]);
                        }

                        stringBuilder.Append(oneLineCode[curScanIndex]);

                        scanResult.Add(stringBuilder.ToString() + "\t\t" + "字符串");
                        curScanIndex++;
                    }
                }
            }

            if(curScanIndex == oneLineCode.Length - 1)
            {
                // 是一个字符的特殊符号
                if (IsSpecialWord(oneLineCode[curScanIndex] + ""))
                {
                    scanResult.Add(oneLineCode[curScanIndex] + "\t\t" + "特殊符号");
                }
            }
        }


        /// <summary>
        /// 对整个文件进行词法分析扫描
        /// </summary>
        /// <param name="sourceFileFullName"></param>
        private void LexicalAnalysisOnFile(string sourceFileFullName)
        {
            // 获取文件拓展名
            string fileExtensionName = Path.GetExtension(sourceFileFullName);

            if(fileExtensionName == ".cpp")
            {
                string oneLineCode = "";

                FileStream fileStream = new FileStream(sourceFileFullName, FileMode.Open, FileAccess.Read, FileShare.Read);

                StreamReader streamReader = new StreamReader(fileStream);

                // 逐行扫描
                while ((oneLineCode = streamReader.ReadLine()) != null)
                {
                    LexicalAnalysisOnOneLine(oneLineCode);
                }

                streamReader.Close();
                fileStream.Close();
            }
            else
            {
                MessageBox.Show("仅支持后缀名为.cpp的文件！", "错误", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// 对一行代码进行压缩
        /// </summary>
        /// <param name="oneLineCode"></param>
        private void CompressOneLine(string oneLineCode)
        {
            // 若一个字符的后一个字符为空格或制表符，则将该字符保存在preChar
            char preChar = ' ';

            // 字符串oneLineCode当前扫描的位置
            int curScanIndex = 0;

            // 如果当前扫描位置处于注释中
            if (commentFlag == true)
            {
                // 当前还未扫描到 "*/"
                while (((curScanIndex <= oneLineCode.Length - 1) && oneLineCode[curScanIndex] != '*')
                || ((curScanIndex < oneLineCode.Length - 1) && oneLineCode[curScanIndex] == '*' && oneLineCode[curScanIndex + 1] != '/'))
                {
                    // 继续后移
                    curScanIndex++;
                }


                // 该行字符串还未扫描完毕(也意味着多行注释在本行中结束)
                if (curScanIndex < oneLineCode.Length - 1)
                {
                    // 注释结束
                    commentFlag = false;

                    // 继续后移
                    curScanIndex += 2;
                }
            }

            // 该行字符串还未扫描完毕
            while (curScanIndex < oneLineCode.Length - 1)
            {
                // 过滤掉空格、制表符
                if (oneLineCode[curScanIndex] == ' ' || oneLineCode[curScanIndex] == '\t')
                {
                    curScanIndex++;
                    continue;
                }

                // 处理头文件名
                if ((oneLineCode[curScanIndex] == '<' || oneLineCode[curScanIndex] == '"')
                    && oneLineCode[0] == '#')
                {
                    // 头文件名还未扫描完毕
                    while (oneLineCode[curScanIndex] != '>' && oneLineCode[curScanIndex] != '"')
                    {
                        compressResultStringBuilder.Append(oneLineCode[curScanIndex++]);
                    }

                    compressResultStringBuilder.Append(oneLineCode[curScanIndex++] + "\r\n");
                }
                // 扫描到单行注释"//xxxxx"
                else if (oneLineCode[curScanIndex] == '/' && oneLineCode[curScanIndex + 1] == '/')
                {
                    // 直接整行跳过扫描
                    curScanIndex = oneLineCode.Length;
                }
                // 扫描到多行注释"/*...*/"头部的"/*"
                else if (oneLineCode[curScanIndex] == '/' && oneLineCode[curScanIndex + 1] == '*')
                {
                    commentFlag = true;
                    curScanIndex += 2;

                    // 当前还未扫描到 "*/"
                    while (((curScanIndex <= oneLineCode.Length - 1) && oneLineCode[curScanIndex] != '*')
                    || ((curScanIndex < oneLineCode.Length - 1) && oneLineCode[curScanIndex] == '*' && oneLineCode[curScanIndex + 1] != '/'))
                    {
                        // 继续后移
                        curScanIndex++;
                    }

                    // 该行字符串还未扫描完毕(也意味着多行注释在本行中结束)
                    if (curScanIndex < oneLineCode.Length - 1)
                    {
                        // 注释结束
                        commentFlag = false;

                        // 继续后移
                        curScanIndex += 2;
                    }
                }
                // 扫描到空格（字符）
                else if ((curScanIndex + 2 <= oneLineCode.Length - 1)
                    && oneLineCode[curScanIndex] == '\''
                    && oneLineCode[curScanIndex + 1] == ' '
                    && oneLineCode[curScanIndex + 2] == '\'')
                {
                    compressResultStringBuilder.Append(oneLineCode[curScanIndex] + " " + oneLineCode[curScanIndex + 2]);
                    curScanIndex += 3;
                }
                // 扫描到字符串（含空格）
                else if ((curScanIndex > 0)
                    && oneLineCode[curScanIndex] == '"'
                    && oneLineCode[curScanIndex - 1] != '\''
                    && oneLineCode[curScanIndex + 1] != '\'')
                {
                    compressResultStringBuilder.Append(oneLineCode[curScanIndex++]);

                    // 考虑到这种形式：str = "Hello \"world\"! "
                    while (oneLineCode[curScanIndex] != '"' || oneLineCode[curScanIndex - 1] == '\\')
                    {
                        compressResultStringBuilder.Append(oneLineCode[curScanIndex++]);
                    }

                    compressResultStringBuilder.Append(oneLineCode[curScanIndex]);
                    curScanIndex++;
                }
                // 字符为非空白符
                else if (oneLineCode[curScanIndex] != ' ' && oneLineCode[curScanIndex] != '\t')
                {
                    // 当前字符的前一个字符为空格或制表符
                    if (curScanIndex >= 2 &&
                        (oneLineCode[curScanIndex - 1] == ' ' || oneLineCode[curScanIndex - 1] == '\t'))
                    {
                        /* 如果当前情形是：两个非空白符（只能为字母或数字）夹着一个或多个空白符（如空格、制表符等），
                        则压缩时应该保留至少一个空格用以分隔，才能保证压缩后的cpp文件能够被编译执行*/
                        if((IsAlpha(preChar)|| IsDigit(preChar)) 
                            && (IsAlpha(oneLineCode[curScanIndex]) || IsDigit(oneLineCode[curScanIndex])))
                        {
                            compressResultStringBuilder.Append(" ");
                        }
                    }

                    compressResultStringBuilder.Append(oneLineCode[curScanIndex++]);

                    if(oneLineCode[curScanIndex] == ' ' || oneLineCode[curScanIndex] == '\t')
                    {
                        preChar = oneLineCode[curScanIndex - 1];
                    }
                }
            }

            if (curScanIndex == oneLineCode.Length - 1)
            {
                // 是一个字符的特殊符号
                if (IsSpecialWord(oneLineCode[curScanIndex] + ""))
                {
                    compressResultStringBuilder.Append(oneLineCode[curScanIndex]);

                }
            }
        }


        /// <summary>
        /// 对整个文件进行压缩
        /// </summary>
        /// <param name="sourceFileFullName"></param>
        private void CompressFile(string sourceFileFullName)
        {
            // 获取文件拓展名
            string fileExtensionName = Path.GetExtension(sourceFileFullName);

            if (fileExtensionName == ".cpp")
            {
                string oneLineCode = "";

                FileStream fileStream = new FileStream(sourceFileFullName, FileMode.Open, FileAccess.Read, FileShare.Read);

                StreamReader streamReader = new StreamReader(fileStream);

                // 逐行压缩
                while ((oneLineCode = streamReader.ReadLine()) != null)
                {
                    CompressOneLine(oneLineCode);
                }

                streamReader.Close();
                fileStream.Close();
            }
            else
            {
                MessageBox.Show("仅支持后缀名为.cpp的文件！", "错误", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// 判断字符是否代表字母
        /// </summary>
        /// <param name="ch"></param>
        /// <returns></returns>
        private bool IsAlpha(char ch)
        {
            if(ch >= 'a' && ch <= 'z' || ch >= 'A' && ch <= 'Z')
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 判断字符是否代表数字
        /// </summary>
        /// <param name="ch"></param>
        /// <returns></returns>
        private bool IsDigit(char ch)
        {
            if (ch >= '0' && ch <= '9')
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 判断字符是否代表关键字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private bool IsKeyword(string str)
        {
            return ((IList)keyword).Contains(str);
        }


        /// <summary>
        /// 判断字符是否代表特殊字符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private bool IsSpecialWord(string str)
        {
            return ((IList)specialWord).Contains(str);
        }


       

        private void btnSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "cpp文件(*.cpp)|*.cpp";
            openFileDialog.Title = "请选择需要扫描的C++源文件";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = openFileDialog.FileName;

                rtxtSourceFileContent.Text = "";
                rtxtScanResult.Text = "";

                DisplaySourceFileContent(txtFilePath.Text);

                isScanned = false;
                isCompressed = false;
            }
        }

        private void tsbtnScanSourceFile_Click(object sender, EventArgs e)
        {
            if(txtFilePath.Text == "")
            {
                MessageBox.Show("请选择待扫描的C++源文件！", "错误", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                commentFlag = false;
                lblScanResult.Text = "词法分析扫描结果：";
                scanResult = new ArrayList();
                LexicalAnalysisOnFile(txtFilePath.Text);
                DisplayScanResult();

                isScanned = true;
            }
        }   

        private void tsbtnSaveScanResult_Click(object sender, EventArgs e)
        {
            if (txtFilePath.Text == "")
            {
                MessageBox.Show("请选择待扫描的C++源文件！", "错误", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else if(!isScanned)
            {
                MessageBox.Show("请先扫描源文件！", "错误", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "将扫描结果保存为";
                saveFileDialog.InitialDirectory = Application.StartupPath;
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.FileName = (new FileInfo(txtFilePath.Text)).Name.Split('.')[0] + "(词法分析扫描结果).txt";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);

                    foreach (string s in scanResult)
                    {
                        streamWriter.WriteLine(s + "\r\n");
                    }

                    streamWriter.Close();
                }
            }
        }

        private void tsbtnCompress_Click(object sender, EventArgs e)
        {
            if (txtFilePath.Text == "")
            {
                MessageBox.Show("请选择待扫描的C++源文件！", "错误", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                commentFlag = false;
                lblScanResult.Text = "词法分析压缩结果：";
                compressResultStringBuilder = new StringBuilder();
                CompressFile(txtFilePath.Text);
                DisplayCompressResult();

                isCompressed = true;
            }
        }

        private void tsbtnSaveCompressResult_Click(object sender, EventArgs e)
        {
            if (txtFilePath.Text == "")
            {
                MessageBox.Show("请选择待扫描的C++源文件！", "错误", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else if(!isCompressed)
            {
                MessageBox.Show("请先压缩源文件！", "错误", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "将压缩结果保存为";
                saveFileDialog.InitialDirectory = Application.StartupPath;
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.FileName = "compressed_" + (new FileInfo(txtFilePath.Text)).Name;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
                    streamWriter.Write(compressResultStringBuilder.ToString());                    
                    streamWriter.Close();
                }
            }
        }

     
    }
}
