namespace LibrairiePoc.Infra.Dtos
{
    public class AuthorDto
    {
        public string Label { get; set; }

        public int Id { get; set; }

        public ICollection<BookDto> Books { get; set; } = new HashSet<BookDto>();
    }
}