using System;

namespace BinarySearchTreeImplementation
{

    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree binaryTree = new BinaryTree();

            binaryTree.Add(1);
            binaryTree.Add(2);
            binaryTree.Add(7);
            binaryTree.Add(3);
            binaryTree.Add(10);
            binaryTree.Add(5);
            binaryTree.Add(8);
            //Console.WriteLine("PreOrder Traversal:");
            //var watch = System.Diagnostics.Stopwatch.StartNew();
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
            binaryTree.LevelOrderTraversalUsingQueueLevelByLevel(binaryTree.Root);
        }
    }
}
