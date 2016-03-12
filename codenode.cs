using System;
using System.Collections.Generic;


namespace PL
{
    public class CodeNode
    {
        public int address;
        public Code code;
        public CodeNode next;

        public CodeNode(int address, Token keyToken, Token[] argsToken)
        {
            this.address = address;
            this.code = new Code(keyToken, argsToken);
            this.next = null;
        }

        //empty node for root
        public CodeNode()
        {
            this.address = 0;
            this.code = null;
            this.next = null;
        }

        public override string ToString()
        {
            return "Tx" + address.ToString() + " => " + code.ToString();
        }

        public void printTree()
        {
            Console.WriteLine(this.ToString());
            if(next != null)
                next.printTree();
        }
    }
}
