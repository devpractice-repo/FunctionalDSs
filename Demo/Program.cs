using static FnDS.Maps.TotalMapFns.TotalMapFn;
using static FnDS.Maps.PartialMapFns.PartialMapFn;
using FnDS.Maps.PartialMapFns;

namespace MapAsFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // TotalMap
            Console.WriteLine("=== TotalMap Demo ===");
            var tm1 = TUpdate(TUpdate(TEmpty<string, int>(-1), "orange", 1), "apple", 2);

            Console.WriteLine($"Default value of tm1: {tm1("test")}");
            Console.WriteLine($"at \"orange\": {tm1("orange")}");
            Console.WriteLine($"at \"apple\": {tm1("apple")}");
            Console.WriteLine();

            Func<TotalMap<string, int>, string, int, TotalMap<string, int>> t_update = TUpdate<string, int>;
            Func<int, TotalMap<string, int>> t_empty = TEmpty<string, int>;

            var tm2 = t_update(t_update(t_empty(-1), "foo", 1), "bar", 2);

            Console.WriteLine($"Default value of tm2: {tm2("test")}");
            Console.WriteLine($"at \"foo\": {tm2("foo")}");
            Console.WriteLine($"at \"bar\": {tm2("bar")}");
            Console.WriteLine();

            // PartialMap
            Console.WriteLine("=== PartialMap Demo ===");

            var pm1 = PUpdate(PUpdate(PEmpty<string, int>(), "car", 1), "bike", 2);
            Console.WriteLine($"Default value of pm1: {pm1("test")}");
            Console.WriteLine($"at \"car\": {pm1("car")}");
            Console.WriteLine($"at \"bike\": {pm1("bike")}");
            Console.WriteLine();

            Func<PartialMap<string, int>, string, int, PartialMap<string, int>> p_update = PUpdate<string, int>;
            Func<PartialMap<string, int>> p_empty = PEmpty<string, int>;

            var pm2 = p_update(p_update(p_empty(), "car", 1), "bike", 2);

            Console.WriteLine($"Default value of pm2: {pm2("test")}");
            Console.WriteLine($"at \"car\": {pm2("car")}");
            Console.WriteLine($"at \"bike\": {pm2("bike")}");
            Console.WriteLine();

            // Pattern matching
            Console.WriteLine("=== Pattern matching demo ===");
            var value = pm2("car") switch
            {
                None<int> => "No value in dict.",
                Some<int> v => $"Value: {v.Value}",
                _ => "Something wrong!"
            };
            Console.WriteLine(value);
        }
    }
}