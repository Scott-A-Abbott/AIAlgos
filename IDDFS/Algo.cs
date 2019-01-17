using System;
using System.Collections.Generic;

namespace IDDFS
{
    public class Algo
    {
        private Node targetNode;
        private volatile bool isTargetFound;

        public Algo(Node targetNode)
        {
            this.targetNode = targetNode;
        }

        public void runDeepeningSearch(Node root){
            int depth = 0;
            while( !isTargetFound ){
                Console.WriteLine();
                dfs(root, depth);
                depth++;
            }
        }

        private void dfs(Node source, int depthLevel){
            Stack<Node> stack = new Stack<Node>();
            stack.Push(source);

            while( stack.Count > 0){
                Node actualNode = stack.Pop();
                Console.Write($"{actualNode.Name} ");

                if(actualNode.Name.Equals(this.targetNode.Name)){
                    Console.WriteLine("Node had been found...");
                    this.isTargetFound = true;
                    return;
                }
                if(actualNode.DepthLevel >= depthLevel){
                    continue;
                }
                foreach(Node node in actualNode.Adjacencies){
                    node.DepthLevel = actualNode.DepthLevel+1;
                    stack.Push(node);
                }
            }
        }
    }
}