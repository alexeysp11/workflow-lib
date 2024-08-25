-- Initialize database with data.

CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

-----------------------

-- Organizations.

insert into "Organizations" ("Name", "Description", "Uid", "DateCreated", "BusinessEntityStatus")
values ('TechnoSoft', 'A company specializing in software and information technology development', uuid_generate_v4(), now(), 1);

insert into "Organizations" ("Name", "Description", "Uid", "DateCreated", "BusinessEntityStatus")
values ('Affordable Construction', 'A construction company engaged in environmentally friendly construction. The company provides construction services to third-party organizations or sells construction materials, and also helps build infrastructure and equip buildings for the operation of a number of companies.', uuid_generate_v4(), now(), 1);

insert into "Organizations" ("Name", "Description", "Uid", "DateCreated", "BusinessEntityStatus")
values ('FinanceInvest', 'A financial company providing investment services. The company allows you to calculate the profitability of activities, predict risks and provide a financial forecast for the activities of a company''s contour', uuid_generate_v4(), now(), 1);

insert into "Organizations" ("Name", "Description", "Uid", "DateCreated", "BusinessEntityStatus")
values ('Media Group', 'A media holding that includes various media resources (TV, radio, Internet). The company allows you to promote the company''s brand, as well as attract investment and new employees', uuid_generate_v4(), now(), 1);

insert into "Organizations" ("Name", "Description", "Uid", "DateCreated", "BusinessEntityStatus")
values ('AutoTechCenter', 'A car service center providing a full range of car repair and maintenance services, and also delivers building materials, transports employees on business trips, and repairs cars', uuid_generate_v4(), now(), 1);

-----------------------

-- Generate Positions (OrganizationItem)

-- TechnoSoft: CEO
INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address") 
VALUES (uuid_generate_v4(), 'CEO', 'Chief Executive Officer', NOW(), 1, false, true, NULL);

-- TechnoSoft: Technical Director
INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address") 
VALUES (uuid_generate_v4(), 'Technical Director', 'Responsible for software development', NOW(), 1, false, true, NULL);

-- TechnoSoft: Marketing Director
INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address") 
VALUES (uuid_generate_v4(), 'Marketing Director', 'Responsible for promoting technology products and services', NOW(), 1, false, true, NULL);

-- FinanceInvest: CEO
INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address") 
VALUES (uuid_generate_v4(), 'CEO', 'Chief Executive Officer', NOW(), 1, false, true, NULL);

-- FinanceInvest: Investment Director
INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address") 
VALUES (uuid_generate_v4(), 'Investment Director', 'Responsible for investment analysis and portfolio management', NOW(), 1, false, true, NULL);

-- FinanceInvest: Risk Management Director
INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address") 
VALUES (uuid_generate_v4(), 'Risk Management Director', 'Responsible for risk management', NOW(), 1, false, true, NULL);

-- Media Group: President
INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address") 
VALUES (uuid_generate_v4(), 'President', 'Responsible for creating engaging media content', NOW(), 1, false, true, NULL);

-- Media Group: CEO
INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address") 
VALUES (uuid_generate_v4(), 'CEO', 'Chief Executive Officer', NOW(), 1, false, true, NULL);

-- Media Group: Creative Director
INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address") 
VALUES (uuid_generate_v4(), 'Creative Director', 'Responsible for content development and promotion', NOW(), 1, false, true, NULL);

-- AutoTechCenter: Director
INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address") 
VALUES (uuid_generate_v4(), 'Director', 'Responsible for managing the car service center', NOW(), 1, false, true, NULL);

-- AutoTechCenter: Service Manager
INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address") 
VALUES (uuid_generate_v4(), 'Service Manager', 'Responsible for ensuring quality and efficiency of services', NOW(), 1, false, true, NULL);

-- AutoTechCenter: Logistics Manager
INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address") 
VALUES (uuid_generate_v4(), 'Logistics Manager', 'Responsible for efficient delivery of goods and employee transportation', NOW(), 1, false, true, NULL);

