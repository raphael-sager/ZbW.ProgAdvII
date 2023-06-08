using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _2_CityCollection {
    public class CityCollection1 : IEnumerable {
        private string[] cities = {"Bern", "Basel", "Zürich", "Rapperswil", "Genf"};

        // TODO: Members für Test-Code in Main()-Methode erstellen
        public IEnumerable<string> Reverse => cities.Reverse();

        public IEnumerator GetEnumerator()
        {
            return new CityEnumerator(this);
        }

        public class CityEnumerator : IEnumerator
        {
            private CityCollection1 _cities;
            private int _index = -1;

            public CityEnumerator(CityCollection1 cities)
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

    public class CityCollection2 : IEnumerable
    {
        private string[] cities = { "Bern", "Basel", "Zürich", "Rapperswil", "Genf" };

        // TODO: Members für Test-Code in Main()-Methode erstellen
        public IEnumerable<string> Reverse => cities.Reverse();

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < cities.Length - 1; i++)
            {
                yield return cities[i];
            }
        }
    }

    class Program {
        static void Main(string[] args) {
            CityCollection1 myColl = new CityCollection1();

            // Ausgabe
            //foreach (string s in myColl)
            //{
            //    Console.WriteLine(s);
            //}

            //Console.WriteLine(Environment.NewLine + "Umgekehrte Reihenfolge:");

            //Ausgabe in umgekehrter Reihenfolge
            //foreach (string s in myColl.Reverse)
            //{
            //    Console.WriteLine(s);
            //}




            // mit yield

            CityCollection2 myColl2 = new CityCollection2();

            // Ausgabe
            Console.WriteLine("mit yield");
            foreach (string s in myColl2)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine(Environment.NewLine + "Umgekehrte Reihenfolge:");

            //Ausgabe in umgekehrter Reihenfolge
            foreach (string s in myColl2.Reverse)
            {
                Console.WriteLine(s);
            }

            Console.ReadKey();
        }
    }
}