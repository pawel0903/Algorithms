/// <summary>
/// Problem: Check for balanced parentheses in an expression
/// </summary>
#include <iostream>
#include <string>
#include <stack>
#include <assert.h>

using namespace std;

int getBracketType(char& c) {
	switch (c) {
	case '{':
	case '}':
		return 3;

	case '[':
	case ']':
		return 2;

	case '(':
	case ')':
		return 1;
	}

	return -1;
}

bool areValid(char& b1, char& b2) {
	return b1 != b2 && getBracketType(b1) == getBracketType(b2);
}

bool isLeftBracker(char& c) {
	return c == '{' || c == '[' || c == '(';
}

bool isRightBracker(char& c) {
	return c == '}' || c == ']' || c == ')';
}

bool evaluate(string exp)
{
	stack<char> brackets;
	for (int i = 0; i<exp.length(); i++) {
		char c = exp[i];

		if (isLeftBracker(c)) {
			brackets.push(c);
		}
		else if (isRightBracker(c)) {
			if (brackets.empty() || !areValid(c, brackets.top()))
				return false;
			else
				brackets.pop();
		}
	}

	return brackets.empty();
}

void testHelper(string exp, bool expetcedResult)
{
	bool result = evaluate(exp);
	cout << exp << ", expected: " << std::boolalpha << expetcedResult << ", output: " << result << endl;
	assert(result == expetcedResult);
}

void test()
{
	testHelper("[()]{}{[()()]()}", true);
	testHelper("[(])", false);
	testHelper("[(a+b)]", true);
}

int main()
{
	printf("testing...\n");
	test();
	printf("all tests passed\n");

	getchar();
	return 0;
}

