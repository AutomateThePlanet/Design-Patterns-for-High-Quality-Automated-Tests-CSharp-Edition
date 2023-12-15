// Copyright 2024 Automate The Planet Ltd.
// Author: Anton Angelov
// Licensed under the Apache License, Version 2.0 (the "License");
// You may not use this file except in compliance with the License.
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
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

namespace BenchRunner;

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
