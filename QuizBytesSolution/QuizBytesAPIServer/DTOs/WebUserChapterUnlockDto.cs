using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBytesAPIServer.DTOs;

public class WebUserChapterUnlockDto
{
    public WebUserDto WebUser { get; set; }
    public ChapterDto Chapter { get; set; }
}
