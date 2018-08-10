using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using static Zdk;

static class Program {
    static Random random = new Random();
    static void Main() => Infinite().Select(_ => AtRandom(Zun, Doko)).Judge().ForEach(WriteLine);
    static IEnumerable<int> Infinite() { while (true) yield return 0; }
    static T AtRandom<T>(params T[] args) => args[random.Next(args.Length)];

    static IEnumerable<object> Judge(this IEnumerable<Zdk> source) {
        var history = new Queue<Zdk>();

        foreach (var zdk in source) {
            yield return zdk;
            history.SizedEnqueue(zdk, 5);
            Zdk[] pattern = { Zun, Zun, Zun, Zun, Doko };
            if (history.SequenceEqual(pattern)) break;
        }
        yield return Kiyoshi;
    }
}

enum Zdk { Zun, Doko, Kiyoshi }

static class QueueExtention {
    public static void SizedEnqueue<T>(this Queue<T> queue, T item, int size) {
        queue.Enqueue(item);
        if (queue.Count > size) queue.Dequeue();
    }
}