-----------------------

-- Generating the Management Committee (OrganizationItem) and its positions.

-- Affordable Construction: Management Committee (I'll consider it a department)
INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address") 
VALUES (uuid_generate_v4(), 'Management Committee', 'Responsible for overall company management', NOW(), 0, false, true, NULL);

-- Affordable Construction: Committee Chair
INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Chair', 'Leads the Management Committee', NOW(), 1, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Management Committee' LIMIT 1));

-- Affordable Construction: Committee Vice Chair
INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Vice Chair', 'Supports the Chair in managing the Committee', NOW(), 1, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Management Committee' LIMIT 1));

-- Affordable Construction: Committee Member
INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Member', 'Contributes to the Management Committee', NOW(), 1, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Management Committee' LIMIT 1));

-----------------------

-- Updating HeadItem in Organization.

-- Update HeadItem for TechnoSoft
UPDATE "Organizations" SET "HeadItemId" = (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'CEO' LIMIT 1 OFFSET 0) 
WHERE "Name" = 'TechnoSoft';

-- Update HeadItem for FinanceInvest
UPDATE "Organizations" SET "HeadItemId" = (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'CEO' LIMIT 1 OFFSET 1) 
WHERE "Name" = 'FinanceInvest';

-- Update HeadItem for Media Group
UPDATE "Organizations" SET "HeadItemId" = (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'President' LIMIT 1) 
WHERE "Name" = 'Media Group';

