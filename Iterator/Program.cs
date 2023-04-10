using System.Collections;
using IteratorNS;

Aggregate agg = new ConcreteAggregate();

agg[0] = 0;
agg[1] = 1;
agg[2] = 2;

Iterator i = agg.GetIterator();

for (var el = i.First(); !i.IsDone(); el = i.Next())
{
    Console.WriteLine(el);
}

namespace IteratorNS
{
    public abstract class Iterator
    {
        public abstract object First();
        public abstract object Next();
        public abstract bool IsDone();
        public abstract object Current();
    }

    public abstract class Aggregate
    {
        public abstract Iterator GetIterator();
        public abstract int Count { get; }
        public abstract object this[int index] { get; set; }
    }

    internal class ConcreteIterator : Iterator
    {
        private readonly Aggregate _aggregate;
        private int _current = 0;

        public ConcreteIterator(Aggregate aggregate)
        {
            _aggregate = aggregate;
        }

        public override object First()
        {
            return _aggregate[0];
        }

        public override object Next()
        {
            if (_current++ < _aggregate.Count - 1)
            {
                return _aggregate[_current];
            }
            
            return null;
        }

        public override object Current()
        {
            return _aggregate[_current];
        }

        public override bool IsDone()
        {
            if (_current < _aggregate.Count)
            {
                return false;
            }

            _current = 0;
            return true;
        }
    }

    internal class ConcreteAggregate : Aggregate
    {
        private ArrayList items = new ArrayList();

        public override Iterator GetIterator()
        {
            return new ConcreteIterator(this);
        }

        public override int Count => items.Count;

        public override object this[int index]
        {
            get => items[index];
            set => items.Insert(index, value);
        }
    }
}