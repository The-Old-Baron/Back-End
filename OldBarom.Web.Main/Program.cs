using OldBarom.Infra.IoC;

namespace OldBarom.Web.Main{
    public class Program{
        public static void Main(string[] args){
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRazorPages();
            builder.Services.AddInfrastructure(builder.Configuration);

            var app = builder.Build();

            if(!app.Environment.IsDevelopment()){
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            using(var scope = app.Services.CreateScope()){
                var services = scope.ServiceProvider;
            }


            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}