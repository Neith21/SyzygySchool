CREATE DATABASE PuellaSchoolDB;
GO

USE PuellaSchoolDB;
GO

CREATE TABLE Students(
	StudentId INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    StudentName VARCHAR(50) NOT NULL,
    StudentLastName VARCHAR(50) NOT NULL,
    StudentAge INT NOT NULL,
    StudentGender CHAR(1),
    StudentParentName VARCHAR(50) NOT NULL   
);
GO

CREATE TABLE Sections(
	SectionId INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	SectionName VARCHAR(50) NOT NULL,
	SectionInfo VARCHAR(100)
);
GO

CREATE TABLE Grades(
    GradeId INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	GradeName VARCHAR(50) NOT NULL,
);
GO

CREATE TABLE Classes(
    ClassId INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    GradeId INT NOT NULL,
    SectionId INT NOT NULL,
    
    FOREIGN KEY (GradeId) REFERENCES Grades(GradeId),
    FOREIGN KEY (SectionId) REFERENCES Sections(SectionId)
);
GO

CREATE TABLE Classrooms(
    ClassroomId INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    ClassId INT NOT NULL,
    StudentId INT NOT NULL,
    
    foreign KEY (ClassId) REFERENCES Classes (ClassId),
    foreign KEY (StudentId) REFERENCES Students(StudentId)
);
GO

CREATE TABLE Subjects(
	SubjectId INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	SubjectName VARCHAR(50) NOT NULL,
	SubjectInfo VARCHAR(100),
	GradeId INT,

	FOREIGN KEY (GradeId) REFERENCES Grades(GradeId)
);
GO

CREATE TABLE Teachers(
	TeacherId INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	TeacherName VARCHAR(50) NOT NULL,
	TeacherLastName VARCHAR(50) NOT NULL,
	TeacherAge INT NOT NULL,
	TeacherGender CHAR(1),
	TeacherPhone VARCHAR(30),
	TeacherEmail NVARCHAR(75) NOT NULL
);
GO

-- Schedules
CREATE TABLE Schedules(
	IdSchedule INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	ScheduleInfo VARCHAR(100),
	ScheduleCreation DATE NOT NULL, -- Se tomará automatico
	ScheduleStart TIME NOT NULL,
	ScheduleEnd TIME NOT NULL,
	ScheduleExpiration DATE NOT NULL, -- Se le asignará manual y junto con el ScheduleCreation se establece un periodo de validez al horario.
	SubjectId INT NOT NULL,
	TeacherId INT NOT NULL,
	ClassId INT NOT NULL,

	FOREIGN KEY (SubjectId) REFERENCES Subjects(SubjectId),
	FOREIGN KEY (TeacherId) REFERENCES Teachers(TeacherId),
	FOREIGN KEY (ClassId) REFERENCES Classes(ClassId)	
);
GO

-- Roles and logins

CREATE TABLE Roles(
	RoleId INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	RoleName VARCHAR(50) NOT NULL,
	RoleInfo VARCHAR(100)
);
GO

CREATE TABLE Logins(
	LoginId INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	LoginUser NVARCHAR(50) NOT NULL,
	LoginPassword NVARCHAR(50) NOT NULL,
	TeacherId INT NOT NULL,
	RoleId INT NOT NULL,
	
	FOREIGN KEY (TeacherId) REFERENCES Teachers(TeacherId),
	FOREIGN KEY (RoleId) REFERENCES Roles(RoleId)	
);
GO

