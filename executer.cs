using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PL
{
    public class Executer
    {
        private CodeTree tree;
        private CodeNode current;
        private Registers regs;

        public Executer(CodeTree tree)
        {
            this.current = tree.root.next;
            this.regs = new Registers();
            this.tree = tree;

            while(this.current != null)
            {
                execute(current.code);
                next();
            }
            if(Compiler.DEBUG) Console.WriteLine("Debug Result of $t1 : " + regs.get("$t1"));
        }

        private void execute(Code code)
        {
            if(Compiler.DEBUG) Console.WriteLine("Executing : "+ code);

            if(code.key.type == Token.TokenType.Add_KEY) execute_add(code);
            else if(code.key.type == Token.TokenType.Addi_KEY) execute_addi(code);
            else if(code.key.type == Token.TokenType.Beq_KEY) execute_beq(code);

        }

        private void next()
        {
            this.current = this.current.next;
        }

#region Math_Op
        private void execute_add(Code code)
        {
            //add $0 $1 $2 => $0 = $1 + $2
            int result = regs.get(code.value(1)) + regs.get(code.value(2));
            regs.set(code.value(0),result);
        }

        private void execute_addi(Code code)
        {
            //addi $0 $1 x => $0 = $1 + x
            int result = regs.get(code.value(1)) + int.Parse(code.value(2));
            regs.set(code.value(0),result);
        }

        private void execute_sub(Code code)
        {
            //sub $0 $1 $2 => $0 = $1 - $2
            int result = regs.get(code.value(1)) - regs.get(code.value(2));
            regs.set(code.value(0),result);
        }

        private void execute_subi(Code code)
        {
            //subi $0 $1 x => $0 = $1 - x
            int result = regs.get(code.value(1)) - int.Parse(code.value(2));
            regs.set(code.value(0),result);
        }

        private void execute_mul(Code code)
        {
            //mul $0 $1 $2 => $0 = $1 * $2
            int result = regs.get(code.value(1)) * regs.get(code.value(2));
            regs.set(code.value(0),result);
        }

        private void execute_muli(Code code)
        {
            //muli $0 $1 x => $0 = $1 * x
            int result = regs.get(code.value(1)) * int.Parse(code.value(2));
            regs.set(code.value(0),result);
        }

        private void execute_div(Code code)
        {
            //div $0 $1 $2 => $0 = $1 / $2
            int result = regs.get(code.value(1)) / regs.get(code.value(2));
            regs.set(code.value(0),result);
        }

        private void execute_divi(Code code)
        {
            //div $0 $1 x => $0 = $1 / x
            int result = regs.get(code.value(1)) / int.Parse(code.value(2));
            regs.set(code.value(0),result);
        }
#endregion

#region Logic_Op
        private void execute_and(Code code)
        {

        }

        private void execute_andi(Code code)
        {

        }

        private void execute_or(Code code)
        {

        }

        private void execute_ori(Code code)
        {

        }

        private void execute_nor(Code code)
        {

        }
#endregion

#region Branch
        private void execute_beq(Code code)
        {
            //beq $0 $1 addr => if $0 == $1 , jump addr
            bool result = regs.get(code.value(0)) == regs.get(code.value(1));
            if(result) jump(code.value(2));
        }

        private void execute_bnq(Code code)
        {
            //beq $0 $1 addr => if $0 != $1 , jump addr
            bool result = regs.get(code.value(0)) != regs.get(code.value(1));
            if(result) jump(code.value(2));
        }
#endregion

#region Function
        public static Regex labelAdress = new Regex("^[0-9A-Za-z]+$");

        private void jump(string address)
        {
            if(labelAdress.IsMatch(address))
            {
                CodeNode node = this.tree.getNodeFromLabel(address + ":");
                if(node != null)
                {
                    this.current = node;
                }
                else
                {
                    Compiler.Error("Executer","can't jump to address " + address);
                }
            }
        }
#endregion
    }
}
