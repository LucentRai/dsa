using System;
using static System.Console;
using SingleLinkedList;

class Program
{
	public static void Main(string[] args)
	{
		WriteLine("This program demonstrates Single Linked List.");
		/*
		LinkedList l = new LinkedList();
		l.Insert(1);
		l.Insert(2, NodePosition.Last);
		l.Insert(3, (int) NodePosition.Last);
		l.Insert(4, NodePosition.Last);
		l.Insert(5, NodePosition.Last);
		l.Insert(6, NodePosition.Last);
		l.Insert(7, NodePosition.Last);
		l.Insert(8, NodePosition.Last);
		l.Insert(9, NodePosition.Last);
		l.Insert(0, (int) NodePosition.First);
		l.Traverse();
		l.Delete(5);
		l.Traverse();
		l.Delete(4);
		l.Traverse();
		l.Delete((int) NodePosition.Last);
		l.Traverse();
		l.Delete((int) NodePosition.First);
		l.Insert(3, 3);
		l.Insert(4, 4);
		l.Traverse();
		l.Search(9);
		*/

		CircularLinkedList c = new CircularLinkedList();
		c.Insert(10);
		c.Search(1);
		c.Insert(9);
		c.Insert(8);
		c.Insert(7);
		c.Insert(6);
		c.Insert(5);
		c.Insert(4);
		c.Insert(3);
		c.Insert(2);
		c.Insert(1);
		c.Insert(40, 6);
		c.Delete(6);
		c.Traverse();
		c.Insert(50, 7, NodePosition.After);
		c.Traverse();
		c.Delete();
		c.Traverse();
		c.Delete(NodePosition.Last);
		c.Traverse();
		c.Search(9);
	}
}