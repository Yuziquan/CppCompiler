using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CppCompiler.Lexical_Analysis
{
    /// <summary>
    /// 状态节点之间的转换边
    /// </summary>
    public class Edge<T> where T:Node
    {
        /// <summary>
        /// 开始状态节点
        /// </summary>
        private T startStateNode;
        public T StartStateNode
        {
            get { return startStateNode; }
            set { startStateNode = value; }
        }

        /// <summary>
        /// 结束状态节点
        /// </summary>
        private T endStateNode;
        public T EndStateNode
        {
            get { return endStateNode; }
            set { endStateNode = value; }
        }

        /// <summary>
        /// 路径
        /// </summary>
        private char route;
        public char Route
        {
            get { return route; }
            set { route = value; }
        }

        public Edge(T startStateNode, T endStateNode, char route)
        {
            this.startStateNode = startStateNode;
            this.endStateNode = endStateNode;
            this.route = route;
        }
    }
}
