using System;

namespace DesignPatterns
{
    //the type of object to be built by the specific builders
    public class BuilderObject
    {
        public string Property1 = string.Empty;
        public string Property2 = string.Empty;
        public string Property3 = string.Empty;
    }

    abstract class Builder
    {
        //protected object to be built
        protected BuilderObject _Object;

        //method to return object
        public BuilderObject GetBuilder()
        {
            return _Object;
        }

        //method to create object
        public void BuildObject()
        {
            _Object = new BuilderObject();
        }


        //public abstract method(s) for building object
        //derived classes will implement
        public abstract void BuildMethod1();
        public abstract void BuildMethod2();
        public abstract void BuildMethod3();
    }

    //class 1 of n that inherits Builder class
    //and overrides each abstract method for building
    class Builder1 : Builder
    {
        public override void BuildMethod1()
        {
            //
        }
        
        public override void BuildMethod2()
        {
            //
        }

        public override void BuildMethod3()
        {
            //
        }
    }

    //class 2 of n that inherits Builder class
    //and overrides each abstract method for building
    class Builder2 : Builder
    {
        public override void BuildMethod1()
        {
            //
        }

        public override void BuildMethod2()
        {
            //
        }

        public override void BuildMethod3()
        {
            //
        }
    }

    //director class that accepts builder type (from inherited builder base type)
    class Director
    {
        private Builder _Builder;

        public Director(Builder builder)
        {
            _Builder = builder;
        }

        public Builder CreateBuilderObject()
        {
            _Builder.BuildMethod1();
            _Builder.BuildMethod2();
            _Builder.BuildMethod3();

            return _Builder;
        }
    }

    class Start
    {
        public Start()
        {
            Builder builderExample = new Builder1();
            builderExample.BuildObject();
            BuilderObject newBuilder1Object = builderExample.GetBuilder();
        }
    }
}
