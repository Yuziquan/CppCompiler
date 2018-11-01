using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CppCompiler.Lexical_Analysis
{
    /// <summary>
    /// 正则表达式类
    /// </summary>
    public class RegularExpression
    {
        /// <summary>
        /// 正则表达式结束标志符
        /// </summary>
        public static readonly char END_OF_REGEX = '#';

        private String regex;
        public String Regex
        {
            get { return regex; }
            set { regex = value; }
        }


        /// <summary>
        /// 对正则表达式进行预处理
        /// </summary>
        /// <param name="rawRegex">未经处理的正则表达式</param>
        public RegularExpression(String rawRegex)
        {
            this.regex = PreProcess(rawRegex);
        }

        /// <summary>
        /// 对正则表达式进行预处理（进行语法验证并加点）
        /// </summary>
        /// <param name="rawRegex">未经处理的正则表达式</param>
        /// <returns>处理后得到的正则表达式</returns>
        private String PreProcess(String rawRegex)
        {
            // 先对正则表达式进行必要的验证
            Validate(rawRegex);

            // 然后对正则表达式进行必要的加点操作
            return AddDot(rawRegex);
        }



        /// <summary>
        /// 验证正则表达式是否语法正确
        /// </summary>
        /// <param name="rawRegex">未经处理的正则表达式</param>
        private void Validate(String rawRegex)
        {
            if (rawRegex.StartsWith("#"))
            {
                throw ExceptionHandler.IllegalStart();
            }

            char[] rawRegexSplited = rawRegex.ToCharArray();

            // 正则表达式中的操作数的个数
            int operandCounter = 0;

            for(int i = 0; i < rawRegexSplited.Length; i++)
            {
                if(IsOperand(rawRegexSplited[i]))
                {
                    operandCounter++;
                }

                if(!IsOperand(rawRegexSplited[i]) && !IsOperator(rawRegexSplited[i]))
                {
                    throw ExceptionHandler.UnsupportedSymbol(rawRegexSplited[i]);
                }

                if(rawRegexSplited[i] == '.' && i + 1 < rawRegexSplited.Length && rawRegexSplited[i + 1] == '.')
                {
                    throw ExceptionHandler.IllegalOperatorSequence(rawRegexSplited[i]);
                }

                if(rawRegexSplited[i] == '|' && i + 1 < rawRegexSplited.Length && rawRegexSplited[i + 1] == '|')
                {
                    throw ExceptionHandler.IllegalOperatorSequence(rawRegexSplited[i]);
                }
            }

            if(operandCounter == 0)
            {
                throw ExceptionHandler.NonOperands();
            }
        }


        /// <summary>
        /// 对于用户输入的正则表达式，如ab 加点变化为内部可处理的形式a.b。
        /// 此方法用来判断两个给定的字符之间是否需要加点
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private bool NeedDotBetween(char a, char b)
        {
            return ((a == ')' && IsOperand(b))
                || (IsOperand(a) && IsOperand(b))
                || (IsOperand(a) && b == '(')
                || (a == '*' && b == '(')
                || (a == '*' && IsOperand(b))
                || (a == ')' && b == '('));
        }

        /// <summary>
        /// 对用户输入的正则表达式进行加点操作
        /// </summary>
        /// <param name="rawRegex"></param>
        /// <returns></returns>
        private String AddDot(String rawRegex)
        {
            StringBuilder resultSb = new StringBuilder();
            char[] rawRegexSplited = rawRegex.ToCharArray();

            resultSb.Append(rawRegexSplited[0]);

            int curAppended = 0;
            int next = curAppended + 1;

            while(next < rawRegexSplited.Length && rawRegexSplited[next] != END_OF_REGEX)
            {
                if(NeedDotBetween(rawRegexSplited[curAppended], rawRegexSplited[next]))
                {
                    resultSb.Append('.');
                }

                resultSb.Append(rawRegexSplited[next]);
                curAppended = next;
                next++;
            }

            resultSb.Append(END_OF_REGEX);
            return resultSb.ToString();
        }




        /// <summary>
        /// 判断一个字符是否为正则表达式中的合法操作数
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsOperand(char c)
        {
            Regex regex = new Regex("[a-zA-Z]");

            if(regex.IsMatch(c + ""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 判断一个字符是否为正则表达式中的合法运算符
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsOperator(char c)
        {
            Regex regex = new Regex("[|.*#()]");

            if(regex.IsMatch(c + ""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 获得两个字符（运算符）之间的优先级关系
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static char GetPriority(char a, char b)
        {
            if(!IsOperator(a))
            {
                throw ExceptionHandler.UnsupportedOperator(a);
            }

            if(!IsOperator(b))
            {
                throw ExceptionHandler.UnsupportedOperator(b);
            }

            switch(a)
            {
                case ')':

                    if (b == '|' || b == '.' || b == '*' || b == '#' || b == ')')
                    {
                        return '>';
                    }

                    if (b == '(')
                    {
                        throw ExceptionHandler.UnsupportedPriority(a, b);
                    }

                    break;

                case '*':

                    if(b == '|' || b == '.' || b == '*' || b == ')' || b == '#')
                    {
                        return '>';
                    }

                    if(b == '(')
                    {
                        return '<';
                    }

                    break;

                case '.':

                    if(b == '|' || b == '.' || b == ')' || b == '#')
                    {
                        return '>';
                    }

                    if(b == '(' || b == '*')
                    {
                        return '<';
                    }

                    break;

                case '|':

                    if(b == '|' || b == ')' || b == '#')
                    {
                        return '>';
                    }

                    if(b == '.' || b == '*' || b == '(')
                    {
                        return '<';
                    }

                    break;

                case '(':

                    if(b == ')')
                    {
                        return '=';
                    }
                    
                    if(b == '(' || b == '|' || b == '.' || b == '*')
                    {
                        return '<';
                    }

                    break;

                case '#':

                    if(b == '#')
                    {
                        return '=';
                    }

                    if(b == '(' || b == '|' || b == '.' || b == '*')
                    {
                        return '<';
                    }

                    if(b == ')')
                    {
                        throw ExceptionHandler.UnsupportedPriority(a, b);
                    }

                    break;

                default:
                    throw ExceptionHandler.UnsupportedOperator(a);
            }

            throw ExceptionHandler.UnsupportedOperator(a);
        }




        private class ExceptionHandler
        {
            public static ArgumentException UnsupportedPriority(char a, char b)
            {
                return new ArgumentException("\"" + a + "\" 与 " + "\"" + b + "\" 之间的优先级未知!");
            }

            public static ArgumentException UnsupportedOperator(char c)
            {
                return new ArgumentException("非法的运算符: " + c + "!");
            }

            public static ArgumentException UnsupportedSymbol(char c)
            {
                return new ArgumentException("非法的符号: " + c + "!");
            }

            public static ArgumentException NonOperands()
            {
                return new ArgumentException("正则表达式中无操作数, 请返回检查!");
            }

            public static ArgumentException IllegalStart()
            {
                return new ArgumentException("正则表达式不能以 \"#\"开头!");
            }

            public static ArgumentException IllegalOperatorSequence(char c)
            {
                return new ArgumentException("正则表达式不能含有 \"" + c + c + "\" 序列, 请返回检查!");
            }

        }
    }
}
