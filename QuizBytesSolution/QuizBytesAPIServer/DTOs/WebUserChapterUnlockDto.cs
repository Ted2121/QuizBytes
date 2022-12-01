using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBytesAPIServer.DTOs;

public class WebUserChapterUnlockDto
{
    public WebUserDto? WebUserDto { get; set; }
    public ChapterDto? ChapterDto { get; set; }
}
