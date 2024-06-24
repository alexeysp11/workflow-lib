SELECT 
    hcs.hcs_id, 
    hcs.name AS hcs_name, 
    hcs.qty, 
    hcs.price_usd, 
    GROUP_CONCAT(pt.name) AS participant_name, 
    hcs.qty * hcs.price_usd AS total_price, 
    p.month, 
    p.year, 
    p.period_id
FROM hcs
INNER JOIN period p ON p.period_id = hcs.period_id
LEFT JOIN hcs_participant hcsp ON hcsp.hcs_id = hcs.hcs_id
LEFT JOIN participant pt ON pt.participant_id = hcsp.participant_id
WHERE p.period_id = {0}
GROUP BY 
    hcs.hcs_id, hcs_name, qty, price_usd, total_price, month, 
    year, p.period_id
ORDER BY hcs_name