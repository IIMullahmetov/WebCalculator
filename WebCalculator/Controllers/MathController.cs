using Ninject;
using System;
using System.Net.Http;
using System.ServiceModel.Channels;
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

		[HttpGet]
		public int Sum(int first, int second)
		{
			string address = GetClientIp(Request);
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
			string address = GetClientIp(Request);
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
			string address = GetClientIp(Request);
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
			string address = GetClientIp(Request);
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
				Time = DateTime.Now,
				First_Operand = first,
				Second_Operand = second,
				Result = result,
				Action = action
			});
		}

		private string GetClientIp(HttpRequestMessage request = null)
		{
			request = request ?? Request;

			if (request.Properties.ContainsKey("MS_HttpContext"))
			{
				return ((HttpContextWrapper)request.Properties["MS_HttpContext"]).Request.UserHostAddress;
			}
			else if (request.Properties.ContainsKey(RemoteEndpointMessageProperty.Name))
			{
				RemoteEndpointMessageProperty prop = (RemoteEndpointMessageProperty)Request.Properties[RemoteEndpointMessageProperty.Name];
				return prop.Address;
			}
			else if (HttpContext.Current != null)
			{
				return HttpContext.Current.Request.UserHostAddress;
			}
			else
			{
				return null;
			}
		}

	}
}
