CREATE TABLE proveedor (
    id INT IDENTITY(1,1) PRIMARY KEY,
    provincia NVARCHAR(40),
    direccion NVARCHAR(60),
    NIF NVARCHAR(15)
);

CREATE TABLE tipoalimento (
    id INT IDENTITY(1,1) PRIMARY KEY,
    tipo NVARCHAR(30)
);

CREATE TABLE comida (
    id INT IDENTITY(1,1) PRIMARY KEY,
    fkIdTipoAlimento INT,
    nombre NVARCHAR(50),
    FOREIGN KEY (fkIdTipoAlimento) REFERENCES tipoalimento(id)
);

CREATE TABLE proveedorcomida (
    fkIdComida INT,
    fkIdProveedor INT,
    PRIMARY KEY (fkIdComida, fkIdProveedor),
    FOREIGN KEY (fkIdComida) REFERENCES comida(id),
    FOREIGN KEY (fkIdProveedor) REFERENCES proveedor(id)
);

CREATE TABLE usuarios (
    id INT IDENTITY(1,1) PRIMARY KEY,
    username NVARCHAR(40) UNIQUE,
    nombre NVARCHAR(20),
    apellido1 NVARCHAR(30),
    apellido2 NVARCHAR(30),
    contraseña NVARCHAR(50),
    profilepic NVARCHAR(255)
);

CREATE TABLE compra (
    id INT IDENTITY(1,1) PRIMARY KEY,
    fkIdUsuario INT,
    FOREIGN KEY (fkIdUsuario) REFERENCES usuarios(id)
);

CREATE TABLE pelicula (
    id INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(50),
    descripcion NVARCHAR(255),
    director NVARCHAR(50),
    anioDeSalida DATETIME,
    imagenBannerUrl NVARCHAR(255),
    imagenPequeniaUrl NVARCHAR(255),
    duracion INT
);

CREATE TABLE categorias (
    id INT IDENTITY(1,1) PRIMARY KEY,
    tipo NVARCHAR(50)
);

CREATE TABLE peliculaCategoria (
    fkIdPelicula INT,
    fkIdCategoria INT,
    PRIMARY KEY (fkIdPelicula, fkIdCategoria),
    FOREIGN KEY (fkIdPelicula) REFERENCES pelicula(id),
    FOREIGN KEY (fkIdCategoria) REFERENCES categorias(id)
);

CREATE TABLE comentarios (
    id INT IDENTITY(1,1) PRIMARY KEY,
    fkIdPelicula INT,
    fkIdUsuario INT,
    valoracion INT CHECK (valoracion BETWEEN 1 AND 5),
    comentario NVARCHAR(255),
    FOREIGN KEY (fkIdUsuario) REFERENCES usuarios(id),
    FOREIGN KEY (fkIdPelicula) REFERENCES pelicula(id)
);

CREATE TABLE sala (
    id INT IDENTITY(1,1) PRIMARY KEY,
    capacidad INT,
    nombre NVARCHAR(30)
);

CREATE TABLE asientos (
    id INT IDENTITY(1,1) PRIMARY KEY,
    fkIdSala INT,
    fila INT,
    numero INT,
    FOREIGN KEY (fkIdSala) REFERENCES sala(id),
    UNIQUE (fkIdSala, fila, numero)
);

CREATE TABLE sesion (
    id INT IDENTITY(1,1) PRIMARY KEY,
    fkIdPelicula INT,
    fkIdSala INT,
    fechaInicio DATETIME,
    fechaFin DATETIME,
    FOREIGN KEY (fkIdPelicula) REFERENCES pelicula(id),
    FOREIGN KEY (fkIdSala) REFERENCES sala(id)
);

CREATE TABLE asientos_sesion (
    id INT IDENTITY(1,1) PRIMARY KEY,
    fkIdSesion INT,
    fkIdAsiento INT,
    fkIdUsuario INT NULL,
    fechaReserva DATETIME NULL,
    ocupado TINYINT DEFAULT 0,
    FOREIGN KEY (fkIdSesion) REFERENCES sesion(id),
    FOREIGN KEY (fkIdAsiento) REFERENCES asientos(id),
    FOREIGN KEY (fkIdUsuario) REFERENCES usuarios(id)
);

CREATE TABLE roles (
    id INT IDENTITY(1,1) PRIMARY KEY,
    rol NVARCHAR(30)
);

CREATE TABLE detallecompra (
    fkIdCompra INT,
    fkIdSesion INT,
    fkIdSala INT,
    fila INT,
    numero INT,
    PRIMARY KEY (fkIdCompra, fkIdSesion, fkIdSala, fila, numero),
    FOREIGN KEY (fkIdCompra) REFERENCES compra(id),
    FOREIGN KEY (fkIdSesion, fkIdSala, fila, numero) REFERENCES asientos_sesion(fkIdSesion, fkIdSala, fila, numero)
);