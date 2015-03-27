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

namespace OOSSIS
{
    class SSISPackage
    {

        string location;
        Microsoft.SqlServer.Dts.Runtime.Package package;

        public SSISPackage(string loc)
        {

            location = loc;

            package = new Microsoft.SqlServer.Dts.Runtime.Package();

        }

        public ConnectionManager add_connection(string conType)
        {

            return package.Connections.Add(conType);

        }

        public Microsoft.SqlServer.Dts.Runtime.Package get_raw()
        {

            return package;

        }

        public string get_location()
        {

            return location;

        }

        public Executable add_task(string taskType)
        {

            Executable exec = package.Executables.Add(taskType);

            return exec;
        }

    }
}
