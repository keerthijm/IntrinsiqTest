CREATE TABLE [dbo].[Gender]
(
	[Id] INT IDENTITY(1,1)  PRIMARY KEY,
	GenderDescription varchar(10)
);

Insert into Gender values ('Male');

Insert into Gender values ('Female');

select * from Gender

CREATE TABLE [dbo].[Nation]
(
	[Id] INT IDENTITY(1,1)  PRIMARY KEY,
	Nationality varchar(50)
);


Insert into Nation values ('United Kingdom');

Insert into Nation values ('India');
Insert into Nation values ('New Zeland');

select * from Nation


CREATE TABLE [dbo].[MainContact]
(
	[Id] INT IDENTITY(1,1)  PRIMARY KEY,
	Contact varchar(100)
);


Insert into MainContact values ('Agent');
Insert into Nation values ('Direct');



CREATE TABLE [dbo].[Student]
(
	[Id] INT IDENTITY(1,1)  PRIMARY KEY,
	Forename varchar(255) NOT NULL,
	Surname varchar(255),
	PreferredName varchar(255),
	DOB DATETIME,
	GenderId int FOREIGN KEY REFERENCES Gender(ID),
	Nationality  int FOREIGN KEY REFERENCES Nation(ID),
	MobileNumber varchar(255),
	Email varchar(320)
)



Insert into Student values ('Keerthi','Jagalur Mutt', 'Keerthi Jagalur Mutt', '02-02-1985', 1,2, '07448033171', 'keerthijm@gmail.com' );
Insert into Student values ('Priynakaa','Ankalgi', 'Priyankaa', '06-06-1991', 1,2, '07438380054', 'priyankaaankalgi@gmail.com' );


CREATE TABLE [dbo].[FamilyDetails]
(
	[Id] INT IDENTITY(1,1)  PRIMARY KEY,
	StudentID int FOREIGN KEY REFERENCES Student(ID),
	MothersName varchar(255) NULL,
	FathersName varchar(255),
	Address varchar(500),
	HomeTelephone varchar(255),
	EmergencyNumber varchar(255),
	MainContact int FOREIGN KEY REFERENCES MainContact(ID)	
)


Insert into FamilyDetails values ('Keerthi','Jagalur Mutt', 'Keerthi Jagalur Mutt', '02-02-1985', 1,2, '07448033171', 'keerthijm@gmail.com' );
Insert into FamilyDetails values ('Priynakaa','Ankalgi', 'Priyankaa', '06-06-1991', 21,2, '07438380054', 'priyankaaankalgi@gmail.com' );

CREATE TABLE [dbo].[PassportDetails]
(
	[Id] INT IDENTITY(1,1)  PRIMARY KEY,
	StudentID int FOREIGN KEY REFERENCES Student(ID),
	PassportNumber varchar(255),
	PassportExpiryDate DATETIME,
	VisaNumber varchar(500),
	VisaExpiryDate DATETIME	
)

CREATE TABLE [dbo].[Gender]
(
	[Id] INT IDENTITY(1,1)  PRIMARY KEY,
	GenderDescription varchar(10)
);

Insert into Gender values ('Male');

Insert into Gender values ('Female');

select * from Gender

CREATE TABLE [dbo].[Nation]
(
	[Id] INT IDENTITY(1,1)  PRIMARY KEY,
	Nationality varchar(50)
);


Insert into Nation values ('United Kingdom');

Insert into Nation values ('India');
Insert into Nation values ('New Zeland');

select * from Nation


CREATE TABLE [dbo].[MainContact]
(
	[Id] INT IDENTITY(1,1)  PRIMARY KEY,
	Contact varchar(100)
);


Insert into MainContact values ('Agent');
Insert into Nation values ('Direct');



CREATE TABLE [dbo].[Student]
(
	[Id] INT IDENTITY(1,1)  PRIMARY KEY,
	Forename varchar(255) NOT NULL,
	Surname varchar(255),
	PreferredName varchar(255),
	DOB DATETIME,
	GenderId int FOREIGN KEY REFERENCES Gender(ID),
	Nationality  int FOREIGN KEY REFERENCES Nation(ID),
	MobileNumber varchar(255),
	Email varchar(320)
)



