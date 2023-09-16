using System.Collections;

namespace ArrayList 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 1, 2, 3, 4, 5, 6 };
            ArrayList arrList = new ArrayList(array);
            Print(arrList);
            arrList.Add(10);
            arrList.Add(10);
            arrList.Add(10);
            arrList.Add(7,7);
            Print(arrList);
            Console.WriteLine(arrList.Max());
            Console.WriteLine(arrList.Min());
            arrList.Decreathlength();
        }

        static void Print(ArrayList arr)
        {
            for (int i = 0; i < arr.Count; ++i)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
    }
}