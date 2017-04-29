using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteBrowser
{
    class DataTypesEnum:List<String>
    {
        public DataTypesEnum()
        {
            this.Add("INTEGER");
            this.Add("BLOB");
            this.Add("TEXT");
            this.Add("REAL");
            this.Add("NUMERIC");
        }
    }
}
