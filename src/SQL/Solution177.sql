-- 177. Nth Highest Salary - Medium
-- Link: https://leetcode.com/problems/nth-highest-salary
-- Solution in MySQL
CREATE FUNCTION getNthHighestSalary(N INT) RETURNS INT
BEGIN
  DECLARE M INT;
  SET M = N - 1;
  RETURN (
      SELECT IFNULL(
          (SELECT DISTINCT Salary
           FROM Employee
           ORDER BY Salary DESC
           LIMIT 1 OFFSET M),
          NULL)
  );
END
