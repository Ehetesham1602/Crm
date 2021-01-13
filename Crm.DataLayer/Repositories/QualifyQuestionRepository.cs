using Crm.Dtos.QualifyQuestion;
using Crm.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using Crm.Utilities;
using Crm.Infrastructure.Repositories;

namespace Crm.DataLayer.Repositories
{
    public class QualifyQuestionRepository : IQualifyQuestionRepository
    {
        private readonly DataContext _dataContext;

        public QualifyQuestionRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddAsync(QualifyQuestion entity)
        {
            await _dataContext.QualifyQuestion.AddAsync(entity);
        }

        public void Edit(QualifyQuestion entity)
        {
            _dataContext.QualifyQuestion.Update(entity);
        }

        public async Task<QualifyQuestion> GetAsync(int id)
        {
            return await _dataContext.QualifyQuestion.FindAsync(id);
        }

        public async Task<QualifyQuestionDetailDto> GetDetailAsync(int id)
        {
            return await (from s in _dataContext.QualifyQuestion
                          where s.Id == id
                          select new QualifyQuestionDetailDto
                          {
                              Id = s.Id,
                              QuestionCode = s.QuestionCode,
                              QuestionName = s.QuestionName,
                              FieldTypeId = s.FieldTypeId,
                              Options = s.Options
                          })
                          .AsNoTracking()
                          .SingleOrDefaultAsync();
        }

        public async Task<JqDataTableResponse<QualifyQuestionDetailDto>> GetPagedResultAsync(JqDataTableRequest model)
        {
            if (model.Length == 0)
            {
                model.Length = Constants.DefaultPageSize;
            }

            var filterKey = model.Search.Value;

            var linqStmt = (from s in _dataContext.QualifyQuestion
                            where s.Status != Constants.RecordStatus.Deleted && (filterKey == null || EF.Functions.Like(s.QuestionName, "%" + filterKey + "%"))
                            select new QualifyQuestionDetailDto
                            {
                                Id = s.Id,
                                QuestionName = s.QuestionName,
                                QuestionCode = s.QuestionCode,
                                FieldTypeId = s.FieldTypeId,
                                Options = s.Options
                            })
                            .AsNoTracking();

            var sortExpresstion = model.GetSortExpression();

            var pagedResult = new JqDataTableResponse<QualifyQuestionDetailDto>
            {
                RecordsTotal = await _dataContext.LeadSource.CountAsync(x => x.Status != Constants.RecordStatus.Deleted),
                RecordsFiltered = await linqStmt.CountAsync(),
                Data = await linqStmt.OrderBy(sortExpresstion).Skip(model.Start).Take(model.Length).ToListAsync()
            };
            return pagedResult;
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _dataContext.QualifyQuestion.FindAsync(id);
            data.Status = Constants.RecordStatus.Deleted;
            _dataContext.QualifyQuestion.Update(data);
        }


        ///Qualify Question Answer
        ///
        public async Task AddQualifyAnswerAsync(List<QualifyQuestionAnswers> entity)
        {
            foreach (var item in entity)
            {
                await _dataContext.QualifyQuestionAnswers.AddAsync(item);
            }

        }

        public async Task<List<QualifyQuestionAnswers>> GetAsyncQualifyAnswer(int id)
        {
            return await (from s in _dataContext.QualifyQuestionAnswers
                          where s.EntityId == id
                          select new QualifyQuestionAnswers
                          {
                              Id = s.Id,
                              EntityId = s.EntityId,
                              QuestionId = s.QuestionId,
                              Answer = s.Answer
                          })
                         .AsNoTracking()
                         .ToListAsync();
        }

        public async Task DeleteAsyncQuestionAnswer(int id)
        {
            var data = await _dataContext.QualifyQuestionAnswers.Where(x => x.EntityId == id).ToListAsync();
            foreach (var item in data)
            {
                _dataContext.QualifyQuestionAnswers.Remove(item);
            }

        }
        public async Task<List<QualifyQuestionDetailDto>> GetAllAsync()
        {
            return await (from s in _dataContext.QualifyQuestion
                          select new QualifyQuestionDetailDto
                          {
                              Id = s.Id,
                              QuestionCode = s.QuestionCode,
                              QuestionName = s.QuestionName,
                              FieldTypeId = s.FieldTypeId,
                              Options = s.Options
                          })
                          .AsNoTracking()
                          .ToListAsync();
        }

    }
}

