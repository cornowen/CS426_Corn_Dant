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

        public override void OutASide1Vardecl(comp5210.node.ASide1Vardecl node)
        {
            string typename = node.GetOne().Text;
            string varname = node.GetTwo().Text;
            Definition typedefn;
            // lookup the type
            if (!stringhash.TryGetValue(typename, out typedefn))
            {
                Console.WriteLine("[" + node.GetOne().Line + "]: " +
                    typename + " is not defined.");
                nodehash.Add(node, typedefn);
            }
            // check to make sure what we got back is a type
            else if (!(typedefn is TypeDefinition))
            {
                Console.WriteLine("[" + node.GetSemicolon().Line + "]: " +
                    typename + " is an invalid type.");
                nodehash.Add(node, typedefn);
            }
            else
            {
                // add this variable to the hash table
                // note you need to add checks to make sure this 
                // variable name isn't already defined.
                if (!stringhash.TryGetValue(varname, out typedefn))//not in string hash
                {
                    //add to string hash
                    VariableDefinition vardefn = new VariableDefinition();
                    vardefn.name = varname;
                    vardefn.vartype = typedefn as TypeDefinition;
                    stringhash.Add(vardefn.name, vardefn);
                }
                else 
                { 
                    // error: varname already defined
                    Console.WriteLine("[" + node.GetSemicolon().Line + "]: " +
                    varname + " is already defined elsewhere.");
                    nodehash.Add(node, typedefn);
                }
            }
        }

        public override void OutAConstantinitConstants(comp5210.node.AConstantinitConstants node)
        {
            string typename = node.GetOne().ToString();
            string varname = node.GetTwo().ToString();
            Definition typedefn;
            // lookup the type
            if (!stringhash.TryGetValue(typename, out typedefn))
            {
                Console.WriteLine("[" + node.GetSemicolon().Line + "]: " +
                    typename + " is not defined.");
                nodehash.Add(node, typedefn);
            }
            // check to make sure what we got back is a type
            else if (!(typedefn is TypeDefinition))
            {
                Console.WriteLine("[" + node.GetSemicolon().Line + "]: " +
                    typename + " is an invalid type.");
                nodehash.Add(node, typedefn);
            }
            else
            {
                // add this variable to the hash table
                // note you need to add checks to make sure this 
                // variable name isn't already defined.
                if (!stringhash.TryGetValue(varname, out typedefn))//not in string hash
                {
                    //check left and right hand side to see if the types match
                    Definition rhs, lhs;
                    nodehash.TryGetValue(node.GetInitialization(), out rhs);
                    stringhash.TryGetValue(typename, out lhs);

                    if ((lhs as VariableDefinition).vartype != rhs)
                    {
                        Console.WriteLine("[" + node.GetSemicolon().Line + "]: " +
                            "types don't match");
                    }
                    else
                    {
                        VariableDefinition vardefn = new VariableDefinition();
                        vardefn.name = varname;
                        vardefn.constant = true;
                        vardefn.vartype = typedefn as TypeDefinition;
                        stringhash.Add(vardefn.name, vardefn);
                    }
                }
                else
                {
                    // error: varname already defined
                    Console.WriteLine("[" + node.GetSemicolon().Line + "]: " +
                    varname + " is already defined elsewhere.");
                    nodehash.Add(node, typedefn);
                }
            }
        }

    }
}
