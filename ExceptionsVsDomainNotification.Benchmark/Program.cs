
// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using ExceptionsVsDomainNotification.Benchmark;


BenchmarkRunner.Run<BenchExceptions>();

//BenchmarkRunner.Run<BenchExceptionsApi>();