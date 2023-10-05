using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThuySan.models
{
    abstract class Model
    {
        protected bool isNew;
        protected abstract void Update();
        protected abstract void Insert();
        protected abstract void Save();
        protected abstract void Delete();
    }
}