-- Insertando registros en la tabla Students
INSERT INTO Students (StudentName, StudentLastName, StudentAge, StudentGender, StudentParentName)
VALUES 
    ('Ana', 'González', 8, 'F', 'María Pérez'),
    ('Carlos', 'Martínez', 9, 'M', 'Juan Martínez'),
    ('Luisa', 'Hernández', 8, 'F', 'José Hernández'),
    ('Pedro', 'Gómez', 9, 'M', 'Sofía Gómez'),
    ('Laura', 'Sánchez', 8, 'F', 'Alejandro Sánchez'),
    ('Diego', 'Rodríguez', 9, 'M', 'Andrea Rodríguez'),
    ('Valentina', 'López', 8, 'F', 'David López'),
    ('Manuel', 'Pérez', 9, 'M', 'Ana Pérez'),
    ('Sofía', 'Díaz', 8, 'F', 'Luis Díaz'),
    ('Javier', 'Fernández', 9, 'M', 'Elena Fernández'),
    ('María', 'Gutiérrez', 8, 'F', 'Carlos Gutiérrez'),
    ('Juan', 'Torres', 9, 'M', 'Lucía Torres'),
    ('Carmen', 'Vargas', 8, 'F', 'Miguel Vargas'),
    ('Miguel', 'Romero', 9, 'M', 'Carmen Romero'),
    ('Isabella', 'Suárez', 8, 'F', 'Jorge Suárez'),
    ('Alejandro', 'Díaz', 9, 'M', 'Sofía Díaz'),
    ('Gabriela', 'Alvarez', 8, 'F', 'Fernando Alvarez'),
    ('Daniel', 'García', 9, 'M', 'Gabriela García'),
    ('Valeria', 'Pérez', 8, 'F', 'Francisco Pérez'),
    ('José', 'Hernández', 9, 'M', 'Valeria Hernández'),
    ('Fernanda', 'Martínez', 8, 'F', 'Roberto Martínez'),
    ('Andrés', 'Rodríguez', 9, 'M', 'Adriana Rodríguez'),
    ('Lucía', 'Gómez', 8, 'F', 'Ignacio Gómez'),
    ('Julián', 'Sánchez', 9, 'M', 'Camila Sánchez'),
    ('Valentina', 'López', 8, 'F', 'Emilio López'),
    ('Mateo', 'Pérez', 9, 'M', 'María Pérez'),
    ('Camila', 'Díaz', 8, 'F', 'Antonio Díaz'),
    ('Diego', 'Fernández', 9, 'M', 'Daniela Fernández'),
    ('Valeria', 'Gutiérrez', 8, 'F', 'Hugo Gutiérrez'),
    ('Juan', 'Martínez', 9, 'M', 'Isabel Martínez'),
    ('Emma', 'Vargas', 8, 'F', 'Eduardo Vargas'),
    ('Samuel', 'Romero', 9, 'M', 'Patricia Romero'),
    ('Natalia', 'Suárez', 8, 'F', 'Ricardo Suárez'),
    ('Matías', 'Díaz', 9, 'M', 'Marina Díaz'),
    ('Valentina', 'Alvarez', 8, 'F', 'Luis Alvarez'),
    ('Santiago', 'García', 9, 'M', 'Andrea García'),
    ('María', 'Pérez', 8, 'F', 'Santiago Pérez'),
    ('Emilia', 'Hernández', 9, 'M', 'Laura Hernández'),
    ('Lucas', 'Martínez', 8, 'F', 'Martín Martínez'),
    ('Isabella', 'Rodríguez', 9, 'M', 'Paula Rodríguez'),
    ('Martina', 'Gómez', 8, 'F', 'Diego Gómez'),
    ('Juan', 'Sánchez', 9, 'M', 'Valentina Sánchez'),
    ('Gabriel', 'López', 8, 'F', 'Felipe López'),
    ('Valentina', 'García', 9, 'M', 'Juliana García'),
    ('Nicolás', 'Vargas', 8, 'F', 'Manuel Vargas'),
    ('Emilia', 'Romero', 9, 'M', 'Carolina Romero'),
    ('Sofía', 'Suárez', 8, 'F', 'Gustavo Suárez'),
    ('Alejandro', 'Díaz', 9, 'M', 'Valeria Díaz'),
    ('Valentina', 'Alvarez', 8, 'F', 'Fernando Alvarez'),
    ('Lucas', 'García', 9, 'M', 'Daniela García');
GO

-- Insertando registros en la tabla Sections
INSERT INTO Sections (SectionName, SectionInfo)
VALUES
('A', 'Section A Info'),
('B', 'Section B Info'),
('C', 'Section C Info');
GO

-- Insertando registros en la tabla Grades
INSERT INTO Grades (GradeName)
VALUES
('Grade 7'),
('Grade 8'),
('Grade 9');
GO

-- Insertando registros en la tabla Classes
INSERT INTO Classes (GradeId, SectionId)
VALUES
(1, 1),
(2, 2),
(3, 3);
GO

-- Insertando registros en la tabla Classrooms
INSERT INTO Classrooms (ClassId, StudentId)
VALUES
(1, 1),
(2, 2),
(3, 3);
GO

-- Insertando registros en la tabla Subjects
INSERT INTO Subjects (SubjectName, SubjectInfo, GradeId)
VALUES
('Mathematics', 'Maths Class', 1),
('Science', 'Science Class', 2),
('History', 'History Class', 3);
GO

