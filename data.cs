using System;
using System.Collections.Generic;

namespace PL
{
    public class Data
    {
#region static
        private static int lastAddress;
        private static List<Data> dataList;
        private static Dictionary<string,int> dataTable;

        public static void init()
        {
            dataList = new List<Data>();
            dataTable = new Dictionary<string,int>();
            lastAddress = 0;
        }

        public static void print()
        {
            foreach(KeyValuePair<string,int> entry in dataTable)
            {
                Console.WriteLine(entry.Key + " " + dataList[entry.Value]);
            }
        }
#endregion

        public Token.TokenType type;
        public int address;

        private int[] _value_intArray;
        private string _value_string;

        public Data(Token label, Token key, params Token[] args)
        {
            switch(key.type)
            {
                case Token.TokenType.Asciiz_KEY : init_asciiz(args); break;
                case Token.TokenType.Word_KEY : init_word(args); break;
                case Token.TokenType.Space_KEY : init_space(); break;
            }

            this.type = key.type;
            this.address = lastAddress;
            dataList.Add(this);
            dataTable.Add(label.value, this.address);
            lastAddress++;
        }

        public override string ToString()
        {
            string ret = "Dx" + this.address + " : ";
            if(type == Token.TokenType.Word_KEY)
            {
                for(int i=0; i < _value_intArray.Length - 1; i++)
                {
                    ret += _value_intArray[i] + ",";
                }
                ret += _value_intArray[_value_intArray.Length - 1];
            }
            else
            {
                ret += _value_string;
            }

            return ret;
        }

        private void init_asciiz(Token[] args)
        {
            this._value_string = args[0].value;
        }

        private void init_space()
        {
            this._value_string = "";
        }

        private void init_word(Token[] args)
        {
            this._value_intArray = new int[args.Length];
            for(int i=0; i < args.Length; i++)
            {
                this._value_intArray[i] = int.Parse(args[i].value);
            }
        }

        public int getInt(int index)
        {
            if(index < 0 || index >= this._value_intArray.Length) Compiler.Error("Runtime","Index out of range");
            return this._value_intArray[index];
        }

        public void setInt(int index, int value)
        {
            if(index < 0 || index >= this._value_intArray.Length) Compiler.Error("Runtime","Index out of range");
            this._value_intArray[index] = value;
        }

        public string getString()
        {
            return this._value_string;
        }

        public void setString(string value)
        {
            this._value_string = value;
        }
    }
}
