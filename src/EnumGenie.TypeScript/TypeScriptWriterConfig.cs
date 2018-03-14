using System.Collections.Generic;
using EnumGenie.Writers;

namespace EnumGenie.TypeScript
{
    public class TypeScriptWriterConfig
    {
        private readonly List<IEnumWriter> _writers = new List<IEnumWriter>();

        public void AddTypeScriptWriter(IEnumWriter writer)
        {
            foreach (var dependency in writer.Dependencies)
            {
                if (_writers.All(w => w.GetType() != dependency))
                {
                    if (Activator.CreateInstance(dependency) is IEnumWriter depWriter)
                        _writers.Add(depWriter);
                }
            }

            _writers.Add(writer);
        }

        internal IEnumWriter CreateWriter()
        {
            return new CompositeEnumWriter(_writers);
        }
    }
}