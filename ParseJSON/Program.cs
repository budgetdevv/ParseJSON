using System.Runtime.CompilerServices;
using NJsonSchema;
using NJsonSchema.CodeGeneration.CSharp;

namespace ParseJSON
{
    public static class Program
    {
        // This is only ran once
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        private static async Task Main(string[] args)
        {
            Console.Write("Input the path to your JSON file:");

            var json = await File.ReadAllTextAsync(Console.ReadLine()!);

            var schema = JsonSchema.FromSampleJson(json);

            var settings = new CSharpGeneratorSettings
            {
                Namespace = "Foo"
            };

            var generator = new CSharpGenerator(schema, settings);

            var classCode = generator.GenerateFile();

            await File.WriteAllTextAsync("GeneratedClasses.cs", classCode);

            Console.WriteLine("C# classes generated successfully.");
        }
    }
}