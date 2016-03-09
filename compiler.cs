using System;

#pragma warning disable 0219

namespace PL
{
	public class Compiler
	{
		public static bool DEBUG;

		public static void Main(string[] args)
		{
			if(args.Length > 0)
			{
				if(args[0] == "-t")
				{
					test();
					return;
				}
				if(args[0] == "-d") DEBUG = true;
			}
			//Lex lex = new Lex("/home/arpple/Desktop/file/prog_lang/test.txt");
			Lex lex = new Lex("test.txt");
			Parser parser = new Parser(lex.getTokenStream());
		}

		public static void Error(string header, string msg)
		{
			Console.WriteLine("ERROR> " + header + " : " + msg);
			System.Environment.Exit(0);
		}

		public static void test()
		{
			int[] test = new int[0];
			Console.WriteLine(test.Length);
		}
	}
}
