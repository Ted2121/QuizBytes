using DataAccessDefinitionLibrary.Data_Access_Models;
using SQLAccessImplementationLibrary;
using WebApiClient.DTOs;

namespace QuizBytesWebsite.Helpers;

public class LeaderboardBuilder : ILeaderboardBuilder
{
    public List<CurrentChallengeParticipantDto> Participants { get; set; }

    public LeaderboardDto BuildLeaderboardFromParticipantList()
    {
        if (Participants == null)
        {
            InitializeChallenge();
        }

        var participantUsers = Participants.Select(participant => participant.WebUser);

        var orderedParticipants =  participantUsers.OrderByDescending(user => user.CorrectAnswers).ThenBy(user => user.ElapsedSecondsInChallenge);

        return new LeaderboardDto()
        {
            Leaderboard = orderedParticipants.ToList()
        };
    }

    // Called when the challenge starts. It's important that everytime it's a new list
    public void InitializeChallenge()
    {
        Participants = new List<CurrentChallengeParticipantDto>();
    }

    // Called when the user clicks on the "Finish" button or when time expires
    public void AddParticipantToLeaderboard(CurrentChallengeParticipantDto newParticipant)
    {
        // Ensures that a participant is not added twice to the list when the time expires
        if (!Participants.Select(participant => participant.WebUser.Username).Contains(newParticipant.WebUser.Username))
        {
            Participants.Add(newParticipant);
        }
    }

   

}
