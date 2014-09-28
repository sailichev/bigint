namespace BigMath.Test
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	using BigMath.Decimal;


	[TestClass]
	public class BigIntTest
	{
		[TestMethod]
		public void AddLittleTest()
		{
			Assert.AreEqual("2000", (new BigInt("1991") + new BigInt("9")).ToString());
			
			Assert.AreEqual("0", (new BigInt("0") + new BigInt("0")).ToString());
			Assert.AreEqual("1", (new BigInt("0") + new BigInt("1")).ToString());
			Assert.AreEqual("2", (new BigInt("1") + new BigInt("1")).ToString());
		}

		[TestMethod]
		public void AddBigTest()
		{
			var a = new BigInt("99999999999999999999999999999999999999999999999999999999999999999999999999999999");
			var b = new BigInt("11111111111111111111111111111111111111111111111111111111111111111111111111111111");

			var res = a + b;

			Assert.AreEqual("111111111111111111111111111111111111111111111111111111111111111111111111111111110", res.ToString());
		}
	}
}