-- Insertando registros en la tabla Teachers
INSERT INTO Teachers (TeacherName, TeacherLastName, TeacherAge, TeacherGender, TeacherPhone, TeacherEmail)
VALUES
('Alice', 'Brown', 30, 'F', '555-1234', 'alice.brown@example.com'),
('David', 'Wilson', 40, 'M', '555-5678', 'david.wilson@example.com'),
('Sophia', 'Miller', 35, 'F', '555-8765', 'sophia.miller@example.com');
GO

-- Insertando registros en la tabla Schedules
INSERT INTO Schedules (ScheduleInfo, ScheduleCreation, ScheduleStart, ScheduleEnd, ScheduleExpiration, SubjectId, TeacherId, ClassId)
VALUES
('Schedule for Science', GETDATE(), '08:00:00', '09:00:00', DATEADD(MONTH, 6, GETDATE()), 2, 2, 1),
('Schedule for History', GETDATE(), '08:00:00', '09:00:00', DATEADD(MONTH, 6, GETDATE()), 3, 3, 1),
('Schedule for Math', GETDATE(), '08:00:00', '09:00:00', DATEADD(MONTH, 6, GETDATE()), 1, 1, 1),
('Schedule for Science', GETDATE(), '09:00:00', '10:00:00', DATEADD(MONTH, 6, GETDATE()), 2, 2, 2),
('Schedule for History', GETDATE(), '10:00:00', '11:00:00', DATEADD(MONTH, 6, GETDATE()), 3, 3, 3);
GO

-- Insertando registros en la tabla Roles
INSERT INTO Roles (RoleName, RoleInfo)
VALUES
('Admin', 'Administrator role'),
('Teacher', 'Teacher role'),
('Student', 'Student role');
GO

-- Insertando registros en la tabla Logins
INSERT INTO Logins (LoginUser, LoginPassword, TeacherId, RoleId)
VALUES
('alice.brown', 'password1', 1, 1),
('david.wilson', 'password2', 2, 2),
('sophia.miller', 'password3', 3, 3);
GO

SELECT Schedules.IdSchedule, Schedules.ScheduleInfo, Schedules.ScheduleCreation, Schedules.ScheduleStart, Schedules.ScheduleEnd, Schedules.ScheduleExpiration, Subjects.SubjectName, Teachers.TeacherName, Teachers.TeacherLastName, Classes.GradeId, Classes.SectionId
FROM Schedules
JOIN Subjects ON Schedules.SubjectId = Subjects.SubjectId
JOIN Teachers ON Schedules.TeacherId = Teachers.TeacherId
JOIN Classes ON Schedules.ClassId = Classes.ClassId
WHERE Classes.GradeId = 1
AND Classes.SectionId = 1
GROUP BY Schedules.IdSchedule, Schedules.ScheduleInfo, Schedules.ScheduleCreation, Schedules.ScheduleStart, Schedules.ScheduleEnd, Schedules.ScheduleExpiration, Subjects.SubjectName, Teachers.TeacherName, Teachers.TeacherLastName, Classes.GradeId, Classes.SectionId;
GO
---[Procesos almacenados para tab la students]---

CREATE OR ALTER PROC dbo.spStudents_Insert --Insert
(@StudentName VARCHAR(50), @StudentLastName VARCHAR(50), @StudentAge INT, @StudentGender CHAR(1), @StudentParentName VARCHAR(50))
AS
BEGIN
	INSERT INTO Students VALUES(@StudentName, @StudentLastName, @StudentAge, @StudentGender, @StudentParentName)
END
GO

CREATE OR ALTER PROC dbo.spStudents_Update --Update
(@StudentId INT, @StudentName VARCHAR(50), @StudentLastName VARCHAR(50), @StudentAge INT, @StudentGender CHAR(1), @StudentParentName VARCHAR(50))
AS
BEGIN
	UPDATE Students SET StudentName = @StudentName, StudentLastName = @StudentLastName,
	StudentAge = @StudentAge, StudentGender = @StudentGender, StudentParentName = @StudentParentName
	WHERE StudentId = @StudentId
END
GO

CREATE OR ALTER PROC dbo.spStudents_Delete --delete
(@StudentId INT)
AS
BEGIN
	DELETE FROM Students WHERE StudentId = @StudentId
END
GO

CREATE OR ALTER PROC dbo.spStudents_GetAll
AS
BEGIN
	SELECT StudentId, StudentName, StudentLastName, StudentAge, StudentGender, StudentParentName FROM Students
