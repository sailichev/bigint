namespace BigMath.Boolean
{
	public abstract class LogicGate : IHasOutput, IHasFirstInput
	{
		protected readonly IHasOutput firstInput;

		protected LogicGate(IHasOutput firstInput)
		{
			this.firstInput = firstInput;
		}

		public IHasOutput FirstInput
		{
			get
			{
				return firstInput;
			}
		}

		public abstract bool Output { get; }
	}
}
