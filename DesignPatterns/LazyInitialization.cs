using System;
using System.Collections.Generic;

namespace DesignPatterns
{
    public class LazyFactoryObject
    {
        //internal collection of items
        //IDictionaery makes sure they are unique
        private IDictionary<LazyObjectType, LazyObject> _LazyObjectList = 
            new Dictionary<LazyObjectType, LazyObject>();

        //enum for passing name of type required
        //avoids passing strings and is part of type ahead
        public enum LazyObjectType
        { 
            None,
            Small,
            Big,
            Bigger,
            Huge
        }

        //standard type of object that will be constructed
        public struct LazyObject
        {
            public LazyObjectType Name;
            public IList<int> Result;
        }

        /// <summary>
        /// Takes type and create 'expensive' list
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private IList<int> Result(LazyObjectType name)
        {
            IList<int> result = null;

            switch (name)
            { 
                case LazyObjectType.Small:
                    result = CreateSomeExpensiveList(1, 100);
                    break;
                case LazyObjectType.Big:
                    result = CreateSomeExpensiveList(1, 1000);
                    break;
                case LazyObjectType.Bigger:
                    result = CreateSomeExpensiveList(1, 10000);
                    break;
                case LazyObjectType.Huge:
                    result = CreateSomeExpensiveList(1, 100000);
                    break;
                case LazyObjectType.None:
                    result = null;
                    break;
                default:
                    result = null;
                    break;
            }

            return result;
        }

        //not an expensive item to create, but you get the point
        //delays creation fo some expensive object until needed
        private IList<int> CreateSomeExpensiveList(int start, int end)
        {
            IList<int> result = new List<int>();

            for (int counter = 0; counter < (end - start); counter++)
            {
                result.Add(start + counter);
            }

            return result;
        }

        public LazyFactoryObject()
        { 
            //empty constructor
        }

        public LazyObject GetLazyFactoryObject(LazyObjectType name)
        {
            //yes, i know it is illiterate and inaccurate
            LazyObject noGoodSomeBitch;

            //retrieves LazyObjectType from list via out, else creates one and adds it to list
            if (!_LazyObjectList.TryGetValue(name, out noGoodSomeBitch))
            {
                noGoodSomeBitch = new LazyObject();
                noGoodSomeBitch.Name = name;
                noGoodSomeBitch.Result = this.Result(name);

                _LazyObjectList.Add(name, noGoodSomeBitch);
            }

            return noGoodSomeBitch;
        }
    }
}
