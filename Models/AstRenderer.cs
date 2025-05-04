using System.Text;

namespace MicroML
{
    public static class AstRenderer
    {
        public static string RenderToHtml(AstNode node)
        {
            var sb = new StringBuilder();
            Render(node, sb, 0);
            return sb.ToString();
        }

        private static void Render(AstNode node, StringBuilder sb, int indent)
        {
            var indentStr = new string(' ', indent * 4);

            switch (node)
            {
                case IdentifierNode id:
                    sb.AppendLine($"{indentStr}<div>Identifier: {id.Name}</div>");
                    break;

                case FunctionNode func:
                    sb.AppendLine($"{indentStr}<div>Function:</div>");
                    sb.AppendLine($"{indentStr}<div style='margin-left:20px;'>Param: {func.Param}</div>");
                    sb.AppendLine($"{indentStr}<div style='margin-left:20px;'>Body:</div>");
                    Render(func.Body, sb, indent + 2);
                    break;

                default:
                    sb.AppendLine($"{indentStr}<div>Unknown node</div>");
                    break;
            }
        }
    }
}
