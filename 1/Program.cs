using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;

namespace _1
{
    public class Program
    {
        static readonly HttpClient client = new HttpClient();

        public static async Task Main(string[] args)
        {
            string userInput = Console.ReadLine();
            var restrictedChars = CheckSymbols(userInput);
            if (restrictedChars.Count > 0)
            {
                Console.Write("Forbidden characters: ");
                for (int i = 0; i < restrictedChars.Count; i++)
                {
                    Console.Write(restrictedChars[i] + " ");
                }
                return;
            }
            int userInputCenter = userInput.Length / 2;
            if (userInput.Length % 2 == 0)
            {
                string substring1 = userInput.Substring(0, userInputCenter);
                string substring2 = userInput.Substring(userInputCenter, userInputCenter);
                userInput = ReverseString(substring1) + ReverseString(substring2);
            }
            else
            {
                userInput = ReverseString(userInput) + userInput;
            }

            Console.Write(userInput + "\nПодстрока с началом и концом из <aeiouy>: ");

            var (start, end) = FindStartAndEndStr(userInput);
            Console.Write(userInput.Substring(start, end - start + 1));

            Console.WriteLine("\nКоличество повторяющихся символов: ");

            var repeatingChars = CountRepeatingChars(userInput);
            foreach (var character in repeatingChars)
            {
                Console.WriteLine($"{character.Key}: {character.Value}");
            }

            if (userInput.Length != 0)
            {
                Console.WriteLine("Выберите метод сортировки QuickSort/TreeSort [q/t]: ");
                string userChoose = Console.ReadLine().ToLower();
                if (userChoose == "q")
                {
                    Console.WriteLine(QuickSort(userInput));
                }
                else if (userChoose == "t")
                {
                    Console.WriteLine(TreeSort(userInput));
                }
                else
                {
                    Console.WriteLine("Сортировка не выбрана. ");
                }


                await WriteStrWithoutOneSymbol(userInput);
            }
        }

        public static string ReverseString(string str)
        {
            string newstr = "";
            for (int i = 1; i <= str.Length; i++)
            {
                newstr += str[str.Length - i];
            }
            return newstr;
        }

        public static List<char> CheckSymbols(string str)
        {
            char[] allowedChars = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            List<char> restrictedChars = new List<char>();
            for (int i = 0; i < str.Length; i++)
            {
                if (!allowedChars.Contains(str[i]))
                {
                    restrictedChars.Add(str[i]);
                }
            }
            return restrictedChars;

        }

        public static (int, int) FindStartAndEndStr(string str)
        {
            char[] vowelsChars = "aeiouy".ToCharArray();
            List<char> vowelsCharsList = new List<char>(vowelsChars);
            if (!vowelsCharsList.Any(str.Contains))
            {
                return (0, -1);
            }
            List<int> vowelsCharsInStr = new List<int>();
            for (int i = 0; i < str.Length; i++)
            {
                if (vowelsChars.Contains(str[i]))
                {
                    vowelsCharsInStr.Add(i);
                }
            }
            return (vowelsCharsInStr[0], vowelsCharsInStr[vowelsCharsInStr.Count - 1]);

        }

        public static Dictionary<char, int> CountRepeatingChars(string str)
        {
            Dictionary<char, int> repeatingChars = new Dictionary<char, int>();
            for (int i = 0; i < str.Length; i++)
            {
                if (repeatingChars.ContainsKey(str[i]))
                {
                    repeatingChars[str[i]] += 1;
                }
                else
                {
                    repeatingChars[str[i]] = 1;
                }
            }
            return repeatingChars;
        }

        public async static Task WriteStrWithoutOneSymbol(string str)
        {
            int randNumber;
            try
            {
                client.DefaultRequestHeaders.Add("User-agent", "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:44.0) Gecko/20100101 Firefox/44.0");
                HttpResponseMessage response = await client.GetAsync("https://www.random.org/integers/?num=1&min=0&max="+(str.Length-1)+"&col=1&base=10&format=plain&rnd=new");
                randNumber = Int32.Parse(await response.Content.ReadAsStringAsync());
            } 
            catch(HttpRequestException e)
            {
                Random rand = new Random();
                randNumber = rand.Next(0, str.Length - 1);
            }
            List<char> characters = new List<char>(str.ToCharArray());
            characters.RemoveAt(randNumber);
            Console.WriteLine(string.Concat(characters));
        }

        public static string QuickSort(string str)
        {
            char[] characters = str.ToCharArray();
            if (characters.Length <= 1)
            {
                return str;
            }
            List<char> smallestChars = new List<char>();
            List<char> biggestChars = new List<char>();
            List<char> equalChars = new List<char>();
            foreach (char i in characters)
            {
                char pivot = characters[characters.Length - 1];
                if (i < pivot)
                {
                    smallestChars.Add(i);
                }
                else if (i == pivot)
                {
                    equalChars.Add(i);
                }
                else
                {
                    biggestChars.Add(i);
                }
            }
            return QuickSort(string.Concat(smallestChars)) + string.Concat(equalChars) + QuickSort(string.Concat(biggestChars));
        }

        public static string TreeSort(string str)
        {
            List<char> characters = new List<char>(str.ToCharArray());
            var treeNode = new TreeNode(characters[0]);
            for (int i = 1; i < characters.Count; i++)
            {
                treeNode.Insert(new TreeNode(characters[i]));
            }

            return treeNode.Transform();
        }
    }
    public class TreeNode
    {
        public TreeNode(char data)
        {
            Data = data;
        }
        public char Data { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
        public void Insert(TreeNode node)
        {
            if (node.Data < Data)
            {
                if (Left == null)
                {
                    Left = node;
                }
                else
                {
                    Left.Insert(node);
                }
            }
            else
            {
                if (Right == null)
                {
                    Right = node;
                }
                else
                {
                    Right.Insert(node);
                }
            }
        }
        public string Transform(List<char> elements = null)
        {
            if (elements == null)
            {
                elements = new List<char>();
            }
            if (Left != null)
            {
                Left.Transform(elements);
            }
            elements.Add(Data);
            if (Right != null)
            {
                Right.Transform(elements);
            }
            return string.Concat(elements);
        }
    }
}