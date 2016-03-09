using System;
using System.Collections.Generic;

public class Registers
{
	public static Dictionary<string,int> register;
	
	public static void Main(string[] args)
	{
		Console.WriteLine("hello world");
		Registers regs = new Registers();
		
		for(int i=0;i<5;i++)
		{
			Console.WriteLine(Registers.reg["zero"]);
		}
	}
	
	public Registers()
	{
		register = new Dictionary<string,int>();
		
		register.Add("zero", 0);
		register.Add("at", 0);
		register.Add("a0", 0); 
		register.Add("a1", 0); 
		register.Add("a2", 0);
		register.Add("a3", 0);
		register.Add("t0", 0);
		register.Add("t1", 0);
		register.Add("t2", 0);
		register.Add("t3", 0);
		register.Add("t4", 0);
		register.Add("t5", 0);
		register.Add("t6", 0);
		register.Add("t7", 0);
		register.Add("s0", 0);
		register.Add("s1", 0);
		register.Add("s2", 0);
		register.Add("s3", 0);
		register.Add("s4", 0);
		register.Add("s5", 0);
		register.Add("s6", 0);
		register.Add("s7", 0);
		register.Add("t8", 0);
		register.Add("t9", 0);
	}		
	
}
