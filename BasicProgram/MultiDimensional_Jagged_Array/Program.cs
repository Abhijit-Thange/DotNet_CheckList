using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiDimensional_Jagged_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Rectangular Array..

            int[,] array = { { 1, 2, 3, 4 }, 
                             { 5, 6, 7, 8 },
                             { 9, 10, 11, 12 } };

          /*  foreach(int i in array)
            {
                Console.WriteLine(i);
            }*/

            for(int i=0;i<array.GetLength(0);i++)
            {
                for(int j=0;j<array.GetLength(1);j++)
                {
                   // Console.WriteLine(array[i,j] + " ");
                }
            }


            //Jagged Array....

            int[][] arr = new int[3][];
            arr[0] = new[] { 1, 2, 2, 4 };
            arr[1] = new[] { 3, 4, 5, 6,7,8,9 };
            arr[2] = new[] { 10, 11 }; 

            for(int i=0;i<arr.GetLength(0);i++)
            {
                for(int j = 0; j < arr[i].Length; j++)
                {
                  // Console.WriteLine(arr[i][j]);
                }
            }

            foreach(int[] i in arr)
            {
                foreach(int j in i)
                {
                    Console.WriteLine(j);
                }

            }



            Console.ReadLine();
        }
    }
}
