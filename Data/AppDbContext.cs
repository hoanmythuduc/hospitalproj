using Microsoft.EntityFrameworkCore;
using THUCTAP.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace THUCTAP.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AppDbContext(DbContextOptions<AppDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public DbSet<User> User { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<AppAction> Action { get; set; }
        public DbSet<FormField> FormField { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<CustomerCategory> CustomerCategory { get; set; }
        public DbSet<CustomerMaster> CustomerMaster { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<EquipmentManager> EquipmentManager { get; set; }
        public DbSet<EquipmentMaintenance> EquipmentMaintenance { get; set; }
        public DbSet<EquipmentMaintenanceLog> EquipmentMaintenanceLog { get; set; }
        public DbSet<EquipmentMaintenanceSchedule> EquipmentMaintenanceSchedule { get; set; }
        public DbSet<WaterSystemLog> WaterSystemLog { get; set; }
        public DbSet<WaterSystemDailyLog> WaterSystemDailyLog { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<EquipmentUsageLog> EquipmentUsageLog { get; set; }
        public DbSet<EquipmentUsageDailyLog> EquipmentUsageDailyLog { get; set; }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var currentUser = _httpContextAccessor.HttpContext?.User?.FindFirst("userId")?.Value
                              ?? _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value
                              ?? "System";
            var entries = ChangeTracker.Entries<BaseModel>();
            

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.createdAt = DateTime.Now;
                    entry.Entity.createdBy = currentUser; 
                    entry.Entity.updatedAt = DateTime.Now;
                    entry.Entity.updatedBy = currentUser; 
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.updatedAt = DateTime.Now;
                    entry.Entity.updatedBy = currentUser; 
                    entry.Property(x => x.createdAt).IsModified = false;
                    entry.Property(x => x.createdBy).IsModified = false;
                }
                if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;
                    entry.Entity.isActive = false;
                    entry.Entity.updatedAt = DateTime.Now;
                    entry.Entity.updatedBy = currentUser;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Menu>()
                .HasOne(m => m.parent)
                .WithMany(m => m.children)
                .HasForeignKey(m => m.parentId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<User>()
                .HasMany(u => u.group)
                .WithMany(g => g.user)
                .UsingEntity<Dictionary<string, object>>(
                "User_Group",
                right => right.HasOne<Group>().WithMany().HasForeignKey("groupid"),
                left => left.HasOne<User>().WithMany().HasForeignKey("userid")
                );
            modelBuilder.Entity<Group>()
                .HasMany(g => g.menu)
                .WithMany(m => m.group)
                .UsingEntity<Dictionary<string, object>>(
                "Group_Menu",
                 right => right.HasOne<Menu>().WithMany().HasForeignKey("menuid"),
                 left => left.HasOne<Group>().WithMany().HasForeignKey("groupid")
                );
            modelBuilder.Entity<Group>()
                 .HasMany(g => g.action)
                 .WithMany(a => a.group)
                 .UsingEntity<Dictionary<string, object>>(
                "Group_Action",
                 right => right.HasOne<AppAction>().WithMany().HasForeignKey("actionid"),
                 left => left.HasOne<Group>().WithMany().HasForeignKey("groupid")
                 );
            modelBuilder.Entity<FormField>()
                .HasOne(f => f.menu)
                .WithMany(m => m.formFields)
                .HasForeignKey(f => f.menuId)
                .OnDelete(DeleteBehavior.SetNull
            );
            modelBuilder.Entity<CustomerMaster>()
                .HasOne(c => c.Category)
                .WithMany()
                .HasForeignKey(c => c.categoryId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<EquipmentManager>()
                .HasOne(m => m.equipment)
                .WithMany(e => e.managers)
                .HasForeignKey(m => m.equipmentId)
                .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<EquipmentManager>()
                .HasOne(m => m.user)
                .WithMany()
                .HasForeignKey(m => m.userId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EquipmentMaintenance>()
                .HasOne(m => m.equipment)
                .WithMany(e => e.maintenances)
                .HasForeignKey(m => m.equipmentId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ProductCategory>()
                .HasOne(p => p.supplier)
                .WithMany()
                .HasForeignKey(p => p.supplierId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Equipment>()
                .HasOne(e => e.productCategory)
                .WithMany()
                .HasForeignKey(e => e.productCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EquipmentMaintenanceSchedule>()
                .HasOne(m => m.equipment).WithMany().HasForeignKey(m => m.equipmentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EquipmentMaintenanceSchedule>()
                .HasOne(m => m.preparer).WithMany().HasForeignKey(m => m.preparerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EquipmentMaintenanceSchedule>()
                .HasOne(m => m.approver).WithMany().HasForeignKey(m => m.approverId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<EquipmentMaintenanceLog>()
                .HasOne(m => m.executor).WithMany().HasForeignKey(m => m.executorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EquipmentMaintenanceLog>()
                .HasOne(m => m.inspector).WithMany().HasForeignKey(m => m.inspectorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EquipmentMaintenanceLog>()
                .HasOne(m => m.reviewer).WithMany().HasForeignKey(m => m.reviewerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WaterSystemLog>()
                .HasOne(w => w.equipment).WithMany().HasForeignKey(w => w.equipmentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<WaterSystemLog>()
                .HasOne(w => w.preparer).WithMany().HasForeignKey(w => w.preparerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WaterSystemLog>()
                .HasOne(w => w.inspector).WithMany().HasForeignKey(w => w.inspectorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WaterSystemLog>()
                .HasOne(w => w.reviewer).WithMany().HasForeignKey(w => w.reviewerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WaterSystemDailyLog>()
                .HasOne(d => d.waterSystemLog)
                .WithMany(w => w.dailyLogs)
                .HasForeignKey(d => d.waterSystemLogId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<WaterSystemDailyLog>()
                .HasOne(d => d.tracker).WithMany().HasForeignKey(d => d.trackerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EquipmentUsageLog>()
                .HasOne(w => w.equipment).WithMany().HasForeignKey(w => w.equipmentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EquipmentUsageLog>()
                .HasOne(w => w.preparer).WithMany().HasForeignKey(w => w.preparerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EquipmentUsageLog>()
                .HasOne(w => w.inspector).WithMany().HasForeignKey(w => w.inspectorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EquipmentUsageLog>()
                .HasOne(w => w.reviewer).WithMany().HasForeignKey(w => w.reviewerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EquipmentUsageDailyLog>()
                .HasOne(d => d.usageLog)
                .WithMany(w => w.dailyLogs)
                .HasForeignKey(d => d.usageLogId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>().HasQueryFilter(x => x.isActive);
            modelBuilder.Entity<Group>().HasQueryFilter(x => x.isActive);
            modelBuilder.Entity<Menu>().HasQueryFilter(x => x.isActive);
            modelBuilder.Entity<AppAction>().HasQueryFilter(x => x.isActive);
            modelBuilder.Entity<FormField>().HasQueryFilter(x => x.isActive);
            modelBuilder.Entity<ProductCategory>().HasQueryFilter(x => x.isActive);
            modelBuilder.Entity<CustomerCategory>().HasQueryFilter(x => x.isActive);
            modelBuilder.Entity<CustomerMaster>().HasQueryFilter(x => x.isActive);
            modelBuilder.Entity<Equipment>().HasQueryFilter(x => x.isActive);
            modelBuilder.Entity<EquipmentManager>().HasQueryFilter(x => x.isActive);
            modelBuilder.Entity<EquipmentMaintenance>().HasQueryFilter(x => x.isActive);
            modelBuilder.Entity<EquipmentMaintenanceSchedule>().HasQueryFilter(x => x.isActive);
            modelBuilder.Entity<WaterSystemLog>().HasQueryFilter(x => x.isActive);
            modelBuilder.Entity<WaterSystemDailyLog>().HasQueryFilter(x => x.isActive);
            modelBuilder.Entity<EquipmentUsageLog>().HasQueryFilter(x => x.isActive);
            modelBuilder.Entity<EquipmentUsageDailyLog>().HasQueryFilter(x => x.isActive);

            modelBuilder.Seed();
        }
    }
}