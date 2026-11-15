-- 2356. Number of Unique Subjects Taught by Each Teacher - Easy
-- Link: https://leetcode.com/problems/number-of-unique-subjects-taught-by-each-teacher
-- Solution in PostgreSQL

SELECT teacher_id, COUNT(DISTINCT subject_id) AS cnt
FROM Teacher
GROUP BY teacher_id;
