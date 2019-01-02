using System;
using System.Collections;
using System.Collections.Generic;                            
using System.Linq;
using System.Text;

namespace CppCompiler.Lexical_Analysis
{
    /// <summary>
    /// 整个DFA
    /// </summary>
    public class DFA
    {
        /// <summary>
        /// 未最小化的DFA中所有的状态节点
        /// </summary>
        private List<DFAStateNode> allStateNodes;
        public List<DFAStateNode> AllStateNodes
        {
            get { return allStateNodes; }
            set { allStateNodes = value; }
        }

        /// <summary>
        /// 未最小化的DFA的开始状态节点
        /// </summary>
        private DFAStateNode startStateNode;
        public DFAStateNode StartStateNode
        {
            get { return startStateNode; }
            set { startStateNode = value; }
        }


        /// <summary>
        /// 未最小化的DFA中的结束状态节点
        /// </summary>
        private List<DFAStateNode> endStateNodes;
        public List<DFAStateNode> EndStateNodes
        {
            get { return endStateNodes; }
            set { endStateNodes = value; }
        }


        /// <summary>
        /// 最小化后的DFA中所有的状态节点
        /// </summary>
        private List<DFAStateNode> minDFAAllStateNodes;
        public List<DFAStateNode> MinDFAAllStateNodes
        {
            get { return minDFAAllStateNodes; }
            set { minDFAAllStateNodes = value; }
        }


        /// <summary>
        /// 最小化后的DFA的开始状态节点
        /// </summary>
        private DFAStateNode minDFAStartStateNode;
        public DFAStateNode MinDFAStartStateNode
        {
            get { return minDFAStartStateNode; }
            set { minDFAStartStateNode = value; }
        }


        /// <summary>
        /// 最小化后的DFA的结束状态节点
        /// </summary>
        private List<DFAStateNode> minDFAEndStateNodes;
        public List<DFAStateNode> MinDFAEndStateNodes
        {
            get { return minDFAEndStateNodes; }
            set { minDFAEndStateNodes = value; }
        }


        private NFA nfa;
        public NFA NFA
        {
            get { return nfa; }
            set { nfa = value; }
        }

        public List<char> GetAlphabet()
        {
            return nfa.Alphabet;
        }



        public DFA(NFA nfa)
        {
            this.nfa = nfa;
            allStateNodes = new List<DFAStateNode>();
            endStateNodes = new List<DFAStateNode>();

            minDFAAllStateNodes = new List<DFAStateNode>();
            minDFAEndStateNodes = new List<DFAStateNode>();

            CreateDFA(nfa);
        }


        /// <summary>
        /// 用NFA构造DFA
        /// </summary>
        /// <param name="nfa"></param>
        private void CreateDFA(NFA nfa)
        {

            Stack<DFAStateNode> stack = new Stack<DFAStateNode>();

            startStateNode = new DFAStateNode();
            startStateNode.AddNFAStateNodeList(NullClosure(nfa.StartStateNode));
            allStateNodes.Add(startStateNode);

            stack.Push(startStateNode);

            while (stack.Count != 0)
            {
                DFAStateNode curNode = stack.Pop();

                foreach (char c in nfa.Alphabet)
                {
                    List<NFAStateNode> destNodes = NullClosure(MoveTo(curNode, c));

                    // 是否需要产生新的DFA状态节点
                    bool needNew = true;

                    foreach (DFAStateNode existedNode in allStateNodes)
                    {
                        if (existedNode.Contains(destNodes))
                        {
                            curNode.Connect(existedNode, c);
                            needNew = false;
                            break;
                        }
                    }

                    if (needNew && destNodes.Count != 0)
                    {
                        DFAStateNode newNode = new DFAStateNode();
                        newNode.AddNFAStateNodeList(destNodes);
                        curNode.Connect(newNode, c);
                        stack.Push(newNode);
                        allStateNodes.Add(newNode);
                    }
                }
            }

            FillEndStateNodes();
        }


        private List<NFAStateNode> NullClosure(NFAStateNode node)
        {
            return node.NullClosure();
        }


        private List<NFAStateNode> NullClosure(List<NFAStateNode> nodes)
        {
            List<NFAStateNode> destNodes = new List<NFAStateNode>();

            foreach (NFAStateNode node in nodes)
            {
                destNodes.AddRange(NullClosure(node));
            }

            destNodes.Sort();
            return destNodes;
        }


        /// <summary>
        /// 从当前包含多个NFA节点的DFA节点node出发，经路径route，所能到达的NFA节点集合
        /// </summary>
        /// <param name="node"></param>
        /// <param name="route"></param>
        /// <returns></returns>
        private List<NFAStateNode> MoveTo(DFAStateNode node, char route)
        {
            List<NFAStateNode> destNodes = new List<NFAStateNode>();

            foreach (NFAStateNode n in node.Content)
            {
                destNodes.AddRange(n.Pass(route));
            }

            return destNodes;
        }



