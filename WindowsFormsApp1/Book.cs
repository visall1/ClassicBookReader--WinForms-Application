namespace WindowsFormsApp1
{
    public class Book
    {
        public string Title { get; }
        public string Url { get; }
        public string CoverUrl { get; }

        public Book(string title, string url, string coverUrl)
        {
            Title = title;
            Url = url;
            CoverUrl = coverUrl;
        }
    }
}
