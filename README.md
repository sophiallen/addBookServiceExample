# addBookServiceExample
itc172 classwork


- In the edmx data model, rightclick > update model from database. Add the new tables that you need. We just added all of them. Remember to save work right away to make them avaiable/visible elsewhere in your code. 
- In the interface, create new operation contract for adding stuff to your database (ex: add author). Ours returned bools to indicate success/failure. 
- In the interfact, click the name again to implement interfaces for the operations you added. 
- In the interface, use try / catch to add your data to the database. **REMEMBER TO USE db.SaveChanges after you db.Add()!!!**
- When adding a book remember to use datetime.now to set book entry date. 
