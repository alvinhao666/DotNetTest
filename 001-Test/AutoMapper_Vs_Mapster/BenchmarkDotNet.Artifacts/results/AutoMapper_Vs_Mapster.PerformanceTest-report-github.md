``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19044.1889/21H2/November2021Update)
Intel Core i5-7500 CPU 3.40GHz (Kaby Lake), 1 CPU, 4 logical and 4 physical cores
.NET SDK=6.0.400
  [Host]     : .NET Core 3.1.28 (CoreCLR 4.700.22.36202, CoreFX 4.700.22.36301), X64 RyuJIT AVX2
  DefaultJob : .NET Core 3.1.28 (CoreCLR 4.700.22.36202, CoreFX 4.700.22.36301), X64 RyuJIT AVX2


```
|      Method |                Mean |             Error |            StdDev |
|------------ |--------------------:|------------------:|------------------:|
| Constructor |            38.31 ns |          0.643 ns |          0.601 ns |
|  AutoMapper | 1,751,177,381.82 ns | 33,408,522.120 ns | 41,028,665.436 ns |
|     Mapster |           829.40 ns |          8.977 ns |          7.958 ns |
