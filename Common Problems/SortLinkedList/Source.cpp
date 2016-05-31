/// <summary>
/// Problem: Sort linked list
/// Expected time complexity: O(nlogn)
/// </summary>
#include <iostream>
#include <assert.h>
using namespace std;

struct Node
{
	Node(int value)
	{
		this->value = value;
		this->next = nullptr;
	}

	Node(int value, Node* next)
	{
		this->value = value;
		this->next = next;
	}

	int value;
	Node* next;
};

void splitInHalf(Node* head, Node*& left, Node*& rigth)
{
	if (head == nullptr)
		return;

	Node *slower = head;
	Node *faster = head->next;

	while (faster != nullptr)
	{
		faster = faster->next;
		if (faster != nullptr)
		{
			faster = faster->next;
			slower = slower->next;
		}
	}

	left = head;
	rigth = slower->next;
	slower->next = nullptr;
}

Node* merge(Node *left, Node *right)
{
	Node head(0);
	Node* tail = &head;

	while (left != nullptr && right != nullptr)
	{
		if (left->value <= right->value)
		{
			tail->next = new Node(left->value);
			left = left->next;
		}
		else
		{
			tail->next = new Node(right->value);
			right = right->next;
		}
		tail = tail->next;
	}

	while (left != nullptr)
	{
		tail->next = new Node(left->value);
		left = left->next;
		tail = tail->next;
	}

	while (right != nullptr)
	{
		tail->next = new Node(right->value);
		right = right->next;
		tail = tail->next;
	}

	return head.next;
}

void mergeSort(Node*& head)
{
	if (head == nullptr || head->next == nullptr)
		return;

	Node *left = nullptr;
	Node *right = nullptr;
	splitInHalf(head, left, right);
	mergeSort(left);
	mergeSort(right);
	head = merge(left, right);
}

void print(Node* head, char* msg = "")
{
	printf(msg);
	Node *x = head;
	while (x != nullptr)
	{
		printf("%d ", x->value);
		x = x->next;
	}
	printf("\n");
}

void push(Node*& head, int value)
{
	Node* tmp = new Node(value, head);
	head = tmp;
}

void test1()
{
	Node* head = nullptr;
	push(head, 50);
	push(head, 1);
	push(head, 38);
	push(head, 24);
	push(head, 62);
	push(head, 34);
	push(head, 24);

	print(head, "unsorted: ");

	mergeSort(head);

	Node *x = head;
	while (x != nullptr && x->next != nullptr)
	{
		assert(x->next->value >= x->value);
		x = x->next;
	}

	print(head, "sorted: ");
}

int main()
{
	printf("testing...\n");
	test1();
	printf("all tests passed\n");

	getchar();
	return 0;
}