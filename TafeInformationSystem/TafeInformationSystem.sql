-- ===========================================================================
--		This script creates the Tafe Information System Database
--		Author:	Ivan Karyakin
--		Date:		20/09/2021
--		Version:	1.0
-- ===========================================================================

USE master;
GO

IF EXISTS ( SELECT name
				FROM master.dbo.sysdatabases
				WHERE name = N'TafeInformationSystem_IvanKaryakin'
		  )
ALTER DATABASE TafeInformationSystem_IvanKaryakin SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
DROP DATABASE TafeInformationSystem_IvanKaryakin;
GO

CREATE DATABASE TafeInformationSystem_IvanKaryakin;
GO

USE TafeInformationSystem_IvanKaryakin;
GO

CREATE TABLE Teacher (
	TeacherID			INT IDENTITY,
	FirstName			NVARCHAR(20) NOT NULL,
	LastName			NVARCHAR(40) NOT NULL,
	DOB					DATE NOT NULL,
	Email				VARCHAR(30),
	MobilePhone			VARCHAR (10) NOT NULL,
	HomePhone			VARCHAR (10),
	GenderID			INT NOT NULL,
	TeacherAddressID	INT NOT NULL,
	CONSTRAINT PK_Teacher PRIMARY KEY(TeacherID)
);
GO

CREATE TABLE Student (
	StudentID			INT IDENTITY,
	FirstName			NVARCHAR(20) NOT NULL,
	LastName			NVARCHAR(40) NOT NULL,
	DOB					DATE NOT NULL,
	Email				VARCHAR(30),
	MobilePhone			VARCHAR (10) NOT NULL,
	HomePhone			VARCHAR (10),
	GenderID			INT NOT NULL,
	StudentAddressID	INT NOT NULL,
	CONSTRAINT PK_Student PRIMARY KEY(StudentID)
);
GO

CREATE TABLE TeacherLogin (
	TeacherID			INT,
	[Password]			NVARCHAR(80)
	CONSTRAINT PK_TeacherLogin PRIMARY KEY (TeacherID)
);
GO

CREATE TABLE StudentLogin (
	StudentID			INT,
	[Password]			NVARCHAR(80)
	CONSTRAINT PK_StudentLogin PRIMARY KEY (StudentID)
);
GO

CREATE TABLE Staff (
	StaffID				INT IDENTITY,
	FirstName			NVARCHAR(20) NOT NULL,
	LastName			NVARCHAR(40) NOT NULL,
	DOB					DATE NOT NULL,
	Email				VARCHAR(30),
	MobilePhone			VARCHAR (10) NOT NULL,
	HomePhone			VARCHAR (10),
	GenderID			INT NOT NULL,
	StaffAddressID		INT NOT NULL,
	CONSTRAINT PK_Staff PRIMARY KEY(StaffID)
);
GO

CREATE TABLE Course (
	CourseID			INT IDENTITY(1001,1),
	[Name]				VARCHAR(80) UNIQUE NOT NULL,
	[Description]		VARCHAR(240) NOT NULL,
	CONSTRAINT PK_Course PRIMARY KEY(CourseID)
);
GO

CREATE TABLE Semester (
	SemesterID			INT IDENTITY NOT NULL,
	SemesterName		NVARCHAR(6),
	StartDate			DATE UNIQUE NOT NULL,
	EndDate				DATE UNIQUE NOT NULL,
	CONSTRAINT PK_Semester PRIMARY KEY(SemesterID)
);
GO

CREATE TABLE Unit (
	UnitID				INT IDENTITY(1001, 1),
	[Name]				VARCHAR(80) UNIQUE NOT NULL,
	[Description]		VARCHAR(240) NOT NULL,
	PointValue			INT NOT NULL,
	Price				SMALLMONEY NOT NULL
	CONSTRAINT PK_Unit PRIMARY KEY(UnitID)
);
GO

CREATE TABLE College (
	CollegeID				INT IDENTITY (101,1),
	[Name]					VARCHAR(80) UNIQUE NOT NULL,	
	Phone					VARCHAR(10) NOT NULL,
	AddressID				INT NOT NULL,
	CONSTRAINT PK_College PRIMARY KEY(CollegeID)
);

