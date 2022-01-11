#include "DoublyLinkedList.hpp"

#ifndef DEBUG
#define DEBUG
#endif

using namespace DLinkedList;

Node::Node(int data){
	this->data = data;
	previous = nullptr;
	next = nullptr;
}
Node::Node(int data, Node *next){
	previous = nullptr;
	this->data = data;
	this->next = next;
}
Node::Node(Node *previous, int data, Node *next){
	this->previous = previous;
	this->data = data;
	this->next = next;
}

DoublyLinkedList::DoublyLinkedList(){
	head = nullptr;
	numOfNodes = 0;
}
DoublyLinkedList::~DoublyLinkedList(){
	nodePtr = head;
	while(nodePtr != nullptr){
		head = nodePtr->next;
		delete nodePtr;
		nodePtr = head;
	}
	#ifdef DEBUG
	std::cout << "DoublyLinkedList destructor called" << std::endl;
	#endif
}
void DoublyLinkedList::Insert(int data){
	Insert(data, HeadPosition);
}
void DoublyLinkedList::Insert(int data, int key){
	if(IsKeyValid(key)){
		if(key == 1 || key == (int) HeadPosition){
			Insert(data, HeadPosition);
		}
		else if(key == numOfNodes || key == (int) TailPosition){
			Insert(data, TailPosition);
		}
		else{
			nodePtr = head;
			for(int i = 1; i != key; i++){
				nodePtr = nodePtr->next;
			}
			Node *newNode = new Node(nodePtr->previous, data, nodePtr);
			nodePtr->previous->next = newNode;
			nodePtr->previous = newNode;
			numOfNodes++;
			#ifdef DEBUG
			std::cout << "Inserted " << data << " at " << key << std::endl;
			#endif
		}
	}
}
void DoublyLinkedList::Insert(int data, NodePosition position){
	if(position == HeadPosition){
		if(head == nullptr){
			head = new Node(data, nullptr);
			tail = head;
		}
		else{
			nodePtr = new Node(nullptr, data, head);
			head->previous = nodePtr;
			head = nodePtr;
		}
		#ifdef DEBUG
		std::cout << "Inserted " << data << " at the beginning" << std::endl;
		#endif
	}
	else{
		if(head == nullptr){
			Insert(data, HeadPosition);
			return;
		}
		else{
			nodePtr = tail;
			tail = new Node(nodePtr, data, nullptr);
			nodePtr->next = tail;
		}
		#ifdef DEBUG
		std::cout << "Inserted " << data << " at the end" << std::endl;
		#endif
	}
	numOfNodes++;
}
void DoublyLinkedList::Delete(){
	Delete(HeadPosition);
}
void DoublyLinkedList::Delete(int key){
	CHECK_LIST_EMPTY()

	if(IsKeyValid(key)){
		if(key == (int) HeadPosition || key == 1){
			Delete(HeadPosition);
			return;
		}
		else if(key == (int) TailPosition || key == numOfNodes){
			Delete(TailPosition);
			return;
		}
		else{
			nodePtr = head;
			for(int i = 1; i != key; i++){
				nodePtr = nodePtr->next;
			}
			nodePtr->previous->next = nodePtr->next;
			nodePtr->next->previous = nodePtr->previous;
			#ifdef DEBUG
			std::cout << "Deleted node at key " << key << std::endl;
			#endif
		}
		delete nodePtr;
		numOfNodes--;
	}
	
}
void DoublyLinkedList::Delete(NodePosition position){
	CHECK_LIST_EMPTY()

	if(position == HeadPosition){
		nodePtr = head;
		head = head->next;
		head->previous = nullptr;
		#ifdef DEBUG
		std::cout << "Deleted head node" << std::endl;
		#endif
	}
	else{
		nodePtr = tail;
		tail = tail->previous;
		tail->next = nullptr;
		#ifdef DEBUG
		std::cout << "Deleted tail Node" << std::endl;
		#endif
	}
	numOfNodes--;
}
void DoublyLinkedList::Traverse(){
	Traverse(HeadToTail);
}
void DoublyLinkedList::Traverse(TraverseDirection direction){
	CHECK_LIST_EMPTY()

	if(direction == HeadToTail){
		std::cout << "Transversing: head to tail" << std::endl;
	}
	else{
		std::cout << "Transversing: tail to head" << std::endl;
	}
	std::cout << "null <=> ";
	if(direction == HeadToTail){
		nodePtr = head;
		while(nodePtr != nullptr){
			std::cout << nodePtr->data << " <=> ";
			nodePtr = nodePtr->next;
		}
	}
	else{
		nodePtr = tail;
		while(nodePtr != nullptr){
			std::cout << nodePtr->data << " <=> ";
			nodePtr = nodePtr->previous;
		}
	}
	std::cout << "null" << std::endl;
	#ifdef DEBUG
	std::cout << "Total nodes = " << numOfNodes << std::endl;
	#endif
}
int DoublyLinkedList::Search(int data){
	int key = 1;
	nodePtr = head;
	dataFound = new SinglyLinkedList::LinkedList();
	while(nodePtr != nullptr)
	{
		if(nodePtr->data == data){
			dataFound->Insert(key);
		}
		nodePtr = nodePtr->next;
		key++;
	}
	#ifdef DEBUG
	if(dataFound == nullptr){
		std::cout << data << " not found in the list" << std::endl;
	}
	else{
		std::cout << data << " found at node " << std::endl;
		dataFound->Traverse();
	}
	#endif
	
	return dataFound->GetNodeCount();
}
bool DoublyLinkedList::IsKeyValid(int key){
	if(key == TailPosition){
		return true;
	}
	else if(key == HeadPosition){
		return true;
	}
	else if(key < 0){
		std::cout << "Cannot operate on node " << key << std::endl;
		return false;
	}
	else if(key == 0){
		std::cout << "Cannot operate head" << std::endl;
		return false;
	}
	else if(key > numOfNodes){
		std::cout << "Only " << numOfNodes << " available" << std::endl;
		return false;
	}
	else{
		return true;
	}
}
int DoublyLinkedList::GetNumOfNodes(){
	return numOfNodes;
}

