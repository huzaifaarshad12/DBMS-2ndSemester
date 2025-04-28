-- Select Table
select * from StudentTbl

--Select first Name
select FirstName from StudentTbl

--Select from table gpa less than equal to 3.5
select * from StudentTbl where GPA >=3.5

--select from table where gpa less than 3.5
select * from dbo.StudentTbl where GPA < 3.5

--Select GPA from table
select  GPA from dbo.StudentTbl

--Concatenation first and last name 
SELECT  CONCAT (FirstName,' ' ,LastName)  Shera from dbo.StudentTbl 

--Select from table
select * from StudentTbl Where FirstName = 'Huzaifa' And GPA < 3.5

--select from table
select * from StudentTbl where GPA =  3.4*null 