using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace parser
{
    // general definition
    public abstract class Definition
    {
        public string name;
    }

    // type definitions
    public abstract class TypeDefinition : Definition
    {
    }
    public class BasicType : TypeDefinition
    {
    }
    public class ArrayType : TypeDefinition
    {
        public TypeDefinition arrtype;
    }
    public class BoolType : TypeDefinition
    {
    }
    public class StringType : TypeDefinition
    {
    }

    // variable definition
    public class VariableDefinition : Definition
    {
        public TypeDefinition vartype;
        public bool constant;
    }

    // subprogram definitions
    public class SubprogramDefinition : Definition
    {
    }
    public class ProcedureDefinition : SubprogramDefinition
    {
        // store bool expression in () maybe?
    }
    public class MethodDefinition : SubprogramDefinition
    {
        public Array parameters;
    }

}
