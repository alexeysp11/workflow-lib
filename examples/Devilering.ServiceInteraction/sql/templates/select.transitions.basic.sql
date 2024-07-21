select 
	bpst."Id",
	bpst."BusinessProcessId",
	bpst."PreviousId",
	bpst."FromStateId",
	bpst."ToStateId",
	from_bps."Name" as "FromStateName", 
	to_bps."Name" as "ToStateName"
from "BusinessProcessStateTransitions" bpst
inner join "BusinessProcessStates" from_bps ON from_bps."Id" = bpst."FromStateId"
inner join "BusinessProcessStates" to_bps ON to_bps."Id" = bpst."ToStateId"