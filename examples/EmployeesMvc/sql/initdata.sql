-- Initialize database with data.

CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

-----------------------

-- Organizations.

INSERT INTO "Organizations" ("Name", "Description", "Uid", "DateCreated", "BusinessEntityStatus")
VALUES ('TechnoSoft', 'A company specializing in software and information technology development', uuid_generate_v4(), NOW(), 1);

INSERT INTO "Organizations" ("Name", "Description", "Uid", "DateCreated", "BusinessEntityStatus")
VALUES ('Affordable Construction', 'A construction company engaged in environmentally friendly construction. The company provides construction services to third-party organizations or sells construction materials, and also helps build infrastructure and equip buildings for the operation of a number of companies.', uuid_generate_v4(), NOW(), 1);

INSERT INTO "Organizations" ("Name", "Description", "Uid", "DateCreated", "BusinessEntityStatus")
VALUES ('FinanceInvest', 'A financial company providing investment services. The company allows you to calculate the profitability of activities, predict risks and provide a financial forecast for the activities of a company''s contour', uuid_generate_v4(), NOW(), 1);

INSERT INTO "Organizations" ("Name", "Description", "Uid", "DateCreated", "BusinessEntityStatus")
VALUES ('Media Group', 'A media holding that includes various media resources (TV, radio, Internet). The company allows you to promote the company''s brand, as well as attract investment and new employees', uuid_generate_v4(), NOW(), 1);

INSERT INTO "Organizations" ("Name", "Description", "Uid", "DateCreated", "BusinessEntityStatus")
VALUES ('AutoTechCenter', 'A car service center providing a full range of car repair and maintenance services, and also delivers building materials, transports employees on business trips, and repairs cars', uuid_generate_v4(), NOW(), 1);

-----------------------

-- Generate Positions (OrganizationItem)

-- TechnoSoft: CEO
INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address") 
VALUES (uuid_generate_v4(), 'CEO (TechnoSoft)', 'Chief Executive Officer', NOW(), 1, false, true, NULL);

-- TechnoSoft: Technical Director
INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address") 
VALUES (uuid_generate_v4(), 'Technical Director', 'Responsible for software development', NOW(), 1, false, true, NULL);

-- TechnoSoft: Marketing Director
INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address") 
VALUES (uuid_generate_v4(), 'Marketing Director', 'Responsible for promoting technology products and services', NOW(), 1, false, true, NULL);

-- FinanceInvest: CEO
INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address") 
VALUES (uuid_generate_v4(), 'CEO (FinanceInvest)', 'Chief Executive Officer', NOW(), 1, false, true, NULL);

-- FinanceInvest: Investment Director
INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address") 
VALUES (uuid_generate_v4(), 'Investment Director', 'Responsible for investment analysis and portfolio management', NOW(), 1, false, true, NULL);

-- FinanceInvest: Risk Management Director
INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address") 
VALUES (uuid_generate_v4(), 'Risk Management Director', 'Responsible for risk management', NOW(), 1, false, true, NULL);

-- Media Group: President
INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address") 
VALUES (uuid_generate_v4(), 'President (Media Group)', 'Responsible for creating engaging media content', NOW(), 1, false, true, NULL);

-- Media Group: CEO
INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address") 
VALUES (uuid_generate_v4(), 'CEO (Media Group)', 'Chief Executive Officer', NOW(), 1, false, true, NULL);

-- Media Group: Creative Director
INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address") 
VALUES (uuid_generate_v4(), 'Creative Director', 'Responsible for content development and promotion', NOW(), 1, false, true, NULL);

-- AutoTechCenter: Director (AutoTechCenter)
INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address") 
VALUES (uuid_generate_v4(), 'Director (AutoTechCenter)', 'Responsible for managing the car service center', NOW(), 1, false, true, NULL);

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
VALUES (uuid_generate_v4(), 'Management Committee (Affordable Construction)', 'Responsible for overall company management', NOW(), 0, false, true, NULL);

-- Affordable Construction: Committee Chair
INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Chair', 'Leads the Management Committee', NOW(), 1, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Management Committee (Affordable Construction)' LIMIT 1));

-- Affordable Construction: Committee Vice Chair
INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Vice Chair', 'Supports the Chair in managing the Committee', NOW(), 1, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Management Committee (Affordable Construction)' LIMIT 1));

-- Affordable Construction: Committee Member
INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Member', 'Contributes to the Management Committee', NOW(), 1, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Management Committee (Affordable Construction)' LIMIT 1));

-----------------------

-- Updating HeadItem in Organization.

-- Update HeadItem for TechnoSoft
UPDATE "Organizations" SET "HeadItemId" = (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'CEO (TechnoSoft)') 
WHERE "Name" = 'TechnoSoft';

-- Update HeadItem for FinanceInvest
UPDATE "Organizations" SET "HeadItemId" = (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'CEO (FinanceInvest)') 
WHERE "Name" = 'FinanceInvest';

-- Update HeadItem for Media Group
UPDATE "Organizations" SET "HeadItemId" = (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'President (Media Group)' LIMIT 1) 
WHERE "Name" = 'Media Group';

-- Update HeadItem for AutoTechCenter
UPDATE "Organizations" SET "HeadItemId" = (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Director (AutoTechCenter)' LIMIT 1) 
WHERE "Name" = 'AutoTechCenter';

-- Update HeadItem for Affordable Construction
UPDATE "Organizations" SET "HeadItemId" = (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Management Committee (Affordable Construction)' LIMIT 1) 
WHERE "Name" = 'Affordable Construction';

-----------------------

-- UPDATE SQL queries to establish dependencies in OrganizationItems for top-managers.

-- Media Group
UPDATE "OrganizationItems" SET "ParentItemId" = (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'President (Media Group)') 
WHERE "Id" = (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'CEO (Media Group)');

UPDATE "OrganizationItems" SET "ParentItemId" = (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'CEO (Media Group)') 
WHERE "Name" = 'Creative Director';

-- TechnoSoft
UPDATE "OrganizationItems" SET "ParentItemId" = (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'CEO (TechnoSoft)') 
WHERE "Name" = 'Technical Director';

UPDATE "OrganizationItems" SET "ParentItemId" = (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'CEO (TechnoSoft)') 
WHERE "Name" = 'Marketing Director';

-- FinanceInvest
UPDATE "OrganizationItems" SET "ParentItemId" = (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'CEO (FinanceInvest)') 
WHERE "Name" = 'Investment Director';

UPDATE "OrganizationItems" SET "ParentItemId" = (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'CEO (FinanceInvest)') 
WHERE "Name" = 'Risk Management Director';

-- AutoTechCenter
UPDATE "OrganizationItems" SET "ParentItemId" = (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Director (AutoTechCenter)' LIMIT 1) 
WHERE "Name" = 'Service Manager';

UPDATE "OrganizationItems" SET "ParentItemId" = (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Director (AutoTechCenter)' LIMIT 1) 
WHERE "Name" = 'Logistics Manager';

-----------------------

-- Departments.

-- TechnoSoft
INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Software Development Department', 'Responsible for developing software', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'CEO (TechnoSoft)'));

INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'IT Infrastructure Department', 'Responsible for managing IT infrastructure', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'CEO (TechnoSoft)'));

INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Marketing and Sales Department', 'Responsible for marketing and sales activities', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'CEO (TechnoSoft)'));

INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Quality Assurance Department', 'Responsible for testing software', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'CEO (TechnoSoft)'));

INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Project Management Department', 'Responsible for project management', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'CEO (TechnoSoft)'));

INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Research and Development Department', 'Responsible for research and development activities', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'CEO (TechnoSoft)'));

-- FinanceInvest
INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Investment Banking Department', 'Responsible for investment banking activities', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'CEO (FinanceInvest)'));

INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Asset Management Department', 'Responsible for managing assets', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'CEO (FinanceInvest)'));

INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId")
VALUES (uuid_generate_v4(), 'Risk Management Department', 'Responsible for managing risks', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'CEO (FinanceInvest)'));

INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Financial Analysis Department', 'Responsible for financial analysis', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'CEO (FinanceInvest)'));

INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Client Services Department', 'Responsible for client services', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'CEO (FinanceInvest)'));

-- Affordable Construction
INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Project Management Department', 'Responsible for project management', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Management Committee (Affordable Construction)' AND "ItemType" = 0));

INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Construction Management Department', 'Responsible for construction management', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Management Committee (Affordable Construction)' AND "ItemType" = 0));

INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Construction Engineering Department', 'Responsible for construction engineering', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Management Committee (Affordable Construction)' AND "ItemType" = 0));

INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Design and Engineering Department', 'Responsible for design and engineering', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Management Committee (Affordable Construction)' AND "ItemType" = 0));

INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Procurement Department', 'Responsible for procurement', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Management Committee (Affordable Construction)' AND "ItemType" = 0));

INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Quality Control Department', 'Responsible for quality control', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Management Committee (Affordable Construction)' AND "ItemType" = 0));

INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Safety and Environment Department', 'Responsible for safety and environment', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Management Committee (Affordable Construction)' AND "ItemType" = 0));

-- Media Group
INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Television Department', 'Responsible for television production', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'CEO (Media Group)'));

INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Radio Department', 'Responsible for radio production', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'CEO (Media Group)'));

INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Online Media Department', 'Responsible for online media production', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'CEO (Media Group)'));

INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Marketing and Sales Department', 'Responsible for marketing and sales activities', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'CEO (Media Group)'));

INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Finance and Operations Department', 'Responsible for finance and operation', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'CEO (Media Group)'));

-- AutoTechCenter
INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Car Repair and Maintenance Department', 'Responsible for car repair and maintenance', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Director (AutoTechCenter)'));

INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Body Shop Department', 'Responsible for body shop services', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Director (AutoTechCenter)'));

INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Parts and Accessories Department', 'Responsible for selling parts and accessories', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Director (AutoTechCenter)'));

INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Logistics Department', 'Responsible for logistics operations', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Director (AutoTechCenter)'));

INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Customer Service Department', 'Responsible for customer service', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Director (AutoTechCenter)'));

-- Insert teams into "Car Repair and Maintenance Department"
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Car Repair and Maintenance Department' AND "IsDeleted" = FALSE),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Mechanical Repair Team',
    'Team responsible for mechanical repairs',
    1;

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Car Repair and Maintenance Department' AND "IsDeleted" = FALSE),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Electrical Repair Team',
    'Team responsible for electrical repairs',
    1;

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Car Repair and Maintenance Department' AND "IsDeleted" = FALSE),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Diagnostics Team',
    'Team responsible for vehicle diagnostics',
    1;

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Car Repair and Maintenance Department' AND "IsDeleted" = FALSE),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Scheduled Maintenance Team',
    'Team responsible for scheduled maintenance services',
    1;

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Car Repair and Maintenance Department' AND "IsDeleted" = FALSE),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Preventive Maintenance Team',
    'Team responsible for preventive maintenance services',
    1;

