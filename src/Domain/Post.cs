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
	public long CreatedTimestamp { get; set; }
	public DateTime CreatedDateTime { get; set; }
	public Guid ModifiedById { get; set; }
	public long ModifyTimestamp { get; set; }
	public DateTime ModifiedDateTime { get; set; }
	public string Action { get; set; }
	public uint ActionType { get; set; }
	public DateTime ActionDate { get; set; }
	public long ActionTimestamp { get; set; }
	public bool IsUndeletable { get; set; }
	public decimal Version { get; set; }

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
