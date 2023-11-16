using System.Diagnostics.CodeAnalysis;


namespace ClothingStore.Models.DTO.SessionDTOs
{
    [ExcludeFromCodeCoverage]
    public class SessionResponseDTO
    {
        public string Token { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }
    }
}
