using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ReExamHelp.CityArray
{
    public class CityArray {

        public string[] cities = new string[10];

        public CityArray(int arrayLength) { 
            cities = new string[arrayLength];
        }

        public bool insertCity(string name, int index) {
            if (index < 0 || index >= cities.Length) {
                return false;
            }
            for (int i = 0; i < cities.Length; i++)
            {
                if (cities[(i+index)%cities.Length] == null)
                {
                    cities[(i+index)%cities.Length] = name;
                    return true;
                }
            }
            return false;
        }

        public bool containsCity(string name) {
            for (int i = 0; i < cities.Length; i++) {
                if (cities[i] != null && cities[i] == name) {
                    return true;
                }
            }
            return false;
        }

        public bool removeCity(string name) {
            for (int i = 0; i < cities.Length; i++)
            {
                if (cities[i] != null && cities[i] == name)
                {
                    cities[i] = name;
                    return true;
                }
            }
            return false;
        }

        public int count() {
            return 0;
        }
    
    }
}
