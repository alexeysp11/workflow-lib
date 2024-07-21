select 
	dl."Id",
	dl."SourceName",
	dl."SourceDetails",
	dl."SourceStatus",
	dl."DateCreated",
	dl."DateChanged"
from "DbgLogs" dl 
order by dl."Id" desc
limit 50