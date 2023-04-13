using TemplateMethod;

AbstractClass instance = new ConcreteClass();
instance.TemplateMethod();

namespace TemplateMethod
{
    public abstract class AbstractClass
    {
        protected abstract void PrimitiveOperation1();
        protected abstract void PrimitiveOperation2();

        public void TemplateMethod()
        {
            PrimitiveOperation1();
            PrimitiveOperation2();
        }
    }

    class ConcreteClass: AbstractClass
    {
        protected override void PrimitiveOperation1()
        {
            Console.WriteLine("PrimitiveOperation1");
        }

        protected override void PrimitiveOperation2()
        {
            Console.WriteLine("PrimitiveOperation2");
        }
    }
}