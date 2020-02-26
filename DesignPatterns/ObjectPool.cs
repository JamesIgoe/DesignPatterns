using System.Collections.Generic;
using System.Data;

namespace DesignPatterns
{
    public class ObjectPool
    {
        readonly IList<ThreadedSql> _threadedSqlCollection;

        readonly string _connection;
        readonly string _userID;
        readonly string  _password;
        readonly int  _startingCount;

        public ObjectPool(string connection, string userID, string password, int startingCount)
        {
            _connection = connection;
            _userID = userID;
            _password = password;
            _startingCount = startingCount;

            //object pool creates empty array of threadeSql
            _threadedSqlCollection = ConstructPool();

            //for each new item
            // create a new connection
            // add item to pool
        }

        private IList<ThreadedSql> ConstructPool()
        {
            IList<ThreadedSql> objectPool = new List<ThreadedSql>();

            for (int counter = 0; counter <_startingCount; counter++)
            {
                //construct default parameters
                ThreadedSql.ThreadedSqlParameters param = GetNullParamaters();

                //create default client
                ThreadedSql client = new ThreadedSql(param);

                //connect client to Db
                
                objectPool.Add(client);
            }

            return objectPool;
        }

        private ThreadedSql.ThreadedSqlParameters GetNullParamaters()
        {
            ThreadedSql.ThreadedSqlParameters param = new ThreadedSql.ThreadedSqlParameters();
            param.CommandTimeout = 0;
            param.Identifier = "";
            param.Sql = "";
            param.Result = null;

            return param;
        }
        
        private ThreadedSql GetClient()
        {
            ThreadedSql existingClient = null;

            //return available client
            foreach (ThreadedSql client in _threadedSqlCollection)
            {
                if (!client.IsActive)
                {
                    existingClient = client;
                    existingClient.Clear();
                }
            }

            return existingClient;
        }

        /// <summary>
        /// Not currently implemnented
        /// </summary>
        public void AddRequest()
        {
            // Not currently implemnented
        }
    }

    public class ThreadedSql
    {
        public struct ThreadedSqlParameters
        {
            public int CommandTimeout { get; set; }
            public string Sql { get; set; }
            public string Identifier { get; set; }
            public DataTable Result { get; set; }
        }

        private ThreadedSqlParameters _parameters;
        
        public bool IsActive { get; set; }

        public ThreadedSql(ThreadedSqlParameters parameters)
        {
            _parameters = parameters;
        }

        public void Clear()
        {
            _parameters.CommandTimeout = 0;
            _parameters.Identifier = "";
            _parameters.Sql = "";
            _parameters.Result = null;
        }

        public DataTable Execute(string Sql, int commandTimeout, string identifier)
        {
            DataTable dt = null;
            return dt;
        }
    }
}
