using System;
using System.Collections;
using System.Collections.Generic;

namespace _6_ExtensionMethodsSimple {
    public static class Extensions {
        /****** ZbwMultipleOf ******/

        // TODO: Operator 'ZbwMultipleOf' implementieren / Gibt alle Werte zurück, bei denen "x % factor" == 0 ist
        public static IEnumerable<int> ZbwMultipleOf(this IEnumerable<int> source, int factor)
        {
            foreach (var i in source)
            {
                if (i % factor == 0)
                {
                    yield return i;
                }
            }
        }
        

        /****** ZbwWhere ******/

        // TODO: Operator 'ZbwWhere' implementieren / Gibt alle Werte zurück, bei denen ein "Predicate<T>" true liefert
        public static IEnumerable<T> ZbwWhere<T>(this IEnumerable<T> input, Predicate<T> pred)
        {
            foreach (var i in input)
            {
                if (pred(i))
                {
                    yield return i;
                }
            }
        }
    }
}