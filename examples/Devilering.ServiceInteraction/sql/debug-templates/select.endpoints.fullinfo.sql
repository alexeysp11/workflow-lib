select 
	-- Endpoint call.
	ec."Id" as ec_id,
	case 
		when ec."EndpointCallType" = 0 then 'Monolith'
		when ec."EndpointCallType" = 1 then 'HTTP'
		when ec."EndpointCallType" = 2 then 'gRPC'
		else 'Undefined'
	end as ect_name,
	-- Endpoint.
	etf."Name" as etf_name,
	e."Name" as e_name,
	ett."Name" as ett_name,
	ee."Name" as ee_name,
	-- Business process states.
	bps."Name" as bps_name,
	bpst."FromStateId" as bpst_fromstateid,
	bpsfrom."Name" as bpsfrom_name,
	bpst."ToStateId" as bpst_tostateid,
	bpsto."Name" as bpsto_name
from "EndpointCalls" ec 
inner join "EndpointTypes" etf on etf."Id" = ec."EndpointTypeFromId"
inner join "EndpointTypes" ett on ett."Id" = ec."EndpointTypeToId"
inner join "Endpoints" e on e."EndpointTypeId" = etf."Id"
inner join "Endpoints" ee on ee."EndpointTypeId" = ett."Id"
left join "BusinessProcessStates" bps on bps."Id" = ec."BusinessProcessStateId"
left join "BusinessProcessStateTransitions" bpst on bpst."Id" = ec."BusinessProcessStateTransitionId"
left join "BusinessProcessStates" bpsfrom on bpsfrom."Id" = bpst."FromStateId"
left join "BusinessProcessStates" bpsto on bpsto."Id" = bpst."ToStateId"
where ec."EndpointCallType" = 0
