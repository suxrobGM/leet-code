-- 1741. Find Total Time Spent by Each Employee - Easy
-- Link: https://leetcode.com/problems/find-total-time-spent-by-each-employee
-- Solution in PostgreSQL

SELECT
  event_day AS day,
  emp_id,
  SUM(out_time - in_time) AS total_time
FROM
  Employees
GROUP BY
  emp_id,
  event_day;
