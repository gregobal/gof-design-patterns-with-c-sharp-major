
namespace Observer
{
    internal class Example
    {
        internal static void Run()
        {
            var master = new Master();

            var minion = new Minion();
            master.CallMinion(minion);
            
            master.CallMinion(new Minion());

            master.Command("Kill all humans!");

            master.KickMinion(minion);

            master.Command("Collect skulls!");
        }
    }

    interface IMinionObserver
    {
        void DoIt(string wish);
    }

    interface IMAsterObservable
    {
        void CallMinion(IMinionObserver minion);
        void KickMinion(IMinionObserver minion);
        void Command(string iWish);
    }

    class Master : IMAsterObservable
    {
        private List<IMinionObserver> _minions = new List<IMinionObserver>();

        public void CallMinion(IMinionObserver minion)
        {
            _minions.Add(minion);
        }

        public void Command(string iWish)
        {
            foreach (var minion in _minions)
            {
                minion.DoIt(iWish);
            }
        }

        public void KickMinion(IMinionObserver minion)
        {
            _minions.Remove(minion);
        }
    }

    class Minion : IMinionObserver
    {
        public void DoIt(string wish)
        {
            Console.WriteLine($"#{GetHashCode()} performs: {wish}");
        }
    }
}
