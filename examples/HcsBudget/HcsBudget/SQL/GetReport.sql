SELECT 
    t.p_name, 
    SUM(t.hcs_qty) AS hcs_qty, 
    ROUND(SUM(t.hcs_price_usd / q.p_qty), 2) AS hcs_price_usd
FROM 
(
    SELECT 
        hcs.hcs_id,
        hcs.name AS hcs_name, 
        COALESCE(hcs.qty, 0) AS hcs_qty,
        COALESCE(hcs.price_usd, 0) * COALESCE(hcs.qty, 0) AS hcs_price_usd, 
        p.name AS p_name
    FROM hcs 
    INNER JOIN hcs_participant hcsp ON hcs.hcs_id = hcsp.hcs_id
    LEFT JOIN participant p ON p.participant_id = hcsp.participant_id
    INNER JOIN period pd ON pd.period_id = hcs.period_id
    WHERE 
        (pd.month BETWEEN {0} AND {2}) 
        AND (pd.year BETWEEN {1} AND {3}) 
) t, 
(
    SELECT hcs.hcs_id, COUNT(*) AS p_qty
    FROM hcs 
    INNER JOIN hcs_participant hcsp ON hcs.hcs_id = hcsp.hcs_id
    LEFT JOIN participant p ON p.participant_id = hcsp.participant_id
    INNER JOIN period pd ON pd.period_id = hcs.period_id
    WHERE 
        (pd.month BETWEEN {0} AND {2}) 
        AND (pd.year BETWEEN {1} AND {3}) 
    GROUP BY hcs.name
) q
WHERE t.hcs_id = q.hcs_id
GROUP BY t.p_name
ORDER BY t.p_name