using System;
using System.Collections.Generic;

namespace MicroML
{
    public abstract class AstNode { }

    public class IdentifierNode : AstNode
    {
        public string Name { get; set; }
        public IdentifierNode(string name) => Name = name;
    }

    public class FunctionNode : AstNode
    {
        public string Param { get; set; }
        public AstNode Body { get; set; }

        public FunctionNode(string param, AstNode body)
        {
            Param = param;
            Body = body;
        }
    }

    public static class MicroMLParser
    {
        public static AstNode Parse(string input)
        {
            input = input.Trim();

            if (input.StartsWith("fun "))
            {
                var parts = input.Substring(4).Split("->", 2);
                var param = parts[0].Trim();
                var body = parts[1].Trim();
                return new FunctionNode(param, new IdentifierNode(body));
            }

            return new IdentifierNode(input); // fallback
        }
    }
}
