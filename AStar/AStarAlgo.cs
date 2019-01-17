using System;
using System.Collections.Generic;
using static AStar.Constants;

namespace AStar
{
    public class AStarAlgo
    {
        //all the nodes/states on the grid
        private Node[,] searchSpace;
        //where we start
        private Node startNode;
        //this is what we are after
        private Node finalNode;
        //the set of nodes that are already evaluated
        private List<Node> closedSet;
        private PriorityQueue<Node> openSet;

        public AStarAlgo()
        {
            this.searchSpace = new Node[NUM_ROWS, NUM_CLMS];
            this.openSet = new PriorityQueue<Node>();
            this.closedSet = new List<Node>();
            InitializeSearchSpace();
        }

        private void InitializeSearchSpace()
        {
            //initialize all the nodes (states) on the grid
            for (int rowIndex = 0; rowIndex < NUM_ROWS; rowIndex++)
            {
                for (int clmnIndex = 0; clmnIndex < NUM_CLMS; clmnIndex++)
                {
                    Node node = new Node(rowIndex, clmnIndex);
                    this.searchSpace[rowIndex, clmnIndex] = node;
                }
            }

            //set obstacles or blocks
            this.searchSpace[1, 7].IsBlock = true;
            this.searchSpace[2, 3].IsBlock = true;
            this.searchSpace[2, 4].IsBlock = true;
            this.searchSpace[2, 5].IsBlock = true;
            this.searchSpace[2, 6].IsBlock = true;
            this.searchSpace[2, 7].IsBlock = true;

            //start node and final node
            this.startNode = this.searchSpace[3, 3];
            this.finalNode = this.searchSpace[1, 6];
        }

        public void search()
        {
            //start with the start node
            startNode.H = manhattanHeuristic(startNode, finalNode);
            openSet.Add(startNode);

            //the algorithm terminates when there are no items left in the open set
            while (!openSet.IsEmpty())
            {
                //shift: returns the node with the smallest f=h+g value
                Node currentNode = openSet.Shift();
                Console.WriteLine($"{currentNode} Predecessor is: {currentNode.Predecessor}");

                //if we find the terminal state, we're done
                if (currentNode.Equals(finalNode)) return;

                //his way:
                //of course we have to update the sets
                //openSet.Remove(currentNode);
                //closedSet.Add(currnetNode);
                //My way:
                //only update the closed set
                closedSet.Add(currentNode);

                //visit all the neighbors of the actual node
                foreach (Node neighbor in GetAllNeighbors(currentNode))
                {
                    //we have already considered that state so go on
                    if (closedSet.Contains(neighbor)) continue;
                    //we consider the state so we're done with that one
                    if (!openSet.Contains(neighbor)) openSet.Add(neighbor);

                    //set the predecessor to be able to track the shortest path
                    neighbor.Predecessor = currentNode;
                }
            }
        }

        public int manhattanHeuristic(Node node1, Node node2)
        {
            return (Math.Abs(node1.RowIndex - node2.RowIndex) + Math.Abs(node1.ClmnIndex - node2.ClmnIndex)) * 10;
        }

        private List<Node> GetAllNeighbors(Node node)
        {
            //store the neighbors in a list
            //NODE: in this implementation every node can have 4 neighbors at most (above, below, left, right)
            List<Node> neighbors = new List<Node>();

            int row = node.RowIndex;
            int clmn = node.ClmnIndex;

            //block above
            if (row - 1 >= 0 && !this.searchSpace[row - 1, clmn].IsBlock)
            {
                Node blockAbove = this.searchSpace[row - 1, clmn];
                blockAbove.G = node.G + HOR_VERT_COST;
                blockAbove.H = manhattanHeuristic(blockAbove, finalNode);
                neighbors.Add(blockAbove);
            }
            //block below
            if (row + 1 < NUM_ROWS && !this.searchSpace[row + 1, clmn].IsBlock)
            {
                Node blockBelow = this.searchSpace[row + 1, clmn];
                blockBelow.G = node.G + HOR_VERT_COST;
                blockBelow.H = manhattanHeuristic(blockBelow, finalNode);
                neighbors.Add(blockBelow);
            }
            //block to the left
            if (clmn - 1 >= 0 && !this.searchSpace[row, clmn - 1].IsBlock)
            {
                Node blockLeft = this.searchSpace[row, clmn - 1];
                blockLeft.G = node.G + HOR_VERT_COST;
                blockLeft.H = manhattanHeuristic(blockLeft, finalNode);
                neighbors.Add(blockLeft);
            }
            //block to the right
            if (clmn + 1 < NUM_CLMS && !this.searchSpace[row, clmn + 1].IsBlock)
            {
                Node blockRight = this.searchSpace[row, clmn + 1];
                blockRight.G = node.G + HOR_VERT_COST;
                blockRight.H = manhattanHeuristic(blockRight, finalNode);
                neighbors.Add(blockRight);
            }

            return neighbors;
        }

        public void ShowPath()
        {
            Console.WriteLine("SHORTEST PATH WITH A* SEARCH:");

            Node node = this.finalNode;

            while (node != null)
            {
                Console.WriteLine(node);
                node = node.Predecessor;
            }
        }
    }
}