-- Insert teams into "Parts and Accessories Department"
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Parts and Accessories Department' AND "IsDeleted" = FALSE),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Parts Sales Team',
    'Team responsible for selling parts and accessories',
    1;

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Parts and Accessories Department' AND "IsDeleted" = FALSE),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Inventory Management Team',
    'Team responsible for managing parts inventory',
    1;

-- Insert teams into "Logistics Department"
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Logistics Department' AND "ParentItemId" IS NOT NULL),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Transportation Team',
    'Team responsible for vehicle transportation',
    1;

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Logistics Department' AND "ParentItemId" IS NOT NULL),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Delivery Team',
    'Team responsible for delivery of parts and vehicles',
    1;

-- Insert teams into "Customer Service Department"
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Customer Service Department' AND "IsDeleted" = FALSE),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Customer Support Team',
    'Team responsible for providing customer support',
    1;

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Customer Service Department' AND "IsDeleted" = FALSE),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Service Scheduling Team',
    'Team responsible for scheduling service appointments',
    1;

-- Insert teams into "Body Shop Department"
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Body Shop Department' AND "IsDeleted" = FALSE),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Body Repair Team',
    'Team responsible for repairing body damage',
    1;

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Body Shop Department' AND "IsDeleted" = FALSE),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Paint Team',
    'Team responsible for vehicle painting',
    1;

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Body Shop Department' AND "IsDeleted" = FALSE),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Detailing Team',
    'Team responsible for vehicle detailing',
    1;

-----------------------

-- Teams.

-- Insert teams into Software Development Department
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    oi."Id", -- Department ID.
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Frontend Development Team',
    'Team responsible for developing the user interface of the application',
    1
FROM "OrganizationItems" oi
WHERE oi."Name" = 'Software Development Department';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    oi."Id", -- Department ID.
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Backend Development Team',
    'Team responsible for developing the server-side logic of the application',
    1
FROM "OrganizationItems" oi
WHERE oi."Name" = 'Software Development Department';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    oi."Id", -- Department ID.
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Mobile Development Team',
    'Team responsible for developing mobile applications',
    1
FROM "OrganizationItems" oi
WHERE oi."Name" = 'Software Development Department';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    oi."Id", -- Department ID.
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'QA Testing Team',
    'Team responsible for testing the application for bugs and defects',
    1
FROM "OrganizationItems" oi
WHERE oi."Name" = 'Software Development Department';

-- Insert teams into IT Infrastructure Department
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    oi."Id", -- Department ID.
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Network Administration Team',
    'Team responsible for managing the network infrastructure',
    1
FROM "OrganizationItems" oi
WHERE oi."Name" = 'IT Infrastructure Department';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    oi."Id", -- Department ID.
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'System Administration Team',
    'Team responsible for managing the server infrastructure',
    1
FROM "OrganizationItems" oi
WHERE oi."Name" = 'IT Infrastructure Department';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    oi."Id", -- Department ID.
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Security Team',
    'Team responsible for securing the network and systems',
    1
FROM "OrganizationItems" oi
WHERE oi."Name" = 'IT Infrastructure Department';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    oi."Id", -- Department ID.
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Database Administration Team',
    'Team responsible for managing the databases',
    1
FROM "OrganizationItems" oi
WHERE oi."Name" = 'IT Infrastructure Department';

-- Insert teams into Quality Assurance Department
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    oi."Id", -- Department ID.
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Manual Testing Team',
    'Team responsible for manually testing the application',
    1
FROM "OrganizationItems" oi
WHERE oi."Name" = 'Quality Assurance Department';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    oi."Id", -- Department ID.
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Automation Testing Team',
    'Team responsible for automating the testing process',
    1
FROM "OrganizationItems" oi
WHERE oi."Name" = 'Quality Assurance Department';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    oi."Id", -- Department ID.
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Performance Testing Team',
    'Team responsible for testing the application performance',
    1
FROM "OrganizationItems" oi
WHERE oi."Name" = 'Quality Assurance Department';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    oi."Id", -- Department ID.
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Security Testing Team',
    'Team responsible for testing the application security',
    1
FROM "OrganizationItems" oi
WHERE oi."Name" = 'Quality Assurance Department';

-- Insert teams into Project Management Department
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    oi."Id", -- Department ID.
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Project Management Team',
    'Team responsible for managing the project lifecycle',
    1
FROM "OrganizationItems" oi
WHERE oi."Name" = 'Project Management Department';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    oi."Id", -- Department ID.
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Product Owners Team',
    'Team responsible for defining the product vision',
    1
FROM "OrganizationItems" oi
WHERE oi."Name" = 'Project Management Department';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    oi."Id", -- Department ID.
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Scrum Masters Team',
    'Team responsible for facilitating the scrum process',
    1
FROM "OrganizationItems" oi
WHERE oi."Name" = 'Project Management Department'
    AND oi."ParentItemId" = (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'CEO (TechnoSoft)');

-- Insert teams into Marketing and Sales Department
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    oi."Id", -- Department ID.
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Marketing Team',
    'Team responsible for developing and executing marketing campaigns',
    1
FROM "OrganizationItems" oi
WHERE oi."Name" = 'Marketing and Sales Department';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    oi."Id", -- Department ID.
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Sales Team',
    'Team responsible for generating leads and closing deals',
    1
FROM "OrganizationItems" oi
WHERE oi."Name" = 'Marketing and Sales Department';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    oi."Id", -- Department ID.
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Content Marketing Team',
    'Team responsible for creating and distributing content',
    1
FROM "OrganizationItems" oi
WHERE oi."Name" = 'Marketing and Sales Department';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    oi."Id", -- Department ID.
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Social Media Marketing Team',
    'Team responsible for managing social media accounts',
    1
FROM "OrganizationItems" oi
WHERE oi."Name" = 'Marketing and Sales Department';

-- Insert teams into "Project Management Department"
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Project Management Department' AND "ParentItemId" = (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Management Committee (Affordable Construction)' AND "ItemType" = 0)),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Project Planning Team',
    'Team responsible for planning projects',
    1;

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Project Management Department' AND "ParentItemId" = (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Management Committee (Affordable Construction)' AND "ItemType" = 0)),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Construction Management Team',
    'Team responsible for managing construction projects',
    1;

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Project Management Department' AND "ParentItemId" = (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Management Committee (Affordable Construction)' AND "ItemType" = 0)),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Project Coordination Team',
    'Team responsible for coordinating project activities',
    1;

-- Insert teams into "Procurement Department"
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Procurement Department' AND "IsDeleted" = FALSE),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Procurement Team',
    'Team responsible for sourcing and purchasing materials',
    1;

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Procurement Department' AND "IsDeleted" = FALSE),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Supply Chain Management Team',
    'Team responsible for managing the supply chain',
    1;

-- Insert teams into "Quality Control Department"
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Quality Control Department' AND "IsDeleted" = FALSE),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Quality Assurance Team',
    'Team responsible for ensuring quality standards are met',
    1;

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Quality Control Department' AND "IsDeleted" = FALSE),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Inspection Team',
    'Team responsible for inspecting materials and processes',
    1;

-- Insert teams into "Safety and Environment Department"
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Safety and Environment Department' AND "IsDeleted" = FALSE),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Safety Officer Team',
    'Team responsible for safety procedures and training',
    1;

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Safety and Environment Department' AND "IsDeleted" = FALSE),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Environmental Compliance Team',
    'Team responsible for environmental compliance and monitoring',
    1;

-- Affordable Construction: Design and Engineering Department.

INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "ParentItemId", "BusinessEntityStatus")
VALUES (uuid_generate_v4(), 'Structural Engineering Team', 'Structural Engineering Team', NOW(), 4, FALSE, TRUE, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Design and Engineering Department'), 1);

INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "ParentItemId", "BusinessEntityStatus")
VALUES (uuid_generate_v4(), 'Civil Engineering Team', 'Civil Engineering Team', NOW(), 4, FALSE, TRUE, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Design and Engineering Department'), 1);

INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "ParentItemId", "BusinessEntityStatus")
VALUES (uuid_generate_v4(), 'Architectural Design Team', 'Architectural Design Team', NOW(), 4, FALSE, TRUE, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Design and Engineering Department'), 1);

-- Affordable Construction: Construction Management Department.

INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "ParentItemId", "BusinessEntityStatus")
VALUES (uuid_generate_v4(), 'Project Planning Team', 'Project Planning Team', NOW(), 4, FALSE, TRUE, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Construction Management Department'), 1);

INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "ParentItemId", "BusinessEntityStatus")
VALUES (uuid_generate_v4(), 'Construction Management Team', 'Construction Management Team', NOW(), 4, FALSE, TRUE, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Construction Management Department'), 1);

INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "ParentItemId", "BusinessEntityStatus")
VALUES (uuid_generate_v4(), 'Project Coordination Team', 'Project Coordination Team', NOW(), 4, FALSE, TRUE, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Construction Management Department'), 1);

-- Insert teams into "Investment Banking Department"
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Investment Banking Department' AND "IsDeleted" = FALSE),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Equity Research Team',
    'Team responsible for research and analysis of equity markets',
    1;

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Investment Banking Department' AND "IsDeleted" = FALSE),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Fixed Income Team',
    'Team responsible for research and analysis of fixed income markets',
    1;

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Investment Banking Department' AND "IsDeleted" = FALSE),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Alternative Investments Team',
    'Team responsible for research and analysis of alternative investments',
    1;

-- Insert teams into "Asset Management Department"
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Asset Management Department' AND "IsDeleted" = FALSE),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Equity Asset Management Team',
    'Team responsible for managing equity assets',
    1;

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Asset Management Department' AND "IsDeleted" = FALSE),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Fixed Income Asset Management Team',
    'Team responsible for managing fixed income assets',
    1;

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Asset Management Department' AND "IsDeleted" = FALSE),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Alternative Investments Asset Management Team',
    'Team responsible for managing alternative investments assets',
    1;

-- Insert teams into "Risk Management Department"
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Risk Management Department' AND "IsDeleted" = FALSE),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Market Risk Management Team',
    'Team responsible for managing market risk',
    1;

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Risk Management Department' AND "IsDeleted" = FALSE),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Credit Risk Management Team',
    'Team responsible for managing credit risk',
    1;

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Risk Management Department' AND "IsDeleted" = FALSE),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Operational Risk Management Team',
    'Team responsible for managing operational risk',
    1;

-- Insert teams into "Financial Analysis Department"
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Financial Analysis Department' AND "IsDeleted" = FALSE),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Financial Reporting Team',
    'Team responsible for preparing financial reports',
    1;

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Financial Analysis Department' AND "IsDeleted" = FALSE),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Accounting Team',
    'Team responsible for accounting operations',
    1;

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Financial Analysis Department' AND "IsDeleted" = FALSE),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Regulatory Reporting Team',
    'Team responsible for preparing regulatory reports',
    1;

-- Insert teams into "Client Services Department"
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Client Services Department' AND "IsDeleted" = FALSE),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Client Relationship Management Team',
    'Team responsible for managing client relationships',
    1;

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Client Services Department' AND "IsDeleted" = FALSE),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Client Onboarding Team',
    'Team responsible for onboarding new clients',
    1;

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Client Services Department' AND "IsDeleted" = FALSE),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Client Support Team',
    'Team responsible for providing client support',
    1;

-- Insert teams into "Television Department"
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Television Department' AND "IsDeleted" = FALSE),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Production Team',
    'Team responsible for planning and executing television productions',
    1;

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Television Department' AND "IsDeleted" = FALSE),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Camera Crew',
    'Team responsible for operating cameras and capturing footage',
    1;

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Television Department' AND "IsDeleted" = FALSE),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Editing Team',
    'Team responsible for editing and assembling video content',
    1;

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Television Department' AND "IsDeleted" = FALSE),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Sound Team',
    'Team responsible for sound recording, mixing, and editing',
    1;

-- Insert teams into "Radio Department"
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Radio Department' AND "IsDeleted" = FALSE),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Production Team',
    'Team responsible for planning and executing radio productions',
    1;

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Radio Department' AND "IsDeleted" = FALSE),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'On-Air Team',
    'Team responsible for presenting and hosting radio programs',
    1;

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Radio Department' AND "IsDeleted" = FALSE),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Editing Team',
    'Team responsible for editing and assembling audio content',
    1;

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Radio Department' AND "IsDeleted" = FALSE),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Sound Team',
    'Team responsible for sound recording, mixing, and editing',
    1;

-- Insert teams into "Online Media Department"
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Online Media Department' AND "IsDeleted" = FALSE),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Content Creation Team',
    'Team responsible for creating and producing online content',
    1;

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Online Media Department' AND "IsDeleted" = FALSE),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Content Editing Team',
    'Team responsible for editing and proofreading online content',
    1;

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Online Media Department' AND "IsDeleted" = FALSE),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Social Media Team',
    'Team responsible for managing social media presence',
    1;

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Online Media Department' AND "IsDeleted" = FALSE),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'SEO Team',
    'Team responsible for search engine optimization',
    1;

-- Insert teams into "Marketing and Sales Department"
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Marketing and Sales Department' AND "IsDeleted" = FALSE),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Marketing Strategy Team',
    'Team responsible for developing and executing marketing strategies',
    1;

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Marketing and Sales Department' AND "IsDeleted" = FALSE),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Advertising Sales Team',
    'Team responsible for selling advertising space',
    1;

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntit
yStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Marketing and Sales Department' AND "IsDeleted" = FALSE),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Digital Marketing Team',
    'Team responsible for digital marketing efforts',
    1;

-- Insert teams into "Finance and Operations Department"
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Finance and Operations Department' AND "IsDeleted" = FALSE),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Finance Team',
    'Team responsible for financial management and accounting',
    1;

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Finance and Operations Department' AND "IsDeleted" = FALSE),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Operations Team',
    'Team responsible for day-to-day operations and logistics',
    1;

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Finance and Operations Department' AND "IsDeleted" = FALSE),
    FALSE,
    TRUE,
    4,
    NOW(),
    uuid_generate_v4(),
    'Human Resources Team',
    'Team responsible for human resource management',
    1;

-----------------------

-- Job titles.

-- TechnoSoft: Software Development Department.

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Software Development Department'),
    FALSE,
    TRUE,
    1,
    'Director of Software Development Department',
    'Head of Software Development Department.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Software Development Department';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Software Development Department'),
    FALSE,
    TRUE,
    1,
    'Software Development Manager',
    'Manages Software Development Teams.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Software Development Department';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Software Development Department'),
    FALSE,
    TRUE,
    1,
    'Senior Software Developer',
    'Experienced software developer with advanced skills.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Software Development Department';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Software Development Department'),
    FALSE,
    TRUE,
    1,
    'Software Developer',
    'Develops software applications.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Software Development Department';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Software Development Department'),
    FALSE,
    TRUE,
    1,
    'Junior Software Developer',
    'New software developer with basic skills.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Software Development Department';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Software Development Department'),
    FALSE,
    TRUE,
    1,
    'Software Architect',
    'Designs and architects software systems.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Software Development Department';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Software Development Department'),
    FALSE,
    TRUE,
    1,
    'Technical Lead',
    'Leads a team of software developers.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Software Development Department';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Software Development Department'),
    FALSE,
    TRUE,
    1,
    'DevOps Engineer',
    'Develops and maintains infrastructure and automation.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Software Development Department';


INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Frontend Development Team'),
    FALSE,
    TRUE,
    1,
    'Frontend Development Team Leader',
    'Leads the Frontend Development Team.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Frontend Development Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Frontend Development Team'),
    FALSE,
    TRUE,
    1,
    'Frontend Developer',
    'Develops frontend applications and user interfaces.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Frontend Development Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Frontend Development Team'),
    FALSE,
    TRUE,
    1,
    'UI/UX Designer',
    'Designs user interfaces and user experiences.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Frontend Development Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Frontend Development Team'),
    FALSE,
    TRUE,
    1,
    'Web Developer',
    'Develops websites and web applications.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Frontend Development Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Frontend Development Team'),
    FALSE,
    TRUE,
    1,
    'JavaScript Developer',
    'Develops applications using JavaScript.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Frontend Development Team';


INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Backend Development Team'),
    FALSE,
    TRUE,
    1,
    'Backend Development Team Leader',
    'Leads the Backend Development Team.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Backend Development Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Backend Development Team'),
    FALSE,
    TRUE,
    1,
    'Backend Developer',
    'Develops backend applications and APIs.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Backend Development Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Backend Development Team'),
    FALSE,
    TRUE,
    1,
    'API Developer',
    'Develops APIs for applications.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Backend Development Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Backend Development Team'),
    FALSE,
    TRUE,
    1,
    'Database Developer',
    'Develops and manages databases.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Backend Development Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Backend Development Team'),
    FALSE,
    TRUE,
    1,
    'C# Developer',
    'Develops applications using C#.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Backend Development Team';


INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Mobile Development Team'),
    FALSE,
    TRUE,
    1,
    'Mobile Development Team Leader',
    'Leads the Mobile Development Team.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Mobile Development Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Mobile Development Team'),
    FALSE,
    TRUE,
    1,
    'Mobile Developer',
    'Develops mobile applications.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Mobile Development Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Mobile Development Team'),
    FALSE,
    TRUE,
    1,
    'Android Developer',
    'Develops applications for Android.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Mobile Development Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Mobile Development Team'),
    FALSE,
    TRUE,
    1,
    'iOS Developer',
    'Develops applications for iOS.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Mobile Development Team';


INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'QA Testing Team'),
    FALSE,
    TRUE,
    1,
    'QA Testing Team Leader',
    'Leads the QA Testing Team.',
    1
FROM "OrganizationItems" WHERE "Name" = 'QA Testing Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'QA Testing Team'),
    FALSE,
    TRUE,
    1,
    'QA Engineer',
    'Performs quality assurance and testing tasks.',
    1
FROM "OrganizationItems" WHERE "Name" = 'QA Testing Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'QA Testing Team'),
    FALSE,
    TRUE,
    1,
    'Senior QA Engineer',
    'Experienced QA Engineer with advanced skills.',
    1
FROM "OrganizationItems" WHERE "Name" = 'QA Testing Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'QA Testing Team'),
    FALSE,
    TRUE,
    1,
    'Test Automation Engineer',
    'Develops and maintains test automation frameworks.',
    1
FROM "OrganizationItems" WHERE "Name" = 'QA Testing Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'QA Testing Team'),
    FALSE,
    TRUE,
    1,
    'Performance Testing Engineer',
    'Performs performance testing and analysis.',
    1
FROM "OrganizationItems" WHERE "Name" = 'QA Testing Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'QA Testing Team'),
    FALSE,
    TRUE,
    1,
    'Security Testing Engineer',
    'Performs security testing and analysis.',
    1
FROM "OrganizationItems" WHERE "Name" = 'QA Testing Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'QA Testing Team'),
    FALSE,
    TRUE,
    1,
    'Manual Tester',
    'Performs manual testing tasks.',
    1
FROM "OrganizationItems" WHERE "Name" = 'QA Testing Team';

-- TechnoSoft: IT Infrastructure Department.

-- Insert job titles into IT Infrastructure Department
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'IT Infrastructure Department'),
    FALSE,
    TRUE,
    1,
    'Director of IT Infrastructure Department',
    'Head of IT Infrastructure Department.',
    1
FROM "OrganizationItems" WHERE "Name" = 'IT Infrastructure Department';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'IT Infrastructure Department'),
    FALSE,
    TRUE,
    1,
    'IT Infrastructure Manager',
    'Manages IT Infrastructure teams and resources.',
    1
FROM "OrganizationItems" WHERE "Name" = 'IT Infrastructure Department';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'IT Infrastructure Department'),
    FALSE,
    TRUE,
    1,
    'System Administrator',
    'Administers computer systems and networks.',
    1
FROM "OrganizationItems" WHERE "Name" = 'IT Infrastructure Department';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'IT Infrastructure Department'),
    FALSE,
    TRUE,
    1,
    'Network Administrator',
    'Administers and manages computer networks.',
    1
FROM "OrganizationItems" WHERE "Name" = 'IT Infrastructure Department';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'IT Infrastructure Department'),
    FALSE,
    TRUE,
    1,
    'Cloud Engineer',
    'Designs, implements, and manages cloud computing services.',
    1
FROM "OrganizationItems" WHERE "Name" = 'IT Infrastructure Department';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'IT Infrastructure Department'),
    FALSE,
    TRUE,
    1,
    'Security Engineer',
    'Develops and implements security measures for IT systems.',
    1
FROM "OrganizationItems" WHERE "Name" = 'IT Infrastructure Department';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'IT Infrastructure Department'),
    FALSE,
    TRUE,
    1,
    'Database Administrator',
    'Administers and manages databases.',
    1
FROM "OrganizationItems" WHERE "Name" = 'IT Infrastructure Department';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'IT Infrastructure Department'),
    FALSE,
    TRUE,
    1,
    'IT Support Specialist',
    'Provides technical support to users.',
    1
FROM "OrganizationItems" WHERE "Name" = 'IT Infrastructure Department';

-- Insert job titles into Network Administration Team
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Network Administration Team'),
    FALSE,
    TRUE,
    1,
    'Network Administration Team Leader',
    'Leads the Network Administration Team.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Network Administration Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Network Administration Team'),
    FALSE,
    TRUE,
    1,
    'Network Engineer',
    'Designs, implements, and maintains computer networks.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Network Administration Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Network Administration Team'),
    FALSE,
    TRUE,
    1,
    'Network Security Engineer',
    'Develops and implements security measures for computer networks.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Network Administration Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Network Administration Team'),
    FALSE,
    TRUE,
    1,
    'Network Analyst',
    'Analyzes and troubleshoots network issues.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Network Administration Team';

-- Insert job titles into System Administration Team
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'System Administration Team'),
    FALSE,
    TRUE,
    1,
    'System Administration Team Leader',
    'Leads the System Administration Team.',
    1
FROM "OrganizationItems" WHERE "Name" = 'System Administration Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'System Administration Team'),
    FALSE,
    TRUE,
    1,
    'System Administrator',
    'Administers computer systems and networks.',
    1
