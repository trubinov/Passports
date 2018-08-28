using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Passports
{
    public class DatabaseContext : IDatabaseContext
    {
        public string ConnectionString { get; }

        public DatabaseContext(string connStr)
        {
            ConnectionString = connStr;
        }
    }
}
