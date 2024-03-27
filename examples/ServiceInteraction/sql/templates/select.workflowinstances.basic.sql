select 
	-- Workflow instance.
    wi."Id" as wi_id, 
    wi."Name" as wi_name, 
    wi."Uid" as wi_uid, 
    wi."Description" as wi_description, 
    wi."ParentInstanceId" as wi_parentinstanceid, 
    wi."BusinessEntityStatus" as wi_businessentitystatus, 
    wi."IsEmulation" as wi_isemulation,
	-- Business process.
    bp."Id" as bp_id, 
	bp."Name" as bp_name,
	-- Workflow tracking items.
	wti."Id" as wti_id,
	wti."Name" as wti_name,
	wti."Description" as wti_description,
	wti."Status" as wti_status,
	-- Business tasks.
	bt."Id" as bt_id,
	bt."Name" as bt_name,
	bt."Subject" as bt_subject,
	bt."ParentTaskId" as bt_parenttaskid,
	bt."IsEmulation" as bt_isemulation,
	bt."Priority" as bt_priority,
	bt."Status" as bt_status
from "WorkflowInstances" wi 
left join "WorkflowTrackingItems" wti ON wti."WorkflowInstanceId" = wi."Id"
left join "BusinessProcesses" bp ON bp."Id" = wi."BusinessProcessId"
left join "BusinessTasks" bt ON bt."Id" = wti."ActiveTaskId"
