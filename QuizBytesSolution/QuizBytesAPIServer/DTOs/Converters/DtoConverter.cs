﻿using DataAccessDefinitionLibrary.Data_Access_Models;

namespace QuizBytesAPIServer.DTOs.Converters;

public static class DtoConverter
{
    #region Answer conversion methods
    public static AnswerDto ToDto(this Answer answerToConvert)
    {
        var answerDto = new AnswerDto();
        answerToConvert.CopyPropertiesTo(answerDto);
        return answerDto;
    }

    public static Answer FromDto(this AnswerDto answerDtoToConvert)
    {
        var answer = new Answer();
        answerDtoToConvert.CopyPropertiesTo(answer);
        return answer;
    }

    public static IEnumerable<AnswerDto> ToDtos(this IEnumerable<Answer> answersToConvert)
    {
        foreach (var answer in answersToConvert)
        {
            yield return answer.ToDto();
        }
    }

    public static IEnumerable<Answer> FromDtos(this IEnumerable<AnswerDto> answerDtosToConvert)
    {
        foreach (var answerDto in answerDtosToConvert)
        {
            yield return answerDto.FromDto();
        }
    }
    #endregion

    #region Chapter conversion methods
    public static ChapterDto ToDto(this Chapter chapterToConvert)
    {
        var chapterDto = new ChapterDto();
        chapterToConvert.CopyPropertiesTo(chapterDto);
        return chapterDto;
    }
    public static Chapter FromDto(this ChapterDto chapterDtoToConvert)
    {
        var chapter = new Chapter();
        chapterDtoToConvert.CopyPropertiesTo(chapter);
        return chapter;
    }

    public static IEnumerable<ChapterDto> ToDtos(this IEnumerable<Chapter> chaptersToConvert)
    {
        foreach (var chapter in chaptersToConvert)
        {
            yield return chapter.ToDto();
        }
    }

    public static IEnumerable<Chapter> FromDtos(this IEnumerable<ChapterDto> chapterDtosToConvert)
    {
        foreach (var chapterDto in chapterDtosToConvert)
        {
            yield return chapterDto.FromDto();
        }
    }

    #endregion

    #region Course conversion methods

    public static CourseDto ToDto(this Course courseToConvert)
    {
        var courseDto = new CourseDto();
        courseToConvert.CopyPropertiesTo(courseDto);
        return courseDto;
    }

    public static Course FromDto(this CourseDto courseDtoToConvert)
    {
        var course = new Course();
        courseDtoToConvert.CopyPropertiesTo(course);
        return course;
    }

    public static IEnumerable<CourseDto> ToDtos(this IEnumerable<Course> coursesToConvert)
    {
        foreach (var course in coursesToConvert)
        {
            yield return course.ToDto();
        }
    }

    public static IEnumerable<Course> FromDtos(this IEnumerable<CourseDto> courseDtosToConvert)
    {
        foreach (var courseDto in courseDtosToConvert)
        {
            yield return courseDto.FromDto();
        }
    }

    #endregion

    #region CurrentChallengeParticipant conversion methods

    public static CurrentChallengeParticipantDto ToDto(this CurrentChallengeParticipant currentChallengeParticipantToConvert)
    {
        var currentChallengeParticipantDto = new CurrentChallengeParticipantDto();
        currentChallengeParticipantToConvert.CopyPropertiesTo(currentChallengeParticipantDto);
        return currentChallengeParticipantDto;
    }

    public static CurrentChallengeParticipant FromDto(this CurrentChallengeParticipantDto currentChallengeParticipantDtoToConvert)
    {
        var currentChallengeParticipant = new CurrentChallengeParticipant();
        currentChallengeParticipantDtoToConvert.CopyPropertiesTo(currentChallengeParticipant);
        return currentChallengeParticipant;
    }

    public static IEnumerable<CurrentChallengeParticipantDto> ToDtos(this IEnumerable<CurrentChallengeParticipant> currentChallengeParticipantsToConvert)
    {
        foreach (var currentChallengeParticipant in currentChallengeParticipantsToConvert)
        {
            yield return currentChallengeParticipant.ToDto();
        }
    }

    public static IEnumerable<CurrentChallengeParticipant> FromDtos(this IEnumerable<CurrentChallengeParticipantDto> currentChallengeParticipantDtosToConvert)
    {
        foreach (var currentChallengeParticipantDto in currentChallengeParticipantDtosToConvert)
        {
            yield return currentChallengeParticipantDto.FromDto();
        }
    }

