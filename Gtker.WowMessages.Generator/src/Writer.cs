using System.Text;

namespace Gtker.WowMessages.Generator;

public class Writer
{
    private readonly StringBuilder _sb = new();
    private int _indentation;

    public void Wln(string line)
    {
        W(line);
        Newline();
    }

    public void OpenCurly(string line)
    {
        W(line);
        WNoIndentation(" {");
        Newline();
        IncrementIndentation();
    }

    public void Newline()
    {
        _sb.Append('\n');
    }

    public void WNoIndentation(string line)
    {
        _sb.Append(line);
    }

    public void WlnNoIndentation(string line)
    {
        _sb.Append(line);
        _sb.Append('\n');
    }

    public void W(string line)
    {
        for (var i = 0; i < _indentation; i++)
        {
            _sb.Append("    ");
        }

        _sb.Append(line);
    }

    public void ClosingCurly(string extra = "")
    {
        DecrementIndentation();
        Wln($"}}{extra}");
    }

    public void Body(string line, Action<Writer> func, string end = "")
    {
        OpenCurly(line);
        func(this);
        ClosingCurly(end);
    }

    public void ExpressionBodiedMember(string line, Action<Writer> func)
    {
        W(line);
        WNoIndentation(" =>");
        Newline();
        IncrementIndentation();
        func(this);
        WlnNoIndentation(";");
        DecrementIndentation();
    }

    public string Data() =>
        _sb.ToString();

    public void DecrementIndentation()
    {
        if (_indentation == 0)
        {
            Console.WriteLine("indentation underflow");
            Environment.Exit(1);
        }

        _indentation -= 1;
    }

    public void IncrementIndentation()
    {
        if (_indentation == 255)
        {
            Console.WriteLine("indentation overflow");
            Environment.Exit(1);
        }

        _indentation += 1;
    }
}