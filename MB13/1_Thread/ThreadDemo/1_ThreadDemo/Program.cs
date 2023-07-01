using System;
using System.Threading;

internal class Program {
    private static void Main() {
        //StartThreads();
        //return;

        //Thread.CurrentThread.Join();

        Console.WriteLine("[{0}] Main called", Thread.CurrentThread.ManagedThreadId);
        Console.WriteLine("[{0}] Processor/core count = {1}",
            Thread.CurrentThread.ManagedThreadId,
            Environment.ProcessorCount);

        var t = new Thread(SayHello) {
            Name = "Hello Thread",
            Priority = ThreadPriority.BelowNormal
        };
        t.Start();
        t.Join();

        Console.WriteLine("[{0}] Main done", Thread.CurrentThread.ManagedThreadId);
        Console.ReadLine();

        /*
         * Ausgabe:
         *
         * [1] Main called
         * [1] Processor/core count = 32
         * [3] Hello, world!
         * [1] Main done
         *
         * Wobei ohne Join() nicht garantiert ist, dass die letzten zwei Zeilen genau in dieser Reihenfolge abgearbeitet werden!
         * Der Scheduler der CLR entscheidet.
         */
    }

    private static void SayHello() {
        Console.WriteLine("[{0}] Hello, world!", Thread.CurrentThread.ManagedThreadId);
    }


    private static void StartThreads() {
        var t1 = new Thread(new ThreadStart(delegate { Write("Anna"); }));
        var t2 = new Thread(new ThreadStart(delegate { Write("Paul"); }));

        t1.Start();
        t2.Start();
    }

    private static void Write(string name) {
        for (var i = 0; i < 100; i++) {
            Console.Write($"{name} ");
        }
    }
}