using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vilicus.Dal
{
    public static class DalHelper
    {
        public static void InitializeDatabaseContext()
        {
            Database.SetInitializer(new ContextInitializer());
        }
    }
}
