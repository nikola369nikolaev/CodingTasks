/*
 * Create a class Article with the following properties:

· Title – a string

· Content – a string

· Author – a string

The class should have a constructor and the following methods:

· Edit (new content) – change the old content with the new one

· ChangeAuthor (new author) – change the author

· Rename (new title) – change the title of the article

· Override the ToString method – print the article in the following format:

"{title} - {content}: {author}"

Create a program that reads an article in the following format "{title}, {content}, {author}". On the next line, you will receive a number n, representing the number of commands, which will follow after it. On the next n lines, you will be receiving the following commands:

· "Edit: {new content}"

· "ChangeAuthor: {new author}"
· "Rename: {new title}"

In the end, print the final state of the article.
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
        string[] articleStr =Console.ReadLine().Split(", ").ToArray();

        Article article = new Article(articleStr[0], articleStr[1], articleStr[2]);

        int commandCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < commandCount; i++)
        {
            string[] command = Console.ReadLine().Split(": ");

            switch (command[0])
            {
                case "Edit":
                    string newContent = command[1];
                    article.Edit(newContent);
                    break;
                case "ChangeAuthor":
                    string newAuthor = command[1];
                    article.ChangeAuthor(newAuthor);
                    break;
                case "Rename":
                    string newTitle = command[1];
                    article.Rename(newTitle);
                    break;
            }
        }

        Console.WriteLine(article);
    }
}

