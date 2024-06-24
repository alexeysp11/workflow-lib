-- Returns a table of months. 
SELECT 
    t.period_id, 
    t.month_no, 
    t.year, 
    t.year || ' ' || w.english  AS english, 
    t.year || ' ' || w.german  AS german, 
    t.year || ' ' || w.russian  AS russian, 
    t.year || ' ' || w.spanish  AS spanish, 
    t.year || ' ' || w.portugues  AS portugues, 
    t.year || ' ' || w.french  AS french, 
    t.year || ' ' || w.italian  AS italian
FROM
(
    SELECT 
        period_id, 
        month AS month_no, 
        (
            CASE 
                WHEN p.month = 1 THEN 'january'
                WHEN p.month = 2 THEN 'february'
                WHEN p.month = 3 THEN 'march'
                WHEN p.month = 4 THEN 'april'
                WHEN p.month = 5 THEN 'may'
                WHEN p.month = 6 THEN 'june'
                WHEN p.month = 7 THEN 'july'
                WHEN p.month = 8 THEN 'august'
                WHEN p.month = 9 THEN 'september'
                WHEN p.month = 10 THEN 'october'
                WHEN p.month = 11 THEN 'november'
                WHEN p.month = 12 THEN 'december'
                ELSE NULL
            END
        ) AS month, 
        year
    FROM period p 
) t, 
word w
WHERE UPPER(w.english) LIKE UPPER(t.month)
ORDER BY t.year, t.month_no; 
