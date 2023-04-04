USE StudentManagement;

INSERT INTO Teacher(first_name, last_name, gender, age, email, subject) VALUES ('Blakely','Ferster','Male',32,'blakelyferster@gmail.com','Art');
INSERT INTO Teacher(first_name, last_name, gender, age, email, subject) VALUES ('Derrick','Lindorf','Male',41,'derricklindorf@gmail.com','Engineering');
INSERT INTO Teacher(first_name, last_name, gender, age, email, subject) VALUES ('Laverne','Saulino','Male',52,'lavernesaulino@gmail.com', 'Medicine');
INSERT INTO Teacher(first_name, last_name, gender, age, email, subject) VALUES ('Alison','Crissler','Female',27,'alisoncrissler@gmail.com', 'Law');
INSERT INTO Teacher(first_name, last_name, gender, age, email, subject) VALUES ('Jayda','Desena','Female',31,'jaydadesena@gmail.com', 'Arhitecture');
INSERT INTO Teacher(first_name, last_name, gender, age, email, subject) VALUES ('Zoe','Wiswell','Female',42,'zoewiswell@gmail.com', 'Agriculture');

INSERT INTO Course(teacher_id, name, time_start, time_end, school_year) VALUES (1,'Art Administration', GETDATE(), DATEADD(hour,2,GETDATE()), '1');
INSERT INTO Course(teacher_id, name, time_start, time_end, school_year) VALUES (2,'Electrical Engineering', GETDATE(), DATEADD(hour,5,GETDATE()), '2');
INSERT INTO Course(teacher_id, name, time_start, time_end, school_year) VALUES (3,'Ophthalmology', GETDATE(), DATEADD(hour,1,GETDATE()), '1');
INSERT INTO Course(teacher_id, name, time_start, time_end, school_year) VALUES (4,'Civil Law', GETDATE(), DATEADD(hour,8,GETDATE()), '3');
INSERT INTO Course(teacher_id, name, time_start, time_end, school_year) VALUES (5,'Property Management', GETDATE(), DATEADD(hour,3,GETDATE()), '1');
INSERT INTO Course(teacher_id, name, time_start, time_end, school_year) VALUES (6,'Plant and Crop Sciences', GETDATE(), DATEADD(hour,3,GETDATE()), '2');