-- 1978. Employees Whose Manager Left the Company - Easy
-- Link: https://leetcode.com/problems/employees-whose-manager-left-the-company
-- Solution in PostgreSQL

SELECT employee_id
FROM Employees
WHERE salary < 30000
  AND manager_id IS NOT NULL
  AND manager_id NOT IN (SELECT employee_id FROM Employees)
ORDER BY employee_id;
