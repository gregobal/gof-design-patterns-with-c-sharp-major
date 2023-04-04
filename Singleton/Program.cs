using SingletonNS;

var instance1 = Singleton.Instance();
var instance2 = Singleton.Instance();

Console.WriteLine(instance1 == instance2);
Console.WriteLine(instance1.Equals(instance2));

namespace SingletonNS
{
    public class LazyThreadSafeSingleton
    {
        private LazyThreadSafeSingleton()
        {
        }

        public static LazyThreadSafeSingleton Instance() => Holder.instance;

        private static class Holder
        {
            static Holder()
            {
            }

            internal static readonly LazyThreadSafeSingleton instance = new LazyThreadSafeSingleton();
        }
    }
    
    public class Singleton
    {
        private static Singleton? _instance;

        private Singleton()
        {
        }

        public static Singleton Instance()
        {
            return _instance ??= new Singleton();
        }
    }
}
