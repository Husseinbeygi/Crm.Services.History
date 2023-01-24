using Domain.Contracts;

namespace Domain.Seedwork
{
	public abstract class Entity : object,
		IEntity<System.Guid>
	{
		public Entity() : base()
		{
			Ordering = 10_000;

			InsertDateTime =
						Utility.Now;

			Id =
				Cyrus.Types.Guid.UuidCreateSequentialComb();
		}

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.Id))]

		[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
			(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
		public System.Guid Id { get; protected set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.Ordering))]

		[System.ComponentModel.DataAnnotations.Range
			(minimum: 1, maximum: 100_000,
			ErrorMessageResourceType = typeof(Resources.Messages.Validations),
			ErrorMessageResourceName = nameof(Resources.Messages.Validations.Range))]
		public int Ordering { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.InsertDateTime))]

		[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
			(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
		public System.DateTime InsertDateTime { get; private set; }
		// **********
	}
}
