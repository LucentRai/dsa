#include <iostream>
#include "SinglyLinkedList.hpp"

#ifndef DEBUG
#define DEBUG
#endif

namespace SinglyLinkedList{

Node::Node(){
	next = nullptr;
}
Node::Node(int data){
	this->data = data;
	next = nullptr;
}
Node::Node(Node *nextPtr){
	next = nextPtr;
}
Node::Node(int data, Node *nextPtr){
	this->data = data;
	next = nextPtr;
}

LinkedList::LinkedList(){
	head = nullptr;
	dataFound = nullptr;
	numOfNodes = 0;
}
LinkedList::~LinkedList(){
	while(head != nullptr){
		nodePtr = head;
		head = head->next;
		delete nodePtr;
	}
	head = nullptr;
	if(dataFound != nullptr){
		nodePtr = dataFound->head;
		while(nodePtr != nullptr){
			head = nodePtr->next;
			delete nodePtr;
			nodePtr = head;
		}
		#ifdef DEBUG
		std::cout << "Searched data deleted" << std::endl;
		#endif
	}
	nodePtr = nullptr;
	#ifdef DEBUG
	std::cout << "Linked list deleted" << std::endl;
	#endif
}
void LinkedList::Insert(int data){
	Insert(data, HeadPosition);
}
void LinkedList::Insert(int data, NodePosition position){
	if(position == HeadPosition){
		if(head == nullptr){
			head = new Node(data, nullptr);
		}
		else{
			nodePtr = head;
			head = new Node(data, nodePtr);
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
		else{
			nodePtr = head;
			while(nodePtr->next != nullptr){
				nodePtr = nodePtr->next;
			}
			nodePtr->next = new Node(data, nullptr);
			#ifdef DEBUG
			std::cout << "Inserted " << data << " at the end" << std::endl;
			#endif
		}
	}
	numOfNodes++;
}
void LinkedList::Insert(int data, int key){
	if(key == HeadPosition || key == 1){
		Insert(data, HeadPosition);
	}
	else if(key == TailPosition || key == numOfNodes){
		Insert(data, TailPosition);
	}
	else if(IsKeyValid(key)){
		nodePtr = head;
		for(int i = 2; i < key; i++){
			nodePtr = nodePtr->next;
		}
		nodePtr->next = new Node(data, nodePtr->next);
		#ifdef DEBUG
		std::cout << "Inserted " << data << " at " << key << std::endl;
		#endif
		numOfNodes++;
	}
}
void LinkedList::Delete(){
	Delete(HeadPosition);
}
void LinkedList::Delete(NodePosition position){
	CHECK_LIST_EMPTY()

	nodePtr = head;
	if(position == HeadPosition){
		head = head->next;
		delete nodePtr;
		nodePtr = nullptr;
		#ifdef DEBUG
		std::cout << "Deleted head node" << std::endl;
		#endif
	}
	else{
		if(numOfNodes == 1){
			Delete(HeadPosition);
			return;
		}
		else{
			while(nodePtr->next->next != nullptr){
				nodePtr = nodePtr->next;
			}
			delete nodePtr->next;
			nodePtr->next = nullptr;
			#ifdef DEBUG
			std::cout << "Deleted tail node" << std::endl;
			#endif
		}
	}
	numOfNodes--;
}
void LinkedList::Delete(int key){
	CHECK_LIST_EMPTY()

	if(key == HeadPosition){
		Delete(HeadPosition);
	}
	else if(key == TailPosition){
		Delete(TailPosition);
	}
	else if(IsKeyValid(key)){
		nodePtr = head;
		Node *nodeToDelete;

		for(int i = 2; i < key; i++){
			nodePtr = nodePtr->next;
		}
		nodeToDelete = nodePtr->next;
		nodePtr->next = nodeToDelete->next;
		delete nodeToDelete;
		nodeToDelete = nullptr;
		numOfNodes--;
		#ifdef DEBUG
		std::cout << "Deleted node at key " << key << std::endl;
		#endif
	}
}
void LinkedList::Traverse(){
	CHECK_LIST_EMPTY()

	nodePtr = head;
	while(nodePtr != nullptr){
		std::cout << nodePtr->data << " => ";
		nodePtr = nodePtr->next;
	}
	std::cout << "null" << std::endl;
	#ifdef DEBUG
	std::cout << "Total nodes = " << numOfNodes << std::endl;
	#endif
}
int LinkedList::Search(int data){
	dataFound = new LinkedList();
	#ifdef DEBUG
	std::cout << std::endl << "New LinkedList created to store searched data" << std::endl;
	#endif
	nodePtr = head;
	for(int key = 1; nodePtr != nullptr; key++){
		if(nodePtr->data == data){
			dataFound->Insert(key);
		}
		nodePtr = nodePtr->next;
	}
	#ifdef DEBUG
	if(dataFound->GetNodeCount() > 0){
		std::cout << data << " found at ";
		dataFound->Traverse();
	}
	else{
		std::cout << data << " not found in the list" << std::endl;
	}
	#endif
	return dataFound->GetNodeCount();
}
bool LinkedList::IsKeyValid(int key){
	if(key == 0){
		std::cout << "Cannot operate in head" << std::endl;
		return false;
	}
	else if(key > numOfNodes){
		std::cout << "Only " << numOfNodes << " nodes available" << std::endl;
		Traverse();
		return false;
	}
	else if(key < 0){
		std::cout << "Invalid key" << std::endl;
		return false;
	}
	else{
		return true;
	}
}
int LinkedList::GetNodeCount(){
	return numOfNodes;
}

CircularLinkedList::CircularLinkedList(){
	head = nullptr;
	numOfNodes = 0;
}
CircularLinkedList::~CircularLinkedList(){
	if(numOfNodes != 0){
		nodePtr = head;
		while(nodePtr != tail){
			head = head->next;
			delete nodePtr;
			nodePtr = head;
		}
		delete nodePtr;
		head = nullptr;
		nodePtr = nullptr;
		tail = nullptr;
		#ifdef DEBUG
		std::cout << "Circular Linked List deleted" << std::endl;
		#endif
	}
}
void CircularLinkedList::Insert(int data, NodePosition position){
	if(position == HeadPosition){
		if(head == nullptr){
			head = new Node(data);
			tail = head;
		}
		else{
			head = new Node(data, head);
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
		nodePtr = new Node(data, head);
		tail->next = nodePtr;
		tail = nodePtr;
		#ifdef DEBUG
		std::cout << "Inserted " << data << " in the end" << std::endl;
		#endif
	}
	numOfNodes++;
}
void CircularLinkedList::Delete(){
	CHECK_LIST_EMPTY()

	nodePtr = head->next;
	tail->next = nodePtr;
	head->next = nullptr;
	delete head;
	head = nodePtr;
	numOfNodes--;
	#ifdef DEBUG
	std::cout << "Deleted head node" << std::endl;
	#endif
}
void CircularLinkedList::Traverse(){
	CHECK_LIST_EMPTY()
	nodePtr = head;
	do{
		std::cout << nodePtr->data << " => ";
		nodePtr = nodePtr->next;
	}
	while(nodePtr != head);
	std::cout << "Back to " << head->data << std::endl;
	#ifdef DEBUG
	std::cout << "Total Nodes = " << numOfNodes << std::endl;
	#endif
}
int CircularLinkedList::Search(int data){
	CHECK_LIST_EMPTY(0)

	dataFound = new LinkedList();
	nodePtr = head;
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
	if(dataFound->GetNodeCount() > 0){
		std::cout << data << " found at node" << std::endl;
		dataFound->Traverse();
	}
	else{
		std::cout << data << " not found in the list" << std::endl;
	}
	#endif

	return dataFound->GetNodeCount();
}
} // SinglyLinkedList namespace end