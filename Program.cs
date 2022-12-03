Task59();

Console.ReadKey();
Task54();

Console.ReadKey();
Task56();

Console.ReadKey();
Task58();

Console.ReadKey();
Task60();

Console.ReadKey();
Task62();


void Task59()
{
    Console.WriteLine("\nЗадача 59: Задайте двумерный массив из целых чисел. Напишите программу, которая " +
                        "удалит строку и столбец, на пересечении которых расположен наименьший элемент массива. " +
                        "\nНапример, задан массив:\n1 4 7 2\n5 9 2 3\n8 4 2 4\n5 2 6 7\nНаименьший " +
                        "элемент -> 1, на выходе получим следующий массив:\n9 2 3\n4 2 4\n2 6 7");

    Console.WriteLine("Решение:");

    int[,] matrix = CreateAndFillIntMatrix(0, 99);
    PrintIntMatrix(matrix);

    (int minI, int minJ, int minNum) minIndex = GetMinIndexByMatrix(matrix);
    Console.WriteLine($"Наименьший элемент массива {minIndex.minNum} расположен " +
                         $"на позиции -> [{minIndex.minI}, {minIndex.minJ}]");

    int[,] numbers = GetNewMatrixWithoutMinIndex(matrix, minIndex);
    PrintIntMatrix(numbers);
}

void Task54()
{
    Console.WriteLine("\nЗадача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по " +
                        "убыванию элементы каждой строки двумерного массива.\nНапример, задан массив:" +
                        "\t\tВ итоге получается вот такой массив:\n1 4 7 2\t\t\t\t7 4 2 1" +
                        "\n5 9 2 3\t\t\t\t9 5 3 2\n8 4 2 4\t\t\t\t8 4 4 2");

    Console.WriteLine("Решение:");

    int[,] matrix = CreateAndFillIntMatrix(0, 9);
    PrintIntMatrix(matrix);

    SortingMatrixByRows(matrix);
    PrintIntMatrix(matrix);
}

void Task56()
{
    Console.WriteLine("\nЗадача 56: Задайте прямоугольный двумерный массив. Напишите программу, " +
                        "которая будет находить строку с наименьшей суммой элементов. " +
                        "Например, задан массив:\n1 4 7 2\n5 9 2 3\n8 4 2 4\n5 2 6 7\nПрограмма считает сумму " +
                        "элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов -> 1 строка");

    Console.WriteLine("Решение:");

    int[,] matrix = CreateAndFillIntMatrix(0, 9);
    PrintIntMatrix(matrix);

    FindMinSumRowByMatrix(matrix);
}

void Task58()
{
    Console.WriteLine("\nЗадача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух " +
                        "матриц.\nНапример, даны 2 матрицы:\n2 4 | 3 4\n3 2 | 3 3" +
                        "\nРезультирующая матрица будет:\n18 20\n15 18");

    Console.WriteLine("Решение:");

    int[,] matrix = CreateAndFillIntMatrix(0, 9);
    PrintIntMatrix(matrix);

    int[,] numbers = CreateAndFillSecondMatrix(matrix, 0, 9);
    PrintIntMatrix(numbers);

    Console.WriteLine("Произведение матриц:");
    int[,] multMatrix = GetMultMatrix(matrix, numbers);
    PrintIntMatrix(multMatrix);
}

void Task60()
{
    Console.WriteLine("\nЗадача 60. Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите " +
                         "программу, которая будет построчно выводить массив, добавляя индексы каждого элемента." +
                         "\nПример массива размером 2 x 2 x 2:\n66(0, 0, 0)\t25(0, 1, 0)\n34(1, 0, 0)\t41(1, 1, 0)" +
                         "\n27(0, 0, 1)\t90(0, 1, 1)\n26(1, 0, 1)\t55(1, 1, 1)");

    Console.WriteLine("Решение:");

    int row = 6; // Количество чисел (от 10 до 99) -> 90. 
    int col = 5; // Размер массива -> 90 (6 * 5 * 3), чтобы значения элементов не повторялись.
    int dep = 3;

    int[,,] cube = new int[6, 5, 3];


    List<int> dinArray = new List<int>();

    Random rand = new Random();
    int randNum = rand.Next(10, 100);
    dinArray.Add(-1);

    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < col; j++)
        {
            for (int k = 0; k < dep; k++)
            {
                for (int l = 0; l < dinArray.Count; l++)
                {
                    if (randNum == dinArray[l])
                    {
                        randNum = rand.Next(10, 100);
                        l = 0;
                    }
                }
                cube[i, j, k] = randNum;
                dinArray.Add(randNum);
                randNum = rand.Next(10, 100);
            }
        }
    }

    PrintCube(cube);
}

