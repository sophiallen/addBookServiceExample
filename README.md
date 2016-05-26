# addBookServiceExample
itc172 classwork


- In the edmx data model, rightclick > update model from database. Add the new tables that you need. We just added all of them. Remember to save work right away to make them avaiable/visible elsewhere in your code. 
- In the interface, create new operation contract for adding stuff to your database (ex: add author). Ours returned bools to indicate success/failure. 
- In the interfact, click the name again to implement interfaces for the operations you added. 
- In the interface, use try / catch to add your data to the database. **REMEMBER TO USE db.SaveChanges after you db.Add()!!!**
- When adding a book remember to use datetime.now to set book entry date. 
- In order to prevent double-adding authors (or other pre-sets) loop through the database and grab the first match. This requires that the value already exists the table you're going to loop through, i.e. you've added the author to the db before matching a book to that author. 
- For testing, we added a new project to the solution, of type unit test project. It's in the visual c > test category in the add project browser. 
  - Within the test project, add reference to the project solution you want to test. (we weren't able to do this in class. :P ). 
