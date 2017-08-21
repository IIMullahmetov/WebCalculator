using System;
using WebCalculator.Models.Database;

namespace WebCalculator.Interfaces
{
	public interface IRepository
	{
		void AddUser(User user);
		void AddUserAction(UserAction userAction);
		User GetUserByAddress(string address);
		Models.Database.Action GetActionByName(string name);
	}
}
