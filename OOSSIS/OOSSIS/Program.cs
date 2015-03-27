using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Dts.Runtime;
using Microsoft.SqlServer.Dts.Tasks;
using System.Data;
using Microsoft.SqlServer.Dts.Tasks.FileSystemTask;
using Microsoft.SqlServer.Dts.Pipeline;
using Microsoft.SqlServer.Dts.Pipeline.Wrapper;
using Microsoft.SqlServer.Dts.Runtime.Wrapper;
using Microsoft.SqlServer.Dts.Tasks.ScriptTask;




namespace OOSSIS
{
    class Program
    {
        static void Main(string[] args)
        {

            Microsoft.SqlServer.Dts.Runtime.Application app = new Microsoft.SqlServer.Dts.Runtime.Application();

            SSISPackage package = new SSISPackage(@"C:\demo.dtsx");

            SSISConnections.FlatFile filey = new SSISConnections.FlatFile(package, @"C:\temp.csv");

            SSISConnections.FlatFileColumn col = new SSISConnections.FlatFileColumn(filey, 100, "PostCode");
            SSISConnections.FlatFileColumn col2 = new SSISConnections.FlatFileColumn(filey, 100, "Count");

            SSISTasks.File filetasky = new SSISTasks.File(package, "TestTask");
            SSISTasks.Pipeline pipetask = new SSISTasks.Pipeline(package, "TestTaskPipe");

            app.SaveToXml(package.get_location(), package.get_raw(), null);

        }


    }
}
