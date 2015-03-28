# OOSsis

##Overview

The purpose of this library is to wrap the SSIS API into a more easily used form.  It has grown out of a number of conversations 
about the issues that the main API can cause.  The two main insights it seeks to deliver are that APIs should make it as easy to
use OO principles as possible and that it is better to narrow the scope of an API to the most important functions and avoid a scatter gun approach.

In general, the SSIS API offers much too wide a functionality and relies on objects that do not
naturally map to the objects used in the SSIS interface.  OOSsis aims to resolve this by only supporting a small subset of core
functionality using a much more coherent set of objects.

Of course, occasion will often demand more detailed control.  To provide this, all of the objects expose their raw SSIS API 
counterparts.

##Who can benefit?

The biggest gainer from OOSsis would be someone who deploys a large number of slightly different SSIS packages to a range of
environments.  The simple, clean OO design makes building and maintaining these packages very easy.  

The less these packages do, the better.  Ideally, the packages would just do the heavy lifting of moving data from place to 
place.  This is where I see SSIS as being strongest, and OOSsis is designed for this.

If you wish to use a lot of features not directly supported by OOSsis, then the simplicity gain for those parts of the API which 
are supported will likely be outweighed by the complication of operating at two layers of abstraction

##How to use

The central object of OOSsis is the SSISPackage, and everything else is assigned to it, either directly or indirectly

```c#
 SSISPackage package = new SSISPackage(@"C:\demo.dtsx");
```

Other objects (connections, tasks etc) can be assigned by creating other objects and passing the SSISPackage instance in 
the constructor.  This indirect pattern will be used a lot in OOSsis because it helps keep the control in the smaller objects
and limit the package object

Add a connection

```c#
SSISConnections.FlatFile filey = new SSISConnections.FlatFile(package, @"C:\temp.csv");
```

Using a similar pattern to the above, you can add columns to the connection by creating a new column object and passing the 
flat file object to the constructor

```c#
SSISConnections.FlatFileColumn col2 = new SSISConnections.FlatFileColumn(filey, 100, "Count");
```

Tasks can be created in a very similar way
```c#
SSISTasks.Pipeline pipetask = new SSISTasks.Pipeline(package, "TestTaskPipe");
```

##Next steps

My main focus is now building out the domain of API functions covered so that whole applications can be deployed from OOSsis.
The immediate next step is precedence constraints and then the innards of the pipeline task


