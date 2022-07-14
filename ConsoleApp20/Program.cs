using java.util;
using System;
using System.Collections.Generic;
using System.Data;

public class Expressions
{
	public static string operators = "+-/*";
	public static string translate(string postfix)
	{
		Stack<string> expr = new Stack<string>();
		Scanner sc = new Scanner(postfix);
		while (sc.hasNext())
		{
			string t = sc.next();
			if (operators.IndexOf(t, StringComparison.Ordinal) == -1)
			{
				expr.Push(t);
			}
			else
			{
				expr.Push("(" + expr.Pop() + t + expr.Pop() + ")");
			}
		}
		return expr.Pop();
	}
	public static int rand()
	{
		int rn;
		System.Random random = new System.Random();
		rn = random.Next(100, 999);
		return rn;
	}
	public static string brute(int?[] numbers, int stackHeight, string eq, int rn)
	{
		string textResult = "";
		string process = "";
		if (stackHeight >= 2)
		{
			foreach (char op in operators.ToCharArray())
			{
				brute(numbers, stackHeight - 1, eq + " " + op,rn);
			}
		}
		bool allUsedUp = true;
		for (int i = 0; i < numbers.Length; i++)
		{
			if (numbers[i] != null)
			{
				allUsedUp = false;
				int? n = numbers[i];
				numbers[i] = null;
				brute(numbers, stackHeight + 1, eq + " " + n.Value,rn);
				numbers[i] = n;
			}
		}
		if (allUsedUp && stackHeight == 1)
		{
			process = translate(eq);
			double result = Convert.ToDouble(new DataTable().Compute(process, null));
			if (result == rn)
			{
				Console.Write("Hesaplanması Gereken Sayımız: ");
				Console.WriteLine(rn);
				textResult = result.ToString();
			}
		}
		if (textResult != "")
		{
			Console.Write("\n-------- YAPILAN İŞLEM --------\n");
			Console.WriteLine(process + " = " + textResult);
			Console.Write("-------------------------------\n");
			ConsoleKeyInfo tus = new ConsoleKeyInfo();
			Console.WriteLine("Yeniden denemek için bir tuşa basın");
			Console.WriteLine("Çıkmak İçin ESC tuşuna basın");
			tus = Console.ReadKey(true);
			if (tus.Key != ConsoleKey.Escape)
			{
				rnumbers();
			}
			else
			{
				Environment.Exit(0);
			}
		}
		return textResult;
	}
	public static string expression(params int?[] numbers)
	{
		string txtResult;
		int a;
		int rn = rand();
		Console.WriteLine("Hesaplanması Gereken Rastgele Sayımız: " + rn);
		Console.Write("Sayıyı değiştirmek istiyor musunuz?(e/h)");
		if (Console.ReadLine().ToLower() == "e")
		{
			Console.Write("Yeni sayı girin: ");
			a = Convert.ToInt32(Console.ReadLine());
			txtResult = brute(numbers, 0, "", a);
			return txtResult;
		}
		else
		{
			txtResult = brute(numbers, 0, "", rn);
			return txtResult;
		}
	}
	public static void rnumbers()
	{
		int n1, n2, n3, n4, n5, n6;
		System.Random Rnd = new System.Random();
		n1 = Rnd.Next(1, 9);
		n2 = Rnd.Next(1, 9);
		n3 = Rnd.Next(1, 9);
		n4 = Rnd.Next(1, 9);
		n5 = Rnd.Next(1, 9);
		n6 = Rnd.Next(10, 90);
		n6 = n6 - n6 % 10;
		Console.Write("\nRastgele Sayılarımız: ");
		Console.WriteLine(n1 + " " + n2 + " " + n3 + " " + n4 + " " + n5 + " " + n6);
		Console.Write("Sayıları değiştirmek istiyor musunuz?(e/h)");
		if (Console.ReadLine().ToLower() == "e")
		{
			Console.WriteLine("Yeni sayıları girin:");
			int newn1, newn2, newn3, newn4, newn5, newn6;
			newn1 = Convert.ToInt32(Console.ReadLine());
			newn2 = Convert.ToInt32(Console.ReadLine());
			newn3 = Convert.ToInt32(Console.ReadLine());
			newn4 = Convert.ToInt32(Console.ReadLine());
			newn5 = Convert.ToInt32(Console.ReadLine());
			newn6 = Convert.ToInt32(Console.ReadLine());
			expression(newn1, newn2, newn3, newn4, newn5, newn6);
		}
		else
			expression(n1, n2, n3, n4, n5, n6);
	}
	public static void Main(string[] args)
	{
		Console.Title = "ARİTMETİK İŞLEM BULMA";
		Console.BackgroundColor = ConsoleColor.White;
		Console.Clear();
		Console.ForegroundColor = ConsoleColor.Black;
		Console.Write("-------------------------------\n");
		Console.Write("---- ARİTMETİK İŞLEM BULMA ----\n");
		Console.Write("-------------------------------\n");
		rnumbers();
	}
}