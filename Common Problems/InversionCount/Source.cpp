/// <summary>
/// Problem: Count inversion in an array - how far an array is from being sorted
/// Expected time complexity: O(nlogn)
/// Algorithmic paradigm: Divide and Conquer - Merge sort modification
/// </summary>
#include <iostream>
#include <vector>
#include <assert.h>

using namespace std;

int merge(int arr[], int l, int m, int r)
{
	int noOfInversion = 0;
	int nL = m - l + 1;
	int nR = r - m;

	vector<int> tmpL;
	vector<int> tmpR;

	for (int i = 0; i < nL; i++)
	{
		tmpL.push_back(arr[l + i]);
	}

	for (int i = 0; i < nR;i++)
	{
		tmpR.push_back(arr[m + i + 1]);
	}

	int iLeft = 0;
	int iRight = 0;
	int i = l;

	while (iLeft < nL && iRight < nR)
	{
		if (tmpL[iLeft] <= tmpR[iRight])
		{
			arr[i++] = tmpL[iLeft++];
		}
		else
		{
			arr[i++] = tmpR[iRight++];
			noOfInversion += nL - iLeft;
		}
	}

	while (iLeft < nL)
	{
		arr[i++] = tmpL[iLeft++];
	}

	while (iRight < nR)
	{
		arr[i++] = tmpR[iRight++];
	}

	return noOfInversion;
}

int mergeSort(int arr[], int l, int r)
{
	int noOfInversion = 0;
	if (l<r)
	{
		int m = (l + r) / 2;
		noOfInversion += mergeSort(arr, l, m);
		noOfInversion += mergeSort(arr, m + 1, r);
		noOfInversion += merge(arr, l, m, r);
	}
	return noOfInversion;
}

int main()
{
	int arr[] = { 1, 20, 6, 4, 5 };
	assert(mergeSort(arr, 0, 4) == 5);
	
	int arr2[] = { 1, 5, 4, 8, 10, 2, 6, 9, 3, 7 };
	assert(mergeSort(arr2, 0, 9) == 17);

	printf("all tests passed");

	getchar();
	return 0;
}