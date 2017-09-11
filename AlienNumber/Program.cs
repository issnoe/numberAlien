using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            bool c = true;
            do
            {
                c = control();
            } while (c);

        }
        static bool control()
        {
            Console.Clear();

            Console.Write("Número a convertir:");
            var number = Console.ReadLine();
            Console.Write("Source:");
            var sourceLanguage = Console.ReadLine();
            Console.Write("Target:");
            var targetLanguage = Console.ReadLine();
            var convert = translateNumber(number, sourceLanguage, targetLanguage);
            Console.Write("R:" + convert);
            Console.Write("\ny->continuar, n->salir\nENTER\n");
            return (Console.ReadLine().ToString() == "y" ? true : false);
        }
        static string translateNumber(string number, string sourceLanguage, string targetLanguage)
        {
            double input = 0;
            double lengthSL = sourceLanguage.Length;
            double lengthTL = targetLanguage.Length;
            string result = "";

            for (int i = 0; i < number.Length; i++)
            {
                var iterNumber = number[i];
                int indexC = sourceLanguage.IndexOf(iterNumber);
                var pot = Math.Pow(lengthSL, number.Length - 1 - i);
                input = input + (indexC *pot);
            }

            double index = Math.Floor(Math.Log(input, lengthTL));
            while (index >= 0)
            {
                int digit = (int)(Math.Floor(input / Math.Pow(lengthTL, index)));
                result = result + targetLanguage[digit].ToString();
                input = input - (digit * Math.Pow(lengthTL, index));
                index--;
            }

            return result;
        }
    }
}
