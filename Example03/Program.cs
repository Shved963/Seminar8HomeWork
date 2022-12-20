// Задача 58: Задайте две матрицы.
// Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

Console.Clear();

Console.WriteLine("Введите размер ПЕРВОЙ матрицы");
int[,] firstArray = CreateRandom2DArray();
Console.WriteLine("Введите размер ВТОРОЙ матрицы");
int[,] secondArray = CreateRandom2DArray();
Console.WriteLine();

PrintArray2D(firstArray);
Console.WriteLine();

PrintArray2D(secondArray);
Console.WriteLine();

int[,] resultArray = GetMultiTwoMatrix(firstArray, secondArray);
resultArray[0,0] = 02;
PrintArray2D(resultArray);



int[,] GetMultiTwoMatrix(int[,] arrayOne, int[,] arrayTwo)
{
    int[,] resultArray = new int[arrayOne.GetLength(0), arrayTwo.GetLength(1)];
    if (arrayOne.GetLength(1) != arrayTwo.GetLength(0))
    {
        throw new ArgumentException("Неправильный размер матриц");
    }
    else
    {
        for (int i = 0; i < arrayOne.GetLength(0); i++)
        {
            for (int j = 0; j < arrayTwo.GetLength(1); j++)
            {
                for (int k = 0; k < arrayOne.GetLength(1); k++)
                {
                    resultArray[i, j] = arrayOne[i, k] * arrayTwo[k, j] + resultArray[i, j];
                }
            }
        }
    }
    return resultArray;
}

int[,] CreateRandom2DArray()
{
    int countOfRow = IntoInt();
    int countOfColums = IntoInt();

    int[,] array = new int[countOfRow, countOfColums];
    Random random = new Random();
    if (countOfColums < 1 || countOfRow < 1)
    {
        throw new ArgumentException("Введен не корректный размер матрицы");
    }
    else
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                array[i, j] = random.Next(1, 10);
            }
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

void PrintArray2D(int[,] array)
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
