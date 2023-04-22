use PracticeProblem
select * from Customer
---Add new Customer data


Create PROCEDURE spAddNewCustomer
@CustomerName varchar(200),
@Address varchar(200),
@PhoneNumber nvarchar(200),
@Country varchar(200),
@Salary varchar(100),
@Pincode varchar (100)
AS
insert into Customer(CustomerName,Address,PhoneNumber,Country,Salary,Pincode)values (@CustomerName,@Address,@PhoneNumber,@Country,@Salary,@Pincode);

-- Delete employee
create PROCEDURE spDeleteCustomer
@CustomerName varchar(200),
@CustomerId int
AS
delete from Customer where CustomerName=CustomerName and CustomerId= @CustomerId;
--------update salary
create or alter  procedure [dbo].[spUpdateCustomer]
(
@CustomerName  nvarchar(200),
@Salary varchar(100)

)
as
begin
update Customer
Set Salary=@Salary
where CustomerName=@CustomerName ;
end
GO
