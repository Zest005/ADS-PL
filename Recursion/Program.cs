using System;
using System.Collections.Generic;
using System.Linq;

namespace Recursion
{
    /*

    + !!!!!!!! 1.	Given a recursive function (= a definition of a recursive algorithm).

        		3, if n = 0;
    F(n) 	= 
	          	4*F(n-1) + 2*F(n/2) + 7, if n>0;            
    Find value F(3).

    + 2.	Write a recursive algorithm int Prod( int a, int b) that calculates and returns a×b;
    + 3.	Write a recursive algorithm int Sum() that calculates and returns the sum of integer items of a linked list.
    + 4.	Write a recursive algorithm void printList() that prints integer items of a linked list.
    + 5.	Write a recursive algorithm void printListReverse() that prints integer items of a linked list in reverse order.
    +- 6.	Write an algorithm void BST_print_asc() that prints node values of a BST in ascending  order.
    +- 7.	Write an algorithm void BST_print_desc() that prints BST values in descending order.
    + 8.	Write an algorithm int BST_sum() that returns the total sum of integer items in a binary search tree.
    - 9.	Write an algorithm bool isEqual(BST *T2) that compares two binary search trees T1 and T2. It returns true if T1 == T2 (values and shape) and false otherwise. It is called as follows: T1.isEqual(&T2).
    - 10.	Write an algorithm bool sameData(BST *T2) that compares two binary search trees T1 and T2. It returns true if T1 and T2 have the same data items (their shapes may be different) and false otherwise. It is called as follows:  T1.isEqual(&T2).
    + 11.	Write an algorithm function void BST_List(linkedList *L) that copies data from a binary search tree T into a linked list L which is sorted in ascending order. It is called as follows: T.BST_List(&L).
    + 12.	Write an algorithm void makeEmpty() for the class BST.
    + 13.	Write an algorithm int size() for the class BST that returns the number of data items (= nodes) in a BST.
    - 14.	Write an algorithm for the method bool isBalanced() of the class BST that returns true if a calling object is balanced and false otherwise.

    - !!!!!!!! 15.	Given time-efficiency function of some algorithm A:
                5, if n < 3;
    TA (n)  = 
		        4* TA (n - 3) + 2 , if n >= 3;
    Find its asymptotic notation using Master Theorem.

    */

    public class BTNode<T> where T : IComparable
    {
        public BTNode(T data)
        {
            Data = data;
        }

        public T Data { get; set; }

        public BTNode<T> Left { get; private set; }

        public BTNode<T> Right { get; private set; }

        internal void BST_print_asc()
        {
            Left?.BST_print_asc();
            Console.Write(Data + " ");
            Right?.BST_print_asc();
        }

        internal void BST_print_desc()
        {
            Right?.BST_print_desc();
            Console.Write(Data + " ");
            Left?.BST_print_desc();
        }
    }

    public class BST<T> where T : IComparable
    {
        public BTNode<T> Root { get; private set; }
        public int Count { get; private set; }

        public BST() { }

        public BST(BTNode<T> node)
        {
            Root = node;
        }

        // Adding elements to the Binary Tree
        public void Add(T data)
        {
            if (Root == null)
            {
                Root = new BTNode<T>(data);
                Count = 1;
                return;
            }

            //Root.Add(data);
            Count++;
        }

        // Copying data from a BST T into a linked list L which is sorted in ascending order
        public void BST_List(BTNode<T> node, List<T> L)
        {
            if (node == null)
            {
                return;
            }
            L.Add(node.Data);
            if (node.Left != null)
            {
                BST_List(node.Left, L);
            }

            if (node.Right != null)
            {
                BST_List(node.Right, L);
            }
        }

        // Creating List
        public List<T> BST_List()
        {
            var L = new List<T>();
            BST_List(Root, L);
            return L;
        }

        // Calculating and returning the sum of integer items of a linked list
        int Sum(LinkedListNode<int> head)
        {
            if (head != null)
                return head.Value + Sum(head.Next);
            else
                return 0;
        }

        // Printing integer items of a linked list
        static void printList(LinkedListNode<T> head)
        {
            if (head == null)
            {
                return;
            }

            Console.Write(head.Value + " ");
            printList(head.Next);
        }

        // Printing integer items of a linked list in reverse order
        void printListReverse(LinkedListNode<T> head)
        {
            if (head == null) return;

            // print list of head node
            printListReverse(head.Next);

            // After everything else is printed
            Console.Write(head.Value + " ");
        }

        // Printing node values of a BST in ascending and descending orders
        public void PrintSorted()
        {
            Console.WriteLine("Ascending order :");
            BST_print_asc();

            Console.WriteLine("Descending order :");
            BST_print_desc();
            Console.WriteLine();
        }
        private void BST_print_asc()
        {
            Root?.BST_print_asc();
        }

        private void BST_print_desc()
        {
            Root?.BST_print_desc();
        } 

        // Returning the total sum of integer items in a BST
        public int BST_sum(BTNode<int> root)
        {
            if (root == null)
            {
                return 0;
            }
            return (root.Data + BST_sum(root.Right));
        }

        // Comparing two BST T1 and T2 (data, shapes may be different)
        public bool sameData(BST<T> BST)
        {
            return BST_List().SequenceEqual(BST.BST_List());
        }

        // Making empty the BST
        public void makeEmpty()
        {
            Root = null;
        }

        // Returning the number of data items (= nodes) in a BST
        public int size(BTNode<T> node)
        {
            if (node == null)
            {
                return 0;
            }
            else
            {
                return (size(node.Left) + 1 + size(node.Right));
            }
        }
    }

    public class Recurs
    {
        // Recursive algorithm
        public static int Recursion(int n)
        {
            if (n == 0)
            {
                return 3;
            }
            else if (n > 0)
            {
                return 4 * Recursion(n - 1) + 2 * Recursion(n / 2) + 7;
            }
            return 0;
        }

        // Calculating and returning a×b
        public static int Prod(int a, int b)
        {
            if (a < b)
            {
                return Prod(b, a);
            }
            else if (b != 0)
            {
                return (a + Prod(a, b - 1));
            }
            else
                return 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var bst1 = new BST<int>();
            bst1.Add(3);
            bst1.Add(2);
            bst1.Add(1);
            bst1.Add(5);
            bst1.Add(4);

            var bst2 = new BST<int>();
            bst2.Add(6);
            bst2.Add(2);
            bst2.Add(-4);
            bst2.Add(9);
            bst2.Add(-1);

            // Recurs first
            Console.WriteLine($"1 answer:\n{Recurs.Recursion(3)}\n");

            // Calculating and returning a×b
            Console.WriteLine($"2 answer:\n{Recurs.Prod(3, 5)}\n");

            // Recurs second
            Console.WriteLine("15 answer:\n----\n");
        }
    }
}
