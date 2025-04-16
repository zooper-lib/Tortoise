using System;
using Zooper.Tortoise.Generators.Attributes.Attributes;
using Zooper.Tortoise.Interfaces;

namespace Zooper.Tortoise.Sample;

[GenerateConverters]
public partial record GuidStrongTypeRecord(Guid Value) : StrongTypeRecord<Guid, GuidStrongTypeRecord>(Value)
{
	public partial class GuidStrongTypeRecordValueConverter;

	public partial class GuidStrongTypeRecordNewtonsoftJsonConverter;

	public partial class GuidStrongTypeRecordTypeConverter;
}