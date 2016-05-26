using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ILoginService" in both code and config file together.
[ServiceContract]
public interface ILoginService
{
    [OperationContract]
    bool RegisterReviewer(Reviewer r);

    [OperationContract]
    int ReviewerLogin(string userName, string password);

    [OperationContract]
    bool AddAuthor(Author a);

    [OperationContract]
    bool AddBook(Book b);

    [OperationContract]
    bool AddReview(Review r);
}
