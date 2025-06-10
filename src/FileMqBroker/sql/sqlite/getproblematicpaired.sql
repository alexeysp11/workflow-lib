select 
    req.id as req_id,
    resp.id as resp_id,
    req.name,
    req.CreatedAt as req_CreatedAt,
    resp.CreatedAt as resp_CreatedAt,
    req.MessageFileState as req_MessageFileState,
    resp.MessageFileState as resp_MessageFileState
from RequestMessageFiles req 
inner join ResponseMessageFiles resp on replace(req.name, '.req', '') = replace(resp.name, '.resp', '')
where req.MessageFileState <> 11 and resp.MessageFileState <> 6;
