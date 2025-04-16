using System;
using Xunit;
using Xunit.Abstractions;
using Zooper.Tortoise.Sample;

namespace Zooper.Tortoise.Tests;

public class StrongTypeConverterGeneratorTests
{
	private readonly ITestOutputHelper _testOutputHelper;

	public StrongTypeConverterGeneratorTests(ITestOutputHelper testOutputHelper)
	{
		_testOutputHelper = testOutputHelper;
	}

	[Fact]
	public void SampleTypesCanBeInstantiated()
	{
		// This test just verifies that the code generation worked by ensuring we can create instances
		// of the sample strong types and their generated converters
		
		// Test record types
		var guidRecord = new GuidStrongTypeRecord(Guid.NewGuid());
		Assert.NotEqual(default, guidRecord.Value);
		
		// Test converter instantiation
		var guidConverter = new GuidStrongTypeRecord.GuidStrongTypeRecordNewtonsoftJsonConverter();
		Assert.NotNull(guidConverter);
		
		// Test class types
		var guidClass = new GuidStrongTypeClass(Guid.NewGuid());
		Assert.NotEqual(default, guidClass.Value);
		
		// Test int type
		var intType = new IntStrongType(42);
		Assert.Equal(42, intType.Value);
		
		_testOutputHelper.WriteLine("All sample strong types can be instantiated successfully");
		_testOutputHelper.WriteLine("All converter types can be instantiated successfully");
	}
}