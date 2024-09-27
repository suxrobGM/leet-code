-- 586. Customer Placing the Largest Number of Orders - Easy
-- Link: https://leetcode.com/problems/customer-placing-the-largest-number-of-orders
-- Solution in PostgreSQL

SELECT customer_number
FROM Orders
GROUP BY customer_number
ORDER BY COUNT(order_number) DESC
LIMIT 1;
