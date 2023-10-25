namespace FnDS.Maps.PartialMapFns;

public static class PartialMapFn
{
    public delegate Option<V> PartialMap<K, V>(K key)
        where K : IEquatable<K>;

    public static PartialMap<K, V> PEmpty<K, V>()
        where K : IEquatable<K> =>
         (_) => Option<V>.None();

    public static PartialMap<K, V> PUpdate<K, V>(PartialMap<K, V> partialMap, K key, V value)
       where K : IEquatable<K> =>
       (k) => k.Equals(key) switch
       {
           true => Option<V>.Some(value),
           false => partialMap(k)
       };
}
