-- 1164. Product Price at a Given Date - Medium
-- Link: https://leetcode.com/problems/product-price-at-a-given-date
-- Solution in PostgreSQL

SELECT product_id,
       COALESCE((
           SELECT new_price
           FROM Products p2
           WHERE p1.product_id = p2.product_id
             AND p2.change_date <= '2019-08-16'
           ORDER BY p2.change_date DESC
           LIMIT 1
       ), 10) AS price
FROM (
    SELECT DISTINCT product_id
    FROM Products
) p1;
