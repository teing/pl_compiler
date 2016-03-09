using System;
using System.Collections.Generic;

namespace PL
{
    public class Parser
    {
        private List<Token> _tokenStream;
        private Token token
        {
            get
            {
                if(_tokenStream.Count > 0)
                    return _tokenStream[0];
                else
                    return null;
            }
        }

        public Parser(List<Token> tokenStream)
        {
            Console.WriteLine("Parser start ...");
            this._tokenStream = tokenStream;
            Function.initFunction();
            program();
            Console.WriteLine("Parser completed");
        }

        private bool nextToken()
        {
            //Console.WriteLine("next : " + token);
            _tokenStream.RemoveAt(0);
            if(token != null)
                return true;
            else
                return false;
        }

        private void check(Token.TokenType type)
        {
            if(token == null)
            {
                Compiler.Error("Parser", "syntax error " + token.ToString() + " in line " + token.lineNumber);
            }
            if(token.type != type)
            {
                Compiler.Error("Parser", "syntax error expected token of type '" + type +  "' , found " + token.ToString() + " in line " + token.lineNumber);
            }
        }

        private void nextLine()
        {
            if(token == null) return;
            while(token.type == Token.TokenType.Endl_KEY)
            {
                if(!nextToken())
                    break;
            }
        }

        private void checkFunction(Token.TokenType key)
        {
            //Console.WriteLine(token.lineNumber);
            Function f = Function.get(key);
            check(f.key);
            nextToken();
            for(int i=0;i < f.args.Count; i++)
            {
                check(f.args[i]);
                nextToken();

                //consume comma
                if(i < f.args.Count - 1)
                {
                    check(Token.TokenType.Comma_KEY);
                    nextToken();
                }
            }
            //Console.WriteLine("ARP:" + token);
            nextLine();
        }

        private void program()
        {
            data_segment();
            text_segment();
        }
#region Data
        private void data_segment()
        {
            check(Token.TokenType.Data_KEY);
            nextToken();
            nextLine();

            data_st_list();
        }

        private void data_st_list()
        {
            if(token.type != Token.TokenType.Text_KEY)
            {
                check(Token.TokenType.Label);
                nextToken();
                data_st();
                data_st_list();
            }
        }

        private void data_st()
        {
            if(token.type == Token.TokenType.Ascii_KEY) ascii_st();
            else if(token.type == Token.TokenType.Asciiz_KEY) asciiz_st();
            else if(token.type == Token.TokenType.Word_KEY) word_st();
            else if(token.type == Token.TokenType.Space_KEY) space_st();
            else
            {
                Compiler.Error("Parser>data_st","wtf, why you give me " + token.ToString() + " in line " + token.lineNumber );
            }

        }

        private void ascii_st()
        {
            nextToken();    //consume key
            check(Token.TokenType.String);
            nextToken();
            nextLine();
        }

        private void asciiz_st()
        {
            nextToken();    //consume key
            check(Token.TokenType.String);
            nextToken();
            nextLine();
        }

        private void word_st()
        {
            nextToken();    //consume key
            check(Token.TokenType.Word);
            nextToken();
            nextLine();
        }

        private void space_st()
        {
            nextToken();    //consume key
            check(Token.TokenType.Const);
            nextToken();
            nextLine();
        }
#endregion

        private void text_segment()
        {
            check(Token.TokenType.Text_KEY);
            nextToken();
            nextLine();

            text_block_list();
        }

        private void text_block_list()
        {
            if(token == null) return;
            check(Token.TokenType.Label);

            nextToken();    //consume Label
            nextLine();

            text_block();
            text_block_list();
        }

        private void text_block()
        {
            text_st_list();
        }

        private void text_st_list()
        {
            if(token == null || token.type == Token.TokenType.Label) return;

            text_st();
            text_st_list();
        }

        private void text_st()
        {
            checkFunction(token.type);
        }



    }
}
