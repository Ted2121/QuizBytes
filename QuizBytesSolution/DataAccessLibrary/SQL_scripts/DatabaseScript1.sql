
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Answer]') AND type in (N'U'))
DROP TABLE [dbo].Answer
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Question]') AND type in (N'U'))
DROP TABLE [dbo].Question
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserChapterUnlock]') AND type in (N'U'))
DROP TABLE [dbo].UserChapterUnlock
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CurrentChallengeParticipant]') AND type in (N'U'))
DROP TABLE [dbo].CurrentChallengeParticipant
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Chapter]') AND type in (N'U'))
DROP TABLE [dbo].Chapter
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Subject]') AND type in (N'U'))
DROP TABLE [dbo].Subject
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Course]') AND type in (N'U'))
DROP TABLE [dbo].Course
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WebUser]') AND type in (N'U'))
DROP TABLE [dbo].WebUser
GO
--there probably exists a better way to manage the deletion of these tables but due to the lack of time and manpower we decided to 
--not focus on this as it is not an issue for our project

Create table [dbo].[Course] -- done
(
PKCourseId int PRIMARY KEY IDENTITY(1,1),
[Name] varchar(100) NOT NULL UNIQUE,
[Description] varchar(500),
)
GO

Create table [dbo].[Subject] -- done
(
PKSubjectId int PRIMARY KEY IDENTITY(1,1),
[Name] varchar(100) NOT NULL UNIQUE,
FKCourseId int FOREIGN KEY REFERENCES dbo.Course(PKCourseId) On Delete Cascade, 
[Description] varchar(500),
)
GO

Create table [dbo].[Chapter] -- done
(
PKChapterId int PRIMARY KEY IDENTITY(1,1),
[Name] varchar(100) UNIQUE NOT NULL,
FKSubjectId int FOREIGN KEY REFERENCES dbo.Subject(PKSubjectId) On Delete Cascade,
[Description] varchar(500),
)
GO


Create table[dbo].[WebUser] -- done
(
PKWebUserId int PRIMARY KEY IDENTITY(1,1),
Username varchar(50) UNIQUE NOT NULL,
PasswordHash varchar(50) NOT NULL,
TotalPoints int,
AvailablePoints int,
Email varchar(300) UNIQUE NOT NULL,
PointsAccumulatedInChallenge int,
ElapsedSecondsInChallenge int,
)
GO

Create table[dbo].[CurrentChallengeParticipant] --done
(
PKCurrentChallengeParticipantId int PRIMARY KEY IDENTITY(1,1),
FKWebUserId int FOREIGN KEY REFERENCES dbo.WebUser(PKWebUserId) On Delete Cascade UNIQUE NOT NULL,
FKCourseId int FOREIGN KEY REFERENCES dbo.Course(PKCourseId) On Delete Cascade NOT NULL,
)
GO

Create table[dbo].[UserChapterUnlock] -- done
(
FKWebUserId int FOREIGN KEY REFERENCES dbo.WebUser(PKWebUserId) On Delete Cascade NOT NULL,
FKChapterId int FOREIGN KEY REFERENCES dbo.Chapter(PKChapterId) On Delete Cascade NOT NULL,
)
GO

Create table[dbo].[Question] --done
(
PKQuestionId int PRIMARY KEY IDENTITY(1,1),
QuestionText varchar(300) NOT NULL,
Hint varchar(300),
FKChapterId int FOREIGN KEY REFERENCES dbo.Chapter(PKChapterId) On Delete Cascade NOT NULL,
)
GO

Create table [dbo].[Answer] --done
(
PKAnswerId int PRIMARY KEY IDENTITY(1,1),
FKQuestionId int FOREIGN KEY REFERENCES dbo.Question(PKQuestionId) On Delete Cascade,
AnswerText varchar(250) NOT NULL,
isCorrect varchar(10),
)
GO
/*
Create trigger [dbo].[CurrentChallengeIdLimit]
On dbo.CurrentChallengeParticipant
INSTEAD of INSERT
AS
BEGIN
	INSERT INTO [CurrentChallengeParticipant](
				[FKCourseId],[FKWebUserId])
	SELECT		FKCourseId, FKWebUserId

	FROM INSERTED
	GROUP BY FKCourseId, FKWebUserId
	HAVING COUNT(FKWebUserId) <=100; --Using count because IDENTITY doesn't reset. IF a user unregisters ID will still be =>100
END
GO
*/ --commented because when tested it didn't work + we added this blockage in DAL for the CurrentChallengeParticipant
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