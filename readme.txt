From http://www.entityframeworktutorial.net/code-first/simple-code-first-example.aspx

The class that inherits from DbContext is the bridge between the database and the entity classes of the project. It is responsible for interacting with data in general terms e.g. defining connection string details or performing certain actions when certain events happen. See http://www.entityframeworktutorial.net/EntityFramework4.3/dbcontext-vs-objectcontext.aspx

If no connection string is supplied to EF Code First then the database will be created in the local SQLEXPRESS instance and named per the project. In this case the database is called ConsoleApp.SchoolContext.

General steps to set up EF in a project:
	. Install it via NuGet or Package Manager
	. Create entity or domain classes with standard properties. 
	. Create context class inheriting from DbContext.
	. Add DbSet properties for each entity to the context class.
	
EF will infer properties of each table based on the entity classes. Primary keys will be ints and named either 'Id' or '<table>Id'. Foreign keys will be named '<table>_<column>Id'

    public class Student {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
		...
        public Standard Standard { get; set; }
		// There will be a column called Standard_StandardId in the database table for this entity.
    }
	
    public class Standard {
        public int StandardId { get; set; }
        public string StandardName { get; set; }

        public ICollection<Student> Students { get; set; }
    }	