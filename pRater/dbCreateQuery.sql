use master;

IF db_id('ProfessorRater') IS NULL
    CREATE DATABASE ProfessorRater

GO

use ProfessorRater;

CREATE TABLE PROFESSOR (
	ProfessorId int NOT NULL IDENTITY (1,1),
	LastName varchar(255) NOT NULL,
	FirstName varchar(255) NOT NULL,
	Department varchar(255) NOT NULL,
	ProfileImage varchar(255),
	CONSTRAINT PROF_PK PRIMARY KEY (ProfessorId)
);

CREATE TABLE PROFRATING (
	RatingId int NOT NULL IDENTITY (1,1),
	ProfessorId int NOT NULL,
	UploadDate Date NOT NULL,
	Comment varchar(255) NOT NULL,
	UseText bit NOT NULL,
	ProfRating int NOT NULL,
	DiffRating int NOT NULL,
	ClassTaken varchar(255) NOT NULL,
	GradeReceived char NOT NULL,
	CONSTRAINT PROFRATING_PK PRIMARY KEY (RatingId),
	CONSTRAINT PROF_FK FOREIGN KEY (ProfessorId) REFERENCES PROFESSOR (ProfessorId)
);

INSERT INTO PROFESSOR 
VALUES ('Martinez', 'Denis', 'Information Technology', 'dmartinez.jpg');

INSERT INTO PROFESSOR 
VALUES ('Lander', 'Eric', 'Information Technology', 'elander.jpg');

INSERT INTO PROFESSOR 
VALUES ('Garcia', 'James', 'Information Technology', 'jgarcia.jpg');

INSERT INTO PROFESSOR 
VALUES ('Pelz', 'Andrew', 'Information Technology', 'apelz.jpg');

INSERT INTO PROFESSOR 
VALUES ('Yusuf', 'Saleem', 'Information Technology', 'syusuf.jpg');

INSERT INTO PROFESSOR 
VALUES ('Gateman', 'Robert', 'Information Technology', 'rgateman.jpg');

INSERT INTO PROFESSOR 
VALUES ('Cooper', 'Stephen', 'Business Administration', 'stcooper.jpg');

INSERT INTO PROFESSOR 
VALUES ('McEwane', 'Stephanie', 'Business Administration', 'smcewane.jpg');

INSERT INTO PROFESSOR 
VALUES ('Butler', 'Joseph', 'Business Administration', 'jbutler.jpg');

INSERT INTO PROFESSOR 
VALUES ('Stark', 'Barbara', 'Business Administration', 'bstark.jpg');

INSERT INTO PROFESSOR 
VALUES ('Beyers', 'Linda', 'Business Administration', 'lbeyers.jpg');

INSERT INTO PROFESSOR 
VALUES ('King', 'Jennifer', 'Business Administration', 'jking.jpg');

INSERT INTO PROFESSOR 
VALUES ('Hutchins', 'Denise', 'Human Service', 'dhutchins.jpg');

INSERT INTO PROFESSOR 
VALUES ('Campbell', 'Monica', 'Human Service', 'mcampbell.jpg');

INSERT INTO PROFESSOR 
VALUES ('Colucci', 'Nichole', 'Human Service', 'ncolucci.jpg');

INSERT INTO PROFESSOR 
VALUES ('Cooper', 'Stephen', 'Human Service', 'scooper.jpg');

INSERT INTO PROFESSOR 
VALUES ('Stevens', 'Kelly', 'Human Service', 'kstevens.jpg');

INSERT INTO PROFESSOR 
VALUES ('Lane', 'Elizabeth', 'Human Service', 'elane.jpg');

INSERT INTO PROFESSOR 
VALUES ('Galic', 'Ivan', 'Mechanical Engineering', 'igalic.jpg');

INSERT INTO PROFESSOR 
VALUES ('Stein', 'Wayne', 'Mechanical Engineering', 'wstein.jpg');

INSERT INTO PROFESSOR 
VALUES ('Pane', 'Joshua', 'Mechanical Engineering', 'jpane.jpg');

INSERT INTO PROFESSOR 
VALUES ('Hanahan', 'Devon', 'Mechanical Engineering', 'hdevon.jpg');

