﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiClient.DTOs
{
    public class CurrentChallengeParticipantDto
    {
        public WebUserDto WebUser { get; set; }
        public CourseDto Course { get; set; }
    }
}
