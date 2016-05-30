/// <summary>
/// Problem solution for http://codeforces.com/problemset/problem/670/A
/// </summary>
#include <iostream>

using namespace std;

int main()
{
	int n;
	cin >> n;

	int noOfWeeks = n / 7;
	int remainder = n % 7;

	int min = (noOfWeeks * 2) + (remainder > 5 ? remainder - 5 : 0);
	int max = (noOfWeeks * 2) + (remainder > 2 ? 2 : remainder);

	cout << min << " " << max << endl;
	return 0;
}