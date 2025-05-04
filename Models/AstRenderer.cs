using System.Text;
using MicroML.Models;

namespace MicroML.Services
{
    public static class AstRenderer
    {
        public static string RenderToHtml(AstNode node)
        {
            var sb = new StringBuilder();
            sb.AppendLine("<ul class='ast-tree'>");
            Render(node, sb, 0);  
            sb.AppendLine("</ul>");
            return sb.ToString();
        }

        public static void Render(AstNode node, StringBuilder sb, int indent)
        {
            var indentStr = new string(' ', indent * 4);  
            switch (node)
            {
                case FunctionNode func:
                    sb.AppendLine($"{indentStr}<li>Function:");
                    sb.AppendLine($"{indentStr}  <ul>");
                    sb.AppendLine($"{indentStr}    <li>Param: {func.Param}</li>");
                    sb.AppendLine($"{indentStr}    <li>Body:</li>");
                    Render(func.Body, sb, indent + 2); 
                    sb.AppendLine($"{indentStr}  </ul>");
                    sb.AppendLine($"{indentStr}</li>");
                    break;

                case IdentifierNode id:
                    sb.AppendLine($"{indentStr}<li>Identifier: <span class='value'>{id.Name}</span></li>");
                    break;

                case LiteralNode lit:
                    sb.AppendLine($"{indentStr}<li>Literal: <span class='value'>{lit.Value}</span></li>");
                    break;

                case BinaryOpNode binOp:
                    sb.AppendLine($"{indentStr}<li>Binary Operation: {binOp.Operator}");
                    sb.AppendLine($"{indentStr}  <ul>");
                    sb.AppendLine($"{indentStr}    <li>Left:</li>");
                    Render(binOp.Left, sb, indent + 2);
                    sb.AppendLine($"{indentStr}    <li>Right:</li>");
                    Render(binOp.Right, sb, indent + 2);
                    sb.AppendLine($"{indentStr}  </ul>");
                    sb.AppendLine($"{indentStr}</li>");
                    break;

                default:
                    sb.AppendLine($"{indentStr}<li>Unknown node type</li>");
                    break;
            }
        }
    }
}
