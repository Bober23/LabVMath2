// See https://aka.ms/new-console-template for more information
using LabVMath2;

Console.WriteLine("Hello, World!");
var MyTask = new LabTask();
double[] cCoefs = MyTask.GetCCoefs();
double[] aCoefs = MyTask.GetACoefs();
double[] bCoefs = MyTask.GetBCoefs();
double[] dCoefs = MyTask.GetDCoefs();
foreach (var a in aCoefs)
{
    Console.WriteLine($"A = {a}");
}
foreach (var b in bCoefs)
{
    Console.WriteLine($"B = {b}");
}
foreach (var c in cCoefs)
{
    Console.WriteLine($"C = {c}");
}
foreach (var d in dCoefs)
{
    Console.WriteLine($"D = {d}");
}