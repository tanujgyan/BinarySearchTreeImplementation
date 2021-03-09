using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearchTreeImplementation
{
    class BinaryTree
    {
        public Node Root { get; set; }
        public Node TempRoot { get; set; }
        public void Add(int value)
        {
           
            if (this.Root == null)
            {
                this.Root = new Node();
                this.Root.Data = value;
            }
            else
            {
                TempRoot = Root;
                while (true)
                {
                    //insert to left node
                    if (value < this.TempRoot.Data && this.TempRoot.LeftNode==null)
                    {
                        this.TempRoot.LeftNode = new Node();
                        this.TempRoot.LeftNode.Data = value;
                        break;
                    }
                    //insert to right node
                    else if (value > this.TempRoot.Data && this.TempRoot.RightNode==null)
                    {
                      this.TempRoot.RightNode = new Node();
                      this.TempRoot.RightNode.Data = value;
                      break;
                    }
                    //traverse to right node
                    else if (value > this.TempRoot.Data && this.TempRoot.RightNode != null)
                    {
                        this.TempRoot = this.TempRoot.RightNode;
                    }
                    //traverse to left node
                    if (value < this.TempRoot.Data && this.TempRoot.LeftNode != null)
                    {
                        this.TempRoot = this.TempRoot.LeftNode;
                    }
                    //this is an error
                    else if (value == this.Root.Data)
                    {
                        return; 
                    }
                }

            }
        }
        
        public void TraversePreOrderIteration(Node rootNode)
        {
            
            if (rootNode == null)
            {
                Console.WriteLine("tree is empty");
            }
            else
            {
                Stack<Node> stack = new Stack<Node>();
                stack.Push(rootNode);
                while(stack.Count>0)
                {
                    var child = stack.Pop();
                    Console.WriteLine(child.Data);
                    if (child.RightNode != null)
                        stack.Push(child.RightNode);
                    if (child.LeftNode != null)
                        stack.Push(child.LeftNode);
                }
            }          
        }
        public void TraversePreOrderRecursion(Node rootNode)
        {
            
            if (rootNode != null)
            {
                Console.Write(rootNode.Data + " ");
                TraversePreOrderRecursion(rootNode.LeftNode);
                TraversePreOrderRecursion(rootNode.RightNode);
            }
           
        }
    }
}
