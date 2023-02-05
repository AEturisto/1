namespace _1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userInput = Console.ReadLine();
            var restrictedChars = CheckSymbols(userInput);
            if (restrictedChars.Count > 0 )
            {
                Console.Write("Forbidden characters: ");
                for (int i = 0; i < restrictedChars.Count; i++)
                {
                    Console.Write(restrictedChars[i] + " ");
                }
                return;
            }

            int userInputCenter = userInput.Length / 2;
            if ( userInput.Length % 2 == 0) {
                string substring1 = userInput.Substring( 0, userInputCenter );
                string substring2 = userInput.Substring( userInputCenter, userInputCenter );
                userInput = ReverseString( substring1 ) + ReverseString( substring2 );
            } else
            {
                userInput = ReverseString( userInput ) + userInput;
            }
            Console.WriteLine( userInput + "\n\nКоличество повторяющихся символов: ");
            var repeatingChars = CountRepeatingChars( userInput );
            foreach (var character in repeatingChars)
            {
                Console.WriteLine($"{character.Key}: {character.Value}");
            }

        }

        static string ReverseString(string str)
        {
            string newstr = "";
            for (int i = 1; i <= str.Length; i++)
            {
                newstr += str[str.Length - i];
            }
            return newstr;
        }

        static List<char> CheckSymbols(string str)
        {
            char[] allowedChars = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            List<char> restrictedChars = new List<char>();
            for (int i = 0; i < str.Length; i++)
            {
                if ( !allowedChars.Contains(str[i]) )
                {
                    restrictedChars.Add(str[i]);
                }
            }
            return restrictedChars;

        }

        static Dictionary<char, int> CountRepeatingChars(string str)
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
    }
}