using DataAccessDefinitionLibrary.DAO_Interfaces;
using QuizBytesAPIServer.Factories;
using QuizBytesAPIServer.Helper_Classes;
using SQLAccessImplementationLibrary;

namespace QuizBytesAPIServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region Data Access DI

            builder.Services.AddSingleton<IAnswerDataAccess, AnswerDataAccess>();
            builder.Services.AddSingleton<IChapterDataAccess, ChapterDataAccess>();
            builder.Services.AddSingleton<ICourseDataAccess, CourseDataAccess>();
            builder.Services.AddSingleton<IQuestionDataAccess, QuestionDataAccess>();
            builder.Services.AddSingleton<ISubjectDataAccess, SubjectDataAccess>();
            builder.Services.AddSingleton<IWebUserDataAccess, WebUserDataAccess>();
            builder.Services.AddSingleton<IWebUserChapterUnlockDataAccess, WebUserChapterUnlockDataAccess>();
            builder.Services.AddSingleton<ICurrentChallengeParticipantDataAccess, CurrentChallengeParticipantDataAccess>();
            #endregion

            #region Factory DI

            builder.Services.AddSingleton<IQuestionAnswerLinkFactory, QuestionAnswerLinkFactory>();
            builder.Services.AddSingleton<IQuizFactory, QuizFactory>();

            #endregion

            #region Helper DI
            builder.Services.AddSingleton<IRewardsDistributionHelper, RewardsDistributionHelper>();
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}