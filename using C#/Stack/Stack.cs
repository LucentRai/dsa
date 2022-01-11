#define DEBUG
using System;

namespace DataStructure.Stack
{
	class Stack
	{
		public int? _poppedItem;
		private const int defaultArraySize = 10;
		private int _top;
		private int?[] _stackArray;
		public Stack()
		{
			_stackArray = new int?[defaultArraySize];
			_top = -1;
		}
		public Stack(int n)
		{
			_stackArray = new int?[n];
			_top = -1;
		}
		public void Push(int item)
		{
			if(_top >= _stackArray.Length - 1)
			{
				Console.WriteLine("Stack Overflow");
			}
			else{
				_top++;
				_stackArray[_top] = item;
				#if DEBUG
				Console.WriteLine($"pushed {item} to stack");
				#endif
			}
		}
		public int? Pop()
		{
			if(_top < 0)
			{
				Console.WriteLine("Stack Underflow");
				return null;
			}
			else
			{
				_poppedItem = _stackArray[_top];
				_stackArray[_top] = null;
				_top--;
				#if DEBUG
				Console.WriteLine($"Popped {_poppedItem} to stack");
				#endif
				return _poppedItem;
			}
		}
		public void ShowStack()
		{
			if(_stackArray.Length == 0)
			{
				Console.WriteLine("Stack empty");
				return;
			}
			for(int i = 0; i < _stackArray.Length; i++)
			{
				if(_stackArray[i] == null) break;
				Console.Write($"[{i}] = " + _stackArray[i] + ", ");
			}
			Console.Write("\n");
		}
	}
}