namespace BigMath.Decimal
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using BigMath.Binary;
	using BigMath.Boolean;


	public class BigInt
	{
		private readonly BinaryCodedDecimal bcd;
		
		public BigInt(string integerValue)
			: this(new BinaryCodedDecimal(integerValue.Select(_ => Convert.ToByte(_.ToString()))))
		{

		}

		private BigInt(BinaryCodedDecimal bcd)
		{
			this.bcd = bcd;
		}
		
		public override string ToString()
		{
			return this.bcd.ToString();
		}


		public static BigInt operator +(BigInt first, BigInt second)
		{
			var res = BinaryAdd(first.bcd.ToReverseBinary(), second.bcd.ToReverseBinary()).Reverse();

			return new BigInt(new BinaryCodedDecimal(res));
		}

		private static IEnumerable<bool> BinaryAdd(IEnumerable<bool> first, IEnumerable<bool> second)
		{
			var _first  = first.ToArray();
			var _second = second.ToArray();

			var length = Math.Max(_first.Length, _second.Length);

			_first  = _first.Concat( Enumerable.Repeat(false, length - _first.Length )).ToArray();
			_second = _second.Concat(Enumerable.Repeat(false, length - _second.Length)).ToArray();

			IAdder a = new HalfAdder
			(
				new Input(_first[0]),
				new Input(_second[0])
			);

			yield return a.Sum.Output;

			for (int i = 1; i < length; i++)
			{
				a = new FullAdder
				(
					new Input(_first[i]),
					new Input(_second[i]),
					a.Carry
				);

				yield return a.Sum.Output;
			}

			yield return a.Carry.Output;
		}
	}
}
