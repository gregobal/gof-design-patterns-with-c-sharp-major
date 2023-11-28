using AdapterNS;

Target target = new Adapter();
target.Request();

Console.WriteLine(new string('=', 10));
Example.Run();

namespace AdapterNS
{
    public abstract class Target
    {
        public abstract void Request();
    }

    public class Adapter: Target
    {
        private Adaptee _adaptee = new Adaptee();

        public override void Request()
        {
            _adaptee.SpecificRequst();
        }
    }

    internal class Adaptee
    {
        public void SpecificRequst()
        {
            Console.WriteLine("Specific Request");
        }
    }
}