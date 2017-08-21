using System;
using System.Data.SqlClient;
using System.Linq;
using WebCalculator.Interfaces;
using WebCalculator.Models.Database;

namespace WebCalculator.Models
{
	public class Repository : IRepository
	{
		private Context context = new Context();
		public void AddUser(User user)
		{
			try
			{
				context.Users.Add(user);
				context.SaveChanges();
			}
			catch (SqlException)
			{
					
			}
			catch (Exception)
			{

			}
		}
		public void AddUserAction(UserAction userAction)
		{
			try
			{
				context.UserActions.Add(userAction);
				context.SaveChanges();
			}
			catch (SqlException)
			{

			}
			catch (Exception)
			{

			}
		}

		public Database.Action GetActionByName(string name)
		{
			try
			{
				return context.Actions.Where(a => a.Name == name).FirstOrDefault();
			}
			catch (SqlException)
			{
				return null;
			}
			catch (Exception)
			{
				return null;
			}
		}
		public User GetUserByAddress(string address)
		{
			try
			{
				return context.Users.Where(u => u.Address == address).FirstOrDefault();
			}
			catch(SqlException)
			{
				return null;
			}
			catch (Exception)
			{
				return null;
			}
		}
	}
}
