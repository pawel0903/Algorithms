/// <summary>
/// Problem solution for http://codeforces.com/problemset/problem/670/C
/// </summary>
#include <iostream>
#include <map>

using namespace std;

int main()
{
	int n, tmp;
	cin >> n;

	map<int, int> scientists;

	while (n--)
	{
		cin >> tmp;
		scientists[tmp]++;
	}

	int m;
	cin >> m;

	int audioLanguage[2000001];
	int subtitleLanguage[2000001];

	for (int i = 0; i < m; i++)
	{
		cin >> tmp;
		audioLanguage[i] = tmp;
	}

	for (int i = 0; i < m; i++)
	{
		cin >> tmp;
		subtitleLanguage[i] = tmp;
	}

	pair<int, int> max(-1, -1);
	int movieIndex = 0;

	for (int i = 0; i < m; i++)
	{
		int audio = scientists[audioLanguage[i]];
		int subtitle = scientists[subtitleLanguage[i]];
		if (audio > max.first || (audio == max.first && subtitle > max.second))
		{
			max = make_pair(audio, subtitle);
			movieIndex = i + 1;
		}
	}

	cout << movieIndex << endl;
	return 0;
}