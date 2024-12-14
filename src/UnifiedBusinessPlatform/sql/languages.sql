-- A set of functions to simplify working with languages.

CREATE OR REPLACE FUNCTION "GetLanguageKvpByFormName"(aLanguageType int, aFormName varchar(100), aApplicationUid varchar(255))
RETURNS TABLE (
    "Id" bigint,
    "LanguageType" integer,
    "LanguageKeyId" bigint,
    "Key" text,
    "Value" text,
    "ApplicationUid" text,
    "DateCreated" timestamp with time zone,
    "DateChanged" timestamp with time zone,
    "BusinessEntityStatus" integer
) AS $$
BEGIN
    RETURN QUERY
    SELECT
        lkvp."Id",
        lkvp."LanguageType",
        lkvp."LanguageKeyId",
        lkvp."Key",
        lkvp."Value",
        lkvp."ApplicationUid",
        lkvp."DateCreated",
        lkvp."DateChanged",
        lkvp."BusinessEntityStatus"
    FROM
        "LanguageKeyValuePairs" lkvp
    INNER JOIN
        "LanguageKeyForms" lkf ON lkvp."Key" = lkf."Key" AND lkvp."ApplicationUid" = lkf."ApplicationUid"
    WHERE
        lkvp."LanguageType" = aLanguageType
        AND lkf."FormName" = aFormName
        AND lkvp."ApplicationUid" = aApplicationUid;
END;
$$ LANGUAGE plpgsql;
