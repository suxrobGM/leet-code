-- 607. Sales Person - Easy
-- Link: https://leetcode.com/problems/sales-person
-- Solution in PostgreSQL

SELECT name
FROM SalesPerson
WHERE sales_id NOT IN (
    SELECT o.sales_id
    FROM Orders o
    JOIN Company c ON o.com_id = c.com_id
    WHERE c.name = 'RED'
);

