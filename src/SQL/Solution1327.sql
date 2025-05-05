-- 1327. List the Products Ordered in a Period - Easy
-- Link: https://leetcode.com/problems/list-the-products-ordered-in-a-period
-- Solution in PostgreSQL

SELECT 
    p.product_name,
    SUM(o.unit) AS unit
FROM 
    Orders o
JOIN 
    Products p ON o.product_id = p.product_id
WHERE 
    o.order_date >= '2020-02-01' AND o.order_date < '2020-03-01'
GROUP BY 
    o.product_id, p.product_name
HAVING 
    SUM(o.unit) >= 100;
