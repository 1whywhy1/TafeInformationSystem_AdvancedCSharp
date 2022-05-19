USE TafeInformationSystem_IvanKaryakin;
GO

-- Stored Procedures --

-----------Unit-------------
-- Insert into Unit
CREATE PROCEDURE spInsert_unit
	@Name				VARCHAR(30),
	@Description		VARCHAR(240),
	@PointValue			INT,
	@Price				SMALLMONEY
AS
BEGIN
INSERT INTO Unit OUTPUT INSERTED.UnitID 
VALUES (@Name,
		@Description,
		@PointValue,
		@Price)
END
GO

-- Update Unit record by UnitID
CREATE PROCEDURE spUpdate_unit
	@UnitID				INT,
	@Name				VARCHAR(30),
	@Description		VARCHAR(240),
	@PointValue			INT,
	@Price				SMALLMONEY
AS
BEGIN
UPDATE Unit
SET Name = @Name,
	Description = @Description,
	PointValue = @PointValue,
	Price = @Price
WHERE UnitID = @UnitID
END
GO

-- Select Unit record by UnitID
CREATE PROCEDURE spSelectID_unit
	@UnitID				INT	
AS
BEGIN
	SELECT *
	FROM Unit
	WHERE UnitID = @UnitID
	RETURN
END
GO

-- Search Unit record by Name
CREATE PROCEDURE spSelectName_unit
	@Name				VARCHAR(30)	
AS
BEGIN
	SELECT *
	FROM Unit
	WHERE Name LIKE '%'+ @Name + '%'
	RETURN
END
GO

-- Search Units allowcated to a Course by CourseID
CREATE PROCEDURE spSelectAllForCourse_unit
	@CourseID				VARCHAR(30)	
AS
BEGIN
	SELECT *
	FROM Unit
	WHERE UnitID IN (SELECT UnitID
					FROM UnitCourse
					WHERE CourseID = @CourseID)
	RETURN
END
GO

-- Search Unit record not allowcated to any Course by UnitID
CREATE PROCEDURE spSelectAllNotAllowcated_unit
AS
BEGIN
	SELECT *
	FROM Unit
	WHERE NOT EXISTS(SELECT * FROM UnitCourse
					WHERE UnitCourse.UnitID = Unit.UnitID)
	RETURN
END
GO

-- Delete Unit by UnitID
CREATE PROCEDURE spDeleteUnitID_unit
	@UnitID				INT	
AS
BEGIN
	DELETE FROM Unit
	WHERE UnitID = @UnitID
END
GO

-- Select all Unit Names
CREATE PROCEDURE spSelectNames_unit
AS
BEGIN
	SELECT	UnitID,
			[Name]
	FROM Unit
END
GO

-----------Semester-------------
-- Insert into Semester
CREATE PROCEDURE spInsert_semester
	@SemesterName			VARCHAR(6),
	@StartDate			DATE,
	@EndDate			DATE
AS
BEGIN
INSERT INTO Semester
VALUES (@SemesterName,
		@StartDate,
		@EndDate)
END
GO

-- Update Semester record by SemesterID
CREATE PROCEDURE spUpdateID_semester
	@SemesterID			INT,
	@StartDate			DATE,
	@EndDate			DATE
AS
BEGIN
UPDATE Semester
SET StartDate = @StartDate,
	EndDate = @EndDate
WHERE SemesterID = @SemesterID
END
GO

-- Update Semester record by SemesterName
CREATE PROCEDURE spUpdate_semester
	@SemesterName		VARCHAR(6),
	@StartDate			DATE,
	@EndDate			DATE
AS
BEGIN
UPDATE Semester
SET StartDate = @StartDate,
	EndDate = @EndDate
WHERE SemesterName = @SemesterName
END
GO

-- Delete Semester by ID
CREATE PROCEDURE spDeleteSemesterID_semester
	@SemesterID			INT	
AS
BEGIN
	DELETE FROM Semester
	WHERE SemesterID = @SemesterID
END
GO

-- Delete Semester by Name
CREATE PROCEDURE spDeleteSemesterName_semester
	@SemesterName			VARCHAR(6)	
AS
BEGIN
	DELETE FROM Semester
	WHERE SemesterName = @SemesterName
END
GO

-- Return All available Semesters' Names
CREATE PROCEDURE spSelectAllSemesterID_semester
AS
BEGIN
	SELECT	SemesterName
	FROM	Semester
	RETURN
END
GO

