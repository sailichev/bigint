namespace BigMath.Decimal
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;


	public class BinaryCodedDecimal
	{
		private readonly byte[] value;

		public BinaryCodedDecimal(IEnumerable<bool> binary)
		{
			bool[] v = binary.Reverse().ToArray();

			byte[] res = new byte[v.Length / 2]; // new byte[Convert.ToInt32(Math.Ceiling(Math.Log10(Math.Pow(2, v.Length))))];

			for (int i = v.Length - 1; i >= 0; i--)
			{
				for (int j = 0; j < res.Length; j++)
					if (res[j] >= 5)
						res[j] += 3;

				bool carry = v[i];

				for (int j = 0; j < res.Length; j++)
				{
					res[j] *= 2;

					if (carry)
						res[j] += 1;

					if (res[j] > 15)
					{
						res[j] -= 16;

						carry = true;
					}
					else
						carry = false;
				}
			}

			this.value = res.Reverse().SkipWhile(_ => _ == 0).ToArray();
		}

		public BinaryCodedDecimal(IEnumerable<byte> bcd)
		{
			this.value = bcd.ToArray();
		}

		public override string ToString()
		{
			var res = new StringBuilder();

			foreach (var v in this.value.SkipWhile(_ => _ == 0))
				res.Append(v);

			if (res.Length == 0)
				res.Append(0);

			return res.ToString();
		}

		public IEnumerable<bool> ToBinary()
		{
			return this.ToReverseBinary().Reverse();
		}

		public IEnumerable<bool> ToReverseBinary()
		{
			if (IsZero(this.value))
			{
				yield return false;
			}
			else
			{
				byte[] v = (byte[])this.value.Clone();

				while (!IsZero(v))
				{
					bool carry = false;

					for (int i = 0; i < v.Length; i++)
					{
						byte add = carry ? (byte)5 : (byte)0;

						carry = v[i] % 2 > 0;

						v[i] = (byte)(v[i] / 2 + add);
					}

					yield return carry;
				}
			}
		}
		
		private static bool IsZero(byte[] value)
		{
			return value.All(_ => _ == 0);
		}
	}
}
