
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[QuestionAnswers]') AND type in (N'U'))
DROP TABLE [dbo].QuestionAnswers
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Questions]') AND type in (N'U'))
DROP TABLE [dbo].Questions
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserChapterUnlocks]') AND type in (N'U'))
DROP TABLE [dbo].UserChapterUnlocks
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CurrentChallenge]') AND type in (N'U'))
DROP TABLE [dbo].CurrentChallenge
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Chapters]') AND type in (N'U'))
DROP TABLE [dbo].Chapters
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Subjects]') AND type in (N'U'))
DROP TABLE [dbo].Subjects
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Courses]') AND type in (N'U'))
DROP TABLE [dbo].Courses
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WebUsers]') AND type in (N'U'))
DROP TABLE [dbo].WebUsers
GO

Create table [dbo].[Courses] -- done
(
CourseId int PRIMARY KEY IDENTITY(1,1),
CourseName varchar NOT NULL,
[Description] varchar,
)
GO

Create table [dbo].[Subjects] -- done
(
SubjectId int PRIMARY KEY IDENTITY(1,1),
SubjectName varchar NOT NULL,
FKCourseId int FOREIGN KEY REFERENCES dbo.Courses(CourseId) On Delete Cascade, 
[Description] varchar,
)
GO

Create table [dbo].[Chapters] -- done
(
ChapterId int PRIMARY KEY IDENTITY(1,1),
ChapterName varchar,
FKSubjectId int FOREIGN KEY REFERENCES dbo.Subjects(SubjectId) On Delete Cascade,
[Description] varchar,
)
GO


Create table[dbo].[WebUsers] -- done
(
WebUserUserName varchar PRIMARY KEY,
PasswordHash varchar NOT NULL,
TotalPoints int,
AvailablePoints int,
Email varchar UNIQUE NOT NULL,
)
GO

Create table[dbo].[CurrentChallenge] --done
(
FKWebUserUserName varchar FOREIGN KEY REFERENCES dbo.WebUsers(WebUserUserName) On Delete Cascade,
FKCourseId int FOREIGN KEY REFERENCES dbo.Courses(CourseId) On Delete Cascade,
PointsAccumulated int,
ElapsedSeconds int,
)
GO

Create table[dbo].[UserChapterUnlocks] -- done
(
FKWebUserUserName varchar FOREIGN KEY REFERENCES dbo.WebUsers(WebUserUserName) On Delete Cascade,
FKChapterId int FOREIGN KEY REFERENCES dbo.Chapters(ChapterId) On Delete Cascade,
)
GO

Create table[dbo].[Questions] --done
(
QuestionId int PRIMARY KEY,
QuestionText varchar NOT NULL,
Hint varchar,
FKChapterId int FOREIGN KEY REFERENCES dbo.Chapters(ChapterId) On Delete Cascade,
)
GO

Create table [dbo].[QuestionAnswers] --done
(
FKQuestionId int FOREIGN KEY REFERENCES dbo.Questions(QuestionId) On Delete Cascade,
Answer varchar,
isCorrect varchar,
)
GO

/*
ALTER TABLE [dbo].[Subjects]  WITH CHECK ADD  CONSTRAINT [CourseId] FOREIGN KEY([FKCourseId])
REFERENCES [dbo].[Courses] ([CourseId]) ON DELETE Cascade
GO
ALTER TABLE [dbo].[Subjects] CHECK CONSTRAINT [CourseId]
GO
ALTER TABLE [dbo].[QuestionAnswers]  WITH CHECK ADD  CONSTRAINT [QuestionId] FOREIGN KEY([FKQuestionId])
REFERENCES [dbo].[Questions] ([QuestionId]) ON DELETE Cascade
GO
ALTER TABLE [dbo].[UserChapterUnlocks]  WITH CHECK ADD  CONSTRAINT [WebUserUserName] FOREIGN KEY([FKWebUserUserName])
REFERENCES [dbo].[WebUsers] ([WebUserUserName]) ON DELETE Cascade
GO
ALTER TABLE [dbo].[UserChapterUnlocks]  WITH CHECK ADD  CONSTRAINT [ChapterId] FOREIGN KEY([FKChapterId])
REFERENCES [dbo].[Chapters] ([ChapterId]) ON DELETE Cascade
GO
ALTER TABLE [dbo].[CurrentChallenge]  WITH CHECK ADD  CONSTRAINT [WebUserUserName] FOREIGN KEY([FKWebUserUserName])
REFERENCES [dbo].[WebUsers] ([WebUserUserName]) ON DELETE Cascade
GO
ALTER TABLE [dbo].[CurrentChallenge]  WITH CHECK ADD  CONSTRAINT [CourseId] FOREIGN KEY([FKCourseId])
REFERENCES [dbo].[Courses] ([CourseId]) ON DELETE Cascade
GO
ALTER TABLE [dbo].[Questions]  WITH CHECK ADD  CONSTRAINT [ChapterId] FOREIGN KEY([FKChapterId])
REFERENCES [dbo].[Chapters] ([ChapterId]) ON DELETE Cascade
GO
ALTER TABLE [dbo].[Chapters]  WITH CHECK ADD  CONSTRAINT [SubjectId] FOREIGN KEY([FKSubjectId])
REFERENCES [dbo].[Subjects] ([SubjectId]) ON DELETE Cascade
GO
*/