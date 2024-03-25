select 
	dl."Id",
	dl."SourceName",
	dl."SourceDetails",
	dl."SourceStatus",
	dl."CreateDate",
	dl."ChangeDate"
from "DbgLogs" dl 
order by dl."Id" desc