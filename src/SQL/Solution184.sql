-- 184. Department Highest Salary - Medium
-- Link: https://leetcode.com/problems/department-highest-salary
-- Solution in MySQL
SELECT Department.name AS 'Department', Employee.name AS 'Employee', Salary
FROM Employee
JOIN Department ON Employee.DepartmentId = Department.Id
WHERE (DepartmentId, Salary) IN
(
    SELECT DepartmentId, MAX(Salary)
    FROM Employee
    GROUP BY DepartmentId
);
