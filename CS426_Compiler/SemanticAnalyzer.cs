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
        public override void OutASide1Vardecl(comp5210.node.ASide1Vardecl node)
        {
            string typename = node.GetTypename().Text;
            string varname = node.GetVarname().Text;
            Definition typedefn;
            // lookup the type
            if (!stringhash.TryGetValue(typename, out typedefn))
            {
                Console.WriteLine("[" + node.GetTypename().Line + "]: " +
                    typename + " is not defined.");

                nodehash.Add(node, typedefn); //adds the type to the node hash even if not found
            }
            // check to make sure what we got back is a type
            else if (!(typedefn is TypeDefinition))
            {
                Console.WriteLine("[" + node.GetSemicolon().Line + "]: " +
                    typename + " is an invalid type.");
            }
            else
            {
                // add this variable to the hash table
                // note you need to add checks to make sure this 
                // variable name isn't already defined.
                VariableDefinition vardefn = new VariableDefinition();
                vardefn.name = varname;
                vardefn.vartype = typedefn as TypeDefinition;
                stringhash.Add(vardefn.name, vardefn);
            }
        }

    }
}
