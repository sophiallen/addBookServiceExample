using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LoginService" in code, svc and config file together.
public class LoginService : ILoginService
{
    BookReviewDbEntities db = new BookReviewDbEntities();

    public bool AddAuthor(Author a)
    {
        Author author = new Author();
        author.AuthorName = a.AuthorName;
        bool result = true;
        try
        {
            db.Authors.Add(author);
            db.SaveChanges();
        }
        catch(Exception ex)
        {
            result = false;
            //throw ex;
        }
        return result;
    }

    public bool AddBook(Book b)
    {
        Book newBook = new Book();
        newBook.BookEntryDate = DateTime.Now;
        newBook.BookISBN = b.BookISBN;       

        foreach(Author a in b.Authors)
        {
            Author author = db.Authors.FirstOrDefault(x => x.AuthorName.Equals(a.AuthorName));
            newBook.Authors.Add(author);
        }

        foreach(Category c in b.Categories)
        {
            Category cat = db.Categories.FirstOrDefault(x => x.CategoryName.Equals(c.CategoryName));
            newBook.Categories.Add(cat);
        }

        bool result = true;
        try
        {
            db.Books.Add(newBook);
            db.SaveChanges();
        }
        catch
        {
            result = false;
        }

        return result;
    }

    public bool AddReview(Review r)
    {
        //note: assumes we've added the book/author already. 
        bool result = true;
        try
        {
            db.Reviews.Add(r);
            db.SaveChanges();
        }
        catch
        {
            result = false;
        }

        return result;
    }

    public bool RegisterReviewer(Reviewer r)
    {
        bool result = true;

        int pass = db.usp_NewReviewer(r.ReviewerUserName, r.ReviewerFirstName, r.ReviewerLastName, r.ReviewerEmail, r.ReviewPlainPassword);
        if( pass== -1)
        {
            result = false;
        }

        return result;
    }

    public int ReviewerLogin(string userName, string password)
    {
        int reviewerKey = 0;
        int result = db.usp_ReviewerLogin(userName, password);
        if(result != -1)
        {
            var key = (from r in db.Reviewers
                      where r.ReviewerUserName.Equals(userName)
                      select new { r.ReviewerKey }).FirstOrDefault();

            reviewerKey = key.ReviewerKey;

        }    
        return reviewerKey;
    }
}
