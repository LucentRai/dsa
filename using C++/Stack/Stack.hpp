#include <iostream>
#define MAX_STACK_ARRAY_SIZE 10

namespace StackADT{
enum ExpressionType{
	Infix,
	Prefix,
	Postfix
};

class Stack{
	public:
		Stack();
		Stack(int stackSize);
		void Push(int item);
		int *Pop();
		void ShowStack();

	private:
		int stackSize, top, poppedItem;
		int **stackDataPtr, *stackData;
		void setStackNull();
};

class InfixExpression{
	public:
		InfixExpression();
		InfixExpression(char* expression);
		~InfixExpression();
		char* ToPostfixExpression();
		char* ToPostfixExpression(char *expression);
		char* ToPrefixExpression(char *expression);
		char* ToInfixExpression(ExpressionType expression);
	
	protected:
		int stringLength;
		char* expression;
		bool IsExpressionValid(char *exp);
		Stack *operation;
};
class PrefixExpression : public InfixExpression{
	public:
		PrefixExpression();
		PrefixExpression(char* expression);
		~PrefixExpression();
};
class PostfixExpression : public InfixExpression{
	public:
		PostfixExpression();
		PostfixExpression(char* expression);
		~PostfixExpression();
};
}