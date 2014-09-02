
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
