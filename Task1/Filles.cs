using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Task1
{
    public class Filles
    {

        private static Random R = new Random();
        private string fileName;

        public Filles(string fileName)
        {
            this.fileName = fileName;
        }


        public void WriteRandomNumbers(int minCount, int maxCount, int minValue, int maxValue)
        {
            using (FileStream fs = new FileStream(this.fileName, FileMode.Create))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    int count = R.Next(minCount, maxCount + 1);
                    for (int i = 0; i < count; i++)
                    {
                        int number = R.Next(minValue, maxValue + 1);
                        Console.WriteLine(number);
                        bw.Write(number);
                    }
                }
            }
        }

        public int ReadNumber()
        {
            try
            {
                using (FileStream fs = new FileStream(this.fileName, FileMode.Open))
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        return br.ReadInt32();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
                return 0;
            }
        }

        // Задание 4
        public static int CountOppositePairs(string filePath)
        {
            int[] numbers = new int[100];
            using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] = reader.ReadInt32();
                }
            }

            int oppositePairsCount = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[i] + numbers[j] == 0)
                    {
                        oppositePairsCount++;
                    }
                }
            }

            return oppositePairsCount;
        }

        // Задание 5 (не поняла как реализовать)


        // Задание 6
        public static void GenerateFilesOneInLine(string filePath)
        {
            try
            {
                Random random = new Random();
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    for (int i = 0; i < 100; i++)
                    {
                        int randomNum = random.Next(-100, 100);
                        writer.WriteLine(randomNum);
                    }
                }

            }
            catch 
            {
                Console.WriteLine("Ошибка!");
            }
        }

        public static bool IsContainingZero(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (int.TryParse(line, out int num) && num == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        public static void FillFileWithFewIntsInLine(string filePath)
        {
            Random random = new Random();
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                for (int i = 0; i < 100; i++)
                {
                    int Row = random.Next(1, 100);
                    List<int> numbers = new List<int>();
                    for (int j = 0; j < Row; j++)
                    {
                        numbers.Add(random.Next(-100, 100));
                    }
                    writer.WriteLine(string.Join(" ", numbers));
                    
                    //int elementsInLine = random.Next(1, 50);
                    //for (int j = 0; j < elementsInLine; j++)
                    //{
                    //    int randomNumber = random.Next(-100, 100);
                    //    writer.Write(randomNumber + " ");
                    //}
                    //writer.WriteLine();
                }
            }

        }

        public static int CalculateMaxElement(string filePath)
        {
            int maxElement = -101;
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    int[] numbers = line.Split(' ').Select(int.Parse).ToArray();
                    int Max = numbers.Max();
                    if (Max > maxElement)
                    {
                        maxElement = Max;
                    }
                }
            }
            return maxElement;
        }

        public static void copyData(string filePathInput, string filePathOutput, char c)
        {
            using (StreamReader reader = new StreamReader(filePathInput)) 
            using (StreamWriter writer = new StreamWriter(filePathOutput))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.EndsWith(c))
                    {
                        writer.WriteLine(line);
                    }
                }
            }
            Console.WriteLine("Успешно создан");
        }












    }
}




