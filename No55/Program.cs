﻿// Задайте двумерный массив. Напишите программу, которая заменяет строки на столбцы. 
// В случае, если это невозможно, программа должна вывести сообщение для пользователя.

int GetNumber(string msg)
{
    while (true)
    {
        Console.WriteLine(msg);
        string value = Console.ReadLine();
        if (int.TryParse(value, out int num))
        {
            return num;
        }
        else
        {
            Console.WriteLine("Вы ввели не число, попробуйте еще раз!");
        }
    }
}

int[,] FillArray(int N, int M)
{
    int[,] Array = new int[N, M];
    Random rnd = new Random();
    for (int i = 0; i < N; i++)
    {
        for (int j = 0; j < M; j++)
        {
            Array[i, j] = rnd.Next(1, 10);
        }
    }
    return Array;
}

void PrintArray(int[,] TwoSetArray)
{
    Console.WriteLine();
    for (int i = 0; i < TwoSetArray.GetLength(0); i++)
    {
        for (int j = 0; j < TwoSetArray.GetLength(1); j++)
        {
            Console.Write(TwoSetArray[i, j] + " ");
        }
        Console.WriteLine();
    }
}

int[,] ArrayRowSwitcher(int[,] TwoSetArray, int N, int M)
{
    int[,] newArray = new int[N, M];
    for (int i = 0; i < N; i++)
    {
        for (int j = 0; j < M; j++)
        {
            newArray[j, i] = TwoSetArray[i, j];
        }
    }
    return newArray;
}

string message1 = "Введите количество строк массива: ";
string message2 = "Введите количество рядов массива: ";
int N = GetNumber(message1);
int M = GetNumber(message2);

int[,] TwoSetArray = FillArray(N, M);
PrintArray(TwoSetArray);
if (TwoSetArray.GetLength(0) != TwoSetArray.GetLength(1))
{
    Console.WriteLine("Простите, но запрос выполнить невозможно в связи с размерностью массива.");
}
if (TwoSetArray.GetLength(0) == TwoSetArray.GetLength(1))
{
    int [,] resultArray = ArrayRowSwitcher(TwoSetArray, N, M);
    PrintArray(resultArray);
}
    