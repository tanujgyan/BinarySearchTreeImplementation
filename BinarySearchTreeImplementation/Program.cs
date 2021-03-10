using System;
using System.Collections;
using System.Collections.Generic;

namespace BinarySearchTreeImplementation
{

    class Program
    {
        static BinaryTree CreateSampleTree()
        {
            ArrayList list = new ArrayList { 50,16,90,14,40,80,100,10,15,35,45,75,82,105,5,32,36,81,85,30,37,87};
            BinaryTree binaryTree = new BinaryTree();
            binaryTree.queue.Clear();
            foreach(int l in list)
            {
                binaryTree.Add(l);
            }
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
            binaryTree.HeightOfBinarySearchTree(binaryTree.Root);
        }
    }
}
