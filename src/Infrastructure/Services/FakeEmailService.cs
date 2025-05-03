
namespace Infrastructure.Services
{
    public class FakeEmailService : IEmailService
    {
        public async Task SendEmailAsync(string email, string subject, string body)
        {
            // Simulamos el envío de un email
            await Task.CompletedTask;
        }
    }
}
