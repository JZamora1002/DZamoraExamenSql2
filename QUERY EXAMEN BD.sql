CREATE DATABASE DZamoraExamenCrudSqlClient

CREATE TABLE Autor(
IdAutor INT PRIMARY KEY IDENTITY(1,1),
Nombre VARCHAR(50))

CREATE TABLE Editorial(
IdEditorial INT PRIMARY KEY IDENTITY(1,1),
Nombre VARCHAR(50))

CREATE TABLE Genero(
IdGenero INT PRIMARY KEY IDENTITY(1,1),
Nombre VARCHAR(50))

CREATE TABLE Libro(
IdLibro INT PRIMARY KEY IDENTITY(1,1),
Nombre VARCHAR(50),
IdAutor INT FOREIGN KEY REFERENCES Autor(IdAutor),
NumeroPaginas INT,
FechaPublicacion DATE,
IdEditorial INT FOREIGN KEY REFERENCES Editorial(IdEditorial),
Edicion VARCHAR(50),
IdGenero INT FOREIGN KEY REFERENCES Genero(IdGenero))

INSERT INTO Autor (Nombre) VALUES ('Charles Dickens')
INSERT INTO Autor (Nombre) VALUES ('Sthephen King')
INSERT INTO Autor (Nombre) VALUES ('Homero')
INSERT INTO Autor (Nombre) VALUES ('Isaac Newton')
INSERT INTO Autor (Nombre) VALUES ('Sthephen Hawking')

INSERT INTO Editorial (Nombre) VALUES ('Selector')
INSERT INTO Editorial (Nombre) VALUES ('Gandhi')
INSERT INTO Editorial (Nombre) VALUES ('Trillas')
INSERT INTO Editorial (Nombre) VALUES ('Newton')
INSERT INTO Editorial (Nombre) VALUES ('SEGOB')

INSERT INTO Genero (Nombre) VALUES ('Fantasia')
INSERT INTO Genero (Nombre) VALUES ('Terror')
INSERT INTO Genero (Nombre) VALUES ('Drama')
INSERT INTO Genero (Nombre) VALUES ('Historia')
INSERT INTO Genero (Nombre) VALUES ('Ciencia')

CREATE PROCEDURE LibroAdd
@Nombre VARCHAR(50),
@IdAutor INT,
@NumeroPaginas INT,
@FechaPublicacion DATE,
@IdEditorial INT,
@Edicion VARCHAR(50),
@IdGenero INT
AS
INSERT INTO Libro (Nombre, IdAutor, NumeroPaginas, FechaPublicacion, IdEditorial, Edicion, IdGenero) VALUES (@Nombre, @IdAutor, @NumeroPaginas, @FechaPublicacion, @IdEditorial, @Edicion, @IdGenero)

CREATE PROCEDURE LibroUpdate
@IdLibro INT,
@Nombre VARCHAR(50),
@IdAutor INT,
@NumeroPaginas INT,
@FechaPublicacion DATE,
@IdEditorial INT,
@Edicion VARCHAR(50),
@IdGenero INT
AS
UPDATE Libro SET Nombre = @Nombre, IdAutor = @IdAutor, NumeroPaginas = @NumeroPaginas, FechaPublicacion = @FechaPublicacion, IdEditorial = @IdEditorial, Edicion = @Edicion, IdGenero = @IdGenero WHERE IdLibro = @IdLibro

CREATE PROCEDURE LibroDelete
@IdLibro INT
AS
DELETE FROM Libro WHERE IdLibro = @IdLibro

CREATE PROCEDURE LibroGetById
@IdLibro INT
AS
SELECT IdLibro, Libro.Nombre, Libro.IdAutor, Autor.Nombre AS 'NombreAutor', NumeroPaginas, FechaPublicacion, Libro.IdEditorial, Editorial.Nombre AS 'NombreEditorial', Edicion, Libro.IdGenero, Genero.Nombre AS 'NombreGenero' FROM Libro
INNER JOIN Autor ON Libro.IdAutor = Autor.IdAutor 
INNER JOIN Editorial ON Libro.IdEditorial = Editorial.IdEditorial
INNER JOIN Genero ON Libro.IdGenero = Genero.IdGenero WHERE Libro.IdLibro = @IdLibro

CREATE PROCEDURE LibroGetAll
AS
SELECT IdLibro, Libro.Nombre, Libro.IdAutor, Autor.Nombre AS 'NombreAutor', NumeroPaginas, FechaPublicacion, Libro.IdEditorial, Editorial.Nombre AS 'NombreEditorial', Edicion, Libro.IdGenero, Genero.Nombre AS 'NombreGenero' FROM Libro
INNER JOIN Autor ON Libro.IdAutor = Autor.IdAutor 
INNER JOIN Editorial ON Libro.IdEditorial = Editorial.IdEditorial
INNER JOIN Genero ON Libro.IdGenero = Genero.IdGenero 



CREATE PROCEDURE AutorGetAll
AS
SELECT IdAutor, Nombre FROM Autor

CREATE PROCEDURE EditorialGetAll
AS
SELECT IdEditorial, Nombre FROM Editorial

CREATE PROCEDURE GeneroGetAll
AS
SELECT IdGenero, Nombre FROM Genero


