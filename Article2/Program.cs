/*
 * Change the program from the previous problem in such a way, that you will be able to store a list of articles. You will not need to use the previous methods anymore (except the "ToString()"). On the first line, you will receive the number of articles. On the next lines, you will receive the articles in the same format as in the previous problem: "{title}, {content}, {author}". Print the articles.
 */

class Article
{
    public Article(string title, string content, string author)
    {
        Title = title;
        Content = content;
        Author = author;
    }

    public string Title { get; set; }
    public string Content { get; set; }
    public string Author { get; set; }

    public void Edit(string newContent)
    {
        Content = newContent;
    }

    public void ChangeAuthor(string newAuthor)
    {
        Author = newAuthor;
    }

    public void Rename(string newTitle)
    {
        Title = newTitle;
    }

    public override string ToString()
    {
        return $"{Title} - {Content}: {Author}";
    }
}

class Program
{
    public static void Main(string[] args)
    {
        List<Article> articles = new List<Article>();

        int commandCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < commandCount; i++)
        {
            string[] articleStr =Console.ReadLine().Split(", ").ToArray();

            Article article = new Article(articleStr[0], articleStr[1], articleStr[2]);
            
            articles.Add(article);
        }

        foreach (Article article in articles)
        {
            Console.WriteLine(article); 
        }
    }
}

