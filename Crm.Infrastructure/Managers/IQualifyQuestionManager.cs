using Crm.Dtos.QualifyQuestion;
using Crm.Entities;
using Crm.Models.QualifyQuestion;
using Crm.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Infrastructure.Managers
{
    public interface IQualifyQuestionManager
    {
        Task AddAsync(QualifyQuestionAddModel model);

        Task EditAsync(QualifyQuestionEditModel model);

        Task<QualifyQuestionDetailDto> GetDetailAsync(int id);

        Task<JqDataTableResponse<QualifyQuestionDetailDto>> GetPagedResultAsync(JqDataTableRequest model);
        Task DeleteAsync(int id);
        Task AddQualifyAnswersAsync(List<QualifyQuestionAnswerAddModel> model);
        Task<List<QualifyQuestionAnswers>> GetAnswerById(int id);
        Task<List<QualifyQuestionDetailDto>> GetAllAsync();

    }
}
