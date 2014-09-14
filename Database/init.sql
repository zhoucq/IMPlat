-- ***************************************************************
-- 用户相关表
--
-- ***************************************************************

-- table T_User
if exists (select * from sys.objects where name = 'T_User' and type = 'u')
    drop table T_User
go

create table T_User
(
Id varchar(50) not null primary key default newid(),
Name nvarchar(256) not null unique,
Password varchar(50),
DisplayName nvarchar(256),
Active bit not null default(0),
Deleted bit not null default(0),
CreateDate datetime not null
)
go

-- table T_Role
if exists (select * from sys.objects where name = 'T_Role' and type = 'u')
    drop table T_role
go

create table T_Role
(
Id varchar(50) not null primary key default newid(),
Name nvarchar(256) not null,
SystemName nvarchar(256) not null unique,
IsSystemRole bit not null,
DisplayOrder int default 0
)
go

-- table T_User_Role_Mapping
if exists (select * from sys.objects where name = 'T_User_Role_Mapping' and type = 'u')
    drop table T_User_Role_Mapping
go

create table T_User_Role_Mapping
(
UserId varchar(50) not null,
RoleId varchar(50) not null,
primary key(UserId,RoleId)
)

-- table T_Permission
if exists (select * from sys.objects where name = 'T_Permission' and type = 'u')
    drop table T_Permission
go

create table T_Permission
(
Id varchar(50) not null primary key default newid(),
Name nvarchar(256) not null,
SystemName nvarchar(256) not null unique,
DisplayOrder int default 0
)
go

-- table T_Role_Permission_Mapping
if exists (select * from sys.objects where name = 'T_Role_Permission_Mapping' and type = 'u')
    drop table T_Role_Permission_Mapping
go

create table T_Role_Permission_Mapping
(
RoleId varchar(50) not null,
PermissionId varchar(50) not null,
primary key(RoleId,PermissionId)
)
go

-- table T_UserGroup
if exists (select * from sys.objects where name = 'T_UserGroup' and type = 'u')
    drop table T_UserGroup
go

create table T_UserGroup
(
Id varchar(50) not null primary key default newid(),
Name nvarchar(256) not null
)
go

-- table T_User_UserGroup_Mapping
if exists (select * from sys.objects where name = 'T_User_UserGroup_Mapping' and type = 'u')
    drop table T_User_UserGroup_Mapping
go

create table T_User_UserGroup_Mapping
(
UserId varchar(50) not null,
UserGroupId varchar(50) not null,
primary key(UserId,UserGroupId)
)
go

-- ***************************************************************
-- 文件相关表
--
-- ***************************************************************

-- table T_Directory
if exists (select * from sys.objects where name = 'T_Directory' and type = 'u')
    drop table T_Directory
go

create table T_Directory
(
Id varchar(50) not null primary key default newid(),
Name nvarchar(256) not null,
OwnerId varchar(50) not null,
IsRoot bit not null,
ParentDirectoryId varchar(50),
CreateDate datetime not null default getdate(),
LastModifyDate datetime
)

-- table T_File
if exists (select * from sys.objects where name = 'T_File' and type = 'u')
    drop table T_File
go

create table T_File
(
Id varchar(50) not null primary key default newid(),
Name nvarchar(256) not null,
OwnerId varchar(50) not null,
DirectoryId varchar(50) not null,
Deleted bit not null default 0,
CreateDate datetime not null default getdate(),
LastModifyDate datetime,
)
go


-- //////////////////////////////////////////////////////////////////////////////
--  数据初始化
-- //////////////////////////////////////////////////////////////////////////////

-- role
insert into T_Role values('39B5B16E-2255-4C1B-BAA0-EEDEC7011166','系统管理员','System Admin',1,1);
insert into T_Role values('4FB13804-9433-4A64-BFF3-847D6EAF909C','文档管理员','Document Admin',1,2);
insert into T_Role values('B1C10065-9CB9-4661-BA4F-D5ACB4127884','文档发布者','Publisher',1,3);
insert into T_Role values('C1EE2BA2-973E-4488-B884-370727458A8F','用户','User',1,4);

-- doc/directory
INSERT INTO T_Directory(Id,Name,OwnerId,IsRoot,ParentDirectoryId,CreateDate,LastModifyDate) values('00000000-0000-0000-0000-000000000000','/','00000000-0000-0000-0000-000000000000',1,'',GETDATE(),NULL)