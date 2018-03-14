using EnumGenie.Filters;
using EnumGenie.Sample.Enums;
using EnumGenie.Sources;
using EnumGenie.Transforms;
using EnumGenie.TypeScript;
using EnumGenie.Writers;

namespace EnumGenie.Sample
{
    public static class Program
    {
        public static void Main()
        {
            var genie = new EnumGenie()
                .SourceFrom.Assembly(typeof(Program).Assembly)
                .FilterBy.Predicate(t => t != typeof(Ignored))
                .TransformBy.RenamingEnum(def => def.Name.Replace("StripThisOut", ""))
                .WriteTo.Console(cfg =>
                    cfg.TypeScript(ts =>
                        ts.Declaration()
                            .Description()
                            .Descriptor()
                    )
                )
                .WriteTo.File("./TypeScript/enums.ts", cfg =>
                    cfg.TypeScript(ts =>
                        ts
                            .Description()
                            .Descriptor(c => c.AsConst())
                    ));

            genie.Write();
        }
    }
}