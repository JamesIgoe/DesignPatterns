namespace DesignPatterns
{
    public enum Location
    {
        Kitchen,
        Bedroom,
        LivingRoom
    }

    public enum Amusements
    {
        String,
        Mouse,
        Food,
        Sleep
    }
    
    public abstract class Feline
    {
        public abstract Feline HereKittyKitty();
    }

    public class Cat : Feline
    {
        private Location _Location;
        private Feline _Cat = null;
        private Amusements _Amusement;
        public Cat(Location location)
        {
            _Location = location;
        }

        public override Feline HereKittyKitty()
        {
            switch (_Location)
            { 
                case Location.Bedroom:
                    _Amusement = Amusements.Sleep;
                    break;
                case Location.Kitchen:
                    _Amusement = Amusements.Food;
                    break;
                case Location.LivingRoom:
                    _Amusement = Amusements.String;
                    break;
                default:
                    _Amusement = Amusements.Mouse;
                    break;
            }

            _Cat = new Cat(_Amusement);

            return _Cat;
        }

        private Cat(Amusements fun)
        { 
        
        }
    }
}
