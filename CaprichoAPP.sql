/*Creamos la base de datos*/
CREATE DATABASE CaprichoAPP
GO
USE CaprichoAPP

	/*Tablas*/
CREATE TABLE Administrador(
	AdministradorId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	AdministradorNombre NVARCHAR(20) NOT NULL,
	Correo NVARCHAR(20) NOT NULL,
	Clave NVARCHAR(15) NOT NULL
);

CREATE TABLE Carrito(
	CarritoId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	VentaId INT NOT NULL,
	ProductoId INT NOT NULL,
	ProductoPrecio DECIMAL(18,2) NOT NULL,
	Cantidad INT NOT NULL
);

CREATE TABLE Clientes(
	ClienteId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	ClienteNombre NVARCHAR(20) NOT NULL,
	Correo NVARCHAR(20) NOT NULL,
	Clave NVARCHAR(15) NOT NULL,
	Fecha_Registro DateTime2 NOT NULL
);

CREATE TABLE Departamento(
	DepartamentoId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	DepartamentoNombre NVARCHAR(20) NOT NULL
);

CREATE TABLE Municipio(
	MunicipioId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	MunicipioNombre NVARCHAR(20) NOT NULL,
	DepartamentoId INT NOT NULL
);

CREATE TABLE Categoria(
	CategoriaId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	CategoriaNombre NVARCHAR(20) NOT NULL,
);

CREATE TABLE Producto(
	ProductoId INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
	ProductoNombre NVARCHAR(20) NOT NULL,
	Precio DECIMAL(18,2) NOT NULL,
	Categoria NVARCHAR(20) NOT NULL,
	Fecha_Registro DateTime2 NOT NULL,
	PhotoFileName NVARCHAR(20) NOT NULL,
);

CREATE TABLE Ventas(
	VentaId INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
	ClienteId INT NOT NULL,
	Fecha_Registro DateTime2 NOT NULL,
	Municipio NVARCHAR(20) NOT NULL,
	MontoTotal DECIMAL(18,2) NOT NULL
);

	/*Relaciones*/
ALTER TABLE Carrito  WITH CHECK ADD  CONSTRAINT FK_Carrito_Producto_ProductoId FOREIGN KEY(ProductoId)
REFERENCES Producto (ProductoId)
ON DELETE CASCADE
GO
	ALTER TABLE Carrito CHECK CONSTRAINT FK_Carrito_Producto_ProductoId
	GO

ALTER TABLE Carrito  WITH CHECK ADD  CONSTRAINT FK_Carrito_Ventas_VentaId FOREIGN KEY(VentaId)
REFERENCES Ventas (VentaId)
ON DELETE CASCADE
GO
	ALTER TABLE Carrito CHECK CONSTRAINT FK_Carrito_Ventas_VentaId
	GO

ALTER TABLE Municipio  WITH CHECK ADD  CONSTRAINT FK_Municipio_Departamento_DepartamentoId FOREIGN KEY(DepartamentoId)
REFERENCES Departamento (DepartamentoId)
ON DELETE CASCADE
GO
	ALTER TABLE Municipio CHECK CONSTRAINT FK_Municipio_Departamento_DepartamentoId
	GO

ALTER TABLE Ventas  WITH CHECK ADD  CONSTRAINT FK_Ventas_Clientes_ClienteId FOREIGN KEY(ClienteId)
REFERENCES Clientes (ClienteId)
ON DELETE CASCADE
GO
	ALTER TABLE Ventas CHECK CONSTRAINT FK_Ventas_Clientes_ClienteId
	GO



	/*ProcedimientosAlmacenados de Clientes*/
DROP PROCEDURE usp_InsertClientes
CREATE PROCEDURE usp_InsertClientes
	@ClienteNombre NVARCHAR(20),
	@Correo NVARCHAR(20),
	@Clave NVARCHAR(15),
	@Fecha_Registro DateTime2
AS 
INSERT INTO Clientes
VALUES (@ClienteNombre, @Correo, @Clave, @Fecha_Registro) 
GO 

DROP PROCEDURE usp_SelectClientes
CREATE PROCEDURE usp_SelectClientes
@ClienteId INT
AS 
SELECT * FROM Clientes WHERE ClienteId = @ClienteId
GO

DROP PROCEDURE usp_SelectClientesAll
CREATE PROCEDURE usp_SelectClientesAll
AS 
SELECT * FROM Clientes
GO

DROP PROCEDURE usp_UpdateClientes
CREATE PROCEDURE usp_UpdateClientes  
	@ClienteId INT,
	@ClienteNombre NVARCHAR(20),
	@Correo NVARCHAR(20),
	@Clave NVARCHAR(15),
	@Fecha_Registro DateTime2
