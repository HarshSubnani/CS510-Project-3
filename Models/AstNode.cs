namespace MicroML.Models;

public abstract class AstNode
{
    public abstract string ToHtml();
}

public class VariableNode : AstNode
{
    public string Name { get; set; }
    public VariableNode(string name) => Name = name;
    public override string ToHtml() => $"<li>Var: {Name}</li>";
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
    public override string ToHtml() => $"<li>Fun({Param})<ul>{Body.ToHtml()}</ul></li>";
}