        /// <summary>
        /// 填充DFA的结束状态节点集合
        /// </summary>
        private void FillEndStateNodes()
        {
            foreach (DFAStateNode d in AllStateNodes)
            {
                foreach (NFAStateNode n in nfa.EndStateNodes)
                {
                    if (d.Content.Contains(n))
                    {
                        endStateNodes.Add(d);
                    }
                }
            }
        }

      
        /// <summary>
        /// DFA最小化
        /// </summary>
        public void MiniMize()
        {
            DFAStateNode.counter = 1;

            // 所有分组（总分组）
            List<List<DFAStateNode>> allGroups = new List<List<DFAStateNode>>();

            List<DFAStateNode> endStateNodeGroup = endStateNodes;
            List<DFAStateNode> nonEndStateNodeGroup = new List<DFAStateNode>();

            foreach (DFAStateNode node in allStateNodes)
            {
                if (!endStateNodes.Contains(node))
                {
                    nonEndStateNodeGroup.Add(node);
                }
            }

            allGroups.Add(endStateNodeGroup);

            if(nonEndStateNodeGroup.Count > 0)
            {
                allGroups.Add(nonEndStateNodeGroup);
            }

            foreach (char eachRoute in GetAlphabet())
            {
                // 所有分组在路径eachRoute下进行所有状态节点的比对时，产生的新分组
                List<List<DFAStateNode>> allNewSmallGroups = new List<List<DFAStateNode>>();

                // 对所有分组都遍历一遍
                foreach (List<DFAStateNode> group in allGroups)
                {
                    if (group.Count > 1)
                    {
                        // 保存当前分组中的所有状态节点经路径eachRoute后到达的目标节点所属的分组（属于allGroups中的哪个分组）
                        List<List<DFAStateNode>> destNodeGroups = new List<List<DFAStateNode>>();

                        // 添加一个新的空分组，作为专门保存经路径eachRoute后到达的目标节点为null时，目标节点所属的分组
                        destNodeGroups.Add(new List<DFAStateNode>());

                        // 当前分组在路径eachRoute下进行所有状态节点的比对时，产生的新分组
                        List<List<DFAStateNode>> newSmallGroups = new List<List<DFAStateNode>>();

                        // 添加一个新的空分组，作为经路径eachRoute后到达的目标节点为null时，产生的新分组
                        newSmallGroups.Add(new List<DFAStateNode>());

                        DFAStateNode firstDestNode = group.ElementAt(0).Pass(eachRoute);

                        // 该状况下，直接将当前的group作为当前的group中的状态节点经路径eachRoute后到达的目标节点为null时，所属的新分组
                        if (firstDestNode == null)
                        {
                            for (int i = group.Count - 1; i >= 1; i--)
                            {
                                DFAStateNode destNode = group.ElementAt(i).Pass(eachRoute);

                                if (destNode != null)
                                {
                                    List<DFAStateNode> destNodeGroup = FindGroup(allGroups, destNode);

                                    if (destNodeGroups.Contains(destNodeGroup))
                                    {
                                        int location = destNodeGroups.IndexOf(destNodeGroup);
                                        newSmallGroups.ElementAt(location).Add(group.ElementAt(i));
                                        group.RemoveAt(i);
                                    }
                                    else
                                    {
                                        destNodeGroups.Add(destNodeGroup);

                                        // 产生新分组
                                        List<DFAStateNode> newSmallGroup = new List<DFAStateNode>();
                                        newSmallGroup.Add(group.ElementAt(i));
                                        newSmallGroups.Add(newSmallGroup);

                                        group.RemoveAt(i);
                                    }
                                }
                            }
                        }
                        else
                        {
                            // firstDestNode所属的分组
                            List<DFAStateNode> firstDestNodeGroup = FindGroup(allGroups, firstDestNode);

                            for (int i = group.Count - 1; i >= 1; i--)
                            {
                                DFAStateNode destNode = group.ElementAt(i).Pass(eachRoute);

                                if (destNode == null)
                                {
                                    newSmallGroups.ElementAt(0).Add(group.ElementAt(i));
                                    group.RemoveAt(i);
                                }
                                else
                                {
                                    List<DFAStateNode> destNodeGroup = FindGroup(allGroups, destNode);

                                    if (destNodeGroup.Count != firstDestNodeGroup.Count || !destNodeGroup.All(firstDestNodeGroup.Contains))
                                    {
                                        if (destNodeGroups.Contains(destNodeGroup))
                                        {
                                            int location = destNodeGroups.IndexOf(destNodeGroup);
                                            newSmallGroups.ElementAt(location).Add(group.ElementAt(i));
                                            group.RemoveAt(i);
                                        }
                                        else
                                        {
                                            destNodeGroups.Add(destNodeGroup);

                                            // 产生新分组
                                            List<DFAStateNode> newSmallGroup = new List<DFAStateNode>();
                                            newSmallGroup.Add(group.ElementAt(i));
                                            newSmallGroups.Add(newSmallGroup);

                                            group.RemoveAt(i);
                                        }
                                    }
                                }
                            }

                        }


                        if (newSmallGroups.ElementAt(0).Count > 0)
                        {
                            allNewSmallGroups.AddRange(newSmallGroups);
                        }
                        else
                        {
                            newSmallGroups.RemoveAt(0);
                            allNewSmallGroups.AddRange(newSmallGroups);
                        }

                    }
                }

                // 将新产生的分组加入到总分组中
                allGroups.AddRange(allNewSmallGroups);
            }

            CreateMinDFA(allGroups);
        }



