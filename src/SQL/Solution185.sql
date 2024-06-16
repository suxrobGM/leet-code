-- 185. Department Top Three Salaries - Hard
-- Link: https://leetcode.com/problems/department-top-three-salaries
-- Solution in MySQL
SELECT Department AS 'Department', Employee AS 'Employee', Salary
FROM
(
    SELECT
        Department.name AS 'Department',
        Employee.name AS 'Employee',
        Salary,
        DENSE_RANK() OVER (PARTITION BY DepartmentId ORDER BY Salary DESC) AS 'Ranking'
    FROM Employee
    JOIN Department ON Employee.DepartmentId = Department.Id
) AS temp
WHERE Ranking <= 3;
