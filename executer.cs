using System;
using System.Collections.Generic;

namespace PL
{
    public class Executer
    {
        private CodeNode current;
        private Registers regs;

        public Executer(CodeTree tree)
        {
            this.current = tree.root.next;
            this.regs = new Registers();

            while(current != null)
            {
                execute(current.code);
                return;
            }
        }

        private void execute(Code code)
        {
            if(code.key.type == Token.TokenType.Add_KEY) execute_add(code);
        }

        private void execute_add(Code code)
        {
            int result = regs.get(code.arg(1)) + regs.get(code.arg(2));
            regs.set(code.arg(0),result);

            //test print result
            Console.WriteLine(regs.get(code.arg(0)));
        }
    }
}
