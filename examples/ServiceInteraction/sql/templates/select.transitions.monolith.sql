select 
	bpst."Id",
	bpst."BusinessProcessId",
	bpst."PreviousId",
	bpst."FromStateId",
	bpst."ToStateId",
	from_bps."Name" as "FromStateName", 
	to_bps."Name" as "ToStateName",
	ec."Id" as ec_id,
	case 
		when ec."EndpointCallType" = 0 then 'Monolith'
		when ec."EndpointCallType" = 1 then 'HTTP'
		when ec."EndpointCallType" = 2 then 'gRPC'
		else 'Undefined'
	end as ect_name
from "BusinessProcessStateTransitions" bpst
inner join "BusinessProcessStates" from_bps ON from_bps."Id" = bpst."FromStateId"
inner join "BusinessProcessStates" to_bps ON to_bps."Id" = bpst."ToStateId"
inner join "EndpointCalls" ec ON ec."BusinessProcessStateTransitionId" = bpst."Id"
where ec."EndpointCallType" = 0 