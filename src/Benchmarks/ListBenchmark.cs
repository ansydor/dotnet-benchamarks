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
    public class ListBenchmark
    {

        [Benchmark]
        public string[] WithLinqNoList() => (string[])Enumerable.Empty<string>();
        [Benchmark]
        public List<string> WithLinq() => Enumerable.Empty<string>().ToList();

        [Benchmark]
        public List<string> ListConstructor() => new List<string>();
    }
}
