using DecoratorNS;

Component component = new ConcreteComponent();
Decorator decoratorA = new ConcreteDecoratorA();
Decorator decoratorB = new ConcreteDecoratorB();

decoratorA.Component = component;
decoratorA.Operation();

decoratorB.Component = component;
decoratorB.Operation();

Console.WriteLine(new string('=', 10));
Example.Run();

namespace DecoratorNS
{
    public abstract class Component
    {
        public abstract void Operation();
    }
    
    public abstract class Decorator: Component
    {
        public Component? Component { protected get; set; }

        public override void Operation()
        {
            Component?.Operation();
        }
    }

    internal class ConcreteComponent : Component
    {
        public override void Operation()
        {
            Console.WriteLine("Concrete Component state");
        }
    }

    internal class ConcreteDecoratorA : Decorator
    {
        string extraState = "Some extra state";

        public override void Operation()
        {
            base.Operation();
            Console.WriteLine(extraState);
        }
    }
    
    internal class ConcreteDecoratorB : Decorator
    {
        void extraBehavior () => Console.WriteLine("Extra Behavior");

        public override void Operation()
        {
            base.Operation();
            extraBehavior();
        }
    }
}