-- Update HeadItem for AutoTechCenter
UPDATE "Organizations" SET "HeadItemId" = (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Director' LIMIT 1) 
WHERE "Name" = 'AutoTechCenter';

-- Update HeadItem for Affordable Construction
UPDATE "Organizations" SET "HeadItemId" = (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Management Committee' LIMIT 1) 
WHERE "Name" = 'Affordable Construction';

-----------------------

-- UPDATE SQL queries to establish dependencies in OrganizationItems for top-managers.

-- Media Group
UPDATE "OrganizationItems" SET "ParentItemId" = (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'President') 
WHERE "Id" = (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'CEO' LIMIT 1 OFFSET 2);

UPDATE "OrganizationItems" SET "ParentItemId" = (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'CEO' LIMIT 1 OFFSET 2) 
WHERE "Name" = 'Creative Director';

-- TechnoSoft
UPDATE "OrganizationItems" SET "ParentItemId" = (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'CEO' LIMIT 1 OFFSET 0) 
WHERE "Name" = 'Technical Director';

UPDATE "OrganizationItems" SET "ParentItemId" = (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'CEO' LIMIT 1 OFFSET 0) 
WHERE "Name" = 'Marketing Director';

-- FinanceInvest
UPDATE "OrganizationItems" SET "ParentItemId" = (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'CEO' LIMIT 1 OFFSET 1) 
WHERE "Name" = 'Investment Director';

UPDATE "OrganizationItems" SET "ParentItemId" = (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'CEO' LIMIT 1 OFFSET 1) 
WHERE "Name" = 'Risk Management Director';

-- AutoTechCenter
UPDATE "OrganizationItems" SET "ParentItemId" = (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Director' LIMIT 1) 
WHERE "Name" = 'Service Manager';

UPDATE "OrganizationItems" SET "ParentItemId" = (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Director' LIMIT 1) 
WHERE "Name" = 'Logistics Manager';

-----------------------

-- Departments.
insert into "OrganizationItems" ("Name", "Description", "Uid", "DateCreated", "BusinessEntityStatus", "ItemType", "HardDelete", "IsDeleted")
values ('Sales Department', 'Responsible for promoting and selling the company''s products/services', uuid_generate_v4(), now(), 1, 0, true, false);

insert into "OrganizationItems" ("Name", "Description", "Uid", "DateCreated", "BusinessEntityStatus", "ItemType", "HardDelete", "IsDeleted")
values ('Marketing Department', 'Conducts marketing research, develops marketing strategies', uuid_generate_v4(), now(), 1, 0, true, false);

insert into "OrganizationItems" ("Name", "Description", "Uid", "DateCreated", "BusinessEntityStatus", "ItemType", "HardDelete", "IsDeleted")
values ('Finance Department', 'Maintains financial records, manages the budget, and performs financial analysis', uuid_generate_v4(), now(), 1, 0, true, false);

insert into "OrganizationItems" ("Name", "Description", "Uid", "DateCreated", "BusinessEntityStatus", "ItemType", "HardDelete", "IsDeleted")
values ('Development Department', 'Develops products, software, and new technologies', uuid_generate_v4(), now(), 1, 0, true, false);

insert into "OrganizationItems" ("Name", "Description", "Uid", "DateCreated", "BusinessEntityStatus", "ItemType", "HardDelete", "IsDeleted")
values ('HR Department', 'Responsible for recruiting, training, motivation, and administrative issues', uuid_generate_v4(), now(), 1, 0, true, false);

insert into "OrganizationItems" ("Name", "Description", "Uid", "DateCreated", "BusinessEntityStatus", "ItemType", "HardDelete", "IsDeleted")
values ('Logistics Department', 'Organizes transportation, storage, and delivery of goods', uuid_generate_v4(), now(), 1, 0, true, false);

insert into "OrganizationItems" ("Name", "Description", "Uid", "DateCreated", "BusinessEntityStatus", "ItemType", "HardDelete", "IsDeleted")
values ('Legal Department', 'Provides legal advice, and conducts legal proceedings', uuid_generate_v4(), now(), 1, 0, true, false);

insert into "OrganizationItems" ("Name", "Description", "Uid", "DateCreated", "BusinessEntityStatus", "ItemType", "HardDelete", "IsDeleted")
values ('IT Department', 'Develops and maintains the company''s IT infrastructure', uuid_generate_v4(), now(), 1, 0, true, false);

insert into "OrganizationItems" ("Name", "Description", "Uid", "DateCreated", "BusinessEntityStatus", "ItemType", "HardDelete", "IsDeleted")
values ('Security Department', 'Deals with company security issues (technical, physical, informational)', uuid_generate_v4(), now(), 1, 0, true, false);

insert into "OrganizationItems" ("Name", "Description", "Uid", "DateCreated", "BusinessEntityStatus", "ItemType", "HardDelete", "IsDeleted")
values ('Quality Department', 'Monitors the quality of products, services, and processes', uuid_generate_v4(), now(), 1, 0, true, false);

-----------------------

-- Positions
-- 1. "Sales Manager" - Sales Department: Conducts telephone negotiations, meetings with clients, concludes contracts.
-- 2. "Marketing Specialist" - Marketing Department: Conducts marketing research, prepares advertising materials.
-- 3. "Accountant" - Accounting Department: Keeps records of financial transactions, prepares documents.
-- 4. "Programmer" - Software Development Department: Develops and tests software.
-- 5. "HR Specialist" - HR Department: Conducts interviews, selects candidates.
-- 6. "Logistician" - Logistics Department: Plans and organizes logistics processes, tracks orders.
-- 7. "Lawyer" - Legal Support Department: Provides legal advice, prepares documents.
-- 8. "System Administrator" - Network Technologies Department: Manages servers, network equipment, ensures network security.
-- 9. "Security Guard" - Technical Security Department: Ensures building security, controls access to the territory.
-- 10. "Quality Engineer" - Quality Control Department: Conducts quality checks of products and processes.
-- 11. "Technical Writer" - Software Development Department: Writes software documentation.
-- 12. "Testing Specialist" - Software Development Department: Conducts software testing.
-- 13. "Graphic Designer" - Marketing Department: Creates designs for advertising materials, presentations.
-- 14. "Content Manager" - Marketing Department: Creates and edits content for the website, social networks.
-- 15. "Analyst" - Finance Department: Analyzes the company's financial performance, prepares reports.
