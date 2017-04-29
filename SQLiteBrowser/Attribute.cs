using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Markup;

namespace SQLiteBrowser
{
    class Attribute
    {
        public string       attributeName           { get; set; }
        public string       typeOfAttribute         { get; set; }
        public bool         isNullAttribute         { get; set; }
        public bool         autoIncrementProperty   { get; set; }
        public bool         uniqeProperty           { get; set; }

    }

}
