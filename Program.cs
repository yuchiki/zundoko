using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using static Zdk;

static class Program {
    static Random random = new Random();
    static IEnumerable<int> Infinite() { while (true) yield return 0; }
    static T AtRandom<T>(params T[] args) => args[random.Next(args.Length)];

    static Zdk[] pattern = { Zun, Zun, Zun, Zun, Doko };
    static void Main() =>
        Infinite().Select(_ => AtRandom(Zun, Doko))
        .Scan(new Queue<Zdk>(), (q, zd) => q.History(zd, 6))
        .TakeWhile(x => !x.Take(5).SequenceEqual(pattern))
        .Select(x => x.Last()).Cast<object>().ForEach(WriteLine);
}

enum Zdk { Zun, Doko, Kiyoshi }

static class QueueExtention {
    public static Queue<T> History<T>(this Queue<T> queue, T item, int size) {
        queue.Enqueue(item);
        if (queue.Count > size) queue.Dequeue();
        return queue;
    }
}
