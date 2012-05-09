Option Strict Off

Module EagerLoading

    Sub Main()
        ' Making database object with sample data
        Dim db = SetupDatabase.SqlCompactDatabase.Setup(True)
        ' Redirecting trace to console
        Trace.Listeners.Add(New TextWriterTraceListener(Console.Out))
        ' Find Person object with Id = 1 Lazy loads address
        Dim person = db.Person.FindById(1)
        Console.WriteLine("{0} {1} {2}", person.Id, person.LastName, person.FirstName)
        Console.WriteLine("{0} {1} {2}", person.Address.Id, person.Address.Street, person.Address.HouseNumber)
        ' Find Person object with Id = 1 eagerly loads address
        ' This does not work in VB.Net
        ' person = db.Person.FindById(1).WithAddress
        ' But this does
        person = db.Person.FindAllById(1).WithAddress.FirstOrDefault
        Console.WriteLine("{0} {1} {2}", person.Id, person.LastName, person.FirstName)
        Console.WriteLine("{0} {1} {2}", person.Address.Id, person.Address.Street, person.Address.HouseNumber)
        ' Waiting for input
        Console.ReadLine()
    End Sub

End Module
