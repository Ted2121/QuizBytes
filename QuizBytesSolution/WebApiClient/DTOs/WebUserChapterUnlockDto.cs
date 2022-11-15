using DataAccessDefinitionLibrary.Data_Access_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiClient.DTOs
{
    public class WebUserChapterUnlockDto
    {
        public int WebUserId { get; set; }
        public int ChapterId { get; set; }
        public WebUser WebUserDto { get; set; }
        public Chapter ChapterDto { get; set; }
    }
}
