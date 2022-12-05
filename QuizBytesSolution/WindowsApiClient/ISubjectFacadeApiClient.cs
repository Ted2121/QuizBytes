using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsApiClient.DTOs;

namespace WindowsApiClient
{
    public interface ISubjectFacadeApiClient
    {
        Task<IEnumerable<SubjectDto>> GetAllSubjectsAsync();
    }
}
