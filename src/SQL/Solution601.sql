-- 601. Human Traffic of Stadium - Hard
-- Link: https://leetcode.com/problems/human-traffic-of-stadium
-- Solution in PostgreSQL

WITH ValidVisits AS (
    -- Filter rows where people >= 100
    SELECT id, visit_date, people,
           ROW_NUMBER() OVER (ORDER BY id) AS row_num
    FROM stadium
    WHERE people >= 100
),
ConsecutiveGroups AS (
    -- Calculate the difference between row number and id
    -- This difference will be the same for consecutive rows
    SELECT id, visit_date, people,
           (id - row_num) AS grp
    FROM ValidVisits
),
GroupedVisits AS (
    -- Count the number of rows in each group
    SELECT grp, MIN(visit_date) AS start_date, COUNT(*) AS cnt
    FROM ConsecutiveGroups
    GROUP BY grp
    HAVING COUNT(*) >= 3
)

-- Select the rows from the original table that belong to valid groups
SELECT s.id, s.visit_date, s.people
FROM stadium s
JOIN ConsecutiveGroups cg ON s.id = cg.id
JOIN GroupedVisits gv ON cg.grp = gv.grp
ORDER BY s.visit_date;