FROM "OrganizationItems" WHERE "Name" = 'System Administration Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'System Administration Team'),
    FALSE,
    TRUE,
    1,
    'Server Administrator',
    'Administers and manages servers.',
    1
FROM "OrganizationItems" WHERE "Name" = 'System Administration Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'System Administration Team'),
    FALSE,
    TRUE,
    1,
    'Linux Administrator',
    'Administers and manages Linux systems.',
    1
FROM "OrganizationItems" WHERE "Name" = 'System Administration Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'System Administration Team'),
    FALSE,
    TRUE,
    1,
    'Windows Administrator',
    'Administers and manages Windows systems.',
    1
FROM "OrganizationItems" WHERE "Name" = 'System Administration Team';

-- Insert job titles into Security Team
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Security Team'),
    FALSE,
    TRUE,
    1,
    'Security Team Leader',
    'Leads the Security Team.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Security Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Security Team'),
    FALSE,
    TRUE,
    1,
    'Security Analyst',
    'Analyzes security threats and vulnerabilities.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Security Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Security Team'),
    FALSE,
    TRUE,
    1,
    'Security Architect',
    'Designs and implements security architectures.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Security Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Security Team'),
    FALSE,
    TRUE,
    1,
    'Penetration Tester',
    'Performs penetration testing to identify vulnerabilities.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Security Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Security Team'),
    FALSE,
    TRUE,
    1,
    'Cybersecurity Analyst',
    'Analyzes cybersecurity threats and incidents.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Security Team';

-- Insert job titles into Database Administration Team
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Database Administration Team'),
    FALSE,
    TRUE,
    1,
    'Database Administration Team Leader',
    'Leads the Database Administration Team.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Database Administration Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Database Administration Team'),
    FALSE,
    TRUE,
    1,
    'Database Administrator',
    'Administers and manages databases.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Database Administration Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Database Administration Team'),
    FALSE,
    TRUE,
    1,
    'SQL Developer',
    'Develops and maintains SQL databases.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Database Administration Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Database Administration Team'),
    FALSE,
    TRUE,
    1,
    'NoSQL Developer',
    'Develops and maintains NoSQL databases.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Database Administration Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Database Administration Team'),
    FALSE,
    TRUE,
    1,
    'Data Analyst',
    'Analyzes and interprets data to identify patterns and insights.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Database Administration Team';

-- Insert job titles into Marketing and Sales Department
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Director of Marketing and Sales Department',
    'Head of Marketing and Sales Department.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Marketing and Sales Department';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Marketing and Sales Manager',
    'Manages Marketing and Sales teams and activities.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Marketing and Sales Department';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Marketing Specialist',
    'Develops and implements marketing campaigns.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Marketing and Sales Department';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Sales Representative',
    'Sells products or services to customers.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Marketing and Sales Department';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Account Manager',
    'Manages relationships with existing customers.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Marketing and Sales Department';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Marketing Manager',
    'Leads the Marketing Team.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Marketing and Sales Department';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Sales Manager',
    'Leads the Sales Team.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Marketing and Sales Department';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Digital Marketing Manager',
    'Leads the Digital Marketing Team.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Marketing and Sales Department';

-- Insert job titles into Marketing Team
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Marketing Team Leader',
    'Leads the Marketing Team.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Marketing Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Content Marketing Specialist',
    'Creates and distributes high-quality content for marketing purposes.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Marketing Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Social Media Marketing Specialist',
    'Manages social media channels and campaigns.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Marketing Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Email Marketing Specialist',
    'Develops and implements email marketing campaigns.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Marketing Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'SEO Specialist',
    'Optimizes website content for search engines.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Marketing Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'SEM Specialist',
    'Manages search engine marketing campaigns.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Marketing Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Marketing Analyst',
    'Analyzes marketing data and performance.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Marketing Team';

-- Insert job titles into Sales Team
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Sales Team Leader',
    'Leads the Sales Team.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Sales Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Sales Representative',
    'Sells products or services to customers.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Sales Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Account Executive',
    'Manages relationships with key accounts.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Sales Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Business Development Manager',
    'Identifies and develops new business opportunities.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Sales Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Sales Engineer',
    'Provides technical expertise and support to sales teams.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Sales Team';

-- Insert job titles into Content Marketing Team
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Content Marketing Team Leader',
    'Leads the Content Marketing Team.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Content Marketing Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Content Writer',
    'Creates written content for various marketing materials.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Content Marketing Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Editor',
    'Edits and proofreads written content.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Content Marketing Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Copywriter',
    'Writes persuasive and engaging marketing copy.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Content Marketing Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Content Strategist',
    'Develops and implements content strategy.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Content Marketing Team';

-- Insert job titles into Social Media Marketing Team
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Social Media Marketing Team Leader',
    'Leads the Social Media Marketing Team.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Social Media Marketing Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Social Media Manager',
    'Manages social media channels and campaigns.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Social Media Marketing Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Social Media Specialist',
    'Creates and distributes social media content.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Social Media Marketing Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Community Manager',
    'Engages with online communities and builds relationships with customers.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Social Media Marketing Team';

-- Director of Quality Assurance Department
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Director of Quality Assurance Department',
    'Director role in Quality Assurance Department',
    1
FROM "OrganizationItems" WHERE "Name" = 'Quality Assurance Department';

-- QA Manager
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'QA Manager',
    'Manager role in Quality Assurance Department',
    1
FROM "OrganizationItems" WHERE "Name" = 'Quality Assurance Department';

-- QA Lead
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'QA Lead',
    'Lead role in Quality Assurance Department',
    1
FROM "OrganizationItems" WHERE "Name" = 'Quality Assurance Department';

-- Manual Testing Team Leader
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Manual Testing Team Leader',
    'Leader role in Manual Testing Team',
    1
FROM "OrganizationItems" WHERE "Name" = 'Manual Testing Team';

-- Manual Tester
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Manual Tester',
    'Performs manual testing tasks.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Manual Testing Team';

-- Test Analyst
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Test Analyst',
    'Analyzes and creates test cases.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Manual Testing Team';

-- Automation Testing Team Leader
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Automation Testing Team Leader',
    'Leader role in Automation Testing Team',
    1
FROM "OrganizationItems" WHERE "Name" = 'Automation Testing Team';

-- Test Automation Engineer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Test Automation Engineer',
    'Develops and maintains automated test scripts.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Automation Testing Team';

-- QA Automation Specialist
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'QA Automation Specialist',
    'Specialist in QA Automation.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Automation Testing Team';

-- Performance Testing Team Leader
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Performance Testing Team Leader',
    'Leader role in Performance Testing Team',
    1
FROM "OrganizationItems" WHERE "Name" = 'Performance Testing Team';

-- Performance Testing Engineer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Performance Testing Engineer',
    'Performs performance testing tasks.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Performance Testing Team';

-- Load Testing Engineer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Load Testing Engineer',
    'Performs load testing tasks.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Performance Testing Team';

-- Security Testing Team Leader
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Security Testing Team Leader',
    'Leader role in Security Testing Team',
    1
FROM "OrganizationItems" WHERE "Name" = 'Security Testing Team';

-- Security Tester
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Security Tester',
    'Performs security testing tasks.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Security Testing Team';

-- Penetration Tester
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Penetration Tester',
    'Performs penetration testing tasks.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Security Testing Team';

-- Director of Project Management Department
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Director of Project Management Department',
    'Director role in Project Management Department',
    1
FROM "OrganizationItems" WHERE "Name" = 'Project Management Department';

-- Project Management Manager
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Project Management Manager',
    'Manager role in Project Management Department',
    1
FROM "OrganizationItems" WHERE "Name" = 'Project Management Department';

-- Project Manager
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Project Manager',
    'Manages projects from start to finish.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Project Management Department';

-- Scrum Master
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Scrum Master',
    'Facilitates Scrum processes and helps teams succeed.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Project Management Department';

-- Product Owner
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Product Owner',
    'Represents the voice of the customer and manages the product backlog.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Project Management Department';

-- Project Coordinator
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Project Coordinator',
    'Provides administrative support for projects.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Project Management Department';

-- Business Analyst
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Business Analyst',
    'Analyzes business needs and translates them into functional requirements.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Project Management Department';

-- Project Coordination Team Leader
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Project Coordination Team Leader',
    'Leader role in Project Coordination Team',
    1
FROM "OrganizationItems" WHERE "Name" = 'Project Coordination Team';

-- Project Coordinator
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Project Coordinator',
    'Provides administrative support for projects.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Project Coordination Team';

-- Project Assistant
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Project Assistant',
    'Provides general administrative support to project teams.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Project Coordination Team';

-- Project Management Team Leader
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Project Management Team Leader',
    'Leader role in Project Management Team',
    1
FROM "OrganizationItems" WHERE "Name" = 'Project Management Team';

-- Project Manager
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Project Manager',
    'Manages projects from start to finish.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Project Management Team';

-- Senior Project Manager
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Senior Project Manager',
    'Experienced Project Manager with leadership responsibilities.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Project Management Team';

-- Product Owners Team Leader
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Product Owners Team Leader',
    'Leader role in Product Owners Team',
    1
FROM "OrganizationItems" WHERE "Name" = 'Product Owners Team';

-- Product Owner
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Product Owner',
    'Represents the voice of the customer and manages the product backlog.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Product Owners Team';

-- Product Manager
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Product Manager',
    'Responsible for the strategic direction of a product.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Product Owners Team';

-- Project Planning Team Leader
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Project Planning Team Leader',
    'Leader role in Project Planning Team',
    1
FROM "OrganizationItems" WHERE "Name" = 'Project Planning Team';

-- Project Planner
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Project Planner',
    'Creates and manages project schedules and plans.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Project Planning Team';

-- Schedule Manager
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Schedule Manager',
    'Manages project schedules and timelines.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Project Planning Team';

-- Scrum Masters Team Leader
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Scrum Masters Team Leader',
    'Leader role in Scrum Masters Team',
    1
FROM "OrganizationItems" WHERE "Name" = 'Scrum Masters Team';

-- Scrum Master
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Scrum Master',
    'Facilitates Scrum processes and helps teams succeed.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Scrum Masters Team';

-- Agile Coach
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Agile Coach',
    'Provides guidance and training on Agile methodologies.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Scrum Masters Team';

-- Construction Management Team Leader
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Construction Management Team Leader',
    'Leader role in Construction Management Team',
    1
FROM "OrganizationItems" WHERE "Name" = 'Construction Management Team';

-- Construction Manager
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Construction Manager',
    'Manages construction projects.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Construction Management Team';

-- Project Engineer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Project Engineer',
    'Provides engineering expertise for construction projects.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Construction Management Team';

-- Site Supervisor
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Site Supervisor',
    'Supervises construction activities on site.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Construction Management Team';

-- Director of Research and Development Department
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Director of Research and Development Department',
    'Director role in Research and Development Department',
    1
FROM "OrganizationItems" WHERE "Name" = 'Research and Development Department';

-- R&D Manager
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'R&D Manager',
    'Manages research and development activities.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Research and Development Department';

-- Research Scientist
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Research Scientist',
    'Conducts scientific research and experiments.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Research and Development Department';

-- Data Scientist
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Data Scientist',
    'Analyzes and interprets large datasets.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Research and Development Department';

