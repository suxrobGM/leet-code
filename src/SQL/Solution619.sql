-- 619. Biggest Single Number - Easy
-- Link: https://leetcode.com/problems/biggest-single-number
-- Solution in PostgreSQL

SELECT MAX(num) AS num FROM (
    SELECT num 
    FROM MyNumbers 
    GROUP BY num 
    HAVING COUNT(num) = 1
);
