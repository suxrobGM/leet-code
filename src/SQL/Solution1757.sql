-- 1757. Recyclable and Low Fat Products - Easy
-- Link: https://leetcode.com/problems/recyclable-and-low-fat-products
-- Solution in PostgreSQL

SELECT product_id
FROM Products
WHERE low_fats = 'Y'
  AND recyclable = 'Y';
