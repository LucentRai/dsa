#include "SinglyLinkedList.hpp"

namespace DLinkedList{
	enum TraverseDirection{
		HeadToTail,
		TailToHead
	};
	class Node{
		public:
			int data;
			Node *next, *previous;

			Node(int data);
			Node(int data, Node *next);
			Node(Node *previous, int data, Node *next);
	};
	class DoublyLinkedList{
		protected:
			int numOfNodes;
			Node *head, *tail, *nodePtr;
			SinglyLinkedList::LinkedList *dataFound; // This list will contain all the nodes where Search() has found data
		
		public:
			DoublyLinkedList();
			~DoublyLinkedList();
			void Insert(int data);
			void Insert(int data, int key);
			virtual void Insert(int data, NodePosition position);
			void Delete(); // Delete First Node
			void Delete(int key);
			virtual void Delete(NodePosition position);
			void Traverse(); // Prints all nodes from head to tail
			virtual void Traverse(TraverseDirection direction);
			virtual int Search(int data);
			bool IsKeyValid(int key);
			int GetNumOfNodes();
	};
	class CircularLinkedList : public DoublyLinkedList{
		public:
			CircularLinkedList();
			~CircularLinkedList();
			using DoublyLinkedList::Insert;
			using DoublyLinkedList::Traverse;
			using DoublyLinkedList::Delete;
			void Insert(int data, NodePosition position);
			void Traverse(TraverseDirection direction);
			void Delete(NodePosition position);
			int Search(int data);
	};
}