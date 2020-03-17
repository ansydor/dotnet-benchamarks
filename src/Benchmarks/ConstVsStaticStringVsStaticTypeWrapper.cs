using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace BenchmarkConsole.Benchmarks
{
    [RPlotExporter, RankColumn]
    [MemoryDiagnoser]
    [DisassemblyDiagnoser]
    [CoreJob]
    [GcServer(true)]
    public class ConstVsStaticStringVsStaticTypeWrapper
    {
        const string constInstance = "XXX";
        static string staticInstance = "YYY";
        static readonly Wrapper wrapperInstance = new Wrapper()
        {
            value = "YYY"
        };

        [Benchmark]
        public string FromConst()
        {
            return constInstance;
        }

        [Benchmark]
        public string FromStatic()
        {
            return staticInstance;
        }

        [Benchmark]
        public string FromWrapper()
        {
            return wrapperInstance;
        }

        class Wrapper
        {
            public string value;
            public static implicit operator string(Wrapper wrap)
            {
                return wrap.value;
            }
        }
    }
}