-- Machine Learning Engineer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Machine Learning Engineer',
    'Develops and implements machine learning models.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Research and Development Department';

-- AI Developer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'AI Developer',
    'Develops artificial intelligence systems and applications.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Research and Development Department';

-- Software Engineer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Software Engineer',
    'Develops and maintains software applications.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Research and Development Department';

-- Managing Director, Head of Investment Banking
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Managing Director, Head of Investment Banking',
    'Head of the Investment Banking Department',
    1
FROM "OrganizationItems" WHERE "Name" = 'Investment Banking Department';

-- Head of Equity Research
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Equity Research',
    'Head of the Equity Research Team',
    1
FROM "OrganizationItems" WHERE "Name" = 'Equity Research Team';

-- Senior Equity Analyst
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Senior Equity Analyst',
    'Experienced analyst covering specific sectors or companies.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Equity Research Team';

-- Equity Analyst
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Equity Analyst',
    'Conducts research on companies and markets.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Equity Research Team';

-- Research Associate
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Research Associate',
    'Provides support to Equity Analysts.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Equity Research Team';

-- Junior Analyst
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Junior Analyst',
    'Entry-level role in Equity Research.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Equity Research Team';

-- Head of Fixed Income
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Fixed Income',
    'Head of the Fixed Income Team',
    1
FROM "OrganizationItems" WHERE "Name" = 'Fixed Income Team';

-- Senior Fixed Income Analyst
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Senior Fixed Income Analyst',
    'Experienced analyst covering fixed income securities.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Fixed Income Team';

-- Fixed Income Analyst
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Fixed Income Analyst',
    'Conducts research and analysis on fixed income securities.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Fixed Income Team';

-- Senior Trader
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Senior Trader',
    'Experienced trader executing fixed income trades.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Fixed Income Team';

-- Trader
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Trader',
    'Executes fixed income trades.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Fixed Income Team';

-- Portfolio Manager
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Portfolio Manager',
    'Manages fixed income portfolios.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Fixed Income Team';

-- Head of Alternative Investments
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Alternative Investments',
    'Head of the Alternative Investments Team',
    1
FROM "OrganizationItems" WHERE "Name" = 'Alternative Investments Team';

-- Senior Alternative Investments Analyst
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Senior Alternative Investments Analyst',
    'Experienced analyst covering alternative investments.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Alternative Investments Team';

-- Alternative Investments Analyst
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Alternative Investments Analyst',
    'Conducts research and analysis on alternative investments.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Alternative Investments Team';

-- Hedge Fund Analyst
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Hedge Fund Analyst',
    'Analyzes hedge funds and their strategies.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Alternative Investments Team';

-- Private Equity Analyst
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Private Equity Analyst',
    'Analyzes private equity investments and strategies.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Alternative Investments Team';

-- Real Estate Analyst
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Real Estate Analyst',
    'Analyzes real estate investments and markets.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Alternative Investments Team';

-- Managing Director, Head of Asset Management
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Managing Director, Head of Asset Management',
    'Head of the Asset Management Department',
    1
FROM "OrganizationItems" WHERE "Name" = 'Asset Management Department';

-- Head of Equity Asset Management
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Equity Asset Management',
    'Head of the Equity Asset Management Team',
    1
FROM "OrganizationItems" WHERE "Name" = 'Equity Asset Management Team';

-- Senior Portfolio Manager
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Senior Portfolio Manager',
    'Experienced Portfolio Manager responsible for equity portfolios.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Equity Asset Management Team';

-- Portfolio Manager
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Portfolio Manager',
    'Manages equity portfolios.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Equity Asset Management Team';

-- Equity Analyst
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Equity Analyst',
    'Conducts research and analysis on equity investments.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Equity Asset Management Team';

-- Research Analyst
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Research Analyst',
    'Provides research support for equity portfolios.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Equity Asset Management Team';

-- Risk Analyst
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Risk Analyst',
    'Analyzes and manages risk in equity portfolios.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Equity Asset Management Team';

-- Head of Fixed Income Asset Management
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Fixed Income Asset Management',
    'Head of the Fixed Income Asset Management Team',
    1
FROM "OrganizationItems" WHERE "Name" = 'Fixed Income Asset Management Team';

-- Senior Portfolio Manager
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Senior Portfolio Manager',
    'Experienced Portfolio Manager responsible for fixed income portfolios.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Fixed Income Asset Management Team';

-- Portfolio Manager
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Portfolio Manager',
    'Manages fixed income portfolios.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Fixed Income Asset Management Team';

-- Fixed Income Analyst
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Fixed Income Analyst',
    'Conducts research and analysis on fixed income investments.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Fixed Income Asset Management Team';

-- Senior Trader
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Senior Trader',
    'Experienced trader executing fixed income trades.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Fixed Income Asset Management Team';

-- Trader
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Trader',
    'Executes fixed income trades.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Fixed Income Asset Management Team';

-- Risk Analyst
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Risk Analyst',
    'Analyzes and manages risk in fixed income portfolios.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Fixed Income Asset Management Team';

-- Head of Alternative Investments Asset Management
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Alternative Investments Asset Management',
    'Head of the Alternative Investments Asset Management Team',
    1
FROM "OrganizationItems" WHERE "Name" = 'Alternative Investments Asset Management Team';

-- Senior Portfolio Manager
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Senior Portfolio Manager',
    'Experienced Portfolio Manager responsible for alternative investments portfolios.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Alternative Investments Asset Management Team';

-- Portfolio Manager
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Portfolio Manager',
    'Manages alternative investments portfolios.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Alternative Investments Asset Management Team';

-- Alternative Investments Analyst
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Alternative Investments Analyst',
    'Conducts research and analysis on alternative investments.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Alternative Investments Asset Management Team';

-- Hedge Fund Analyst
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Hedge Fund Analyst',
    'Analyzes hedge funds and their strategies.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Alternative Investments Asset Management Team';

-- Private Equity Analyst
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Private Equity Analyst',
    'Analyzes private equity investments and strategies.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Alternative Investments Asset Management Team';

-- Real Estate Analyst
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Real Estate Analyst',
    'Analyzes real estate investments and markets.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Alternative Investments Asset Management Team';

-- Risk Analyst
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Risk Analyst',
    'Analyzes and manages risk in alternative investments portfolios.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Alternative Investments Asset Management Team';

-- Chief Risk Officer (CRO)
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Chief Risk Officer (CRO)',
    'Head of the Risk Management Department',
    1
FROM "OrganizationItems" WHERE "Name" = 'Risk Management Department';

-- Head of Market Risk Management
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Market Risk Management',
    'Head of the Market Risk Management Team',
    1
FROM "OrganizationItems" WHERE "Name" = 'Market Risk Management Team';

-- Senior Market Risk Analyst
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Senior Market Risk Analyst',
    'Experienced analyst assessing market risk.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Market Risk Management Team';

-- Market Risk Analyst
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Market Risk Analyst',
    'Analyzes market risk.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Market Risk Management Team';

-- Quantitative Analyst
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Quantitative Analyst',
    'Develops and applies quantitative models for risk management.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Market Risk Management Team';

-- Risk Manager
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Risk Manager',
    'Manages market risk.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Market Risk Management Team';

-- Head of Credit Risk Management
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Credit Risk Management',
    'Head of the Credit Risk Management Team',
    1
FROM "OrganizationItems" WHERE "Name" = 'Credit Risk Management Team';

-- Senior Credit Risk Analyst
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Senior Credit Risk Analyst',
    'Experienced analyst assessing credit risk.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Credit Risk Management Team';

-- Credit Risk Analyst
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Credit Risk Analyst',
    'Analyzes credit risk.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Credit Risk Management Team';

-- Credit Officer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Credit Officer',
    'Evaluates creditworthiness of borrowers.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Credit Risk Management Team';

-- Loan Officer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Loan Officer',
    'Processes and manages loans.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Credit Risk Management Team';

-- Risk Manager
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Risk Manager',
    'Manages credit risk.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Credit Risk Management Team';

-- Head of Operational Risk Management
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Operational Risk Management',
    'Head of the Operational Risk Management Team',
    1
FROM "OrganizationItems" WHERE "Name" = 'Operational Risk Management Team';

-- Senior Operational Risk Analyst
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Senior Operational Risk Analyst',
    'Experienced analyst assessing operational risk.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Operational Risk Management Team';

-- Operational Risk Analyst
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Operational Risk Analyst',
    'Analyzes operational risk.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Operational Risk Management Team';

-- Compliance Officer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Compliance Officer',
    'Ensures compliance with regulations and policies.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Operational Risk Management Team';

-- Internal Auditor
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Internal Auditor',
    'Conducts internal audits to assess risk and compliance.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Operational Risk Management Team';

-- Risk Manager
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Risk Manager',
    'Manages operational risk.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Operational Risk Management Team';

-- Chief Financial Officer (CFO)
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Chief Financial Officer (CFO)',
    'Head of the Financial Analysis Department',
    1
FROM "OrganizationItems" WHERE "Name" = 'Financial Analysis Department';

-- Head of Financial Reporting
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Financial Reporting',
    'Head of the Financial Reporting Team',
    1
FROM "OrganizationItems" WHERE "Name" = 'Financial Reporting Team';

-- Senior Financial Analyst
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Senior Financial Analyst',
    'Experienced analyst responsible for financial reporting.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Financial Reporting Team';

-- Financial Analyst
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Financial Analyst',
    'Analyzes financial data and prepares reports.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Financial Reporting Team';

-- Accountant
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Accountant',
    'Maintains financial records and prepares financial statements.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Financial Reporting Team';

-- Reporting Specialist
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Reporting Specialist',
    'Specializes in preparing financial reports.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Financial Reporting Team';

-- Head of Accounting
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Accounting',
    'Head of the Accounting Team',
    1
FROM "OrganizationItems" WHERE "Name" = 'Accounting Team';

-- Senior Accountant
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Senior Accountant',
    'Experienced accountant responsible for accounting tasks.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Accounting Team';

-- Accountant
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Accountant',
    'Maintains financial records and prepares financial statements.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Accounting Team';

-- Bookkeeper
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Bookkeeper',
    'Records financial transactions and maintains accounting records.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Accounting Team';

-- Financial Controller
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Financial Controller',
    'Oversees financial operations and reporting.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Accounting Team';

-- Head of Regulatory Reporting
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Regulatory Reporting',
    'Head of the Regulatory Reporting Team',
    1
FROM "OrganizationItems" WHERE "Name" = 'Regulatory Reporting Team';

-- Senior Regulatory Reporting Analyst
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Senior Regulatory Reporting Analyst',
    'Experienced analyst preparing regulatory reports.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Regulatory Reporting Team';

-- Regulatory Reporting Analyst
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Regulatory Reporting Analyst',
    'Analyzes financial data and prepares regulatory reports.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Regulatory Reporting Team';

-- Compliance Officer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Compliance Officer',
    'Ensures compliance with regulations and policies.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Regulatory Reporting Team';

-- Data Analyst
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Data Analyst',
    'Analyzes and interprets financial data for regulatory reporting.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Regulatory Reporting Team';

-- Head of Client Services
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Client Services',
    'Head of the Client Services Department',
    1
