// Составить частотный словарь элементов двумерного массива. 
// Частотный словарь содержит информацию о том, сколько раз встречается элемент входных данных.

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
            array[i,j] = rnd.Next(1,10);
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

void StringArrayPrint(string[,] Array) // функция напишет словарь 
{
    Console.WriteLine();  
    for ( int i = 0 ; i < Array.GetLength(0) ; i ++)
    {
        for ( int j = 0 ; j < Array.GetLength(1) ; j ++)
            Console.Write($"{Array[i,j]}" + " "); // "\t"{Array...} создает пробел между элементами строки 
        Console.WriteLine();
    }
}

string[,] DictionaryCreation(int[,] Array) // создаем словарь 
{
    string[,] dictionary = new string[10,4]; // 10 строк от 1 до 10, 4 слова: "число" + встречается + "столько-то" + раз
    for (int i = 0 ; i < 10 ; i ++) // число от 1 до 10 в первом ряду во всех строках
        dictionary[i,0] = $"{i}";
    for (int i = 0 ; i < 10 ; i ++) // проставили во всех строках на второй позиции "встречается"
        dictionary[i,1] = "встречается";
    for (int i = 0 ; i < 10 ; i ++) // везде по дефолту проставили нули на 3 позиции
        dictionary[i,2] = "0";
    for (int i = 0 ; i < 10 ; i ++) // везде проставили "раз" на 4 позиции 
        dictionary[i,3] = "раз";

    for ( int i = 0 ; i < Array.GetLength(0) ; i++) // пошли по всему массиву чисел по порядку
        for ( int j = 0 ; j < Array.GetLength(1); j++) // параллельно запускаем счетчик n от 0 до 9 на первой позиции словаря 
            for ( int n = 0 ; n < 10 ; n++) // если элемент массива равен первому элементу какой-то строки словаря, то счетчик "раз" на 3 позиции увеличивается на 1
                if (Convert.ToString(Array[i,j]) == dictionary[n,0]) dictionary[n,2] = Convert.ToString(int.Parse(dictionary[n,2]) + 1);
    
    return dictionary;
}

string message1 = "Введите количество строк массива: ";
string message2 = "Введите количество рядов массива: ";
int N = GetNumber(message1);
int M = GetNumber(message2);

int [,] Array = FillArray(N,M);
PrintArray(Array);
string [,] Dictionary = DictionaryCreation(Array);
StringArrayPrint(Dictionary);