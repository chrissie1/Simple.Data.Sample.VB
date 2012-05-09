Option Strict Off

Imports System.Data.SqlServerCe
Imports System.IO
Imports Simple.Data

Public Module SqlCompactDatabase

    Function Setup(withTestData As Boolean) As Object
        CreateDatabase()
        CreateTables()
        Dim db = Database.OpenConnection(ConnectionString)
        If withTestData Then InsertTestData(db)
        Return db
    End Function

    Private Sub InsertTestData(ByVal db As Object)
        db.Address.Insert(New With {.Street = "street1", .HouseNumber = "1"})
        db.Address.Insert(New With {.Street = "street2", .HouseNumber = "2"})
        db.Person.Insert(New With {.LastName = "lastname1", .FirstName = "firstname1", .AddressId = 1})
        db.Person.Insert(New With {.LastName = "lastname1", .FirstName = "firstname2", .AddressId = 1})
        db.Person.Insert(New With {.LastName = "lastname2", .FirstName = "firstname3", .AddressId = 2})
        db.BadHabit.Insert(New With {.BadHabit = "Drinks"})
        db.BadHabit.Insert(New With {.BadHabit = "Smokes"})
        db.BadHabit.Insert(New With {.BadHabit = "Eats to much"})
        db.BadHabitPerson.Insert(New With {.BadHabitId = 1, .PersonId = 1})
        db.BadHabitPerson.Insert(New With {.BadHabitId = 2, .PersonId = 1})
        db.BadHabitPerson.Insert(New With {.BadHabitId = 3, .PersonId = 2})
        db.BadHabitPerson.Insert(New With {.BadHabitId = 3, .PersonId = 1})
        db.BadHabitPerson.Insert(New With {.BadHabitId = 3, .PersonId = 3})
    End Sub

    Public Function ConnectionString() As String
        Return "DataSource=""test.sdf""; Password=""mypassword"""
    End Function

    Private Function CreateDatabase() As SqlCeEngine
        If File.Exists("test.sdf") Then File.Delete("test.sdf")
        Dim en = New SqlCeEngine(ConnectionString)
        en.CreateDatabase()
        Return en
    End Function

    Private Sub CreateTables()
        Using cn = New SqlCeConnection(ConnectionString)
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            For Each SqlScript In CreateTableScripts()
                Using cmd = New SqlCeCommand(SqlScript, cn)
                    cmd.ExecuteNonQuery()
                End Using
            Next
        End Using
    End Sub

    Private Function CreateTableScripts() As IList(Of String)
        Dim s As New List(Of String)
        s.Add("CREATE TABLE Address (Id int IDENTITY(1,1) PRIMARY KEY, Street nvarchar (40) NOT NULL, HouseNumber nvarchar (10))")
        s.Add("CREATE TABLE Person (Id int IDENTITY(1,1) PRIMARY KEY, LastName nvarchar (40) NOT NULL, FirstName nvarchar (40), AddressId int NOT NULL)")
        s.Add("ALTER TABLE Person ADD CONSTRAINT FK_Person_Address FOREIGN KEY (AddressId) REFERENCES Address(Id)")
        s.Add("CREATE TABLE BadHabit (Id int IDENTITY(1,1) PRIMARY KEY, BadHabit nvarchar (40) NOT NULL)")
        s.Add("CREATE TABLE BadHabitPerson (BadHabitId int NOT NULL, PersonId int NOT NULL)")
        s.Add("ALTER TABLE BadHabitPerson ADD PRIMARY KEY(BadHabitId, PersonId)")
        s.Add("ALTER TABLE BadHabitPerson ADD CONSTRAINT FK_BadHabitPerson_Person FOREIGN KEY (PersonId) REFERENCES Person(Id)")
        s.Add("ALTER TABLE BadHabitPerson ADD CONSTRAINT FK_BadHabitPerson_BadHabit FOREIGN KEY (BadHabitId) REFERENCES BadHabit(Id)")
        Return s
    End Function

End Module