FROM "OrganizationItems" WHERE "Name" = 'Client Services Department';

-- Head of Client Relationship Management
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Client Relationship Management',
    'Head of the Client Relationship Management Team',
    1
FROM "OrganizationItems" WHERE "Name" = 'Client Relationship Management Team';

-- Senior Client Relationship Manager
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Senior Client Relationship Manager',
    'Experienced manager responsible for building and maintaining client relationships.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Client Relationship Management Team';

-- Client Relationship Manager
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Client Relationship Manager',
    'Manages and develops client relationships.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Client Relationship Management Team';

-- Account Manager
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Account Manager',
    'Manages client accounts and provides service.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Client Relationship Management Team';

-- Client Advisor
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Client Advisor',
    'Provides advice and support to clients.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Client Relationship Management Team';

-- Head of Client Onboarding
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Client Onboarding',
    'Head of the Client Onboarding Team',
    1
FROM "OrganizationItems" WHERE "Name" = 'Client Onboarding Team';

-- Senior Client Onboarding Specialist
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Senior Client Onboarding Specialist',
    'Experienced specialist responsible for onboarding new clients.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Client Onboarding Team';

-- Client Onboarding Specialist
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Client Onboarding Specialist',
    'Onboards new clients and ensures compliance with regulations.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Client Onboarding Team';

-- KYC Specialist
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'KYC Specialist',
    'Verifies client identities and conducts Know Your Customer (KYC) checks.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Client Onboarding Team';

-- AML Specialist
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'AML Specialist',
    'Ensures compliance with Anti-Money Laundering (AML) regulations.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Client Onboarding Team';

-- Head of Client Support
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Client Support',
    'Head of the Client Support Team',
    1
FROM "OrganizationItems" WHERE "Name" = 'Client Support Team';

-- Senior Client Support Specialist
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Senior Client Support Specialist',
    'Experienced specialist providing support to clients.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Client Support Team';

-- Client Support Specialist
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Client Support Specialist',
    'Provides support to clients and resolves their issues.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Client Support Team';

-- Service Desk Analyst
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Service Desk Analyst',
    'Provides first-line support to clients.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Client Support Team';

-- Technical Support Specialist
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Technical Support Specialist',
    'Provides technical support to clients.',
    1
FROM "OrganizationItems" WHERE "Name" = 'Client Support Team';

-- Construction Engineering Department

-- Chief Construction Engineer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Chief Construction Engineer',
    'Leads the Construction Engineering department, responsible for overall project delivery and engineering expertise.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Construction Engineering Department';

-- Director of Construction Engineering
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Director of Construction Engineering',
    'Manages the Construction Engineering department, oversees project budgets and timelines.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Construction Engineering Department';

-- Structural Engineering Team

-- Head of Structural Engineering
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Structural Engineering',
    'Leads the Structural Engineering team, responsible for structural design and analysis.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Structural Engineering Team';

-- Senior Structural Engineer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Senior Structural Engineer',
    'Experienced structural engineer responsible for complex design calculations and project management.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Structural Engineering Team';

-- Structural Engineer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Structural Engineer',
    'Performs structural analysis and design, creates drawings and specifications.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Structural Engineering Team';

-- Structural Designer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Structural Designer',
    'Creates detailed drawings and specifications for structural elements, collaborates with engineers.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Structural Engineering Team';

-- BIM Specialist (Structural)
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'BIM Specialist (Structural)',
    'Develops and manages structural models in BIM software, collaborates with engineers and designers.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Structural Engineering Team';

-- CAD Technician
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'CAD Technician',
    'Creates and modifies technical drawings using CAD software, assists engineers and designers.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Structural Engineering Team';

-- Civil Engineering Team

-- Head of Civil Engineering
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Civil Engineering',
    'Leads the Civil Engineering team, responsible for civil infrastructure design and project management.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Civil Engineering Team';

-- Senior Civil Engineer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Senior Civil Engineer',
    'Experienced civil engineer responsible for complex design calculations and project management.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Civil Engineering Team';

-- Civil Engineer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Civil Engineer',
    'Designs and oversees civil infrastructure projects, prepares drawings and specifications.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Civil Engineering Team';

-- Geotechnical Engineer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Geotechnical Engineer',
    'Conducts geotechnical investigations, analyzes soil conditions, provides recommendations for foundation design.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Civil Engineering Team';

-- Site Engineer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Site Engineer',
    'Oversees construction activities on site, ensures compliance with plans and specifications.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Civil Engineering Team';

-- Project Manager (Civil)
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Project Manager (Civil)',
    'Manages civil infrastructure projects, plans and coordinates activities, tracks progress and budget.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Civil Engineering Team';

-- Architectural Design Team

-- Head of Architectural Design
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Architectural Design',
    'Leads the Architectural Design team, responsible for building design and aesthetics.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Architectural Design Team';

-- Senior Architect
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Senior Architect',
    'Experienced architect responsible for leading design projects, collaborating with clients and engineers.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Architectural Design Team';

-- Architect
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Architect',
    'Designs buildings and spaces, prepares architectural drawings and specifications.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Architectural Design Team';

-- Architectural Designer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Architectural Designer',
    'Develops architectural designs, creates 3D models, prepares presentation drawings.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Architectural Design Team';

-- BIM Specialist (Architectural)
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'BIM Specialist (Architectural)',
    'Develops and manages architectural models in BIM software, collaborates with architects and engineers.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Architectural Design Team';

-- Landscape Architect
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Landscape Architect',
    'Designs outdoor spaces, gardens, and landscaping, integrates with building architecture.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Architectural Design Team';

-- Project Planning Team

-- Head of Project Planning
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Project Planning',
    'Leads the Project Planning team, responsible for project scheduling, budgeting, and resource allocation.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Project Planning Team';

-- Senior Project Planner
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Senior Project Planner',
    'Experienced project planner responsible for developing and managing complex project schedules.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Project Planning Team';

-- Project Planner
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Project Planner',
    'Develops and maintains project schedules, tracks progress, and identifies potential delays.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Project Planning Team';

-- Scheduling Specialist
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Scheduling Specialist',
    'Creates and manages project schedules using specialized software, analyzes critical path and dependencies.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Project Planning Team';

-- Cost Estimator
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Cost Estimator',
    'Develops and analyzes project budgets, identifies cost savings opportunities, and tracks expenses.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Project Planning Team';

-- Project Coordination Team

-- Head of Project Coordination
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Project Coordination',
    'Leads the Project Coordination team, responsible for communication, documentation, and project administration.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Project Coordination Team';

-- Project Coordinator
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Project Coordinator',
    'Coordinates project activities, manages communication between stakeholders, tracks progress and deadlines.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Project Coordination Team';

-- Contract Administrator
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Contract Administrator',
    'Manages project contracts, ensures compliance with terms, resolves contract disputes.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Project Coordination Team';

-- Document Controller
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Document Controller',
    'Manages project documentation, maintains records, controls access, and ensures document integrity.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Project Coordination Team';

-- Project Assistant
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Project Assistant',
    'Provides administrative support to project managers and teams, handles tasks, and coordinates communication.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Project Coordination Team';

-- Procurement Department

-- Director of Procurement
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Director of Procurement',
    'Leads the Procurement department, responsible for overall procurement strategy and supplier management.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Procurement Department';

-- Procurement Team

-- Head of Procurement
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Procurement',
    'Leads the Procurement team, responsible for sourcing, negotiating, and awarding contracts for goods and services.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Procurement Team';

-- Senior Procurement Specialist
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Senior Procurement Specialist',
    'Experienced procurement specialist responsible for complex sourcing processes, contract negotiations, and supplier management.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Procurement Team';

-- Procurement Specialist
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Procurement Specialist',
    'Conducts sourcing activities, negotiates with suppliers, manages procurement processes.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Procurement Team';

-- Buyer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Buyer',
    'Places purchase orders, negotiates pricing and terms, manages supplier relationships.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Procurement Team';

-- Sourcing Specialist
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Sourcing Specialist',
    'Identifies and evaluates potential suppliers, conducts market research, and negotiates contracts.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Procurement Team';

-- Procurement Analyst
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Procurement Analyst',
    'Analyzes procurement data, identifies cost savings opportunities, and develops strategies for supplier optimization.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Procurement Team';

-- Supply Chain Management Team

-- Head of Supply Chain Management
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Supply Chain Management',
    'Leads the Supply Chain Management team, responsible for overall supply chain efficiency and optimization.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Supply Chain Management Team';

-- Supply Chain Manager
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Supply Chain Manager',
    'Manages the flow of goods and services from suppliers to customers, ensures timely delivery and cost efficiency.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Supply Chain Management Team';

-- Logistics Coordinator
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Logistics Coordinator',
    'Coordinates the transportation and storage of goods, manages logistics operations, and ensures efficient delivery.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Supply Chain Management Team';

-- Inventory Analyst
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Inventory Analyst',
    'Analyzes inventory levels, forecasts demand, manages stock optimization, and minimizes inventory costs.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Supply Chain Management Team';

-- Supplier Relationship Manager
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Supplier Relationship Manager',
    'Manages relationships with suppliers, ensures contract compliance, resolves disputes, and builds long-term partnerships.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Supply Chain Management Team';

-- Quality Control Department

-- Director of Quality Control
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Director of Quality Control',
    'Leads the Quality Control department, responsible for ensuring product and process quality.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Quality Control Department';

-- Quality Assurance Team

-- Head of Quality Assurance
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Quality Assurance',
    'Leads the Quality Assurance team, responsible for developing and implementing quality assurance procedures.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Quality Assurance Team';

-- Senior Quality Assurance Engineer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Senior Quality Assurance Engineer',
    'Experienced QA engineer responsible for designing and conducting quality assurance tests.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Quality Assurance Team';

-- Quality Assurance Engineer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Quality Assurance Engineer',
    'Conducts quality assurance tests, analyzes results, and reports defects.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Quality Assurance Team';

-- Quality Control Inspector
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Quality Control Inspector',
    'Inspects products and processes to ensure compliance with quality standards.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Quality Assurance Team';

-- Lab Technician
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Lab Technician',
    'Performs laboratory tests on materials and products to ensure quality and compliance.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Quality Assurance Team';

-- Inspection Team

-- Head of Inspection
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Inspection',
    'Leads the Inspection team, responsible for conducting inspections and ensuring compliance.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Inspection Team';

-- Senior Inspector
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Senior Inspector',
    'Experienced inspector responsible for conducting complex inspections and leading inspection teams.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Inspection Team';

-- Inspector
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Inspector',
    'Conducts inspections to ensure compliance with standards, identifies defects, and reports findings.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Inspection Team';

-- Quality Control Supervisor
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Quality Control Supervisor',
    'Oversees quality control activities, provides guidance to inspectors, and ensures compliance with standards.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Inspection Team';

-- Site Inspector
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Site Inspector',
    'Conducts inspections on-site, verifies construction progress, and ensures compliance with specifications.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Inspection Team';

-- Safety and Environment Department

-- Director of Safety and Environment
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Director of Safety and Environment',
    'Leads the Safety and Environment department, responsible for promoting a safe and environmentally responsible workplace.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Safety and Environment Department';

