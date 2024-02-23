using Microsoft.AspNetCore.Identity;

namespace WebIdentity.CustomDescriber
{
    public class CustomErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError PasswordTooShort(int length)
        {
            return new()
            {
                Code = "PasswordTooShort",
                Description = $"Parola en az {length} karakter olmalıdır!"
            };
        }

        public override IdentityError DuplicateUserName(string userName)
        {
            return new()
            {
                Code = "DuplicateUserName",
                Description = $"{userName} sistemde zaten kayıtlı!"
            };
        }
    }
}
