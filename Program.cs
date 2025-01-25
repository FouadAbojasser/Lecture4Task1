namespace Lecture4Task1
{
    
    class Book
    {
        string title;
        string author;
        string isbn;
        bool available;

        // Constructor
        public Book(string title, string author, string isbn, bool available = true)
        {
            this.title = title;
            this.author = author;
            this.isbn = isbn;
            this.available = available;
        }

        // Setters
        public void SetTitle(string title){this.title = title;}
        public void SetAuthor(string author){this.author = author;}
        public void SetISBN (string isbn) {  this.isbn = isbn; }
        public void SetAvailable(bool available) { this.available = available; }

        // Getters
        public string GetTitle() {return this.title;}
        public string GetAuthor() {return this.author;}
        public string GetISBN() {return this.isbn;}
        public bool GetAvailable() {return this.available;}


    }
    class Library
    {
        List<Book> books = new List<Book>();

        public bool AddBook(Book book)
        {
            books.Add(book);
            return true;
        }
        public Book SearchBook(string title)
        {
            if (title != "" && title!=" ")
            {
                for (int i = 0; i < books.Count; i++)
                {
                    if (books[i].GetTitle().ToLower().Contains(title.ToLower()))
                    {
                    
                        return books[i];
                    }
                }
            }
            return null;
        }

        public bool BorrowBook(string title)
        {
            Book book = SearchBook(title);
            if (book != null && book.GetAvailable())
            {
                book.SetAvailable(false);
               return true;
            }
            return false;
        }

        public void ReturnBook (string title)
        {

        }


        public void UserInterface(string searchTitle, char whatToDo)
        {

            // whatToDo ==> (b = borrow book)  (r = return book)
            Book book = SearchBook(searchTitle);

            switch (whatToDo.ToString().ToLower())
            {
                case "b":
                    if (book != null)
                    {
                        if (book.GetAvailable())
                        {
                            Console.WriteLine($"We have a book with ' {searchTitle} ' in title and you can borrow it");
                            BorrowBook(searchTitle);
                        }
                        else
                        {
                            Console.WriteLine($"We have a book with ' {searchTitle} ' in title BUT it is already borrowed");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"There is no book in the library with title containing ' {searchTitle} ' ");
                    }
                    break;


                case "r":
                    if (book == null)
                    {
                        Console.WriteLine($"The book with title contains ' {searchTitle} ' is not borrowed from our library!");
                    }
                    else
                    {
                        if (!book.GetAvailable())
                        {
                            book.SetAvailable(true);
                            Console.WriteLine($"The book with title contains ' {searchTitle} ' has been returned successfully!");
                        }
                        else
                        {
                            Console.WriteLine($"The book with title contains ' {searchTitle} ' is already returned and is available!");
                        }
                    }
                    break;

                default:
                    Console.WriteLine("Invalid inputs");
                    break;


            }

        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            Library library = new Library();

            // Adding books to the library
            library.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565"));
            library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084"));
            library.AddBook(new Book("1984", "George Orwell", "9780451524935"));


            //Testing (b = borrow book)  (r = return book)
            // Searching and borrowing books
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nSearching and borrowing books...");
            Console.ResetColor();
            library.UserInterface("Gatsby", 'b');
            library.UserInterface("1984", 'b');
            library.UserInterface("Harry Potter", 'b'); // This book is not in the library
            library.UserInterface("1984", 'b');
            library.UserInterface("kill", 'b');

            // Returning books
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nReturning books...");
            Console.ResetColor();
            library.UserInterface("Gatsby", 'r');
            library.UserInterface("Harry Potter", 'r'); // This book is not borrowed
            library.UserInterface("Gatsby", 'r');




        }
    }
}
