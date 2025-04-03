namespace MyTask_3
{

    public class Book {

       public string Author;
       public string Title;
       public string ISBN;
       public bool availability;

        public Book(string title, string author, bool availability , string isbn)
        {
            this.Author = author;
            this.Title = title;
            this.availability = availability;
            this.ISBN = isbn;
        }
    }// end of class Book

    public class Library
    {
        List<Book> books = new List<Book>();

        public void AddBook(Book book)
        {
            books.Add(book);
        }//end of AddBook()

        public string SearchBook(string author, string title)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Author.ToUpper() == author.ToUpper() && books[i].Title.ToUpper() == title.ToUpper())
                {
                    if (books[i].availability == false)
                    {
                        return $"Someone borrow {books[i].Title}";
                    }

                    return $"{books[i].Title} exists in the library";
                }
            }

            return "the book is not found";
        }//end of SearchBook()


        public string BorrowBook(string title)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Title.ToUpper() == title.ToUpper() && books[i].availability == true)
                {
                    books[i].availability = false;
                    return $"{books[i].Title} is borrowed";
                }
                else if(books[i].Title.ToUpper() == title.ToUpper() && books[i].availability == false)
                {
                    return $"{books[i].Title} is not available to borrow";
                }
               
            }

            return "book is not found";
        }// end of BorrowBook()

        public string ReturnBook(string title)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Title.ToUpper() == title.ToUpper() && books[i].availability == false)
                {
                    books[i].availability = true;
                    return $"{books[i].Title} is returned";
                }
              

            }

            return $"This Book is not belong to this library";
        }// end of ReturnBook()

    }// end of class Library
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            // Adding books to the library
            library.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald",true, "9780743273565"));
            library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee",true, "9780061120084"));
            library.AddBook(new Book("1984", "George Orwell",true, "9780451524935"));

            //BorrowBook() method
            Console.WriteLine(library.BorrowBook("the great gatsby"));
            Console.WriteLine(library.BorrowBook("1984"));

            //SearchBook() method
            Console.WriteLine(library.SearchBook("F. Scott Fitzgerald", "the great gatsby")); 
            Console.WriteLine(library.SearchBook("GRRM" , "A song of ice and fire"));

            //ReturnBook() method
            Console.WriteLine(library.ReturnBook("1984"));
            Console.WriteLine(library.ReturnBook("harry potter"));


        }
    }
}