AS 
UPDATE Clientes SET  
	ClienteNombre=@ClienteNombre,
    Correo=@Correo,
	Clave=@Clave,
	Fecha_Registro=@Fecha_Registro
       WHERE ClienteId= @ClienteId
GO

DROP PROCEDURE usp_DeleteClientes
CREATE PROCEDURE usp_DeleteClientes
@ClienteId INT
AS 
DELETE FROM Clientes WHERE ClienteId = @ClienteId
GO

/*Prueba de procedimientos almacenados*/
exec usp_InsertClientes 'Jeyson','jeyson@gmail.com','jeyson123', '';

exec usp_SelectClientesAll

exec usp_SelectClientes 1

exec usp_UpdateClientes 1, 'Ramon','ramon@gmail.com','jeyson123', '';

exec usp_DeleteClientes 1




	/*ProcedimientosAlmacenados de Ventas*/
DROP PROCEDURE usp_InsertVentas
CREATE PROCEDURE usp_InsertVentas
	@ClienteId INT,
	@Fecha_registro DateTime2,
	@Municipio NVARCHAR,
	@MontoTotal DECIMAL(18,2)
AS 
INSERT INTO Ventas
VALUES (@ClienteId, @Fecha_registro, @Municipio, @MontoTotal) 
GO 

CREATE PROCEDURE usp_SelectVentas
@VentaId INT
AS 
SELECT * FROM Ventas WHERE VentaId = @VentaId
GO

CREATE PROCEDURE usp_SelectVentasAll
AS 
SELECT * FROM Ventas
GO

DROP PROCEDURE usp_UpdateVentas
CREATE PROCEDURE usp_UpdateVentas 
	@VentaId INT,
	@ClienteId INT,
	@Fecha_registro DateTime2,
	@Municipio NVARCHAR,
	@MontoTotal DECIMAL(18,2)
AS 
UPDATE Ventas SET  
	ClienteId=@ClienteId,
    Fecha_registro=@Fecha_registro,
	Municipio=@Municipio,
	MontoTotal=@MontoTotal
       WHERE VentaId= @VentaId
GO

CREATE PROCEDURE usp_DeleteVentas
	@VentaId INT
AS 
DELETE FROM Ventas WHERE VentaId = @VentaId
GO







	/*ProcedimientosAlmacenados de Producto*/
DROP PROCEDURE usp_InsertProducto
CREATE PROCEDURE usp_InsertProducto
	@ProductoNombre NVARCHAR(20),
	@Precio DECIMAL(18,2),
	@Categoria NVARCHAR(20),
	@Fecha_Registro DateTime2,
	@PhotoFileName NVARCHAR(20)
AS 
INSERT INTO Producto
VALUES (@ProductoNombre, @Precio, @Categoria, @Fecha_Registro, @PhotoFileName) 
GO 

CREATE PROCEDURE usp_SelectProducto
@ProductoId INT
AS 
SELECT * FROM Producto WHERE ProductoId = @ProductoId
GO
DROP PROCEDURE usp_SelectProductoAll
CREATE PROCEDURE usp_SelectProductoAll
AS 
SELECT * FROM Producto
GO

DROP PROCEDURE usp_UpdateProducto
CREATE PROCEDURE usp_UpdateProducto 
	@ProductoId INT,
	@ProductoNombre NVARCHAR(20),
	@Precio DECIMAL(18,2),
	@Categoria NVARCHAR(20),
	@Fecha_Registro DateTime2,
	@PhotoFileName NVARCHAR(20)
AS 
UPDATE Producto SET  
	ProductoNombre=@ProductoNombre,
	Precio=@Precio,
	Categoria=@Categoria,
    Fecha_Registro=@Fecha_Registro,
	PhotoFileName=@PhotoFileName
       WHERE ProductoId= @ProductoId
GO
DROP PROCEDURE usp_DeleteProducto
CREATE PROCEDURE usp_DeleteProducto
	@ProductoId INT
AS 
DELETE FROM Producto WHERE ProductoId = @ProductoId
GO




exec usp_InsertProducto 'Perfume','10','Mascarilla', '', 'Perfume.png';

exec usp_SelectProductoAll

exec usp_SelectProducto 2

exec usp_UpdateProducto 2, 'Perfumees','100','Mascarilla', '', 'Perfume.png';

exec usp_DeleteProducto 2





	/*ProcedimientosAlmacenados de Carrito*/
DROP PROCEDURE usp_InsertCarrito
CREATE PROCEDURE usp_InsertCarrito
	@VentaId INT,
	@ProductoId INT,
	@ProductoPrecio DECIMAL(18,2),
	@Cantidad INT
