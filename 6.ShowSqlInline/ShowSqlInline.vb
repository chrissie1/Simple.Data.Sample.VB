Option Strict Off

Module ShowSqlInline

    Sub Main()
        ' Making database object with sample data
        Dim db = SetupDatabase.SqlCompactDatabase.Setup(True)
        ' Redirecting trace to console
        Trace.Listeners.Add(New TextWriterTraceListener(Console.Out))
        ' Find Person object with Id = 1
        Dim person = db.Person.FindById(1)
        Console.WriteLine("{0} {1} {2}", person.Id, person.LastName, person.FirstName)
        ' Waiting for input
        Console.ReadLine()
    End Sub

End Module
