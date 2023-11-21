
namespace Factory_Method
{
    static class Example
    {
        public static void Run()
        {
            var vendingMachine1 = new CoffeeMachine("My Coffee Machine");
            vendingMachine1.Make();

            var vendingMachine2 = new SodaMachine("My Soda Machine");
            vendingMachine2.Make();
        }
    }

    abstract class VendingMachine(string title)
    {
        public string Title => title;

        abstract public Drink Make();
    }

    class CoffeeMachine(string title) : VendingMachine(title) 
    {     
        public override Drink Make()
        {
            return new Coffee();
        }
    }

    class SodaMachine(string title) : VendingMachine(title)
    {  
        public override Drink Make()
        {
            return new Soda();
        }
    }

    abstract class Drink
    {
        public Drink(string name)
        {
            Console.WriteLine($"{name} is ready");
        }
    }

    class Coffee : Drink
    {
        public Coffee() :
            base("Coffee")
        { }
    }

    class Soda : Drink
    {
        public Soda() :
            base("Soda")
        { }
    }
}
