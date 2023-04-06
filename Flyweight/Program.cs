using FlyweightNS;

int extrinsicState = 0;

Flyweight flyweight;
var factory = new FlyweightFactory();

flyweight = factory.GetFlyweight(1);
flyweight.Operation(extrinsicState);

flyweight = factory.GetFlyweight(10);
flyweight.Operation(extrinsicState);

flyweight = new UnsharedConcreteFlyweight();
flyweight.Operation(extrinsicState);

namespace FlyweightNS
{
    public class FlyweightFactory
    {
        private Dictionary<int, Flyweight> pool = new()
        {
            { 1, new ConcreteFlyweight() },
            { 2, new ConcreteFlyweight() },
            { 3, new ConcreteFlyweight() },
        };

        public Flyweight GetFlyweight(int key)
        {
            if (!pool.ContainsKey(key))
            {
                pool.Add(key, new ConcreteFlyweight());
            }

            return pool[key];
        }
    }
    public abstract class Flyweight
    {
        public abstract void Operation(int extrinsicState);
    }

    internal class ConcreteFlyweight : Flyweight
    {
        private int _instrinsicState;

        public override void Operation(int extrinsicState)
        {
            _instrinsicState = extrinsicState;
        }
    }
    
    internal class UnsharedConcreteFlyweight : Flyweight
    {
        private int _allState;

        public override void Operation(int extrinsicState)
        {
            _allState = extrinsicState;
        }
    }
}