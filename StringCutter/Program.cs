using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCutter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert complete file path: ");
            string file = Console.ReadLine();
            int fileLength = countLines(file);

            string[] arr = new string[fileLength];
            arr = fileContent(file, fileLength);
            cutwords(arr);
            while (true) ;
        }

        private static void cutwords(string[] arr)
        {
            List<string> word = new List<string>();
            int length = arr.Length;
            for (int i = 0; i < length; i++)
            {
                char[] letter = new char[arr[i].Length];
                letter = arr[i].ToCharArray();
                word.Clear();
                for(int k = 0; k <= arr[i].Length; k++)
                {               
                    int y = letter.Length;
                    while (y != 0)
                    {
                        int c = y;
                        char[] tmp = new char[c];
                        for(int x = 0; x < c; x++)
                        {
                            tmp[x] = letter[x];
                            Console.Write(letter[x]);
                            word.Add(tmp[x].ToString());
                        }
                        Console.Write(" ");
                        word.Add(" ");
                        y -= 1;
                    }
                    if(letter.Length-1 != -1)
                    letter = reduceLetter(letter);
                }
                Console.Write("\n");
                writeToFile(word, arr[i]);
            }
        }

        private static void writeToFile(List<string> word, string arr)
        {
            string final = "";
            for(int i = 0; i < word.Count; i++)
            {
                final += word[i];
            }
            string file = arr + ".txt";
            using (StreamWriter writer = new StreamWriter(file))
            {
                writer.Write(final);                
            }
        }

        private static char[] reduceLetter(char[] letter)
        {
            char[] reducedletter = new char[letter.Length-1];

            for(int i = 0; i < letter.Length-1; i++)
            {
                reducedletter[i] = letter[i+1];
            }

            return reducedletter;
        }

        private static string[] fileContent(string file, int length)
        {
            string[] content = new string[length];
            int i = 0;
            using (StreamReader r = new StreamReader(file))
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    content[i] = line;
                    i++;
                }
            }
            return content;
        }

        private static int countLines(string file)
        {
            int count = 0;
            using (StreamReader r = new StreamReader(file))
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
