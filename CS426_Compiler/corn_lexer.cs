/* This file was generated by SableCC (http://www.sablecc.org/). */

using System;
using System.Collections;
using System.Text;
using System.IO;
using comp5210.lexer;
using comp5210.node;

class lexer_to_test
{
  public static void Main(String[] args)
  {
    Lexer l = new Lexer(new System.IO.StreamReader(args[0]));
    while (true)
    {
        Token token = l.Next();
        Console.WriteLine ("Read token '" + token.GetType().Name +
            "', Text = [" + token.Text + "] at [" + token.Line +
            "," + token.Pos + "]");
        if ( token is EOF ) break;
    }
  }
}
