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
            return new FunctionNode(param, ParseExpression(body));
        }

            return ParseExpression(input);
    }


        public static AstNode ParseExpression(string expr)
        {
            expr = expr.Trim();

            if (expr.Contains("+"))
            {
                var parts = expr.Split('+', 2);
                return new BinaryOpNode("+",
                ParseExpression(parts[0]),
                ParseExpression(parts[1]));
            }
            
            else if (int.TryParse(expr, out var literalValue))
            {
                return new LiteralNode(literalValue);
            }
            
            else
            {
                return new IdentifierNode(expr);
            }
        }

    }
}
