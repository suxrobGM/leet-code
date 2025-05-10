-- 1341. Movie Rating - Medium
-- Link: https://leetcode.com/problems/movie-rating
-- Solution in PostgreSQL

(
  SELECT name AS results
  FROM Users u
  JOIN MovieRating mr ON u.user_id = mr.user_id
  GROUP BY u.user_id, u.name
  ORDER BY COUNT(*) DESC, u.name
  LIMIT 1
)
UNION ALL
(
  SELECT title AS results
  FROM Movies m
  JOIN MovieRating mr ON m.movie_id = mr.movie_id
  WHERE mr.created_at BETWEEN '2020-02-01' AND '2020-02-29'
  GROUP BY m.movie_id, m.title
  ORDER BY AVG(mr.rating) DESC, m.title
  LIMIT 1
);
