using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static FashionHeaven.Infrastructure.Data.Constants.Constants.ApplicationUserConstants;
using static FashionHeaven.Infrastructure.Data.Constants.MessageConstants;


namespace FashionHeaven.Infrastructure.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(MaxLenghtUserName,MinimumLength =MinLenghtUserName)]
        public string Username { get; set; } = string.Empty;

    }
}
