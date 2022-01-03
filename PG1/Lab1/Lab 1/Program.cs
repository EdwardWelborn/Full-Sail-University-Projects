// Programming 1
// Edward Welborn
// Lab 1


String strName = "";
String strDate = "";


Console.Clear();
Console.WriteLine("Hello and Welcome to Lab 1\n");
Console.Write("Please Enter Your Name: ");
strName = Console.ReadLine();
Console.Write("Pleaes Enter Your Age: ");
strDate = Console.ReadLine();

Console.WriteLine($"\nHello {strName}, Glad you have been around all these {strDate} year(s)\n");

Console.WriteLine("Press any Key to Exit");
Console.ReadKey();

