/// <summary>
/// Problem: Given an array, print the Next Greater Element for every element
/// Time complexity: O(n)
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

void findNextGreaterElement(int arr[], int n) {
	stack<int> stack;

	for (int i = 0; i<n; i++) {
		if (!stack.empty()) {
			int element = pop(stack);

			while (element < arr[i]) {
				cout << element << " -> " << arr[i] << endl;
				if (stack.empty())
					break;
				element = pop(stack);
			}

			if (element >= arr[i])
				stack.push(element);
		}

		stack.push(arr[i]);
	}

	while (!stack.empty()) {
		cout << pop(stack) << " -> " << -1 << endl;
	}

}

void printArray(int arr[], int n)
{
	cout << "array:";
	for (int i = 0;i < n;i++)
	{
		cout << " " << arr[i];
	}
	cout << endl;
}

void test1()
{
	int arr[] = { 11, 13, 21, 3, 50 };
	printArray(arr, 5);
	findNextGreaterElement(arr, 5);
}

int main()
{
	test1();

	system("PAUSE");
	return 0;
}