--WITH 
--SELECT EXTRACT(YEAR FROM
/* need to figure out what is a good approa*/

-----------CollegeAddress-------------
--Insert into CollegeAddress
CREATE PROCEDURE spInsert_college_address
	@StreetAddress			NVARCHAR(50),
	@Postcode				INT,
	@City					NVARCHAR(30),
	@State					NVARCHAR(30)
AS
BEGIN
	INSERT CollegeAddress  OUTPUT INSERTED.CollegeAddressID 
	VALUES (@StreetAddress, @Postcode, @City, @State)
END
GO


--Detele from CollegeAddress
CREATE PROCEDURE spDeleteAddress_collegeAddress
	@CollegeAddressID			INT
AS
BEGIN
	DELETE FROM CollegeAddress
	WHERE CollegeAddressID = @CollegeAddressID
END
GO


-----------College-------------
--Insert into College
CREATE PROCEDURE spInsert_college
	@Name				VARCHAR(30),
	@Phone				VARCHAR(10),
	@AddressID			INT
AS
BEGIN
	INSERT College OUTPUT INSERTED.CollegeID
	VALUES (@Name, 
			@Phone, 
			@AddressID)
END
GO

--Delete from College
CREATE PROCEDURE spDelete_college
	@CollegeID			INT
AS
BEGIN
	DELETE FROM College
	WHERE CollegeID = @CollegeID
END
GO

--Update from College and Address
CREATE PROCEDURE spUpdate_college_collegeAddress
	@CollegeID			INT,
	@Name				VARCHAR(30),
	@Phone				VARCHAR(10),
	@StreetAddress		NVARCHAR(50),
	@Postcode			INT,
	@City				NVARCHAR(30),
	@State				NVARCHAR(30)
AS
BEGIN
UPDATE College
SET Name = @Name,
	@Phone = @Phone
WHERE CollegeID = @CollegeID
UPDATE CollegeAddress
SET StreetAddress = @StreetAddress,
	Postcode = @Postcode,
	City = @City,
	[State] = @State
WHERE CollegeAddressID IN (SELECT AddressID
							FROM College
							WHERE CollegeID = @CollegeID)
END
GO

--Retrieve all Colleges IDs and Names
CREATE PROCEDURE spSelect_all_id_names_college
AS
BEGIN
SELECT	CollegeID,
		[Name]
FROM	College
END
GO

-----------CourseCollegeSemester-------------
-- Insert into CourseCollegeSemester
CREATE PROCEDURE spInsert_CourseCollegeSemester
	@CourseID			INT,
	@CollegeID			INT,	
	@SemesterID			INT
AS
BEGIN
	INSERT CourseCollegeSemester
	VALUES (@CollegeID, 
			@CourseID,
			@SemesterID)
END
GO

-- Delete from CourseCollegeSemester by Index
CREATE PROCEDURE spDelete_CourseCollegeSemesterByIndex
	@CourseID			INT,
	@CollegeID			INT,	
	@SemesterID			INT
AS
BEGIN
	DELETE FROM CourseCollegeSemester
	WHERE CourseID = @CourseID
	AND CollegeID = @CollegeID
	AND SemesterID = @SemesterID
END
GO

-- Delete from CourseCollegeSemester by ID
CREATE PROCEDURE spDelete_CourseCollegeSemesterByID
	@CCSID			INT
AS
BEGIN
	DELETE FROM CourseCollegeSemester
	WHERE CCSID = @CCSID
END
GO


-------------------Course------------------
-- Insert into Course
CREATE PROCEDURE spInsert_course	
	@Name				VARCHAR(40),
	@Description		VARCHAR(240)
AS
BEGIN
INSERT INTO Course
VALUES (@Name,
		@Description)
END
GO

-- Update Course record by CourseID
CREATE PROCEDURE spUpdate_course
	@CourseID			INT,
	@Name				VARCHAR(40),
	@Description		VARCHAR(240)
AS
BEGIN
UPDATE	Course
SET		Name = @Name,
		Description = @Description
WHERE CourseID = @CourseID
END
GO

-- Search Delete Course by ID
CREATE PROCEDURE spDeleteCourseID_course
	@CourseID			INT	
AS
BEGIN
	DELETE FROM Course
	WHERE CourseID = @CourseID
END
GO

-- Return All available Course' IDs
CREATE PROCEDURE spSelectAllCourseIdName_course
AS
BEGIN
	SELECT	CourseID,
			[Name]
	FROM	Course
	RETURN
END
GO

-- Retrieve a Course by ID
CREATE PROCEDURE spSelectCourseByID_course
	@CourseID			INT	
AS
BEGIN
	SELECT	CourseID,
			[Name],
			[Description]
	FROM Course
	WHERE CourseID = @CourseID
	RETURN
END
GO

-- Retrieve a Course by Name
CREATE PROCEDURE spSelectCourseByName_course
	@Name			NVARCHAR	
AS
BEGIN
	SELECT	CourseID,
			[Name],
			[Description]
	FROM Course
	WHERE [Name] LIKE '%' + @Name + '%'
	RETURN
END
GO

--Retrieve all Courses not allowcated to a College
CREATE PROCEDURE spSelectAllCourseNoCollege_course
AS
BEGIN
SELECT	Course.CourseID,
		[Name],
		[Description]
FROM	Course
LEFT OUTER JOIN CourseCollegeSemester
ON Course.CourseID = CourseCollegeSemester.CourseID 
WHERE CourseCollegeSemester.CourseID IS NULL
END
GO

EXEC spSelectAllCourseNoCollege_course
GO

--Retrieve All Courses the teacher has tought in the past
CREATE PROCEDURE spSelectAllPastCourseForTeacher_course
	@TeacherID		INT
AS
BEGIN
SELECT	c.CourseID,
		c.Name
FROM	Course as c
WHERE c.CourseID IN (SELECT ccs.CourseID
					FROM CourseCollegeSemester as ccs
					WHERE CCSID IN (SELECT tc.CCSID
									FROM TeacherCourse as tc
									WHERE TeacherID = @TeacherID))
END
GO

EXEC spSelectAllPastCourseForTeacher_course 1
GO

-- Retrieve All courses and locations and semesters for a teacher

CREATE PROCEDURE spSelectAllCoursesLocationsSemesters
	@TeacherID		INT
AS
BEGIN
SELECT	c.CourseID,
		c.[Name],
		col.[Name],
		s.SemesterName
FROM	Course as c,
		College as col,
		Semester as s,
		CourseCollegeSemester as ccs
WHERE c.CourseID = ccs.CourseID
AND s.SemesterID = ccs.SemesterID
AND col.CollegeID = ccs.CollegeID
AND ccs.CCSID IN (	SELECT	tc.CCSID
					FROM	TeacherCourse as tc
					WHERE	tc.TeacherID = @TeacherID)
END
GO

-- Retrieve All courses and locations for a teacher and semester --- doenst work

CREATE PROCEDURE spSelectAllCoursesCollegesForTeacherAndSemester
	@TeacherID		INT,
	@SemesterName	VARCHAR(6)
AS
BEGIN
SELECT	c.CourseID,
		c.[Name],
		col.[Name],
		s.SemesterName
FROM	Course as c,
		College as col,
		Semester as s,
		CourseCollegeSemester as ccs
WHERE c.CourseID = ccs.CourseID
AND col.CollegeID = ccs.CollegeID
AND ccs.CCSID IN (	SELECT	tc.CCSID
					FROM	TeacherCourse as tc
					WHERE	tc.TeacherID = @TeacherID)
AND ccs.SemesterID IN(	SELECT s.SemesterID
						FROM Semester
						WHERE SemesterName = @SemesterName)
END
GO

-----------UnitCourse-------------
-- Insert into UnitCourse
CREATE PROCEDURE spInsert_unitCourse
	@CourseID		INT,
	@UnitID			INT	
AS
BEGIN
	INSERT UnitCourse
	VALUES (@CourseID,
			@UnitID)
END
GO

-- Delete from UnitCourse
CREATE PROCEDURE spDelete_unitCourse
	@CourseID		INT,
	@UnitID			INT	
AS
BEGIN
	DELETE FROM UnitCourse
	WHERE CourseID = @CourseID
	AND UnitID = @UnitID
END
GO

------------Student-----------
-- Insert into StudentAddress
CREATE PROCEDURE spInsert_studentAddress
	@StreetAddress			NVARCHAR(50),
	@AptNumber				NVARCHAR(4),
	@Postcode				INT,
	@City					NVARCHAR(30),
	@State					NVARCHAR(30)
AS
BEGIN
	INSERT StudentAddress  OUTPUT INSERTED.StudentAddressID 
	VALUES (@StreetAddress, @AptNumber, @Postcode, @City, @State)
END
GO

-- Insert into Student
CREATE PROCEDURE spInsert_student
	@StudentID		INT,
	@FirstName		NVARCHAR(20),
	@LastName		NVARCHAR(40),
	@DOB			DATE,
	@Email			VARCHAR(30),
	@MobilePhone	INT,
	@HomePhone		INT,
	@GenderID		INT,
	@AddressID		INT
AS
BEGIN
	INSERT INTO Student
	VALUES (@FirstName,
			@LastName,
			@DOB,
			@Email,
			@MobilePhone,
			@HomePhone,
			@GenderID,
			@AddressID)
END
GO

-- Update Student and StudentAddress
CREATE PROCEDURE spUpdate_student_studentAddress
	@StudentID			INT,
	@FirstName			NVARCHAR(20),
	@LastName			NVARCHAR(40),
	@DOB				DATE,
	@Email				VARCHAR(30),
	@MobilePhone		INT,
	@HomePhone			INT,
	@GenderID				INT,	
	@StreetAddress		NVARCHAR(50),
	@AptNumber			NVARCHAR(4),
	@Postcode			INT,
	@City				NVARCHAR(30),
	@State				NVARCHAR(30),
	@Country			NVARCHAR(30)
AS
BEGIN
UPDATE Student
SET FirstName = @FirstName,
	LastName = @LastName,
	DOB = @DOB,
	Email = @Email,
	MobilePhone = @MobilePhone,
	HomePhone = @HomePhone,
	GenderID = @GenderID	
WHERE @StudentID = @StudentID
UPDATE StudentAddress
SET StreetAddress = @StreetAddress,
	AptNumber = @AptNumber,
	Postcode = @Postcode,
	City = @City,
	State = @State
WHERE StudentAddressID IN (SELECT StudentAddressID
							FROM Student
							WHERE StudentID = @StudentID)
END
GO

-- Select Student and StudentAddress by ID
CREATE PROCEDURE spSelectAllByID_student_address
	@StudentID		INT
AS
BEGIN
SELECT	s.StudentID,
		s.FirstName,		
		s.LastName,
		s.DOB,
		s.Email,
		s.MobilePhone,
		s.HomePhone,
		g.GenderID,
		sa.StreetAddress,
		sa.AptNumber,
		sa.Postcode,
		sa.City,
		sa.State
FROM	Student as s,
		Gender as g,
		StudentAddress as sa
WHERE s.StudentID = @StudentID
AND s.GenderID = g.GenderID
AND s.StudentAddressID = sa.StudentAddressID
END
GO

-- Select Student and StudentAddress by FName
CREATE PROCEDURE spSelectAllByFName_student_address
	@FirstName		NVARCHAR(20)
AS
BEGIN
SELECT	s.StudentID,
		s.FirstName,		
		s.LastName,
		s.DOB,
		s.Email,
		s.MobilePhone,
		s.HomePhone,
		g.GenderID,
		sa.StreetAddress,
		sa.AptNumber,
		sa.Postcode,
		sa.City,
		sa.State
FROM	Student as s,
		Gender as g,
		StudentAddress as sa
WHERE s.FirstName LIKE '%'+ @FirstName+ '%'
AND s.GenderID = g.GenderID
AND s.StudentAddressID = sa.StudentAddressID
END
GO


-- Students enrolled but not paid the fees
--CREATE PROCEDURE spSelectEnrolledButNotFullyPaid


--- Needs work
CREATE PROCEDURE sp_SelectBySemesterAndLocation_student
	@CollegeName		VARCHAR(30),
	@SemesterID			INT
AS
BEGIN
SELECT	s.StudentID,
		s.FirstName,		
		s.LastName,
		s.DOB,
		s.Email,
		s.MobilePhone,
		g.Gender
FROM	Student as s,
		Gender as g
WHERE g.GenderID = s.GenderID
AND StudentID IN (SELECT StudentID
					FROM Enrolment
					WHERE CCSID = @SemesterID)
				
END
GO

CREATE PROCEDURE spDeleteByID_Student_Address
	@StudentID	INT
AS
BEGIN
DELETE	FROM Student
		WHERE StudentID = @StudentID
END
GO

----------------Teacher------------------------
-- Insert into TeacherAddress
CREATE PROCEDURE spInsert_TeacherAddress
	@StreetAddress			NVARCHAR(50),
	@AptNumber				NVARCHAR(4),
	@Postcode				INT,
	@City					NVARCHAR(30),
	@State					NVARCHAR(30),
	@Country				NVARCHAR(30)
AS
BEGIN
	INSERT TeacherAddress  OUTPUT INSERTED.TeacherAddressID 
	VALUES (@StreetAddress, @AptNumber, @Postcode, @City, @State)
END
GO

-- Insert into Teacher
CREATE PROCEDURE spInsert_Teacher
	@TeacherID		INT,
	@FirstName		NVARCHAR(20),
	@LastName		NVARCHAR(40),
	@DOB			DATE,
	@Email			VARCHAR(30),
	@MobilePhone	INT,
	@HomePhone		INT,
	@GenderID		INT,
	@AddressID		INT
AS
BEGIN
	INSERT INTO Teacher
	VALUES (@FirstName,
			@LastName,
			@DOB,
			@Email,
			@MobilePhone,
			@HomePhone,
			@GenderID,
			@AddressID)
END
GO

-- Update Teacher and TeacherAddress
CREATE PROCEDURE spUpdate_Teacher_TeacherAddress
	@TeacherID			INT,
	@FirstName			NVARCHAR(20),
	@LastName			NVARCHAR(40),
	@DOB				DATE,
	@Email				VARCHAR(30),
	@MobilePhone		INT,
	@HomePhone			INT,
	@GenderID				INT,	
	@StreetAddress		NVARCHAR(50),
	@AptNumber			NVARCHAR(4),
	@Postcode			INT,
	@City				NVARCHAR(30),
	@State				NVARCHAR(30),
	@Country			NVARCHAR(30)
AS
BEGIN
UPDATE Teacher
SET FirstName = @FirstName,
	LastName = @LastName,
	DOB = @DOB,
	Email = @Email,
	MobilePhone = @MobilePhone,
	HomePhone = @HomePhone,
	GenderID = @GenderID	
WHERE @TeacherID = @TeacherID
UPDATE TeacherAddress
SET StreetAddress = @StreetAddress,
	AptNumber = @AptNumber,
	Postcode = @Postcode,
	City = @City,
	State = @State
WHERE TeacherAddressID IN (SELECT TeacherAddressID
							FROM Teacher
							WHERE TeacherID = @TeacherID)
END
GO

-- Select Teacher and TeacherAddress by ID
CREATE PROCEDURE spSelectAllByID_Teacher_address
	@TeacherID		INT
AS
BEGIN
SELECT	t.TeacherID,
		t.FirstName,		
		t.LastName,
		t.DOB,
		t.Email,
		t.MobilePhone,
		t.HomePhone,
		g.GenderID,
		ta.StreetAddress,
		ta.AptNumber,
		ta.Postcode,
		ta.City,
		ta.State
FROM	Teacher as t,
		Gender as g,
		TeacherAddress as ta
WHERE t.TeacherID = @TeacherID
AND t.GenderID = g.GenderID
AND t.TeacherAddressID = ta.TeacherAddressID
END
GO

-- Select Teacher and TeacherAddress by FName
CREATE PROCEDURE spSelectAllByFName_Teacher_address
	@FirstName		NVARCHAR(20)
AS
BEGIN
SELECT	t.TeacherID,
		t.FirstName,		
		t.LastName,
		t.DOB,
		t.Email,
		t.MobilePhone,
		t.HomePhone,
		g.GenderID,
		ta.StreetAddress,
		ta.AptNumber,
		ta.Postcode,
		ta.City,
		ta.State
FROM	Teacher as t,
		Gender as g,
		TeacherAddress as ta
WHERE t.FirstName LIKE '%' + @FirstName + '%'
AND t.GenderID = g.GenderID
AND t.TeacherAddressID = ta.TeacherAddressID
END
GO

-- Select All Teacher based on a College - aint pretty but working
CREATE PROCEDURE spSelectAllTeachersByCollege_teacher_college
	@CollegeName		VARCHAR(30)
AS
BEGIN
WITH [AllCourseAssignments] AS
(SELECT ccs.CCSID
FROM CourseCollegeSemester as ccs
WHERE ccs.CollegeID IN (SELECT CollegeID
						FROM College
						WHERE [Name] = @CollegeName))
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
GROUP BY	t.TeacherID,
			t.FirstName,		
			t.LastName,
			t.DOB,
			t.Email,
			t.MobilePhone,
			t.HomePhone
END
GO

-------------------
--WITH [AllCourseAssignments] AS
--(SELECT ccs.CCSID
--FROM CourseCollegeSemester as ccs
--WHERE ccs.CollegeID IN (SELECT CollegeID
--						FROM College
--						WHERE [Name] = 'TAFE Granville'))
--SELECT  t.TeacherID,
--		t.FirstName,		
--		t.LastName,
--		t.DOB,
--		t.Email,
--		t.MobilePhone,
--		t.HomePhone
--FROM	Teacher as t
--INNER JOIN TeacherCourse as tc ON t.TeacherID = tc.TeacherID
--AND tc.CCSID IN (SELECT [AllCourseAssignments].CCSID
--						FROM [AllCourseAssignments])
--GROUP BY	t.TeacherID,
--			t.FirstName,		
--			t.LastName,
--			t.DOB,
--			t.Email,
--			t.MobilePhone,
--			t.HomePhone
-------------------------------



------------------- Enrolment--------------------
CREATE PROCEDURE spInsert_Enrolment
	@StudentID			INT,
	@PaymentID			INT,	
	@CCSID				INT,
	@Status				BIT
AS
BEGIN
	INSERT Enrolment
	VALUES (@CCSID,
			@StudentID, 
			@PaymentID,			
			@Status)
END
GO

-- Delete from Enrolment by ID
CREATE PROCEDURE spDeleteByID_Enrolment
	@EnrolmentID		INT
AS
BEGIN
	DELETE FROM Enrolment
	WHERE EnrolmentID = @EnrolmentID
END
GO

-- Update Status for Enrolment by ID
CREATE PROCEDURE spUpdateStatusByID_Enrolment
	@EnrolmentID		INT,
	@Status				BIT
AS
BEGIN
	UPDATE	Enrolment
	SET		EnrolStatus = @Status
	WHERE	EnrolmentID = @EnrolmentID
END
GO

-- Select from Enrolment by StudentID
CREATE PROCEDURE spSelectAllByStudentID_Enrolment
	@StudentID		INT
AS
BEGIN
	SELECT  s.StudentID,
			s.FirstName,
			s.LastName,
			c.CourseID,
			c.[Name],
			sm.SemesterName
	FROM	Student as s,
			Course as c,
			Semester as sm,
			Enrolment as e
	WHERE e.StudentID = @StudentID
	AND e.StudentID = s.StudentID
	AND 
END
GO








--------------Triggers---------------------
-- After delete from Student delete from StudentAddress by AddressID
CREATE TRIGGER tr_Student_AfterDelete
ON Student
FOR DELETE 
AS
BEGIN
	DECLARE @StudentAddressID INT
	SELECT @StudentAddressID = del.StudentAddressID FROM DELETED del;
	DELETE FROM StudentAddress
	WHERE StudentAddress.StudentAddressID = @StudentAddressID;
END
GO

-- After delete from Teacher delete from TeacherAddress by AddressID
CREATE TRIGGER tr_Teacher_AfterDelete
ON Teacher
FOR DELETE 
AS 
BEGIN
	DECLARE @TeacherAddressID INT
	SELECT @TeacherAddressID = del.TeacherAddressID FROM DELETED del;
	DELETE FROM TeacherAddress
	WHERE TeacherAddress.TeacherAddressID = @TeacherAddressID;
END
GO

-- After delete from Staff delete from StaffAddress by AddressID
CREATE TRIGGER tr_Staff_AfterDelete
ON Staff
FOR DELETE 
AS 
BEGIN
	DECLARE @StaffAddressID INT
	SELECT @StaffAddressID = del.StaffAddressID FROM DELETED del;
	DELETE FROM StaffAddress
	WHERE StaffAddress.StaffAddressID = @StaffAddressID;
END
GO


--------------------Views--------------------------
--CREATE VIEW vwCoursePrice AS
--(
--	WITH	[Course Total Price] AS 
--	(SELECT SUM(Unit.Price))



--	SELECT	c.CourseID,
--			c.[Name] as [Course Name],
--			SUM(u.Price) as [Course Total Price]
--	FROM	Course as c,
--			Unit as u,
--			UnitCourse as uc			
--	WHERE c.CourseID = uc.CourseID
--	GROUP BY uc.CourseID

--	FROM     Attendee
--	WHERE   (State = N'NSW')
--)



--WITH [Number of Attendees] AS
--(
--	SELECT  e.Event_ID,
--		COUNT(r.Attendee_ID) as [AttendeeCount]
--		FROM [Event] as e,
--			Registration as r
--		WHERE e.Event_ID = r.Event_ID 
--		GROUP BY e.Event_ID
--)
--UPDATE e 
--SET e.[AttendeeCount] = na.AttendeeCount
--FROM [Event] e
--INNER JOIN [Number of Attendees] AS na ON e.Event_ID = na.Event_ID 
--GO