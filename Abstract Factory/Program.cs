using Abstract_Factory;

var client1 = new Client(new Factory1());
client1.Run();

var client2 = new Client(new Factory2());
client2.Run();

namespace Abstract_Factory
{
    public class Client
    {
        private AbstractProductA Apa { get; }
        private AbstractProductB Apb { get; }

        public Client(AbstractFactory af)
        {
            Apa = af.CreateProductA();
            Apb = af.CreateProductB();
        }

        public void Run()
        {
            Apb.Interact(Apa);
        }
    }

    public abstract class AbstractFactory
    {
        public abstract AbstractProductA CreateProductA();
        public abstract AbstractProductB CreateProductB();
    }

    public class Factory1: AbstractFactory
    {
        public override AbstractProductA CreateProductA() => new ProductA1();
        public override AbstractProductB CreateProductB() => new ProductB1();
    }
    
    public class Factory2: AbstractFactory
    {
        public override AbstractProductA CreateProductA() => new ProductA2();
        public override AbstractProductB CreateProductB() => new ProductB2();
    }

    public abstract class AbstractProductA
    {
    }

    internal class ProductA1: AbstractProductA
    {
    }
    
    internal class ProductA2: AbstractProductA
    {
    }
    
    public abstract class AbstractProductB
    {
        public abstract void Interact(AbstractProductA apa);
    }
    
    internal class ProductB1: AbstractProductB
    {
        public override void Interact(AbstractProductA apa) =>
            Console.WriteLine($"{this} interacts with " + apa);
    }
    
    internal class ProductB2: AbstractProductB
    {
        public override void Interact(AbstractProductA apa) =>
            Console.WriteLine($"{this} interacts with " + apa);
    }
}