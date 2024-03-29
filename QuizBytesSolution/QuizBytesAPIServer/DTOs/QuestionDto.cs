﻿using System.ComponentModel.DataAnnotations;

namespace QuizBytesAPIServer.DTOs;

public class QuestionDto
{
    public int Id { get; set; }
    public string? QuestionText { get; set; }
    public string? Hint { get; set; }
    public int FkChapterId { get; set; }
}
