using System;

namespace DesignPatterns
{   
    //primary class for factory method
    public class FactoryObject
    {
        //public fields, set as part of method and return
        public int X;
        public int Y;
        public int Result;

        //factory method
        public FactoryObject Addition(int x, int y)
        {
            return new FactoryObject(x, y, x + y);
        }

        //factory method
        public FactoryObject Subtaction(int x, int y)
        {
            return new FactoryObject(x, y, x - y);
        }

        //factory method
        public FactoryObject Multiplication(int x, int y)
        {
            return new FactoryObject(x, y, x * y);
        }

        //factory method
        public FactoryObject Division(int x, int y)
        {
            return new FactoryObject(x, y, (y == 0) ? 0 : (x / y));
        }

        //constructor is private
        //object is returned via factory methods
        private FactoryObject(int x, int y, int result)
        {
            this.X = x;
            this.Y = y;
            this.Result = result;
        }
    }
}
