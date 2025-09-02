-- 1789. Primary Department for Each Employee - Easy
-- Link: https://leetcode.com/problems/primary-department-for-each-employee
-- Solution in PostgreSQL

SELECT employee_id, department_id
FROM Employee
WHERE primary_flag = 'Y'
   OR employee_id IN (
        SELECT employee_id
        FROM Employee
        GROUP BY employee_id
        HAVING COUNT(*) = 1
   );

