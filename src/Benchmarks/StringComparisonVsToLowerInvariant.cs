using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace BenchmarkConsole.Benchmarks
{
    [RankColumn]
    [MemoryDiagnoser]
    [DisassemblyDiagnoser]
    [CoreJob]
    [GcServer(true)]
    public class StringComparisonVsToLowerInvariant
    {
        private string _data1;
        private string _data2;

        [GlobalSetup]
        public void DataInitialization()
        {
            _data1 = Guid.NewGuid().ToString("N");
            _data2 = "A" + string.Join("", Enumerable.Range(0, 100).Select(s => Guid.NewGuid().ToString("N"))) + _data1;
        }
        [Benchmark]
        public bool ContainsWithStringComparisonOrdinal()
        {
            return _data2.Contains(_data1, StringComparison.Ordinal);
        }
        [Benchmark]
        public bool ContainsWithStringToLowerInvariantAndComparisonOrdinal()
        {
            return _data2.ToLowerInvariant().Contains(_data1.ToLowerInvariant(), StringComparison.Ordinal);
        }
        [Benchmark]
        public bool ContainsWithStringComparisonOrdinalIgnoreCase()
        {
            return _data2.Contains(_data1, StringComparison.OrdinalIgnoreCase);
        }

        [Benchmark]
        public bool ContainsWithToLowerInvariant()
        {
            return _data2.ToLowerInvariant().Contains(_data1.ToLowerInvariant());
        }

    }
}
