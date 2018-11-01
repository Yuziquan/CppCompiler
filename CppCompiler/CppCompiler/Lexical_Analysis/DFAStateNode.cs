using CppCompiler.Lexical_Analysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CppCompiler
{
    /// <summary>
    ///  DFA的状态节点类
    /// </summary>
    public class DFAStateNode:Node, IComparable
    {
        /// <summary>
        /// 目前已产生的DFA状态节点数
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
        private List<Edge<DFAStateNode>> edgeList = new List<Edge<DFAStateNode>>();
        public List<Edge<DFAStateNode>> EdgeList
        {
            get { return edgeList; }
            set { edgeList = value; }
        }

        /// <summary>
        /// 该DFA状态节点所包含的NFA节点集合
        /// </summary>
        private List<NFAStateNode> content = new List<NFAStateNode>();
        public List<NFAStateNode> Content
        {
            get
            {
                content.Sort();
                return content;
            }
            set { content = value; }
        }

        /// <summary>
        /// 将当前节点与另一个节点连接
        /// </summary>
        /// <param name="endStateNode">结束状态节点</param>
        /// <param name="route">连接路径</param>
        public void Connect(DFAStateNode endStateNode, char route)
        {
            edgeList.Add(new Edge<DFAStateNode>(this, endStateNode, route));
        }


        public void AddNFAStateNode(NFAStateNode node)
        {
            content.Add(node);
        }


        public void AddNFAStateNodeList(List<NFAStateNode> nodeList)
        {
            content.AddRange(nodeList);
        }

        /// <summary>
        /// 判断当前的DFA状态节点是否等价于另一个NFA状态节点集
        /// </summary>
        /// <param name="nodeList"></param>
        /// <returns></returns>
        public bool Contains(List<NFAStateNode> nodeList)
        {
            if(content.Count != nodeList.Count)
            {
                return false;
            }

            for(int i = 0; i < content.Count; i++)
            {
                if(content.ElementAt(i).Id != nodeList.ElementAt(i).Id)
                {
                    return false;
                }
            }

            return true;
        }


        /// <summary>
        /// 获得以该状态为起点经过路径route所能到达的状态节点
        /// </summary>
        /// <param name="route"></param>
        /// <returns></returns>
        public DFAStateNode Pass(char route)
        {
            foreach (Edge<DFAStateNode> edge in edgeList)
            {
                if (edge.Route == route)
                {
                    return edge.EndStateNode;
                }
            }

            return null;
        }


        public int CompareTo(object obj)
        {
            if (obj is DFAStateNode)
            {
                return Id.CompareTo(((DFAStateNode)obj).Id);
            }

            return 1;
        }
    }
}
