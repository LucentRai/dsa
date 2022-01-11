#include <iostream>
#define CHECK_LIST_EMPTY(x) if(head == nullptr){	\
							std::cout << "List is empty" << std::endl;	\
							return x;	\
						}

enum NodePosition{
	HeadPosition = 1,
	TailPosition = -1
};
namespace SinglyLinkedList{
class Node{
	public:
		int data;
		Node *next;

		Node();
		Node(int data);
		Node(Node *nextPtr);
		Node(int item, Node *nextPtr);
};

class LinkedList{
	protected:
		Node *head, *nodePtr;
		int numOfNodes;
		LinkedList *dataFound;	// This list will contain all the nodes where Search() has found data

	public:
		LinkedList();
		~LinkedList();
		void Insert(int data);	// Insertion at the beginning
		virtual void Insert(int data, NodePosition position);
		void Insert(int data, int key);
		virtual void Delete();	// Delete head node
		void Delete(NodePosition position);
		void Delete(int key);
		virtual void Traverse();
		virtual int Search(int data);
		bool IsKeyValid(int key);
		int GetNodeCount();
};

class CircularLinkedList : public LinkedList{
	private:
		Node *tail;

	public:
		CircularLinkedList();
		~CircularLinkedList();
		using LinkedList::Insert;
		using LinkedList::Delete;
		void Insert(int data, NodePosition position);
		void Traverse();
		void Delete();
		int Search(int data);
};
}