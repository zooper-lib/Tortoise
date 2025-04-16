using Zooper.Tortoise.Generators.Attributes.Attributes;
using Zooper.Tortoise.Interfaces;

namespace Zooper.Tortoise.Sample;

[GenerateConverters]
public partial record IntStrongType(int Value) : StrongTypeRecord<int, IntStrongType>(Value)
{
	public partial class IntStrongTypeValueConverter;

	public partial class IntStrongTypeNewtonsoftJsonConverter;

	public partial class IntStrongTypeTypeConverter;
}