-- Safety Officer Team

-- Head of Safety
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Safety',
    'Leads the Safety Officer team, responsible for implementing and enforcing safety procedures.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Safety Officer Team';

-- Safety Officer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Safety Officer',
    'Conducts safety inspections, investigates incidents, and promotes safe work practices.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Safety Officer Team';

-- Safety Supervisor
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Safety Supervisor',
    'Oversees safety procedures and training, provides guidance to safety officers, and ensures compliance.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Safety Officer Team';

-- Health and Safety Officer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Health and Safety Officer',
    'Focuses on health and safety issues, conducts risk assessments, and promotes a healthy workplace.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Safety Officer Team';

-- Fire Safety Officer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Fire Safety Officer',
    'Responsible for fire safety procedures, conducts fire drills, and ensures compliance with fire safety regulations.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Safety Officer Team';

-- Environmental Compliance Team

-- Head of Environmental Compliance
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Environmental Compliance',
    'Leads the Environmental Compliance team, responsible for ensuring compliance with environmental regulations.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Environmental Compliance Team';

-- Environmental Specialist
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Environmental Specialist',
    'Conducts environmental assessments, monitors pollution levels, and implements environmental management plans.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Environmental Compliance Team';

-- Environmental Officer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Environmental Officer',
    'Ensures compliance with environmental regulations, conducts audits, and implements environmental programs.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Environmental Compliance Team';

-- Environmental Consultant
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Environmental Consultant',
    'Provides expert advice on environmental issues, conducts assessments, and recommends solutions.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Environmental Compliance Team';

-- Environmental Engineer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Environmental Engineer',
    'Applies engineering principles to environmental issues, designs pollution control systems, and implements environmental solutions.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Environmental Compliance Team';

-- Sustainability Specialist
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Sustainability Specialist',
    'Promotes sustainable practices, conducts environmental impact assessments, and develops sustainability programs.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Environmental Compliance Team';

-- Director of Television
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Director of Television',
    'Leads the Television department, oversees all television production and programming.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Television Department';

-- Head of Television Programming
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Television Programming',
    'Responsible for developing and scheduling television programs, manages content creation.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Television Department';

-- Production Team

-- Production Manager
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Production Manager',
    'Manages the day-to-day operations of television production, oversees budgets and schedules.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Production Team';

-- Executive Producer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Executive Producer',
    'Oversees the overall creative direction of a television program, manages budgets and talent.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Production Team';

-- Producer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Producer',
    'Responsible for the overall production of a television program, manages budgets and schedules.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Production Team';

-- Line Producer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Line Producer',
    'Manages the day-to-day operations of a television shoot, oversees budgets and schedules.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Production Team';

-- Assistant Producer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Assistant Producer',
    'Provides support to the producer, handles administrative tasks, and coordinates with departments.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Production Team';

-- Scriptwriter
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Scriptwriter',
    'Writes scripts for television programs, develops characters and storylines.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Production Team';

-- Director
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Film director',
    'Directs the filming of a television program, guides actors and crew, ensures creative vision is realized.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Production Team';

-- Director of Photography
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Director of Photography',
    'Responsible for the visual style of a television program, oversees camera and lighting.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Production Team';

-- Set Designer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Set Designer',
    'Designs and creates the sets for a television program, manages props and furniture.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Production Team';

-- Art Director
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Art Director',
    'Oversees the visual style of a television program, collaborates with set designers and costume designers.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Production Team';

-- Costume Designer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Costume Designer',
    'Designs and creates costumes for actors in a television program.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Production Team';

-- Camera Crew

-- Head of Camera
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Camera',
    'Leads the Camera crew, oversees camera operation and lighting.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Camera Crew';

-- Director of Photography
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Director of Photography',
    'Responsible for the visual style of a television program, oversees camera and lighting.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Camera Crew';

-- Camera Operator
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Camera Operator',
    'Operates the camera, captures footage according to the director''s vision.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Camera Crew';

-- Gaffer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Gaffer',
    'Head electrician on set, responsible for lighting design and execution.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Camera Crew';

-- Grip
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Grip',
    'Handles camera support, rigging, and camera movement, assists with lighting.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Camera Crew';

-- Camera Assistant
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Camera Assistant',
    'Assists the camera operator, loads film or memory cards, and maintains camera equipment.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Camera Crew';

-- Lighting Technician
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Lighting Technician',
    'Sets up and operates lighting equipment, creates desired lighting effects on set.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Camera Crew';

-- Editing Team

-- Head of Editing
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Editing',
    'Leads the Editing team, oversees the post-production process, ensures consistency and quality.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Editing Team';

-- Post-Production Supervisor
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Post-Production Supervisor',
    'Manages the post-production process, coordinates with editors, sound engineers, and visual effects artists.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Editing Team';

-- Video Editor
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Video Editor',
    'Edits video footage, assembles scenes, and creates the final television program.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Editing Team';

-- Post-Production Editor
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Post-Production Editor',
    'Edits video footage, adds special effects, and prepares the final television program for broadcast.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Editing Team';

-- Colorist
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Colorist',
    'Grades and colors video footage, adjusts color balance and saturation.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Editing Team';

-- Graphic Designer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Graphic Designer',
    'Creates graphics for television programs, designs titles, logos, and visual elements.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Editing Team';

-- VFX Artist
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'VFX Artist',
    'Creates visual effects for television programs, adds special effects, and manipulates images.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Editing Team';

-- Sound Team

-- Head of Sound
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Sound',
    'Leads the Sound team, oversees sound design, recording, and mixing.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Sound Team';

-- Sound Designer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Sound Designer',
    'Creates the sound design for a television program, selects sound effects, and composes music.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Sound Team';

-- Sound Mixer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Sound Mixer',
    'Mixes sound for television programs, balances dialogue, sound effects, and music.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Sound Team';

-- Sound Editor
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Sound Editor',
    'Edits sound for television programs, cleans up audio, adds sound effects, and prepares sound for mixing.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Sound Team';

-- Foley Artist
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Foley Artist',
    'Creates sound effects for television programs, uses props and objects to simulate sounds.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Sound Team';

-- Music Composer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Music Composer',
    'Composes music for television programs, writes original scores and arranges existing music.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Sound Team';

-- Radio Department

-- Director of Radio
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Director of Radio',
    'Leads the Radio department, oversees all radio production and programming.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Radio Department';

-- Head of Radio Programming
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Radio Programming',
    'Responsible for developing and scheduling radio programs, manages content creation.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Radio Department';

-- Production Team

-- Production Manager
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Production Manager',
    'Manages the day-to-day operations of radio production, oversees budgets and schedules.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Production Team';

-- Executive Producer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Executive Producer',
    'Oversees the overall creative direction of a radio program, manages budgets and talent.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Production Team';

-- Producer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Producer',
    'Responsible for the overall production of a radio program, manages budgets and schedules.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Production Team';

-- Line Producer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Line Producer',
    'Manages the day-to-day operations of a radio show, oversees budgets and schedules.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Production Team';

-- Assistant Producer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Assistant Producer',
    'Provides support to the producer, handles administrative tasks, and coordinates with departments.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Production Team';

-- Scriptwriter
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Scriptwriter',
    'Writes scripts for radio programs, develops storylines and characters.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Production Team';

-- Voice Actor
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Voice Actor',
    'Provides voice-over for radio programs, narrates, reads commercials, and plays characters.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Production Team';

-- Audio Engineer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Audio Engineer',
    'Records and mixes audio for radio programs, operates recording equipment, and ensures sound quality.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Production Team';

-- Radio Announcer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Radio Announcer',
    'Announces programs, reads news and commercials, interacts with listeners.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Production Team';

-- On-Air Team

-- Program Director
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Program Director',
    'Oversees the programming schedule for a radio station, selects and schedules programs, manages on-air talent.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'On-Air Team';

-- Head of On-Air
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of On-Air',
    'Manages on-air talent, oversees live broadcasts, ensures program quality and consistency.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'On-Air Team';

-- Radio Host
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Radio Host',
    'Presents radio programs, interacts with listeners, plays music, and interviews guests.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'On-Air Team';

-- DJ
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'DJ',
    'Plays music on radio, mixes songs, and interacts with listeners.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'On-Air Team';

-- News Anchor
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'News Anchor',
    'Reads and presents news on radio, delivers news updates, and interviews guests.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'On-Air Team';

-- Reporter
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Reporter',
    'Gathers and reports news stories for radio, conducts interviews, and writes news scripts.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'On-Air Team';

-- Commentator
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Commentator',
    'Provides commentary and analysis on events, sports, or other topics on radio.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'On-Air Team';

-- Editing Team

-- Head of Editing
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Editing',
    'Leads the Editing team, oversees the post-production process, ensures consistency and quality.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Editing Team';

-- Post-Production Supervisor
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Post-Production Supervisor',
    'Manages the post-production process, coordinates with editors, sound engineers, and music editors.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Editing Team';

-- Audio Editor
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Audio Editor',
    'Edits audio recordings for radio programs, cleans up sound, adds effects, and prepares audio for mixing.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Editing Team';

-- Post-Production Engineer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Post-Production Engineer',
    'Manages audio equipment, processes audio, and ensures technical quality of radio programs.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Editing Team';

-- Music Editor
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Music Editor',
    'Edits music for radio programs, selects and prepares music tracks, and creates playlists.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Editing Team';

-- Sound Engineer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Sound Engineer',
    'Records and mixes audio for radio programs, operates recording equipment, and ensures sound quality.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Editing Team';

-- Sound Team

-- Head of Sound
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Sound',
    'Leads the Sound team, oversees sound design, recording, and mixing.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Sound Team';

-- Sound Designer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Sound Designer',
    'Creates the sound design for a radio program, selects sound effects, and composes music.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Sound Team';

-- Sound Mixer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Sound Mixer',
    'Mixes sound for radio programs, balances dialogue, sound effects, and music.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Sound Team';

-- Sound Engineer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Sound Engineer',
    'Records and mixes audio for radio programs, operates recording equipment, and ensures sound quality.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Sound Team';

-- Foley Artist
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Foley Artist',
    'Creates sound effects for radio programs, uses props and objects to simulate sounds.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Sound Team';

-- Music Composer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Music Composer',
    'Composes music for radio programs, writes original scores and arranges existing music.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Sound Team';

-- Director of Online Media
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Director of Online Media',
    'Leads the Online Media department, oversees all digital content creation and distribution.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Online Media Department';

-- Head of Digital Media
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Digital Media',
    'Responsible for managing digital content strategy, oversees social media and SEO efforts.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Online Media Department';

-- Content Creation Team

-- Head of Content Creation
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Content Creation',
    'Leads the Content Creation team, responsible for developing and producing high-quality digital content.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Content Creation Team';

-- Content Director
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Content Director',
    'Oversees the content strategy and production process, ensures content aligns with brand guidelines.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Content Creation Team';

-- Content Writer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Content Writer',
    'Creates engaging and informative written content for websites, blogs, and social media.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Content Creation Team';

-- Editor
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Editor',
    'Edits written content for clarity, style, and accuracy, ensures consistency with brand guidelines.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Content Creation Team';

