namespace tB_Fotografias.Models.Api
{
    public class CategoryDto
    {
        public string Name { get; set; } = string.Empty;
        public List<PhotosDto> Photos { get; set; } = [];
    }
}
