using System;
using System.Collections.Generic;


namespace PL
{
    public class CodeNode
    {
        private Code code;
        private CodeNode next;

        public CodeNode(Token keyToken, Token[] argsToken)
        {
            this.code = new Code(keyToken, argsToken);
            this.next = null;
        }

        public void setNext(CodeNode next)
        {
            this.next = next;
        }

        public override string ToString()
        {
            return code.ToString();
        }

        public static void printTree(CodeNode node)
        {
            if(node == null) return;

            Console.WriteLine(node);
            printTree(node.next);

        }
    }
}
