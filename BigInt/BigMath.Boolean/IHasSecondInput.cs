namespace BigMath.Boolean
{
	public interface IHasSecondInput : IHasFirstInput
	{
		IHasOutput SecondInput { get; }
	}
}