INSERT INTO PROFESSOR 
VALUES ('Orch', 'Jason', 'Mechanical Engineering', 'jorch.jpg');

INSERT INTO PROFESSOR 
VALUES ('Hong', 'Russell', 'Mechanical Engineering', 'rhong.jpg');

INSERT INTO PROFESSOR 
VALUES ('Bravo', 'Karen', 'Biology', 'kbravo.jpg');

INSERT INTO PROFESSOR 
VALUES ('Bravo', 'July', 'Biology', 'jbravo.jpg');

INSERT INTO PROFESSOR 
VALUES ('Darby', 'Alan', 'Biology', 'adarby.jpg');

INSERT INTO PROFESSOR 
VALUES ('Singh', 'Janet', 'Biology', 'jsingh.jpg');

INSERT INTO PROFESSOR 
VALUES ('Kerrigan', 'John', 'Chemistry','jkerrigan.jpg');

INSERT INTO PROFESSOR 
VALUES ('Borne', 'William', 'Chemistry', 'wborne.jpg');

INSERT INTO PROFESSOR 
VALUES ('Kovler', 'Jessica', 'Chemistry', 'jkolver.jpg');

INSERT INTO PROFESSOR 
VALUES ('Bravo', 'Karen', 'Chemistry', 'kabravo.jpg');

INSERT INTO PROFESSOR 
VALUES ('Schafer', 'Fred', 'Computer Engineering', 'fschafer.jpg');

INSERT INTO PROFESSOR 
VALUES ('Woodward', 'Chad', 'Computer Engineering', 'cwoodward.jpg');

INSERT INTO PROFESSOR 
VALUES ('Moon', 'Ezekiel', 'Computer Engineering', 'emoon.jpg');

INSERT INTO PROFESSOR 
VALUES ('Marcelo', 'Bruce', 'Computer Engineering', 'bmarcelo.jpg');

/* PROFESSOR RATING INSERTS */

INSERT INTO PROFRATING
VALUES (1, '5/17/2017', 'He was an awesome professor. I would take him again', 0, 4, 3, 'IST215', 'A');

INSERT INTO PROFRATING
VALUES (1, '11/24/2017', 'I have taken him three times. He has taught me a lot.', 0, 5, 2, 'IST215', 'A');

INSERT INTO PROFRATING
VALUES (1, '12/28/2017', 'A very lenient professor who cares about his students', 0, 5, 3, 'IST215', 'B');

INSERT INTO PROFRATING
VALUES (1, '6/13/2017', 'He is a good teacher, but he sometimes gets off topic.', 0, 3, 3, 'IST101', 'A');

INSERT INTO PROFRATING
VALUES (2, '4/29/2017', 'I really enjoyed his class, but he was a tough grader.', 1, 4, 4, 'IST101', 'B');

INSERT INTO PROFRATING
VALUES (2, '5/01/2017', 'He really pushed me to apply myself. I have learned great skills.', 1, 4, 4, 'IST140', 'C');

INSERT INTO PROFRATING
VALUES (2, '7/28/2017', 'A little tough for my preference, but he does care about the students.', 1, 4, 5, 'IST140', 'C');

INSERT INTO PROFRATING
VALUES (2, '8/24/2017', 'Great professor. I have taken him twice now and would recommend him to take.', 1, 5, 3, 'IST220', 'A');

INSERT INTO PROFRATING
VALUES (3, '3/29/2018', 'Very, very hard professor. Would not recommend him. He is very condescending when asking questions.', 1, 2, 5, 'IST220', 'C');

INSERT INTO PROFRATING
VALUES (3, '1/7/2017', 'I would not recommend taking a class with Garcia. The workload is very involved.', 1, 1, 5, 'IST220', 'D');

INSERT INTO PROFRATING
VALUES (3, '1/24/2018', 'He was okay. Kinda tough, but as long as you are dedicated you can manage.', 1, 2, 4, 'IST220', 'B');

INSERT INTO PROFRATING
VALUES (4, '2/4/2017', 'Professor Pelz does not care about the students. He is also really mean to students.', 1, 1, 5, 'IST125', 'C');

INSERT INTO PROFRATING
VALUES (4, '9/16/2017', 'I did not like this professor and would not take another class with him', 1, 2, 5, 'IST125', 'C');

