using System;
using System.Collections.Generic;
#pragma warning disable 0219

namespace PL
{
	public class Compile
	{

		public static void Main(string[] args)
		{
			Token key = new Token(Token.TokenType.Add_KEY,"add",0);
			Token arg1 = new Token(Token.TokenType.Register,"$1",1);
			Token arg2 = new Token(Token.TokenType.Register,"$2",2);
			new Function(key,arg1,arg2);
		}

		private static void print(params int[] args)
		{
			foreach(int arg in args)
			{
				Console.WriteLine(arg);
			}
		}
	}
}
