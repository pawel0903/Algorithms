/// <summary>
/// Problem solution for http://codeforces.com/problemset/problem/670/D2
/// </summary>
#include <iostream>
#include <vector>

using namespace std;

bool isValid(vector<long long> cookiesCost, vector<long long> ingredients, long long noOfCookies, long long magicPowder, int noOfElements)
{
	for (long long i = 0; i < noOfElements; i++)
	{
		if ((cookiesCost[i] * noOfCookies) > 0 && ingredients[i] / (cookiesCost[i] * noOfCookies) < 1)
		{
			magicPowder -= (cookiesCost[i] * noOfCookies - ingredients[i]);

			if (magicPowder < 0)
				return false;
		}
	}

	return true;
}

long long search(vector<long long> cookiesCost, vector<long long> ingredients, long long magicPowder, int noOfElements)
{
	long long left = 0;
	long long right = 10000100000;
	long long noOfCookies = 0;
	while (left <= right)
	{
		long long middle = (left + right) / 2;
		bool compareResult = isValid(cookiesCost, ingredients, middle, magicPowder, noOfElements);

		if (compareResult)
		{
			noOfCookies = middle;
			left = middle + 1;
		}
		else
		{
			right = middle - 1;
		}
	}

	return noOfCookies;
}

int main()
{
	int n;
	long long k, tmp;
	cin >> n >> k;

	vector<long long> cookiesCost;
	for (int i = 0; i < n; i++)
	{
		cin >> tmp;
		cookiesCost.push_back(tmp);
	}

	vector<long long> ingredients;
	for (int i = 0; i < n; i++)
	{
		cin >> tmp;
		ingredients.push_back(tmp);
	}

	cout << search(cookiesCost, ingredients, k, n) << endl;
	return 0;
}