CREATE TABLE CollegeAddress (
	CollegeAddressID		INT IDENTITY,
	StreetAddress			NVARCHAR(50) NOT NULL,
	Postcode				INT NOT NULL,
	City					NVARCHAR(30) NOT NULL,
	State					NVARCHAR(30) NOT NULL
	CONSTRAINT PK_CollegeAddress PRIMARY KEY(CollegeAddressID)
);
GO

CREATE TABLE Enrolment (
	EnrolmentID				INT IDENTITY,
	CCSID					INT NOT NULL,
	StudentID				INT NOT NULL,
	PaymentID				INT NOT NULL,
	EnrolStatus				BIT NOT NULL
	CONSTRAINT PK_Enrolment PRIMARY KEY(EnrolmentID)
);
GO

CREATE TABLE CourseCollegeSemester (
	CCSID					INT IDENTITY,
	CourseID				INT NOT NULL,
	CollegeID				INT NOT NULL,
	SemesterID				INT NOT NULL
	CONSTRAINT PK_SemesterCourse PRIMARY KEY (CCSID)
);
GO

CREATE TABLE TeacherCourse (
	TeacherID				INT,
	CCSID					INT
	CONSTRAINT PK_TeacherCourse PRIMARY KEY (TeacherID, CCSID)
);
GO

CREATE TABLE UnitCourse (
	CourseID				INT,
	UnitID					INT
	CONSTRAINT PK_UnitCourse PRIMARY KEY (courseID, unitID)
);
GO

CREATE TABLE PaymentSystem (
	PaymentID				INT IDENTITY,
	CreationDate			DATETIME NOT NULL,
	PaymentReceived			MONEY NOT NULL,
	CONSTRAINT PK_Payment PRIMARY KEY(PaymentID)
);
GO


CREATE TABLE Gender (
	GenderID				INT IDENTITY,
	Gender					NVARCHAR(7),
	CONSTRAINT PK_Gender PRIMARY KEY(GenderID),
);
GO

CREATE TABLE StudentAddress (
	StudentAddressID		INT IDENTITY,
	StreetAddress			NVARCHAR(50) NOT NULL,
	AptNumber				NVARCHAR(4),
	Postcode				INT NOT NULL,
	City					NVARCHAR(30) NOT NULL,
	[State]					NVARCHAR(30) NOT NULL,
	CONSTRAINT PK_StudentAddress PRIMARY KEY(StudentAddressID)
);
GO

CREATE TABLE TeacherAddress (
	TeacherAddressID		INT IDENTITY,
	StreetAddress			NVARCHAR(50) NOT NULL,
	AptNumber				NVARCHAR(4),
	Postcode				INT NOT NULL,
	City					NVARCHAR(30) NOT NULL,
	[State]					NVARCHAR(30) NOT NULL,
	CONSTRAINT PK_TeacherAddress PRIMARY KEY(TeacherAddressID)
);
GO

CREATE TABLE StaffAddress (
	StaffAddressID			INT IDENTITY,
	StreetAddress			NVARCHAR(50) NOT NULL,
	AptNumber				NVARCHAR(4),
	Postcode				INT NOT NULL,
	City					NVARCHAR(30) NOT NULL,
	State					NVARCHAR(30) NOT NULL,
	Country					NVARCHAR(30) NOT NULL,
	CONSTRAINT PK_StaffAddress PRIMARY KEY(StaffAddressID)
);
GO


-- Create constraints for Teacher table
ALTER TABLE Teacher ADD CONSTRAINT FK_TeacherAddressID FOREIGN KEY 
(TeacherAddressID) REFERENCES TeacherAddress(TeacherAddressID)
GO

ALTER TABLE Teacher ADD CONSTRAINT FK_TeacherGender FOREIGN KEY
(GenderID) REFERENCES Gender(GenderID)
GO
ALTER TABLE Teacher ADD CONSTRAINT DF_TeacherGender DEFAULT 1 FOR GenderID;
GO

-- Create constraints for Student table
ALTER TABLE Student ADD CONSTRAINT FK_StudentAddressID FOREIGN KEY 
(StudentAddressID) REFERENCES StudentAddress(StudentAddressID)
GO

ALTER TABLE Student ADD CONSTRAINT FK_StudentGender FOREIGN KEY
(GenderID) REFERENCES Gender(GenderID)
GO

ALTER TABLE Student ADD CONSTRAINT DF_StudentGender DEFAULT 1 FOR GenderID;
GO

