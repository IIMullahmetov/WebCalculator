using Ninject;
using System;
using System.Web;
using System.Web.Http;
using WebCalculator.Interfaces;
using WebCalculator.Models.Database;

namespace WebCalculator.Controllers
{
	public class MathController : ApiController
	{
		[Inject]
		public IMath Math { get; set; }
		[Inject]
		public IRepository Repository { get; set; }

		private string GetIPAddress()
		{
			HttpContext context = HttpContext.Current;
			string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

			if (!string.IsNullOrEmpty(ipAddress))
			{
				string[] addresses = ipAddress.Split(',');
				if (addresses.Length != 0)
				{
					return addresses[0];
				}
			}

			return context.Request.ServerVariables["REMOTE_ADDR"];
		}

		[HttpGet]
		public int Sum(int first, int second)
		{
			string address = GetIPAddress();
			int result = result = Math.Sum(first, second);
			User user = Repository.GetUserByAddress(address);
			Models.Database.Action action = Repository.GetActionByName("Sum");
			if (user != null)
			{
				CreateUserAction(action, first, second, result, user);
			}
			else
			{
				user = new User() { Address = address };
				Repository.AddUser(user);
				CreateUserAction(action, first, second, result, user);
			}
			return result;
		}

		[HttpGet]
		public int Substract(int first, int second)
		{
			string address = GetIPAddress();
			int result = result = Math.Substract(first, second);
			User user = Repository.GetUserByAddress(address);
			Models.Database.Action action = Repository.GetActionByName("Substract");
			if (user != null)
			{
				CreateUserAction(action, first, second, result, user);
			}
			else
			{
				user = new User() { Address = address };
				Repository.AddUser(user);
				CreateUserAction(action, first, second, result, user);
			}
			return result;
		}

		[HttpGet]
		public int Multiply(int first, int second)
		{
			string address = GetIPAddress();
			int result = result = Math.Multiply(first, second);
			User user = Repository.GetUserByAddress(address);
			Models.Database.Action action = Repository.GetActionByName("Multiply");
			if (user != null)
			{
				CreateUserAction(action, first, second, result, user);
			}
			else
			{
				user = new User() { Address = address };
				Repository.AddUser(user);
				CreateUserAction(action, first, second, result, user);
			}
			return result;
		}

		[HttpGet]
		public int Divide(int first, int second)
		{
			string address = GetIPAddress();
			int result = result = Math.Divide(first, second);
			User user = Repository.GetUserByAddress(address);
			Models.Database.Action action = Repository.GetActionByName("Divide");
			if (user != null)
			{
				CreateUserAction(action, first, second, result, user);
			}
			else
			{
				user = new User() { Address = address };
				Repository.AddUser(user);
				CreateUserAction(action, first, second, result, user);
			}
			return result;
		}

		[HttpGet]
		public string Get() => "default";

		private void CreateUserAction(Models.Database.Action action, int first, int second, int result, User user)
		{
			Repository.AddUserAction(new UserAction()
			{
				User = user,
				//Фиксация времени активации метода можно сделать с помощью триггера
				Time = DateTime.Now,
				First_Operand = first,
				Second_Operand = second,
				Result = result,
				Action = action
			});
		}
	}
}
