INSERT INTO period (month, year) 
SELECT {0}, {1}
WHERE
(
    SELECT COUNT(*)
    FROM period
    WHERE month = {0} AND year = {1}
) = 0; 