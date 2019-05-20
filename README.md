# Idoit.API.Client

Make your i-doit Api Calls in Visual studio C#


[![NuGet package](https://img.shields.io/nuget/v/Anemonis.JsonRpc.ServiceClient.svg?style=flat-square)](https://www.nuget.org/packages/Anemonis.JsonRpc.ServiceClient)

## Project Details
- The Idoit.API.Client supports working with request and response HTTP headers.
- The Idoit.API.Client supports operation cancellation via cancellation token.
- The Idoit.API.Client can `Create`, Update, Read, Delete and Quickpurge Category.
- The Idoit.API.Client can Create, Update, Read, Delete and Quickpurge Dialog.
- The Idoit.API.Client can Create, Update, Read, Delete, Archiving and Purge Object.
- The Idoit.API.Client can Read ObjectTypes.
- The Idoit.API.Client can Read Objects.
## Install and update

Installing Idoit.API.Client by Using the Package Manager Console
PM> install Idoit.API.Client.1.0.0.nupkg. 




## Code Examples for Object

Headers
```cs
using Idoit.API.Client;
using Idoit.API.Client.CMDB.Object.Response;
using Obj = Idoit.API.Client.CMDB.Object.Object;
using Idoit.API.Client.CMDB.Object;
using ObjectType = Idoit.API.Client.Contants.ObjectTypes;
using CmdbStatus = Idoit.API.Client.Contants.CmdbStatus;
```

Create
```cs

	int i;
        Client myClient = new Client(URL, APIKEY, LANGUAGE);
        myClient.Username = "admin";
        myClient.Password = "admin";
        Obj request = new Obj(myClient);

        request.type = ObjectType.Printer;
        request.title = "My Printer";
        request.cmdbStatus = CmdbStatus.defect;

        i = request.Create();
        Console.WriteLine("ObjectId is "+i); 
	Console.WriteLine("title"+request.title);
        Console.WriteLine("type"+request.type);
        Console.WriteLine("cmdbStatus"+request.cmdbStatus);
        
```

Delete
```cs
	    int i;
            Client myClient = new Client(URL, APIKEY, LANGUAGE);
            myClient.Username = "admin";
            myClient.Password = "admin";
            Obj request = new Obj(myClient);

            request.type = ObjectType.Client;
            request.title = " My Client";
            request.cmdbStatus = CmdbStatus.inOperation;
            i = request.Create();
            request.Delete(i);

        
```

Archive
```cs
	   
            int i;
            Client myClient = new Client(URL, APIKEY, LANGUAGE);
            myClient.Username = "admin";
            myClient.Password = "admin";
            Obj request = new Obj(myClient);

            request.type = ObjectType.Router;
            request.title = "My Router";
            request.cmdbStatus = CmdbStatus.planned;
            i = request.Create();

            request.Archive(i);
        
```
Purge 
```cs
	   
             int i;
            Client myClient = new Client(URL, APIKEY, LANGUAGE);
            myClient.Username = "admin";
            myClient.Password = "admin";
            Obj request = new Obj(myClient);

            request.type = ObjectType.Rack;
            request.title = " Rack 1";
            request.cmdbStatus = CmdbStatus.sorted;
            i = request.Create();

            request.Purge(i);        
```

Update
```cs
	   
            int i;
            Client myClient = new Client(URL, APIKEY, LANGUAGE);
            myClient.Username = "admin";
            myClient.Password = "admin";
            Obj request = new Obj(myClient);

            request.type = ObjectType.Rack;
            request.title = " Rack 1";
            request.cmdbStatus = CmdbStatus.sorted;
            i = request.Create();

            request.Purge(i);        
```

Read
```cs
	   
            int i;
            Result list = new Result();
            Client myClient = new Client(URL, APIKEY, LANGUAGE);
            myClient.Username = "admin";
            myClient.Password = "admin";
            Obj request = new Obj(myClient);
            
            request.type = ObjectType.SystemService;
            request.title = " SystemService 3";
            request.cmdbStatus = CmdbStatus.inOperation;
            i = request.Create();
            
            list = request.Read(i);

           Console.WriteLine("ObjectId is "+request.); 
	   Console.WriteLine("title"+request.title);
           Console.WriteLine("type"+request.type);
           Console.WriteLine("cmdbStatus"+request.cmdbStatus); 

            request.Purge(i);     
```













