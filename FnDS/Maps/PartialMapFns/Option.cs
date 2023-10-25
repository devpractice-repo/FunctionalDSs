namespace FnDS.Maps.PartialMapFns;

public abstract record Option<T>
{
    public static Some<T> Some(T value) => new(value);
    public static None<T> None() => new();
}
public record Some<T>(T Value) : Option<T> { }
public record None<T>() : Option<T> { }
