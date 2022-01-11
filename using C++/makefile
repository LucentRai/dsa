Program: Program.cpp DoublyLinkedList.cpp SinglyLinkedList.cpp
	g++ SinglyLinkedList.cpp -c
	g++ DoublyLinkedList.cpp -c
	g++ Program.cpp SinglyLinkedList.o DoublyLinkedList.o -o Program

DoublyLinkedList.o: SinglyLinkedList.cpp SinglyLinkedList.hpp DoublyLinkedList.cpp DoublyLinkedList.hpp
	g++ DoublyLinkedList.cpp -c

SinglyLinkedList.o: SinglyLinkedList.cpp SinglyLinkedList.hpp
	g++ SinglyLinkedList.cpp -c