using System;
using System.Collections;
using System.Collections.Generic;

namespace _1._1_ExtensionMethods_QueryOperators {
    /// <summary>
    /// Dokumentation der offiziellen LINQ Extension Methods:
    /// http://msdn.microsoft.com/en-us/library/system.linq.enumerable_methods.aspx
    /// 
    /// Nutzen Sie diese Dokumentation um Ihre Extension Methods zu implementieren.
    /// Sie finden dort auch die Beschreibung, was die Methode effektiv für einen Effekt hat.
    /// </summary>
    public static class Extensions {
        // TODO: ZbwForEach
        public static void ZbwForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
            {
                action(item);
            }
        }

        // TODO: ZbwWhere
        public static IEnumerable<T> ZbwWhere<T>(this IEnumerable<T> source, Predicate<T> predicate)
        {
            foreach (var i in source)
            {
                if (predicate(i))
                {
                    yield return i;
                }
            }
        }

        // TODO: ZbwOfType
        public static IEnumerable<T> ZbwOfType<T>(this IEnumerable source)
        {
            foreach (var item in source)
            {
                if (item is T)
                {
                    yield return (T)item;
                }
            }
        }

        // TODO: ZbwToList
        public static List<T> ZbwToList<T>(this IEnumerable<T> source)
        {
            return new List<T>(source);
        }

        // TODO: ZbwSum
        public static int ZbwSum<T>(this IEnumerable<T> source, Func<T, int> selector)
        {
            int sum = 0;

            foreach (var item in source)
            {
                sum += selector(item);
            }
            return sum;
        }
    }
}