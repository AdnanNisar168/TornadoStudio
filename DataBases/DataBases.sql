Select file_id, name, physical_name 
	from master.sys.database_files
/*
1	master	C:\Users\Adnan Nisar\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\tornadoStudio\master.mdf
2	mastlog	C:\Users\Adnan Nisar\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\tornadoStudio\mastlog.ldf
*/


Select name, physical_name 'CurrentLocation' , state_desc 
	from sys.master_files
		where database_id = DB_ID('master')


/*
location of master databases
master	C:\Users\Adnan Nisar\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\tornadoStudio\master.mdf	ONLINE
mastlog	C:\Users\Adnan Nisar\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\tornadoStudio\mastlog.ldf	ONLINE
*/


/*
USE master;  
GO  
ALTER DATABASE tempdb   
MODIFY FILE (NAME = tempdev, FILENAME = 'E:\TornadoStudio\tsDB\DataBases\tempdb.mdf');  
GO  
ALTER DATABASE tempdb   
MODIFY FILE (NAME = templog, FILENAME = 'E:\TornadoStudio\tsDB\DataBases\templog.ldf');  
GO
*/

SELECT name, physical_name AS CurrentLocation, state_desc  
FROM sys.master_files  
WHERE database_id = DB_ID(N'tempdb');