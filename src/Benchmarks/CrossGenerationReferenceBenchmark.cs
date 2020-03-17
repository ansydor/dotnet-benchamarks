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
    public class CrossGenerationReferenceBenchmark
    {


        [Benchmark]
        public List<string> WithSingleton()
        {
            var sing = Guid.NewGuid().ToString();
            //var data = new List<object>();
            for (int i = 0; i < 100; i++)
            {
                var a = Enumerable.Range(0, 100).Select(s => new { s = Guid.NewGuid().ToString() }).ToList();
                var a2 = Enumerable.Range(0, 100).Select(s => new { s = sing, count = a.Count }).ToList();
                //data.Add(a2);
                GC.Collect();
            }
            return new List<string>();
        }

        [Benchmark]
        public List<string> WithoutSingleton()
        {
            var sing = Guid.NewGuid().ToString();
            //var data = new List<object>();
            for (int i = 0; i < 100; i++)
            {
                var a = Enumerable.Range(0, 100).Select(s => new { s = Guid.NewGuid().ToString() }).ToList();
                var a2 = Enumerable.Range(0, 100).Select(s => new { count = a.Count }).ToList();
                //data.Add(a2);
                GC.Collect();
            }
            return new List<string>();
        }
    }
}
