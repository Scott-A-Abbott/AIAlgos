using System;
using System.Collections.Generic;

namespace IDDFS
{
    public class Node
    {
        private string name;
        private int depthLevel = 0;
        private List<Node> adjacencies;

        public Node(string name)
        {
            this.Name = name;
            this.adjacencies = new List<Node>();
        }

        public string Name { get => name; set => name = value; }
        public int DepthLevel { get => depthLevel; set => depthLevel = value; }
        public List<Node> Adjacencies { get => adjacencies; }

        public void AddNeighbor(Node node)
        {
            Adjacencies.Add(node);
        }
    }
}