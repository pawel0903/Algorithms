/// <summary>
/// Problem solution for http://codeforces.com/problemset/problem/652/B
/// </summary>
#include <iostream>
#include <algorithm>

using namespace std;

int main()
{
	int n, tmp;
	int arr[1000];
	cin >> n;

	for (int i = 0; i<n; i++) {
		cin >> tmp;
		arr[i] = tmp;
	}

	sort(arr, arr + n);

	for (int i = 1; i < n; i++) {
		if (i % 2 == 1) {
			if (arr[i - 1] > arr[i]) {
				swap(arr[i - 1], arr[i]);
			}
		}
		else {
			if (arr[i - 1] < arr[i]) {
				swap(arr[i - 1], arr[i]);
			}
		}
	}

	for (int i = 0; i < n; i++) {
		cout << arr[i] << " ";
	}

	return 0;
}