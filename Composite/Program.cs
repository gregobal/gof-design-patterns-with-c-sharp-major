using CompositeNS;

Component root = new Composite("Root");
Component branch1 = new Composite("Branch1");
Component branch2 = new Composite("Branch2");
Component leaf1 = new Leaf("Leaf1");
Component leaf2 = new Leaf("Leaf2");

root.Add(branch1);
root.Add(branch2);
branch1.Add(leaf1);
branch1.Add(leaf2);

root.Operation();

namespace CompositeNS
{
    public abstract class Component
    {
        protected readonly string Name;

        protected Component(string name)
        {
            Name = name;
        }

        public abstract void Operation();
        public abstract void Add(Component component);
        public abstract void Remove(Component component);
        public abstract Component GetChild(int index);
    }

    public class Composite: Component
    {
        private List<Component> _nodes = new ();
        
        public Composite(string name):
            base(name) {}

        public override void Operation()
        {
            Console.WriteLine(Name);
            foreach (var component in _nodes)
            {
                component.Operation();
            }
        }

        public override void Add(Component component)
        {
            _nodes.Add(component);
        }

        public override void Remove(Component component)
        {
            _nodes.Remove(component);
        }

        public override Component GetChild(int index)
        {
            return _nodes[index];
        }
    }

    public class Leaf : Component
    {
        public Leaf(string name) : base(name) {}

        public override void Operation()
        {
            Console.WriteLine(Name);
        }

        public override void Add(Component component)
        {
            throw new InvalidOperationException();
        }

        public override void Remove(Component component)
        {
            throw new InvalidOperationException();
        }

        public override Component GetChild(int index)
        {
            throw new InvalidOperationException();
        }
    }
}