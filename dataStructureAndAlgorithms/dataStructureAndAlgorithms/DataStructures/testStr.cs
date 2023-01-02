using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataStructureAndAlgorithms.DataStructures
{
    public static class testStr
    {

        public static void StringConversion()
        {
            string testString = "tHis iS tHe FBI Calling";
            string result;
            result = testString.ToLower();
            Console.WriteLine(result);  
            result = testString.ToUpper();
            Console.WriteLine(result);
        }
        public static void stringAsArray()
        {
            string testString = "Timothy";
            for(int i = 0; i < testString.Length; i++)
            {
                Console.WriteLine(testString[i]);
            }
        }

        public static void EscapString()
        {
            string result;
            result = "this is my \"test\"";
            Console.Write(result);  
        }
        public static void WorkingWithArrays()
        {
            int [] ages = new[] {1,2,3,4,5,6};
            string result;
            result = String.Concat(ages);
            Console.WriteLine(result);
            result = String.Join("test ",ages);
            Console.WriteLine(result);

            string testString = "helo,fsqf,fqsfsdqf,fqsdfq";
            string[] tests = testString.Split(",");
            foreach(string test in tests)
            {
                Console.WriteLine(test);
            }
        }

        public static void checkPresence()
        {
            string testString = "i'm gonna test if things work out, test fsqfdsqftest test";
            bool result;
            int resultIn;
            result = testString.All(x => x != 'z');
            Console.WriteLine("result with all method from linq " + result);
            result = testString.StartsWith("i'm");
            Console.WriteLine(result);
           var linqResult = testString.Select((char x, int i) =>
            {
                if (i % 2 == 0) return x.ToString();
                else return 'e'.ToString();
            }).ToList();
            Console.WriteLine(String.Concat(linqResult));
            Console.WriteLine(testString.Contains("test"));

            Console.WriteLine($"index de test: {testString.IndexOf("test")}");
            Console.WriteLine("comparaison de strings " + "hello".CompareTo("hello"));

            int indexTest = testString.IndexOf(" test "); ;
            var resultTest = new List<int>();

            if (indexTest != -1)
            {
                do
                {

                    resultTest.Add(1);
                    indexTest = testString.IndexOf("test", indexTest +"test".Length );

                } while (indexTest != -1);
            }
            Console.WriteLine($"nombre de fois que test est présent : {resultTest.Sum()}");
            
        }

        public static void Ordering()
        {
            void ComparerString(string a , string? b)
            {
                var result = a.CompareTo(b);
                switch (result)
                {
                    case > 0:
                        Console.WriteLine($"{b ?? "null"} comes before {a}");
                        break;
                    case 0:
                        Console.WriteLine("same order");
                        break;
                    case < 0:
                        Console.WriteLine($"{b ?? "null"} comes after {a}");
                        break;
                    
                }
            }
            ComparerString("salut",null);
            ComparerString("salut","solo");


        }
        public static void CheckEquality()
        {
            void equalityHelper(string? a,string? b)
            {
                bool result;
                result = String.Equals(a,b,StringComparison.InvariantCultureIgnoreCase);
                if (result) Console.WriteLine($"same string : {a} == {b} ");
                else Console.WriteLine($"{a} and {b} are differents");
            }
            equalityHelper("bob", "mary");
            equalityHelper("yooo", "yooo");
            equalityHelper(null, "");
            equalityHelper(" ", "");
            Console.WriteLine(null == " ");
            equalityHelper("bob", "BOB");
            Console.WriteLine(String.Compare("bob","BOB",StringComparison.InvariantCultureIgnoreCase));
        }

        public static void GettingSubstring()
        {
            string testString = "this is a test string. just for practicing substring";
            string result = testString.Substring(5);
            Console.WriteLine(result);
            //extract a specific string 
            if (testString.Contains("test"))
            {
                var index = testString.IndexOf("test"); 
                Console.WriteLine(testString.Substring(index,"test".Length));   
            }

            var resultFromReplace = testString.Replace("test", "trial");
            Console.WriteLine(resultFromReplace);  
            
        }
    }
}
