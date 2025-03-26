-- 1148. Article Views I - Easy
-- Link: https://leetcode.com/problems/article-views-i
-- Solution in PostgreSQL

SELECT DISTINCT author_id AS id
FROM Views
WHERE author_id = viewer_id
ORDER BY id;
