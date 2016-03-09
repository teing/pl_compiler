using System;
using System.Collections.Generic;

namespace PL
{
    public class Code
    {
        Token key;
        Token[] args;

        public Code(Token key, params Token[] args)
        {
            this.key = key;
            if(args.Length > 0)
            {
                this.args = args;
            }
            else
            {
                this.args = new Token[0];
            }
        }

        public override string ToString()
        {
            string str = key.value + " : ";
            foreach(Token arg in args)
            {
                str += arg.value + " ";
            }
            return str;
        }
    }
}
