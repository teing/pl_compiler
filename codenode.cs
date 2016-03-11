using System;
using System.Collections.Generic;


namespace PL
{
    public class CodeNode
    {
        public Code code;
        public CodeNode next;

        public CodeNode(Token keyToken, Token[] argsToken)
        {
            this.code = new Code(keyToken, argsToken);
            this.next = null;
        }

        //empty node for root
        public CodeNode()
        {
            this.code = null;
            this.next = null;
        }

        public override string ToString()
        {
            return code.ToString();
        }

        public void printTree()
        {
            Console.WriteLine(this.ToString());
            if(next != null)
                next.printTree();
        }
    }
}
