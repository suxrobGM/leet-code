-- 1731. The Number of Employees Which Report to Each Employee - Easy
-- Link: https://leetcode.com/problems/the-number-of-employees-which-report-to-each-employee
-- Solution in PostgreSQL

SELECT
  e1.employee_id,
  e1.name,
  COUNT(e2.employee_id) AS reports_count,
  ROUND(AVG(e2.age)) AS average_age
FROM Employees e1
JOIN Employees e2
  ON e1.employee_id = e2.reports_to
GROUP BY e1.employee_id, e1.name
ORDER BY e1.employee_id;
