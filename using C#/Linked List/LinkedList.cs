#define DEBUG

using System;
using System.Collections;
using static System.Console;

namespace SinglyLinkedList
{
public enum NodePosition
{
	Head = 1,
	Tail = -1,
	Before = -2,
	After = -3
}
public class LinkedList
{
	protected int numOfNodes;
	protected ArrayList DataFound;
	internal Node head, node, newNode;
	public int GetNumOfNodes => numOfNodes;
	public LinkedList()
	{
		head = null;
	}
	public void Insert(int data)
	{
		Insert(data, NodePosition.Head);
	}
	public virtual void Insert(int data, int key)
	{
		if(IsKeyValid(key))
		{
			if(key == 1 || key == (int)NodePosition.Head)
			{
				Insert(data, NodePosition.Head);
			}
			else if(key == numOfNodes || key == (int)NodePosition.Tail)
			{
				Insert(data, NodePosition.Tail);
			}
			else
			{
				node = head;
				for(int i = 1, j = key - 1; i < j; i++)
				{
					node = node.next;
				}
				newNode = new Node(data, node.next);
				node.next = newNode;
				numOfNodes++;
				#if DEBUG
				WriteLine($"Inserted node at {key}\nTotal Nodes = {numOfNodes}");
				#endif
			}
		}
	}
	public virtual void Insert(int data, NodePosition position)
	{
		if(position == NodePosition.Head)
		{
			head = new Node(data, head);
			#if DEBUG
			WriteLine($"Inserted {data} in the beginning");
			#endif
		}
		else 
		{
			node = head;
			while(node.next != null)
			{
				node = node.next;
			}
			newNode = new Node(data);
			node.next = newNode;
			#if DEBUG
			WriteLine($"Inserted {data} at the end");
			#endif
		}
		numOfNodes++;
	}
	public virtual void Insert(int data, NodePosition position, int key)
	{
		if(head == null)
		{
			Insert(data, NodePosition.Head);
		}
	
		if(IsKeyValid(key))
		{
			if(position == NodePosition.Before)
			{
				if(key == 1)
				{
					Insert(data, NodePosition.Tail);
					return;
				}
				node = head;
				for(int i = 1, j = key - 1; i != j; i++)
				{
					node = node.next;
				}
				node.next = new Node(data, node.next);
				numOfNodes++;
				#if DEBUG
				WriteLine($"Inserted {data} before node {key}");
				#endif
			}
			else if(position == NodePosition.After)
			{
				node = head;
				for(int i = 1; i != key; i++)
				{
					node = node.next;
				}
				node.next = new Node(data, node.next);
				numOfNodes++;
				#if DEBUG
				WriteLine($"Inserted {data} after node {key}");
				#endif
			}
			else if(position == NodePosition.Head)
			{
				Insert(data, NodePosition.Head);
			}
			else
			{
				Insert(data, NodePosition.Tail);
			}
		}
	}
	public void Delete()
	{
		Delete(NodePosition.Head);
	}
	public virtual void Delete(NodePosition position)
	{
		if(position == NodePosition.Head)
		{
			if(head == null)
			{
				WriteLine("List empty");
			}
			else
			{
				head = (head).next;
				numOfNodes--;
				#if DEBUG
				WriteLine("Deleted first node");
				#endif
			}
		}
		else
		{
			if(head == null)
			{
				WriteLine("List empty");
			}
			else
			{
				node = head;
				while((node.next).next != null)
				{
					node = node.next;
				}
				node.next = null;
				numOfNodes--;
				#if DEBUG
				WriteLine("Deleted last node");
				#endif
			}
		}
	}
	public void Delete(int key)
	{
		if(numOfNodes == 0)
		{
			WriteLine("List is empty");
			return;
		}

		if(IsKeyValid(key))
		{
			if(key == 1 || key == (int)NodePosition.Head)
			{
				Delete(NodePosition.Head);
			}
			else if(key == numOfNodes || key == (int)NodePosition.Tail)
			{
				Delete(NodePosition.Tail);
			}
			else
			{
				node = head;
				for(int i = 1, j = key - 1; i != j; i++)
				{
					node = node.next;
				}
				node.next = (node.next).next;
				numOfNodes--;
				#if DEBUG
				WriteLine($"Deleted node {key}");
				#endif
			}
		}
	}
	public virtual void Traverse()
	{
		node = head;
		while(node != null)
		{
			Write($"{node.data} => ");
			node = node.next;
		}
		WriteLine("null");
		#if DEBUG
		WriteLine($"Total nodes = {numOfNodes}");
		#endif
	}
	public virtual int Search(int data)
	{
		if(head == null)
		{
			WriteLine("List is empty");
			return 0;
		}

		DataFound = new ArrayList();
		node = head;
		for(int key = 1; node != null; key++)
		{
			if(node.data == data)
			{
				DataFound.Add(key);
			}
			node = node.next;
		}
		#if DEBUG
		if(DataFound.Count > 0)
		{
			Write("Node ");
			foreach(int i in DataFound)
			{
				Write($"{i}, ");
			}
			WriteLine($"contain {data}");
		}
		else
		{
			WriteLine($"Could not find {data} in the list");
		}
		#endif
		return DataFound.Count;
	}
	public bool IsKeyValid(int key)
	{
		if(key == 0)
		{
			WriteLine("Cannot operate on head");
			return false;
		}
		else if(key < 0)
		{
			WriteLine($"Cannot operate on {key} node");
			return false;
		}
		else if(key > numOfNodes)
		{
			WriteLine($"Only {numOfNodes} nodes available");
			return false;
		}
		else
		{
			return true;
		}
	}
}
public class CircularLinkedList : LinkedList
{
	internal Node tail;
	public override void Insert(int data, int key)	//Insert at before node at key
	{
		if(IsKeyValid(key))
		{
			if(key == 1 || key == (int) NodePosition.Head || head == null)
			{
				Insert(data, NodePosition.Head);
			}
			else if(key == numOfNodes || key == (int) NodePosition.Tail)
			{
				Insert(data, NodePosition.Tail);
			}
			else	// This does not work when key == 1
			{
				node = head;
				for(int i = 1, j = key - 1; i < j; i++)
				{
					node = node.next;
				}
				newNode = new Node(data, node.next);
				node.next = newNode;
				numOfNodes++;
				#if DEBUG
				WriteLine($"Inserted {newNode.data} before node {key}\nTotal Nodes = {numOfNodes}");
				#endif
			}
		}
	}
	public override void Insert(int data, NodePosition position)
	{
		if(head == null)
		{
			head = new Node(data);
			tail = head;
			#if DEBUG
			WriteLine($"Inserted {data} in the beginning");
			#endif
		}
		else
		{
			if(position == NodePosition.Head)
			{
				head = new Node(data, head);
				tail.next = head;
				#if DEBUG
				WriteLine($"Inserted {data} in the beginning");
				#endif
			}
			else
			{
				node = new Node(data, head);
				tail.next = node;	// NullReferenceException
				tail = node;
				#if DEBUG
				WriteLine($"Inserted {data} at the end");
				#endif
			}
		}
		numOfNodes++;
	}
	public override void Insert(int data, NodePosition position, int key)
	{
		if(head == null)
		{
			Insert(data, NodePosition.Head);
		}

		if(IsKeyValid(key))
		{
			if(position == NodePosition.Before)
			{
				if(key == 1)
				{
					Insert(data, NodePosition.Tail);
					return;
				}
				node = head;
				for(int i = 1, j = key - 1; i < j; i++)
				{
					node = node.next;
				}
				node.next = new Node(data, node.next);
				numOfNodes++;
				#if DEBUG
				WriteLine($"Inserted {data} before node {key}");
				#endif
			}
			else if(position == NodePosition.After)
			{
				node = head;
				for(int i = 1; i != key; i++)
				{
					node = node.next;
				}
				node.next = new Node(data, node.next);
				if(key == numOfNodes)
				{
					tail = node.next;
				}
				numOfNodes++;
				#if DEBUG
				WriteLine($"Inserted {data} after node {key}");
				#endif
			}
			else if(position == NodePosition.Head)
			{
				Insert(data, NodePosition.Head);
			}
			else
			{
				Insert(data, NodePosition.Tail);
			}
		}
	}
	public override void Delete(NodePosition position)
	{
		if(numOfNodes == 0)
		{
			WriteLine("List is empty");
			return;
		}
		if(position == NodePosition.Head)
		{
			head = head.next;
			tail.next = head;
			numOfNodes--;
			GC.Collect();
			#if DEBUG
			WriteLine("Deleted First node");
			#endif
		}
		else if(position == NodePosition.Tail)
		{
			node = head;
			while(node.next != tail)
			{
				node = node.next;
			}
			node.next = head;
			tail = node;
			numOfNodes--;
			#if DEBUG
			WriteLine("Deleted tail node");
			#endif
		}
	}
	public override void Traverse()
	{
		if(head == null)
		{
			WriteLine("List empty");
			return;
		}
		node = head;
		do
		{
			Write($"{node.data} => ");
			node = node.next;
		}
		while(node != head);
		WriteLine($"Back to {head.data}");
		#if DEBUG
		WriteLine($"Total Nodes = {numOfNodes}");
		#endif
	}
	public override int Search(int data)
	{
		if(head == null)
		{
			WriteLine("List is empty");
			return 0;
		}

		DataFound = new ArrayList();
		node = head;
		int key = 1;
		do
		{
			if(node.data == data)
			{
				DataFound.Add(key);
			}
			key++;
			node = node.next;
		}
		while(node != head);
		#if DEBUG
		if(DataFound.Count > 0)
		{
			Write("Nodes ");
			foreach(int i in DataFound)
			{
				Write($"{i}, ");
			}
			WriteLine($"contains {data}");
		}
		else
		{
			WriteLine($"Could not find {data} in the list");
		}
		#endif
		return DataFound.Count;
	}
}
internal class Node
{
	public int data;
	public Node next;
	public Node()
	{

	}
	public Node(int data)
	{
		this.data = data;
		next = null;
	}
	public Node(int d, Node node)
	{
		data = d;
		next = node;
	}
	#if DEBUG
	~Node()
	{
		WriteLine("Node destructor called");
	}
	#endif
}
}

