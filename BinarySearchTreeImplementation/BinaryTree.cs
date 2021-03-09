using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearchTreeImplementation
{
    class BinaryTree
    {
        public Node Root { get; set; }
        public Node TempRoot { get; set; }
        Queue<Node> queue = new Queue<Node>();
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
        public void TraverseInOrderRecursion(Node rootNode)
        {

            if (rootNode != null)
            {
                TraverseInOrderRecursion(rootNode.LeftNode);
                Console.Write(rootNode.Data + " ");
                TraverseInOrderRecursion(rootNode.RightNode);
            }

        }

        /// <summary>
        /// This is level order in one line 
        /// 1. If queue is empty and root node is not null meaning we are starting the process for the first time put root Node in queue
        /// 2. Check if queue has some node in it. If the node in queue has a left child, enqueue the left child
        /// 3. Check if queue has some node in it. If the node in queue has a right child, enqueue the left child
        /// 4. Dequeue the queue and print the element
        /// 5. If the root node has a left child, call recursion with left child as root node
        /// 6. If root node has right child call recursion with right child as root node
        /// </summary>
        /// <param name="rootNode"></param>
        public void LevelOrderTraversalUsingQueue(Node rootNode)
        {
            
            if (queue.Count==0 && rootNode != null)
            {
                queue.Enqueue(rootNode);
            }

            if (queue.Peek() != null)
            {
                if(queue.Peek().LeftNode!=null) queue.Enqueue(queue.Peek().LeftNode);
                if (queue.Peek().RightNode != null) queue.Enqueue(queue.Peek().RightNode);
                Console.WriteLine(queue.Dequeue().Data);
                if (queue.Count>0)
                    LevelOrderTraversalUsingQueue(queue.Peek());
            }
            //if (rootNode.LeftNode != null)
            //    LevelOrderTraversalUsingQueue(rootNode.LeftNode);
            //if (rootNode.RightNode != null)
            //    LevelOrderTraversalUsingQueue(rootNode.RightNode);
        }
        /// <summary>
        /// This is level order level by level algorithm
        /// 1. For the first element add it to queue and add a null after that
        /// If queue peek is not null
        ///     2. Check the queue and if the data is not null enqueue the left and right child
        ///     3. Dequeue the data and print it
        ///     4. Peek the data from queue and call the recursion using the peeked data
        /// If queue peek is null
        ///     5. Dequeue
        ///     6. Write new line
        ///     7. enqueue null 
        ///     8. check if peeked element is not null call recursion with peeked element
        /// 
        /// </summary>
        /// <param name="rootNode"></param>
        public void LevelOrderTraversalUsingQueueLevelByLevel(Node rootNode)
        {
            if (queue.Count == 0 && rootNode != null)
            {
                queue.Enqueue(rootNode);
                queue.Enqueue(null);
            }
            if (queue.Peek() != null)
            {
                if (queue.Peek().LeftNode != null) queue.Enqueue(queue.Peek().LeftNode);
                if (queue.Peek().RightNode != null) queue.Enqueue(queue.Peek().RightNode);
                Console.Write(queue.Dequeue().Data +" ");
                LevelOrderTraversalUsingQueueLevelByLevel(queue.Peek());
            }
            else if(queue.Peek()==null)
            {
                queue.Dequeue();
                Console.Write("\n");
                queue.Enqueue(null);
                if(queue.Peek()!=null)
                    LevelOrderTraversalUsingQueueLevelByLevel(queue.Peek());
            }
           
            

        }
    }
}
