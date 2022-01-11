#include "Stack.hpp"

#ifndef DEBUG
#define DEBUG
#endif

using namespace std;
using namespace StackADT;

Stack::Stack(){
	top = -1;
	stackDataPtr = new int *[MAX_STACK_ARRAY_SIZE];
	stackData = new int[MAX_STACK_ARRAY_SIZE];
	stackSize = MAX_STACK_ARRAY_SIZE;
	setStackNull();
}
Stack::Stack(int stackSize){
	top = -1;
	stackDataPtr = new int *[stackSize];
	stackData = new int[stackSize];
	this->stackSize = stackSize;

	setStackNull();
}
void Stack::Push(int item){
	if(top >= (stackSize - 1)){
		cout << "Stack Overflow" << endl;
	}
	else{
		stackData[++top] = item;
		stackDataPtr[top] = stackData + top;
		cout << "Pushed " << item << " to stack." << endl;
	}
}
int* Stack::Pop(){
	if(top < 0){
		cout << "Stack Underflow" << endl;
		return nullptr;
	}
	else{
		poppedItem = stackData[top];
		stackDataPtr[top] = nullptr;
		top--;
		return &poppedItem;
	}
}
void Stack::ShowStack(){
	if(top < 0){
		cout << "Stack empty" << endl;
		return;
	}
	else{
		for(int i = 0; i < stackSize && stackDataPtr[i] != nullptr; i++){
			cout << "[" << i << "] = " << stackData[i] << ", ";
		}
		cout << endl;
	}
}
void Stack::setStackNull(){
	for(int i = 0; i < stackSize; i++){
		stackDataPtr[i] = nullptr;
	}
}
InfixExpression::InfixExpression(){
	expression = nullptr;
	stringLength = 0;
	operation = nullptr;
}
InfixExpression::InfixExpression(char* expression){
	if(IsExpressionValid(expression)){
		this->expression = expression;
		operation = new Stack(stringLength);
		cout << expression << " is valid" << endl;
	}
	else{
		cout << expression << " is not a valid expression" << endl;
	}
}
InfixExpression::~InfixExpression(){
	delete expression;
	delete operation;
	expression = nullptr;
	operation = nullptr;
	#ifdef DEBUG
	cout << "~InfixExpression() called" << endl;
	#endif
}
bool InfixExpression::IsExpressionValid(char *exp){
	stringLength = (sizeof(exp) / sizeof(exp[0])) - 1;
	for(int i = 0, j = stringLength - 1; i < j; i++){
		/* If exp[i] is not any of these characters, 
		then exp is not valid expression */
		if( !(
			(exp[i] >= 'A' && exp[i] <= 'Z') ||
			(exp[i] >= 'a' && exp[i] <= 'z') ||
			exp[i] == '+' || exp[i] == '-' ||
			exp[i] == '*' || exp[i] == '/' ||
			exp[i] == '%' || exp[i] == '^' ||
			exp[i] == '(' || exp[i] == ')' ||
			exp[i] == ' '
			) 
		){
			return false;
		}
	}
	return true;
}

// char* InfixExpression::ToPostfixExpression(){

// }
// char* InfixExpression::ToPostfixExpression(char *expression){

// }
// char* InfixExpression::ToPrefixExpression(char *expression){

// }
// char* InfixExpression::ToInfixExpression(ExpressionType expression){

// }