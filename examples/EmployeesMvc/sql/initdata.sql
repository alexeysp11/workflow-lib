-- Initialize database with data.

CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

-- Organization.
insert into "Organizations" ("Name", "Description", "Uid", "DateCreated", "BusinessEntityStatus")
values ('TechnoSoft', 'A company specializing in software and information technology development', uuid_generate_v4(), now(), 1);

insert into "Organizations" ("Name", "Description", "Uid", "DateCreated", "BusinessEntityStatus")
values ('Affordable Construction', 'A construction company engaged in environmentally friendly construction', uuid_generate_v4(), now(), 1);

insert into "Organizations" ("Name", "Description", "Uid", "DateCreated", "BusinessEntityStatus")
values ('FinanceInvest', 'A financial company providing investment services', uuid_generate_v4(), now(), 1);

insert into "Organizations" ("Name", "Description", "Uid", "DateCreated", "BusinessEntityStatus")
values ('Media Group', 'A media holding that includes various media resources (TV, radio, Internet)', uuid_generate_v4(), now(), 1);

insert into "Organizations" ("Name", "Description", "Uid", "DateCreated", "BusinessEntityStatus")
values ('AutoTechCenter', 'A car service center providing a full range of car repair and maintenance services', uuid_generate_v4(), now(), 1);

-- Organization items.
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
