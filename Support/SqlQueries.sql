--===================================================
--query a database 
--===================================================
--select everything from the table
select * from automobiles

--select certain rows 
select * from Automobiles where model = 'optima'

--select certain columns 
select model from Automobiles 

--combine the two
select model from Automobiles  where Make = 'Kia'



--===================================================
--you can use functions too
--===================================================
--get a count of records in the table
select count(*) NumberOfAutomobiles from Automobiles 

--count of unique models
select count(distinct model) NumberOfDistinctModels from Automobiles 

--find all automobiles where we have more than one of the same Make, Model, Year, and Color
select Make, Model, Year, Color,  count(*) from Automobiles group by Make, Model, Year, Color having count(*) > 0

--and of course you can combine that with the were clause
select count(*) as NumberOfKias from Automobiles   where Make = 'Kia'



--===================================================
--sql isn't just for reading from a table
--===================================================
--update a proprty on a table based on known Id
update Automobiles set Weight = 500 where Id = 1

--insert
insert into Automobiles(NumberOfAxels, Weight, Make, Model, NumberOfPassengers, Year, RideHigh, Color) values
(2,300,'Ford','Mustang',2,1969,31,'Red')

--delete record
delete from Automobiles where Id = 0

