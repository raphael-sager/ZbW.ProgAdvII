using System;
using System.Collections;
using System.Collections.Generic;

namespace _2_CityCollection {
    public class CityCollection : IEnumerable {
        private string[] cities = {"Bern", "Basel", "Zürich", "Rapperswil", "Genf"};
        public IEnumerable<string> Reverse { get; set; }

        // TODO: Members für Test-Code in Main()-Methode erstellen

        public IEnumerator GetEnumerator()
        {
            return new CityEnumerator(this);
        }

        public class CityEnumerator : IEnumerator
        {
            private CityCollection _cities;
            private int _index = -1;

            public CityEnumerator(CityCollection cities)
            {
                _cities = cities;
            }
            public bool MoveNext()
            {
                _index++;
                return _index <= _cities.cities.Length -1;
            }

            public void Reset()
            {

            }

            public object Current => _cities.cities[_index];
        }
    }

    class Program {
        static void Main(string[] args) {
            CityCollection myColl = new CityCollection();

            // Ausgabe
            foreach (string s in myColl)
            {
                Console.WriteLine(s);
            }

            //Ausgabe in umgekehrter Reihenfolge
            foreach (string s in myColl.Reverse)
            {
                Console.WriteLine(s);
            }

            Console.ReadKey();
        }
    }
}