namespace LibrairiePoc.Infra.Dtos
{
    public class CategoryDto
    {
        public ICollection<BookDto> Books { get; set; } = new HashSet<BookDto>();

        public int Id { get; set; }

        public string Label { get; set; }
    }
}