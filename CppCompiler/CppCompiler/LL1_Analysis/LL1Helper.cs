using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CppCompiler
{
    public static class LL1Helper
    {
        /// <summary>
        /// 当前系统中根据需要新建的新非终结符
        /// </summary>
        public static List<String> newNonterminalSymbolList = new List<string>();

        /// <summary>
        /// 文法中所有的非终结符
        /// </summary>
        public static List<String> nonterminalSymbolsOfGrammar = new List<string>();

        /// <summary>
        /// 文法中所有的终结符
        /// </summary>
        public static List<String> terminalSymbolsOfGrammar = new List<string>();

        /// <summary>
        /// LL(1)分析表
        /// </summary>
        public static string[,] table;


        /// <summary>
        /// 文法规则列表
        /// </summary>
        public static List<List<String>> grammarRuleList = new List<List<string>>();

        /// <summary>
        /// 文法规则列表的一个副本
        /// </summary>
        public static List<List<String>> copyOfGrammarRuleList = new List<List<string>>();

        /// <summary>
        /// 文法规则列表的一个副本
        /// </summary>
        public static List<List<String>> copy1OfGrammarRuleList = new List<List<string>>();


        /// <summary>
        /// 文法规则列表的一个副本
        /// </summary>
        public static List<List<String>> copy2OfGrammarRuleList = new List<List<string>>();

        /// <summary>
        /// 标记能/不能推出ε的非终结符
        /// </summary>
        public static Dictionary<String, bool> nonterminalSymbolRelEmptyStr = new Dictionary<String, bool>();


        /// <summary>
        /// 保存文法规则中非终结符/终结符的FIRST集合
        /// </summary>
        public static Dictionary<String, List<String>> firstSetOfSymbol = new Dictionary<String, List<String>>();

        /// <summary>
        /// 保存文法规则右部产生式的FIRST集合
        /// </summary>
        public static Dictionary<String, List<String>> firstSetOfProduction = new Dictionary<String, List<String>>();

        /// <summary>
        /// 保存文法规则左部非终结符的FOLLOW集合
        /// </summary>
        public static Dictionary<String, List<String>> followSetOfNonterminalSymbol = new Dictionary<String, List<String>>();


        /// <summary>
        /// 文法规则的开始符号（默认取文法规则列表的第一条文法的左部非终结符）
        /// </summary>
        public static String startSymbol = "";


        /// <summary>
        /// 文法规则列表是否存在左递归
        /// </summary>
        public static bool existedLeftRecursion = false;

        /// <summary>
        /// 文法规则列表是否存在左公共因子
        /// </summary>
        public static bool existedLeftFactor = false;

        /// <summary>
        /// 是否已经进行了语法预处理操作
        /// </summary>
        public static bool isPreproccessed = false;
    
        /// <summary>
        /// 是否已经进行了语法检查操作
        /// </summary>
        public static bool isChecked = false;


        /// <summary>
        /// LL(1)分析表是否已经生成
        /// </summary>
        public static bool isTableGenerated = false;


        /// <summary>
        /// 重置系统状态
        /// </summary>
        public static void Reset()
        {
            newNonterminalSymbolList = new List<string>();
            nonterminalSymbolsOfGrammar = new List<string>();
            terminalSymbolsOfGrammar = new List<string>();
            grammarRuleList = new List<List<string>>();
            copyOfGrammarRuleList = new List<List<string>>();
            copy1OfGrammarRuleList = new List<List<string>>();
            copy2OfGrammarRuleList = new List<List<string>>();
            nonterminalSymbolRelEmptyStr = new Dictionary<string, bool>();
            firstSetOfSymbol = new Dictionary<string, List<string>>();
            firstSetOfProduction = new Dictionary<string, List<string>>();
            followSetOfNonterminalSymbol = new Dictionary<string, List<string>>();
            startSymbol = "";
            existedLeftRecursion = false;
            existedLeftFactor = false;
            isPreproccessed = false;
            isChecked = false;
            isTableGenerated = false;
        }


        /// <summary>
        /// 对输入的文法规则进行预处理，以链表方式读入内存
        /// </summary>
        public static void GrammarInputPreproccess(RichTextBox grammarRichTextBox)
        {
            if (grammarRichTextBox.Text.Equals(""))
            {
                MessageBox.Show("文法规则不能为空！", "错误", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }

            foreach (String line in grammarRichTextBox.Lines)
            {
                // 暂存一条文法规则
                List<String> grammarRule = new List<String>();
                List<String> copyOfGrammarRule = new List<String>();
                List<String> copy1OfGrammarRule = new List<String>();
                List<String> copy2OfGrammarRule = new List<String>();

                // 寻找每一条文法规则的右部产生式的开始标志->
                int index1 = line.IndexOf('>');

                if (index1 == -1)
                {
                    MessageBox.Show("文法规则有误！", "错误", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }

                // 添加 -> 左边的非终结符
                grammarRule.Add(line.Substring(0, index1 - 1));
                copyOfGrammarRule.Add(line.Substring(0, index1 - 1));
                copy1OfGrammarRule.Add(line.Substring(0, index1 - 1));
                copy2OfGrammarRule.Add(line.Substring(0, index1 - 1));


                int index2 = line.IndexOf('|');

                // 右部产生式含 | 
                if (index2 != -1)
                {
                    // 根据 | 进行拆分
                    String[] tempArray = line.Substring(index1 + 1).Split('|');

                    // 添加 -> 右边的产生式
                    grammarRule.AddRange(new List<String>(tempArray));
                    copyOfGrammarRule.AddRange(new List<String>(tempArray));
                    copy1OfGrammarRule.AddRange(new List<String>(tempArray));
                    copy2OfGrammarRule.AddRange(new List<String>(tempArray));
                }
                // 右部产生式不含 | 
                else
                {
                    // 添加 -> 右边的产生式
                    grammarRule.Add(line.Substring(index1 + 1));
                    copyOfGrammarRule.Add(line.Substring(index1 + 1));
                    copy1OfGrammarRule.Add(line.Substring(index1 + 1));
                    copy2OfGrammarRule.Add(line.Substring(index1 + 1));
                }

                grammarRuleList.Add(grammarRule);
                copyOfGrammarRuleList.Add(copyOfGrammarRule);
                copy1OfGrammarRuleList.Add(copyOfGrammarRule);
                copy2OfGrammarRuleList.Add(copyOfGrammarRule);
            }

            startSymbol = grammarRuleList[0][0];
            followSetOfNonterminalSymbol.Add(startSymbol, new List<String>() { "$" }); // 语句输入的结束符默认为"$"

            isPreproccessed = true;
        }


        /// <summary>
        /// 1、消除左递归
        /// 2、若存在Ai->Ajr (i>j)形式，且Aj->xxx|xxx, 则用Aj的右部替换Ai->Ajr中的Aj，得到Ai新的右部产生式
        /// </summary>
        /// <param name="grammarRuleList">待处理的文法</param>
        /// <param name="isChecking">为true时，检查是否存在左递归；为false时，执行左递归消除</param>
        public static void LeftRecursionRemoval(List<List<String>> grammarRuleList, bool isChecking)
        {
            for (int i = 0; i < grammarRuleList.Count; i++) // 对于每个Ai
            {
                for (int j = 0; j < i; j++) // 对于每个Aj(j<i)
                {
                    for (int k = 1; k < grammarRuleList[i].Count;)  // 对于Ai的每个右部产生式
                    {
                        String productionOfAi = grammarRuleList[i][k];  // Ai的一个右部产生式
                        String Aj = grammarRuleList[j][0];  // 当前的Aj（非终结符）
                        bool isFind = false;

                        if (IsNonterminalSymbol(productionOfAi[0]) && (productionOfAi[0] + "").Equals(Aj)) // 右部产生式的第一个字母为非终结符时，才可能出现左递归
                        {
                            isFind = true;

                            for (int n = 1; n < grammarRuleList[j].Count; n++) // 对于Aj的每个右部产生式
                            {
                                // 在当前Ai的右部产生式中，在位于索引k的Ajr形式的右部产生式前，插入由替换新生成的产生式
                                grammarRuleList[i].Insert(k, grammarRuleList[j][n] + productionOfAi.Substring(1));
                                k++;
                            }

                            grammarRuleList[i].RemoveAt(k); // 删除Ai的右部产生式中为Ajr形式的产生式，此时k索引的是 Ajr形式的产生式 的下一个产生式
                        }

                        if (!isFind)
                        {
                            k++;
                        }
                    }
                }

                // 判断替换后的文法规则中是否存在直接左递归,若存在,则将左递归转换成右递归
                bool hasRecursion = false;
                List<String> tempList = new List<string>();  // 存放含有左递归的某一右部产生式中的不含有左递归的右边部分,如A->Abc,则存放bc

                for (int j = 1; j < grammarRuleList[i].Count;)  // 对于Ai的每个右部产生式
                {
                    if ((grammarRuleList[i][j][0] + "").Equals(grammarRuleList[i][0])) // Ai的右部产生式中,存在Ai->Aixxx形式的产生式
                    {
                        hasRecursion = true;
                        tempList.Add(grammarRuleList[i][j].Substring(1));
                        grammarRuleList[i].RemoveAt(j);  // 删除带有左递归的原来的Aixxx形式的产生式
                    }
                    else
                    {
                        j++;
                    }
                }

                // 含有左递归,则将其转化成右递归再存入文法规则中
                if (hasRecursion)
                {
                    if (isChecking)
                    {
                        existedLeftRecursion = true;
                        return;
                    }

                    String newNonterminalSymbol = grammarRuleList[i][0] + "'"; // 新的非终结符Ai'
                    while (newNonterminalSymbolList.Contains(newNonterminalSymbol)) //该非终结符已经存在,要用新的非终结符
                    {
                        newNonterminalSymbol += "'";
                    }
                    newNonterminalSymbolList.Add(newNonterminalSymbol);

                    for (int j = 1; j < grammarRuleList[i].Count; j++) // 对于Ai的每个右部产生式(此时都不含左递归产生式)
                    {
                        grammarRuleList[i][j] = grammarRuleList[i][j] + newNonterminalSymbol;
                    }

                    for (int j = 0; j < tempList.Count; j++)
                    {
                        tempList[j] = tempList[j] + newNonterminalSymbol;
                    }

                    List<String> newGrammarRule = new List<string>(); // 新的文法规则Ai'->xxx

                    newGrammarRule.Add(newNonterminalSymbol);

                    for (int j = 0; j < tempList.Count; j++)
                    {
                        newGrammarRule.Add(tempList[j]);
                    }

                    newGrammarRule.Add("ε");
                    grammarRuleList.Insert(i + 1, newGrammarRule);  // 插入新的文法规则Ai'->xxx
                }
            }
        }


        /// <summary>
        /// 合并文法规则列表中左部相同的文法规则，以便后期的提取左公共因子
        /// </summary>
        private static void mergeGrammarRules(List<List<String>> grammarRuleList)
        {
            for (int i = 0; i < grammarRuleList.Count; i++)
            {
                for (int j = i + 1; j < grammarRuleList.Count;)
                {
                    if (grammarRuleList[i][0].Equals(grammarRuleList[j][0]))
                    {
                        for (int k = 1; k < grammarRuleList[j].Count; k++)
                        {
                            grammarRuleList[i].Insert(1, grammarRuleList[j][k]);  // 插入合并
                        }

                        grammarRuleList.RemoveAt(j);
                    }
                    else
                    {
                        j++;
                    }
                }
            }
        }


        /// <summary>
        /// 消除左公共因子（递归方式）
        /// </summary>
        /// <param name="grammarRuleList">待处理的文法</param>
        /// <param name="isChecking">为true时，检查是否存在左公共因子；为false时，执行左公共因子消除</param>
        public static void LeftFactoring(List<List<String>> grammarRuleList, bool isChecking)
        {
            bool isRecursion = false;

            // 1、先将隐式左公共因子转换成显式左公共因子，直到所有的右部产生式都是以终结符开始
            for (int i = 0; i < grammarRuleList.Count; i++) // 对于每个Ai(文法规则)
            {
                for (int j = 1; j < grammarRuleList[i].Count;)  // 对于Ai的每个右部产生式
                {
                    String productionOfAi = grammarRuleList[i][j];  // Ai的一个右部产生式
                    int indexOfSymbol = -1;  // A'或A''或A'''中最后一个'的索引的后一个位置
                    bool hasSymbol = false; // 非终结符是否带有'
                    bool isFind = false;  // 是否找到了用以替换非终结符的以终结符开始的产生式

                    if (IsNonterminalSymbol(productionOfAi[0])) // 首部为非终结符
                    {
                        String nonterminalSymbol;  // 一个右部产生式的首部非终结符

                        if (productionOfAi.Length > 1 && (productionOfAi[1] + "").Equals("'")) // 右部产生式的首部存在A'或A''或...
                        {
                            hasSymbol = true;
                            for (int k = 1; k < productionOfAi.Length; k++)
                            {
                                if (!(productionOfAi[k] + "").Equals("'"))
                                {
                                    indexOfSymbol = k;
                                    break;
                                }
                            }

                            if (indexOfSymbol == -1)
                            {
                                indexOfSymbol = productionOfAi.Length;
                            }

                            nonterminalSymbol = productionOfAi.Substring(0, indexOfSymbol);  // 以非终结符开头的产生式(带')的首部非终结符
                        }
                        else
                        {
                            nonterminalSymbol = productionOfAi.Substring(0, 1); // 以非终结符开头的产生式(不带')的首部非终结符
                        }

                        for (int k = 0; k < grammarRuleList.Count; k++)
                        {
                            if (grammarRuleList[k][0].Equals(nonterminalSymbol)) // 在文法规则的左部非终结符中找到了nonterminalSymbol
                            {
                                for (int n = 1; n < grammarRuleList[k].Count; n++)
                                {
                                    String rightProduction = grammarRuleList[k][n];

                                    if (!IsNonterminalSymbol(rightProduction[0]))  // 该右部产生式的首字母为终结符
                                    {
                                        isRecursion = true;
                                        isFind = true;
                                        grammarRuleList[i].Insert(j, rightProduction + productionOfAi.Substring(hasSymbol ? indexOfSymbol : 1));
                                        j++;
                                    }
                                }
                            }
                        }
                    }

                    if (isFind)
                    {
                        grammarRuleList[i].RemoveAt(j); // 删除首部为非终结符的Ai的右部产生式
                    }
                    else
                    {
                        j++;
                    }
                }
            }

            // 2、合并文法规则
            mergeGrammarRules(grammarRuleList);

            // 3、开始提取左公共因子
            for (int i = 0; i < grammarRuleList.Count; i++)
            {
                for (int j = 1; j < grammarRuleList[i].Count; j++)
                {
                    String productionOfAi = grammarRuleList[i][j];  // Ai的一个右部产生式
                    List<String> tempList = new List<string>(); // 存放含有左公共因子的右部产生式中的除公因子外的剩余部分
                    bool isLeftCommonFactorFind = false;
                    bool isSubString = true;
                    int commonLength = productionOfAi.Length;  // 左公共因子的长度
                    List<String> listToBeFactoring = new List<String>(); // 存放将要被提取左公共因子的产生式

                    for (int k = j + 1; k < grammarRuleList[i].Count; k++)
                    {
                        String anotherProductionOfAi = grammarRuleList[i][k];  // Ai的另一个右部产生式

                        if (anotherProductionOfAi[0] == productionOfAi[0]) // 存在左公共因子
                        {
                            for (int n = 0; n < Math.Min(anotherProductionOfAi.Length, productionOfAi.Length); n++)
                            {
                                if (anotherProductionOfAi[n] != productionOfAi[n]) // 左公共因子长度可能大于1
                                {
                                    isSubString = false;
                                    commonLength = Math.Min(commonLength, n); // 取所有左公共因子最短的部分提取
                                    break;
                                }
                            }

                            if (isSubString) // 两个产生式中其中一个是另一个的子串
                            {
                                int substringLength = Math.Min(anotherProductionOfAi.Length, productionOfAi.Length);
                                commonLength = Math.Min(commonLength, substringLength);
                            }

                            isLeftCommonFactorFind = true;
                            listToBeFactoring.Add(anotherProductionOfAi); // 标记要提取左公共因子的右部产生式
                        }
                    }


                    if (isLeftCommonFactorFind) // 存在左公共因子，进行提取
                    {
                        if(isChecking)
                        {
                            existedLeftFactor = true;
                            return;
                        }

                        for (int k = j + 1; k < grammarRuleList[i].Count;)
                        {
                            String anotherProductionOfAi = grammarRuleList[i][k];

                            if (listToBeFactoring.Contains(anotherProductionOfAi))
                            {
                                tempList.Add(anotherProductionOfAi.Substring(commonLength).Equals("") ? "ε" : anotherProductionOfAi.Substring(commonLength));
                                grammarRuleList[i].RemoveAt(k);
                            }
                            else
                            {
                                k++;
                            }
                        }

                        List<String> newGrammarRule = new List<string>(); // 新的文法规则
                        String newNonterminalSymbol = grammarRuleList[i][0] + "'"; // 新的非终结符Ai'
                        while (newNonterminalSymbolList.Contains(newNonterminalSymbol)) //该非终结符已经存在,要用新的非终结符
                        {
                            newNonterminalSymbol += "'";
                        }
                        newNonterminalSymbolList.Add(newNonterminalSymbol);

                        // 将旧规则（productionOfAi）的公因子部分进行提取
                        tempList.Add(productionOfAi.Substring(commonLength).Equals("") ? "ε" : productionOfAi.Substring(commonLength));

                        grammarRuleList[i][j] = grammarRuleList[i][j].Substring(0, commonLength) + newNonterminalSymbol;

                        newGrammarRule.Add(newNonterminalSymbol);

                        for (int n = 0; n < tempList.Count; n++)
                        {
                            newGrammarRule.Add(tempList[n]);
                        }

                        grammarRuleList.Insert(i + 1, newGrammarRule);  // 插入当前文法规则的下一位
                    }
                }
            }

            if (isRecursion)  // 递归执行
            {
                LeftFactoring(grammarRuleList, isChecking);
            }
            else
            {
                return;
            }
        }



        /// <summary>
        /// 检查文法规则
        /// </summary>
        /// <param name="grammarRichTextBox"></param>
        public static void CheckGrammar(RichTextBox grammarRichTextBox)
        {
            Reset();

            // 先进行预处理
            GrammarInputPreproccess(grammarRichTextBox);

            // 预处理失败
            if(!isPreproccessed)
            {
                MessageBox.Show("请输入正确的文法规则!", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }

            // 左递归检查
            LeftRecursionRemoval(copy1OfGrammarRuleList, true);

            // 左公共因子检查
            LeftFactoring(copy2OfGrammarRuleList, true);

            if(existedLeftRecursion && existedLeftFactor)
            {
                MessageBox.Show("预处理和检查完毕，当前文法规则存在左递归和左公共因子，需要先消除！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            else if(existedLeftRecursion)
            {
                MessageBox.Show("预处理和检查完毕，当前文法规则存在左递归，需要先消除！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            else if(existedLeftFactor)
            {
                MessageBox.Show("预处理和检查完毕，当前文法规则存在左公共因子，需要先消除！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("预处理和检查完毕，当前文法规则不存在左递归和左公共因子！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }

            isChecked = true;
        }


        /// <summary>
        /// 消除左递归，供GUI界面调用的接口
        /// </summary>
        public static void LeftRecursionRemoval(RichTextBox textBox)
        {
            if(!isChecked)
            {
                MessageBox.Show("请先执行文法的预处理和检查操作！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }

            if (!existedLeftRecursion)
            {
                MessageBox.Show("当前文法规则不存在左递归，不必执行左递归消除操作！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }

            LeftRecursionRemoval(grammarRuleList, false);
            OutputToRichTextBox(grammarRuleList, textBox);
            existedLeftRecursion = false;
        }

        /// <summary>
        /// 消除左公共因子，供GUI界面调用的接口
        /// </summary>
        public static void LeftFactoring(RichTextBox textBox)
        {
            if (!isChecked)
            {
                MessageBox.Show("请先执行文法的预处理和检查操作！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }

            if (!existedLeftFactor)
            {
                MessageBox.Show("当前文法规则不存在左公共因子，不必执行左公共因子消除操作！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }

            LeftFactoring(grammarRuleList, false);
            OutputToRichTextBox(grammarRuleList, textBox);
            existedLeftFactor = false;
        }


        /// <summary>
        /// 将文法规则输出到文本框
        /// </summary>
        /// <param name="textBox"></param>
        public static void OutputToRichTextBox(List<List<String>> grammarRuleList, RichTextBox textBox)
        {
            textBox.Text = "";

            for (int i = 0; i < grammarRuleList.Count; i++)
            {
                textBox.Text += (grammarRuleList[i][0] + "->");

                for (int j = 1; j < grammarRuleList[i].Count; j++)
                {
                    textBox.Text += grammarRuleList[i][j];
                    if (j < grammarRuleList[i].Count - 1)
                    {
                        textBox.Text += "|";
                    }
                }

                textBox.Text += "\r\n";
            }
        }


        /// <summary>
        /// 1、求出能推出ε的非终结符（非递归求法），这里权当一次锻炼，该函数不运用于LL(1)分析
        /// 2、递归求法：使用递归方式求所有非终结符的FIRST集，若某一个非终结符A的FIRST集含有ε，即FIRST(A)={ε,...},则A能推出ε！
        /// 3、"2"中的结论出自《编译原理及实践》P126 中的一个定理：当且仅当FIRST(A)包含ε时，非终结符A为可空的。
        /// </summary>
        public static void getNonterminalSymbolsOfEmptyStr(RichTextBox textBox)
        {
            int countDeleted = 0;

            for (int i = 0; i < copyOfGrammarRuleList.Count;)
            {
                for (int j = 1; j < copyOfGrammarRuleList[i].Count;)
                {
                    String productionOfAi = copyOfGrammarRuleList[i][j];
                    bool flag = false;

                    if (productionOfAi.Equals("ε"))
                    {
                        nonterminalSymbolRelEmptyStr.Add(copyOfGrammarRuleList[i][0], true);

                        while (copyOfGrammarRuleList[i].Count > 1)  // 删除该非终结符的所有产生式,最后只剩左部的非终结符
                        {
                            copyOfGrammarRuleList[i].RemoveAt(1);
                        }

                        break;
                    }

                    for (int k = 0; k < productionOfAi.Length; k++)
                    {
                        if (!IsNonterminalSymbol(productionOfAi[k]) && productionOfAi[k] != '\'')  // 删除所有右部含有终结符的产生式
                        {
                            flag = true;
                            copyOfGrammarRuleList[i].RemoveAt(j);
                            break;
                        }
                    }

                    if (!flag)
                    {
                        j++;
                    }
                }

                if (copyOfGrammarRuleList[i].Count == 1 && !nonterminalSymbolRelEmptyStr.ContainsKey(copyOfGrammarRuleList[i][0]))
                {
                    nonterminalSymbolRelEmptyStr.Add(copyOfGrammarRuleList[i][0], false);
                    copyOfGrammarRuleList.RemoveAt(i); // 从文法规则中删除该非终结符
                    countDeleted++;
                }
                else if (nonterminalSymbolRelEmptyStr.ContainsKey(copyOfGrammarRuleList[i][0]) && nonterminalSymbolRelEmptyStr[copyOfGrammarRuleList[i][0]])
                {
                    copyOfGrammarRuleList.RemoveAt(i); // 从文法规则中删除该非终结符
                    countDeleted++;
                }
                else
                {
                    i++;
                }
            }

            while (countDeleted < grammarRuleList.Count)
            {
                for (int i = 0; i < copyOfGrammarRuleList.Count;)
                {
                    for (int j = 1; j < copyOfGrammarRuleList[i].Count;)
                    {
                        bool flag = false;

                        for (int k = 0; k < copyOfGrammarRuleList[i][j].Length;)
                        {
                            int startIndex = k;

                            String nonterminalSymbol = copyOfGrammarRuleList[i][j][k] + "";
                            while ((k + 1 < copyOfGrammarRuleList[i][j].Length) && copyOfGrammarRuleList[i][j][k + 1] == '\'')
                            {
                                nonterminalSymbol += "'";
                                k++;
                            }

                            if (nonterminalSymbolRelEmptyStr.ContainsKey(nonterminalSymbol) && nonterminalSymbolRelEmptyStr[nonterminalSymbol])
                            {
                                copyOfGrammarRuleList[i][j] = copyOfGrammarRuleList[i][j].Remove(startIndex, k - startIndex + 1); // 在产生式中删除该非终结符
                                k = startIndex;
                            }
                            else if (nonterminalSymbolRelEmptyStr.ContainsKey(nonterminalSymbol) && !nonterminalSymbolRelEmptyStr[nonterminalSymbol])
                            {
                                copyOfGrammarRuleList[i].RemoveAt(j); // 删除该产生式
                                flag = true;
                                break;
                            }
                            else
                            {
                                k++;
                            }
                        }

                        if (!flag && copyOfGrammarRuleList[i][j].Equals("")) // 最终右部产生式为空，说明左部的非终结符可以推出ε
                        {
                            nonterminalSymbolRelEmptyStr.Add(copyOfGrammarRuleList[i][0], true);

                            while (copyOfGrammarRuleList[i].Count > 1)  // 删除该非终结符的所有产生式,最后只剩左部的非终结符
                            {
                                copyOfGrammarRuleList[i].RemoveAt(1);
                            }

                            break;
                        }
                        else
                        {
                            j++;
                        }
                    }

                    if (copyOfGrammarRuleList[i].Count == 1 && !nonterminalSymbolRelEmptyStr.ContainsKey(copyOfGrammarRuleList[i][0]))
                    {
                        copyOfGrammarRuleList.RemoveAt(i); // 从文法规则中删除该非终结符
                        nonterminalSymbolRelEmptyStr.Add(copyOfGrammarRuleList[i][0], false);
                        countDeleted++;
                    }
                    else if (nonterminalSymbolRelEmptyStr.ContainsKey(copyOfGrammarRuleList[i][0]) && nonterminalSymbolRelEmptyStr[copyOfGrammarRuleList[i][0]])
                    {
                        copyOfGrammarRuleList.RemoveAt(i);  // 删除该非终结符的文法
                        countDeleted++;
                    }
                    else
                    {
                        i++;
                    }
                }
            }

            textBox.Text = "";

            foreach (String key in nonterminalSymbolRelEmptyStr.Keys)
            {
                if (nonterminalSymbolRelEmptyStr[key] == true)
                {
                    textBox.Text += key + " ";
                }
            }
        }


        /// <summary>
        /// 计算文法规则中非终结符/终结符的FIRST集合（递归方式）
        /// </summary>
        public static void GetFirstSetOfSymbol(String symbol)
        {
            List<String> firstSet = firstSetOfSymbol.ContainsKey(symbol) ? firstSetOfSymbol[symbol] : new List<string>();

            if (!IsNonterminalSymbol(symbol[0])) // 为终结符
            {
                if (!firstSet.Contains(symbol))
                {
                    firstSet.Add(symbol);
                }

                if (firstSetOfSymbol.ContainsKey(symbol))
                {
                    firstSetOfSymbol[symbol] = firstSet;
                }
                else
                {
                    firstSetOfSymbol.Add(symbol, firstSet);
                }
            }


            for (int i = 0; i < grammarRuleList.Count; i++) // 为非终结符
            {
                if (grammarRuleList[i][0].Equals(symbol))
                {
                    for (int j = 1; j < grammarRuleList[i].Count; j++)
                    {
                        String production = grammarRuleList[i][j];

                        if (production.Equals("ε"))
                        {
                            firstSet.Add("ε");
                            if (!firstSetOfSymbol.ContainsKey("ε"))
                            {
                                firstSetOfSymbol.Add("ε", new List<string>() { "ε" });
                            }
                        }
                        else
                        {
                            int k = 0;
                            while (k < production.Length) // 从左往右扫描右部产生式
                            {
                                String aSymbol = production[k] + "";

                                if (IsNonterminalSymbol(aSymbol[0]))  // 是否为A'、A''形式的非终结符
                                {
                                    while (k + 1 < production.Length && production[k + 1] == '\'')
                                    {
                                        aSymbol += "'";
                                        k++;
                                    }
                                }

                                GetFirstSetOfSymbol(aSymbol); // 先预先求好aSymbol的FIRST集
                                List<String> set = firstSetOfSymbol[aSymbol];

                                for (int n = 0; n < set.Count; n++) // 加入aSymbol的FIRST集
                                {
                                    if (!firstSet.Contains(set[n]) && !set[n].Equals("ε"))
                                    {
                                        firstSet.Add(set[n]);
                                    }
                                }

                                if (set.Contains("ε")) // 包含空串，则继续处理下一个符号
                                {
                                    k++;
                                }
                                else // 不包含空串，则当前产生式处理完毕，执行退出，处理下一个产生式
                                {
                                    break;
                                }

                                if (k == production.Length) // 到了产生式末尾，也就是说产生式所有符号的FIRST集都包含空串
                                {
                                    if (!firstSet.Contains("ε"))
                                    {
                                        firstSet.Add("ε");
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (firstSetOfSymbol.ContainsKey(symbol))
            {
                firstSetOfSymbol[symbol] = firstSet;
            }
            else
            {
                firstSetOfSymbol.Add(symbol, firstSet);
            }
        }


        /// <summary>
        /// 计算文法规则右部某一产生式的FIRST集合
        /// </summary>
        public static void GetFirstSetOfProduction(String production)
        {
            List<String> firstSet = firstSetOfProduction.ContainsKey(production) ? firstSetOfProduction[production] : new List<string>();

            int i = 0;
            while (i < production.Length) // 从左往右扫描右部产生式
            {
                String aSymbol = production[i] + "";

                if (IsNonterminalSymbol(aSymbol[0]))  // 是否为A'、A''形式的非终结符
                {
                    while (i + 1 < production.Length && production[i + 1] == '\'')
                    {
                        aSymbol += "'";
                        i++;
                    }
                }

                if (!firstSetOfSymbol.ContainsKey(aSymbol))
                {
                    GetFirstSetOfSymbol(aSymbol);
                }
                List<String> set = firstSetOfSymbol[aSymbol];

                for (int n = 0; n < set.Count; n++) // 加入aSymbol的FIRST集
                {
                    if (!firstSet.Contains(set[n]) && !set[n].Equals("ε"))
                    {
                        firstSet.Add(set[n]);
                    }
                }

                if (set.Contains("ε")) // 包含空串，则继续处理下一个符号
                {
                    i++;
                }
                else // 不包含空串，则当前产生式处理完毕，执行退出
                {
                    break;
                }

                if (i == production.Length) // 到了产生式末尾，也就是说产生式所有符号的FIRST集都包含空串
                {
                    if (!firstSet.Contains("ε"))
                    {
                        firstSet.Add("ε");
                    }
                }
            }

            if (firstSetOfProduction.ContainsKey(production))
            {
                firstSetOfProduction[production] = firstSet;
            }
            else
            {
                firstSetOfProduction.Add(production, firstSet);
            }
        }


        /// <summary>
        /// 计算文法规则左部非终结符的FOLLOW集合(这里求FOLLOW(A))
        /// </summary>
        /// <param name="A">非终结符A</param>
        public static void GetFollowSetOfNonterminalSymbol(String A)
        {
            List<String> followSetOfA = followSetOfNonterminalSymbol.ContainsKey(A) ? followSetOfNonterminalSymbol[A] : new List<string>();

            for (int i = 0; i < grammarRuleList.Count; i++) // 查找所有文法规则的产生式，确定A后面的终结符
            {
                for (int j = 1; j < grammarRuleList[i].Count; j++)
                {
                    String production = grammarRuleList[i][j];

                    int k = 0;

                    if (A.Length > 1) // 左部非终结符为A'、A''形式
                    {
                        int len = A.Length;

                        while (k < production.Length)
                        {
                            if (production[k] == A[0] && k + len < production.Length && production.Substring(k, len).Equals(A)
                                &&!IsNonterminalSymbol(production[k + len]))
                            {
                                followSetOfA.Add(production[k + len] + "");
                                k += len;
                            }
                            else
                            {
                                k++;
                            }
                        }
                    }
                    else  // 左部非终结符为 A 形式
                    {
                        while (k < production.Length)
                        {
                            if (production[k] == A[0] && k + 1 < production.Length && !IsNonterminalSymbol(production[k + 1]))
                            {
                                followSetOfA.Add(production[k + 1] + "");
                            }
                            k++;
                        }
                    }
                }
            }

            if (followSetOfNonterminalSymbol.ContainsKey(A))
            {
                followSetOfNonterminalSymbol[A] = followSetOfA;
            }
            else
            {
                followSetOfNonterminalSymbol.Add(A, followSetOfA);
            }

            for (int i = 0; i < grammarRuleList.Count; i++)  // 处理A的每条产生式
            {
                if (grammarRuleList[i][0].Equals(A))
                {
                    for (int j = 1; j < grammarRuleList[i].Count; j++)
                    {
                        String production = grammarRuleList[i][j];

                        int k = 0;
                        while (k < production.Length) // A->αBβ  
                        {
                            String B;

                            if (IsNonterminalSymbol(production[k]))
                            {
                                B = production[k] + ""; // B

                                while (k + 1 < production.Length && production[k + 1] == '\'')
                                {
                                    B += "'";
                                    k++;
                                }

                                List<String> followSetOfB = followSetOfNonterminalSymbol.ContainsKey(B) ? followSetOfNonterminalSymbol[B] : new List<String>();

                                if (k == production.Length - 1 && !B.Equals(A)) // B为产生式中最后一个非终结符，即β不存在，即A->αB，则将FOLLOW(A)加入FOLLOW(B)
                                {
                                    foreach (String symbol in followSetOfA)
                                    {
                                        if (!followSetOfB.Contains(symbol))
                                        {
                                            followSetOfB.Add(symbol);
                                        }
                                    }

                                    if (followSetOfNonterminalSymbol.ContainsKey(B))
                                    {
                                        followSetOfNonterminalSymbol[B] = followSetOfB;
                                    }
                                    else
                                    {
                                        followSetOfNonterminalSymbol.Add(B, followSetOfB);
                                    }
                                }
                                else  // 为 A->αBβ 形式
                                {
                                    String rightOfProduction = production.Substring(k + 1);

                                    GetFirstSetOfProduction(rightOfProduction);
                                    List<String> firstSet = firstSetOfProduction[rightOfProduction];

                                    foreach (String symbol in firstSet)
                                    {
                                        if (!followSetOfB.Contains(symbol) && !symbol.Equals("ε"))
                                        {
                                            followSetOfB.Add(symbol);
                                        }
                                    }

                                    if (firstSet.Contains("ε") && !B.Equals(A))  // 为 A->αBβ 形式,其中FIRST(β)包含空串，则将FOLLOW(A)加入FOLLOW(B)
                                    {
                                        foreach (String symbol in followSetOfA)
                                        {
                                            if (!followSetOfB.Contains(symbol))
                                            {
                                                followSetOfB.Add(symbol);
                                            }
                                        }

                                        if (followSetOfNonterminalSymbol.ContainsKey(B))
                                        {
                                            followSetOfNonterminalSymbol[B] = followSetOfB;
                                        }
                                        else
                                        {
                                            followSetOfNonterminalSymbol.Add(B, followSetOfB);
                                        }
                                    }
                                }
                            }
                            k++;
                        }
                    }
                }
            }
        }



        /// <summary>
        /// 准备好LL(1)分析时要使用的FIRST、FOLLOW集
        /// </summary>
        public static void GetFirstAndFollow()
        {
            for (int i = 0; i < grammarRuleList.Count; i++)
            {
                GetFirstSetOfSymbol(grammarRuleList[i][0]);
            }

            for (int i = 0; i < grammarRuleList.Count; i++)
            {
                for (int j = 1; j < grammarRuleList[i].Count; j++)
                {
                    String production = grammarRuleList[i][j];
                    GetFirstSetOfProduction(production);
                }
            }

            for (int i = 0; i < grammarRuleList.Count; i++)
            {
                GetFollowSetOfNonterminalSymbol(grammarRuleList[i][0]);
            }
        }

        /// <summary>
        /// 获取文法中所有的非终结符和终结符
        /// </summary>
        public static void GetNSAndTS()
        {
            for (int i = 0; i < grammarRuleList.Count; i++)
            {
                if (!nonterminalSymbolsOfGrammar.Contains(grammarRuleList[i][0]))
                {
                    nonterminalSymbolsOfGrammar.Add(grammarRuleList[i][0]);
                }
            }

            for (int i = 0; i < grammarRuleList.Count; i++)
            {
                for (int j = 1; j < grammarRuleList[i].Count; j++)
                {
                    String production = grammarRuleList[i][j];

                    for (int k = 0; k < production.Length; k++)
                    {
                        if (!IsNonterminalSymbol(production[k]) && production[k] != '\'')
                        {
                            if (!terminalSymbolsOfGrammar.Contains(production[k] + ""))
                            {
                                terminalSymbolsOfGrammar.Add(production[k] + "");
                            }
                        }
                    }

                }
            }
        }


        /// <summary>
        /// 1、判断当前文法是否为LL(1)文法
        /// 2、判断思想：根据文法是否有二义性进行判断。
        /// 3、判断方法：若当前文法规则中所有的"FIRST集中含有ε的非终结符A"的FOLLOW集与其FIRST集交集为空，
        /// 则文法不存在二义性，文法为LL(1)文法。
        /// </summary>
        public static bool IsLL1Grammar()
        {
            for(int i = 0; i < nonterminalSymbolsOfGrammar.Count; i++)
            {
                List<String> firstSet = firstSetOfSymbol[nonterminalSymbolsOfGrammar[i]];

                if(firstSet.Contains("ε"))
                {
                    List<String> followSet = followSetOfNonterminalSymbol[nonterminalSymbolsOfGrammar[i]];

                    if(firstSet.Intersect(followSet).ToList().Count > 0) // 有交集
                    {
                        return false;
                    }
                }
            }
            return true;
        }



        /// <summary>
        /// 在LL(1)分析表中插入产生式，其中行标为NS，列标为TS
        /// </summary>
        /// <param name="NS">非终结符</param>
        /// <param name="TS">终结符</param>
        /// <param name="production"></param>
        public static void insertIntoTable(String NS, String TS, String production)
        {
            if (TS.Equals("ε"))
            {
                TS = "$";
            }

            for (int i = 0; i < nonterminalSymbolsOfGrammar.Count + 1; i++)
            {
                if (table[i, 0].Equals(NS))
                {
                    for (int j = 0; j < terminalSymbolsOfGrammar.Count + 1; j++)
                    {
                        if (table[0, j].Equals(TS))
                        {
                            table[i, j] = "->" + production;
                            return;
                        }
                    }
                }
            }
        }


        /// <summary>
        /// 生成LL(1)分析表
        /// </summary>
        /// <param name="dataGridView"></param>
        public static void GenerateLL1ParsingTable(DataGridView dataGridView)
        {
            if (!isChecked)
            {
                MessageBox.Show("请先执行文法的预处理和检查操作！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }

            if (existedLeftRecursion && existedLeftFactor)
            {
                MessageBox.Show("当前文法规则存在左递归和左公共因子，需要先消除！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }
            else if (existedLeftRecursion)
            {
                MessageBox.Show("当前文法规则存在左递归，需要先消除！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }
            else if (existedLeftFactor)
            {
                MessageBox.Show("当前文法规则存在左公共因子，需要先消除！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }

            firstSetOfSymbol = new Dictionary<string, List<string>>();
            firstSetOfProduction = new Dictionary<string, List<string>>();
            followSetOfNonterminalSymbol = new Dictionary<string, List<string>>();

            GetFirstAndFollow();
            GetNSAndTS();

            bool isLL1Grammar = IsLL1Grammar();

            if(!isLL1Grammar)
            {
                MessageBox.Show("当前文法不是LL(1)文法！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }
            else
            {
                MessageBox.Show("当前文法是LL(1)文法！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }

            table = new string[nonterminalSymbolsOfGrammar.Count + 1, terminalSymbolsOfGrammar.Count + 1];
            table[0, 0] = "非终结符/终结符";

            for (int i = 0; i < terminalSymbolsOfGrammar.Count; i++)
            {
                table[0, i + 1] = terminalSymbolsOfGrammar[i].Equals("ε") ? "$" : terminalSymbolsOfGrammar[i];
            }

            for (int i = 0; i < nonterminalSymbolsOfGrammar.Count; i++)
            {
                table[i + 1, 0] = nonterminalSymbolsOfGrammar[i];
            }

            for (int i = 0; i < nonterminalSymbolsOfGrammar.Count; i++)
            {
                for (int j = 0; j < terminalSymbolsOfGrammar.Count; j++)
                {
                    table[i + 1, j + 1] = "error";
                }
            }

            // 构造LL(1)分析表的内存数据结构（填充二维数组）
            for (int i = 0; i < grammarRuleList.Count; i++)
            {
                for (int j = 1; j < grammarRuleList[i].Count; j++)
                {
                    String production = grammarRuleList[i][j];
                    List<String> firstSet = firstSetOfProduction[production];

                    foreach (String symbol in firstSet) // firstSet可能含ε
                    {
                        insertIntoTable(grammarRuleList[i][0], symbol, production);
                    }

                    if (firstSet.Contains("ε"))
                    {
                        List<String> followSet = followSetOfNonterminalSymbol[grammarRuleList[i][0]];
                        foreach (String symbol in followSet) // followSet可能包含$
                        {
                            insertIntoTable(grammarRuleList[i][0], symbol, production);
                        }
                    }
                }
            }

            // LL(1)分析表可视化
            dataGridView.Rows.Clear();
            dataGridView.ColumnCount = terminalSymbolsOfGrammar.Count + 1;

            for (int i = 0; i < nonterminalSymbolsOfGrammar.Count + 1; i++)
            {
                int rowIndex = dataGridView.Rows.Add();

                for (int j = 0; j < terminalSymbolsOfGrammar.Count + 1; j++)
                {
                    dataGridView.Rows[rowIndex].Cells[j].Value = table[i, j];
                }
            }

            isTableGenerated = true;
        }


        /// <summary>
        /// 构造分析语句过程中的分析表的一行
        /// </summary>
        /// <param name="parsingTable"></param>
        /// <param name="parsingStack"></param>
        /// <param name="input"></param>
        /// <param name="action"></param>
        public static void CreateARow(List<List<String>> parsingTable, Stack<String> parsingStack, String input, String action)
        {
            List<String> row = new List<string>();
            String[] contentOfStack = parsingStack.ToArray();
            Array.Reverse(contentOfStack);

            String content = "";
            foreach (String s in contentOfStack)
            {
                content += s;
            }

            row.Add(content);  // 分析栈
            row.Add(input);  // 输入
            row.Add(action); // 动作
            parsingTable.Add(row);
        }

    
        /// <summary>
        /// 在LL(1)分析表中查找产生式，其中行标为NS，列标为TS
        /// </summary>
        /// <param name="NS"></param>
        /// <param name="TS"></param>
        /// <returns>产生式</returns>
        public static String FindInTable(String NS, String TS)
        {
            for (int i = 0; i < nonterminalSymbolsOfGrammar.Count + 1; i++)
            {
                if (table[i, 0].Equals(NS))
                {
                    for (int j = 0; j < terminalSymbolsOfGrammar.Count + 1; j++)
                    {
                        if (table[0, j].Equals(TS))
                        {
                            return table[i, j];
                        }
                    }
                }
            }
            return "";
        }


        /// <summary>
        /// 显示LL(1)分析语句的过程
        /// </summary>
        /// <param name="sentence">待分析语句</param>
        /// <param name="dataGridView">表</param>
        public static void DisplayLL1Parsing(String sentence, DataGridView dataGridView)
        {
            List<List<String>> parsingTable = new List<List<string>>();

            Stack<String> parsingStack = new Stack<string>();  // 分析栈
            sentence += "$";
            int curIndexOfSentence = 0; // 待分析语句的当前分析位置
            String action; // 分析过程中的动作

            parsingStack.Push("$");
            parsingStack.Push(startSymbol);

            String topOfParsingStack = parsingStack.Peek();

            // 使用$标记分析栈的底部和待分析语句的结尾
            while (!topOfParsingStack.Equals("$"))
            {
                String curInput = sentence[curIndexOfSentence] + "";
                if (topOfParsingStack.Equals(curInput))
                {
                    action = "匹配" + curInput;

                    CreateARow(parsingTable, parsingStack, sentence.Substring(curIndexOfSentence), action);

                    parsingStack.Pop();
                    curIndexOfSentence++;
                }
                else if (IsNonterminalSymbol(topOfParsingStack[0]) && !FindInTable(topOfParsingStack, curInput).Equals("error"))
                {
                    String content = FindInTable(topOfParsingStack, curInput);

                    action = topOfParsingStack + content;

                    CreateARow(parsingTable, parsingStack, sentence.Substring(curIndexOfSentence), action);

                    int k = content.IndexOf(">");
                    String production = content.Substring(k + 1);
                    
                    if(production.Equals("ε"))
                    {
                        parsingStack.Pop();
                    }
                    else
                    {
                        List<String> symbolsOfProduction = new List<string>();

                        int j = 0;
                        while (j < production.Length)
                        {
                            if (IsNonterminalSymbol(production[j]))
                            {
                                String symbol = production[j] + "";
                                while (j + 1 < production.Length && production[j + 1] == '\'')
                                {
                                    symbol += "'";
                                    j++;
                                }

                                symbolsOfProduction.Add(symbol);
                            }
                            else
                            {
                                symbolsOfProduction.Add(production[j] + "");
                            }

                            j++;
                        }

                        parsingStack.Pop();
                        for (int i = symbolsOfProduction.Count - 1; i >= 0; i--)
                        {
                            parsingStack.Push(symbolsOfProduction[i]);
                        }
                    }
                }
                else
                {
                    //MessageBox.Show("输入语句不符合当前文法！", "错误", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    //return;
                    break;
                }

                topOfParsingStack = parsingStack.Peek();
            }

            CreateARow(parsingTable, parsingStack, sentence.Substring(curIndexOfSentence), "接受");


            // 分析过程可视化
            dataGridView.Rows.Clear();
            dataGridView.ColumnCount = 3;

            int index = dataGridView.Rows.Add();
            dataGridView.Rows[index].Cells[0].Value = "分析栈";
            dataGridView.Rows[index].Cells[1].Value = "输入";
            dataGridView.Rows[index].Cells[2].Value = "动作";

            for (int i = 0; i < parsingTable.Count; i++)
            {
                int rowIndex = dataGridView.Rows.Add();
                for(int j = 0; j < parsingTable[i].Count; j++)
                {
                    dataGridView.Rows[rowIndex].Cells[j].Value = parsingTable[i][j];
                }
            }
        }


        /// <summary>
        /// 是否为非终结符（大写字母）
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static Boolean IsNonterminalSymbol(char c)
        {
            return c >= 'A' && c <= 'Z';
        }
    }
}
