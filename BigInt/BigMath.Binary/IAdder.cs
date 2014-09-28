namespace BigMath.Binary
{
	using BigMath.Boolean;

	
	public interface IAdder
	{
		IHasOutput Sum { get; }
		IHasOutput Carry { get; }
	}
}
