using Newtonsoft.Json;

namespace Zooper.Tortoise.Generators.Attributes.Converters;

public abstract class UInt64JsonConverter<T> : JsonConverter<T>
{
	protected abstract T CreateInstance(ulong value);

	protected abstract ulong GetValue(T instance);

	public override void WriteJson(
		JsonWriter writer,
		T? value,
		JsonSerializer serializer)
	{
		if (value == null)
		{
			writer.WriteNull();
			return;
		}

		writer.WriteValue(GetValue(value));
	}

	public override T? ReadJson(
		JsonReader reader,
		Type objectType,
		T? existingValue,
		bool hasExistingValue,
		JsonSerializer serializer)
	{
		switch (reader.TokenType)
		{
			case JsonToken.Null:
				return default;
			case JsonToken.Integer:
			{
				var value = Convert.ToUInt64(reader.Value);
				return CreateInstance(value);
			}
			default:
				throw new JsonSerializationException(
					$"Unexpected token parsing {typeof(T).Name}. Expected Integer, got {reader.TokenType}."
				);
		}
	}
}