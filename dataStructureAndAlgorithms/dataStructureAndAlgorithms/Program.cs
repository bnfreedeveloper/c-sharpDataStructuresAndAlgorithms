//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using dataStructureAndAlgorithms.DataStructures;
using System.Linq.Expressions;
using static dataStructureAndAlgorithms.DataStructures.ArrayStructure;
//ArrayStructure test = new ArrayStructure();
//test.Operations();

//testStr.StringConversion();
//testStr.stringAsArray();
//testStr.EscapString();
//testStr.WorkingWithArrays();
//testStr.checkPresence();
//testStr.Ordering();
//testStr.CheckEquality();
//testStr.GettingSubstring();
Console.WriteLine(ArrayStructure.checkFiveSumIsFive(new int[] { 1, 5, 6, 9, 10, 17 }));
Console.WriteLine(ArrayStructure.checkFiveSumIsFive(new int[] { 1, 5, 5, 5, 10, 17 }));
Console.WriteLine(new int[] { 1, 5, 7, 9, 10, 12 }.Count(x => x %2 ==0));

// swiping
int y = 15, x = 17;
double a = 15, b = 20;
int result;
//testRef<int> test = ArrayStructure.TestSwipe<int>;

//ArrayStructure.Swipe(ref x, ref y, ArrayStructure.TestSwipe<int>);
//ArrayStructure.Swipe(ref x, ref y, (ref int x, ref int y) =>
//{
//   result = (x * 2) +(y * 2);
//   Console.WriteLine(result);
//});

//Console.WriteLine($"x = {x} and y = {y}");

//var dic = test<int>.dico;
//Func<int, int, int> testb = (x, y) => x + y;
//var test = new KeyValuePair<string, Func<int, int, int>>("test",testb);
//dic.Add(test.Key,test.Value);

//Console.WriteLine(dic["test"](15, 20));

#region operations with arrays: find maximum values of nested array and another one sum of two lowest number of array
var nestedResult = ArrayOp.NestedArr(
    new int[][]
    {
        new int[]{15,25,98},
        new int[]{-87,-4,-98,-3},
        new int[]{},
        new int[] {-8,15,-4,98,150}
    },
    x => x < 0
    ) ;
foreach(var item in nestedResult)
{
    Console.WriteLine(item);
}

Console.WriteLine(ArrayOp.SumOfTwoLowestNumber(new int[]{84,45,12,180,5,668},(x,y)=> x + y));
#endregion

#region func,action,predicate and delegate for ref paramaters managements rules
int first = 15,second = 20;
Console.WriteLine("voici le result d'une addition : " + ArrayOp.RandomOp( ref first,ref  second, (first, second) =>
{
    //cela ne fera rien 
    first += 10;
    second += 10;
    return first + second;
}));
Console.WriteLine($"after operation without ref first = {first} and second = {second}");

Console.WriteLine("Voici l'opération précédente mais avec ref et delegate : " + ArrayOp.RandomOpWithRef(ref first,ref second, (ref int first, ref int second) =>
{
    first += 10;
    second += 10;
    return first + second;
}));
Console.WriteLine($"after operation with ref first = {first} and second = {second}");
#endregion

#region regression for the Collatz Conjecture
static int Regression(int x)
{
 
   var steps = new List<int>();
    int Calcul(int x)
    {
        if (x == 1)
        {
            //steps.Add(1);
            return steps.Count;
        }
        else
        {
            if (x % 2 == 0)
            {
                x = x / 2;
                steps.Add(1);
                return Calcul(x);
            }
            else
            {
                x = x * 3 + 1;
                steps.Add(1);
                return Calcul(x);
            }
        }
    }
    return Calcul(x);
    
}

Console.WriteLine($"number of steps for Number 10 :{Regression(10)}");
Console.WriteLine($"number of steps for Number 20(normally on steps more compare to 10) :{Regression(20)}");
#endregion

#region count number of positives and negatives numbers in an array, with use array of expression func or array of func only
Expression<Func<Double, bool>> testNegativesNumbers = x => x <0;
Expression<Func<Double, bool>> testPositivesNumbers = x => x > 0;

var resultComp = ArrayOp.PositiveNegativeSum(new double[] {15,25,19,-87,74,-36,-78,14},
    new Expression<Func<Double, bool>>[] {testNegativesNumbers,testPositivesNumbers} );
Console.WriteLine("nombre d'éléments inférieurs à 0 :" + resultComp[0]);
Console.WriteLine("number of elements superior to 0 : " +resultComp[1]);
var resultBis = ArrayOp.PositiveNegativeSumBis(new double[] { 15, 25, 19, -87, 74, -36, -78, 14 }, new Func<double, bool>[] { x => x < 0, x => x > 0 });
Console.WriteLine("nombre d'éléments inférieurs à 0 :" + resultBis[0]);
Console.WriteLine("number of elements superior to 0 : " + resultBis[1]);
#endregion

#region chain filters on array with expression delegate 
var expressionsForFilteringIntArray = new Expression<Func<int, bool>>[]
{
    x => x > 0,
    x => x > 20,
    x => x > 25 && x < 60
};
var resultFilteredArray = ArrayOp.ChainFiltering(new int[] { 15, 36, 45, 87, 12, 9, 100, 55 }, expressionsForFilteringIntArray);
Array.ForEach(resultFilteredArray, x => Console.WriteLine(x));
#endregion
Console.ReadLine(); 

