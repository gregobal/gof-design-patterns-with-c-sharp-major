using ProxyNS;

Subject subject = new Proxy();
subject.Request();

namespace ProxyNS
{
    public abstract class Subject
    {
        public abstract void Request();
    }

    internal class ConcreteSubject: Subject
    {
        public override void Request()
        {
            Console.WriteLine("Concrete Subject");
        }
    }

    internal class Proxy : Subject
    {
        private ConcreteSubject? _subject;

        public override void Request()
        {
            _subject ??= new ConcreteSubject();
            _subject.Request();
        }
    }
}