// Задайте двумерный массив из целых чисел. 
// Напишите программу, которая удалит строку и столбец, на пересечении которых расположен наименьший элемент массива.

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
    int [,] array = new int [N,M];
    Random rnd = new Random();
    for (int i = 0; i < N; i++)
    {
        for (int j = 0; j < M; j++)
        {
            array[i,j] = rnd.Next(1,100);
        }
    }
    return array;
}

void PrintArray(int [,] Array)
{
    Console.WriteLine();
    for (int i = 0; i < Array.GetLength(0); i++)
    {
        for (int j = 0; j < Array.GetLength(1); j++)
        {
            Console.Write(Array[i,j] + " ");
        }
        Console.WriteLine();
    }
}

(int, int, int) FindMin (int [,] Array)
{
    int min = Array[0,0];
    int MinN = 0;
    int MinM = 0;
    for (int i = 0; i < Array.GetLength(0); i++)
    {
        for (int j = 0; j < Array.GetLength(1); j++)
        {
            if (Array[i,j] < min)
            {
                min = Array[i,j];
                MinN = i;
                MinM = j;
            }
        }
    }
    return (min, MinN, MinM);
}

int [,] ArrayChanger(int [,] Array, int minValue, int RowToDelete, int ColumnToDelete)
{
    int x = 0;
    int y = 0;

    int [,] NewArray = new int [Array.GetLength(0)-1, Array.GetLength(1)-1];
    for ( int i = 0 ; i < Array.GetLength(0) ; i++)
        if ( i != RowToDelete) 
        {   
            y = 0;
            for ( int j = 0 ; j < Array.GetLength(1) ; j ++)
            {
                if ( j != ColumnToDelete) 
                {
                    NewArray[x,y] = Array[i,j];
                    y++;
                }
            }
            x++;
        }
    return NewArray;
}

string message1 = "Введите количество строк массива: ";
string message2 = "Введите количество рядов массива: ";
int N = GetNumber(message1);
int M = GetNumber(message2);

int [,] Array = FillArray(N,M);
PrintArray(Array);
(int minValue, int RowToDelete, int ColumnToDelete) = FindMin(Array);
int [,] ResultArray = ArrayChanger(Array, minValue, RowToDelete, ColumnToDelete);
PrintArray(ResultArray);