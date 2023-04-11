using MementoNS;

var originator = new Originator();
originator.State = "on";
Console.WriteLine(originator);

var caretaker = new Caretaker();
caretaker.Memento = originator.CreateMemento();

originator.State = "off";
Console.WriteLine(originator);

originator.SetMemento(caretaker.Memento);
Console.WriteLine(originator);

namespace MementoNS
{
    public class Memento
    {
        public string State { get; private set; }

        public Memento(string state)
        {
            State = state;
        }
    }

    internal class Caretaker
    {
        public Memento Memento { get; set; }
    }

    internal class Originator
    {
        public string State { get; set; }

        public void SetMemento(Memento memento)
        {
            State = memento.State;
        }

        public Memento CreateMemento()
        {
            return new Memento(State);
        }

        public override string ToString()
        {
            return $"Originator state is {State}";
        }
    }
}