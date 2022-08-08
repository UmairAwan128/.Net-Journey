using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Demo
{
    //LINQ is a query Language using Which we can write query on wide variety of dataSources
    //(like arrays,Collecions,relationalDatabases, XML files e.t.c. )
    //so LINQ is divided into some categorizes these are
    //LINQ to Object    (using this we write queries on Arrays,collections e.t.c)
    //LINQ to Databases (using this we write queries on ADO.NET_DataTables, Relational_Database_tables) 
    //    has two parts  =>  LINQ to ADO.NET   => LINQ to SQL(ineracts with only SQL Server)   => LINQ to Entities(ineracts with all other DB Servers e.g Oracle)
    //LINQ to XML (using this we write queries on XML Files)

    //LINQ to SQL is used for working with relational database only SQL Server  
    //It is not only for quering(i.e accessing,selecting) the data but also we can perform insert,update,delete operation which
    //we call here as CRUD operations also we can call Stored Procedures..   CRUD(Create(Insert) Read(Select) Update Delete)

    //Q. why Microsoft Created LINQ to SQL as Microsoft already had ado.net using which it can interact with DB (SQL interacts with SQLServer using ADO.net) 
    //   so in ADO.net we interact with databases with the language SQL...
    //   so in ADO.net we use SQL to interact with SQL Server (SQL => SQL Server) 
    //   and in LINQ to SQL we use LINQ to interact with SQL Server so (LINQ =TO> SQL Server)
    //  So the ans of the Question is in ADO.net the syntax of SQLStatements are checked on runtime by databaseEngine not by the C# compiler 
    //  as we write these statements/queries in double quotes i.e String which can have any thing so on runtime these SQL Statments are carried 
    //  to databaseEngine by ADO.net and main drawback is thses queries will checked by databaseEngine on each run so extra task each time. 
    //  but in (LINQ to SQL) Compile time Syntax is checked in C# as LINQ Namspace is purely defined in C# i.e we have our own query engine 
    //  main benifit is its compiled like c# program so will be compiled only once will not compiled on each run..also here intellisense tells
    //  us the the name of table,its columns and their type so we don,t need to remember and less chance of error but in ADO.net as we write 
    //  SQL statements in double quote so no intellisense and we get any error when we run the program and Database engine tell us about error
    //  in query so putting extra load on SQLServer i.e also verification on server so Debugging is also not available here
    //  but in LINQ to SQL verification is on client system as intellisense and also Debugging is available..  
    //  in ADO.net we have code of combination of OOP and Relational_DB_query  (e.g  "Insert into Student Values(" +Value1+ "," +value2+ ")";  )               
    //  in LINQ to SQL we have pure (OOP)object oriented programming so no double quotes strings here 
    //  every table is Class, every column is an property , every record of table is an instance of class and stored procedures are going to be Methods..
    //  SO working with LINQ means pure OOP no relational Database and if we want to use it we have to first convert 
    //  all relational objects into Object oriented types this process is also known as ORM(Object Relational Mapping) 
    //  for this conversion we have a tool known as 'OR Designer' 
    class LINQ_To_SQL
    {
    }
}
