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
    class FlatFileColumn
    {

        SSISConnections.FlatFile file;
        IDTSConnectionManagerFlatFileColumn100 column;
        string name;

        public FlatFileColumn(SSISConnections.FlatFile fl, int width, string nm)
        {

            file = fl;
            name = nm;

            column = file.add_column();
            configure();


        }

        private void configure()
        {

            column.DataType = DataType.DT_WSTR;
            column.ColumnType = "Delimited";
            column.ColumnWidth = 0;
            column.MaximumWidth = 255;
            column.TextQualified = false;
            column.ColumnDelimiter = ",";
            var columnName = column as IDTSName100;
            columnName.Name = name;

        }

        public IDTSConnectionManagerFlatFileColumn100 get_raw()
        {

            return column;

        }
    }
}
