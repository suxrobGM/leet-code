﻿-- 1068. Product Sales Analysis I - Easy
-- Link: https://leetcode.com/problems/product-sales-analysis-i
-- Solution in PostgreSQL

SELECT p.product_name, s.year, s.price
FROM Sales s
JOIN Product p
ON s.product_id = p.product_id;
