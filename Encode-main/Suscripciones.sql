create database Suscripciones
use Suscripciones

create table Suscriptor(
	IdSuscriptor int identity primary key,
	Nombre nvarchar(50),
	Apellido nvarchar(50),
	NumeroDocumento int,
	TipoDocumento nvarchar(50),
	Direccion nvarchar(50),
	Telefono int,
	Email nvarchar(50),
	NombreUsuario nvarchar(50),
	Pass nvarchar (50)
)

create table Suscripcion(
	IdAsociacion int identity primary key,
	IdSuscriptor int,
	FechaAlta datetime,
	FechaFin datetime,
	MotivoFin nvarchar(50)
	constraint fk_Suscriptor_Suscripcion foreign key (IdSuscriptor) references Suscriptor (IdSuscriptor)
)