-- Create constraints for TeacherLogin table
ALTER TABLE TeacherLogin ADD CONSTRAINT FK_TeacherID FOREIGN KEY
(TeacherID) REFERENCES Teacher(TeacherID)
GO
ALTER TABLE TeacherLogin ADD CONSTRAINT DF_TeacherPassword 
DEFAULT 'QL0AFWMIX8NRZTKeof9cXsvbvu8=' FOR [Password]

-- Create constraints for StudentLogin table
ALTER TABLE StudentLogin ADD CONSTRAINT FK_StudentID FOREIGN KEY
(StudentID) REFERENCES Student(StudentID)
GO
ALTER TABLE StudentLogin ADD CONSTRAINT DF_StudentPassword 
DEFAULT 'QL0AFWMIX8NRZTKeof9cXsvbvu8=' FOR [Password]

-- Create constraints for Staff table
ALTER TABLE Staff ADD CONSTRAINT FK_StaffAddressID FOREIGN KEY 
(StaffAddressID) REFERENCES StaffAddress(StaffAddressID)
GO

ALTER TABLE Staff ADD CONSTRAINT FK_StaffGender FOREIGN KEY
(GenderID) REFERENCES Gender(GenderID)
GO

ALTER TABLE Staff ADD CONSTRAINT DF_StaffGender DEFAULT 1 FOR GenderID;
GO

-- Create constraints/indecies for College table
ALTER TABLE College ADD CONSTRAINT FK_CollegeAddress FOREIGN KEY 
(AddressID) REFERENCES CollegeAddress(CollegeAddressID)
GO

CREATE INDEX UX_CollegeName
ON College ([Name]); 

-- Create constraints for Semeter table
ALTER TABLE Semester ADD CONSTRAINT CHK_StartDate CHECK (StartDate > GETDATE())
GO
 
ALTER TABLE Semester ADD CONSTRAINT CHK_EndDate CHECK (EndDate > StartDate)
GO

ALTER TABLE Semester ADD CONSTRAINT UK_StartDate UNIQUE (SemesterName)
GO

CREATE INDEX UX_SemesterName
ON Semester(SemesterName); 

-- Create constraints for Gender table
ALTER TABLE Gender ADD CONSTRAINT CHK_GenderID CHECK (GenderID < 4)

-- Create constraints for SemesterCourse table
ALTER TABLE CourseCollegeSemester ADD CONSTRAINT FK_CourseCollegeSemesterCourse FOREIGN KEY
(CourseID) REFERENCES Course (CourseID)
GO

ALTER TABLE CourseCollegeSemester ADD CONSTRAINT FK_CourseCollegeSemesterSemester FOREIGN KEY
(SemesterID) REFERENCES Semester (SemesterID)
GO

ALTER TABLE CourseCollegeSemester ADD CONSTRAINT FK_CourseCollegeSemesterCollege FOREIGN KEY
(CollegeID) REFERENCES College (CollegeID)
GO

CREATE UNIQUE NONCLUSTERED INDEX UX_CourseCollegeSemester ON CourseCollegeSemester (CourseID,SemesterID, CollegeID)

-- Create constraints for TeacherCourseCollege table
ALTER TABLE TeacherCourse ADD CONSTRAINT FK_TeacherCourseCourse FOREIGN KEY
(CCSID) REFERENCES CourseCollegeSemester (CCSID)
GO

ALTER TABLE TeacherCourse ADD CONSTRAINT FK_TeacherCourseTeacher FOREIGN KEY
(TeacherID) REFERENCES Teacher (TeacherID)
GO

-- Create constraints for UnitCourse table
ALTER TABLE UnitCourse ADD CONSTRAINT FK_UnitCourseCourse FOREIGN KEY
(CourseID) REFERENCES Course (CourseID)
GO

ALTER TABLE UnitCourse ADD CONSTRAINT FK_UnitCourseUnit FOREIGN KEY
(UnitID) REFERENCES Unit (UnitID)
GO

-- Create constraints for Enrolment table
ALTER TABLE Enrolment ADD CONSTRAINT FK_EnrolmentStudent FOREIGN KEY
(StudentID) REFERENCES Student (StudentID)
GO

ALTER TABLE Enrolment ADD CONSTRAINT FK_EnrolmentCCS FOREIGN KEY
(CCSID) REFERENCES CourseCollegeSemester (CCSID)
GO

