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
    public class LinqAnyVsCountVsLength
    {
        private int[] _data;
        private List<int> _dataList;
        [GlobalSetup]
        public void DataInitialization()
        {
            _data = new int[0];
            _dataList = new List<int>();
        }

        [Benchmark]
        public bool LinqAny() => _data.Any();
        [Benchmark]
        public bool ArrayLength() => _data.Length > 0;
        [Benchmark]
        public bool ListCount() => _dataList.Count > 0;
        [Benchmark]
        public bool ListLinqAny() => _dataList.Any();
    }
}
