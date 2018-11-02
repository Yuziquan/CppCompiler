using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CppCompiler.Lexical_Analysis
{
    /// <summary>
    /// 词法分析程序生成器
    /// </summary>
    public class Lexer
    {
        /// <summary>
        /// 最小化的DFA的开始状态节点
        /// </summary>
        private DFAStateNode startStateNode;

        /// <summary>
        /// 最小化的DFA的结束状态节点集
        /// </summary>
        private List<DFAStateNode> endStateNodes;

        private List<DFAStateNode> allStateNodes;

        /// <summary>
        /// 生成的词法分析程序（C语言描述）
        /// </summary>
        private StringBuilder generatedSourceCode;
        public StringBuilder GeneratedSourceCode
        {
            get { return generatedSourceCode; }
            set { generatedSourceCode = value; }
        }

        public Lexer(DFA dfa)
        {
            startStateNode = dfa.MinDFAStartStateNode;
            endStateNodes = dfa.MinDFAEndStateNodes;
            allStateNodes = dfa.MinDFAAllStateNodes;
            GenerateSourceCode();
        }



        /// <summary>
        /// 生成词法分析程序（C语言描述）
        /// </summary>
        private void GenerateSourceCode()
        {
            generatedSourceCode = new StringBuilder();
            GenerateHeadSourceCode();
            GenerateBodySourceCode();
            GenerateFootSourceCode();
        }


        /// <summary>
        /// 生成词法分析程序的头部（C语言描述）
        /// </summary>
        private void GenerateHeadSourceCode()
        {
            generatedSourceCode.Append("#include<stdio.h>\r\n\r\n");
            generatedSourceCode.Append("int startStateId = " + startStateNode.Id + ";\r\n");
            generatedSourceCode.Append("int endStateIds[200] = {");

            bool isFirst = true;

            foreach(DFAStateNode node in endStateNodes)
            {
                if(isFirst)
                {
                    generatedSourceCode.Append(node.Id);
                    isFirst = false;
                }
                else
                {
                    generatedSourceCode.Append(", " + node.Id);
                }
            }

            generatedSourceCode.Append("};\r\n");
            generatedSourceCode.Append("int endStatesNum = " + endStateNodes.Count + ";\r\n\r\n");
            generatedSourceCode.Append("bool isEndStateId(int stateId)\r\n");
            generatedSourceCode.Append("{ \r\n");
            generatedSourceCode.Append("\tfor (int i = 0; i < endStatesNum; i++)\r\n");
            generatedSourceCode.Append("\t{ \r\n");
            generatedSourceCode.Append("\t\tif (stateId == endStateIds[i])\r\n");
            generatedSourceCode.Append("\t\t{ \r\n");
            generatedSourceCode.Append("\t\t\treturn true;\r\n");
            generatedSourceCode.Append("\t\t} \r\n");
            generatedSourceCode.Append("\t} \r\n");
            generatedSourceCode.Append("\treturn false;\r\n");
            generatedSourceCode.Append("} \r\n\r\n");

            generatedSourceCode.Append("int main()\r\n");
            generatedSourceCode.Append("{ \r\n");
            generatedSourceCode.Append("\tint curStateId = startStateId;\r\n");
            generatedSourceCode.Append("\tprintf(\"Please input a string: \\n\");\r\n");
            generatedSourceCode.Append("\tchar c = getchar();\r\n\r\n");
            generatedSourceCode.Append("\twhile (curStateId != -1 && c != '\\n')\r\n");
            generatedSourceCode.Append("\t{ \r\n");
            generatedSourceCode.Append("\t\tswitch (curStateId)\r\n");
            generatedSourceCode.Append("\t\t{ \r\n");
        }


        /// <summary>
        /// 生成词法分析程序的主体部分（C语言描述）
        /// </summary>
        private void GenerateBodySourceCode()
        {
            foreach (DFAStateNode node in allStateNodes)
            {
                GenerateCaseCode(node);
            }
        }


        /// <summary>
        /// 生成"case"部分的代码块
        /// </summary>
        /// <param name="stateNode"></param>
        private void GenerateCaseCode(DFAStateNode stateNode)
        {
            generatedSourceCode.Append("\t\t\tcase " + stateNode.Id + ":\r\n");
            generatedSourceCode.Append("\t\t\t\tswitch(c)\r\n");
            generatedSourceCode.Append("\t\t\t\t{ \r\n");

            foreach (Edge<DFAStateNode> edge in stateNode.EdgeList)
            {
                generatedSourceCode.Append("\t\t\t\t\tcase '" + edge.Route + "':\r\n");
                generatedSourceCode.Append("\t\t\t\t\t\tc = getchar();\r\n");
                generatedSourceCode.Append("\t\t\t\t\t\tcurStateId = " + edge.EndStateNode.Id + ";\r\n");
                generatedSourceCode.Append("\t\t\t\t\t\tbreak;\r\n\r\n");
            }

            generatedSourceCode.Append("\t\t\t\t\tdefault:\r\n");
            generatedSourceCode.Append("\t\t\t\t\t\tcurStateId = -1;\r\n");
            generatedSourceCode.Append("\t\t\t\t} \r\n");
            generatedSourceCode.Append("\t\t\t\tbreak; \r\n\r\n");
        }

        /// <summary>
        /// 生成词法分析程序的尾部（C语言描述）
        /// </summary>
        private void GenerateFootSourceCode()
        {
            generatedSourceCode.Append("\t\t} \r\n");
            generatedSourceCode.Append("\t} \r\n\r\n");
            generatedSourceCode.Append("\tif (isEndStateId(curStateId) && c == '\\n')\r\n");
            generatedSourceCode.Append("\t{ \r\n");
            generatedSourceCode.Append("\t\tprintf(\"Accept!\\n\");\r\n");
            generatedSourceCode.Append("\t} \r\n");
            generatedSourceCode.Append("\telse\r\n");
            generatedSourceCode.Append("\t{ \r\n");
            generatedSourceCode.Append("\t\tprintf(\"Reject!\\n\");\r\n");
            generatedSourceCode.Append("\t} \r\n\r\n");
            generatedSourceCode.Append("\treturn 0;\r\n");
            generatedSourceCode.Append("} \r\n");
        }

    }
}
