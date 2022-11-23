using WebApiClient.DTOs;

namespace QuizBytesWebsite.Helpers
{
    public interface ILeaderboardBuilder
    {
        IEnumerable<CurrentChallengeParticipantDto> Participants { get; set; }

        void AddParticipantToLeaderboard(CurrentChallengeParticipantDto newParticipant);
        IEnumerable<WebUserDto> BuildLeaderboardFromParticipantList();
        void InitializeChallenge();
    }
}