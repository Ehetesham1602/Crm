using Crm.Dtos.QualifyQuestion;
using Crm.Entities;
using Crm.Factories;
using Crm.Infrastructure.DataLayer;
using Crm.Infrastructure.Managers;
using Crm.Infrastructure.Repositories;
using Crm.Models.QualifyQuestion;
using Crm.Utilities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Managers
{
    public class QualifyQuestionManager: IQualifyQuestionManager
    {
        private readonly IQualifyQuestionRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        private readonly string _userId;

        public QualifyQuestionManager(IHttpContextAccessor contextAccessor,
          IQualifyQuestionRepository repository,
          IUnitOfWork unitOfWork)
        {
            _userId = contextAccessor.HttpContext.User.GetUserId();

            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(QualifyQuestionAddModel model)
        {
            await _repository.AddAsync(QualifyQuestionFactory.Create(model, _userId));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EditAsync(QualifyQuestionEditModel model)
        {
            var item = await _repository.GetAsync(model.Id);
            QualifyQuestionFactory.Create(model, item, _userId);
            _repository.Edit(item);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<QualifyQuestionDetailDto> GetDetailAsync(int id)
        {
            return await _repository.GetDetailAsync(id);
        }

        public async Task<JqDataTableResponse<QualifyQuestionDetailDto>> GetPagedResultAsync(JqDataTableRequest model)
        {
            return await _repository.GetPagedResultAsync(model);
        }
        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        ///Qualify Question Answers
        public async Task AddQualifyAnswersAsync(List<QualifyQuestionAnswerAddModel> model)
        {
            List<QualifyQuestionAnswers> item = await _repository.GetAsyncQualifyAnswer(model[0].EntityId);
            QualifyQuestionFactory.CreateQualifyAnswer(model,item);
           await  _repository.AddQualifyAnswerAsync(item);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<QualifyQuestionAnswers>> GetAnswerById(int id)
        {
            return await _repository.GetAsyncQualifyAnswer(id);
        }
    }
}

