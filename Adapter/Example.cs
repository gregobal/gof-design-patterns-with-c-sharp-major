namespace AdapterNS
{
    internal class Example
    {
        public static void Run()
        {
            var traveller = new Traveller();
            traveller.Travel(new Car());

            var elefant = new Elefant();
            IDrivable elefantDrivable = new AnimalToDrivableAdapter(elefant);
            traveller.Travel(elefantDrivable);
        }
    }

    class Traveller
    {
        public void Travel(IDrivable vehicle)
        {
            vehicle.Drive();
        } 
    }

    interface IDrivable
    {
        void Drive();
    }

    class Car : IDrivable
    {
        public void Drive()
        {
            Console.WriteLine("Drive in the car");
        }
    }

    interface IAnimal
    {
        void Move();
    }

    class Elefant : IAnimal
    {
        public void Move()
        {
            Console.WriteLine("Move on the elefant");
        }
    }

    class AnimalToDrivableAdapter(IAnimal animal) : IDrivable
    {
        public void Drive()
        {
            animal.Move();
        }
    }
}
