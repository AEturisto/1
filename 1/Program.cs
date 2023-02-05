namespace _1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userInput = Console.ReadLine();
            List<char> restrictedChars = checkSymbols(userInput);

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
            Console.WriteLine( userInput );
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

        static List<char> checkSymbols(string str)
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
    }
}