-- Stored Procedure to Update Contact Information (email and Phone number)
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


-- Stored Procedure to retrieve contacts added in given date range
create or alter procedure SpGetContactsByDateRange
(
@StartDate date,
@EndDate date
)
as
begin
--Join contact_Details and contact_type tables
select contact.Contact_ID,FirstName,LastName,AddressBookName,ContactType,Address,City,State,Zipcode,PhoneNumber,Email,format(Date_added,'dd-MM-yyyy')
from Contact_Details contact 
inner join Contact_Type type
on (contact.Contact_ID = type.ContactID)
where Date_Added between @StartDate and @EndDate
end
