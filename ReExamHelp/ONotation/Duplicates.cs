using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReExamHelp.ONotation
{
    public class Duplicates
    {
        public int[] numbers { get; set; }

        //O(n^2)
        public bool containsDuplicates1() {
            for (int i = 0; i < numbers.Length; i++) {
                for (int j = 0; j < numbers.Length; j++) {
                    if (j != i && numbers[j] == numbers[i]) {
                        return true;
                    }
                }
            }
            return false;
        }

        //O(n^2)
        public bool constainsDuplicates2() {
            List<int> seenNumbers = new();
            for (int i = 0; i < numbers.Length; i++) {
                for(int j =0; j<seenNumbers.Count;j++)
                    if (numbers[i] == seenNumbers[j]) {
                        return true;
                    }
                    seenNumbers.Add(numbers[i]);
            }
            return false;
        }
        
        //O(???)
        public bool constainsDuplicates3()
        {
            List<int> seenNumbers = new();
            foreach (int i in numbers) {
                if (seenNumbers.Contains(i))
                {
                    return true;
                }
                seenNumbers.Add(i);
            }
            return false;
        }

        //O(???)
        public bool containsDuplicates4() {
            HashSet<int> seenNumbers = new();
            foreach (int i in numbers) {
                if (seenNumbers.Contains(i)) { 
                    return true;
                }
            }
            return false;
        }

        //O(???)
        public bool containsDuplicates5() {
            Array.Sort(numbers);
            for(int i = 0; i<numbers.Length-1; i++) {
                if (numbers[i] == numbers[i + 1]) {
                    return true;
                }
            }
            return false;
        }



    }
}
