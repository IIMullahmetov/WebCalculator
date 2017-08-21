using WebCalculator.Interfaces;

namespace WebCalculator.Models
{
	public class Math : IMath
	{
		public int Divide(int first, int second) => first / second;
		public int Multiply(int first, int second) => first * second;
		public int Substract(int first, int second) => first - second;
		public int Sum(int first, int second) => first + second;
	}
}
