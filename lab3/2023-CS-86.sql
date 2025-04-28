--Average
select AVG(Salary) as avg from [DB Lab 1] ;
--Minimum
select min(Salary) as min from [DB Lab 1];
--Sum
select sum(Salary) as sum from [DB Lab 1];
--cOUNT
select count (Salary) as count from [DB Lab 1];
 --Standard deviation
 select STDEV (Salary) as STDEV from [DB Lab 1];
 --VAR
 select var (Salary) as var from [DB Lab 1];
 --max
 select max (Salary) as max from [DB Lab 1];
 --varp
 select varp (Salary) as varp from [DB Lab 1];
 select ID ,Avg(Salary) as salary from Name group by ID;

 select unitsInStock from dbo.products as U_stock;
 
 select categoryName as C_Name from dbo.categories;
 
 select supplierID, count(*) as new from products 
 group by supplierID
 having count(*) >0

 select Year (birthDate) as year from dbo.Employees;
 select month(birthDate) from dbo.Employees;
 select day(birthDate) from dbo.Employees;

 select year(HireRate) .year(BirthDate) as age_on_hire from dbo.Employees;
