-- 608. Tree Node - Medium
-- Link: https://leetcode.com/problems/tree-node
-- Solution in PostgreSQL

SELECT id,
    CASE
        WHEN p_id IS NULL THEN 'Root'
        WHEN id NOT IN (SELECT DISTINCT p_id FROM Tree WHERE p_id IS NOT NULL) THEN 'Leaf'
        ELSE 'Inner'
    END AS type
FROM Tree;
