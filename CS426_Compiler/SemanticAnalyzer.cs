using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace parser
{
    class SemanticAnalyzer : comp5210.analysis.DepthFirstAdapter
    {
        System.Collections.Generic.Dictionary<string,parser.Definition>
            stringhash = new Dictionary<string,Definition>();
        System.Collections.Generic.Dictionary<comp5210.node.Node, parser.Definition>
            nodehash = new Dictionary<comp5210.node.Node, Definition>(); // imma comment
        // before theclass starts, create the two hashes and 
        // add int and float

        //constants
        //In outAIntConst check that:
        //"int" is a data type, X is not already declared, type of e1 is int
        //const = {int} const_t var var equal e1 semicolon;


        //inAProgram
        public override void InAProgram(comp5210.node.AProgram node)
        {
            BasicType inttype = new BasicType();
            inttype.name = "int";
            BasicType floattype = new BasicType();
            floattype.name = "float";
            stringhash.Add(inttype.name,inttype);
            stringhash.Add(floattype.name, floattype);
            
        }

        //outASide1Vardecl


    }
}
