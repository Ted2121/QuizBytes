using WebApiClient.DTOs;

namespace QuizBytesWebsite.Helpers
{
    public interface ILeaderboardBuilder
    {
        IEnumerable<CurrentChallengeParticipantDto> Participants { get; set; }

        void AddParticipantToLeaderboard(CurrentChallengeParticipantDto newParticipant);
        LeaderboardDto BuildLeaderboardFromParticipantList();
        void InitializeChallenge();
    }
}