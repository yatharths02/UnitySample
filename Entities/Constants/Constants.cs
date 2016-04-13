using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Constants
{
    public enum DBAccessVar
    {
        ExecuteNonQuery = 1,
        ExecuteScalar = 2,
        ReturnDataSet = 3
    };
}
