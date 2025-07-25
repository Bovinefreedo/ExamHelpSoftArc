using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReExamHelp._5CountryArray
{
    public class Spg5CountryArray
    {
        string[] contries;
        public int count = 0;

        public Spg5CountryArray(int length)
        {
            contries = new string[length];
        }
        public bool insertCountry(int index, string country) {
            for (int i = 0; i < contries.Length; i++) {
                int tryIndex = (i + index) % contries.Length;
                if (contries[tryIndex] == null) {
                    contries[tryIndex] = country;
                    count++;
                    return true;
                }
            }
            return false;
        }

        public bool contains(string country) {
            for (int i = 0; i < contries.Length; i++) {
                if (contries[i] != null && contries[i] == country) {
                    return true;
                }
            }
            return false;
        }

        public bool deleteCountry(string country) {
            for (int i = 0; i < contries.Length; i++)
            {
                if (contries[i] != null && contries[i] == country)
                {
                    contries[i] = null!;
                    count--;
                    return true;
                }
            }
            return false;
        }

        public string printArray() {
            string result = "[";
            for (int i = 0; i < contries.Length; i++) {
                if (contries[i] == null) {
                    result += "null";
                }
                else
                {
                    result += contries[i];
                }
                result += ", ";
            }
            result += "]";
            return result;
        }
    }

//    Spg5CountryArray spg5 = new Spg5CountryArray(7);

//    Console.WriteLine(spg5.printArray());
//spg5.insertCountry(3, "Tyskland");
//Console.WriteLine(spg5.printArray());
//Console.WriteLine(spg5.count);
//spg5.insertCountry(6, "Norge"); 
//spg5.insertCountry(6, "Sverige");
//spg5.insertCountry(3, "Italien");
//Console.WriteLine(spg5.printArray());
//Console.WriteLine(spg5.count);
//Console.WriteLine($"Tyskland er i arrayet: {spg5.contains("Tyskland")}");
//spg5.deleteCountry("Tyskland");
//Console.WriteLine(spg5.printArray());
//Console.WriteLine(spg5.count);
//Console.WriteLine($"Tyskland er i arrayet: {spg5.contains("Tyskland")}");
}
