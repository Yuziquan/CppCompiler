using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace CppCompiler.Lexical_Analysis
{
    /// <summary>
    /// 整个NFA
    /// </summary>
    public class NFA
    {
        /// <summary>
        /// 字母表
        /// </summary>
        private List<Char> alphabet;
        public List<Char> Alphabet
        {
            get { return alphabet; }
            set { alphabet = value; }
        }


        /// <summary>
        /// NFA中所有的状态节点
        /// </summary>
        private List<NFAStateNode> allStateNodes;
        public List<NFAStateNode> AllStateNodes
        {
            get { return allStateNodes; }
            set { allStateNodes = value; }
        }

        /// <summary>
        /// 开始状态节点
        /// </summary>
        private NFAStateNode startStateNode;
        public NFAStateNode StartStateNode
        {
            get { return startStateNode; }
            set { startStateNode = value; }
        }
        

        /// <summary>
        /// 结束状态节点
        /// </summary>
        private List<NFAStateNode> endStateNodes;
        public List<NFAStateNode> EndStateNodes
        {
            get { return endStateNodes; }
            set { endStateNodes = value; }
        }

        /// <summary>
        /// 空字符
        /// </summary>
        public static readonly char NULL_CHAR = '~';

        /// <summary>
        /// 内部类，一个开始/结束状态节点对
        /// </summary>
        private class StartEndPair
        {
            private NFAStateNode startStateNode;
            public NFAStateNode StartStateNode
            {
                get { return startStateNode; }
                set { startStateNode = value; }
            }

            private NFAStateNode endStateNode;
            public NFAStateNode EndStateNode
            {
                get { return endStateNode; }
                set { endStateNode = value; }
            }

            public StartEndPair(NFAStateNode startStateNode, NFAStateNode endStateNode)
            {
                this.startStateNode = startStateNode;
                this.endStateNode = endStateNode;
            }
        }

       
        public NFA(RegularExpression regex)
        {
            alphabet = new List<Char>();
            allStateNodes = new List<NFAStateNode>();
            endStateNodes = new List<NFAStateNode>();
            CreateNFA(regex);
        }



        /// <summary>
        /// 用正则表达式构造NFA，注意压栈的时候压入的是一个开始/结束状态节点对
        /// </summary>
        /// <param name="expression">正则表达式</param>
        private void CreateNFA(RegularExpression regex)
        {
            Stack<StartEndPair> operandStack = new Stack<StartEndPair>();
            Stack<Char> operatorStack = new Stack<Char>();
            operatorStack.Push(RegularExpression.END_OF_REGEX);
            char[] regexSplited = regex.Regex.ToCharArray();

            int curIndex = 0;

            while (curIndex < regexSplited.Length 
                &&((regexSplited[curIndex] != RegularExpression.END_OF_REGEX)
                || (operatorStack.Peek() != RegularExpression.END_OF_REGEX)))
            {
                if(RegularExpression.IsOperand(regexSplited[curIndex]))
                {
                    operandStack.Push(SingleCharCreate(regexSplited[curIndex]));
                    AddToAlphabet(regexSplited[curIndex]);
                    curIndex++;
                }

                switch(RegularExpression.GetPriority(operatorStack.Peek(), regexSplited[curIndex]))
                {
                    case '<':
                        operatorStack.Push(regexSplited[curIndex]);
                        curIndex++;
                        break;

                    case '=':
                        operatorStack.Pop();
                        curIndex++;
                        break;

                    case '>':

                        switch (operatorStack.Peek())
                        {
                            case '*':
                                StartEndPair target = operandStack.Pop();
                                operatorStack.Pop();
                                operandStack.Push(ClosureCreate(target));
                                break;

                            case '|':
                                StartEndPair b1 = operandStack.Pop();
                                StartEndPair a1 = operandStack.Pop();
                                operatorStack.Pop();
                                operandStack.Push(OrCreate(a1, b1));
                                break;

                            case '.':
                                StartEndPair b2 = operandStack.Pop();
                                StartEndPair a2 = operandStack.Pop();
                                operatorStack.Pop();
                                operandStack.Push(AndCreate(a2, b2));
                                break;
                        }

                        break;
                }
            }

            startStateNode = operandStack.Peek().StartStateNode;
            AddToEndStateNodes(operandStack.Peek().EndStateNode);
        }


        /// <summary>
        /// 单个字符创建NFA
        /// </summary>
        /// <returns></returns>
        private StartEndPair SingleCharCreate(char c)
        {
            NFAStateNode startStateNode = new NFAStateNode();
            NFAStateNode endStateNode = new NFAStateNode();

            startStateNode.Connect(endStateNode, c);

            allStateNodes.Add(startStateNode);
            allStateNodes.Add(endStateNode);

            return new StartEndPair(startStateNode, endStateNode);
        }


        /// <summary>
        /// 闭包创建NFA
        /// </summary>
        /// <param name="startEndPair"></param>
        /// <returns></returns>
        private StartEndPair ClosureCreate(StartEndPair startEndPair)
        {
            NFAStateNode newStartStateNode = new NFAStateNode();
            NFAStateNode newEndStateNode = new NFAStateNode();

            allStateNodes.Add(newStartStateNode);
            allStateNodes.Add(newEndStateNode);

            newStartStateNode.Connect(startEndPair.StartStateNode, NULL_CHAR);
            newStartStateNode.Connect(newEndStateNode, NULL_CHAR);
            startEndPair.EndStateNode.Connect(startEndPair.StartStateNode, NULL_CHAR);
            startEndPair.EndStateNode.Connect(newEndStateNode, NULL_CHAR);

            return new StartEndPair(newStartStateNode, newEndStateNode);
        }



        /// <summary>
        /// 或操作，创建NFA
        /// </summary>
        /// <returns></returns>
        private StartEndPair OrCreate(StartEndPair a, StartEndPair b)
        {
            NFAStateNode newStartStateNode = new NFAStateNode();
            NFAStateNode newEndStateNode = new NFAStateNode();

            allStateNodes.Add(newStartStateNode);
            allStateNodes.Add(newEndStateNode);

            newStartStateNode.Connect(a.StartStateNode, NULL_CHAR);
            newStartStateNode.Connect(b.StartStateNode, NULL_CHAR);
            a.EndStateNode.Connect(newEndStateNode, NULL_CHAR);
            b.EndStateNode.Connect(newEndStateNode, NULL_CHAR);

            return new StartEndPair(newStartStateNode, newEndStateNode);
        }


        /// <summary>
        /// 且操作，创建NFA
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private StartEndPair AndCreate(StartEndPair a, StartEndPair b)
        {
            a.EndStateNode.Connect(b.StartStateNode, NULL_CHAR);
            return new StartEndPair(a.StartStateNode, b.EndStateNode);
        }


        private void AddToEndStateNodes(NFAStateNode node)
        {
            if(!endStateNodes.Contains(node))
            {
                endStateNodes.Add(node);
            }
        }

        private void AddToAlphabet(char c)
        {
            if(!alphabet.Contains(c))
            {
                alphabet.Add(c);
            }
        }
    }
}
