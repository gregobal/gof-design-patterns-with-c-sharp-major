using Interpreter;

var context = new Context()
{
    Vocabulary = 'a',
    Source = "aaa"
};

var expression = new NonterminalExpression();
expression.Interpret(context);

Console.WriteLine(context.Result);

namespace Interpreter
{
    public class Context
    {
        public string Source { get; set; }
        public char Vocabulary { get; set; }
        public bool Result { get; set; }
        public int Position { get; set; }
    }
    
    public abstract class AbstractExpression
    {
        public abstract void Interpret(Context context);
    }

    public class TerminalExpression : AbstractExpression
    {
        public override void Interpret(Context context)
        {
            context.Result = context.Source[context.Position] == context.Vocabulary;
        }
    }

    public class NonterminalExpression : AbstractExpression
    {
        private AbstractExpression _nonterminalExpression;
        private AbstractExpression _terminalExpression;

        public override void Interpret(Context context)
        {
            if (context.Position < context.Source.Length)
            {
                _terminalExpression = new TerminalExpression();
                _terminalExpression.Interpret(context);
                context.Position++;

                if (context.Result)
                {
                    _nonterminalExpression = new NonterminalExpression();
                    _nonterminalExpression.Interpret(context);
                }
            }
        }
        
    }
}