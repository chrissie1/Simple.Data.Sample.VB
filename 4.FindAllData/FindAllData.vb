Option Strict Off

Module FindAllData

    Sub Main()
        ' Making database object with sample data
        Dim db = SetupDatabase.SqlCompactDatabase.Setup(True)
        ' Find Persons with lastname = lastname1
        Dim persons = db.Person.FindAllByLastName("lastname1")
        For Each person In persons
            Console.WriteLine("{0} {1} {2}", person.Id, person.LastName, person.FirstName)
        Next
        ' Find Persons with lastname = lastname1 using named arguments
        persons = db.Person.FindAllBy(LastName:="lastname1")
        For Each person In persons
            Console.WriteLine("{0} {1} {2}", person.Id, person.LastName, person.FirstName)
        Next
        'Find Person object with address.street = "street1" 
        persons = db.Person.FindAll(db.Address.Street = "street1").WithAddress
        For Each person In persons
            Console.WriteLine("{0} {1} {2}", person.Id, person.LastName, person.FirstName)
        Next
        'Find Person object with address.street like "street%" 
        persons = db.Person.FindAll(db.Address.Street.Like("street%")).WithAddress
        For Each person In persons
            Console.WriteLine("{0} {1} {2}", person.Id, person.LastName, person.FirstName)
        Next
        ' Find Person object With Lastname = lastname1 and FirstName = firstname1
        persons = db.Person.FindAllByLastNameAndFirstName("lastname1", "firstname1")
        For Each person In persons
            Console.WriteLine("{0} {1} {2}", person.Id, person.LastName, person.FirstName)
        Next
        ' Waiting for input
        Console.ReadLine()
    End Sub

End Module
