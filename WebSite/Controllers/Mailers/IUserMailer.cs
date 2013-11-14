using Mvc.Mailer;

namespace ProjectHermes.Controllers.Mailers
{ 
    public interface IUserMailer
    {
			MvcMailMessage Welcome();
	}
}