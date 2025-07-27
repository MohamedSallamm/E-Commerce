namespace E_Com.Core.DTO
{
    public record CategoryDTO
     (string Name, string Description);
    public record UpdateCategoryDTO
     (int Id, string Name, string Description);
}
