// Задача 62.
// Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

Console.Clear();

int[,] array = CreateRandom2DArray();
PrintArray2D(GetFillArraySpiral(array));

int[,] GetFillArraySpiral(int[,] array)
{
    int temp = 1;
    int i = 0;
    int j = 0;

    while (temp <= array.GetLength(0) * array.GetLength(1))
    {
        array[i, j] = temp;
        temp++;
        if (i <= j + 1 && i + j < array.GetLength(1) - 1)
            j++;
        else 
        if (i < j && i + j >= array.GetLength(0) - 1)
            i++;
        else 
        if (i >= j && i + j > array.GetLength(1) - 1)
            j--;
        else
            i--;
    }
    return array;
}

int[,] CreateRandom2DArray()
{
    int countOfRow = IntoInt();
    int countOfColums = IntoInt();

    int[,] array = new int[countOfRow, countOfColums];
    //Random random = new Random();

    // for (int i = 0; i < array.GetLength(0); i++)
    // {
    //     for (int j = 0; j < array.GetLength(1); j++)
    //     {
    //         array[i, j] = random.Next(1, 10);
    //     }
    // }

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

void PrintArray2D(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            string message = string.Join(" ", array);
            message = array[i,j].ToString("D2");
            Console.Write($"{message} ");
        }
        Console.WriteLine();
    }
}
