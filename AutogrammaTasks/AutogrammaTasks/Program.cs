using AutogrammaTasks;

Console.Write("Введите строку для решения задачи 1: ");
string stringForTask1 = Console.ReadLine()!;
Task1 task1 = new(stringForTask1);
Console.Write("Введите строку для решения задачи 2: ");
string stringForTask2 = Console.ReadLine()!;
Task2 task2 = new(stringForTask2);
Console.Write("Введите через пробел массив строк для решения задачи 3: ");
List<string> stringForTask3 = Console.ReadLine()!.Split(" ").ToList<string>();
Task3 task3 = new(stringForTask3);
Facade facade = new(task1,task2,task3);
facade.Start();
