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
VALUES (uuid_generate_v4(), 'Content Creation Department', 'Responsible for content creation', NOW(), 0, false, true, NULL, (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'CEO' AND "ItemType" = 1 LIMIT 1 OFFSET 2));

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

-- Insert teams into "Financial Reporting Department"
INSERT INTO "OrganizationItems" ("ParentItemId", "IsDeleted", "HardDelete", "ItemType", "DateCreated", "Uid", "Name", "Description", "BusinessEntityStatus")
SELECT 
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Financial Reporting Department' AND "IsDeleted" = FALSE),
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
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Financial Reporting Department' AND "IsDeleted" = FALSE),
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
    (SELECT "Id" FROM "OrganizationItems" WHERE "Name" = 'Financial Reporting Department' AND "IsDeleted" = FALSE),
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
