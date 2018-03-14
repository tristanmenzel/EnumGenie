using System;
using System.IO;
using EnumGenie.Writers;

namespace EnumGenie.TypeScript
{
    public class EnumDescriptionFunctionWriter : IEnumWriter
    {
        public void WriteTo(Stream stream, EnumDefinition enumDefinition)
        {
            var writer = new StreamWriter(stream);
            var functionName = char.ToLowerInvariant(enumDefinition.Name[0]) + enumDefinition.Name.Substring(1) +
                               "Description";
            writer.WriteLine($"export const {functionName} = (value: {enumDefinition.Name}): string => {enumDefinition.Name}Desc[value];");
            writer.Flush();
        }

        public Type[] Dependencies => new[] {typeof(EnumDeclarationWriter), typeof(EnumDescriptionDictionaryWriter)};
    }
}