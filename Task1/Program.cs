using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Task1;
using System.Xml;
using System.Xml.Serialization;
using static System.Net.WebRequestMethods;

// Задание 1
// Создание первого массива

try
{
    Console.Write("Введите количество строк для первого массива: ");
    int n = Convert.ToInt32(Console.ReadLine());
    Console.Write("Введите количество столбцов для первого массива: ");
    int m = Convert.ToInt32(Console.ReadLine());

    MatrixGenerator generator1 = new MatrixGenerator(n, m);
    Console.WriteLine("Первый массив:");
    generator1.PrintMatrix();
}

catch
{

    Console.WriteLine("Возникла ошибка!");
}

try
{   // Создание второго массива
    Console.Write("\nВведите размерность для второго массива: ");
    int n = Convert.ToInt32(Console.ReadLine());

    MatrixGenerator generator2 = new MatrixGenerator(n);
    Console.WriteLine("\nВторой массив:");
    generator2.PrintMatrix();

    // Создание третьего массива
    Console.Write("Введите размерность матрицы: ");
    int x = Convert.ToInt32(Console.ReadLine());
    bool t = true;

    Console.WriteLine("\nТретий массив:");
    MatrixGenerator generator3 = new MatrixGenerator(x, t);

}

catch
{

    Console.WriteLine("Возникла ошибка!");
}

try
{   // Создание третьего массива
    Console.Write("Введите размерность матрицы: ");
    int x = Convert.ToInt32(Console.ReadLine());
    bool t = true;

    Console.WriteLine("\nТретий массив:");
    MatrixGenerator generator3 = new MatrixGenerator(x, t);
}

catch
{

    Console.WriteLine("Возникла ошибка!");
}

try
{
    // Задание 2
    Console.WriteLine("Введите кол-во банков: ");
    int y = Convert.ToInt32(Console.ReadLine());
    string s = "";

    MatrixGenerator generator4 = new MatrixGenerator(y, s);
    Console.WriteLine("Таблица задолжности:");
    generator4.PrintMatrix();
    generator4.MaximumElement();
}
catch { Console.WriteLine("Возникла ошибка!"); }


try
{
    // Задание 3
    Console.WriteLine("Введите размерность матриц: ");
    int a = Convert.ToInt32(Console.ReadLine());
    string s = "";

    MatrixGenerator A = new MatrixGenerator(a, s);
    MatrixGenerator B = new MatrixGenerator(a, s);
    MatrixGenerator C = new MatrixGenerator(a, s);

    Console.WriteLine("Матрица А: ");
    A.PrintMatrix();
    Console.WriteLine("Матрица В: ");
    B.PrintMatrix();
    Console.WriteLine("Матрица С: ");
    C.PrintMatrix();
    Console.WriteLine("\nРезультат выражения: ");
    Console.WriteLine(2 * A - B.Transpose() * C);
}

catch {
    Console.WriteLine("Возникла ошибка!");
}

// Задание 4
try
{
    Filles files = new Filles("random_numbers.bin");

    // Запись случайных чисел в файл
    files.WriteRandomNumbers(100, 200, -100, 100);

    // Подсчет пар противоположных чисел
    int oppositePairsCount = Filles.CountOppositePairs("random_numbers.bin");

    Console.WriteLine($"Количество пар противоположных чисел: {oppositePairsCount}");

}
catch
{
    Console.WriteLine("Возникла ошибка!");
}

// Задание 6
string filePath = "task6.txt";
Filles.GenerateFilesOneInLine(filePath);
Console.WriteLine("Содержит ли нули: " + Filles.IsContainingZero(filePath));


// Задача 7
string path2 = "task7.txt";
Filles.FillFileWithFewIntsInLine(path2);
Console.WriteLine("Максимальный чел: " + Filles.CalculateMaxElement(path2));

// Задача 8
    string filePathInput = "text8.txt";
    string filePathOutput = "task8out.txt";
    char input = Convert.ToChar(Console.ReadLine());

    Filles.copyData(filePathInput, filePathOutput, input);
catch { Console.WriteLine("оштбка"); }
Console.ReadKey();
