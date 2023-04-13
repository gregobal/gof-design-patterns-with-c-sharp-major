using Visitor;

var structure = new ObjectStructure();

structure.Add(new ElementA());
structure.Add(new ElementB());

structure.Accept(new ConcreteVisitor1());

namespace Visitor
{
    abstract class Visitor
    {
        public abstract void VisitElementA(ElementA elementA);
        public abstract void VisitElementB(ElementB elementB);
    }

    internal class ConcreteVisitor1 : Visitor
    {
        public override void VisitElementA(ElementA elementA)
        {
            elementA.Operation();
        }

        public override void VisitElementB(ElementB elementB)
        {
            elementB.Operation();
        }
    }

    abstract class Element
    {
        public abstract void Accept(Visitor visitor);
    }

    internal class ElementA : Element
    {
        public override void Accept(Visitor visitor)
        {
            visitor.VisitElementA(this);
        }

        public void Operation()
        {
            Console.WriteLine("Operation from A");
        }
    }
    
    internal class ElementB : Element
    {
        public override void Accept(Visitor visitor)
        {
            visitor.VisitElementB(this);
        }

        public void Operation()
        {
            Console.WriteLine("Operation from B");
        }
    }

    internal class ObjectStructure
    {
        private List<Element> _elements = new();

        public void Add(Element element)
        {
            _elements.Add(element);
        }
        
        public void Remove(Element element)
        {
            _elements.Remove(element);
        }

        public void Accept(Visitor visitor)
        {
            foreach (var element in _elements)
            {
                element.Accept(visitor);
            }
        }
    }
}