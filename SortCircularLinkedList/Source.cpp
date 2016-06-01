/// <summary>
/// Problem: Sort circular linked list
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
	if (head == nullptr || head == head->next)
		return;

	Node *slower = head;
	Node *faster = head;

	while (faster->next != head)
	{
		faster = faster->next;
		if (faster->next != head)
		{
			faster = faster->next;
			slower = slower->next;
		}
	}

	left = head;
	rigth = slower->next;
	faster->next = slower->next;
	slower->next = head;
}

Node* merge(Node *left, Node *right)
{
	Node head(0);
	Node* tail = &head;
	Node* headL = left;
	Node* headR = right;
	bool usedL = false, usedR = false;

	do
	{
		if (left->value <= right->value)
		{
			tail->next = new Node(left->value);
			left = left->next;
			usedL = true;
		}
		else
		{
			tail->next = new Node(right->value);
			right = right->next;
			usedR = true;
		}
		tail = tail->next;
	} while ((left != headL || !usedL) && (right != headR || !usedR));

	while (left != headL || !usedL)
	{
		if (!usedL)
			usedL = true;
		tail->next = new Node(left->value);
		left = left->next;
		tail = tail->next;
	}


	while (right != headR || !usedR)
	{
		if (!usedR)
			usedR = true;
		tail->next = new Node(right->value);
		right = right->next;
		tail = tail->next;
	}

	tail->next = head.next;

	return head.next;
}

void mergeSort(Node*& head)
{
	if (head == nullptr || head->next == head)
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
	if (head == nullptr)
		return;
	printf(msg);
	Node *x = head;
	do
	{
		printf("%d ", x->value);
		x = x->next;
	} while (x != head);

	printf("\n");
}

void push(Node*& head, int value)
{
	Node* newNode = new Node(value, head);
	Node* tmp = head;

	if (head != nullptr)
	{
		while (tmp->next != head)
		{
			tmp = tmp->next;
		}
		tmp->next = newNode;
	}
	else
	{
		newNode->next = newNode;
	}

	head = newNode;
}

void test1()
{
	Node* head = nullptr;
	push(head, 3);
	push(head, 5);
	push(head, 1);
	push(head, 6);
	push(head, 2);
	push(head, 1);
	push(head, 4);


	print(head, "unsorted: ");

	mergeSort(head);

	Node *x = head;
	do
	{
		assert(x->next->value >= x->value);
		x = x->next;
	} while (x != head && x->next != head);

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