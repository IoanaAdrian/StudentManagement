CREATE DATABASE StudentManagement;
USE StudentManagement;

CREATE TABLE Student(
	id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	username VARCHAR(255),
	password VARCHAR(255),
	first_name VARCHAR(255),
	last_name VARCHAR(255),
	gender VARCHAR(255),
	age int,
	email VARCHAR(255)
);
CREATE TABLE Teacher(
	id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	first_name VARCHAR(255),
	last_name VARCHAR(255),
	gender VARCHAR(255),
	age int,
	email VARCHAR(255),
	subject VARCHAR(255)
);

CREATE TABLE Course(
	id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	teacher_id INT NOT NULL,
	FOREIGN KEY (teacher_id) REFERENCES Teacher(id),
	name VARCHAR(255),
	time_start DATETIME,
	time_end DATETIME,
	school_year VARCHAR(255)
);

CREATE TABLE StudentCourse(
	id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	student_id INT NOT NULL,
	FOREIGN KEY (student_id) REFERENCES Student(id),
	course_id INT NOT NULL,
	FOREIGN KEY (course_id) REFERENCES Course(id)
);