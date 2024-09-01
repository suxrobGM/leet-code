-- 511. Game Play Analysis I
-- Link: https://leetcode.com/problems/game-play-analysis-i
-- Solution in PostgreSQL
SELECT 
    player_id,
    MIN(event_date) AS first_login
FROM 
    Activity
GROUP BY 
    player_id;