namespace DoublyLinkedList
{
enum NodePosition
{
	Head = 1,
	Tail = -1
}
enum TraverseDirection
{
	FrontToBack,
	BackToFront
}
class LinkedList
{
	protected int numOfNodes;
	protected ArrayList DataFound;
	protected Node head, tail, node;

	public LinkedList()
	{
		head = null;
	}
	~LinkedList()
	{
		#if DEBUG
		WriteLine("LinkedList destructor called");
		#endif
	}
	public virtual void Insert(int data)
	{
		if(head == null)
		{
			head = new Node(data);
			tail = head;
		}
		else
		{
			node = new Node(data, head);
			head.previous = node;
			head = node;
		}
		numOfNodes++;
		#if DEBUG
		WriteLine($"Inserted {data} in the beginning");
		#endif
	}
	public virtual void Insert(int data, NodePosition position)
	{
		if(position == NodePosition.Head)
		{
			Insert(data);
			return;
		}
		else // Last
		{
			node = tail;
			tail = new Node(node, data, null);
			node.next = tail;
			numOfNodes++;
			#if DEBUG
			WriteLine($"Inserted {data} in the end");
			#endif
		}
	}
	
	public void Insert(int data, int key)
	{
		if(IsKeyValid(key))	
		{
			node = head;

			for(int i = 1; i != key; i++)
			{
				node = node.next;
			}
			node = new Node(node.previous, data, node);
			node.previous.next = node;
			node.next.previous = node;
			numOfNodes++;
			#if DEBUG
			WriteLine($"Inserted {data} at {key}");
			#endif
		}
	}
	public virtual void Delete()
	{
		Delete(NodePosition.Head);
	}
	public virtual void Delete(NodePosition position)
	{
		if(head == null)
		{
			WriteLine("List is empty");
			return;
		}
		if(position == NodePosition.Head)
		{
			node = head;
			head = head.next;
			head.previous = null;
			node.next = null;
			node = null;
			#if DEBUG
			WriteLine($"Deleted head node");
			#endif
			}
		else // tail node
		{
			node = tail.previous;
			node.next = null;
			tail.previous = null;
			tail = node;
			#if DEBUG
			WriteLine($"Deleted tail node");
			#endif
		}
		numOfNodes--;
		GC.Collect();
	}
	public void Delete(int key)
	{
		if(head == null)
		{
			WriteLine("List is empty");
			return;
		}

		if(IsKeyValid(key))
		{
			if(key == 1)
			{
				Delete();
			}
			else
			{
				node = head;
				for(int i = 1; i != key; i++)
				{
					node = node.next;
				}
				(node.previous).next = node.next;
				node.next.previous = node.previous;
				node.previous = null;
				node.next = null;
				node = null;
				numOfNodes--;
				GC.Collect();
				#if DEBUG
				WriteLine($"Deleted node {key}");
				#endif
			}
		}
	}
	public virtual void Traverse(TraverseDirection direction)
	{
		if(head == null)
		{
			WriteLine("List is empty");
			return;
		}

		Write("null <=> ");

		if(direction == TraverseDirection.FrontToBack)
		{
			node = head;
			while(node != null)
			{
				Write($"{node.data} <=> ");
				node = node.next;
			}
		}
		else
		{
			node = tail;
			while(node != null)
			{
				Write($"{node.data} <=> ");
				node = node.previous;
			}
		}

		WriteLine("null");
		#if DEBUG
		WriteLine($"Total nodes = {numOfNodes}");
		#endif
	}
	public virtual void Traverse()
	{
		Traverse(TraverseDirection.FrontToBack);
	}
	protected bool IsKeyValid(int key)
	{
		if(key == 0)
		{
			WriteLine("Cannot operate head node");
			return false;
		}
		else if(key > numOfNodes)
		{
			WriteLine($"Only {numOfNodes} nodes available");
			return false;
		}
		else if(key < 0)
		{
			WriteLine($"Cannot operate on {key} node");
			return false;
		}
		else
		{
			return true;
		}
	}
	public virtual int Search(int data) // if found, returns the key of the searched data else returns zero
	{
		DataFound = new ArrayList();
		node = head;
		for(int key = 1; node != null; key++)
		{
			if(node.data == data)
			{
				DataFound.Add(key);
			}
			node = node.next;
		}
		#if DEBUG
		if(DataFound.Count > 0)
		{
			Write($"{data} found at node ");
			foreach(int i in DataFound)
			{
				Write($"{i}, ");
			}
			WriteLine();
		}
		else
		{
			WriteLine($"{data} not found");
		}
		#endif
		return DataFound.Count;
	}
	public int GetNodesNumber => numOfNodes;
}	// LinkedList class end

class CircularLinkedList : LinkedList
{
	public CircularLinkedList()
	{
		head = null;
	}
	~CircularLinkedList()
	{
		#if DEBUG
		WriteLine("CircularLinkedList destructor called");
		#endif
	}
	public override void Insert(int data)
	{
		Insert(data, NodePosition.Head);
	}
	public override void Insert(int data, NodePosition position)
	{
		if(head == null)
		{
			head = new Node(data);
			tail = head;
			#if DEBUG
			WriteLine($"Inserted node with {data} at head");
			#endif
		}
		else if(position == NodePosition.Head)
		{
			node = head;
			head = new Node(tail, data, node);
			node.previous = head;
			tail.next = head;
			#if DEBUG
			WriteLine($"Inserted node with {data} at head");
			#endif
		}
		else // Last
		{
			node = new Node(tail, data, head);
			tail.next = node;
			head.previous = node;
			tail = node;
			#if DEBUG
			WriteLine($"Inserted node with {data} at tail");
			#endif
		}
		numOfNodes++;
	}
	public override void Delete()
	{
		Delete(NodePosition.Head);
	}
	public override void Delete(NodePosition position)
	{
		if(head == null)
		{
			WriteLine("List is empty");
			return;
		}
		if(position == NodePosition.Head)
		{
			node = head;
			head = head.next;
			#if DEBUG
			WriteLine("Deleted head node");
			#endif
		}
		else
		{
			node = tail;
			tail = tail.previous;
			#if DEBUG
			WriteLine("Deleted tail node");
			#endif
		}
		head.previous = tail;
		tail.next = head;
		node.next = null;
		node.previous = null;
		numOfNodes--;
		GC.Collect();
	}
	public override void Traverse()
	{
		Traverse(TraverseDirection.FrontToBack);
	}
	public override void Traverse(TraverseDirection direction)
	{
		if(head == null)
		{
			WriteLine("Empty List");
			return;
		}

		if(direction == TraverseDirection.FrontToBack)
		{
			node = head;
			do
			{
				Write($"{node.data} => ");
				node = node.next;
			}
			while(node != head);
			WriteLine($"Back to {head.data}");
		}
		else
		{
			node = tail;
			do
			{
				Write($"{node.data} => ");
				node = node.previous;
			}
			while(node != tail);
			WriteLine($"Back to {tail.data}");
		}
		#if DEBUG
		WriteLine($"Total nodes = {numOfNodes}");
		#endif
	}
	public override int Search(int data)
	{
		DataFound = new ArrayList();
		node = head;
		int key = 1;
		do
		{
			if(node.data == data)
			{
				DataFound.Add(key);
			}
			node = node.next;
			key++;
		}
		while(node != head);
		#if DEBUG
		if(DataFound.Count > 0)
		{
			Write($"{data} found at node ");
			foreach(int i in DataFound)
			{
				Write($"{i}, ");
			}
			WriteLine();
		}
		#endif
		return DataFound.Count;
	}
}	// CircularLinkedList class end
class Node
{
	internal int data;
	public Node next, previous;
	public Node(int data)
	{
		this.data = data;
		previous = null;
		next = null;
	}
	public Node(int data, Node next)
	{
		previous = null;
		this.data = data;
		this.next = next;
	}
	public Node(Node previous, int data, Node next)
	{
		this.data = data;
		this.previous = previous;
		this.next = next;
	}
	~Node()
	{
		#if DEBUG
		WriteLine("Node Destructor called");
		#endif
	}
}
}	// DoublyLinkedList namespace end
