using ChainOfResponsibility;

Handler h1 = new ConcreteHandler1();
Handler h2 = new ConcreteHandler2();

h1.Successor = h2;
h1.HandleRequest(1);
h1.HandleRequest(2);
h1.HandleRequest(3);

namespace ChainOfResponsibility
{
    public abstract class Handler
    {
        public Handler? Successor { get; set; }
        public abstract void HandleRequest(int request);
    }

    internal class ConcreteHandler1: Handler
    {
        public override void HandleRequest(int request)
        {
            if (request == 1)
            {
                Console.WriteLine("Handler One");
            }
            else
            {
                Successor?.HandleRequest(request);
            }
        }
    }

    internal class ConcreteHandler2: Handler
    {
        public override void HandleRequest(int request)
        {
            if (request == 2)
            {
                Console.WriteLine("Handler Two");
            }
            else
            {
                Successor?.HandleRequest(request);
            }
        }
    }
}
