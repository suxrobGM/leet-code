-- 176. Second Highest Salary - Medium
-- Link: https://leetcode.com/problems/second-highest-salary
-- Solution in MySQL
SELECT
    IFNULL(
        (SELECT DISTINCT Salary
         FROM Employee
         ORDER BY Salary DESC
         LIMIT 1 OFFSET 1),
        NULL) AS SecondHighestSalary;