CircularLinkedList::CircularLinkedList(){
	head = nullptr;
	tail = nullptr;
	numOfNodes = 0;
}
CircularLinkedList::~CircularLinkedList(){
	CHECK_LIST_EMPTY()

	nodePtr = head;
	while(head != tail){
		head = nodePtr->next;
		delete nodePtr;
		nodePtr = head;
	}
	delete tail;
	nodePtr = nullptr;
	head = nullptr;
	tail = nullptr;
	#ifdef DEBUG
	std::cout << "CircularLinkedList destructor called" << std::endl;
	#endif
}
void CircularLinkedList::Insert(int data, NodePosition position){
	if(position == HeadPosition){
		if(head == nullptr){
			head = new Node(data);
			tail = head;
		}
		else{
			nodePtr = new Node(tail, data, head);
			nodePtr->next = head;
			nodePtr->previous = tail;
			head->previous = nodePtr;
			head = nodePtr;
			tail->next = head;
		}
		#ifdef DEBUG
		std::cout << "Inserted " << data << " in the beginning" << std::endl;
		#endif
	}
	else{
		if(head == nullptr){
			Insert(data, HeadPosition);
			return;
		}
		nodePtr = tail;
		tail = new Node(tail, data, head);
		nodePtr->next = tail;
		head->previous = tail;
		#ifdef DEBUG
		std::cout << "Inserted " << data << " in the end" << std::endl;
		#endif
	}
	numOfNodes++;
}
void CircularLinkedList::Traverse(TraverseDirection direction){
	CHECK_LIST_EMPTY()

	if(direction == HeadToTail){
		std::cout << "Traversing Head to Tail Node" << std::endl;
		nodePtr = head;
		do{
			std::cout << nodePtr->data << " <=> ";
			nodePtr = nodePtr->next;
		}
		while(nodePtr != head);
		std::cout << "Back to " << head->data << std::endl;
	}
	else{
		std::cout << "Traversing Tail to Head Node" << std::endl;
		nodePtr = tail;
		do{
			std::cout << nodePtr->data << " <=> ";
			nodePtr = nodePtr->previous;
		}
		while(nodePtr != tail);
		std::cout << "Back to " << tail->data << std::endl;
	}
	#ifdef DEBUG
	std::cout << "Total nodes = " << numOfNodes << std::endl;
	#endif
}
void CircularLinkedList::Delete(NodePosition position){
	CHECK_LIST_EMPTY()

	if(position == HeadPosition){
		nodePtr = head;
		head = head->next;
		head->previous = tail;
		tail->next = head;
		#ifdef DEBUG
		std::cout << "Deleted head node" << std::endl;
		#endif
	}
	else{
		nodePtr = tail;
		tail = tail->previous;
		tail->next = head;
		head->previous = tail;
		#ifdef DEBUG
		std::cout << "Deleted tail node" << std::endl;
		#endif
	}
	delete nodePtr;
	nodePtr = nullptr;
	numOfNodes--;
}
int CircularLinkedList::Search(int data){
	CHECK_LIST_EMPTY(0)

	nodePtr = head;
	dataFound = new SinglyLinkedList::LinkedList();
	int key = 1;
	do{
		if(nodePtr->data == data){
			dataFound->Insert(key);
		}
		nodePtr = nodePtr->next;
		key++;
	}
	while(nodePtr != head);
	#ifdef DEBUG
	if(dataFound->GetNodeCount() == 0){
		std::cout << data << " not found in the list" << std::endl;
	}
	else{
		std::cout << data << " found" << std::endl;
		dataFound->Traverse();
	}
	#endif

	return dataFound->GetNodeCount();
}