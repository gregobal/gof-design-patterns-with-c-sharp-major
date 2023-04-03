using Builder;

var builder = new ConcreteBuilder();
var director = new Director(builder);
director.Construct();

var product = builder.GetResult();
product.Show();

namespace Builder
{
    public class Director
    {
        private Builder _builder;

        public Director(Builder builder)
        {
            _builder = builder;
        }

        public void Construct()
        {
            _builder.BuildPartA();
            _builder.BuildPartB();
            _builder.BuildPartC();
        }
    }

    public class Product
    {
        private List<string> parts = new List<string>();

        public void Add(string part)
        {
            parts.Add(part);
        }

        public void Show()
        {
            foreach (var p in parts)
            {
                Console.WriteLine(p);
            }
        }
    }

    public abstract class Builder
    {
        public abstract void BuildPartA();
        public abstract void BuildPartB();
        public abstract void BuildPartC();
        public abstract Product GetResult();
    }

    internal class ConcreteBuilder : Builder
    {
        private Product _product = new Product();

        public override void BuildPartA() {
            _product.Add("Part A");
        }

        public override void BuildPartB() {
            _product.Add("Part B");
        }

        public override void BuildPartC() {
            _product.Add("Part C");
        }

        public override Product GetResult() => _product;
    }
}