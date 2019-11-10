using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question1
{
    class Program
    {
        static void Main(string[] args)
        {
            string givenSentence = "Please replace all characters equals to the letter 'A' with an underscore(_)";
            Console.WriteLine("Original Sentence: {0} \n",givenSentence);
            string replacedSentence=ReplaceChar(givenSentence);
            Console.WriteLine("Sentance with Replaced characters: {0} \n",replacedSentence);
            Console.WriteLine("Please press any key to exit...");

            Console.ReadKey();
        }

        private static string ReplaceChar(string givenSentence)
        {
            char[] charArray = givenSentence.ToCharArray();
            for (int i = 0; i < charArray.Length; i++)
            {
                char character = charArray[i];
                if (character.Equals('a') ||character.Equals('A'))
                    charArray[i] = '_';
            }
            givenSentence = new string(charArray);
            return givenSentence;
        }
    }
}
