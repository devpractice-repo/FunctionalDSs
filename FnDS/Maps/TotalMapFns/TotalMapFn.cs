namespace FnDS.Maps.TotalMapFns;

public static class TotalMapFn
{
    public delegate V TotalMap<K, V>(K key)
        where K : IEquatable<K>;
    public static TotalMap<K, V> TEmpty<K, V>(V defaultValue)
        where K : IEquatable<K> =>
        (_) => defaultValue;

    public static TotalMap<K, V> TUpdate<K, V>(TotalMap<K, V> totalMap, K key, V value)
        where K : IEquatable<K> =>
        (k) => k.Equals(key) switch
        {
            true => value,
            false => totalMap(k)
        };
}
