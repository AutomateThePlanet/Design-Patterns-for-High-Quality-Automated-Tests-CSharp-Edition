using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Diagnostics.Windows;
using BenchmarkDotNet.Diagnostics.Windows.Configs;
using BenchmarkDotNet.Running;
////using BenchRunner.Second;
using StackExchange.Profiling;
using System;
using BenchRunner.First;

namespace BenchRunner
{
    // [InProcess]

    [CsvExporter]
    [HtmlExporter]
    ////[DisassemblyDiagnoser(printAsm: true, printSource: true)]
    ////[EtwProfiler]
    public class Program
    {
        static void Main(string[] args)
        {
            ////_driver = new ChromeDriver(AssemblyFolder);
            ////var config = DefaultConfig.Instance.With(ConfigOptions.DisableOptimizationsValidator);
            var summary = BenchmarkRunner.Run<ButtonClickBenchmark>();
            Console.WriteLine(summary);
        }
    }
}