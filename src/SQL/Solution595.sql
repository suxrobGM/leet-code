-- 595. Big Countries - Easy
-- Link: https://leetcode.com/problems/big-countries
-- Solution in PostgreSQL

SELECT name, population, area
FROM World
WHERE area >= 3000000 OR population >= 25000000;

