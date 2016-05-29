/// <summary>
/// Problem solution for http://codeforces.com/problemset/problem/670/D1
/// </summary>
#include <iostream>
#include <vector>

using namespace std;

bool isValid(vector<int> cookiesCost, vector<int> ingredients, int noOfCookies, int magicPowder, int noOfElements)
{

	for (int i = 0; i < noOfElements; i++)
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

int search(vector<int> cookiesCost, vector<int> ingredients, int magicPowder, int noOfElements)
{
	int left = 0;
	int right = 2000;
	int noOfCookies = 0;
	while (left <= right)
	{
		int middle = (left + right) / 2;
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
	int n, k, tmp;
	cin >> n >> k;

	vector<int> cookiesCost;
	for (int i = 0; i < n; i++)
	{
		cin >> tmp;
		cookiesCost.push_back(tmp);
	}

	vector<int> ingredients;
	for (int i = 0; i < n; i++)
	{
		cin >> tmp;
		ingredients.push_back(tmp);
	}

	cout << search(cookiesCost, ingredients, k, n) << endl;
	return 0;
}