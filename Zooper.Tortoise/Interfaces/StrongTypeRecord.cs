namespace Zooper.Tortoise.Interfaces;

using System;

/// <summary>
/// Interface defining a strong type that encapsulates a value of type <typeparamref name="TValue"/>.
/// </summary>
/// <typeparam name="TValue">The type of the encapsulated value.</typeparam>
/// <typeparam name="T">The type of the implementing type itself.</typeparam>
public interface IStrongType<out TValue, T>
    where T : IStrongType<TValue, T>
{
    /// <summary>
    /// Gets the value encapsulated by this strong type.
    /// </summary>
    TValue Value { get; }
    
    /// <summary>
    /// Determines if this instance is equal to another instance of the same type.
    /// </summary>
    /// <param name="other">The instance to compare with.</param>
    /// <returns>True if the instances are equal based on their values, false otherwise.</returns>
    bool Equals(T? other);
}

/// <summary>
/// A base record for strong types encapsulating a value of type <typeparamref name="TValue"/>.
/// This version does not support comparisons. The encapsulated value must implement <see cref="IEquatable{TValue}"/>.
/// This base record provides basic equality functionality, ensuring that two instances of a strong type are compared based on their encapsulated values.
/// </summary>
/// <typeparam name="TValue">The type of the encapsulated value, must implement <see cref="IEquatable{TValue}"/>.</typeparam>
/// <typeparam name="T">The type of the derived record itself, used for enforcing the strong type pattern in derived records.</typeparam>
public abstract record StrongTypeRecord<TValue, T>(TValue Value)
    : IStrongType<TValue, T>
    where TValue : IEquatable<TValue>
    where T : StrongTypeRecord<TValue, T>
{
    /// <summary>
    /// Creates a new instance of the strong type by invoking the provided constructor.
    /// </summary>
    /// <param name="value">The value to encapsulate in the strong type.</param>
    /// <param name="constructor">A delegate that constructs the specific type <typeparamref name="T"/>.</param>
    /// <returns>A new instance of <typeparamref name="T"/> encapsulating the provided <paramref name="value"/>.</returns>
    // ReSharper disable once UnusedMember.Global
    protected static T Create(
        TValue value,
        Func<TValue, T> constructor)
    {
        return constructor(value);
    }

    /// <summary>
    /// Determines if this instance is equal to another instance of the same type.
    /// </summary>
    /// <param name="other">The instance to compare with.</param>
    /// <returns>True if the instances are equal based on their values, false otherwise.</returns>
    public virtual bool Equals(T? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        
        return Value is null ? other.Value is null : Value.Equals(other.Value);
    }

    /// <summary>
    /// Returns a string representation of the encapsulated value.
    /// </summary>
    /// <returns>The string representation of the value.</returns>
    public override string? ToString() => Value?.ToString();
}