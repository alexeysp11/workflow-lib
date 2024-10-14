-- Create user accounts based on the records from the "Employees" table.
INSERT INTO "UserAccounts" (
  "Login", "Email", "PhoneNumber", "Password", "Status", "Uid", "Name", "Description", "DateCreated", "DateChanged", "BusinessEntityStatus"
)
SELECT 
  "FirstName" || '.' || "LastName",
  "FirstName" || '.' || "LastName" || '@example.com',
  "MobilePhone",
  "FirstName" || '.' || "LastName",
  0,
  "Uid",
  "FullName",
  "Description",
  "DateCreated",
  "DateChanged",
  "BusinessEntityStatus"
FROM "Employees";

-- Fill in the association table between "Employees" and "UserAccounts".
INSERT INTO "EmployeeUserAccounts" (
  "EmployeeId", "UserAccountId", "DateCreated", "Uid", "Name", "Description", "DateChanged", "BusinessEntityStatus"
)
SELECT 
  e."Id",
  ua."Id",
  NOW(),
  e."Uid",
  e."FullName",
  e."Description",
  e."DateChanged",
  e."BusinessEntityStatus"
FROM "Employees" e
JOIN "UserAccounts" ua ON e."FirstName" || '.' || e."LastName" = ua."Login";
