namespace Domain.Contracts
{
	public interface IEntityHasUpdateDateTime
	{
		public DateTime ModifiedDateTime { get; set; }

		void SetUpdateDateTime();
	}
}
