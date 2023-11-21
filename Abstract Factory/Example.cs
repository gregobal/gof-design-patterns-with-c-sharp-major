
namespace Abstract_Factory
{
    static class Example
    {
        public static void Run()
        {
            Hero paladin = new Hero(new PaladinFactory());
            paladin.Cast();
            paladin.Hit();

            Hero elf = new Hero(new ElfFactory());
            elf.Hit();
        }
    }

    abstract class Weapon
    {
        public abstract void Hit();
    }

    abstract class Magic
    {
        public abstract void Cast();
    }

    class Bow : Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Bow shot");
        }
    }

    class Sword : Weapon
    {
        public override void Hit() {
            Console.WriteLine("Sword slash");
        }
    }

    class Fireball : Magic
    {
        public override void Cast()
        {
            Console.WriteLine("Fireball throw");
        }
    }

    abstract class HeroFactory
    {
        public abstract Weapon CreateWeapon();

        public abstract Magic CreateMagic();
    }

    class PaladinFactory : HeroFactory
    {
        public override Magic CreateMagic()
        {
           return new Fireball();
        }

        public override Weapon CreateWeapon()
        {
            return new Sword();
        }
    }

    class ElfFactory : HeroFactory
    {
        public override Magic CreateMagic()
        {
            return new Fireball();
        }

        public override Weapon CreateWeapon()
        {
            return new Bow();
        }
    }

    class Hero
    {
        private Magic _magic;
        private Weapon _weapon;

        public Hero(HeroFactory factory)
        {
            _magic = factory.CreateMagic();
            _weapon = factory.CreateWeapon();
        }

        public void Cast()
        {
            _magic.Cast();
        }

        public void Hit()
        {
            _weapon.Hit();
        }
    }
}
