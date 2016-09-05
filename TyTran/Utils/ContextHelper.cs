using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using QueryBuilder;
using TranTy.Dto;
using TranTy.Entity;

namespace TranTy.Utils
{
    public static class ContextHelper
    {
        public class PagingResult<T>
        {
            public int PageCount { get; set; }
            public int PageIndex { get; set; }
            public List<T> Data { get; set; }
        }

        public static TranTyContext CreateContext()
        {
            var context = new TranTyContext();
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ProxyCreationEnabled = false;
            context.Configuration.LazyLoadingEnabled = false;
            context.Database.Log = Console.WriteLine;
            return context;
        }

        public static List<TDto> Load<TDto, TEntity>()
            where TDto : class, IDto<TEntity>, new()
            where TEntity : class
        {
            using (var context = ContextHelper.CreateContext())
            {
                var dataSource = new List<TDto>();
                foreach (var entity in context.Set<TEntity>())
                {
                    var dto = new TDto();
                    dto.FromEntity(entity);
                    dataSource.Add(dto);
                }
                return dataSource;
            }
        }

        public static PagingResult<TDto> Load<TDto, TEntity>(QueryExpression qe, IQueryable<TEntity> includedQuery)
            where TDto : class, IDto<TEntity>, new()
            where TEntity : class
        {
            const int pageSize = 5;

            int pageCount;
            var resultQuery = QueryExpression.AddQueryExpression(includedQuery, qe, pageSize, out pageCount);

            var result = new PagingResult<TDto>
                             {
                                 PageIndex = qe.PageIndex,
                                 PageCount = pageCount,
                                 Data = new List<TDto>()
                             };

            foreach (var entity in resultQuery)
            {
                var dto = new TDto();
                dto.FromEntity(entity);
                result.Data.Add(dto);
            }

            return result;
        }

        public static void Save<T>(
            IEnumerable<IDto<T>> addedEntitties,
            IEnumerable<IDto<T>> removedEntitties,
            IEnumerable<IDto<T>> entitties) where T : class
        {
            using (var context = CreateContext())
            {
                foreach (var addedEntitty in addedEntitties)
                {
                    context.Set<T>().Add(addedEntitty.ToEntity());
                }
                foreach (var removedEntitty in removedEntitties)
                {
                    var t = removedEntitty.ToEntity();
                    context.Set<T>().Attach(t);
                    context.Entry(t).State = EntityState.Deleted;
                }
                foreach (var entitty in entitties)
                {
                    if (entitty.HasChange && entitty.GetKey() != 0)
                    {
                        context.Entry(entitty.ToEntity()).State = EntityState.Modified;
                    }
                }

                context.SaveChanges();
            }
        }
    }
}
