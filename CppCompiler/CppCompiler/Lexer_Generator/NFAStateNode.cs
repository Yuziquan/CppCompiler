using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CppCompiler.Lexical_Analysis
{
    /// <summary>
    /// NFA的状态节点类
    /// </summary>
    public class NFAStateNode:Node, IComparable
    {
        /// <summary>
        /// 目前已产生的NFA状态节点数
        /// </summary>
        public static int counter = 1;


        /// <summary>
        /// 唯一地标识每个状态节点的id, 该类每生成一个实例，计数器加1，以此来唯一标识该类的一个实例
        /// </summary>
        private int id = counter++;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        /// <summary>
        /// 以此状态为起点的边的集合
        /// </summary>
        private List<Edge<NFAStateNode>> edgeList = new List<Edge<NFAStateNode>>();
        public List<Edge<NFAStateNode>> EdgeList
        {
            get { return edgeList; }
            set { edgeList = value; }
        }


        /// <summary>
        /// 将当前节点与另一个节点连接
        /// </summary>
        /// <param name="endStateNode">结束状态节点</param>
        /// <param name="route">连接路径</param>
        public void Connect(NFAStateNode endStateNode, char route)
        {
            edgeList.Add(new Edge<NFAStateNode>(this, endStateNode, route));
        }


        /// <summary>
        /// 获得以该状态为起点经过路径route所能到达的状态节点集合
        /// </summary>
        /// <param name="route"></param>
        /// <returns></returns>
        public List<NFAStateNode> Pass(char route)
        {
            List<NFAStateNode> destNodes = new List<NFAStateNode>();

            foreach(Edge<NFAStateNode> edge in edgeList)
            {
                if(edge.Route == route)
                {
                    destNodes.Add(edge.EndStateNode);
                }
            }

            destNodes.Sort();
            return destNodes;
        }


        /// <summary>
        /// 计算当前状态节点的epsilon闭包
        /// </summary>
        /// <returns></returns>
        public List<NFAStateNode> NullClosure()
        {
            List<NFAStateNode> destNodes = new List<NFAStateNode>();
            Stack<NFAStateNode> stack = new Stack<NFAStateNode>();

            // epsilon闭包总是包含该状态本身
            destNodes.Add(this);

            stack.Push(this);

            while(stack.Count != 0)
            {
                foreach(Edge<NFAStateNode> edge in stack.Pop().EdgeList)
                {
                    if(edge.Route == NFA.NULL_CHAR)
                    {
                        NFAStateNode destNode = edge.EndStateNode;
                        
                        if(!destNodes.Contains(destNode))
                        {
                            destNodes.Add(destNode);
                            stack.Push(destNode);
                        }
                    }
                }
            }

            destNodes.Sort();
            return destNodes;
        }




        public int CompareTo(object obj)
        {
            if(obj is NFAStateNode)
            {
                return Id.CompareTo(((NFAStateNode)obj).Id);
            }

            return 1;
        }
    }
}
