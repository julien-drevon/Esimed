namespace LibrairiePoc.Infra.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public AuthorDto Author { get; set; }

        public CategoryDto Category { get; set; }

        public int AuthorId { get; set; }

        public int CategoryId { get; set; }

        public string Isbn { get; set; }
    }
}