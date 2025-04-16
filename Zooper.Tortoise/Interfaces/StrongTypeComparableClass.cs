namespace Zooper.Tortoise.Interfaces;

/// <summary>
/// A base class for strong types encapsulating a value of type <typeparamref name="TValue"/>.
/// This version supports comparisons. The encapsulated value must implement <see cref="IComparable{TValue}"/> and <see cref="IEquatable{TValue}"/>.
/// </summary>
/// <typeparam name="TValue">The type of the encapsulated value, must implement <see cref="IComparable{TValue}"/> and <see cref="IEquatable{TValue}"/>.</typeparam>
/// <typeparam name="T">The type of the derived class itself, used for enforcing the strong type pattern.</typeparam>
public abstract class StrongTypeComparableClass<TValue, T>(TValue value) : StrongTypeClass<TValue, T>(value), IComparable<T>
	where TValue : IComparable<TValue>, IEquatable<TValue>
	where T : StrongTypeComparableClass<TValue, T>, new()
{
    /// <summary>
    /// Compares the current instance with another object of the same type and returns an integer
    /// that indicates whether the current instance precedes, follows, or occurs in the same position
    /// in the sort order as the other object.
    /// </summary>
    /// <param name="other">An object to compare with this instance.</param>
    /// <returns>
    /// A value that indicates the relative order of the objects being compared.
    /// The return value has these meanings:
    /// - Less than zero: This instance precedes 'other' in the sort order.
    /// - Zero: This instance occurs in the same position in the sort order as 'other'.
    /// - Greater than zero: This instance follows 'other' in the sort order.
    /// </returns>
    public int CompareTo(T? other)
    {
        return other == null ? 1 : Value.CompareTo(other.Value);
    }

    /// <summary>
    /// Determines whether the left strong type is less than the right strong type by comparing their values.
    /// </summary>
    public static bool operator <(
        StrongTypeComparableClass<TValue, T>? left,
        StrongTypeComparableClass<TValue, T>? right)
    {
        if (left is null)
            throw new ArgumentNullException(nameof(left));
        if (right is null)
            throw new ArgumentNullException(nameof(right));

        return left.Value.CompareTo(right.Value) < 0;
    }

    /// <summary>
    /// Determines whether the left strong type is greater than the right strong type by comparing their values.
    /// </summary>
    public static bool operator >(
        StrongTypeComparableClass<TValue, T>? left,
        StrongTypeComparableClass<TValue, T>? right)
    {
        if (left is null)
            throw new ArgumentNullException(nameof(left));
        if (right is null)
            throw new ArgumentNullException(nameof(right));

        return left.Value.CompareTo(right.Value) > 0;
    }

    /// <summary>
    /// Determines whether the left strong type is less than or equal to the right strong type by comparing their values.
    /// </summary>
    public static bool operator <=(
        StrongTypeComparableClass<TValue, T>? left,
        StrongTypeComparableClass<TValue, T>? right)
    {
        if (left is null)
            throw new ArgumentNullException(nameof(left));
        if (right is null)
            throw new ArgumentNullException(nameof(right));

        return left.Value.CompareTo(right.Value) <= 0;
    }

    /// <summary>
    /// Determines whether the left strong type is greater than or equal to the right strong type by comparing their values.
    /// </summary>
    public static bool operator >=(
        StrongTypeComparableClass<TValue, T>? left,
        StrongTypeComparableClass<TValue, T>? right)
    {
        if (left is null)
            throw new ArgumentNullException(nameof(left));
        if (right is null)
            throw new ArgumentNullException(nameof(right));

        return left.Value.CompareTo(right.Value) >= 0;
    }
}