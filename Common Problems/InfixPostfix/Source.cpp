/// <summary>
/// Problem: 
/// 1) Convert infix to postfix notation
/// 2) Evaluate postfix notation
/// </summary>
#include <string>
#include <iostream>
#include <stack>
#include "math.h"
#include "assert.h"

using namespace std;

int isOperand(char c)
{
	return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9');
}

int precedenceOrder(char c)
{
	switch (c)
	{
	case '+':
	case '-':
		return 1;

	case '*':
	case '/':
		return 2;

	case '^':
		return 3;

	}
	return -1;
}

string infixToPostfix(string infix)
{
	stack<char> stack;
	string result = "";
	for (int i = 0; i < infix.length(); i++)
	{
		// checks if character is operand
		if (isOperand(infix[i]))
		{
			result += infix[i];
		}
		else
		{
			if (infix[i] == '(')
			{
				stack.push(infix[i]);
			}
			else if (infix[i] == ')')
			{
				while (!stack.empty() && stack.top() != '(')
				{
					result += stack.top();
					stack.pop();
				}
				if (stack.empty())
				{
					return "INVALID";
				}
				// pops '(' character
				stack.pop();
			}
			else
			{
				while (!stack.empty() && precedenceOrder(infix[i]) <= precedenceOrder(stack.top()))
				{
					result += stack.top();
					stack.pop();
				}
				stack.push(infix[i]);
			}
		}
	}

	while (!stack.empty())
	{
		result += stack.top();
		stack.pop();
	}

	return result;
}

double performAction(char operand, double a, double b)
{
	switch (operand)
	{
	case '+':
		return a + b;
	case '-':
		return a - b;

	case '*':
		return a*b;
	case '/':
		return a / b;

	case '^':
		return pow(a, b);
	}
}

double pop(stack<double>& stack)
{
	double result = stack.top();
	stack.pop();
	return result;
}

// evaluates postfix expression
// support numbers only
double evaluate(string postfix)
{
	stack<double> stack;
	for (int i = 0; i < postfix.length(); i++)
	{
		if (isOperand(postfix[i]))
		{
			double x = postfix[i] - '0';
			stack.push(x);
		}
		else
		{
			double first = pop(stack);
			double second = pop(stack);
			stack.push(performAction(postfix[i], second, first));
		}
	}

	return stack.top();
}

void infixToPostfixTestHelper(string infix, string expected)
{
	string postfix = infixToPostfix(infix);
	cout << "infix: " << infix << ", postfix: " << expected << ", result: " << postfix << endl;
	assert(postfix == expected);
}

void infixToPostfixTest()
{
	infixToPostfixTestHelper("3+4*2/(1-5)^2", "342*15-2^/+");
	infixToPostfixTestHelper("a+b*((c^d-e)^(f+g*h))-i", "abcd^e-fgh*+^*+i-");

	cout << "infixToPostfixTest passed," << endl;
}

void evaluateTest()
{
	assert(evaluate("231*+9-") == -4);
	assert(evaluate(infixToPostfix("3+4*2/(1-5)^2")) == 3.5);
	
	cout << "evaluateTest passed," << endl;
}

void test()
{
	infixToPostfixTest();
	evaluateTest();
	cout << "all tests passed." << endl;
}

int main()
{
	test();

	getchar();
	return 0;
}
