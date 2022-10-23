using DataAccessDefinitionLibrary.DAO_models;

namespace QuizBytesAPIServer.DTOs.Converters
{

    public static class DtoConverter
    {
        #region Answer conversion methods
        public static AnswerDto ToDto(this Answer answerToConvert)
        {
            var answerDto = new AnswerDto();
            answerToConvert.CopyPropertiesTo(answerDto);
            return answerDto;
        }

        public static Answer FromDto(this AnswerDto answerDtoToConvert)
        {
            var answer = new Answer();
            answerDtoToConvert.CopyPropertiesTo(answer);
            return answer;
        }

        public static IEnumerable<AnswerDto> ToDtos(this IEnumerable<Answer> answersToConvert)
        {
            foreach (var answer in answersToConvert)
            {
                yield return answer.ToDto();
            }
        }

        public static IEnumerable<Answer> FromDtos(this IEnumerable<AnswerDto> answerDtosToConvert)
        {
            foreach (var answerDto in answerDtosToConvert)
            {
                yield return answerDto.FromDto();
            }
        }
        #endregion

        #region Chapter conversion methods
        public static ChapterDto ToDto(this Chapter chapterToConvert)
        {
            var chapterDto = new ChapterDto();
            chapterToConvert.CopyPropertiesTo(chapterDto);
            return chapterDto;
        }

        public static Chapter FromDto(this ChapterDto chapterDtoToConvert)
        {
            var chapter = new Chapter();
            chapterDtoToConvert.CopyPropertiesTo(chapter);
            return chapter;
        }

        public static IEnumerable<AnswerDto> ToDtos(this IEnumerable<Answer> answersToConvert)
        {
            foreach (var answer in answersToConvert)
            {
                yield return answer.ToDto();
            }
        }

        public static IEnumerable<Answer> FromDtos(this IEnumerable<AnswerDto> answerDtosToConvert)
        {
            foreach (var answerDto in answerDtosToConvert)
            {
                yield return answerDto.FromDto();
            }
        }

        #endregion
    }
}
