using System;
using System.Collections.Generic;

namespace AStar
{
    public class NodeComparator : IComparer<Node>
    {
        public int Compare(Node node1, Node node2){
            if(node1.F < node2.F) return -1;
            if(node1.F > node2.F) return +1;
            return 0;
        }
    }
}