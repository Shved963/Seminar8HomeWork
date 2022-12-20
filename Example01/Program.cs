// Задача 54: Задайте двумерный массив.
// Напишите программу, которая упорядочит
// по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

Console.Clear();

Console.WriteLine("Введите размер массива");

int[,] array = CreateRandom2DArray();
PrintArray(array);

Console.WriteLine();

int[,] sortingArray = GetRowSorting(array);
PrintArray(sortingArray);

int[,] GetRowSorting(int[,] array)
{

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int k = 0; k < array.GetLength(1); k++)
        {
            for (int j = 0; j < array.GetLength(1) - 1 - k; j++)
            {
                if (array[i, j] < array[i, j + 1])
                {
                    int tempVolue = array[i, j];
                    array[i, j] = array[i, j + 1];
                    array[i, j + 1] = tempVolue;
                }
            }
        }
    }
    return array;

}

void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]} ");
        }
        Console.WriteLine();
    }
}

int[,] CreateRandom2DArray()
{
    int countOfRow = IntoInt();
    int countOfColums = IntoInt();

    int[,] array = new int[countOfRow, countOfColums];
    Random random = new Random();

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = random.Next(-9, 10);
        }
    }

    return array;
}

int IntoInt()
{
    bool isParsed = int.TryParse(Console.ReadLine(), out int num);
    if (isParsed)
    {
        return num;
    }
    else
    {
        throw new Exception("Ввели не корректные данные");
    }

}