Insert into Student values ('Keerthi','Jagalur Mutt', 'Keerthi Jagalur Mutt', '02-02-1985', 1,2, '07448033171', 'keerthijm@gmail.com' );
Insert into Student values ('Priynakaa','Ankalgi', 'Priyankaa', '06-06-1991', 1,2, '07438380054', 'priyankaaankalgi@gmail.com' );


CREATE TABLE [dbo].[FamilyDetails]
(
	[Id] INT IDENTITY(1,1)  PRIMARY KEY,
	StudentID int FOREIGN KEY REFERENCES Student(ID),
	MothersName varchar(255) NULL,
	FathersName varchar(255),
	Address varchar(500),
	HomeTelephone varchar(255),
	EmergencyNumber varchar(255),
	MainContact int FOREIGN KEY REFERENCES MainContact(ID)	
)


Insert into FamilyDetails values ('Keerthi','Jagalur Mutt', 'Keerthi Jagalur Mutt', '02-02-1985', 1,2, '07448033171', 'keerthijm@gmail.com' );
Insert into FamilyDetails values ('Priynakaa','Ankalgi', 'Priyankaa', '06-06-1991', 21,2, '07438380054', 'priyankaaankalgi@gmail.com' );

CREATE TABLE [dbo].[PassportDetails]
(
	[Id] INT IDENTITY(1,1)  PRIMARY KEY,
	StudentID int FOREIGN KEY REFERENCES Student(ID),
	PassportNumber varchar(255),
	PassportExpiryDate DATETIME,
	VisaNumber varchar(500),
	VisaExpiryDate DATETIME	
)


Create Procedure AddStudentFamilyInformation
(
	@StudentID int,
	@MothersName varchar(255),
	@FathersName varchar(255),
	@Address varchar(500),
	@HomeTelephone varchar(255),
	@EmergencyNumber varchar(255),
	@MainContact int	
) 
As
 Begin
   Insert into FamilyDetails (StudentID, MothersName , FathersName, Address, HomeTelephone, EmergencyNumber, MainContact)  
   Values(@StudentID, @MothersName,@FathersName,@Address,@HomeTelephone,@EmergencyNumber,@MainContact) 
 End

 Create Procedure AddStudentInformation
(
 	@Forename varchar(255) ,
	@Surname varchar(255),
	@PreferredName varchar(255),
	@DOB DATETIME,
	@GenderId int,
	@Nationality  int,
	@MobileNumber varchar(255),
	@Email varchar(320)
) 
As
 Begin
   Insert into Student (Forename, Surname, PreferredName, DOB, GenderId, Nationality, MobileNumber, Email)  
   Values(@Forename, @Surname,@PreferredName,@DOB,@GenderId,@Nationality,@MobileNumber,@Email)
 End

  Create Procedure AddStudentPassportVisaInformation
(
	@StudentID int,
	@PassportNumber varchar(255),
	@PassportExpiryDate DATETIME,
	@VisaNumber varchar(500),
	@VisaExpiryDate DATETIME		
) 
As
 Begin
   Insert into PassportDetails (StudentID, PassportNumber , PassportExpiryDate, VisaNumber , VisaExpiryDate)  
   Values(@StudentID, @PassportNumber, @PassportExpiryDate, @VisaNumber , @VisaExpiryDate) 
 End


 Create  PROCEDURE GetStudent(
@studentid INT                   --Input parameter ,  Studentid of the student 
)
AS
BEGIN
SELECT * FROM Student Where ID = @studentid;
END

Create  PROCEDURE GetStudents
AS
BEGIN
SELECT * FROM Student;
END

Create  PROCEDURE GetMainContacts
AS
BEGIN
SELECT * FROM MainContact;
END

Create  PROCEDURE GetGenders
AS
BEGIN
SELECT * FROM Gender;
END

Create  PROCEDURE GetNation
AS
BEGIN
SELECT * FROM Nation;
END

  
Create Procedure AddStudentInformation2
(
 	@Forename varchar(255) ,
	@Surname varchar(255),
	@PreferredName varchar(255),
	@DOB DATETIME,
	@GenderId int,
	@Nationality  int,
	@MobileNumber varchar(255),
	@Email varchar(320)
) 
As
 Begin
   Insert into Student (Forename, Surname, PreferredName, DOB, GenderId, Nationality, MobileNumber, Email)  
   Values(@Forename, @Surname,@PreferredName,@DOB,@GenderId,@Nationality,@MobileNumber,@Email);

    SELECT SCOPE_IDENTITY();
 End