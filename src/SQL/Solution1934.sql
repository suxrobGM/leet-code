-- 1934. Confirmation Rate - Medium
-- Link: https://leetcode.com/problems/confirmation-rate
-- Solution in PostgreSQL

SELECT 
    s.user_id,
    ROUND(
        COALESCE(
            SUM(CASE WHEN c.action = 'confirmed' THEN 1 ELSE 0 END)::DECIMAL / 
            NULLIF(COUNT(c.time_stamp), 0),
            0
        ),
        2
    ) AS confirmation_rate
FROM Signups s
LEFT JOIN Confirmations c ON s.user_id = c.user_id
GROUP BY s.user_id
ORDER BY s.user_id;