void Task62()
{
    Console.WriteLine("\nЗадача 62. Напишите программу, которая заполнит спирально массив 4 на 4. " +
                        "\nНапример, на выходе получается вот такой массив:\n01 02 03 04" +
                        "\n12 13 14 05\n11 16 15 06\n10 09 08 07");

    Console.WriteLine("Решение:");

    int rows = ReadIntFromConsole("Введите количество строк массива: ");
    int columns = ReadIntFromConsole("Введите количество столбцов массива: ");

    int[,] matrix = new int[rows, columns];
    int length = matrix.Length;

    int count = 0;
    int curRow = 0;
    int curCol = 0;

    int changeIndRow = 0;
    int changeIndCol = 1;

    int steps = columns;
    int turn = 0;

    while (count < length)
    {
        count++;
        matrix[curRow, curCol] = count;
        steps--;

        if (steps == 0)
        {
            steps = rows * ((turn + 1) % 2) + columns * (turn % 2) - 1 - turn / 2;
            (changeIndRow, changeIndCol) = (changeIndCol, -changeIndRow);
            turn++;
        }

        curRow += changeIndRow;
        curCol += changeIndCol;
    }

    PrintIntMatrix(matrix);
}


int ReadIntFromConsole(string message)
{
    Console.Write(message);
    return Convert.ToInt32(Console.ReadLine());
}

int[,] CreateAndFillIntMatrix(int minVal = -99, int maxVal = 99)
{
    maxVal++;
    Random rand = new Random();

    int rows = ReadIntFromConsole("Введите количество строк массива: ");
    int columns = ReadIntFromConsole("Введите количество столбцов массива: ");

    int[,] matrix = new int[rows, columns];

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            matrix[i, j] = rand.Next(minVal, maxVal);
        }
    }
    return matrix;
}

void PrintIntMatrix(int[,] matrix)
{
    Console.WriteLine("Вывод двумерного массива:");
    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            Console.Write(matrix[i, j] + "\t");
        }
        Console.WriteLine();
    }
}

(int minI, int minJ, int minNum) GetMinIndexByMatrix(int[,] matrix)
{
    (int minI, int minJ, int minNum) minIndex = (0, 0, matrix[0, 0]);

    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            if (matrix[i, j] < minIndex.minNum)
            {
                minIndex.minNum = matrix[i, j];
                minIndex.minI = i;
                minIndex.minJ = j;
            }
        }
    }
    return minIndex;
}

int[,] GetNewMatrixWithoutMinIndex(int[,] matrix, (int minI, int minJ, int minNum) minIndex)
{
    int rows = matrix.GetLength(0) - 1;
    int columns = matrix.GetLength(1) - 1;

    int[,] numbers = new int[rows, columns];
    int skipI = 0;

    for (int i = 0; i < rows; i++)
    {
        if (i == minIndex.minI) skipI++;
        int skipJ = 0;

        for (int j = 0; j < columns; j++)
        {
            if (j == minIndex.minJ) skipJ++;
            numbers[i, j] = matrix[i + skipI, j + skipJ];
        }
    }

    return numbers;
}

void SortingMatrixByRows(int[,] matrix)
{
    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);

    for (int i = 0; i < rows; i++)
    {
        for (int j = 1; j < columns; j++)
        {
            for (int k = 0; k < columns - j; k++)
            {
                if (matrix[i, k] < matrix[i, k + 1])
                {
                    (matrix[i, k], matrix[i, k + 1]) = (matrix[i, k + 1], matrix[i, k]);
                }
            }
        }
    }
}

void FindMinSumRowByMatrix(int[,] matrix)
{
    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);

    int minIndexSumRow = 0;
    int sumRow = 0;

    for (int j = 0; j < columns; j++)
    {
        sumRow += matrix[minIndexSumRow, j];
    }

    int minSumRow = sumRow;

    for (int i = 1; i < rows; i++)
    {
        sumRow = 0;
        for (int j = 0; j < columns; j++)
        {
            sumRow += matrix[i, j];
        }

        if (minSumRow > sumRow)
        {
            minSumRow = sumRow;
            minIndexSumRow = i;
        }
    }
    Console.WriteLine($"Номер строки с наименьшей суммой элементов -> {minIndexSumRow + 1} строка");
}

int[,] CreateAndFillSecondMatrix(int[,] matrix, int minVal = -99, int maxVal = 99)
{
    maxVal++;
    Random rand = new Random();
    int rows = ReadIntFromConsole("Введите количество строк второй матрицы: ");
    int columns = matrix.GetLength(0);

    int[,] numbers = new int[rows, columns];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            numbers[i, j] = rand.Next(minVal, maxVal);
        }
    }
    return numbers;
}

int[,] GetMultMatrix(int[,] matrix, int[,] numbers)
{
    int rows = numbers.GetLength(0);
    int columns = matrix.GetLength(1);
    int count = matrix.GetLength(0);

    int[,] multMatrix = new int[rows, columns];

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            int sumMult = 0;

            for (int k = 0; k < count; k++)
            {
                sumMult += matrix[k, j] * numbers[i, k];
            }
            multMatrix[i, j] = sumMult;
        }
    }
    return multMatrix;
}

void PrintCube(int[,,] cube)
{
    Console.WriteLine("Вывод трехмерного массива:");
    int row = cube.GetLength(0);
    int col = cube.GetLength(1);
    int dep = cube.GetLength(2);

    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < col; j++)
        {
            for (int k = 0; k < dep; k++)
            {
                Console.Write($"{cube[i, j, k]}({i},{j},{k})\t");
            }
            Console.WriteLine();
        }
    }
}
