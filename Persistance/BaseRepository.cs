
using System.Data;

namespace Persistance
{
    public abstract class BaseRepository
    {
        private readonly IDbConnection _dbConnection;
        protected IDbConnection Connection
        {
            get { return _dbConnection; }
        }

        protected BaseRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void EnsureDbConnectionIsOpen()
        {
            if (Connection.State != ConnectionState.Open)
            {
                Connection.Open();
            }

        }
    }
}
