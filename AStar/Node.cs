using System;

namespace AStar
{
    public class Node
    {
        //how far away the node is from the starting point
        private int g;
        //how far away the node is from the end node
        private int h;
        private int rowIndex;
        private int clmnIndex;
        //previous node in the path
        private Node predecessor;
        //if the node is an obsticle/block
        private bool isBlock;

        public Node(int rowIndex, int clmnIndex)
        {
            this.RowIndex = rowIndex;
            this.ClmnIndex = clmnIndex;
        }

        public int G { get => g; set => g = value; }
        public int H { get => h; set => h = value; }
        public int F { get => this.g + this.h; }
        public int RowIndex { get => rowIndex; set => rowIndex = value; }
        public int ClmnIndex { get => clmnIndex; set => clmnIndex = value; }
        public Node Predecessor { get => predecessor; set => predecessor = value; }
        public bool IsBlock { get => isBlock; set => isBlock = value; }

        public override bool Equals(Object node2)
        {
            Node otherNode = (Node)node2;
            return this.rowIndex == otherNode.RowIndex && this.clmnIndex == otherNode.ClmnIndex;
        }
        public override string ToString(){
            return $"Node ({this.rowIndex};{this.clmnIndex}) h:{this.h} - g:{this.g} - f={this.F}";
        }
    }

    //override
}