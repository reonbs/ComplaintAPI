using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bankly.Complaint.Respository.IRepository;
using Bankly.Complaint.Respository.Models;
using Microsoft.EntityFrameworkCore;

namespace Bankly.Complaint.Respository.Repository
{
    public class ComplaintRepository : IComplaintRepository,IDisposable
    {
        private AppDbContext _appDbContext;

        public ComplaintRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Add(ProductComplaint  productComplaint)
        {
            _appDbContext.Add(productComplaint);
            await _appDbContext.SaveChangesAsync();
        }

        public void Update(ProductComplaint productComplaint)
        {
            _appDbContext.Attach(productComplaint);
            _appDbContext.Entry(productComplaint).State = EntityState.Modified;
        }

        public async Task<ProductComplaint> GetById(long Id)
        {
            return await _appDbContext.ProductComplaints.FirstOrDefaultAsync(x => x.Id == Id && !x.IsDeleted);
        }

        public async Task<ProductComplaint> GetByIdAsnotracking(long Id)
        {
            return await _appDbContext.ProductComplaints.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id && !x.IsDeleted);
        }

        public async Task<List<ProductComplaint>> GetAll(Expression<Func<ProductComplaint, bool>> predicate)
        {
            return await _appDbContext.ProductComplaints.Where(predicate).ToListAsync();
        }

        public IQueryable<ProductComplaint> GetAllAsQueryable()
        {
            return _appDbContext.ProductComplaints.AsQueryable();
        }

        public bool Exist(Expression<Func<ProductComplaint, bool>> predicate)
        {
            return _appDbContext.ProductComplaints.Where(predicate).Any();
        }

        public async Task SaveChangesAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _appDbContext.Dispose();
            _appDbContext = null;
        }
    }
}
