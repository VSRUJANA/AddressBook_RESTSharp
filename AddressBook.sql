-- Create a database
create database Address_Book_Service;
-- View database name
use Address_Book_Service;
select DB_NAME() 

-- Create table in the database
create table Address_Book
(
FirstName varchar(25) not null,
LastName varchar(25) not null,
Address varchar(60) not null,
City varchar(15) not null,
State varchar(15) not null,
Zipcode varchar(6) not null,
PhoneNumber varchar(12) not null,
Email varchar(25) not null
);

-- Display table details
select * from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = 'Address_Book';
-- Inserting data in table
insert into Address_Book values
('Tony','Stark','Stark Tower, 59th Street, Broadway','Manhattan','NewYork','100001','8987224534','ironman@gmail.com'),
('Steve','Rogers','Times Square','Brooklyn','Texas','11224','9876778434','captainAmerica@yahoo.com'),
('Bruce','Banner','Vandalia','Greater Dayton','Florida','45441','1403425611','incredibleHulk@gmail.com'),
('Peter','Parker','20 Ingram Street, Forest Hills, Queens','NewYork City','NewYork','10023','4013224355','spiderman@gmail.com'),
('Stephen','Strange','177A Bleecker Street, Greenwich Village','Manhattan','NewYork','10431','6300964579','drStrange@yahoo.com'),
('Thor','Odinson','RoyalPalace','Asgard','Florida','224','7849876734','thor@rediffmail.com'),
('Natasha','Romanoff','Broadway street','NewYork City','NewYork','10028','45667365277','blackwidow@gmail.com'),
('Pepper','Potts','Stark Tower, 59th Street, Broadway','Manhattan','NewYork','100001','8987224534','pepper@gmail.com'),
('Edwin','Jarvis','Avengers Mansion, 890 Fifth Avenue', 'Manhattan', 'Texas','112','67676886','jarvis@gmail.com'),
('Howard','Stark','Richford','Manhattan','NewYork','100001','9876543256','stark@yahoo.com');
-- View AddressBook table
select* from Address_Book;

-- Edit existing contact using persons's name
update Address_Book
set PhoneNumber = '7654567885',Zipcode='534260' where FirstName = 'Bruce';
select* from Address_Book;

-- Delete contact using person's name
delete Address_Book
where FirstName = 'Howard';
select* from Address_Book;

-- Retrieve contacts belonging to City or state from Address_Book
select * from Address_Book
where City = 'NewYork City' or State = 'Florida';

-- Count contacts by City in Address_Book  
select City,count(City) from Address_Book group by City;
-- Count contacts by State in Address_Book  
select State,count(State) from Address_Book group by State;

-- Sort contacts by first name for a given city
select * from Address_Book
where City = 'Manhattan'
order by FirstName asc;

-- Add addressbook name and type columns
alter table address_book add addressbook_name varchar(20), type varchar(20);
-- update records for newly added columns
update address_book set addressbook_name = 'Home',type = 'Family' where FirstName = 'Tony' or FirstName = 'Pepper' or FirstName = 'Edwin';
update address_book set addressbook_name = 'Home',type = 'Friends' where FirstName = 'Steve' or FirstName = 'Bruce' or  FirstName = 'Peter' or FirstName = 'Thor';
update address_book set addressbook_name = 'Office',type = 'Profession' where FirstName = 'Stephen' or FirstName = 'Natasha';

-- Count contacts by type
select type, COUNT(FirstName) from address_book group by type;

-- Add a contact to both Friend and Family type
Insert into address_book values
('Peter','Parker','20 Ingram Street, Forest Hills, Queens','NewYork City','NewYork','10023','4013224355','spiderman@gmail.com','Home','Family');
select * from address_book;

-- UC-12 Implementation of ER Diagram
--Create table Contact_Details
create table Contact_Details
(
Contact_ID int identity(1,1) not null,
FirstName varchar(25) not null,
LastName varchar(25) not null,
Address varchar(60) not null,
City varchar(15) not null,
State varchar(15) not null,
Zipcode varchar(6) not null,
PhoneNumber varchar(12) not null,
Email varchar(25) not null
);

-- Inserting data in table
insert into Contact_Details values
('Tony','Stark','Stark Tower','Manhattan','NewYork','10001','8987224534','ironman@gmail.com'),
('Steve','Rogers','Times Square','Brooklyn','Texas','11224','9876778434','captainAmerica@yahoo.com'),
('Bruce','Banner','Vandalia','Greater Dayton','Florida','45441','9403425611','incredibleHulk@gmail.com'),
('Peter','Parker','Queens','NewYork City','NewYork','10023','7713224355','spiderman@gmail.com'),
('Stephen','Strange','Bleecker Street','Manhattan','NewYork','10431','6300964579','drStrange@yahoo.com'),
('Thor','Odinson','RoyalPalace','Asgard','Florida','22400','7849876734','thor@rediffmail.com'),
('Natasha','Romanoff','Broadway street','NewYork City','NewYork','10028','8667365277','blackwidow@gmail.com'),
('Pepper','Potts','Stark Tower','Manhattan','NewYork','10001','8987224534','pepper@gmail.com'),
('Edwin','Jarvis','Avengers Mansion', 'Manhattan', 'Texas','11224','6700676886','jarvis@gmail.com');
select * from Contact_Details;

-- Create table Contact_Type
create table Contact_Type
(
ContactID int not null,
AddressBookName varchar(20) not null,
ContactType varchar(20) not null
);

-- Inserting data in table
insert into Contact_Type values
(1,'Home','Family'),
(2,'Home','Friends'),
(3,'Home','Friends'),
(4,'Home','Friends'),
(5,'Office','Profession'),
(6,'Home','Friends'),
(7,'Office','Profession'),
(8,'Home','Family'),
(9,'Home','Family')
--View Contact_type
select * from Contact_Type

--Join contact_Details and contact_type tables
select contact.Contact_ID,FirstName,LastName,AddressBookName,ContactType,Address,City,State,Zipcode,PhoneNumber,Email,format(Date_added,'dd-MM-yyyy')
from Contact_Details contact 
inner join Contact_Type type
on (contact.Contact_ID = type.ContactID);

-- UC-13 Ensure retrieve queries in UC 6, UC 7, UC 8 and UC 10 are working with new table structure
-- Retrieve contacts belonging to City or state from Address_Book
select * from Address_Book
where City = 'NewYork City' or State = 'Florida';

-- Count contacts by City in Address_Book  
select City,count(City) from Address_Book group by City;
-- Count contacts by State in Address_Book  
select State,count(State) from Address_Book group by State;

-- Sort contacts by first name for a given city
select * from Address_Book
where City = 'Manhattan'
order by FirstName asc;

-- Count contacts by type
select ContactType, COUNT(ContactID) from Contact_Type group by ContactType;

Alter table Contact_Details add Date_Added Date
Update Contact_Details set Date_Added = '2020-10-03' where Contact_ID=1 or Contact_ID=3 or Contact_ID=8
Update Contact_Details set Date_Added = '2019-08-28' where Contact_ID=2 or Contact_ID=7
Update Contact_Details set Date_Added = '2017-04-05' where Contact_ID=4 or Contact_ID=6
Update Contact_Details set Date_Added = '2018-12-07' where Contact_ID=5 or Contact_ID=9

