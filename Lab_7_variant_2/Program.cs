using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Lab_7_variant_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Reader Rdr = new Reader("InputTextFile.txt");
            string data = Rdr.ReadFile;
            Sentence Value = new Sentence(data);
            int a = Value.Count;
            Console.WriteLine("Колличество предложений: " + a);
            Console.WriteLine("Колличество слов: " + Value.CountWords);
            Console.WriteLine("Вывод слова по номеру: " + Value.ReturnWordString(54));
            char[] c = { 'о', 'р', 'д', 'е', 'н' };
            Console.WriteLine(Value.OutputSentence(c));
            #region OutPutPosition
            /*
            int[,] matrix = new int[value.CountWords, 2];
            matrix = value.PositionWords;
            for (int i = 0; i < value.CountWords; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            */
            #endregion
            Console.ReadKey();
        }
    }
}
