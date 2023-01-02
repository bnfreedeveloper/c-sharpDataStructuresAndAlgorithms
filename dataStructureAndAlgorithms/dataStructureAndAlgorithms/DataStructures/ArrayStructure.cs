using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace dataStructureAndAlgorithms.DataStructures
{
    public class ArrayStructure
    {

        public static void Operations()
        {
            //insertion at the end of an array
            int[] test = new int[6];
            for (int i = 0; i < test.Length; i++)
            {
                test[i] = i;
            }
            foreach (var i in test)
            {
                Console.WriteLine(i);
            }

            //reversing an arrray
            var test2 = new int[test.Length];
            for (int i = test.Length - 1; i >= 0; i--)
            {
                test2[i] = test[test.Length - 1 - i];
            }
            foreach (int i in test2)
            {
                Console.WriteLine(i);
            }

            //shifting elements of array starting a specific index
            //i'm gonna start from the value 2

            var index = Array.IndexOf(test2, 2);
            //we shif 2 elements
            for (int i = index; i < test2.Length - 2; i++)
            {
                test2[i + 1] = test2[i - 1];



            }
            foreach (int i in test2)
            {
                Console.WriteLine(i);
            }
        }

        public static bool checkFiveSumIsFive(int[] test)
        {
            return test.Where(x => x == 5).Sum() == 15;
        }
        public delegate void testRef<U>(ref U x, ref U y) where U : struct;
        public static void Swipe<T>(ref T x, ref T y, testRef<T> test) where T : struct {
            test(ref x, ref y);
        }

        public static void TestSwipe<T>(ref T x, ref T y) where T : struct
        {
            var test = y;
            y = x;
            x = test;

        }



    }

    public class test<T>
    {
        public static Dictionary<string, Func<T, T, T>> dico = new Dictionary<string, Func<T, T, T>>();
    }
    public delegate bool compareNegativesValues<T>(T val);
    public static class ArrayOp{

        public static T[] NestedArr<T>(T[][] nestedArr,compareNegativesValues<T>compare) where T:struct
        {
            var maxOfEachArray = new List<T>();
            foreach(var tab in nestedArr)
            {
                if (tab.Length > 0)
                {
                    if (tab.All(x => compare(x)))
                    {
                        maxOfEachArray.Add(tab.Max());
                    }
                    else
                    {
                        maxOfEachArray.Add(tab.Max());
                    }
                }
                else continue;
                
            }
            return maxOfEachArray.ToArray();

        }
        public static T SumOfTwoLowestNumber<T>(T[] arr,Func<T,T,T> calcul)
        {
            //var numbersOrdered = new List<T>(); 
            //numbersOrdered.AddRange(arr);
            //numbersOrdered.Sort();
            Array.Sort(arr);
            var result = arr.Take(2).ToList();
            return calcul(result[0],result[1]);   

        }
        //here we can not use ref with func,action,or predicate
        public static T RandomOp<T>( ref T x, ref T y, Func<T, T, T> computation)
        {
            return computation(x, y);
        }
       
        public static T RandomOpWithRef<T>(ref T x, ref T y, calculWithRef<T> opRef)
        {
            return opRef(ref x, ref y); 
        }
        public static int[] PositiveNegativeSum<T>(T[] values, Expression<Func<T, bool>>[] checkValues)
        {
            var result = new List<int>();
            var totalNegativesNumber = values.Count(x => checkValues[0].Compile().Invoke(x));
            var totalPositivesNumber = values.Count(x => checkValues[1].Compile().Invoke(x));
            result.AddRange(new int[] { totalNegativesNumber, totalPositivesNumber });
            return result.ToArray();

        }
        public static int[] PositiveNegativeSumBis(double[] values,Func<double,bool>[] checkValues)
        {
            var result = new List<int>();
            var totalNegativesNumber = values.Count(x =>checkValues[0](x));
            var totalPositivesNumber = values.Count(x => checkValues[1](x));
            result.AddRange(new int[] { totalNegativesNumber, totalPositivesNumber });
            return result.ToArray();

        }

        public static T[] ChainFiltering<T>(T[] arr, Expression<Func<T,bool>>[] filters)
        {
            var result = arr.AsQueryable();

            if (filters.Length == 0) return arr;
            else
            {
                foreach(var filter in filters)
                {
                    result = result.Where(filter);  
                }
            }
            return result.ToArray();
        }
    }

#region delegates
    //if i want to use ref i need to use a delegate 
    public delegate T calculWithRef<T>(ref T x, ref T y);
#endregion
}
