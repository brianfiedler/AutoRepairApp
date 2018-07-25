RESTORE FILELISTONLY
FROM DISK = 'C:\Development\Git\WebApplication1\App_Data\AdventureWorks2017.bak'
GO

RESTORE DATABASE AdventureWorks2017
FROM DISK = 'C:\Development\Git\WebApplication1\App_Data\AdventureWorks2017.bak'
WITH MOVE 'AdventureWorks2017' TO 'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQL2017RTM\MSSQL\DATA\AdventureWorks2017.mdf',
MOVE 'AdventureWorks2017_log' TO 'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQL2017RTM\MSSQL\DATA\AdventureWorks2017_log.ldf'

