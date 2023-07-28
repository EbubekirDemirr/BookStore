using Entities.Concrete.BaseEntities;

namespace Entities.Concrete.Authentication;

public class UserOtpCode: BaseEntity
{
    public int OtpCode { get; set; }
    public int Id { get; set; }
    public string UserId { get; set; }
}
