// Задача 60.Сформируйте трёхмерный массив из неповторяющихся двузначных чисел.
// Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

Console.Clear();

int[,,] array = CreateRandom3DArray();
PrintArray3D(array);





int[,,] CreateRandom3DArray()
{
    int countOfRow = IntoInt();
    int countOfColums = IntoInt();
    int countOf3D = IntoInt();
    int number;

    int[,,] array = new int[countOfRow, countOfColums, countOf3D];
    int[] randomElemets = new int[countOfRow * countOfColums * countOf3D];
    Random random = new Random();
    if (countOfColums < 1 || countOfRow < 1 || countOf3D < 1)
    {
        throw new ArgumentException("Введен не корректный размер матрицы");
    }
    else
    {
        for (int l = 0; l < randomElemets.Length; l++)
        {
            randomElemets[l] = random.Next(10, 100);
            number = randomElemets[l];

                for (int n = 0; n < l; n++)
                {
                    while (randomElemets[l] == randomElemets[n])
                    {
                        randomElemets[l] = random.Next(10, 100);
                        n = 0;
                        number = randomElemets[l];
                    }

                    number = randomElemets[l];
                }
        }
        int count = 0;
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                for (int k = 0; k < array.GetLength(2); k++)
                {
                    array[i, j, k] = randomElemets[count];
                    count++;
                }
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

void PrintArray3D(int[,,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                Console.Write($"{array[i, j, k]} ({i},{j},{k}) ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}