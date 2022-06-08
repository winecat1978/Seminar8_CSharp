// Задайте двумерный массив. 
// Напишите программу, которая поменяет местами первую и последнюю строку массива.

int GetNumber (string msg)
{
    while(true)
    {
        Console.WriteLine(msg);
        string value = Console.ReadLine();
        if(int.TryParse(value, out int num))
        {
            return num;
        }
        else 
        {
            Console.WriteLine("Вы ввели не число, попробуйте еще раз!");
        }
    }
}

int [,] FillArray (int N, int M)
{
    int [,] Array = new int [N,M];
    Random rnd = new Random();
    for (int i = 0; i < N; i++)
    {
        for (int j = 0; j < M; j++)
        {
            Array[i,j] = rnd.Next(1,10);
        }
    }
    return Array;
}

void PrintArray(int [,] TwoSetArray)
{
    Console.WriteLine();
    for (int i = 0; i < TwoSetArray.GetLength(0); i++)
    {
        for (int j = 0; j < TwoSetArray.GetLength(1); j++)
        {
            Console.Write(TwoSetArray[i,j] + " ");
        }
        Console.WriteLine();
    }
}

void ArraySwitcher (int [,] TwoSetArray)
{
    int k = TwoSetArray.GetLength(0);
    int l = TwoSetArray.GetLength(1);
    int remember = 0;
    for (int i = 0; i < TwoSetArray.GetLength(0); i++)
    {
        for (int j = 0; j < TwoSetArray.GetLength(1); j++)
        {
            if(i == 0)
            {
                remember = TwoSetArray[i,j];
                TwoSetArray[i,j] = TwoSetArray[k-1,j];
                TwoSetArray[k-1,j] = remember;
            }
        }
    }
}


string message1 = "Введите количество строк массива: ";
string message2 = "Введите количество рядов массива: ";
int N = GetNumber(message1);
int M = GetNumber(message2);

int [,] TwoSetArray = FillArray(N,M);
PrintArray(TwoSetArray);
ArraySwitcher(TwoSetArray);
PrintArray(TwoSetArray);