namespace BigMath.Binary
{
	using BigMath.Boolean;

	
	public class FullAdder : IAdder
	{
		public IHasOutput Sum { get; private set; }
		public IHasOutput Carry { get; private set; }

		public FullAdder(IHasOutput firstInput, IHasOutput secondInput, IHasOutput carry)
		{
			var a = new HalfAdder(firstInput, secondInput);
			var b = new HalfAdder(a.Sum, carry);

			this.Sum = b.Sum;
			this.Carry = new Or(a.Carry, b.Carry);
		}
	}
}
