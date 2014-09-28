namespace BigMath.Boolean
{
	public class And : LogicGate, IHasSecondInput
	{
		private readonly IHasOutput secondInput;

		public And(IHasOutput firstInput, IHasOutput secondInput)
			: base(firstInput)
		{
			this.secondInput = secondInput;
		}

		public override bool Output
		{
			get
			{
				return FirstInput.Output & SecondInput.Output;
			}
		}

		public IHasOutput SecondInput
		{
			get
			{
				return secondInput;
			}
		}
	}
}
