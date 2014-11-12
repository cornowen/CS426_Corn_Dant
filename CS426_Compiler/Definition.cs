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
        public int length;
        public TypeDefinition arrtype;
    }

    // variable definition
    public class VariableDefinition : Definition
    {
        public TypeDefinition vartype;
    }

    // subprogram definition
    public class MethodDefinition : Definition
    {
        public Array parameters;
    }

}
