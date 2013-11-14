using Mvc.Mailer;
using ProjectHermes.Models.Account;

namespace ProjectHermes.Controllers.Mailers
{
	interface IForgotPasswordMailer
	{
		MvcMailMessage ForgotPasswordMail(ForgotPasswordViewModel model);
	}
}
