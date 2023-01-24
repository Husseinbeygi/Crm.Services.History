using Cyrus.DDD;
using Domain.Contracts;
using Domain.Seedwork;

namespace Domain;

public class Post : Entity,
					IAggregateRoot,
					IEntityHasIsUndeletable,
					IEntityHasUpdateDateTime
{
	public Guid TraceId { get; set; }
	public Guid ObjectId { get; set; }
	public string ObjectType { get; set; }
	public Guid OwnerId { get; set; }
	public Guid BusinessUnitId { get; set; }
	public Guid TenantId { get; set; }
	public Guid CreatedById { get; set; }
	public string CreatedBy { get; set; }
	public long InsertTimestamp { get; set; }
	public Guid ModifiedById { get; set; }
	public string ModifiedBy { get; set; }
	public long ModifyTimestamp { get; set; }
	public DateTime ModifiedDateTime { get; set; }
	public string Action { get; set; }
	public Guid ActionType { get; set; }
	public Guid ActionDate { get; set; }
	public Guid ActionTimestamp { get; set; }
	public bool IsUndeletable { get; set; }
	public int Version { get; set; }

	IReadOnlyList<IDomainEvent> IAggregateRoot.DomainEvents => new List<IDomainEvent>();

	public void ClearDomainEvents()
	{
		throw new NotImplementedException();
	}

	public void SetUpdateDateTime()
	{
		throw new NotImplementedException();
	}
}
