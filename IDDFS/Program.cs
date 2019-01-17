using System;

namespace IDDFS
{
    class Program
    {
        static void Main(string[] args)
        {
            Node node0 = new Node("A");
            Node node1 = new Node("B");
            Node node2 = new Node("C");
            Node node3 = new Node("D");
            Node node4 = new Node("E");

            node0.AddNeighbor(node1);
            node0.AddNeighbor(node2);
            node1.AddNeighbor(node3);
            node3.AddNeighbor(node4);

            Algo algo = new Algo(node1);
            algo.runDeepeningSearch(node0);
        }
    }
}
