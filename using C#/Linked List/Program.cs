using System;
// using SinglyLinkedList;
using DoublyLinkedList;
using static System.Console;

class Program
{
	public static void Main(string[] args)
	{
		LinkedList l = new LinkedList();
		l.Search(0);
		l.Traverse();
		l.Insert(1);
		l.Insert(2, NodePosition.Tail);
		l.Insert(3, (int) NodePosition.Tail);
		// l.Insert(3, NodePosition.After, 2);
		l.Insert(4, NodePosition.Tail);
		l.Insert(5, NodePosition.Tail);
		l.Insert(6, NodePosition.Tail);
		l.Insert(7, NodePosition.Tail);
		l.Insert(8, NodePosition.Tail);
		// l.Insert(9, NodePosition.Before, 1);
		l.Insert(0, NodePosition.Head);
		l.Delete();
		l.Traverse();
		WriteLine();

		// l.Insert(45, NodePosition.Before, 4);
		// l.Insert(46, NodePosition.After, 8);
		l.Traverse();
		WriteLine();

		l.Delete(4);
		l.Delete(8);
		// l.Insert(47, NodePosition.Head, 0);
		// l.Insert(48, NodePosition.Tail, 2);
		l.Delete(NodePosition.Tail);
		l.Traverse();
		/*
		l.Insert(9);
		l.Insert(9, NodePosition.Tail);
		l.Insert(9, 4);
		l.Insert(9, NodePosition.After, 3);
		l.Insert(9, NodePosition.Before, 7);
		l.Traverse();
		l.Search(9);
*/
	}
}
