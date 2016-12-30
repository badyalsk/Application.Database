create table Employee(id int, name varchar(50));
go
create proc GetEmployee
as
select id, name 
from Employee


