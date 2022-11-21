using DataAccessDefinitionLibrary.DAO_Interfaces;
using QuizBytesAPIServer.DTOs;
using QuizBytesAPIServer.Factories;
using QuizBytesAPIServer.Helper_Classes;
using SQLAccessImplementationLibrary;
using SQLAccessImplementationLibraryUnitTest;
using System.Configuration;
using ConfigurationManager = Microsoft.Extensions.Configuration.ConfigurationManager;

namespace QuizBytesAPIServer;

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





        #region Factory DI

        builder.Services.AddScoped<IQuestionAnswerLinkFactory, QuestionAnswerLinkFactory>();
        builder.Services.AddScoped<IQuizFactory, QuizFactory>();

        #endregion

        #region Helper DI
        builder.Services.AddScoped<IRewardsDistributionHelper, RewardsDistributionHelper>();
        #endregion

        // allows us to obtain the connection string from appsettings.json

        ConfigurationManager configuration = builder.Configuration;


        #region Data Access DI

        builder.Services.AddScoped((sc) => SqlDAOFactory.CreateDAO<IAnswerDataAccess>(configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddScoped((sc) => SqlDAOFactory.CreateDAO<IChapterDataAccess>(configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddScoped((sc) => SqlDAOFactory.CreateDAO<ICourseDataAccess>(configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddScoped((sc) => SqlDAOFactory.CreateDAO<IQuestionDataAccess>(configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddScoped((sc) => SqlDAOFactory.CreateDAO<ISubjectDataAccess>(configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddScoped((sc) => SqlDAOFactory.CreateDAO<IWebUserDataAccess>(configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddScoped((sc) => SqlDAOFactory.CreateDAO<IWebUserChapterUnlockDataAccess>(configuration.GetConnectionString("DefaultConnection")));

#if DEBUG
        builder.Services.AddScoped<ICurrentChallengeParticipantDataAccess, CurrentChallengeParticipantDataAccessMock>();
#else
        builder.Services.AddScoped((sc) => SqlDAOFactory.CreateDAO<ICurrentChallengeParticipantDataAccess>(configuration.GetConnectionString("DefaultConnection")));
#endif


        #endregion

        var app = builder.Build();


        
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpLogging();

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}