using System;
using System.Reflection;

var hello = new Hello();
// リフレクションでプロパティを設定
var pinfo = typeof(Hello).GetProperty("Name");
pinfo?.SetValue(hello, "Masuda Tomoaki");
// リフレクションでメソッドを呼び出し
var minfo = typeof(Hello).GetMethod("Print");
minfo?.Invoke(hello, new object[] { });

// 以下と同じ
hello.Name = "Masuda Tomoaki";
hello.Print();

class Hello {
    public string Name { get; set; } = "";
    public void Print() {
        Console.WriteLine($"Hello {Name}");
    }
}
