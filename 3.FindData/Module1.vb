Option Strict Off

Module Module1

    Sub Main()
        ' Making database object with sample data
        Dim db = SetupDatabase.SqlCompactDatabase.Setup(True)
        ' Find Person object with Id = 1
        Dim person = db.Person.FindById(1)
        Console.WriteLine("{0} {1} {2}", person.Id, person.LastName, person.FirstName)
        'Find Person object with Id = 1 using named arguments
        person = db.Person.FindBy(Id:=1)
        Console.WriteLine("{0} {1} {2}", person.Id, person.LastName, person.FirstName)
        ' Find Person object With Lastname = lastname1 and FirstName = firstname1
        person = db.Person.FindByLastNameAndFirstName("lastname1", "firstname1")
        Console.WriteLine("{0} {1} {2}", person.Id, person.LastName, person.FirstName)
        ' Waiting for input
        Console.ReadLine()
    End Sub

End Module
