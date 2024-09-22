-- 570. Managers with at Least 5 Direct Reports - Medium
-- Link: https://leetcode.com/problems/managers-with-at-least-5-direct-reports
-- Solution in PostgreSQL

SELECT m.name
FROM Employee AS e
INNER JOIN Employee AS m ON e.managerId = m.id
GROUP BY m.id, m.name
HAVING COUNT(e.id) >= 5;

