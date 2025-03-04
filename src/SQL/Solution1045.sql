-- 1045. Customers Who Bought All Products - Medium
-- Link: https://leetcode.com/problems/customers-who-bought-all-products
-- Solution in PostgreSQL

SELECT customer_id
FROM Customer
GROUP BY customer_id
HAVING COUNT(DISTINCT product_key) = (SELECT COUNT(DISTINCT product_key) FROM Product);

