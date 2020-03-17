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
    public class ForVsForeach
    {
        private List<string> _data;
        [GlobalSetup]
        public void DataInitialization()
        {
            _data = Enumerable.Range(0, 100000).Select(s => Guid.NewGuid().ToString()).ToList();
        }
        [Benchmark]
        public List<string> ForLoop()
        {
            var result = new List<string>(_data.Count);
            for (int i = 0; i < _data.Count; i++)
            {
                result.Add(_data[i]);
            }
            return result;
        }
        [Benchmark]
        public List<string> ForeachLoop()
        {
            var result = new List<string>(_data.Count);
            foreach (var item in _data)
            {
                result.Add(item);
            }
            return result;
        }

        [Benchmark]
        public List<string> LinqSelectLoop()
        {
            var result = _data.Select(s => s).ToList();
            return result;
        }

        [Benchmark]
        public string[] YieldReturnLoop()
        {
            var result = new string[_data.Count];
            var inc = 0;
            foreach (var item in Generate())
            {
                result[inc++] = item;
            }
            return result;
        }
        [Benchmark]
        public List<string> YieldReturnToList()
        {
            return Generate().ToList();
        }

        private IEnumerable<string> Generate()
        {
            for (var index = 0; index < _data.Count; index++)
            {
                var item = _data[index];
                yield return item;
            }
        }
    }
}
