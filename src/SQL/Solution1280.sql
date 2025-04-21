-- 1280. Students and Examinations - Easy
-- Link: https://leetcode.com/problems/students-and-examinations
-- Solution in PostgreSQL

SELECT 
    s.student_id,
    s.student_name,
    subj.subject_name,
    COUNT(e.subject_name) AS attended_exams
FROM Students s
CROSS JOIN Subjects subj
LEFT JOIN Examinations e
  ON s.student_id = e.student_id AND subj.subject_name = e.subject_name
GROUP BY s.student_id, s.student_name, subj.subject_name
ORDER BY s.student_id, subj.subject_name;
