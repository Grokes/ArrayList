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
            arrList.Add(0,7);
            Print(arrList);
            Console.WriteLine(arrList.Max());
            Console.WriteLine(arrList.Min());
            arrList.Delete(0);
            arrList.Delete(2);
            Print(arrList);
            arrList.Remove(10);
            Print(arrList);
            foreach (var el in arrList)
            {
                Console.WriteLine(el.ToString());
            }

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