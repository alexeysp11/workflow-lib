select 
	bp."Id" as bp_id,
	bp."Name" as bp_name,
	bp."BusinessEntityStatus" as bp_bestatus,
	bps."Name" as bps_name,
	bps."BusinessEntityStatus" as bps_bestatus
from "BusinessProcesses" bp 
left join "BusinessProcessStates" bps on bp."Id" = bps."BusinessProcessId"