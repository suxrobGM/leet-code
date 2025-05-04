-- 1321. Restaurant Growth - Medium
-- Link: https://leetcode.com/problems/restaurant-growth
-- Solution in PostgreSQL

WITH daily_amount AS (
  SELECT visited_on, SUM(amount) AS amount
  FROM Customer
  GROUP BY visited_on
),
moving_avg AS (
  SELECT 
    d1.visited_on,
    SUM(d2.amount) AS amount,
    ROUND(SUM(d2.amount) * 1.0 / 7, 2) AS average_amount
  FROM daily_amount d1
  JOIN daily_amount d2
    ON d2.visited_on BETWEEN d1.visited_on - INTERVAL '6 days' AND d1.visited_on
  GROUP BY d1.visited_on
)
SELECT *
FROM moving_avg
WHERE visited_on >= (
  SELECT MIN(visited_on) + INTERVAL '6 days'
  FROM daily_amount
)
ORDER BY visited_on;
