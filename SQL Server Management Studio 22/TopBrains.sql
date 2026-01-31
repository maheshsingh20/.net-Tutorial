use LPU_Db;
--question 1

-- created sales raw table

CREATE TABLE Sales_Raw
(
    OrderID INT,
    OrderDate VARCHAR(20),
    CustomerName VARCHAR(100),
    CustomerPhone VARCHAR(20),
    CustomerCity VARCHAR(50),
    ProductNames VARCHAR(200),
    Quantities VARCHAR(100),
    UnitPrices VARCHAR(100),
    SalesPerson VARCHAR(100)
);

--inserting values in raw table

INSERT INTO Sales_Raw VALUES
(101, '2024-01-05', 'Ravi Kumar', '9876543210', 'Chennai',
 'Laptop,Mouse', '1,2', '55000,500', 'Anitha'),

(102, '2024-01-06', 'Priya Sharma', '9123456789', 'Bangalore',
 'Keyboard,Mouse', '1,1', '1500,500', 'Anitha'),

(103, '2024-01-10', 'Ravi Kumar', '9876543210', 'Chennai',
 'Laptop', '1', '54000', 'Suresh'),

(104, '2024-02-01', 'John Peter', '9988776655', 'Hyderabad',
 'Monitor,Mouse', '1,1', '12000,500', 'Anitha'),

(105, '2024-02-10', 'Priya Sharma', '9123456789', 'Bangalore',
 'Laptop,Keyboard', '1,1', '56000,1500', 'Suresh');

select * from Sales_Raw

-- customer table

CREATE TABLE Customers
(
    CustomerID INT IDENTITY PRIMARY KEY,
    CustomerName VARCHAR(100),
    CustomerPhone VARCHAR(20),
    CustomerCity VARCHAR(50)
);


--salesperon table
CREATE TABLE SalesPersons
(
    SalesPersonID INT IDENTITY PRIMARY KEY,
    SalesPersonName VARCHAR(100)
);


--product table 
CREATE TABLE Products
(
    ProductID INT IDENTITY PRIMARY KEY,
    ProductName VARCHAR(100),
    UnitPrice DECIMAL(10,2)
);


--orders table

CREATE TABLE Orders
(
    OrderID INT PRIMARY KEY,
    OrderDate DATE,
    CustomerID INT,
    SalesPersonID INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (SalesPersonID) REFERENCES SalesPersons(SalesPersonID)
);


CREATE TABLE OrderDetails
(
    OrderDetailID INT IDENTITY PRIMARY KEY,
    OrderID INT,
    ProductID INT,
    Quantity INT,
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

select * from OrderDetails


--question 2

WITH OrderTotals AS
(
    SELECT 
        OrderID,
        SUM(CAST(q.value AS INT) * CAST(p.value AS INT)) AS TotalSales
    FROM Sales_Raw
    CROSS APPLY STRING_SPLIT(Quantities, ',') q
    CROSS APPLY STRING_SPLIT(UnitPrices, ',') p
    GROUP BY OrderID
),
RankedOrders AS
(
    SELECT *,
           DENSE_RANK() OVER (ORDER BY TotalSales DESC) AS rnk
    FROM OrderTotals
)
SELECT TotalSales
FROM RankedOrders
WHERE rnk = 3;




--Question 3

SELECT 
    SalesPerson,
    SUM(CAST(q.value AS INT) * CAST(p.value AS INT)) AS TotalSales
FROM Sales_Raw
CROSS APPLY STRING_SPLIT(Quantities, ',') q
CROSS APPLY STRING_SPLIT(UnitPrices, ',') p
GROUP BY SalesPerson
HAVING SUM(CAST(q.value AS INT) * CAST(p.value AS INT)) > 60000;



--question 4

SELECT 
    CustomerName,
    SUM(CAST(q.value AS INT) * CAST(p.value AS INT)) AS TotalSpent
FROM Sales_Raw
CROSS APPLY STRING_SPLIT(Quantities, ',') q
CROSS APPLY STRING_SPLIT(UnitPrices, ',') p
GROUP BY CustomerName
HAVING SUM(CAST(q.value AS INT) * CAST(p.value AS INT)) >
(
    SELECT AVG(CustomerTotal)
    FROM
    (
        SELECT 
            CustomerName,
            SUM(CAST(q.value AS INT) * CAST(p.value AS INT)) AS CustomerTotal
        FROM Sales_Raw
        CROSS APPLY STRING_SPLIT(Quantities, ',') q
        CROSS APPLY STRING_SPLIT(UnitPrices, ',') p
        GROUP BY CustomerName
    ) A
);


--question 5


SELECT 
    UPPER(CustomerName) AS CustomerName,
    MONTH(CAST(OrderDate AS DATE)) AS OrderMonth,
    OrderDate
FROM Sales_Raw
WHERE YEAR(CAST(OrderDate AS DATE)) = 2026
  AND MONTH(CAST(OrderDate AS DATE)) = 1;
