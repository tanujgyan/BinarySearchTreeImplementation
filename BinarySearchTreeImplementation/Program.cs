using System;
using System.Collections;
using System.Collections.Generic;

namespace BinarySearchTreeImplementation
{

    class Program
    {
       
        static BinaryTree CreateSampleTree()
        {
            BinaryTree binaryTree = new BinaryTree();
            ArrayList list1 = new ArrayList { 50,16,90,14,40,78,100,10,15,35,45,75,82,5,32,36,81,85,37,79,87};
           ArrayList list2 = new ArrayList { 10,5,30,-2,6,40,2,8,-1 };
            BinaryTree binaryTree1 = new BinaryTree();
            BinaryTree binaryTree2 = new BinaryTree();
            
            //binaryTree.queue.Clear();
            foreach (int l in list1)
            {
                binaryTree1.Add(l);
            }
            foreach (int l in list2)
            {
                binaryTree2.Add(l);
            }
            binaryTree.Root = new Node();
            binaryTree.Root.Data = 1;
            binaryTree.Root.LeftNode = new Node();
            binaryTree.Root.LeftNode.Data = 2;
            binaryTree.Root.RightNode = new Node();
            binaryTree.Root.RightNode.Data = 3;

            //binaryTree.Root.LeftNode.LeftNode = new Node();
            //binaryTree.Root.LeftNode.LeftNode.Data = 4;
            //binaryTree.Root.LeftNode.RightNode = new Node();
            //binaryTree.Root.LeftNode.RightNode.Data = 5;
            //binaryTree.Root.RightNode.LeftNode = new Node();
            //binaryTree.Root.RightNode.LeftNode.Data = 6;
            //binaryTree.Root.RightNode.RightNode = new Node();
            //binaryTree.Root.RightNode.RightNode.Data = 7;
            //binaryTree.Add(10);
            //binaryTree.Add(5);
            //binaryTree.Add(11);
            //binaryTree.Add(4);
            ////binaryTree.Add(2);
            //binaryTree.Add(3);
            //binaryTree.Add(1);
            //binaryTree.Add(2);
            //binaryTree.Add(7);
            //binaryTree.Add(3);
            //binaryTree.Add(10);
            //binaryTree.Add(5);
            //binaryTree.Add(8);
            return binaryTree;
        }
        static BinaryTree CreateSampleTree2()
        {
            ArrayList list1 = new ArrayList { 50, 16, 90, 14, 40, 78, 100, 10, 15, 35, 45, 75, 82, 5, 32, 36, 81, 85, 37, 79, 87 };
            ArrayList list2 = new ArrayList { 10, 5, 30, -2, 6, 40, 2, 8, -1 };
            BinaryTree binaryTree1 = new BinaryTree();
            BinaryTree binaryTree2 = new BinaryTree();
            //binaryTree.queue.Clear();
            foreach (int l in list1)
            {
                binaryTree1.Add(l);
            }
            foreach (int l in list2)
            {
                binaryTree2.Add(l);
            }
            
            return binaryTree2;
        }
        static void Main(string[] args)
        {
            var binaryTree = CreateSampleTree();
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var elapsedMs = watch.ElapsedMilliseconds;
            //Console.WriteLine("PreOrder Traversal:");
            //binaryTree.TraversePreOrderRecursion(binaryTree.Root);
            //watch.Stop();
            //var elapsedMs = watch.ElapsedMilliseconds;
            //Console.WriteLine("Recursion time " + elapsedMs);
            // watch = System.Diagnostics.Stopwatch.StartNew();
            //binaryTree.TraversePreOrderIteration(binaryTree.Root);
            //watch.Stop();
            //elapsedMs = watch.ElapsedMilliseconds;
            //Console.WriteLine("Iteration time " + elapsedMs);
            //Console.WriteLine();
            //binaryTree.TraverseInOrderRecursion(binaryTree.Root);
            //binaryTree.LevelOrderTraversalUsingQueue(binaryTree.Root);
            //binaryTree.LevelOrderTraversalUsingQueueLevelByLevel(binaryTree.Root);
            var node = binaryTree.LastLeafNode;
            //binaryTree.TraversePostOrderRecursion(binaryTree.Root);
            //binaryTree.InsertIntoBinaryTreeUsingRecursion(binaryTree.Root, 11);
            //binaryTree.GetDeepestRightLeafNode(binaryTree.Root);
            watch.Stop();
            //Console.WriteLine("Recursion time " + elapsedMs);
            //watch = System.Diagnostics.Stopwatch.StartNew();
           // binaryTree.getDeepestRightLeafNode_GFG(binaryTree.Root);
            watch.Stop();
            //elapsedMs = watch.ElapsedMilliseconds;
            //Console.WriteLine("GFG time " + elapsedMs);
            binaryTree.queue.Clear();
            watch = System.Diagnostics.Stopwatch.StartNew();
            // binaryTree.DeleteBinaryTreeNode(binaryTree.Root, 5);
            //watch.Stop();
            //elapsedMs = watch.ElapsedMilliseconds;
            //Console.WriteLine("Delete from binary tree time " + elapsedMs);
            //binaryTree.ReverseLevelOrderTraversal(binaryTree.Root);
            //binaryTree.FindInorderSuccessor(binaryTree.Root, 37);
            // binaryTree.HeightOfBinarySearchTree(binaryTree.Root);
            // binaryTree.FindInorderPredecessor(binaryTree.Root, 100);
            //binaryTree.MorrisTraversal(binaryTree.Root);
            //binaryTree.ReverseMorrisTraversal(binaryTree.Root);
            //binaryTree.CountTheNumberOfvisibleNodes(binaryTree.Root, Int32.MinValue);
            //Console.WriteLine(binaryTree.Count);
            //var result = binaryTree.CheckIfTwoTreesAreIdentical(CreateSampleTree().Root, CreateSampleTree2().Root);
            //Console.WriteLine("Two trees are identical: "+result);
            //var result1 = binaryTree.CheckIfTwoTreesAreIdenticalRecursion(CreateSampleTree().Root, CreateSampleTree2().Root);
            //Console.WriteLine("Two trees are identical by recursion: " + result);

            //binaryTree.VerticalOrderTraversal(CreateSampleTree2().Root);
            //binaryTree.BottomViewOfBinayTree(CreateSampleTree2().Root);
            // binaryTree.TopViewOfBinayTree(CreateSampleTree().Root);
           
            binaryTree.Root = new Node();
            binaryTree.Root.Data = 44;
            binaryTree.Root.LeftNode = new Node();
            binaryTree.Root.LeftNode.Data = 9;
            binaryTree.Root.RightNode = new Node();
            binaryTree.Root.RightNode.Data = 13;
            binaryTree.Root.LeftNode.LeftNode = new Node();
            binaryTree.Root.LeftNode.LeftNode.Data = 4;
            binaryTree.Root.LeftNode.RightNode = new Node();
            binaryTree.Root.LeftNode.RightNode.Data = 5;
            binaryTree.Root.RightNode.LeftNode = new Node();
            binaryTree.Root.RightNode.LeftNode.Data = 6;
            binaryTree.Root.RightNode.RightNode = new Node();
            binaryTree.Root.RightNode.RightNode.Data = 7;
            // binaryTree.InSumTree(binaryTree.Root);
            //binaryTree.FindAllCousinsInBinaryTree(binaryTree.Root);
            // binaryTree.FindCousinOfGivenNodeInBinaryTree(binaryTree.Root,4);

            binaryTree.IsSumTree(binaryTree.Root, out bool isSumTree);
            Console.WriteLine(isSumTree);

        }
    }
}
