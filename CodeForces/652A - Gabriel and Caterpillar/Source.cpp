/// <summary>
/// Problem solution for http://codeforces.com/contest/652/problem/A
/// </summary>
#include <iostream>

using namespace std;

int main()
{
	double h1, h2, a, b;
	cin >> h1 >> h2 >> a >> b;
	h1 -= 4 * a;
	a *= 12;
	b *= 12;

	if (a <= b && a + h1 < h2)
	{
		cout << -1 << endl;
		return 0;
	}


	int i = 0;
	while (true)
	{
		h1 += a;
		if (h1 >= h2)
		{
			cout << i << endl;
			break;
		}
		h1 -= b;
		i++;
	}

	return 0;
}