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

namespace SSISTasks
{
    class File
    {

        string name;
        string taskType;
        Microsoft.SqlServer.Dts.Runtime.TaskHost task;
        OOSSIS.SSISPackage package;
        Executable exec;


        public File(OOSSIS.SSISPackage pkg, string name)
        {

            package = pkg;

            taskType = "STOCK:FileSystemTask";

            exec = package.add_task(taskType);

            task = exec as Microsoft.SqlServer.Dts.Runtime.TaskHost;

            task.Name = name;

        }

    }
}
