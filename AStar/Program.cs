using System;

namespace AStar
{
    class Program
    {
        static void Main(string[] args)
        {
            AStarAlgo algo = new AStarAlgo();
            algo.search();
            algo.ShowPath();
        }
    }
}
