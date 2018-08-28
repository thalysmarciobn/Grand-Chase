using System;
using Common.Communication;

namespace Common.Attributes
{
    public class OpcodeInAttribute : Attribute
    {
        public Opcodes.Center Center { get; }
        
        public Opcodes.Game Game { get; }
    
        public OpcodeInAttribute(Opcodes.Center code)
        {
            Center = code;
        }
    
        public OpcodeInAttribute(Opcodes.Game code)
        {
            Game = code;
        }
    }
}