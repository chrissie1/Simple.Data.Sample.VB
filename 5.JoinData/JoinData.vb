Option Strict Off

Module JoinData

    Sub Main()
        ' Making database object with sample data
        Dim db = SetupDatabase.SqlCompactDatabase.Setup(True)
        ' Find Persons and join with address table
        Dim persons = db.Persons.Query _
                .Join((db.Address)).On(db.Persons.AddressId = db.Address.Id) _
                .Select(db.Persons.LastName, db.Persons.FirstName, db.Address.Street, db.Address.HouseNumber)
        For Each person In persons
            Console.WriteLine("{0} {1} {2} {3}", person.LastName, person.FirstName, person.Street, person.HouseNumber)
        Next
        ' Waiting for input
        Console.ReadLine()
    End Sub

End Module
