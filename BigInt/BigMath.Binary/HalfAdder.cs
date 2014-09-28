namespace BigMath.Binary
{
	using BigMath.Boolean;

	
	public class HalfAdder : IAdder
	{
		public IHasOutput Sum { get; private set; }
		public IHasOutput Carry { get; private set; }

		public HalfAdder(IHasOutput firstInput, IHasOutput secondInput)
		{
			this.Carry =
				new And
				(
					firstInput,
					secondInput
				);

			this.Sum =
				new And
				(
					new Or
					(
						firstInput,
						secondInput
					),
					new Not
					(
						this.Carry
					)
				);
		}
	}
}