END
GO

CREATE OR ALTER PROC dbo.spStudents_GetById --delete
(@StudentId INT)
AS
BEGIN
	SELECT StudentId, StudentName, StudentLastName, StudentAge, StudentGender, StudentParentName FROM Students 
	WHERE StudentId = @StudentId
END
GO

---[Procesos almacenados para tabla Classrooms]---
CREATE OR ALTER PROC dbo.spClassrooms_Insert --Insert
(@ClassId INT, @StudentId INT)
AS
BEGIN
	INSERT INTO Classrooms VALUES(@ClassId, @StudentId)
END
GO

CREATE OR ALTER PROC dbo.spClassrooms_Update --Edit
(@ClassroomId INT, @ClassId INT, @StudentId INT)
AS
BEGIN
	UPDATE Classrooms SET ClassId = @ClassId, StudentId = @StudentId WHERE ClassroomId = @ClassroomId
END
GO

CREATE OR ALTER PROC dbo.spClassrooms_Delete --Delete
(@ClassroomId INT)
AS
BEGIN
	DELETE FROM Classrooms WHERE ClassroomId = @ClassroomId
END
GO

CREATE OR ALTER PROC dbo.spClassrooms_GetById --gETbY ID
(@ClassroomId INT)
AS
BEGIN
	SELECT ClassroomId, (S.StudentName + ' ' + S.StudentLastName ) AS StudentName, ClassId, C.StudentId FROM Classrooms C INNER JOIN Students S ON C.StudentID = S.StudentID
	WHERE ClassroomId = @ClassroomId
END
GO

CREATE OR ALTER PROC dbo.spClassrooms_GetAll 
AS
BEGIN
	SELECT ClassroomId, (S.StudentName + ' ' + S.StudentLastName ) AS StudentName, ClassId, C.StudentId FROM Classrooms C INNER JOIN Students S ON C.StudentID = S.StudentID
END
GO

---------------------------------------- Procesos almacenados de login --------------------------------------
-- Procedimiento almacenado para SELECT
CREATE OR ALTER PROCEDURE spLogin_GetAll
AS
BEGIN
    SELECT LoginId, LoginUser, LoginPassword, TeacherId, RoleId
    FROM Logins;
END;
GO

-- Procedimiento almacenado para SELECTBYID
CREATE OR ALTER PROCEDURE spLogin_GetByID
	@LoginId INT
AS
BEGIN
    SELECT LoginId, LoginUser, LoginPassword, TeacherId, RoleId
    FROM Logins
	WHERE LoginId = @LoginId
END;
GO

-- Procedimiento almacenado para INSERT
CREATE OR ALTER PROCEDURE spLogin_Insert
    @LoginUser NVARCHAR(50),
    @LoginPassword NVARCHAR(50),
    @TeacherId INT,
    @RoleId INT
AS
BEGIN
    INSERT INTO Logins (LoginUser, LoginPassword, TeacherId, RoleId)
    VALUES (@LoginUser, @LoginPassword, @TeacherId, @RoleId);
END;
GO

-- Procedimiento almacenado para UPDATE
CREATE OR ALTER PROCEDURE spLogin_Update
    @LoginId INT,
    @LoginUser NVARCHAR(50),
    @LoginPassword NVARCHAR(50),
    @TeacherId INT,
    @RoleId INT
AS
BEGIN
    UPDATE Logins
    SET LoginUser = @LoginUser,
        LoginPassword = @LoginPassword,
        TeacherId = @TeacherId,
        RoleId = @RoleId
    WHERE LoginId = @LoginId;
END;
GO

-- Procedimiento almacenado para DELETE
CREATE OR ALTER PROCEDURE spLogin_Delete
    @LoginId INT
AS
BEGIN
    DELETE FROM Logins
    WHERE LoginId = @LoginId;
END;
GO

-------------------------------------Procesos almacenados de ROLES --------------------------------------

-- Procedimiento almacenado para la consulta SELECT
CREATE OR ALTER PROCEDURE spRoles_GetAll
AS
BEGIN
    SELECT RoleId, RoleName, RoleInfo
    FROM Roles;
END;
GO

CREATE PROCEDURE spRoles_GetById
	@RoleId INT
AS
BEGIN
    SELECT RoleId, RoleName, RoleInfo
    FROM Roles
	WHERE RoleId = @RoleId
END;
GO


-- Procedimiento almacenado para la consulta INSERT
CREATE OR ALTER PROCEDURE spRoles_Insert
    @RoleName VARCHAR(50),
    @RoleInfo VARCHAR(100)
