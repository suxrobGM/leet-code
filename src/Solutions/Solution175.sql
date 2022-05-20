SELECT firstName, lastName, city, state FROM Person per 
LEFT JOIN Address addr
ON per.personId = addr.personId