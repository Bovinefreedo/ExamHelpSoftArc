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
}
