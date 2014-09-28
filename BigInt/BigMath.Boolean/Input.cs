namespace BigMath.Boolean
{
	using System;


	public class Input : IHasOutput
	{
		private readonly Func<bool> getValue;

		public Input(Func<bool> getValue)
		{
			this.getValue = getValue;
		}
		public Input(bool value)
			: this(() => value)
		{

		}

		public bool Output
		{
			get
			{
				return getValue();
			}
		}

		public static readonly Input False = new Input(false);
		public static readonly Input True = new Input(true);
	}
}
