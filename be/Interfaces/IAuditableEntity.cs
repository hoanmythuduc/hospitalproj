namespace THUCTAP.Interfaces
{
    public interface IAuditableEntity
    {
        DateTime createdAt { get; set; }
        DateTime updatedAt { get; set; }

        //token và createby updateby
    }
}