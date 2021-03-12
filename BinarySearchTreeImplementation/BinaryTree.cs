using System;
using System.Collections.Generic;
using System.Linq;
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
        public int Count { get; set; }
        public List<Node> sList = new List<Node>();
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
        /// 1. Start with an empty queue and empty stack. The idea is to do level order traversal and push the items to stack 
        /// so they can be read in opposite order
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
            while (localQueue.Count > 0)
            {
                if (localQueue.Peek().LeftNode != null) localQueue.Enqueue(localQueue.Peek().LeftNode);
                if (localQueue.Peek().RightNode != null) localQueue.Enqueue(localQueue.Peek().RightNode);
                localStack.Push(localQueue.Dequeue());
            }
            Console.WriteLine("ReverseLevelOrderTraversal");
            Console.WriteLine("------------------------------");
            while (localStack.Count > 0)
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
        public Node FindInorderSuccessor(Node rootNode, int? data)
        {
            Node result = new Node();
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
                if (localQueue.Peek().Data == data)
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
            if (startNode.RightNode != null)
            {
                tempNode = startNode.RightNode;
                while (tempNode.LeftNode != null)
                {
                    //this condition is needed for reverse morris traversal
                    if (tempNode.LeftNode == startNode)
                    {
                        break;
                    }
                    tempNode = tempNode.LeftNode;
                }

                //Console.WriteLine("Inorder successor is " + tempNode.Data);
                return tempNode;
            }
            //if the start node doesn't have a left subtree then start from root again and run a loop till you hit the start node
            //every time you make a left turn while searching for start node store it because its a potential candidate for answer
            //once you reach start node print the stored variable.
            else if (startNode.RightNode == null)
            {

                tempNode = rootNode;
                while (tempNode.Data != startNode.Data)
                {
                    if (startNode.Data <= tempNode.Data)
                    {
                        result = tempNode;
                        tempNode = tempNode.LeftNode;

                    }
                    else
                    {
                        tempNode = tempNode.RightNode;
                    }
                }
                // Console.WriteLine("Inorder successor is " + result.Data);

            }
            return result;
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
        public int HeightOfBinarySearchTree(Node rootNode)
        {
            int height = -1;
            Queue<Node> queue = new Queue<Node>();
            if (rootNode == null)
            {
                return 0;
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
                    if (queue.Count > 0 && queue.Peek() != null)
                        queue.Enqueue(null);
                }
            }
            //Console.WriteLine("Height of tree is " + height);
            return height;

        }

        public void PopulateInorderSuccessorForAllNodes()
        {

        }
        public Node FindInorderPredecessor(Node rootNode, int? data)
        {
            Node result = new Node();
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
                if (localQueue.Peek().Data == data)
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
            //Traverse the left sub tree of the start node to RIGHT until you reach a null and that will be the answer.
            if (startNode.LeftNode != null)
            {
                tempNode = startNode.LeftNode;
                while (tempNode.RightNode != null)
                {
                    //this condition is needed for morris traversal
                    if (tempNode.RightNode == startNode)
                    {
                        return tempNode;
                    }
                    tempNode = tempNode.RightNode;
                }
                //  Console.WriteLine("Inorder predecessor is " + tempNode.Data);
                result = tempNode;
            }
            //if the start node doesn't have a left subtree then start from root again and run a loop till you hit the start node
            //every time you make a right turn while searching for start node store it because its a potential candidate for answer
            //once you reach start node print the stored variable.
            else if (startNode.LeftNode == null)
            {

                tempNode = rootNode;
                while (tempNode.Data != startNode.Data)
                {
                    if (startNode.Data > tempNode.Data)
                    {
                        result = tempNode;
                        tempNode = tempNode.RightNode;

                    }
                    else
                    {
                        tempNode = tempNode.LeftNode;
                    }
                }
                // Console.WriteLine("Inorder predecessor is " + result.Data);

            }
            return result;
        }
        /// <summary>
        /// 1. Initialize rootNode to currentpointer node. This current pointer node will be used for traversal
        /// 2. Start a loop for currentpointer node not null
        ///         3. Check if current pointer left child is null print current pointer
        ///             4. Set current pointer to right child and continue the loop
        ///         5. If current pointer left child is not null. Find the inorder predecessor of current node. This inorder predecessor is different
        ///         from normal. We have to modify the case 1 where we traverse the right nodes of the left subtree till we find null
        ///         the modification is to look for either null or start node. The reason is we make temporary right child which looks like a loop. 
        ///         This connection will be made in step 6.
        ///         6. If predecessor right node is null then set the predecessor right node as current pointer (this is the loop)
        ///              7. move left by setting current pointer to current pointer left child.
        ///          8. If predecessor right node is not null set predecessor right node to null (break the loop)
        ///                9. print current pointer data
        ///                10. set current pointer to right child
        ///  11. Repeat the loop in step 2
        /// </summary>
        /// <param name="rootNode"></param>
        public void MorrisTraversal(Node rootNode)
        {
            Node currentPointer = new Node();
            Node predecessor = new Node();
            currentPointer = rootNode;
            while (currentPointer != null)
            {
                if (currentPointer.LeftNode == null)
                {
                    Console.WriteLine(currentPointer.Data);
                    currentPointer = currentPointer.RightNode;
                }
                else
                {
                    //predecessor = currentPointer.LeftNode;
                    //while (predecessor.RightNode != null && predecessor.RightNode != currentPointer)
                    //{
                    //    predecessor = predecessor.RightNode;
                    //}
                    predecessor = FindInorderPredecessor(currentPointer, currentPointer.Data);
                    if (predecessor.RightNode == null)
                    {
                        predecessor.RightNode = currentPointer;
                        currentPointer = currentPointer.LeftNode;
                    }
                    else
                    {
                        predecessor.RightNode = null;
                        Console.WriteLine(currentPointer.Data);
                        currentPointer = currentPointer.RightNode;
                    }
                }
            }
        }

        public void ReverseMorrisTraversal(Node rootNode)
        {
            Console.WriteLine("Reverse Morris Traversal");
            Node currentPointer = new Node();
            Node successor = new Node();
            Node previouslyVisitedNode = new Node();
            currentPointer = rootNode;
            while (currentPointer != null)
            {
                if (currentPointer.RightNode == null)
                {
                    if (previouslyVisitedNode.Data == null)
                    {
                        previouslyVisitedNode.Data = currentPointer.Data;
                    }
                    if (previouslyVisitedNode.Data != currentPointer.Data)
                        Console.WriteLine("Next of {0} is {1} ", previouslyVisitedNode.Data, currentPointer.Data);
                    currentPointer = currentPointer.LeftNode;
                }
                else
                {
                    successor = FindInorderSuccessor(currentPointer, currentPointer.Data);
                    if (successor.LeftNode == null)
                    {
                        successor.LeftNode = currentPointer;
                        currentPointer = currentPointer.RightNode;
                    }
                    else
                    {
                        successor.LeftNode = null;
                        Console.WriteLine(currentPointer.Data);
                        currentPointer = currentPointer.LeftNode;
                    }
                }
            }
        }

        /// <summary>
        /// Simplest way to solve this is using preorder traversal and 
        /// counting the number of nodes you pass which are greater than the last max node passed
        /// Root node will always be a visible node
        /// </summary>
        /// <param name="rootNode"></param>
        /// <param name="max"></param>
        public void CountTheNumberOfvisibleNodes(Node rootNode, int max)
        {
            if (rootNode == null)
            {
                return;
            }

            if (rootNode != null && rootNode.Data >= max)
            {
                Count++;
                max = Math.Max((int)rootNode.Data, (int)max);
            }
            Console.Write(rootNode.Data + " ");
            CountTheNumberOfvisibleNodes(rootNode.LeftNode, max);
            CountTheNumberOfvisibleNodes(rootNode.RightNode, max);

        }

        /// <summary>
        /// Simple idea is to do a preorder traversal and compare every node.
        /// </summary>
        /// <param name="firstTree"></param>
        /// <param name="secondTree"></param>
        /// <returns></returns>
        public bool CheckIfTwoTreesAreIdentical(Node firstTree, Node secondTree)
        {
            //both trees are null and hence same
            if (firstTree == null && secondTree == null)
            {
                return true;
            }
            else if (firstTree == null)
            {
                return false;
            }
            else if (secondTree == null)
            {
                return false;
            }
            else
            {
                Stack<Node> firstStack = new Stack<Node>();
                Stack<Node> secondStack = new Stack<Node>();
                firstStack.Push(firstTree);
                secondStack.Push(secondTree);
                while (firstStack.Count > 0 && secondStack.Count > 0)
                {
                    var firstchild = firstStack.Pop();
                    var secondChild = secondStack.Pop();
                    if (firstchild.Data != secondChild.Data)
                    {
                        return false;
                    }
                    if (firstchild.RightNode != null)
                        firstStack.Push(firstchild.RightNode);
                    if (firstchild.LeftNode != null)
                        firstStack.Push(firstchild.LeftNode);
                    if (secondChild.RightNode != null)
                        secondStack.Push(secondChild.RightNode);
                    if (secondChild.LeftNode != null)
                        secondStack.Push(secondChild.LeftNode);

                }
            }
            return true;
        }

        /// <summary>
        /// Simple idea is to do a preorder traversal and compare every node.
        /// </summary>
        /// <param name="firstTree"></param>
        /// <param name="secondTree"></param>
        /// <returns></returns>
        public bool CheckIfTwoTreesAreIdenticalRecursion(Node firstTree, Node secondTree)
        {
            //both trees are null and hence same
            if (firstTree == null && secondTree == null)
            {
                return true;
            }
            else if (firstTree == null)
            {
                return false;
            }
            else if (secondTree == null)
            {
                return false;
            }
            if (firstTree != null && secondTree != null)
            {
                if (firstTree.Data != secondTree.Data)
                {
                    return false;
                }
                TraversePreOrderRecursion(firstTree.LeftNode);
                TraversePreOrderRecursion(secondTree.LeftNode);
                TraversePreOrderRecursion(firstTree.RightNode);
                TraversePreOrderRecursion(secondTree.RightNode);
            }
            return true;

        }

        /// <summary>
        /// This is a combination of level order traversal and storing horizontal distance in hashtable/dictionary
        /// we will first put root node as value in dictionary
        /// then when we enqueue the left child we will put the key as horizontal distance of root -1
        /// then when we enqueue the right child we will put the key as horizontal distance of root +1
        /// </summary>
        public void VerticalOrderTraversal(Node rootNode)
        {
            Queue<Node> queue = new Queue<Node>();
            Dictionary<int, List<int?>> dict = new Dictionary<int, List<int?>>();

            if (queue.Count == 0 && rootNode != null)
            {
                queue.Enqueue(rootNode);
                dict.Add(0, new List<int?> { rootNode.Data });
            }
            while (queue.Count > 0)
            {
                if (queue.Peek() != null)
                {
                    if (queue.Peek().LeftNode != null)
                    {
                        queue.Enqueue(queue.Peek().LeftNode);

                        foreach (var keyValuePair in dict)
                        {
                            if (keyValuePair.Value.Contains(queue.Peek().Data))
                            {
                                if (!dict.ContainsKey(keyValuePair.Key - 1))
                                {
                                    dict.Add(keyValuePair.Key - 1, new List<int?> { queue.Peek().LeftNode.Data });
                                    break;
                                }
                                else
                                {
                                    dict[keyValuePair.Key - 1].Add(queue.Peek().LeftNode.Data);
                                    break;
                                }
                            }

                        }
                    }
                    if (queue.Peek().RightNode != null)
                    {
                        queue.Enqueue(queue.Peek().RightNode);
                        foreach (var keyValuePair in dict)
                        {
                            if (keyValuePair.Value.Contains(queue.Peek().Data))
                            {
                                if (!dict.ContainsKey(keyValuePair.Key + 1))
                                {
                                    dict.Add(keyValuePair.Key + 1, new List<int?> { queue.Peek().RightNode.Data });
                                    break;
                                }
                                else
                                {
                                    dict[keyValuePair.Key + 1].Add(queue.Peek().RightNode.Data);
                                    break;
                                }
                            }
                        }
                    }

                    queue.Dequeue();
                }
            }
            foreach (var pair in dict)
            {
                Console.Write(pair.Key + ": ");
                foreach (var val in pair.Value)
                {
                    Console.Write(val + ", ");
                }
                Console.WriteLine("\n");
            }


        }
        /// <summary>
        /// This is done using vertical order traversal
        /// The idea is to keep replacing values of the key with the newer values for the same key
        /// At the end whatever is left will be bottom view
        /// </summary>
        /// <param name="rootNode"></param>
        public void BottomViewOfBinayTree(Node rootNode)
        {
            Queue<Node> queue = new Queue<Node>();
            SortedDictionary<int, int> dict = new SortedDictionary<int, int>();

            if (queue.Count == 0 && rootNode != null)
            {
                queue.Enqueue(rootNode);
                dict.Add(0, (int)rootNode.Data);
            }
            while (queue.Count > 0)
            {
                if (queue.Peek() != null)
                {
                    if (queue.Peek().LeftNode != null)
                    {
                        queue.Enqueue(queue.Peek().LeftNode);
                        dict[dict.FirstOrDefault(x => x.Value == (int)queue.Peek().Data).Key - 1] = (int)queue.Peek().LeftNode.Data;
                    }
                    if (queue.Peek().RightNode != null)
                    {
                        queue.Enqueue(queue.Peek().RightNode);
                        dict[dict.FirstOrDefault(x => x.Value == (int)queue.Peek().Data).Key + 1] = (int)queue.Peek().RightNode.Data;
                    }

                    queue.Dequeue();
                }
            }
            foreach (var pair in dict)
            {
                Console.WriteLine(pair.Value);
            }

        }
        /// This is done using vertical order traversal
        /// The idea is to put the horizontal distance for the first time for a key and then never replace it
        /// At the end whatever is left will be bottom view
        public void TopViewOfBinayTree(Node rootNode)
        {
            Queue<Node> queue = new Queue<Node>();
            SortedDictionary<int, int> dict = new SortedDictionary<int, int>();

            if (queue.Count == 0 && rootNode != null)
            {
                queue.Enqueue(rootNode);
                dict.Add(0, (int)rootNode.Data);
            }
            while (queue.Count > 0)
            {
                if (queue.Peek() != null)
                {
                    if (queue.Peek().LeftNode != null)
                    {
                        queue.Enqueue(queue.Peek().LeftNode);
                        if (!dict.ContainsKey(dict.FirstOrDefault(x => x.Value == (int)queue.Peek().Data).Key - 1))
                            dict[dict.FirstOrDefault(x => x.Value == (int)queue.Peek().Data).Key - 1] = (int)queue.Peek().LeftNode.Data;
                    }
                    if (queue.Peek().RightNode != null)
                    {
                        queue.Enqueue(queue.Peek().RightNode);
                        if (!dict.ContainsKey(dict.FirstOrDefault(x => x.Value == (int)queue.Peek().Data).Key + 1))
                            dict[dict.FirstOrDefault(x => x.Value == (int)queue.Peek().Data).Key + 1] = (int)queue.Peek().RightNode.Data;
                    }

                    queue.Dequeue();
                }
            }
            foreach (var pair in dict)
            {
                Console.WriteLine(pair.Value);
            }

        }

        /// <summary>
        /// This is solved using recursion 
        /// Store node in a temp value. Do sum of left subtree and right subtree and then add to node and return
        /// </summary>
        /// <param name="rootNode"></param>
        public int InSumTree(Node rootNode)
        {

            if (rootNode != null)
            {
                int? val = rootNode.Data;
                rootNode.Data = InSumTree(rootNode.LeftNode) + InSumTree(rootNode.RightNode);
                return (int)(rootNode.Data + val);

            }
            return 0;
        }

        /// <summary>
        /// We will solve this using level order traversal.
        /// We will create a dictionary with key as node data and value as a string of format Level-Parent
        /// Once the dictionary is filled, we will parse through dictionary and find the cousins
        /// </summary>
        /// <param name="rootNode"></param>
        public void FindAllCousinsInBinaryTree(Node rootNode)
        {

            Queue<Node> queue = new Queue<Node>();
            Dictionary<int?, string> dict = new Dictionary<int?, string>();
            if (rootNode == null)
            {
                return;
            }

            if (queue.Count == 0 && rootNode != null)
            {
                queue.Enqueue(rootNode);
                dict.Add(rootNode.Data, "1-null");
                queue.Enqueue(null);
            }

            while (queue.Count > 0)
            {
                if (queue.Peek() != null)
                {
                    if (queue.Peek().LeftNode != null)
                    {
                        if (!dict.ContainsKey(queue.Peek().LeftNode.Data))
                        {
                            string val = (Convert.ToInt32(dict[queue.Peek().Data].Split("-")[0]) + 1).ToString() + "-" + queue.Peek().Data;
                            dict.Add(queue.Peek().LeftNode.Data, val);
                        }
                        queue.Enqueue(queue.Peek().LeftNode);
                    }
                    if (queue.Peek().RightNode != null)
                    {
                        if (!dict.ContainsKey(queue.Peek().RightNode.Data))
                        {
                            string val = (Convert.ToInt32(dict[queue.Peek().Data].Split("-")[0]) + 1).ToString() + "-" + queue.Peek().Data;
                            dict.Add(queue.Peek().RightNode.Data, val);
                        }
                        queue.Enqueue(queue.Peek().RightNode);
                    }
                    queue.Dequeue();

                }
                else if (queue.Peek() == null)
                {
                    queue.Dequeue();
                    if (queue.Count > 0 && queue.Peek() != null)
                        queue.Enqueue(null);
                }
            }
            //parse through dictionary and print the cousins
            foreach(var pair in dict)
            {
                var cousins = dict.Select(x => x.Value.Split("-")[0] == pair.Value.Split("-")[0] && x.Value.Split("-")[1] != pair.Value.Split("-")[1]).ToList();
                if (cousins.Contains(true))
                {
                    for (int i = 0; i < cousins.Count; i++)
                    {
                        if (cousins[i] == true)
                        {
                            Console.Write(dict.ElementAt(i).Key + "-");
                        }
                    }
                    Console.Write(pair.Key);
                    Console.WriteLine("");
                }
                dict.Remove(pair.Key);
            }
        }

        public void FindCousinOfGivenNodeInBinaryTree(Node rootNode, int data)
        {
            Queue<Node> queue = new Queue<Node>();
            Dictionary<int?, string> dict = new Dictionary<int?, string>();
            if (rootNode == null || rootNode.Data==data)
            {
                return;
            }

            if (queue.Count == 0 && rootNode != null)
            {
                queue.Enqueue(rootNode);
                dict.Add(rootNode.Data, "1-null");
                queue.Enqueue(null);
            }
            while (queue.Count > 0)
            {
                if (queue.Peek() != null)
                {
                    if (queue.Peek().LeftNode != null)
                    {
                        if (!dict.ContainsKey(queue.Peek().LeftNode.Data))
                        {
                            string val = (Convert.ToInt32(dict[queue.Peek().Data].Split("-")[0]) + 1).ToString() + "-" + queue.Peek().Data;
                            dict.Add(queue.Peek().LeftNode.Data, val);
                        }
                        queue.Enqueue(queue.Peek().LeftNode);
                    }
                    if (queue.Peek().RightNode != null)
                    {
                        if (!dict.ContainsKey(queue.Peek().RightNode.Data))
                        {
                            string val = (Convert.ToInt32(dict[queue.Peek().Data].Split("-")[0]) + 1).ToString() + "-" + queue.Peek().Data;
                            dict.Add(queue.Peek().RightNode.Data, val);
                        }
                        queue.Enqueue(queue.Peek().RightNode);
                    }
                    queue.Dequeue();

                }
                else if (queue.Peek() == null)
                {
                    queue.Dequeue();
                    if (queue.Count > 0 && queue.Peek() != null)
                        queue.Enqueue(null);
                }
            }
            var level = dict[data].Split("-")[0];
            var parent = dict[data].Split("-")[1];
            var cousins = dict.Select(x => x.Value.Split("-")[0] == level && x.Value.Split("-")[1] != parent).ToList();
            for(int i=0;i<cousins.Count;i++)
            {
                if(cousins[i]==true)
                {
                    Console.WriteLine(dict.ElementAt(i).Key);
                }
            }
        }

        public int IsSumTree(Node rootNode,out bool isSumTree)
        {
            isSumTree = true;
            if (rootNode != null)
            {
                int? val = rootNode.Data;
                //Calculate the sum of left tree and right tree and compare against root node
                var leftNodeSum = InSumTree(rootNode.LeftNode);
                var rightNodeSum = InSumTree(rootNode.RightNode);
                if (rootNode.Data == leftNodeSum + rightNodeSum)
                {
                    isSumTree = isSumTree && true;
                    rootNode.Data = rootNode.Data + leftNodeSum + rightNodeSum;
                }
                else
                {
                    isSumTree = isSumTree && false;
                }
                return (int)(rootNode.Data + val);

            }
            return 0;
        }

        /// <summary>
        /// A perfect binary tree has 2^h nodes at height h
        /// The idea is to check the formula we increase the height and if a mismatch is found return false otherwise continue
        /// </summary>
        /// <param name="rootNode"></param>
        public Node IsPerfectBinaryTree(Node rootNode)
        {
            
            int height = 0;
            Queue<Node> queue = new Queue<Node>();
            if (rootNode == null)
            {
                return null;
            }
            if(rootNode.LeftNode==null && rootNode.RightNode==null)
            {
                return rootNode;
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
                    //check if the formula is valid
                    if(queue.Count(x=>x!=null)==Math.Pow(2,height))
                    {
                        //returnVal = true;
                    }
                    //queue has some children and formula is not valid
                    else if(queue.Count!=0)
                    {
                        //this means its not a perfect binary tree
                        height = -2;
                        return null;
                    }
                    if (queue.Count > 0 && queue.Peek() != null)
                        queue.Enqueue(null);
                }
            }
            //return the height if its a perfect binary tree
            return rootNode;
        }

        public void FindBiggestPerfectBinaryTree(Node rootNode)
        {
            Node returnedNode = new Node();
            
            if (rootNode != null)
            {
                returnedNode = IsPerfectBinaryTree(rootNode);
                if (returnedNode!= null)
                    sList.Add(returnedNode);
                FindBiggestPerfectBinaryTree(rootNode.LeftNode);
                //Console.Write(rootNode.Data + " ");
                FindBiggestPerfectBinaryTree(rootNode.RightNode);
            }
        }
        /// <summary>
        /// There can be two cases
        /// 1. If diameter passes through root the diameter will be height of left subtree+ height of right subtree +1
        /// 2. If diameter doesnt pass through root we will recursively call the left and right subtree as root and 
        /// consider them as root nodes and calculate the diameters.
        ///     Every time we get the diameter of left and right subtree we will keep the bigger one and compare them with root as diameter value
        ///     . The bigger one will be answer
        /// </summary>
        /// <param name="rootNode"></param>
        /// <returns></returns>
        public int DiameterOfBinaryTree(Node rootNode)
        {
            int leftHeight = 0, rightHeight = 0;
            if (rootNode==null)
            {
                return 0;
            }
            if(rootNode.LeftNode!=null)
                leftHeight= HeightOfBinarySearchTree(rootNode.LeftNode)+1;
            if (rootNode.RightNode != null)
                rightHeight= HeightOfBinarySearchTree(rootNode.RightNode)+1;
           
            int leftDiameter = DiameterOfBinaryTree(rootNode.LeftNode);
            int rightDiameter = DiameterOfBinaryTree(rootNode.RightNode);
            int finalDiameter = Math.Max(leftHeight + rightHeight + 1, Math.Max(leftDiameter, rightDiameter));
            return finalDiameter;
        }
        /// <summary>
        /// This will be done recursively. A binary tree is considered as mirror of another tree if
        /// the left child of tree 1 is right child of tree2 and right child of tree 1 is left child of tree 2
        /// Check for the following conditions
        /// 1. If both trees are null, answer is true
        /// 2. If one tree is null and other is not answer is false
        /// 3. If node 1 data is not equal to node 2 data answer is false
        /// 4. If 3rd condition is not true then we will call the method again with node 1 left and node 2 right, node 1 right and node2 left.
        /// Basically we are checking for subtree
        /// 
        /// </summary>
        /// <param name="rootNode1"></param>
        /// <param name="rootNode2"></param>
        /// <returns></returns>
        public bool CheckIfTwoBinaryTreesAreMirror(Node rootNode1, Node rootNode2)
        {
            if(rootNode1==null && rootNode2==null)
            {
                return true;
            }
            if (rootNode1 == null || rootNode2 == null)
            {
                return false;
            }
            if(rootNode1.Data==rootNode2.Data)
            {
                if(CheckIfTwoBinaryTreesAreMirror(rootNode1.LeftNode,rootNode2.RightNode)&&CheckIfTwoBinaryTreesAreMirror(rootNode1.RightNode,rootNode2.LeftNode))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Just pass the left subtree and right subtree to the CheckIfTwoBinaryTreesAreMirror method
        /// </summary>
        /// <param name="rootNode"></param>
        /// <returns></returns>
        public bool CheckIfABinaryTreeIsSymmetric(Node rootNode)
        {
            if(rootNode==null)
            {
                return false;
            }
            if(rootNode.LeftNode==null && rootNode.RightNode==null)
            {
                return true;
            }
            if (rootNode.LeftNode == null || rootNode.RightNode == null)
            {
                return false;
            }
            return CheckIfTwoBinaryTreesAreMirror(rootNode.LeftNode, rootNode.RightNode);
        }
    }
}
