﻿using DataAccessDefinitionLibrary.DAO_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLAccessImplementationLibrary
{
    public static class SqlDAOFactory
    {
        public static T CreateDAO<T>(string connectionstring) where T : class
        {
            switch (typeof(T).Name)
            {
                case "IAnswerDataAccess":
                    return new AnswerDataAccess(connectionstring) as T;
                case "IChapterDataAccess":
                    return new ChapterDataAccess(connectionstring) as T;
                case "ICourseDataAccess":
                    return new CourseDataAccess(connectionstring) as T;
                case "ICurrentChallengeDataAccess":
                    return new CurrentChallengeDataAccess(connectionstring) as T;
                case "IQuestionDataAccess":
                    return new QuestionDataAccess(connectionstring) as T;
                case "ISubjectDataAccess":
                    return new SubjectDataAccess(connectionstring) as T;
                case "IWebUserChapterUnlocksDataAccess":
                    return new WebUserChapterUnlocksDataAccess(connectionstring) as T;
                case "IWebUserDataAccess":
                    return new WebUserDataAccess(connectionstring) as T;
            }
            throw new ArgumentException($"Unknown type {typeof(T).FullName}");
        }
    }
}