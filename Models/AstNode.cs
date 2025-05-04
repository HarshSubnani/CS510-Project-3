using MicroML.Models;
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

public class LiteralNode : AstNode
{
    public int Value { get; set; }

    public LiteralNode(int value)
    {
        Value = value;
    }

    public override string ToHtml()
    {
        return $"<li>Literal: {Value}</li>";
    }
}

public class BinaryOpNode : AstNode
{
    public string Operator { get; set; }
    public AstNode Left { get; set; }
    public AstNode Right { get; set; }

    public BinaryOpNode(string op, AstNode left, AstNode right)
    {
        Operator = op;
        Left = left;
        Right = right;
    }

    public override string ToHtml()
    {
        return $"<li>BinaryOp: {Operator}<ul>{Left.ToHtml()}{Right.ToHtml()}</ul></li>";
    }
}


public class IdentifierNode : AstNode
{
    public string Name { get; set; }
    public IdentifierNode(string name) => Name = name;

    public override string ToHtml() => $"<li>Identifier: {Name}</li>";
}
