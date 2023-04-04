using Prototype;

var prototype = new ConcretePrototype(1);
var clone1 = prototype.Clone();
var clone2 = prototype.Clone();

Console.WriteLine(clone1.Id == clone2.Id);

namespace Prototype
{
    public abstract class Prototype
    {
        public int Id { get; }

        public Prototype(int id)
        {
            this.Id = id;
        }

        public abstract Prototype Clone();
    }

    internal class ConcretePrototype : Prototype
    {
        public ConcretePrototype(int id) : base(id)
        {
        }

        public override Prototype Clone()
        {
            return new ConcretePrototype(Id);
        }
    }
}
