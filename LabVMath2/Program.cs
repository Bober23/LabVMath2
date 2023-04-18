// See https://aka.ms/new-console-template for more information
using LabVMath2;

Console.WriteLine("Hello, World!");
var MyTask = new LabTask();
double[] cCoefs = MyTask.GetCCoefs();
foreach (var c in cCoefs)
{
    Console.WriteLine(c);
}