create proc GetEmployeeById
@ID int
as
begin
select id, name 
from Employee where id = @ID
end