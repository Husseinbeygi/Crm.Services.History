namespace Domain.Contracts
{
	public interface IEntityHasUpdateDateTime
	{
		DateTime UpdateDateTime { get; }

		void SetUpdateDateTime();
	}
}
