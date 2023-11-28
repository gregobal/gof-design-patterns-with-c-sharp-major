namespace DecoratorNS
{
    internal class Example
    {
        public static void Run()
        {
            var coffee = new Coffee();
            var tea = new Tea();
            var coffeeWithMilk = new DrinkWithMilk(coffee);
            var coffeeWithMilkWithSugar = new DrinkWithSugar(coffeeWithMilk);

            Console.WriteLine(coffee);
            Console.WriteLine(tea);
            Console.WriteLine(coffeeWithMilk);
            Console.WriteLine(coffeeWithMilkWithSugar);
        }        

        abstract class Drink(string name)
        {
            public string Name => name;

            public abstract int GetCost();

            public override string ToString()
            {
                return $"{Name} costs {GetCost()}";
            }
        }

        class Coffee() : Drink("Coffee")
        {
            public override int GetCost()
            {
                return 10;
            }
        }

        class Tea() : Drink("Tea")
        {
            public override int GetCost()
            {
                return 5;
            }
        }

        abstract class DrinkDecorator(string name, Drink drink) : Drink(name)
        {
            protected Drink Drink => drink;
        }

        class DrinkWithMilk(Drink drink) : DrinkDecorator($"{drink.Name} with milk", drink)
        {
            public override int GetCost()
            {
                return Drink.GetCost() + 2;
            }
        }

        class DrinkWithSugar(Drink drink) : DrinkDecorator($"{drink.Name} with sugar", drink)
        {
            public override int GetCost()
            {
                return Drink.GetCost() + 1;
            }
        }
    }
}
