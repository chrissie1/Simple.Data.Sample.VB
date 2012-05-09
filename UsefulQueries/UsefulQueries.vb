Option Strict Off

Module UsefulQueries

    Sub Main()
        ' Making database object with sample data
        Dim db = SetupDatabase.SqlCompactDatabase.Setup(True)
        ' Find All persons but select only certain columns
        Dim persons = db.Person.All.Select(db.Person.LastName)
        For Each person In persons
            Console.WriteLine("{0}", person.LastName)
        Next
        ' Find All persons but select only certain columns and give them an alias
        persons = db.Person.All.Select(db.Person.LastName.As("Name"))
        For Each person In persons
            Console.WriteLine("{0}", person.Name)
        Next
        ' Waiting for input
        Console.ReadLine()
    End Sub

End Module
