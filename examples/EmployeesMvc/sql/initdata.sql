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

-- TechnoSoft
INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Software Development Department', 'Responsible for developing software', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'CEO' AND "ItemType" = 1 LIMIT 1 OFFSET 0));

INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'IT Infrastructure Department', 'Responsible for managing IT infrastructure', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'CEO' AND "ItemType" = 1 LIMIT 1 OFFSET 0));

INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Marketing and Sales Department', 'Responsible for marketing and sales activities', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'CEO' AND "ItemType" = 1 LIMIT 1 OFFSET 0));

INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Quality Assurance Department', 'Responsible for testing software', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'CEO' AND "ItemType" = 1 LIMIT 1 OFFSET 0));

INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Project Management Department', 'Responsible for project management', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'CEO' AND "ItemType" = 1 LIMIT 1 OFFSET 0));

INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Research and Development Department', 'Responsible for research and development activities', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'CEO' AND "ItemType" = 1 LIMIT 1 OFFSET 0));

-- FinanceInvest
INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Investment Banking Department', 'Responsible for investment banking activities', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'CEO' AND "ItemType" = 1 LIMIT 1 OFFSET 1));

INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Asset Management Department', 'Responsible for managing assets', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'CEO' AND "ItemType" = 1 LIMIT 1 OFFSET 1));

INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId")
VALUES (uuid_generate_v4(), 'Risk Management Department', 'Responsible for managing risks', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'CEO' AND "ItemType" = 1 LIMIT 1 OFFSET 1));

INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Financial Analysis Department', 'Responsible for financial analysis', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'CEO' AND "ItemType" = 1 LIMIT 1 OFFSET 1));

INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Client Services Department', 'Responsible for client services', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'CEO' AND "ItemType" = 1 LIMIT 1 OFFSET 1));

-- Affordable Construction
INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Project Management Department', 'Responsible for project management', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Management Committee' AND "ItemType" = 0));

INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Construction Management Department', 'Responsible for construction management', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Management Committee' AND "ItemType" = 0));

INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Construction Engineering Department', 'Responsible for construction engineering', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Management Committee' AND "ItemType" = 0));

INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Design and Engineering Department', 'Responsible for design and engineering', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Management Committee' AND "ItemType" = 0));

INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Procurement Department', 'Responsible for procurement', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Management Committee' AND "ItemType" = 0));

INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Quality Control Department', 'Responsible for quality control', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Management Committee' AND "ItemType" = 0));

INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Safety and Environment Department', 'Responsible for safety and environment', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Management Committee' AND "ItemType" = 0));

-- Media Group
INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Television Department', 'Responsible for television production', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'CEO' AND "ItemType" = 1 LIMIT 1 OFFSET 2));

INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Radio Department', 'Responsible for radio production', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'CEO' AND "ItemType" = 1 LIMIT 1 OFFSET 2));

INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Online Media Department', 'Responsible for online media production', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'CEO' AND "ItemType" = 1 LIMIT 1 OFFSET 2));

INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Marketing and Sales Department', 'Responsible for marketing and sales activities', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'CEO' AND "ItemType" = 1 LIMIT 1 OFFSET 2));

INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Finance and Operations Department', 'Responsible for finance and operation', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'CEO' AND "ItemType" = 1 LIMIT 1 OFFSET 2));

-- AutoTechCenter
INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Car Repair and Maintenance Department', 'Responsible for car repair and maintenance', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Director' AND "ItemType" = 1));

INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Body Shop Department', 'Responsible for body shop services', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Director' AND "ItemType" = 1));

INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Parts and Accessories Department', 'Responsible for selling parts and accessories', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Director' AND "ItemType" = 1));

INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Logistics Department', 'Responsible for logistics operations', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Director' AND "ItemType" = 1));

INSERT INTO "OrganizationItems" ("Uid", "Name", "Description", "DateCreated", "ItemType", "IsDeleted", "HardDelete", "Address", "ParentItemId") 
VALUES (uuid_generate_v4(), 'Customer Service Department', 'Responsible for customer service', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Director' AND "ItemType" = 1));

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
    AND oi."ParentItemId" = (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'CEO' AND "ItemType" = 1 LIMIT 1 OFFSET 0);

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
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Project Management Department' AND "ParentItemId" = (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Management Committee' AND "ItemType" = 0)),
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
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Project Management Department' AND "ParentItemId" = (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Management Committee' AND "ItemType" = 0)),
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
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Project Management Department' AND "ParentItemId" = (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Management Committee' AND "ItemType" = 0)),
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
