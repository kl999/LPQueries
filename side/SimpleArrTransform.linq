<Query Kind="Statements" />

float[] arr = new float[]{0, 1, 2, 3, 4};

//----------------------------------------------------------------

float addMember = 5;

arr.Dump("Original");

float[] temp = arr;

int newLen = arr.Length + 1;

arr = new float[newLen];

for(int i = 0; i < newLen - 1; i++)
{
	arr[i] = temp[i];
}

arr[newLen - 1] = addMember;

arr.Dump("Appended");

//-----------------------------------------------------------------

addMember = 2.5f;

int position = 3;

temp = arr;

newLen = arr.Length + 1;

arr = new float[newLen];

for(int i = 0; i < temp.Length; i++)
{
	if(i < position)
		arr[i] = temp[i];
	if(i >= position)
		arr[i + 1] = temp[i];
}

arr[position] = addMember;

arr.Dump("Added");