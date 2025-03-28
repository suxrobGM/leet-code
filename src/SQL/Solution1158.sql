-- 1158. Market Analysis I - Medium
-- Link: https://leetcode.com/problems/market-analysis-i
-- Solution in PostgreSQL

SELECT u.user_id AS buyer_id,
       u.join_date,
       COUNT(o.order_id) AS orders_in_2019
FROM Users u
LEFT JOIN Orders o
  ON u.user_id = o.buyer_id
  AND o.order_date BETWEEN '2019-01-01' AND '2019-12-31'
GROUP BY u.user_id, u.join_date;

