/// <summary>
/// Problem solution for http://codeforces.com/problemset/problem/670/B
/// </summary>
#include <iostream>
#include <vector>

using namespace std;

int main()
{
	int n, k, tmp;
	cin >> n >> k;

	vector<int> identifiers;
	for (int i = 0; i < n; i++)
	{
		cin >> tmp;
		identifiers.push_back(tmp);
	}

	for (int i = 1; i <= n; i++)
	{
		if (k <= i)
			break;
		k -= i;
	}

	cout << identifiers[k - 1] << endl;

	return 0;
}