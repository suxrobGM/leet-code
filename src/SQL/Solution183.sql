-- 183. Customers Who Never Order - Easy
-- Link: https://leetcode.com/problems/customers-who-never-order
-- Solution in MySQL
SELECT Name AS Customers
FROM Customers
WHERE Id NOT IN (
    SELECT CustomerId
    FROM Orders
);
