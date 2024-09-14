-- 550. Game Play Analysis IV
-- Link: https://leetcode.com/problems/game-play-analysis-iv
-- Solution in PostgreSQL
WITH FirstLogin AS (
    -- Step 1: Identify the first login date for each player
    SELECT player_id, MIN(event_date) AS first_login_date
    FROM Activity
    GROUP BY player_id
),
ConsecutiveLogin AS (
    -- Step 2: Identify players who logged in on the next day after their first login
    SELECT DISTINCT A.player_id
    FROM Activity A
    JOIN FirstLogin F
    ON A.player_id = F.player_id
    WHERE A.event_date = F.first_login_date + INTERVAL '1 day'
)
-- Step 3: Calculate the fraction of players with consecutive logins
SELECT 
    ROUND(COUNT(C.player_id)::DECIMAL / (SELECT COUNT(*) FROM FirstLogin), 2) AS fraction
FROM ConsecutiveLogin C;
