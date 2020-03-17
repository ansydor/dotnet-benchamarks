using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace BenchmarkConsole.Benchmarks
{
    [RPlotExporter, RankColumn]
    [MemoryDiagnoser]
    [DisassemblyDiagnoser]
    [CoreJob]
    [GcServer(true)]
    public class AsyncTaskVsSimpleTask
    {
        [Benchmark]
        public async Task SimpleTasksSequenceAsync()
        {
            Task ReturnValue()
            {
                return Task.CompletedTask;
            }

            Task ReturnValueWrapperLevel1()
            {
                return ReturnValue();
            }

            Task ReturnValueWrapperLevel2()
            {
                return ReturnValueWrapperLevel1();
            }

            Task ReturnValueWrapperLevel3()
            {
                return ReturnValueWrapperLevel2();
            }

            Task ReturnValueWrapperMain()
            {
                return ReturnValueWrapperLevel3();
            }

            await ReturnValueWrapperMain();
        }

        [Benchmark]
        public async Task AsyncTasksSequenceAsync()
        {
            Task ReturnValue()
            {
                return Task.CompletedTask;
            }

            async Task ReturnValueWrapperLevel1()
            {
                await ReturnValue();
            }

            async Task ReturnValueWrapperLevel2()
            {
                await ReturnValueWrapperLevel1();
            }

            async Task ReturnValueWrapperLevel3()
            {
                await ReturnValueWrapperLevel2();
            }

            async Task ReturnValueWrapperMain()
            {
                await ReturnValueWrapperLevel3();
            }

            await ReturnValueWrapperMain(); 
        }

      
      
    }
}
