
USE [CasoEstudio]
GO


-- Procedimiento almacenado para registrar solicitudes de ejercicios
CREATE PROCEDURE RegistrarSolicitud
	@Nombre		varchar(255),
    @Monto		decimal(10, 2),
    @TipoEjercicio		int
AS
BEGIN
	
	DECLARE @Inscripciones int;

	SET @Inscripciones = (SELECT COUNT(*) FROM Ejercicios WHERE Nombre = @Nombre)
	
	IF (@Inscripciones < 2) AND EXISTS (SELECT 1 FROM TiposEjercicio 
										WHERE TipoEjercicio = @TipoEjercicio)
	BEGIN
		INSERT INTO Ejercicios(Nombre, Fecha, Monto, TipoEjercicio)
		VALUES (@Nombre, GETDATE(), @Monto, @TipoEjercicio)
	END

END
GO

-- Procedimiento para consultar todas las solicitudes de ejercicios
CREATE PROCEDURE ConsultarSolicitudes
	
AS
BEGIN

	SELECT	E.Fecha, E.Monto, T.DescripcionTipoEjercicio, E.Nombre
	FROM	Ejercicios E
	INNER JOIN TiposEjercicio T 
	ON E.TipoEjercicio = T.TipoEjercicio;

END
GO