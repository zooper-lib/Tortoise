using Microsoft.CodeAnalysis;

namespace Zooper.Tortoise.Generators;

public static class GeneratorExecutionContextExtensions
{
	public static void ReportDiagnostic(
		this IncrementalGeneratorInitializationContext context,
		DiagnosticDescriptor data)
	{
		Diagnostic.Create(
			data,
			Location.None
		);
	}
}