AS
BEGIN
    INSERT INTO Roles (RoleName, RoleInfo)
    VALUES (@RoleName, @RoleInfo);
END;
GO


-- Procedimiento almacenado para la consulta UPDATE
CREATE OR ALTER PROCEDURE spRoles_Update
    @RoleId INT,
    @RoleName VARCHAR(50),
    @RoleInfo VARCHAR(100)
AS
BEGIN
    UPDATE Roles
    SET RoleName = @RoleName, RoleInfo = @RoleInfo
    WHERE RoleId = @RoleId;
END;
GO

-- Procedimiento almacenado para la consulta DELETE
CREATE OR ALTER PROCEDURE spRoles_Delete
    @RoleId INT
AS
BEGIN
    DELETE FROM Roles
    WHERE RoleId = @RoleId;
END;
GO

------------------------------------- TEACHER --------------------------------
-- Procedimiento almacenado para la consulta SELECT
CREATE OR ALTER PROCEDURE spTeachers_GetAll
AS
BEGIN
    SELECT TeacherId, TeacherName, TeacherLastName, TeacherAge, TeacherGender, TeacherPhone, TeacherEmail
    FROM Teachers;
END;
GO

CREATE PROCEDURE spTeachers_GetById
    @TeacherId INT
AS
BEGIN
    SELECT * FROM Teachers WHERE TeacherId = @TeacherId;
END;
GO

CREATE PROCEDURE spTeachers_Insert
    @TeacherName NVARCHAR(100),
    @TeacherLastName NVARCHAR(100),
    @TeacherAge INT,
    @TeacherGender NVARCHAR(10),
    @TeacherPhone NVARCHAR(20),
    @TeacherEmail NVARCHAR(100)
AS
BEGIN
    INSERT INTO Teachers (TeacherName, TeacherLastName, TeacherAge, TeacherGender, TeacherPhone, TeacherEmail)
    VALUES (@TeacherName, @TeacherLastName, @TeacherAge, @TeacherGender, @TeacherPhone, @TeacherEmail);
END;
GO

CREATE PROCEDURE spTeachers_Update
    @TeacherId INT,
    @TeacherName NVARCHAR(100),
    @TeacherLastName NVARCHAR(100),
    @TeacherAge INT,
    @TeacherGender NVARCHAR(10),
    @TeacherPhone NVARCHAR(20),
    @TeacherEmail NVARCHAR(100)
AS
BEGIN
    UPDATE Teachers
    SET TeacherName = @TeacherName,
        TeacherLastName = @TeacherLastName,
        TeacherAge = @TeacherAge,
        TeacherGender = @TeacherGender,
        TeacherPhone = @TeacherPhone,
        TeacherEmail = @TeacherEmail
    WHERE TeacherId = @TeacherId;
END;
GO

CREATE PROCEDURE spTeachers_Delete
    @TeacherId INT
AS
BEGIN
    DELETE FROM Teachers WHERE TeacherId = @TeacherId;
END;
GO
---------------------
-- Procedimiento para obtener todos los profesores
ALTER PROCEDURE spTeachers_GetAll
AS
BEGIN
    SELECT TeacherId, TeacherName, TeacherLastName, TeacherAge, TeacherGender, TeacherPhone, TeacherEmail
    FROM Teachers;
END;
GO

-- Procedimiento para obtener un profesor por su ID
ALTER PROCEDURE spTeachers_GetById
    @Id INT
AS
BEGIN
    SELECT TeacherId, TeacherName, TeacherLastName, TeacherAge, TeacherGender, TeacherPhone, TeacherEmail
    FROM Teachers
    WHERE TeacherId = @Id;
END;
GO

-- Procedimiento para insertar un nuevo profesor
ALTER PROCEDURE spTeachers_Insert
    @TeacherName VARCHAR(50),
    @TeacherLastName VARCHAR(50),
    @TeacherAge INT,
    @TeacherGender CHAR(1),
    @TeacherPhone VARCHAR(30),
    @TeacherEmail NVARCHAR(75)
AS
BEGIN
    INSERT INTO Teachers (TeacherName, TeacherLastName, TeacherAge, TeacherGender, TeacherPhone, TeacherEmail)
    VALUES (@TeacherName, @TeacherLastName, @TeacherAge, @TeacherGender, @TeacherPhone, @TeacherEmail);
END;
GO