-- Blogger
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Blogger',
    'Creates and publishes blog posts, shares insights and perspectives, and engages with readers.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Content Creation Team';

-- Photographer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Photographer',
    'Captures high-quality images for websites, blogs, and social media, ensures visuals align with brand guidelines.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Content Creation Team';

-- Videographer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Videographer',
    'Creates video content for websites, blogs, and social media, edits videos, and ensures visual quality.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Content Creation Team';

-- Content Editing Team

-- Head of Content Editing
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Content Editing',
    'Leads the Content Editing team, ensures all content is accurate, consistent, and adheres to brand guidelines.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Content Editing Team';

-- Content Editor
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Content Editor',
    'Edits written content for clarity, style, and accuracy, ensures consistency with brand guidelines.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Content Editing Team';

-- Content Editor
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Content Editor',
    'Edits written content for clarity, style, and accuracy, ensures consistency with brand guidelines.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Content Editing Team';

-- Proofreader
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Proofreader',
    'Checks written content for spelling, grammar, and punctuation errors.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Content Editing Team';

-- Copywriter
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Copywriter',
    'Creates persuasive and engaging marketing copy for websites, ads, and other materials.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Content Editing Team';

-- Graphic Designer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Graphic Designer',
    'Creates visual assets for websites, social media, and marketing materials.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Content Editing Team';

-- Web Designer
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Web Designer',
    'Designs and develops websites, ensures usability and functionality, and implements visual elements.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Content Editing Team';

-- Social Media Team

-- Head of Social Media
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Social Media',
    'Leads the Social Media team, develops and executes social media strategy, and manages online communities.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Social Media Team';

-- Social Media Manager
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Social Media Manager',
    'Manages social media accounts, creates content, engages with followers, and analyzes performance.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Social Media Team';

-- Social Media Specialist
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Social Media Specialist',
    'Creates and schedules social media content, engages with followers, and analyzes performance.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Social Media Team';

-- Community Manager
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Community Manager',
    'Engages with online communities, responds to questions, and fosters positive interactions on social media.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Social Media Team';

-- Social Media Content Creator
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Social Media Content Creator',
    'Creates engaging and visually appealing content for social media platforms.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Social Media Team';

-- SEO Team

-- Head of SEO
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of SEO',
    'Leads the SEO team, develops and implements SEO strategy, and monitors website performance.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'SEO Team';

-- SEO Manager
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'SEO Manager',
    'Manages SEO activities, researches keywords, optimizes website content, and analyzes search engine performance.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'SEO Team';

-- SEO Specialist
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'SEO Specialist',
    'Conducts keyword research, optimizes website content, builds backlinks, and analyzes SEO performance.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'SEO Team';

-- SEO Analyst
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'SEO Analyst',
    'Analyzes website traffic, keyword rankings, and SEO performance data, identifies areas for improvement.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'SEO Team';

-- Content Optimization Specialist
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Content Optimization Specialist',
    'Optimizes website content for search engines, researches keywords, and ensures content is relevant and engaging.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'SEO Team';

-- Finance and Operations Department

-- Chief Financial Officer (CFO)
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Chief Financial Officer (CFO)',
    'Leads the Finance and Operations department, oversees all financial matters and operations.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Finance and Operations Department';

-- Chief Operating Officer (COO)
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Chief Operating Officer (COO)',
    'Oversees the day-to-day operations of the organization, ensures efficiency and effectiveness.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Finance and Operations Department';

-- Finance Team

-- Head of Finance
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Finance',
    'Leads the Finance team, manages financial reporting, budgeting, and accounting.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Finance Team';

-- Finance Manager
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Finance Manager',
    'Oversees daily financial operations, prepares financial reports, and manages budgets.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Finance Team';

-- Accountant
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Accountant',
    'Maintains financial records, prepares financial statements, and ensures compliance with accounting standards.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Finance Team';

-- Financial Analyst
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Financial Analyst',
    'Analyzes financial data, prepares financial forecasts, and identifies opportunities for cost savings.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Finance Team';

-- Budget Analyst
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Budget Analyst',
    'Develops and manages budgets, tracks expenses, and identifies areas for budget optimization.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Finance Team';

-- Controller
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Controller',
    'Oversees the accounting function, ensures financial accuracy and compliance, and prepares financial reports.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Finance Team';

-- Operations Team

-- Head of Operations
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Operations',
    'Leads the Operations team, manages day-to-day operations, and ensures efficiency and effectiveness.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Operations Team';

-- Operations Manager
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Operations Manager',
    'Oversees daily operations, coordinates with departments, and ensures smooth workflow.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Operations Team';

-- Project Manager
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Project Manager',
    'Plans, manages, and executes projects, tracks progress, and ensures project goals are met.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Operations Team';

-- Operations Specialist
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Operations Specialist',
    'Provides support to operations management, handles administrative tasks, and coordinates with departments.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Operations Team';

-- Logistics Manager
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Logistics Manager',
    'Manages the flow of goods and services, oversees transportation, warehousing, and distribution.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Operations Team';

-- Facilities Manager
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Facilities Manager',
    'Manages the physical facilities of the organization, oversees maintenance, repairs, and security.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Operations Team';

-- Human Resources Team

-- Head of Human Resources
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Human Resources',
    'Leads the Human Resources team, manages recruitment, training, compensation, and employee relations.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Human Resources Team';

-- HR Manager
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'HR Manager',
    'Oversees daily HR operations, manages recruitment, training, and employee relations.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Human Resources Team';

-- HR Specialist
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'HR Specialist',
    'Provides support to HR management, handles administrative tasks, and assists with recruitment, training, and employee relations.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Human Resources Team';

-- Recruitment Specialist
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Recruitment Specialist',
    'Manages the recruitment process, posts job openings, screens candidates, and conducts interviews.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Human Resources Team';

-- Training and Development Specialist
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Training and Development Specialist',
    'Develops and delivers training programs, creates training materials, and assesses training effectiveness.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Human Resources Team';

-- Compensation and Benefits Specialist
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Compensation and Benefits Specialist',
    'Manages employee compensation, benefits, and payroll, ensures compliance with regulations.',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Human Resources Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Repair and Maintenance',
    'Head of Repair and Maintenance',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Car Repair and Maintenance Department';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Service Manager',
    'Service Manager',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Car Repair and Maintenance Department';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Mechanical Repairs',
    'Head of Mechanical Repairs',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Mechanical Repair Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Lead Mechanic',
    'Lead Mechanic',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Mechanical Repair Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Senior Mechanic',
    'Senior Mechanic',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Mechanical Repair Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Mechanic',
    'Mechanic',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Mechanical Repair Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Apprentice Mechanic',
    'Apprentice Mechanic',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Mechanical Repair Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Engine Specialist',
    'Engine Specialist',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Mechanical Repair Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Transmission Specialist',
    'Transmission Specialist',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Mechanical Repair Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Brake Specialist',
    'Brake Specialist',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Mechanical Repair Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Electrical Repairs',
    'Head of Electrical Repairs',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Electrical Repair Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Lead Electrician',
    'Lead Electrician',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Electrical Repair Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Senior Electrician',
    'Senior Electrician',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Electrical Repair Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Electrician',
    'Electrician',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Electrical Repair Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Automotive Electrical Technician',
    'Automotive Electrical Technician',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Electrical Repair Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Electronics Specialist',
    'Electronics Specialist',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Electrical Repair Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Diagnostics Specialist',
    'Diagnostics Specialist',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Diagnostics Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Diagnostics',
    'Head of Diagnostics',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Diagnostics Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Senior Diagnostics Technician',
    'Senior Diagnostics Technician',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Diagnostics Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Diagnostics Technician',
    'Diagnostics Technician',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Diagnostics Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Computer Systems Specialist',
    'Computer Systems Specialist',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Diagnostics Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Scheduled Maintenance',
    'Head of Scheduled Maintenance',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Scheduled Maintenance Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Lead Technician',
    'Lead Technician',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Scheduled Maintenance Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Senior Technician',
    'Senior Technician',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Scheduled Maintenance Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Technician',
    'Technician',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Scheduled Maintenance Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Service Advisor',
    'Service Advisor',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Scheduled Maintenance Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Maintenance Specialist',
    'Maintenance Specialist',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Scheduled Maintenance Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Preventive Maintenance',
    'Head of Preventive Maintenance',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Preventive Maintenance Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Preventive Maintenance Technician',
    'Preventive Maintenance Technician',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Preventive Maintenance Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Inspection Specialist',
    'Inspection Specialist',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Preventive Maintenance Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Parts and Accessories',
    'Head of Parts and Accessories',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Parts and Accessories Department';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Parts Manager',
    'Parts Manager',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Parts and Accessories Department';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Sales Manager',
    'Sales Manager',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Parts Sales Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Parts Sales',
    'Head of Parts Sales',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Parts Sales Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Parts Sales Representative',
    'Parts Sales Representative',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Parts Sales Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Parts Advisor',
    'Parts Advisor',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Parts Sales Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Counter Salesperson',
    'Counter Salesperson',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Parts Sales Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Inventory',
    'Head of Inventory',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Inventory Management Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Inventory Manager',
    'Inventory Manager',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Inventory Management Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Inventory Specialist',
    'Inventory Specialist',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Inventory Management Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Warehouse Manager',
    'Warehouse Manager',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Inventory Management Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Stock Controller',
    'Stock Controller',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Inventory Management Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Logistics',
    'Head of Logistics',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Logistics Department';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Logistics Manager',
    'Logistics Manager',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Logistics Department';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Transportation',
    'Head of Transportation',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Transportation Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Transportation Supervisor',
    'Transportation Supervisor',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Transportation Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Driver',
    'Driver',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Transportation Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Dispatcher',
    'Dispatcher',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Transportation Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Logistics Coordinator',
    'Logistics Coordinator',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Transportation Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Delivery',
    'Head of Delivery',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Delivery Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Delivery Supervisor',
    'Delivery Supervisor',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Delivery Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Delivery Driver',
    'Delivery Driver',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Delivery Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Delivery Assistant',
    'Delivery Assistant',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Delivery Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Delivery Coordinator',
    'Delivery Coordinator',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Delivery Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Customer Service',
    'Head of Customer Service',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Customer Service Department';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Customer Service Manager',
    'Customer Service Manager',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Customer Service Department';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Customer Support Supervisor',
    'Customer Support Supervisor',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Customer Support Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Customer Support',
    'Head of Customer Support',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Customer Support Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Customer Service Representative',
    'Customer Service Representative',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Customer Support Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Service Advisor',
    'Service Advisor',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Customer Support Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Complaint Handler',
    'Complaint Handler',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Customer Support Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Service Scheduler',
    'Service Scheduler',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Service Scheduling Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Head of Service Scheduling',
    'Head of Service Scheduling',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Service Scheduling Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Appointment Coordinator',
    'Appointment Coordinator',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Service Scheduling Team';

INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "Name", "Description", "BusinessEntityStatus", "DateCreated", "Uid") 
SELECT 
    "Id",
    FALSE,
    TRUE,
    1,
    'Scheduling Specialist',
    'Scheduling Specialist',
    1,
    NOW(),
    uuid_generate_v4()
FROM "OrganizationItems" WHERE "Name" = 'Service Scheduling Team';
