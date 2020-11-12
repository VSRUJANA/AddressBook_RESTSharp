create or alter procedure SpUpdateContactInfo
(
@FirstName varchar(25),
@LastName varchar(25),
@PhoneNo varchar(12),
@Email varchar(25)
)
as
begin
Update Contact set PhoneNumber = @PhoneNo, Email=@Email
where FirstName = @FirstName and LastName = @LastName
end