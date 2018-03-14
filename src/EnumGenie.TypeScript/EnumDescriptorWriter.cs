using System;
using System.IO;
using System.Linq;
using System.Reflection;
using EnumGenie.Writers;

namespace EnumGenie.TypeScript
{
    public class EnumDescriptorWriter : IEnumWriter
    {
        private readonly bool _const;
        private readonly bool _prefixInterface;

        public EnumDescriptorWriter() : this(null)
        {
        }

        public EnumDescriptorWriter(EnumDescriptorWriterConfig descriptorConfig)
        {
            _const = descriptorConfig?.Const ?? false;
            _prefixInterface = descriptorConfig?.UseInterfacePrefix ?? true;
        }

        public void WriteTo(Stream stream, EnumDefinition enumDefinition)
        {
            var membersExceptFlagsDefault = enumDefinition.EnumType.GetCustomAttribute<FlagsAttribute>() == null
                ? enumDefinition.Members
                : enumDefinition.Members.Where(m => m.Value != 0).ToList();

            var varOrConst = _const ? "const" : "var";

            var interfacePrefix = _prefixInterface ? "I" : "";
            var descriptorInterface = $"{interfacePrefix}{enumDefinition.Name}Descriptor";

            var writer = new StreamWriter(stream);
            writer.WriteLine(
                $"export interface {descriptorInterface} {{ value: {enumDefinition.Name}; name: string; description: string; }}");
            writer.WriteLine($"export {varOrConst} all{enumDefinition.Name}: {descriptorInterface}[] = [");
            writer.Write(string.Join($",{Environment.NewLine}",
                membersExceptFlagsDefault.Select(m => $" {enumDefinition.Name}.{m.Name}")));
            writer.WriteLine();

            writer.WriteLine(
                $"].map(value => ({{value, name: {enumDefinition.Name}[value], description: {enumDefinition.Name}Desc[value]}}));");

            writer.WriteLine(
                $"export const get{enumDefinition.Name}Descriptor = (value: {enumDefinition.Name}): {descriptorInterface} => ");
            writer.WriteLine($" all{enumDefinition.Name}.filter(d => d.value === value)[0];");
            writer.Flush();
        }

        private static string Descriptor(EnumDefinition enumDefinition, EnumMemberDefinition m)
        {
            return $"{{ value: {enumDefinition.Name}.{m.Name}, name: `{m.Name}`, description: `{m.Description}` }}";
        }


        public Type[] Dependencies => new[] {typeof(EnumDeclarationWriter), typeof(EnumDescriptionDictionaryWriter)};
    }
}