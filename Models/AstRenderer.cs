using System.Text;
using MicroML.Models;


namespace MicroML.Services
{
    public static class AstRenderer
    {
        public static string RenderToHtml(AstNode node)
        {
            var sb = new StringBuilder();
            Render(node, sb, 0);
            return sb.ToString();
        }

    public static void Render(AstNode node, StringBuilder sb, int indent)
    {
        var indentStr = new string(' ', indent * 4);

        if (indent == 0)
        {
            sb.AppendLine("<div class='ast'>");
        }

        switch (node)
        {
            case IdentifierNode id:
                sb.AppendLine($"{indentStr}<div class='node'>Identifier: <span class='value'>{id.Name}</span></div>");
                break;

            case FunctionNode func:
                sb.AppendLine($"{indentStr}<div class='node'>Function:</div>");
                sb.AppendLine($"{indentStr}<div style='margin-left:20px;'>Param: <span class='value'>{func.Param}</span></div>");
                sb.AppendLine($"{indentStr}<div style='margin-left:20px;'>Body:</div>");
                Render(func.Body, sb, indent + 2); 
                break;

            case LiteralNode lit:
                sb.AppendLine($"{indentStr}<div class='node'>Literal: <span class='value'>{lit.Value}</span></div>");
                break;

            case BinaryOpNode binOp:
                sb.AppendLine($"{indentStr}<div class='node'>Binary Operation: {binOp.Operator}</div>");
                sb.AppendLine($"{indentStr}<div style='margin-left:20px;'>Left:</div>");
                Render(binOp.Left, sb, indent + 2);
                sb.AppendLine($"{indentStr}<div style='margin-left:20px;'>Right:</div>");
                Render(binOp.Right, sb, indent + 2);
                break;

            default:
                sb.AppendLine($"{indentStr}<div class='node'>Unknown node type</div>");
                break;
    }

    if (indent == 0)
    {
        sb.AppendLine("</div>");
        }
    }
}
}
