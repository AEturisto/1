using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace _1.tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public static void ReverseString_abcd_bcda()
        {
            string input = "abcd";
            string expect = "dcba";
            string result = Program.ReverseString(input);
            if(result == expect)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }
        [Test]
        public static void ReverseString_a1_1a()
        {
            string input = "a1";
            string expect = "1a";
            string result = Program.ReverseString(input);
            if (result == expect)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public static void CheckSymbols_qwertyuiopasdfghjklzxcvbnm_0()
        {
            string input = "qwertyuiopasdfghjklzxcvbnm";
            int expect = 0;
            List<char> result = Program.CheckSymbols(input);
            if (result.Count() == expect)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public static void CheckSymbols_1234567890qwertyuiopasdfghjklzxcvbnm_10()
        {
            string input = "1234567890qwertyuiopasdfghjklzxcvbnm";
            int expect = 10;
            List<char> result = Program.CheckSymbols(input);
            if (result.Count() == expect)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public static void FindStartAndEndStr_awwwa_0_4()
        {
            string input = "awwa";
            int expectStart = 0;
            int expectEnd = 3;
            var(start,end) = Program.FindStartAndEndStr(input);
            if (start == expectStart && end == expectEnd)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public static void FindStartAndEndStr_awww_0_0()
        {
            string input = "awww";
            int expectStart = 0;
            int expectEnd = 0;
            var (start, end) = Program.FindStartAndEndStr(input);
            if (start == expectStart && end == expectEnd)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public static void QuickSort_qwertyuiopasdfghjklzxcvbnm_()
        {
            string input = "qwertyuiopasdfghjklzxcvbnm";
            string expect = "abcdefghijklmnopqrstuvwxyz";
            var start = Program.QuickSort(input);
            if (start == expect)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public static void TreeSort_qwertyuiopasdfghjklzxcvbnm_()
        {
            string input = "qwertyuiopasdfghjklzxcvbnm";
            string expect = "abcdefghijklmnopqrstuvwxyz";
            var start = Program.TreeSort(input);
            if (start == expect)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public static void TreeSort_qwertyuiopasdfghjklzxcvbnm1234567890_()
        {
            string input = "qwertyuiopasdfghjklzxcvbnm1234567890";
            string expect = "0123456789abcdefghijklmnopqrstuvwxyz";
            var start = Program.TreeSort(input);
            Console.WriteLine(start);
            if (start == expect)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public static void QuickSort_qwertyuiopasdfghjklzxcvbnm1234567890_()
        {
            string input = "qwertyuiopasdfghjklzxcvbnm1234567890";
            string expect = "0123456789abcdefghijklmnopqrstuvwxyz";
            var start = Program.QuickSort(input);
            Console.WriteLine(start);
            if (start == expect)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }
    }
}