using System;
using static System.Console;
using DoublyLinkedList;


class Program
{
	public static void Main(string[] args)
	{

		LinkedList l = new LinkedList();
		l.Insert(7);
		l.Insert(6);
		l.Insert(5);
		l.Insert(4);
		l.Insert(3);
		l.Insert(2);
		l.Insert(1);
		l.Insert(8, NodePosition.Last);
		l.Insert(0, NodePosition.First);
		l.Delete();
		l.Traverse(TraverseDirection.FrontToBack);
		l.Traverse(TraverseDirection.BackToFront);
		l.Delete(NodePosition.Last);
		l.Traverse();
		l.Traverse(TraverseDirection.BackToFront);
		l.Delete(3);
		l.Traverse();
		l.Traverse(TraverseDirection.BackToFront);
		l.Insert(3,3);
		l.Insert(1, NodePosition.Last);
		l.Traverse();
		l.Traverse(TraverseDirection.BackToFront);
		
		int data = 1;
		l.Search(data);

/*
		CircularLinkedList cObj = new CircularLinkedList();
		cObj.Insert(7);
		cObj.Insert(6);
		cObj.Insert(5);
		cObj.Insert(4);
		cObj.Insert(3);
		cObj.Insert(2);
		cObj.Insert(1);
		cObj.Traverse(TraverseDirection.FrontToBack);
		cObj.Traverse(TraverseDirection.BackToFront);
		WriteLine();
		cObj.Insert(0, NodePosition.First);
		cObj.Insert(50, 4);
		cObj.Traverse(TraverseDirection.FrontToBack);
		cObj.Traverse(TraverseDirection.BackToFront);
		cObj.Delete();
		cObj.Traverse(TraverseDirection.FrontToBack);
		cObj.Traverse(TraverseDirection.BackToFront);
		cObj.Delete(3);
		cObj.Delete(NodePosition.Last);
		cObj.Insert(100);
		cObj.Insert(100);
		cObj.Insert(100);
		cObj.Insert(100);
		cObj.Traverse(TraverseDirection.FrontToBack);
		cObj.Traverse(TraverseDirection.BackToFront);
		cObj.Search(3);
		cObj.Search(100);
*/
	}
}