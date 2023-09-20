using System.Collections;

namespace ArrayList 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 1, 2, 3, 4, 5, 6 };
            ArrayList<int> arrList = new ArrayList<int>(array);
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
           

        }

        static void Print(IEnumerable arr)
        {
            foreach (var el in arr)
            {
                Console.Write(el.ToString() + " ");
            }
            Console.WriteLine();
        }
    }
}