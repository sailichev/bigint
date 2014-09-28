namespace BigMath.Boolean
{
	public class Not : LogicGate
	{
		public Not(IHasOutput firstInput)
			: base(firstInput)
		{

		}

		public override bool Output
		{
			get
			{
				return !FirstInput.Output;
			}
		}
	}
}
