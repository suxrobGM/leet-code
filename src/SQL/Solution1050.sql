-- 1050. Actors and Directors Who Cooperated At Least Three Times - Easy
-- Link: https://leetcode.com/problems/actors-and-directors-who-cooperated-at-least-three-times
-- Solution in PostgreSQL

SELECT actor_id, director_id
FROM ActorDirector
GROUP BY actor_id, director_id
HAVING COUNT(*) >= 3;
