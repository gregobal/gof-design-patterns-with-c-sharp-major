using Observer;
using pull = ObserverPull;
using push = ObserverPush;

// pull model
var subject1 = new pull.ConcreteSubject();
var observer1 = new pull.ConcreteObserver(subject1);
var observer2 = new pull.ConcreteObserver(subject1);

subject1.Attach(observer1);
subject1.Attach(observer2);
subject1.State = "from subject 1";
subject1.Notify();
Console.WriteLine(observer1);
Console.WriteLine(observer2);

subject1.Detach(observer1);
subject1.State = "new state from subject 1";
subject1.Notify();
Console.WriteLine(observer1);
Console.WriteLine(observer2);

// push model
var subject2 = new push.ConcreteSubject();
var observer3 = new push.ConcreteObserver(subject2);
var observer4 = new push.ConcreteObserver(subject2);

subject2.Attach(observer3);
subject2.Attach(observer4);
subject2.State = "from subject 2";
subject2.Notify();
Console.WriteLine(observer3);
Console.WriteLine(observer4);

Console.WriteLine(new string('=', 10));
Example.Run();


namespace ObserverPull
{
    public abstract class Observer
    {
        public abstract void Update();
    }

    public abstract class Subject
    {
        private List<Observer> _observers = new();

        public void Attach(Observer observer)
        {
            _observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }
    }

    internal class ConcreteSubject : Subject
    {
        public string State { get; set; }
    }

    internal class ConcreteObserver : Observer
    {
        private string _state;
        private ConcreteSubject _subject;

        public ConcreteObserver(ConcreteSubject subject)
        {
            _subject = subject;
        }

        public override void Update()
        {
            _state = _subject.State;
        }

        public override string ToString()
        {
            return $"Observer {GetHashCode()} has state {_state}";
        }
    }
}

namespace ObserverPush
{
    public abstract class Observer
    {
        public abstract void Update(string state);
    }

    public abstract class Subject
    {
        private List<Observer> _observers = new();

        public void Attach(Observer observer)
        {
            _observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            _observers.Remove(observer);
        }
        
        public abstract string State { get; set; }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(State);
            }
        }
    }

    internal class ConcreteSubject : Subject
    {
        public override string State { get; set; }
    }

    internal class ConcreteObserver : Observer
    {
        private string _state;
        private ConcreteSubject _subject;

        public ConcreteObserver(ConcreteSubject subject)
        {
            _subject = subject;
        }

        public override void Update(string state)
        {
            _state = state;
        }

        public override string ToString()
        {
            return $"Observer {GetHashCode()} has state {_state}";
        }
    }
}