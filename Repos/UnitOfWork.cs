using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection; 
using THUCTAP.Data;
using THUCTAP.Interfaces;

namespace THUCTAP.Repos
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly IServiceProvider _serviceProvider;

        
        private IActionRepository _actions;
        private IFormFieldRepository _formFields;
        private IGroupRepository _groups;
        private IProductCategoryRepository _productCategories;
        private IUserRepository _users;
        private ICustomerCategoryRepository _customerCategories;

        public UnitOfWork(AppDbContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }

        public IActionRepository Action =>
            _actions ??= _serviceProvider.GetRequiredService<IActionRepository>();

        public IFormFieldRepository FormField =>
            _formFields ??= _serviceProvider.GetRequiredService<IFormFieldRepository>();

        public IGroupRepository Group =>
            _groups ??= _serviceProvider.GetRequiredService<IGroupRepository>();

        public IProductCategoryRepository ProductCategory =>
            _productCategories ??= _serviceProvider.GetRequiredService<IProductCategoryRepository>();

        public IUserRepository User =>
            _users ??= _serviceProvider.GetRequiredService<IUserRepository>();

        public ICustomerCategoryRepository CustomerCategory =>
            _customerCategories ??= _serviceProvider.GetRequiredService<ICustomerCategoryRepository>();

        public async Task<int> SaveAsync()
        {
            UpdateAuditableEntities();

            return await _context.SaveChangesAsync();
        }

        private void UpdateAuditableEntities()
        {
            var entries = _context.ChangeTracker.Entries<IAuditableEntity>();

            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    entityEntry.Entity.createdAt = DateTime.Now;
                }

                if (entityEntry.State == EntityState.Modified)
                {
                    entityEntry.Entity.updatedAt = DateTime.Now;
                }
            }
        }
    }
}