using System;
using Zooper.Tortoise.Generators.Attributes.Attributes;
using Zooper.Tortoise.Interfaces;

namespace Zooper.Tortoise.Sample;

[GenerateConverters]
public partial class GuidStrongTypeClass(Guid value) : StrongTypeClass<Guid, GuidStrongTypeClass>(value)
{
	public partial class GuidStrongTypeClassValueConverter;

	public partial class GuidStrongTypeClassNewtonsoftJsonConverter;

	public partial class GuidStrongTypeClassTypeConverter;
}