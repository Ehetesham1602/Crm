using Crm.Dtos.QualifyQuestion;
using Crm.Entities;
using Crm.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Infrastructure.Repositories
{
    public interface IQualifyQuestionRepository
    {
        Task AddAsync(QualifyQuestion entity);

        void Edit(QualifyQuestion entity);

        Task<QualifyQuestion> GetAsync(int id);

        Task<QualifyQuestionDetailDto> GetDetailAsync(int id);

        Task<JqDataTableResponse<QualifyQuestionDetailDto>> GetPagedResultAsync(JqDataTableRequest model);

        Task DeleteAsync(int id);
        Task AddQualifyAnswerAsync(List<QualifyQuestionAnswers> entity);
        Task<List<QualifyQuestionAnswers>> GetAsyncQualifyAnswer(int id);
        Task DeleteAsyncQuestionAnswer(int id);
        Task<List<QualifyQuestionDetailDto>> GetAllAsync();

    }
}
