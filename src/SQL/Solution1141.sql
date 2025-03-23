-- 1141. User Activity for the Past 30 Days I - Easy
-- Link: https://leetcode.com/problems/user-activity-for-the-past-30-days-i
-- Solution in PostgreSQL
SELECT activity_date AS day, COUNT(DISTINCT user_id) AS active_users
FROM Activity
WHERE activity_date BETWEEN '2019-07-27'::DATE - INTERVAL '29 days' AND '2019-07-27'
GROUP BY activity_date;
