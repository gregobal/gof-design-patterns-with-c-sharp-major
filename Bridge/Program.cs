using Bridge;

Implementor implementor = new ConcreteImplementor();
Abstraction abstraction = new RefinedAbstraction(implementor);

abstraction.Operation();

namespace Bridge
{
    public abstract class Abstraction
    {
        private readonly Implementor _implementor;

        protected Abstraction(Implementor implementor)
        {
            _implementor = implementor;
        }

        public virtual void Operation()
        {
            _implementor.OperationImpl();
        }
    }
    
    internal class RefinedAbstraction : Abstraction
    {
        public RefinedAbstraction(Implementor implementor) :
            base(implementor)
        {
        }

        public override void Operation()
        {
            Console.WriteLine("Refined");
            base.Operation();
        }
    }
    
    public abstract class Implementor
    {
        public abstract void OperationImpl();
    }

    internal class ConcreteImplementor: Implementor
    {
        public override void OperationImpl()
        {
            Console.WriteLine("Concrete Implemented");
        }
    }
}