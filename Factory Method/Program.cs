using FactoryMethod;

Creator creator = new ConcreteCreator();
Product product = creator.FactoryMethod();

namespace FactoryMethod
{
    public abstract class Product
    {
    }

    internal class ConcreteProduct: Product
    {
        public ConcreteProduct()
        {
            Console.WriteLine(GetHashCode());
        }
    }

    public abstract class Creator
    {
        public abstract Product FactoryMethod();
    }

    internal class ConcreteCreator : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProduct();
        }
    }
}