ALTER TABLE Enrolment ADD CONSTRAINT FK_StudentEnrolmentPayment FOREIGN KEY
(PaymentID) REFERENCES PaymentSystem (PaymentID)
GO

ALTER TABLE Enrolment ADD CONSTRAINT DF_EnrolmentStatus 
DEFAULT 0 FOR [EnrolStatus]
GO

CREATE INDEX UX_EnrolmentStudentID
ON Enrolment (StudentID); 

-- Create constraints for Payment table
ALTER TABLE PaymentSystem ADD CONSTRAINT DF_PaymentCreationDate DEFAULT (getdate()) FOR CreationDate
GO
ALTER TABLE PaymentSystem ADD CONSTRAINT DF_PaymentReceived DEFAULT (0.00) FOR PaymentReceived
GO


-- ===========================================================================
--					INSERT DATA
-- ===========================================================================

-- Inserting Values for Tafe College and CollegeAddress
INSERT INTO CollegeAddress VALUES ('136 William Street', 2142, 'Sydney', 'NSW')
INSERT INTO College VALUES ('TAFE Granville', '61131601', 1)
GO
INSERT INTO CollegeAddress VALUES ('27 Crystal Street', 2049, 'Sydney', 'NSW')
INSERT INTO College VALUES ('TAFE Petersham', '61131601', 2)
GO
INSERT INTO CollegeAddress VALUES ('Cnr of Darley Road & King Street', 2031, 'Sydney', 'NSW')
INSERT INTO College VALUES ('TAFE Randwick', '1300360601', 3)
GO
INSERT INTO CollegeAddress VALUES ('651-731 Harris Street', 2007, 'Sydney', 'NSW')
INSERT INTO College VALUES ('TAFE Unltimo', '61131601', 4)


-- Insert Gender options
INSERT INTO Gender VALUES ('Not Say');
INSERT INTO Gender VALUES ('Male');
INSERT INTO Gender VALUES ('Female');
GO


-- Insert 3 Semeter times
--INSERT INTO Semester VALUES (CONVERT(datetime,'2022-01-28'), CONVERT(datetime,'2022-02-28'), CONVERT(datetime,'2022-06-28'));
INSERT INTO Semester VALUES ('2022-2', CONVERT(datetime,'2022-07-28'), CONVERT(datetime,'2022-11-28'));
INSERT INTO Semester VALUES ('2023-1', CONVERT(datetime,'2023-01-28'), CONVERT(datetime,'2023-06-23'));
INSERT INTO Semester VALUES ('2023-2', CONVERT(datetime,'2023-07-28'), CONVERT(datetime,'2023-11-28'));
GO

--- Insert into Teacher
INSERT INTO TeacherAddress VALUES ('Raj street', '25',  2021, 'Sydney', 'NSW');
INSERT INTO TeacherAddress VALUES ('Chris street2', '12', 2021, 'Sydney', 'NSW');
INSERT INTO TeacherAddress VALUES ('Simone Street','7',2017,'Sydney', 'NSW');

INSERT INTO Teacher VALUES ('Raj', 'Batra', CONVERT(datetime,'1960-01-28'), 'raj@batra.com', 0492234123, 1111111111, 2, 1); 
INSERT INTO Teacher VALUES ('Chris', 'Medec', CONVERT(datetime,'1989-03-28'), 'chris@medec.com', 0491231223, 2222222222, 2, 2); 
INSERT INTO Teacher VALUES ('Simone', 'Jones', CONVERT(datetime,'1972-05-12'), 'simone@jones.com', 0497764464, 3333333333, 1, 3); 
GO

-- Insert into Student
INSERT INTO StudentAddress VALUES ('Ivan street', '25',  2021, 'Sydney', 'NSW');
INSERT INTO StudentAddress VALUES ('Jake street', '12', 2021, 'Sydney', 'NSW');
INSERT INTO StudentAddress VALUES ('Carla street', '1', 2021, 'Sydney', 'NSW');

INSERT INTO Student VALUES ('Ivan', 'K', CONVERT(datetime,'1988-01-21'), 'emia@gmail.com', 0492234123, 1111111111, 2, 1); 
INSERT INTO Student VALUES ('Jake', 'Strider', CONVERT(datetime,'2000-08-13'), 'hwo@me.com', 0491231223, 2222222222, 2, 2); 
INSERT INTO Student VALUES ('Carla', 'Mein', CONVERT(datetime,'2002-10-12'), 'Carla@me.com', 0491231223, 2222222222, 2, 2); 
GO

