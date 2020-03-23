using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;

namespace BenchmarkConsole.Benchmarks
{
    [RankColumn]
    [MemoryDiagnoser]
    [DisassemblyDiagnoser]
    [GcServer(true)]
    public class NullableGetDefaultVsNullCoalescing
    {
        [Benchmark]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool ForNullableGetValueOrDefault()
        {
            string[] a = new string[10];
            return (a?.Length).GetValueOrDefault() > 0;
        }
        [Benchmark]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool ForNullCoalescing()
        {
            string[] a = new string[10];
            return (a?.Length ?? 0) > 0;
        }
    }
}
