using ReExamHelp.Andet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReExamHelp.Andet
{
    public class BinarySearch
    {
        public static bool contains(int[] numbers, int target) {
            int max = numbers.Length - 1;
            int min = 0;
            while (max >= min) {
                int middle = min + ((max-min) / 2);
                if (target == numbers[middle])
                {
                    return true;
                }
                else if (target > numbers[middle])
                {
                    min = middle + 1;
                }
                else {
                    max = middle - 1;
                }
            }
            return false;
        }
    }
}

//int[] numbers = new int[] { 1, 20, 40, 66, 70, 102, 134, 234, 654, 5767, 8457987 };

//Console.WriteLine(BinarySearch.contains(numbers, 8457987));
