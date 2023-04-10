using MediatorNS;

var mediator = new ConcreteMediator();
var collegue1 = new ConcreteColleague1(mediator);
var collegue2 = new ConcreteColleague2(mediator);

mediator.Colleague1 = collegue1;
mediator.Colleague2 = collegue2;

collegue1.Send("message from ConcreteColleague1");
collegue2.Send("message from ConcreteColleague2");

namespace MediatorNS
{
    public abstract class Mediator
    {
        public abstract void Send(string msg, Colleague colleague);
    }

    public abstract class Colleague
    {
        protected Mediator Mediator;

        public Colleague(Mediator mediator)
        {
            Mediator = mediator;
        }
    }

    internal class ConcreteMediator : Mediator
    {
        public ConcreteColleague1 Colleague1 { get; set; }
        public ConcreteColleague2 Colleague2 { get; set; }
        
        public override void Send(string message, Colleague colleague)
        {
            if (colleague == Colleague1)
            {
                Colleague2.Notify(message);
            }
            else
            {
                Colleague1.Notify(message);
            }
        }
    }

    internal class ConcreteColleague1 : Colleague
    {
        public ConcreteColleague1(Mediator mediator):
            base(mediator)
        {
        }

        public void Send(string message)
        {
            Mediator.Send(message, this);
        }

        public void Notify(string message)
        {
            Console.WriteLine("ConcreteColleague1 received " + message);
        }
    }
    
    internal class ConcreteColleague2 : Colleague
    {
        public ConcreteColleague2(Mediator mediator):
            base(mediator)
        {
        }

        public void Send(string message)
        {
            Mediator.Send(message, this);
        }

        public void Notify(string message)
        {
            Console.WriteLine("ConcreteColleague2 received " + message);
        }
    }
}
