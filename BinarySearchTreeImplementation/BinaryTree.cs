using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearchTreeImplementation
{
    class BinaryTree
    {
        public Node Root { get; set; }
        public Node TempRoot { get; set; }
        public Queue<Node> queue = new Queue<Node>();
        private Node rightLeafNode = new Node();
        public Node LastLeafNode = new Node();
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
                    if (value < this.TempRoot.Data && this.TempRoot.LeftNode == null)
                    {
                        this.TempRoot.LeftNode = new Node();
                        this.TempRoot.LeftNode.Data = value;
                        break;
                    }
                    //insert to right node
                    else if (value > this.TempRoot.Data && this.TempRoot.RightNode == null)
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
                while (stack.Count > 0)
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
        public void TraversePostOrderRecursion(Node rootNode)
        {

            if (rootNode != null)
            {
                TraversePostOrderRecursion(rootNode.LeftNode);
                TraversePostOrderRecursion(rootNode.RightNode);
                Console.Write(rootNode.Data + " ");

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

            if (queue.Count == 0 && rootNode != null)
            {
                queue.Enqueue(rootNode);
            }

            if (queue.Peek() != null)
            {
                if (queue.Peek().LeftNode != null) queue.Enqueue(queue.Peek().LeftNode);
                if (queue.Peek().RightNode != null) queue.Enqueue(queue.Peek().RightNode);
                Console.WriteLine(queue.Dequeue().Data);
                if (queue.Count > 0)
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
                LastLeafNode = queue.Peek();
                Console.Write(queue.Dequeue().Data + " ");
                LevelOrderTraversalUsingQueueLevelByLevel(queue.Peek());
            }
            else if (queue.Peek() == null)
            {
                queue.Dequeue();
                Console.Write("\n");
                queue.Enqueue(null);
                if (queue.Peek() != null)
                    LevelOrderTraversalUsingQueueLevelByLevel(queue.Peek());
            }

        }

        public void InsertIntoBinaryTreeUsingRecursion(Node node, int data)
        {
            if (node != null)
            {
                if (data < node.Data)
                {
                    if (node.LeftNode == null)
                    {
                        node.LeftNode = new Node();
                        node.LeftNode.Data = data;
                        return;
                    }
                    InsertIntoBinaryTreeUsingRecursion(node.LeftNode, data);
                }
                else if (data > node.Data)
                {
                    if (node.RightNode == null)
                    {
                        node.RightNode = new Node();
                        node.RightNode.Data = data;
                        return;
                    }
                    InsertIntoBinaryTreeUsingRecursion(node.RightNode, data);
                }
                else
                {
                    return; //this is an error
                }
            }
        }

        public void DeleteFromBinaryTree(Node node, int data)
        {

        }

        //This takes 19 ms. Not a good idea
        /// <summary>
        /// This method will give you rightmost and deepeset node. If you have a node which is left and deeper it will be ignored by this method.
        /// We cannot use it for deletion from binary tree
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public Node GetDeepestRightLeafNode(Node root)
        {

            if (root != null && queue.Count == 0)
            {
                queue.Enqueue(root);
                if (queue.Peek().LeftNode == null && queue.Peek().RightNode == null)
                {
                    queue.Clear();
                    return root;
                }
            }
            else if (root != null && queue.Count > 0)
            {
                if (queue.Peek() != null && queue.Peek().LeftNode != null)
                {
                    if (queue.Peek().LeftNode.LeftNode != null || queue.Peek().LeftNode.RightNode != null)
                    {
                        queue.Enqueue(queue.Peek().LeftNode);
                    }
                    else
                    {
                        if (queue.Peek().RightNode != null)
                        {
                            rightLeafNode = queue.Peek().RightNode;

                        }

                    }
                }
                if (queue.Peek() != null && queue.Peek().RightNode != null)
                {
                    if (queue.Peek().RightNode.LeftNode != null || queue.Peek().RightNode.RightNode != null)
                    {
                        queue.Enqueue(queue.Peek().RightNode);
                    }
                    else
                    {
                        if (queue.Peek().RightNode != null)
                        {
                            rightLeafNode = queue.Peek().RightNode;

                        }
                    }
                }
                queue.Dequeue();
            }
            if (queue.Count > 0)
            {
                return GetDeepestRightLeafNode(queue.Peek());
            }
            return rightLeafNode;
        }
        //This takes 0 ms
        /// <summary>
        /// This method will give you rightmost and deepeset node. If you have a node which is left and deeper it will be ignored by this method.
        /// We cannot use it for deletion from binary tree
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public Node getDeepestRightLeafNode_GFG(Node root)
        {
            if (root == null)
                return null;

            // Create a queue for level order traversal 
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);

            Node result = null;

            // Traverse until the queue is empty 
            while (q.Count != 0)
            {
                Node temp = q.Peek();
                q.Dequeue();


                if (temp.LeftNode != null)
                {
                    q.Enqueue(temp.LeftNode);
                }

                // Since we go level by level, the last  
                // stored right leaf node is deepest one  
                if (temp.RightNode != null)
                {
                    q.Enqueue(temp.RightNode);
                    if (temp.RightNode.LeftNode == null && temp.RightNode.RightNode == null)
                        result = temp.RightNode;
                }
            }
            return result;
        }
        /// <summary>
        /// 1. Call the LevelOrderTraversalUsingQueueLevelByLevel to find deepest right most node. Set the value in LastLeafNode object
        /// 2. Clear the queue
        /// 3. Call ReplaceNodeToBeDeletedWithLastNode to replace the data to be deleted with last node
        /// 4. Set LastLeafNodeData to null
        /// 5. Print inorder to check the results.
        /// </summary>
        /// <param name="rootNode"></param>
        /// <param name="data"></param>
        public void DeleteBinaryTreeNode(Node rootNode, int data)
        {
            LevelOrderTraversalUsingQueueLevelByLevel(rootNode);
            queue.Clear();
            ReplaceNodeToBeDeletedWithLastNode(rootNode, data);
            LastLeafNode.Data = null;
            TraverseInOrderRecursion(rootNode);

        }

        /// <summary>
        /// 1. Start with an empty queue and if queue is empty and rootNode is not null, enqueue root node to queue and enqueue a null to queue
        /// 2. start while loop with condition queue count>0
        /// 3.      Check the child of the element in queue. Enqueue the left child and right child in the queue if they are not null
        /// 4.      Check if queue data is equal to data to be deleted. Set the leaf node to that data. 
        ///                 Break out of loop
        /// 5.      If condition 4 is not true dequeue the queue
        /// 6.      Check if queue peek is null dequeue the queue and enque null to queue
        /// </summary>
        /// <param name="rootNode"></param>
        /// <param name="data"></param>
        public void ReplaceNodeToBeDeletedWithLastNode(Node rootNode, int data)
        {
            if (queue.Count == 0 && rootNode != null)
            {
                queue.Enqueue(rootNode);
                queue.Enqueue(null);
            }
            while (queue.Count > 0)
            {
                if (queue.Peek() != null)
                {
                    if (queue.Peek().LeftNode != null) queue.Enqueue(queue.Peek().LeftNode);
                    if (queue.Peek().RightNode != null) queue.Enqueue(queue.Peek().RightNode);
                    if (queue.Peek().Data == data)
                    {
                        queue.Peek().Data = LastLeafNode.Data;
                        break;

                    }
                    queue.Dequeue();

                }
                else if (queue.Peek() == null)
                {
                    queue.Dequeue();
                    queue.Enqueue(null);
                }
            }
        }
        /// <summary>
        /// 1. Start with an empty queue and empty stack. The idea is to do level order traversal and push the items to stack so they can be read in opposite order
        /// 
        /// </summary>
        /// <param name="rootNode"></param>
        public void ReverseLevelOrderTraversal(Node rootNode)
        {
            Queue<Node> localQueue = new Queue<Node>();
            Stack<Node> localStack = new Stack<Node>();
            if (localQueue.Count == 0 && rootNode != null)
            {
                localQueue.Enqueue(rootNode);
            }
            while(localQueue.Count>0)
            {
                if (localQueue.Peek().LeftNode != null) localQueue.Enqueue(localQueue.Peek().LeftNode);
                if (localQueue.Peek().RightNode != null) localQueue.Enqueue(localQueue.Peek().RightNode);
                localStack.Push(localQueue.Dequeue());
            }
            Console.WriteLine("ReverseLevelOrderTraversal");
            Console.WriteLine("------------------------------");
            while (localStack.Count>0)
            {
                Console.WriteLine(localStack.Pop().Data);
            }
        }
        /// <summary>
        /////  Case 1: If node has right subtree
        //        if(p->right!=null)
        //    {
        //  temp=p->right
        //  while(temp->left!=null)
        //        temp=temp->left
        //  print(temp)
        //    }
           //Case 2: If node doesn't have a right subtree
           /*
            s=root
           while(s->data!=p->data)
                if(p->data<=s->data)
                    store=s
                    s=s->left
                else
                    s=s->right
           print store
            */
        /// </summary>
        /// <param name="data"></param>
        public void FindInorderSuccessor(Node rootNode, int data)
        {
            Queue<Node> localQueue = new Queue<Node>();
            Node startNode = new Node();
            Node tempNode = new Node();
            if (localQueue.Count == 0 && rootNode != null)
            {
                localQueue.Enqueue(rootNode);
            }
            //Do an inorder traversal to find the node for which we want to find the inorder successor
            while (localQueue.Count > 0)
            {
                if (localQueue.Peek().LeftNode != null) localQueue.Enqueue(localQueue.Peek().LeftNode);
                if (localQueue.Peek().RightNode != null) localQueue.Enqueue(localQueue.Peek().RightNode);
                if(localQueue.Peek().Data==data)
                {
                    //once the node is found store it and break out of loop
                    startNode = localQueue.Dequeue();
                    break;
                }
                else
                {
                    localQueue.Dequeue();
                }
            }
            //Traverse the right sub tree of the start node to LEFT until you reach a null and that will be the answer.
            if(startNode.RightNode!=null)
            {
                tempNode = startNode.RightNode;
                while(tempNode.LeftNode!=null)
                {
                    tempNode = tempNode.LeftNode;
                }
                Console.WriteLine("Inorder successor is "+tempNode.Data);
            }
            else if(startNode.RightNode==null)
            {
                int? result = 0;
                tempNode = rootNode;
                while (tempNode.Data!=startNode.Data)
                {
                    if(startNode.Data<=tempNode.Data)
                    {
                        result = tempNode.Data;
                        tempNode = tempNode.LeftNode;

                    }
                    else
                    {
                        tempNode = tempNode.RightNode;
                    }
                }
                Console.WriteLine("Inorder successor is "+result);
            }
        }
        /// <summary>
        /// This is solved using level by level traversal algorithm. Height of an empty tree is -1 so we will initialize our variable to -1
        /// 1. Start with an empty queue. Check if rootNode is null return -1
        /// 2. Store  rootNode in a queue followed by null
        /// 3. Start a loop till queue is empty
        ///     If queue peek is not null
        ///             4. If node left and right are not null enqueue them.
        ///             5. Dequeue the queue
        ///     If queue peek is null
        ///             6. Dequeue the queue
        ///             7. increment height by 1
        ///             8. if queue contains only null values this will be end of loop. if not enqueue null
        /// </summary>
        /// <param name="rootNode"></param>
        public void HeightOfBinarySearchTree(Node rootNode)
        {
            int height = -1;
            Queue<Node> queue = new Queue<Node>();
            if(rootNode==null)
            {
                return;
            }
          
            if (queue.Count == 0 && rootNode != null)
            {
                queue.Enqueue(rootNode);
                queue.Enqueue(null);
            }

            while (queue.Count > 0)
            {
                if (queue.Peek() != null)
                {
                    if (queue.Peek().LeftNode != null) queue.Enqueue(queue.Peek().LeftNode);
                    if (queue.Peek().RightNode != null) queue.Enqueue(queue.Peek().RightNode);
                    queue.Dequeue();
                    
                }
                else if (queue.Peek() == null)
                {
                    queue.Dequeue();
                    height++;
                    if(queue.Count>0 && queue.Peek()!=null)
                    queue.Enqueue(null);
                }
            }
            Console.WriteLine("Height of tree is "+height);

        }



    }
}
