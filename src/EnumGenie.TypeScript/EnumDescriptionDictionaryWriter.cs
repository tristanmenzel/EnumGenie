using System;
using System.IO;
using EnumGenie.Writers;

namespace EnumGenie.TypeScript
{
    public class EnumDescriptionDictionaryWriter : IEnumWriter
    {
        public void WriteTo(Stream stream, EnumDefinition enumDefinition)
        {
            var writer = new StreamWriter(stream);

            writer.WriteLine($"const {enumDefinition.Name}Desc: any = {{");
            foreach (var member in enumDefinition.Members)
                writer.WriteLine($"  [{enumDefinition.Name}.{member.Name}]: `{member.Description}`,");
            writer.WriteLine("};");
            writer.Flush();

        }

        public Type[] Dependencies => new[] {typeof(EnumDeclarationWriter)};
    }
}