-- Procedimiento para actualizar un profesor
ALTER PROCEDURE spTeachers_Update
    @TeacherId INT,
    @TeacherName VARCHAR(50),
    @TeacherLastName VARCHAR(50),
    @TeacherAge INT,
    @TeacherGender CHAR(1),
    @TeacherPhone VARCHAR(30),
    @TeacherEmail NVARCHAR(75)
AS
BEGIN
    UPDATE Teachers
    SET TeacherName = @TeacherName, TeacherLastName = @TeacherLastName,
        TeacherAge = @TeacherAge, TeacherGender = @TeacherGender,
        TeacherPhone = @TeacherPhone, TeacherEmail = @TeacherEmail
    WHERE TeacherId = @TeacherId;
END;
GO

-- Procedimiento para eliminar un profesor por su ID
ALTER PROCEDURE spTeachers_Delete
    @Id INT
AS
BEGIN
    DELETE FROM Teachers
    WHERE TeacherId = @Id;
END;
GO
--------------------------------------------------


-- Procedimiento almacenado para insertar un nuevo registro en la tabla Subjects
CREATE PROCEDURE spSubject_Insert
    @SubjectName NVARCHAR(100),
    @SubjectInfo NVARCHAR(MAX),
    @GradeId INT
AS
BEGIN
    INSERT INTO Subjects (SubjectName, SubjectInfo, GradeId)
    VALUES (@SubjectName, @SubjectInfo, @GradeId);
    SELECT SCOPE_IDENTITY(); -- Retorna el ID del nuevo registro insertado
END;
GO

-- Procedimiento almacenado para eliminar un registro de la tabla Subjects por su ID
CREATE PROCEDURE spSubject_Delete
    @SubjectId INT
AS
BEGIN
    DELETE FROM Subjects
    WHERE SubjectId = @SubjectId;
END;
GO

-- Procedimiento almacenado para obtener todos los registros de la tabla Subjects
CREATE OR ALTER PROCEDURE dbo.spSubjects_GetAll
AS
BEGIN
    SELECT SubjectId, SubjectName, SubjectInfo, g.GradeName, s.GradeId
	FROM Subjects s
	INNER JOIN Grades g ON s.GradeId = g.GradeId;
END;
GO

-- Procedimiento almacenado para obtener un registro de la tabla Subjects por su ID
CREATE PROCEDURE spSubject_GetById
    @SubjectId INT
AS
BEGIN
    SELECT * FROM Subjects
    WHERE SubjectId = @SubjectId;
END;
GO

-- Procedimiento almacenado para actualizar un registro de la tabla Subjects por su ID
CREATE PROCEDURE spSubject_Update
    @SubjectId INT,
    @SubjectName NVARCHAR(100),
    @SubjectInfo NVARCHAR(MAX),
    @GradeId INT
AS
BEGIN
    UPDATE Subjects
    SET SubjectName = @SubjectName,
        SubjectInfo = @SubjectInfo,
        GradeId = @GradeId
    WHERE SubjectId = @SubjectId;
END;
GO

---[Procesos almacenados para tabla Schedules]---
CREATE OR ALTER PROCEDURE dbo.spSchedules_GetAll
AS
BEGIN
    SELECT 
        sc.IdSchedule,
        sc.ScheduleInfo,
        sc.ScheduleCreation,
        sc.ScheduleStart,
        sc.ScheduleEnd,
        sc.ScheduleExpiration,
		sc.ClassId,
        sc.SubjectId,
        s.SubjectName,
        sc.TeacherId,
        t.TeacherName
    FROM 
        Schedules sc
    INNER JOIN 
        Subjects s ON sc.SubjectId = s.SubjectId
    INNER JOIN 
        Teachers t ON sc.TeacherId = t.TeacherId
END;
GO

CREATE OR ALTER PROCEDURE dbo.spSchedule_Insert
    @ScheduleInfo VARCHAR(100),
	@ScheduleCreation DATE,
    @ScheduleStart TIME,
    @ScheduleEnd TIME,
    @ScheduleExpiration DATE,
    @SubjectId INT,
    @TeacherId INT,
    @ClassId INT
AS
BEGIN
    INSERT INTO Schedules (ScheduleInfo, ScheduleCreation, ScheduleStart, ScheduleEnd, ScheduleExpiration, SubjectId, TeacherId, ClassId)
    VALUES (@ScheduleInfo, @ScheduleCreation, @ScheduleStart, @ScheduleEnd, @ScheduleExpiration, @SubjectId, @TeacherId, @ClassId);
END;