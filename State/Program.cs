using StateNS;

var context = new Contest(new ConcreteStateA());
context.Request();
context.Request();

namespace StateNS
{
    public abstract class State
    {
        protected State()
        {
            Console.WriteLine($"Current state is {this.GetType().Name}");
        }
        public abstract void Handle(Contest contest);
    }
    
    public class Contest
    {
        public State State { get; set; }

        public Contest(State state)
        {
            State = state;
        }

        public void Request()
        {
            State.Handle(this);
        }
    }

    internal class ConcreteStateA : State
    {
        public override void Handle(Contest contest)
        {
            contest.State = new ConcreteStateB();
        }
    }
    
    internal class ConcreteStateB : State
    {
        public override void Handle(Contest contest)
        {
            contest.State = new ConcreteStateA();
        }
    }
}
