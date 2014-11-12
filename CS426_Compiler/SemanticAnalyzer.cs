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
            BasicType stringtype = new BasicType();
            stringtype.name = "String";
            BoolType booltype = new BoolType();
            booltype.name = "bool";
            stringhash.Add(inttype.name,inttype);
            stringhash.Add(floattype.name, floattype);
            stringhash.Add(booltype.name, booltype);
            
        }

        public override void OutAMainMethod(comp5210.node.AMainMethod node)
        {
            
        }

        public override void OutAMethodRecurseMethod(comp5210.node.AMethodRecurseMethod node)
        {
            
        }

        public override void OutAConstantinitConstants(comp5210.node.AConstantinitConstants node)
        {
            string typename = node.GetOne().Text;
            string varname = node.GetTwo().Text;
            Definition typedefn;
            // lookup the type
            if (!stringhash.TryGetValue(typename, out typedefn))
            {
                Console.WriteLine("[" + node.GetSemicolon().Line + "]: " +
                    typename + ", is not defined.");
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

                    if (lhs != rhs)
                    {
                        Console.WriteLine("[" + node.GetSemicolon().Line + "]: " +
                            "types don't match");
                    }
                    else
                    {
                        VariableDefinition vardefn = new VariableDefinition();
                        vardefn.name = varname;
                        vardefn.constant = true;
                        vardefn.vartype = lhs as TypeDefinition;
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

        public override void OutAIntizationInitialization(comp5210.node.AIntizationInitialization node)
        {
            Definition intdef;
            stringhash.TryGetValue("int", out intdef);
            nodehash.Add(node, intdef);   
        }

        public override void OutAFloatizationInitialization(comp5210.node.AFloatizationInitialization node)
        {
            Definition floatdef;
            stringhash.TryGetValue("float", out floatdef);
            nodehash.Add(node, floatdef);
        }

        public override void OutAFirstList(comp5210.node.AFirstList node)
        {
            
        }

        public override void OutASecondList(comp5210.node.ASecondList node)
        {
            
        }

        public override void OutAThirdList(comp5210.node.AThirdList node)
        {
            
        }

        public override void OutAFourthList(comp5210.node.AFourthList node)
        {
            
        }

        public override void OutAWhileList(comp5210.node.AWhileList node)
        {
            
        }

        public override void OutAArrayList(comp5210.node.AArrayList node)
        {
            
        }

        public override void OutASide1E1(comp5210.node.ASide1E1 node)
        {
            base.OutASide1E1(node);
        }

        public override void OutASide2E1(comp5210.node.ASide2E1 node)
        {
            
        }

        public override void OutASide3E1(comp5210.node.ASide3E1 node)
        {
            Definition nodetype;
            nodehash.TryGetValue(node.GetE2(), out nodetype);
            nodehash.Add(node, nodetype);
        }

        //      public override void OutASide1E2(comp5210.node.ASide1E2 node)
        //        {
        //  BoolType boolDef;
        //    Definition rhs, lhs; // get the node's children
        //      nodehash.TryGetValue(node.GetOne(), out rhs);
        //        nodehash.TryGetValue(node.GetTwo(), out lhs);
        //          // check to make sure the types match
        //            if (lhs.GetType() != rhs.GetType())
        //{
        //      Console.WriteLine("[" + node.GetLessThan().Line + "]: " +
        //            "types don't match");
        //      }
        //        else
        //          {
        //            //    boolDef = new BoolType();
        //      boolDef.name = "lessthan";
        //        boolDef.op = "<";
        //          stringhash.Add(boolDef.name, boolDef);
        //           
        //          }
        //        }

        public override void OutASide2E2(comp5210.node.ASide2E2 node)
        {
            base.OutASide2E2(node);
        }

        public override void OutASide3E2(comp5210.node.ASide3E2 node)
        {
            base.OutASide3E2(node);
        }

        public override void OutASide4E2(comp5210.node.ASide4E2 node)
        {
            base.OutASide4E2(node);
        }

        public override void OutASide5E2(comp5210.node.ASide5E2 node)
        {
            base.OutASide5E2(node);
        }

        public override void OutASide6E2(comp5210.node.ASide6E2 node)
        {
            base.OutASide6E2(node);
        }

        public override void OutASide7E2(comp5210.node.ASide7E2 node)
        {
            base.OutASide7E2(node);
        }

        public override void OutASide8E2(comp5210.node.ASide8E2 node)
        {
            Definition nodetype;
            nodehash.TryGetValue(node.GetE3(), out nodetype);
            nodehash.Add(node, nodetype);
        }

        public override void OutASide1E3(comp5210.node.ASide1E3 node)
        {
            Definition lhs, rhs;
            nodehash.TryGetValue(node.GetE3(), out lhs);
            nodehash.TryGetValue(node.GetE4(), out rhs);
            // you should really get the types of both sides and make sure 
            // they match
            // make sure the type of the child is a BasicType, as those
            // are the only addable things.
            if(lhs != rhs)
            {
                Console.WriteLine("[" + node.GetPlus().Line + "]: " +
                    " operand types do not match.");
                nodehash.Add(node, lhs);
            }
            else if (!(lhs is BasicType))
            {
                Console.WriteLine("[" + node.GetPlus().Line + "]: " +
                    " left operand is not an addable type.");
                nodehash.Add(node, lhs);
            }
            else if (!(rhs is BasicType))
            {
                Console.WriteLine("[" + node.GetPlus().Line + "]: " +
                    " right operand is not an addable type.");
                nodehash.Add(node, lhs);
            }
            else
            {
                nodehash.Add(node, lhs);
            }
            
        }

        public override void OutASide2E3(comp5210.node.ASide2E3 node)
        {
            Definition lhs, rhs;
            nodehash.TryGetValue(node.GetE3(), out lhs);
            nodehash.TryGetValue(node.GetE4(), out rhs);
            // you should really get the types of both sides and make sure 
            // they match
            // make sure the type of the child is a BasicType, as those
            // are the only addable things.
            if (lhs != rhs)
            {
                Console.WriteLine("[" + node.GetMinus().Line + "]: " +
                    " operand types do not match.");
                nodehash.Add(node, lhs);
            }
            else if (!(lhs is BasicType))
            {
                Console.WriteLine("[" + node.GetMinus().Line + "]: " +
                    " left operand is not a subtractable type.");
                nodehash.Add(node, lhs);
            }
            else if (!(rhs is BasicType))
            {
                Console.WriteLine("[" + node.GetMinus().Line + "]: " +
                    " right operand is not an aubtractable type.");
                nodehash.Add(node, lhs);
            }
            else
            {
                nodehash.Add(node, lhs);
            }
        }

        public override void OutASide3E3(comp5210.node.ASide3E3 node)
        {
            Definition nodetype;
            nodehash.TryGetValue(node.GetE4(), out nodetype);
            nodehash.Add(node, nodetype);
        }

        public override void OutASide1E4(comp5210.node.ASide1E4 node)
        {
            base.OutASide1E4(node);
        }

        public override void OutASide2E4(comp5210.node.ASide2E4 node)
        {
            base.OutASide2E4(node);
        }

        public override void OutASide3E4(comp5210.node.ASide3E4 node)
        {
            Definition nodetype;
            nodehash.TryGetValue(node.GetE5(), out nodetype);
            nodehash.Add(node, nodetype);
        }

        public override void OutASide1E5(comp5210.node.ASide1E5 node)
        {
            base.OutASide1E5(node);
        }

        public override void OutASide2E5(comp5210.node.ASide2E5 node)
        {
            base.OutASide2E5(node);
        }

        public override void OutASide3E5(comp5210.node.ASide3E5 node)
        {
            Definition intdef;
            stringhash.TryGetValue("int", out intdef);
            nodehash.Add(node, intdef);
        }

        public override void OutASide4E5(comp5210.node.ASide4E5 node)
        {
            Definition floatdef;
            stringhash.TryGetValue("float", out floatdef);
            nodehash.Add(node, floatdef);
        }

        public override void OutASide5E5(comp5210.node.ASide5E5 node)
        {
            string arraytype = node.GetVariable().Text;
            Definition arraytypedefn;
            if(!stringhash.TryGetValue(arraytype, out arraytypedefn))
            {
                Console.WriteLine("[" + node.GetLeftBracket().Line + "]: " +
                   arraytype + " is not defined.");
                nodehash.Add(node, arraytypedefn);
            }
            else if (!(arraytypedefn is BasicType))
            {
                Console.WriteLine("[" + node.GetLeftBracket().Line + "]: " +
                    arraytype + " is an invalid type for an array.");
                nodehash.Add(node, arraytypedefn);
            }
            else
            {
                Definition brackettypedefn;
                nodehash.TryGetValue(node.GetE1(), out brackettypedefn);
                if(brackettypedefn.name != "int")
                {
                   Console.WriteLine("[" + node.GetLeftBracket().Line + "]: " +
                   brackettypedefn + " array parameter must be an int.");
                    nodehash.Add(node, arraytypedefn);
                }
                else
                {
                    ArrayType arraydef = new ArrayType();
                    arraydef.arrtype = brackettypedefn as TypeDefinition;
                    nodehash.Add(node, arraydef);
                }
                
                
            }
            
        }

        public override void OutAVardecl(comp5210.node.AVardecl node)
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
                Definition reallynothingisheresothisisnull;
                if (!stringhash.TryGetValue(varname, out reallynothingisheresothisisnull))//not in string hash
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

        public override void OutAVarassign(comp5210.node.AVarassign node)
        {
            string varname = node.GetVariable().Text;
            Definition typedefn;
            if (!stringhash.TryGetValue(varname, out typedefn))
            {
                Console.WriteLine("[" + node.GetSemicolon().Line + "]: " +
                   varname + " variable is not declared.");
                nodehash.Add(node, typedefn);
            }
            else
            {
                Definition rhs;
                VariableDefinition lhs;
                lhs = typedefn as VariableDefinition;
                nodehash.TryGetValue(node.GetE1(), out rhs);
                
                if (lhs.vartype != rhs)
                {
                    Console.WriteLine("[" + node.GetSemicolon().Line + "]: " +
                        " variable type does not match assignment.");
                    nodehash.Add(node, rhs);
                }
                else
                {
                    nodehash.Add(node, rhs);
                }
            }
        }

 

        //------------------------------------------------

       // public override void OutAWhileStatement(comp5210.node.AWhileStatement node)
        //{
        //    Definition whileexpression;
        //    nodehash.TryGetValue(node.GetE1(), out whileexpression);
        //    if((whileexpression as ProcedureDefinition).)
        //}
    
    }
}
