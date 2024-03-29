﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsApiClient.DTOs
{
    public class ChapterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int FKSubjectId { get; set; }
        public int UnlockPrice { get; private set; } = 256;
    }
}
