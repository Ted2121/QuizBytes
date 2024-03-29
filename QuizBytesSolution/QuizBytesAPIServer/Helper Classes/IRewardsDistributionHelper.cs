﻿using DataAccessDefinitionLibrary.Data_Access_Models;
using QuizBytesAPIServer.DTOs;

namespace QuizBytesAPIServer.Helper_Classes;

public interface IRewardsDistributionHelper
{
    Task DistributeChallengeRewardsAsync(LeaderboardDto leaderboard);
    Task DistributeQuizRewardsAsync(WebUserDto webUserDto);
}