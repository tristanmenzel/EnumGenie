namespace EnumGenie.TypeScript
{
    public class EnumDescriptorWriterConfig
    {
        public bool Const { get; private set; }
        
        public bool UseInterfacePrefix { get; private set; }

        public EnumDescriptorWriterConfig AsConst() { Const = true; return this; }
        public EnumDescriptorWriterConfig PrefixInterface() { UseInterfacePrefix= true; return this; }
    }
}