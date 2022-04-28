using System;
using System.Reflection;

var hello = new Hello()
{
    Name = "Masuda Tomoaki"
};
var attr = typeof(Hello).GetProperty("Name")?.GetCustomAttribute<HelpAttribute>();
Console.WriteLine(attr?.Message);
Console.WriteLine($"Name is {hello.Name}");
var attr2 = typeof(Hello).GetMethod("Print")?.GetCustomAttribute<HelpAttribute>();
Console.WriteLine(attr2?.Message);
hello.Print();

class HelpAttribute : Attribute
{
    public HelpAttribute( string msg )
    {
        this.Message = msg;
    }
    public string Message { get; set; }
}

class Hello
{
    [Help("ここに名前を入力")]
    public string Name { get; set; } = "";
    [Help("ここで挨拶を表示する")]
    public void Print()
    {
        Console.WriteLine($"Hello {Name}");
    }
}
