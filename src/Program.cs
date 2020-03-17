using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using BenchmarkConsole.Benchmarks;

namespace BenchmarkConsole
{
    class Program
    {
        async static Task Main(string[] args)
        {
            //var summary = BenchmarkRunner.Run<ListBenchmark>();
            //var summary = BenchmarkRunner.Run<CrossGenerationReferenceBenchmark>();
            //var summary = BenchmarkRunner.Run<ForVsForeach>();
            //var summary = BenchmarkRunner.Run<SumVsAggregate>();
            //var summary = BenchmarkRunner.Run<StringComparisonVsToLowerInvariant>();
            //var summary = BenchmarkRunner.Run<LinqAnyVsCountVsLength>();
            //var summary = BenchmarkRunner.Run<ConstVsStaticStringVsStaticTypeWrapper>();
            //var summary = BenchmarkRunner.Run<AsyncTaskVsSimpleTask>();
        }
    }
}
