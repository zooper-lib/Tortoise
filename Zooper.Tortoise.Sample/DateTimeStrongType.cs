using System;
using Zooper.Tortoise.Interfaces;
using Zooper.Tortoise.Generators.Attributes.Attributes;

namespace Zooper.Tortoise.Sample;

[GenerateConverters]
public partial record DateTimeStrongType(DateTime Value) : StrongTypeRecord<DateTime, DateTimeStrongType>(Value)
{
	public partial class DateTimeStrongTypeValueConverter;

	public partial class DateTimeStrongTypeNewtonsoftJsonConverter;

	public partial class DateTimeStrongTypeTypeConverter;
}