        /// <summary>
        /// 根据产生的所有新分组构建最小化DFA
        /// </summary>
        /// <param name="groups"></param>
        private void CreateMinDFA(List<List<DFAStateNode>> groups)
        {
            if(groups != null && groups.Count > 0)
            {
                // 根据最小化的DFA的开始/结束状态节点，对各组节点重新组织、分类
                List<List<DFAStateNode>> sortedGroups = new List<List<DFAStateNode>>();

                // 最小化DFA的开始状态节点所属的组索引
                int minDFAStartStateNodeGroupIndex = FindGroupIndex(groups, startStateNode);

                // 最小化DFA的所有结束状态节点所属的组索引
                List<int> minDFAEndStateNodeGroupIndexes = new List<int>();
                foreach(DFAStateNode node in endStateNodes)
                {
                    int groupIndex = FindGroupIndex(groups, node);
                    if(!minDFAEndStateNodeGroupIndexes.Contains(groupIndex))
                    {
                        minDFAEndStateNodeGroupIndexes.Add(groupIndex);
                    }
                }
                minDFAEndStateNodeGroupIndexes.Sort();


                sortedGroups.Add(groups.ElementAt(minDFAStartStateNodeGroupIndex));

                for (int i = 0; i < groups.Count; i++)
                {
                    if (i != minDFAStartStateNodeGroupIndex && !minDFAEndStateNodeGroupIndexes.Contains(i))
                    {
                        sortedGroups.Add(groups.ElementAt(i));
                    }
                }

                for(int i = 0; i < minDFAEndStateNodeGroupIndexes.Count; i++)
                {
                    sortedGroups.Add(groups.ElementAt(minDFAEndStateNodeGroupIndexes.ElementAt(i)));
                }
              

                for (int i = 0; i < sortedGroups.Count; i++)
                {
                    minDFAAllStateNodes.Add(new DFAStateNode());
                }


                for (int i = 0; i < sortedGroups.Count; i++)
                {
                    DFAStateNode node = sortedGroups.ElementAt(i).ElementAt(0);
                    List<Edge<DFAStateNode>> edgeList = node.EdgeList;

                    foreach(Edge<DFAStateNode> edge in edgeList)
                    {
                        minDFAAllStateNodes.ElementAt(i).Connect(minDFAAllStateNodes.ElementAt(FindGroupIndex(sortedGroups, edge.EndStateNode)), edge.Route);
                    }
                }


                // 最小化DFA的开始状态节点
                minDFAStartStateNode = minDFAAllStateNodes.ElementAt(FindGroupIndex(sortedGroups, startStateNode));

                // 填充最小化DFA的结束状态节点集
                for(int i = 0; i < minDFAAllStateNodes.Count; i++)
                {
                    if(endStateNodes.Contains(sortedGroups.ElementAt(i).ElementAt(0)))
                    {
                        minDFAEndStateNodes.Add(minDFAAllStateNodes.ElementAt(i));
                    }
                }
            }
        }
        


        /// <summary>
        /// 得到某一DFA状态节点所属的分组
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private List<DFAStateNode> FindGroup(List<List<DFAStateNode>> groups, DFAStateNode node)
        {
            foreach (List<DFAStateNode> group in groups)
            {
                if (group.Contains(node))
                {
                    return group;
                }
            }

            return null;
        }


        /// <summary>
        /// 得到某一DFA状态节点所属的分组的索引
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private int FindGroupIndex(List<List<DFAStateNode>> groups, DFAStateNode node)
        {
            for(int i = 0; i < groups.Count; i++)
            {
                if (groups.ElementAt(i).Contains(node))
                {
                    return i;
                }
            }

            return -1;
        }

    }

}
