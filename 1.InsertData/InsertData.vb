Option Strict Off

Module InsertData

    Sub Main()
        ' Making database object with sample data
        Dim db = SetupDatabase.SqlCompactDatabase.Setup(False)
        ' Inserting data in Address table using anonymous object
        db.Address.Insert(New With {.Street = "street1", .HouseNumber = "1"})
        ' Inserting data in Persons table using named parameters
        db.Person.Insert(LastName:="lastname1", FirstName:="firstname1", AddressId:=1)
        ' Showing data in address table
        Dim address = db.Address.All.ToList()(0)
        Console.WriteLine("{0} {1} {2}", address.Id, address.Street, address.HouseNumber)
        ' Showing data in persons table
        Dim person = db.Person.All.ToList()(0)
        Console.WriteLine("{0} {1} {2}", person.Id, person.LastName, person.FirstName)
        ' Waiting for input
        Console.ReadLine()
    End Sub

End Module
