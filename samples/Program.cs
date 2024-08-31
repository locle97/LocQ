using System.Diagnostics;

Stopwatch sw = new Stopwatch();
sw.Start();

List<int> list1 = new(), list2 = new();

for (int i = 0; i < 100000000; i++)
{
    list1.Add(i);
    list2.Add(i);
}

sw.Stop();
Console.WriteLine($"Time taken to add items in two lists: {sw.ElapsedMilliseconds} ms");

sw.Restart();
list1.Zip(list2).ToList();
sw.Stop();
Console.WriteLine($"Time taken to Zip: {sw.ElapsedMilliseconds} ms");

sw.Restart();
list1.Rar(list2).ToList();
sw.Stop();
Console.WriteLine($"Time taken to Rar: {sw.ElapsedMilliseconds} ms");
