
namespace DesignPatterns
{

    //double-checked locking singleton
    //required for threaded environments
    public class DoubleCheckingSingleton
    {
        private static volatile DoubleCheckingSingleton _instance = null;
        private static object _syncRoot = new object();
    
        //Private constructor prevents instantiation from other classes
        private DoubleCheckingSingleton()
        {
            //class contruction
        }
        
        public static DoubleCheckingSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                        {
                            _instance = new DoubleCheckingSingleton();
                        }
                    }
                }
                return _instance;
            }   
        }
    }

    //lazy initialization of singleton
    public class LazySingleton 
    {
        private LazySingleton _instance = null;
    
        // Private constructor prevents instantiation from other classes
        private LazySingleton() 
        {
            //class contruction
        }
 

        public LazySingleton getInstance() 
        {
            if (_instance == null)
            {
                _instance = new LazySingleton();
            }
            else
            {
                return _instance;
            }
            return _instance;
        }
    }


    //eager initialization of singleton
    public class EagerSingleton
    {
        private static EagerSingleton _Instance = new EagerSingleton();

        // Private constructor prevents instantiation from other classes
        private EagerSingleton()
        {
            //class contruction
        }

        public EagerSingleton getInstance()
        {
            return _Instance;
        }
    }
}