AS 
INSERT INTO Carrito
VALUES (@VentaId, @ProductoId, @ProductoPrecio, @Cantidad) 
GO 

CREATE PROCEDURE usp_SelectCarrito
@CarritoId INT
AS 
SELECT * FROM Carrito WHERE CarritoId = @CarritoId
GO

CREATE PROCEDURE usp_SelectCarritoAll
AS 
SELECT * FROM Carrito
GO

DROP PROCEDURE usp_UpdateCarrito
CREATE PROCEDURE usp_UpdateCarrito 
	@CarritoId INT,
	@VentaId INT,
	@ProductoId INT,
	@ProductoPrecio DECIMAL(18,2),
	@Cantidad INT
AS 
UPDATE Carrito SET  
	VentaId=@VentaId,
	ProductoId=@ProductoId,
	ProductoPrecio=@ProductoPrecio,
    Cantidad=@Cantidad
       WHERE CarritoId= @CarritoId
GO

CREATE PROCEDURE usp_DeleteCarrito
	@CarritoId INT
AS 
DELETE FROM Carrito WHERE CarritoId = @CarritoId
GO









	/*ProcedimientosAlmacenados de Categoria*/
DROP PROCEDURE usp_InsertCategoria
CREATE PROCEDURE usp_InsertCategoria
	@CategoriaNombre NVARCHAR(20)
AS 
INSERT INTO Categoria
VALUES (@CategoriaNombre) 
GO 

CREATE PROCEDURE usp_SelectCategoria
@CategoriaId INT
AS 
SELECT * FROM Categoria WHERE CategoriaId = @CategoriaId
GO

CREATE PROCEDURE usp_SelectCategoriaAll
AS 
SELECT * FROM Categoria
GO

DROP PROCEDURE usp_UpdateCategoria
CREATE PROCEDURE usp_UpdateCategoria
	@CategoriaId INT,
	@CategoriaNombre NVARCHAR(20)
AS 
UPDATE Categoria SET  
    CategoriaNombre=@CategoriaNombre
       WHERE CategoriaId= @CategoriaId
GO

CREATE PROCEDURE usp_DeleteCategoria
	@CategoriaId INT
AS 
DELETE FROM Categoria WHERE CategoriaId = @CategoriaId
GO











	/*ProcedimientosAlmacenados de Departamento*/
DROP PROCEDURE usp_InsertDepartamento
CREATE PROCEDURE usp_InsertDepartamento
	@DepartamentoNombre NVARCHAR(20)
AS 
INSERT INTO Departamento
VALUES (@DepartamentoNombre) 
GO 

CREATE PROCEDURE usp_SelectDepartamento
@DepartamentoId INT
AS 
SELECT * FROM Departamento WHERE DepartamentoId = @DepartamentoId
GO

CREATE PROCEDURE usp_SelectDepartamentoAll
AS 
SELECT * FROM Departamento
GO

DROP PROCEDURE usp_UpdateDepartamento
CREATE PROCEDURE usp_UpdateDepartamento
	@DepartamentoId INT,
	@DepartamentoNombre NVARCHAR(20)
AS 
UPDATE Departamento SET  
    DepartamentoNombre=@DepartamentoNombre
       WHERE DepartamentoId= @DepartamentoId
GO

CREATE PROCEDURE usp_DeleteDepartamento
	@DepartamentoId INT
AS 
DELETE FROM Departamento WHERE DepartamentoId = @DepartamentoId
GO









	/*ProcedimientosAlmacenados de Municipio*/
DROP PROCEDURE usp_InsertMunicipio
CREATE PROCEDURE usp_InsertMunicipio
	@MunicipioNombre NVARCHAR(20),
	@DepartamentoId INT
AS 
INSERT INTO Municipio
VALUES (@MunicipioNombre, @DepartamentoId) 
GO 

CREATE PROCEDURE usp_SelectMunicipio
@MunicipioId INT
AS 
SELECT * FROM Municipio WHERE MunicipioId = @MunicipioId
GO

CREATE PROCEDURE usp_SelectMunicipioAll
AS 
SELECT * FROM Municipio
GO

DROP PROCEDURE usp_UpdateMunicipio
CREATE PROCEDURE usp_UpdateMuncipio
	@MunicipioId INT,
	@MunicipioNombre NVARCHAR(20),
	@DepartamentoId INT
AS 
UPDATE Municipio SET  
    MunicipioNombre=@MunicipioNombre,
	DepartamentoId=@DepartamentoId
       WHERE MunicipioId= @MunicipioId
GO

CREATE PROCEDURE usp_DeleteMunicipio
	@MunicipioId INT
AS 
DELETE FROM Municipio WHERE DepartamentoId = @MunicipioId
GO


