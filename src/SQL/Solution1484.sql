-- 1484. Group Sold Products By The Date - Easy
-- Link: https://leetcode.com/problems/group-sold-products-by-the-date
-- Solution in PostgreSQL

SELECT
  sell_date,
  COUNT(DISTINCT product) AS num_sold,
  STRING_AGG(DISTINCT product, ',' ORDER BY product) AS products
FROM
  Activities
GROUP BY
  sell_date
ORDER BY
  sell_date;
