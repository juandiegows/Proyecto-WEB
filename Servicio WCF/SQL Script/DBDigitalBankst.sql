Create database  DBDigitalBankst;
go

use DBDigitalBankst;
go
CREATE TABLE Sexo (
	Nombre char(1) NOT NULL PRIMARY KEY)
GO
CREATE TABLE Usuario
(
Id int primary key identity not null,
Nombre varchar(100) not null,
FechaNacimiento date not null,
Sexo char(1) not null FOREIGN KEY(Sexo)  References Sexo(Nombre)
);
go


INSERT Sexo ([Nombre]) VALUES (N'F'),(N'M')
GO



CREATE PROCEDURE Obtener
AS
BEGIN
	SELECT * from Usuario
END
GO

CREATE PROCEDURE Actualizar
@Id int,
@Nombre varchar(100),
@FechaNacimiento date,
@Sexo char(1)
AS
BEGIN
	update Usuario set Nombre = @Nombre, FechaNacimiento = @FechaNacimiento, Sexo = @Sexo
	where Id = @Id
END
GO


CREATE PROCEDURE Agregar
@Nombre varchar(100),
@FechaNacimiento date,
@Sexo char(1)
AS
BEGIN
	insert into Usuario (Nombre, FechaNacimiento, Sexo) values (@Nombre,@FechaNacimiento,@Sexo)
END
GO

CREATE PROCEDURE Eliminar
@Id int
AS
BEGIN
	delete from Usuario where Id = @Id
END
GO