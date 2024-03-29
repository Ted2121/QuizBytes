﻿using DataAccessDefinitionLibrary.Data_Access_Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessDefinitionLibrary.DAO_Interfaces;

public interface ICurrentChallengeParticipantDataAccess
{
    Task<int> AddWebUserToChallengeAsync(WebUser webuser, Course course);
    Task<bool> DeleteWebUserFromChallengeAsync(int id);
    Task<IEnumerable<CurrentChallengeParticipant>> GetAllRowsInChallengeAsync();
    Task<bool> ClearTempTableBeforeNextChallengeAsync();
    Task<int> GetRowAmountFromDatabaseAsync(SqlConnection connection = null, SqlTransaction transaction = null);
    Task<bool> CheckIfWebUserIsInChallengeAsync(int id);
}
