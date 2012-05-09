Option Strict Off

Module UpdateData

    Sub Main()
        ' Making database object with sample data
        Dim db = SetupDatabase.SqlCompactDatabase.Setup(True)
        ' Showing data in address table with id = 1
        Dim address = db.Address.FindById(1)
        Console.WriteLine("{0} {1} {2}", address.Id, address.Street, address.HouseNumber)
        ' Showing data in address table with id = 2
        address = db.Address.FindById(2)
        Console.WriteLine("{0} {1} {2}", address.Id, address.Street, address.HouseNumber)
        ' Showing data in persons table with id = 1
        Dim person = db.Person.FindById(1)
        Console.WriteLine("{0} {1} {2}", person.Id, person.LastName, person.FirstName)
        ' Updating data in Address table using anonymous object using ById
        db.Address.UpdateById(New With {.Id = 1, .Street = "street1updated", .HouseNumber = "1updated"})
        ' Updating data in Address table using named parameters
        db.Address.UpdateById(Id:=2, Street:="street2updated", HouseNumber:="2updated")
        ' Updating data in Persons table using anonymous object using primary key
        db.Person.Update(New With {.Id = 1, .LastName = "lastname1updated", .FirstName = "firstname1updated", .AddressId = 1})
        ' Showing data in address table with id = 1
        address = db.Address.FindById(1)
        Console.WriteLine("{0} {1} {2}", address.Id, address.Street, address.HouseNumber)
        ' Showing data in address table with = 1
        address = db.Address.FindById(2)
        Console.WriteLine("{0} {1} {2}", address.Id, address.Street, address.HouseNumber)
        ' Showing data in persons table with id = 1
        person = db.Person.FindById(1)
        Console.WriteLine("{0} {1} {2}", person.Id, person.LastName, person.FirstName)
        ' Waiting for input
        Console.ReadLine()
    End Sub

End Module