-- Insert into Payment
INSERT INTO PaymentSystem VALUES (default, 256.00);
INSERT INTO PaymentSystem VALUES (default, 1111.00);
INSERT INTO PaymentSystem VALUES (default, 0.00);

-- Insert into Enrolment
INSERT INTO Enrolment VALUES (1,1,1,1);
INSERT INTO Enrolment VALUES (2,2,2,1);
INSERT INTO Enrolment VALUES (1,3,3,0);

GO

-- Insert into Course
INSERT INTO Course VALUES ('Diploma of Advanced C#', 'A range of C#, java and SQL units');
INSERT INTO Course VALUES ('Diploma of Java', 'Java Stuff');
INSERT INTO Course VALUES ('Certificate III in Networking', 'Cert 3 Networking stuff');
GO


-- Insert into CCS
INSERT INTO CourseCollegeSemester VALUES (1001, 101, 1);
INSERT INTO CourseCollegeSemester VALUES (1001, 101, 2);
INSERT INTO CourseCollegeSemester VALUES (1001, 102, 1);
INSERT INTO CourseCollegeSemester VALUES (1001, 103, 1);
INSERT INTO CourseCollegeSemester VALUES (1002, 102, 1);
INSERT INTO CourseCollegeSemester VALUES (1002, 103, 1);
GO

-- Assign Teachers to Courses
INSERT INTO TeacherCourse VALUES (1,1);
INSERT INTO TeacherCourse VALUES (1,2);
INSERT INTO TeacherCourse VALUES (2,3);
INSERT INTO TeacherCourse VALUES (2,5);
GO

---- Insert into Unit
INSERT INTO Unit VALUES('C# - Apply intermediate programming skills in another language', 'My Description here', 3, 300.00);
INSERT INTO Unit VALUES('C# - Apply advanced programming skills in another language', 'My Description here2', 3, 300.00);
INSERT INTO Unit VALUES('C# - Apply software developments methodologies', 'My Description here3', 3, 300.00);
INSERT INTO Unit VALUES('C# - Apply testing techniques for software development', 'Testing techniques', 3, 300.00);
INSERT INTO Unit VALUES('C# - Validate an application design against specifications', 'Validation', 3, 300.00);

INSERT INTO Unit VALUES('Java - Apply intermediate object-oriented language skills', 'Intermediate OOP', 3, 300.00);
INSERT INTO Unit VALUES('Java - Debug and monitor applications', 'Debugging', 3, 300.00);
INSERT INTO Unit VALUES('Java - Apply advanced object-oriented language skills', 'Advanced OOP', 3, 300.00);
INSERT INTO Unit VALUES('Java - Deploy an application to a production environment', 'Combine everything to deploy an app', 3, 300.00);


----- Insert into UnitCourse
INSERT INTO UnitCourse VALUES(1001,1001);
INSERT INTO UnitCourse VALUES(1001,1002);
INSERT INTO UnitCourse VALUES(1001,1003);
INSERT INTO UnitCourse VALUES(1001,1004);
INSERT INTO UnitCourse VALUES(1002,1005);

--DELETE FROM UnitCourse;
--DELETE FROM Unit;
--DELETE FROM TeacherCourse;
--DELETE FROM CourseCollegeSemester;
--DELETE FROM Course;

---------- WHY DONT YOU WRITE DESCRIPTOINS, IVAN?!?!?!?!
WITH [AllCourseAssignments] AS
(SELECT ccs.CCSID
FROM CourseCollegeSemester as ccs
WHERE ccs.CollegeID IN (SELECT CollegeID
						FROM College
						WHERE [Name] LIKE '%'+ 'Granville' + '%'))
SELECT  t.TeacherID,
		t.FirstName,		
		t.LastName,
		t.DOB,
		t.Email,
		t.MobilePhone,
		t.HomePhone
FROM	Teacher as t
INNER JOIN TeacherCourse as tc ON t.TeacherID = tc.TeacherID
AND tc.CCSID IN (SELECT [AllCourseAssignments].CCSID
						FROM [AllCourseAssignments])