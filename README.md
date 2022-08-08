# Exceptions Vs DomainNotification

This project was created to compare the **difference** between to throw **domain validations** as **Exception** or to return as **Notification**.

To check this point, was used the framework [Benchmark](https://github.com/dotnet/BenchmarkDotNet) to help us.

## Projects

### ExceptionsVsDomainNotification.Benchmark

This project is a **Console Application** that mock and run APIs to compare the results.
There are two class to test here:

1. BenchExceptions.cs (Simple example that compare two methods)
2. BenchExceptionsApi.cs (Simple example that call two differents APIs and compare the results)

#### Dependencies

- [BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet) 0.13.1

### ExceptionsVsDomainNotification.ExceptionApi

This project is a **ASP.NET Core Web Api** that has a simple route to login that throw exceptions as domain validation when catch a error.

### ExceptionsVsDomainNotification.NotificationApi

This project is a **ASP.NET Core Web Api** that has a simple route to login that return notification as domain validation when catch a error.

#### Dependencies

- [OneOf](https://github.com/mcintyre321/OneOf) 3.0.223

## Get Started

1. Clone the repo.
2. Run the project Benchmark.
3. Check the results in the console.

### Results

**BenchExceptions.cs**

```ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1766 (21H2)
Intel Core i5-7200U CPU 2.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.302
  [Host]     : .NET 6.0.7 (6.0.722.32202), X64 RyuJIT
  DefaultJob : .NET 6.0.7 (6.0.722.32202), X64 RyuJIT


```

| Method           | Type            |          Mean |         Error |        StdDev |        Median |  Gen 0 | Allocated |
| ---------------- | --------------- | ------------: | ------------: | ------------: | ------------: | -----: | --------: |
| **Notification** | **badRequest**  | **1.1469 ns** | **0.2038 ns** | **0.6009 ns** | **0.9610 ns** |  **-** |     **-** |
| ExceptionThrow   | badRequest      | 9,022.1942 ns |   594.3958 ns | 1,666.7496 ns | 8,940.0696 ns | 0.1221 |     200 B |
| **Notification** | **goodRequest** | **0.9042 ns** | **0.2503 ns** | **0.7300 ns** | **0.7077 ns** |  **-** |     **-** |
| ExceptionThrow   | goodRequest     |     0.7076 ns |     0.1942 ns |     0.5664 ns |     0.6512 ns |      - |         - |

**Legends**

- Type : Value of the 'Type' parameter
- Mean : Arithmetic mean of all measurements
- Error : Half of 99.9% confidence interval
- StdDev : Standard deviation of all measurements
- Median : Value separating the higher half of all measurements (50th percentile)
- Gen 0 : GC Generation 0 collects per 1000 operations
- Allocated : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)
- 1 ns : 1 Nanosecond (0.000000001 sec)

</br>
</br>

**BenchExceptionsApi.cs**

```ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1766 (21H2)
Intel Core i5-7200U CPU 2.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.302
  [Host]     : .NET 6.0.7 (6.0.722.32202), X64 RyuJIT
  DefaultJob : .NET 6.0.7 (6.0.722.32202), X64 RyuJIT


```

| Method              |     Mean |    Error |   StdDev |   Median |   Gen 0 | Allocated |
| ------------------- | -------: | -------: | -------: | -------: | ------: | --------: |
| ExceptionVersion    | 345.5 μs | 32.00 μs | 94.36 μs | 292.0 μs | 15.1367 |     23 KB |
| NotificationVersion | 212.6 μs |  1.68 μs |  1.40 μs | 212.7 μs | 13.6719 |     21 KB |

**Legends**

- Mean : Arithmetic mean of all measurements
- Error : Half of 99.9% confidence interval
- StdDev : Standard deviation of all measurements
- n 0 : GC Generation 0 collects per 1000 operations
- located : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)
- us : 1 Microsecond (0.000001 sec)
