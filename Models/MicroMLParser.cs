using System;
using MicroML.Models;

namespace MicroML.Services
{
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

            return new IdentifierNode(input);
        }
    }
}
