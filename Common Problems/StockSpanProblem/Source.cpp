/// <summary>
/// Problem solution for stock span problem
/// Time complexity: O(n)
/// </summary>
#include <iostream>
#include <stack>
#include <assert.h>

using namespace std;

int pop(stack<int>& stack) {
	int result = stack.top();
	stack.pop();
	return result;
}

void printResult(int arr[], int n) {
	for (int i = 0; i < n; i++) {
		cout << "s[" << i << "] = " << arr[i] << endl;
	}
}

int* computeSpan(int arr[], int n) {
	stack<int> stack;
	int* result = new int[n];

	for (int i = n - 1; i >= 0; i--) {
		if (!stack.empty()) {
			int element = pop(stack);

			while (arr[element] < arr[i]) {
				result[element] = element - i;
				if (stack.empty())
					break;
				element = pop(stack);
			}

			if (arr[element] >= arr[i])
				stack.push(element);
		}

		stack.push(i);
	}

	while (!stack.empty()) {
		int element = pop(stack);
		result[element] = 1;
	}


	return result;
}

void test()
{
	int n = 7;
	int input[] = { 100, 80, 60, 70, 60, 75, 85 };
	int expectedOutput[] = { 1, 1, 1, 2, 1, 4, 6 };

	int* output = computeSpan(input, n);

	printResult(output, n);

	for (int i = 0; i < n; i++)
	{
		assert(output[i] == expectedOutput[i]);
	}
}

int main()
{
	printf("testing...\n");
	test();
	printf("all tests passed\n");

	system("PAUSE");
	return 0;
}