    #endregion

    #region Question conversion methods

    public static QuestionDto ToDto(this Question questionToConvert)
    {
        var questionDto = new QuestionDto();
        questionToConvert.CopyPropertiesTo(questionDto);
        return questionDto;
    }

    public static Question FromDto(this QuestionDto questionDtoToConvert)
    {
        var question = new Question();
        questionDtoToConvert.CopyPropertiesTo(question);
        return question;
    }

    public static IEnumerable<QuestionDto> ToDtos(this IEnumerable<Question> questionsToConvert)
    {
        foreach (var question in questionsToConvert)
        {
            yield return question.ToDto();
        }
    }

    public static IEnumerable<Question> FromDtos(this IEnumerable<QuestionDto> questionDtosToConvert)
    {
        foreach (var questionDto in questionDtosToConvert)
        {
            yield return questionDto.FromDto();
        }
    }

    #endregion

    #region Subject conversion methods

    public static SubjectDto ToDto(this Subject subjectToConvert)
    {
        var subjectDto = new SubjectDto();
        subjectToConvert.CopyPropertiesTo(subjectDto);
        return subjectDto;
    }

    public static Subject FromDto(this SubjectDto subjectDtoToConvert)
    {
        var subject = new Subject();
        subjectDtoToConvert.CopyPropertiesTo(subject);
        return subject;
    }

    public static IEnumerable<SubjectDto> ToDtos(this IEnumerable<Subject> subjectsToConvert)
    {
        foreach (var subject in subjectsToConvert)
        {
            yield return subject.ToDto();
        }
    }

    public static IEnumerable<Subject> FromDtos(this IEnumerable<SubjectDto> subjectDtosToConvert)
    {
        foreach (var subjectDto in subjectDtosToConvert)
        {
            yield return subjectDto.FromDto();
        }
    }

    #endregion

    #region WebUser conversion methods

    public static WebUserDto ToDto(this WebUser webUserToConvert)
    {
        var webUserDto = new WebUserDto();
        webUserToConvert.CopyPropertiesTo(webUserDto);
        return webUserDto;
    }

    public static WebUser FromDto(this WebUserDto webUserDtoToConvert)
    {
        var webUser = new WebUser();
        webUserDtoToConvert.CopyPropertiesTo(webUser);
        return webUser;
    }

    public static IEnumerable<WebUserDto> ToDtos(this IEnumerable<WebUser> webUsersToConvert)
    {
        foreach (var webUser in webUsersToConvert)
        {
            yield return webUser.ToDto();
        }
    }

    public static IEnumerable<WebUser> FromDtos(this IEnumerable<WebUserDto> webUserDtosToConvert)
    {
        foreach (var webUserDto in webUserDtosToConvert)
        {
            yield return webUserDto.FromDto();
        }
    }

    #endregion

    #region WebUserChapterUnlock conversion methods
    // currently unusable

    //public static WebUserChapterUnlockDto ToDto(this WebUserChapterUnlock webUserChapterUnlocksToConvert)
    //{
    //    var webUserChapterUnlocksDto = new WebUserChapterUnlockDto();
    //    webUserChapterUnlocksToConvert.CopyPropertiesTo(webUserChapterUnlocksDto);
    //    return webUserChapterUnlocksDto;
    //}

    //public static WebUserChapterUnlock FromDto(this WebUserChapterUnlockDto webUserChapterUnlocksDtoToConvert)
    //{
    //    var webUserChapterUnlocks = new WebUserChapterUnlock();
    //    webUserChapterUnlocksDtoToConvert.CopyPropertiesTo(webUserChapterUnlocks);
    //    return webUserChapterUnlocks;
    //}

    //public static IEnumerable<WebUserChapterUnlockDto> ToDtos(this IEnumerable<WebUserChapterUnlock> webUserChapterUnlocksToConvert)
    //{
    //    foreach (var webUserChapterUnlocks in webUserChapterUnlocksToConvert)
    //    {
    //        yield return webUserChapterUnlocks.ToDto();
    //    }
    //}

    //public static IEnumerable<WebUserChapterUnlock> FromDtos(this IEnumerable<WebUserChapterUnlockDto> webUserChapterUnlocksDtosToConvert)
    //{
    //    foreach (var webUserChapterUnlocksDto in webUserChapterUnlocksDtosToConvert)
    //    {
    //        yield return webUserChapterUnlocksDto.FromDto();
    //    }
    //}

    #endregion
}
