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
    public class SumVsAggregate
    {
        private List<int> _data;
        [GlobalSetup]
        public void DataInitialization()
        {
            Random randomizer = new Random();
            _data = Enumerable.Range(0, 100000).Select(s => randomizer.Next(0, 100)).ToList();
        }
        [Benchmark]
        public int ForSum()
        {
            return _data.Sum();
        }
        [Benchmark]
        public int ForAggregate()
        {
            return _data.Aggregate(0, (sum, i) => sum + i);
        }
        [Benchmark]
        public int ForForeachLoop()
        {
            int result = 0;
            foreach (var i in _data) result = result + i;
            return result;
        }
        [Benchmark]
        public int ForLoop()
        {
            int result = 0;
            for (var index = 0; index < _data.Count; index++)
            {
                var i = _data[index];
                result = result + i;
            }
            return result;
        }
    }
}
