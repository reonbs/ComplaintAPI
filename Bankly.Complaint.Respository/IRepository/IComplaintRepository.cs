using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bankly.Complaint.Respository.Models;

namespace Bankly.Complaint.Respository.IRepository
{
    public interface IComplaintRepository
    {
        Task Add(ProductComplaint productComplaint);
        void Update(ProductComplaint productComplaint);
        Task<ProductComplaint> GetById(long Id);
        Task<List<ProductComplaint>> GetAll(Expression<Func<ProductComplaint, bool>> predicate);
        bool Exist(Expression<Func<ProductComplaint, bool>> predicate);
        Task SaveChangesAsync();
        Task<ProductComplaint> GetByIdAsnotracking(long Id);
        IQueryable<ProductComplaint> GetAllAsQueryable();
    }

}
