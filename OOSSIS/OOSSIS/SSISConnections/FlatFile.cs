using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Dts.Tasks.FileSystemTask;
using Microsoft.SqlServer.Dts.Pipeline;
using Microsoft.SqlServer.Dts.Pipeline.Wrapper;
using Microsoft.SqlServer.Dts.Runtime.Wrapper;
using Microsoft.SqlServer.Dts.Tasks.ScriptTask;
using Microsoft.SqlServer.Dts.Runtime;

namespace SSISConnections
{
    class FlatFile
    {

        private string location;
        private OOSSIS.SSISPackage package;
        private ConnectionManager manager;
        IDTSConnectionManagerFlatFile100 conn;

        public FlatFile(OOSSIS.SSISPackage pkg, string loc)
        {

            location = loc;
            package = pkg;

            manager = package.add_connection("FlatFile");

            manager.ConnectionString = location;

            conn = manager.InnerObject as IDTSConnectionManagerFlatFile100;

            configure();

        }

        public IDTSConnectionManagerFlatFileColumn100 add_column()
        {

            IDTSConnectionManagerFlatFileColumn100 flatFileColumn = conn.Columns.Add() as IDTSConnectionManagerFlatFileColumn100;

            return flatFileColumn;

        }

        public OOSSIS.SSISPackage get_package()
        {

            return package;

        }

        private void configure()
        {

            conn.RowDelimiter = "\r";
            conn.Format = "Delimited";
            conn.ColumnNamesInFirstDataRow = true;



        }

        public ConnectionManager get_raw()
        {

            return manager;

        }


    }
}
