/// <summary>
/// Problem: Find the first circular tour that visits all petrol pumps
/// Suppose there is a circle.There are n petrol pumps on that circle.You are given two sets of data.
/// 
/// 1. The amount of petrol that every petrol pump has.
/// 2. Distance from that petrol pump to the next petrol pump.
/// 
/// Calculate the first point from where a truck will be able to complete the circle(The truck will stop at each petrol pump and it has infinite capacity).
/// Expected time complexity is O(n).Assume for 1 litre petrol, the truck can go 1 unit of distance.
///
/// Source: http://www.geeksforgeeks.org/find-a-tour-that-visits-all-stations/
/// </summary>
#include <iostream>
#include <assert.h>

using namespace std;

struct pump
{
	int petrol;
	int distance;

	int calculateRealtiveCost() const
	{
		return petrol - distance;
	}
};

int find(pump arr[], int n)
{
	int begin = 0;
	int end = 1;
	int current = arr[begin].calculateRealtiveCost();

	while(begin != end || current < 0)
	{
		while (begin != end && current < 0)
		{
			current -= arr[begin].calculateRealtiveCost();
			begin = (begin + 1) % n;

			if (begin == 0)
				return -1;
		}

		current += arr[end].calculateRealtiveCost();

		end = (end + 1) % n;
	}

	return begin;
}

void testHelper(pump arr[], int expetcedOutput)
{
	int n = sizeof(arr) / sizeof(arr[0]);
	cout << n << endl;
	assert(find(arr, n), expetcedOutput);
}

void test()
{
	pump arr[] = { { 4, 6 }, { 6, 5 }, { 7, 3 }, {4, 5} };
	int n = sizeof(arr) / sizeof(arr[0]);
	assert(find(arr, n) == 1);
}

int main()
{
	cout << "testing..." << endl;
	test();
	cout << "all tests passed." << endl;

	system("PAUSE");
	return 0;
}