using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using THUCTAP.Data;
using THUCTAP.Interfaces;
using THUCTAP.Middlewares;
using THUCTAP.Repos;
using THUCTAP.Services;
using Microsoft.OpenApi.Models;
using Serilog;


Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information() 
    .WriteTo.Console()          
    .WriteTo.File("Logs/hospital-log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

try
{
    Log.Information("Hospital is running...");

    var builder = WebApplication.CreateBuilder(args);
    builder.Host.UseSerilog();

    
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("Hospital"))
    );

    builder.Services.AddScoped<ITokenService, TokenService>();

    builder.Services.AddScoped<IAuthService, AuthService>();
    builder.Services.AddScoped<IMenuService, MenuService>();
    builder.Services.AddScoped<IActionRepository, ActionRepository>();
    builder.Services.AddScoped<IActionService, ActionService>();

    builder.Services.AddScoped<IFormFieldRepository, FormFieldRepository>();
    builder.Services.AddScoped<IFormFieldService, FormFieldService>();

    builder.Services.AddScoped<IGroupRepository, GroupRepository>();
    builder.Services.AddScoped<IGroupService, GroupService>();

    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<IUserService, UserService>();

    builder.Services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
    builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();

    builder.Services.AddScoped<ICustomerCategoryRepository, CustomerCategoryRepository>();
    builder.Services.AddScoped<ICustomerCategoryService, CustomerCategoryService>();

    builder.Services.AddScoped<ICustomerMasterRepository, CustomerMasterRepository>();
    builder.Services.AddScoped<ICustomerMasterService, CustomerMasterService>();

    builder.Services.AddScoped<IEquipmentRepository, EquipmentRepository>();
    builder.Services.AddScoped<IEquipmentService, EquipmentService>();

    builder.Services.AddScoped<IMaintenanceLogRepository, MaintenanceLogRepository>();
    builder.Services.AddScoped<IMaintenanceLogService, MaintenanceLogService>();

    builder.Services.AddScoped<IMaintenanceScheduleRepository, MaintenanceScheduleRepository>();
    builder.Services.AddScoped<IMaintenanceScheduleService, MaintenanceScheduleService>();

    builder.Services.AddScoped<IWaterSystemRepository, WaterSystemRepository>();
    builder.Services.AddScoped<IWaterSystemService, WaterSystemService>();

    builder.Services.AddScoped<IEquipmentUsageRepository, EquipmentUsageRepository>(); 
    builder.Services.AddScoped<IEquipmentUsageService, EquipmentUsageService>();

    builder.Services.AddScoped<IOrderRepository, OrderRepository>();
    builder.Services.AddScoped<IOrderService, OrderService>();

    builder.Services.AddScoped<IReportService, ReportService>();

    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
   
    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
                ValidateIssuer = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidateAudience = true,
                ValidAudience = builder.Configuration["Jwt:Audience"],
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
        });

    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAll", policyBuilder =>
        {
            policyBuilder.AllowAnyOrigin()
                         .AllowAnyHeader()
                         .AllowAnyMethod();
        });
    });

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddHttpClient();
    builder.Services.AddSwaggerGen(options =>
    {
        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = "Nhập token theo cú pháp: Bearer {token của bạn}\nVí dụ: Bearer eyJhbGciOiJIUzI1Ni...",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });

        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] {}
            }
        });
    });

    builder.Services.AddHttpContextAccessor();

    var app = builder.Build();


   //if (app.Environment.IsDevelopment())
    
        app.UseSwagger();
        app.UseSwaggerUI();
    

    app.UseHttpsRedirection();
    app.UseRouting();
    app.UseCors("AllowAll");

    app.UseAuthentication();
    app.UseAuthorization();
    app.UseMiddleware<PermissionMiddleware>();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Hệ thống gặp lỗi nghiêm trọng và không thể khởi động!");
}
finally
{
    Log.CloseAndFlush();
}