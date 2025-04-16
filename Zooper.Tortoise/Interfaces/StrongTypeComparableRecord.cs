namespace Zooper.Tortoise.Interfaces;

using System;

/// <summary>
/// Interface for comparable strong types
/// </summary>
/// <typeparam name="TValue">The type of the encapsulated value.</typeparam>
/// <typeparam name="T">The type of the implementing type itself.</typeparam>
public interface IComparableStrongType<out TValue, T> : IStrongType<TValue, T>, IComparable<T>
    where T : IComparableStrongType<TValue, T>
{
}

/// <summary>
/// A derived record for strong types encapsulating a value of type <typeparamref name="TValue"/>.
/// This version supports comparisons. The encapsulated value must implement both <see cref="IComparable{TValue}"/> and <see cref="IEquatable{TValue}"/>.
/// This derived record provides comparison functionality, allowing strong types to be compared based on their values using comparison operators.
/// </summary>
/// <typeparam name="TValue">The type of the encapsulated value, must implement <see cref="IComparable{TValue}"/> and <see cref="IEquatable{TValue}"/>.</typeparam>
/// <typeparam name="T">The type of the derived record itself, used for enforcing the strong type pattern in derived records.</typeparam>
public abstract record StrongTypeComparableRecord<TValue, T>(TValue Value) 
    : StrongTypeRecord<TValue, T>(Value), IComparableStrongType<TValue, T>
    where TValue : IComparable<TValue>, IEquatable<TValue>
    where T : StrongTypeComparableRecord<TValue, T>
{
    /// <summary>
    /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
    /// </summary>
    /// <param name="other">An object to compare with this instance.</param>
    /// <returns>A value that indicates the relative order of the objects being compared.</returns>
    public int CompareTo(T? other)
    {
        if (other is null) return 1;
        if (ReferenceEquals(this, other)) return 0;
        
        return Value is null ? (other.Value is null ? 0 : -1) : Value.CompareTo(other.Value);
    }
    
    /// <summary>
    /// Determines whether one instance of a strong type is less than another instance.
    /// </summary>
    /// <param name="left">The first instance to compare.</param>
    /// <param name="right">The second instance to compare.</param>
    /// <returns>true if left is less than right; otherwise, false.</returns>
    public static bool operator <(StrongTypeComparableRecord<TValue, T> left, StrongTypeComparableRecord<TValue, T> right)
    {
        return left.CompareTo((T)right) < 0;
    }
    
    /// <summary>
    /// Determines whether one instance of a strong type is less than or equal to another instance.
    /// </summary>
    /// <param name="left">The first instance to compare.</param>
    /// <param name="right">The second instance to compare.</param>
    /// <returns>true if left is less than or equal to right; otherwise, false.</returns>
    public static bool operator <=(StrongTypeComparableRecord<TValue, T> left, StrongTypeComparableRecord<TValue, T> right)
    {
        return left.CompareTo((T)right) <= 0;
    }
    
    /// <summary>
    /// Determines whether one instance of a strong type is greater than another instance.
    /// </summary>
    /// <param name="left">The first instance to compare.</param>
    /// <param name="right">The second instance to compare.</param>
    /// <returns>true if left is greater than right; otherwise, false.</returns>
    public static bool operator >(StrongTypeComparableRecord<TValue, T> left, StrongTypeComparableRecord<TValue, T> right)
    {
        return left.CompareTo((T)right) > 0;
    }
    
    /// <summary>
    /// Determines whether one instance of a strong type is greater than or equal to another instance.
    /// </summary>
    /// <param name="left">The first instance to compare.</param>
    /// <param name="right">The second instance to compare.</param>
    /// <returns>true if left is greater than or equal to right; otherwise, false.</returns>
    public static bool operator >=(StrongTypeComparableRecord<TValue, T> left, StrongTypeComparableRecord<TValue, T> right)
    {
        return left.CompareTo((T)right) >= 0;
    }
}