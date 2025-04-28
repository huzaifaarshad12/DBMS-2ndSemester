--Perform self-cross join and see if there is any difference between cross join and self-cross join
-- Cross Join
SELECT * FROM Customers CROSS JOIN Customers AS C2;

-- Self-Cross Join
SELECT *FROM Customers AS C1 JOIN Customers AS C2 ON C1.CustomerID <> C2.CustomerID;

--Return customers and their orders, including customers who placed no orders (CustomerID, OrderID, OrderDate)

SELECT C.CustomerID, O.OrderID, O.OrderDate FROM Customers C LEFT JOIN Orders O ON C.CustomerID = O.CustomerID;

--Report only those customer IDs who never placed any order. (CustomerID, OrderID, OrderDate)

SELECT C.CustomerID, O.OrderID, O.OrderDate FROM Customers C LEFT JOIN Orders O ON C.CustomerID = O.CustomerID WHERE O.OrderID IS NULL;

--Report those customers who placed orders on July, 1997. (CustomerID, OrderID, OrderDate)

SELECT C.CustomerID, O.OrderID, O.OrderDate FROM Customers C JOIN Orders O ON C.CustomerID = O.CustomerID WHERE YEAR(O.OrderDate) = 1997 AND MONTH(O.OrderDate) = 7;

--Report the total orders of each customer. (customerID, totalorders)

SELECT C.CustomerID, COUNT(O.OrderID) AS totalorders FROM Customers C LEFT JOIN Orders O ON C.CustomerID = O.CustomerID GROUP BY C.CustomerID;

--Write a query to generate five copies of each employee. (EmployeeID, FirstName, LastName)

SELECT TOP 5 E.EmployeeID, E.FirstName, E.LastName FROM Employees E CROSS JOIN (VALUES(1),(2),(3),(4),(5)) AS Numbers(N);

--Write a query that returns a row for each employee and day in the range 04-07-1996 through 04-08 1997. (EmployeeID, Date)

WITH DateRange AS (
    SELECT CAST('1996-07-04' AS DATE) AS StartDate, CAST('1997-08-04' AS DATE) AS EndDate
)
SELECT E.EmployeeID, DATEADD(DAY, DATEDIFF(DAY, 0, StartDate) + N.Number, 0) AS Date FROM Employees E CROSS JOIN DateRange 
JOIN master..spt_values N ON N.Number BETWEEN 0 AND DATEDIFF(DAY, StartDate, EndDate);

--Return US customers, and for each customer return the total number of orders and total quantities. (CustomerID, Totalorders, totalquantity)

SELECT C.CustomerID, COUNT(O.OrderID) AS TotalOrders, SUM(OD.Quantity) AS TotalQuantity
FROM Customers C
JOIN Orders O ON C.CustomerID = O.CustomerID
JOIN [Order Details] OD ON O.OrderID = OD.OrderID
WHERE C.Country = 'USA'
GROUP BY C.CustomerID;

--Write a query that returns all customers in the output, but matches them with their respective orders only if they were placed on July 04, 1997. (CustomerID, CompanyName, OrderID, Orderdate)

SELECT C.CustomerID, C.CompanyName, O.OrderID, O.OrderDate
FROM Customers C
LEFT JOIN Orders O ON C.CustomerID = O.CustomerID
WHERE O.OrderDate = '1997-07-04';

--Are there any employees who are older than their managers? List that names of those employees and their ages. (EmployeeName, Age, Manager Age):

SELECT E.FirstName + ' ' + E.LastName AS EmployeeName, DATEDIFF(YEAR, E.BirthDate, GETDATE()) AS Age, 
DATEDIFF(YEAR, M.BirthDate, GETDATE()) AS ManagerAge
FROM Employees E
JOIN Employees M ON E.ReportsTo = M.EmployeeID
WHERE DATEDIFF(YEAR, E.BirthDate, GETDATE()) > DATEDIFF(YEAR, M.BirthDate, GETDATE());

--List the names of products which were ordered on 8th August 1997. (ProductName, OrderDate)

SELECT P.ProductName, O.OrderDate
FROM Products P
JOIN [Order Details] OD ON P.ProductID = OD.ProductID
JOIN Orders O ON OD.OrderID = O.OrderID
WHERE O.OrderDate = '1997-08-08';

--List the addresses, cities, countries of all orders which were serviced by Anne and were shipped late. (Address, City, Country)

SELECT ShipAddress AS Address, ShipCity AS City, ShipCountry AS Country
FROM Orders
WHERE EmployeeID IN (SELECT EmployeeID FROM Employees WHERE FirstName = 'Anne')
AND ShippedDate > RequiredDate;

--List all countries to which beverages have been shipped. (Country)

SELECT DISTINCT ShipCountry AS Country
FROM Orders
WHERE OrderID IN (SELECT OrderID FROM [Order Details] WHERE ProductID IN (SELECT ProductID FROM Products 
WHERE CategoryID IN (SELECT CategoryID FROM Categories WHERE CategoryName = 'Beverages')));

