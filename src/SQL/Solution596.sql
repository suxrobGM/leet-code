-- 596. Classes More Than 5 Students - Easy
-- Link: https://leetcode.com/problems/big-countries
-- Solution in PostgreSQL

SELECT class
FROM courses
GROUP BY class
HAVING COUNT(DISTINCT student) >= 5;

