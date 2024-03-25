using Microsoft.EntityFrameworkCore;
using SchoolManagement.MvC.Data;


namespace SchoolManagement.MvC.Extension
{
    public static class ApplicationExtension
    {
        public static void ExtensionServiceMethod(this IServiceCollection services){
                
        }

        public static void DatabBaseConnectionMethod(this IServiceCollection services, IConfiguration configuration){

           services.AddDbContext<SchoolManagementDbContext>(option=>{

            option.UseSqlServer(configuration.GetConnectionString("defaultConnection"));
           });
        }
    }
}