using System;
using DataStructure.Stack;

class Program
{
	public static void Main()
	{
		const int stackSize = 10;
		Stack stack = new Stack(stackSize);

		Console.WriteLine("This program demonstrates the concept of Stack Data Structure \n\n" +
							$"Stack size  = {stackSize}");

		stack.Pop();
		stack.Push(1);
		stack.Push(2);
		stack.Push(3);
		stack.Pop();
		stack.Push(3);
		stack.Push(4);
		stack.Push(5);
		stack.Push(6);
		stack.Push(7);
		stack.Push(8);
		stack.Push(9);
		stack.Push(10);
		stack.Push(11);
		stack.ShowStack();
		for(int i =0; i < 13; i++)
		{
			stack.Pop();
		}
		stack.ShowStack();
	}
}