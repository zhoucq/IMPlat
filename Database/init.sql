
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