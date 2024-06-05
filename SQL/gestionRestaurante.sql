#TABLAS BASE DE DATO gestionRestaurante

CREATE DATABASE gestionRestaurante;

USE gestionRestaurante;

CREATE TABLE Clientes (
    cliente_id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    apellido VARCHAR(50) NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL,
    telefono VARCHAR(15),
    CHECK (telefono REGEXP '^[0-9]+$' OR telefono IS NULL)
);

CREATE TABLE Mesas (
    mesa_id INT AUTO_INCREMENT PRIMARY KEY,
    numero INT NOT NULL,
    capacidad INT NOT NULL
);

CREATE TABLE Reservaciones (
    reservacion_id INT AUTO_INCREMENT PRIMARY KEY,
    cliente_id INT,
    mesa_id INT,
    fecha_hora DATETIME NOT NULL,
    numero_personas INT NOT NULL,
    FOREIGN KEY (cliente_id) REFERENCES Clientes(cliente_id) ON DELETE CASCADE,
    FOREIGN KEY (mesa_id) REFERENCES Mesas(mesa_id) ON DELETE CASCADE
);

CREATE TABLE Categorias_Menu (
    categoria_id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    descripcion TEXT
);

CREATE TABLE Menus (
    menu_id INT AUTO_INCREMENT PRIMARY KEY,
    categoria_id INT,
    nombre VARCHAR(100) NOT NULL,
    descripcion TEXT,
    precio DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (categoria_id) REFERENCES Categorias_Menu(categoria_id) ON DELETE CASCADE
);

CREATE TABLE Ingredientes (
    ingrediente_id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    descripcion TEXT,
    stock DECIMAL(10, 2) NOT NULL,
    unidad VARCHAR(20) NOT NULL
);

CREATE TABLE Recetas (
    receta_id INT AUTO_INCREMENT PRIMARY KEY,
    menu_id INT,
    nombre VARCHAR(100) NOT NULL,
    descripcion TEXT,
    FOREIGN KEY (menu_id) REFERENCES Menus(menu_id) ON DELETE CASCADE
);

CREATE TABLE Detalle_Recetas (
    detalle_receta_id INT AUTO_INCREMENT PRIMARY KEY,
    receta_id INT,
    ingrediente_id INT,
    cantidad DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (receta_id) REFERENCES Recetas(receta_id) ON DELETE CASCADE,
    FOREIGN KEY (ingrediente_id) REFERENCES Ingredientes(ingrediente_id) ON DELETE CASCADE
);

CREATE TABLE Proveedores (
    proveedor_id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    contacto VARCHAR(100),
    telefono VARCHAR(15),
    email VARCHAR(100)
);

CREATE TABLE Compras (
    compra_id INT AUTO_INCREMENT PRIMARY KEY,
    proveedor_id INT,
    fecha DATE NOT NULL,
    total DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (proveedor_id) REFERENCES Proveedores(proveedor_id) ON DELETE CASCADE
);

CREATE TABLE Detalle_Compras (
    detalle_compra_id INT AUTO_INCREMENT PRIMARY KEY,
    compra_id INT,
    ingrediente_id INT,
    cantidad DECIMAL(10, 2) NOT NULL,
    precio DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (compra_id) REFERENCES Compras(compra_id) ON DELETE CASCADE,
    FOREIGN KEY (ingrediente_id) REFERENCES Ingredientes(ingrediente_id) ON DELETE CASCADE
);

CREATE TABLE Inventario (
    inventario_id INT AUTO_INCREMENT PRIMARY KEY,
    ingrediente_id INT,
    cantidad DECIMAL(10, 2) NOT NULL,
    unidad VARCHAR(20) NOT NULL,
    FOREIGN KEY (ingrediente_id) REFERENCES Ingredientes(ingrediente_id) ON DELETE CASCADE
);

CREATE TABLE Pedidos (
    pedido_id INT AUTO_INCREMENT PRIMARY KEY,
    reservacion_id INT,
    fecha_hora DATETIME NOT NULL,
    total DECIMAL(10, 2) NOT NULL,
    tipo_pedido ENUM('En Establecimiento', 'Online') NOT NULL,
    FOREIGN KEY (reservacion_id) REFERENCES Reservaciones(reservacion_id) ON DELETE CASCADE
);

CREATE TABLE Detalle_Pedidos (
    detalle_pedido_id INT AUTO_INCREMENT PRIMARY KEY,
    pedido_id INT,
    menu_id INT,
    cantidad INT NOT NULL,
    precio DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (pedido_id) REFERENCES Pedidos(pedido_id) ON DELETE CASCADE,
    FOREIGN KEY (menu_id) REFERENCES Menus(menu_id) ON DELETE CASCADE
);

CREATE TABLE Empleados (
    empleado_id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    apellido VARCHAR(50) NOT NULL,
    puesto VARCHAR(50) NOT NULL,
    telefono VARCHAR(15),
    CHECK (telefono REGEXP '^[0-9]+$' OR telefono IS NULL) 
);

CREATE TABLE Turnos (
    turno_id INT AUTO_INCREMENT PRIMARY KEY,
    empleado_id INT,
    fecha_hora_inicio DATETIME NOT NULL,
    fecha_hora_fin DATETIME NOT NULL,
    FOREIGN KEY (empleado_id) REFERENCES Empleados(empleado_id) ON DELETE CASCADE
);

CREATE TABLE Categorias_Bebidas (
    categoria_bebida_id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    descripcion TEXT
);

CREATE TABLE Bebidas (
    bebida_id INT AUTO_INCREMENT PRIMARY KEY,
    categoria_bebida_id INT,
    nombre VARCHAR(50) NOT NULL,
    descripcion TEXT,
    stock DECIMAL(10, 2) NOT NULL,
    unidad VARCHAR(20) NOT NULL,
    horario_disponible ENUM('Diurno', 'Nocturno', 'Ambos') NOT NULL,
    FOREIGN KEY (categoria_bebida_id) REFERENCES Categorias_Bebidas(categoria_bebida_id) ON DELETE CASCADE
);

CREATE TABLE Cocteles (
    coctel_id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    descripcion TEXT,
    precio DECIMAL(10, 2) NOT NULL
);

CREATE TABLE Detalle_Cocteles (
    detalle_coctel_id INT AUTO_INCREMENT PRIMARY KEY,
    coctel_id INT,
    bebida_id INT,
    cantidad DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (coctel_id) REFERENCES Cocteles(coctel_id) ON DELETE CASCADE,
    FOREIGN KEY (bebida_id) REFERENCES Bebidas(bebida_id) ON DELETE CASCADE
);

CREATE TABLE Roles (
    rol_id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    descripcion TEXT
);

CREATE TABLE Permisos (
    permiso_id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    descripcion TEXT
);

CREATE TABLE Roles_Permisos (
    rol_permiso_id INT AUTO_INCREMENT PRIMARY KEY,
    rol_id INT,
    permiso_id INT,
    FOREIGN KEY (rol_id) REFERENCES Roles(rol_id) ON DELETE CASCADE,
    FOREIGN KEY (permiso_id) REFERENCES Permisos(permiso_id) ON DELETE CASCADE
);

CREATE TABLE Clientes_Frecuentes (
    cliente_frecuente_id INT AUTO_INCREMENT PRIMARY KEY,
    cliente_id INT,
    puntos INT NOT NULL,
    FOREIGN KEY (cliente_id) REFERENCES Clientes(cliente_id) ON DELETE CASCADE
);

CREATE TABLE Programas_Fidelidad (
    programa_id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    descripcion TEXT,
    puntos_requeridos INT NOT NULL
);

CREATE TABLE Pedidos_Online (
    pedido_online_id INT AUTO_INCREMENT PRIMARY KEY,
    pedido_id INT,
    direccion_entrega VARCHAR(255) NOT NULL,
    estado ENUM('Pendiente', 'En camino', 'Entregado') NOT NULL,
    FOREIGN KEY (pedido_id) REFERENCES Pedidos(pedido_id) ON DELETE CASCADE
);

CREATE TABLE Eventos (
    evento_id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    descripcion TEXT,
    fecha_hora_inicio DATETIME NOT NULL,
    fecha_hora_fin DATETIME NOT NULL
);

CREATE TABLE Eventos_Bebidas (
    evento_bebida_id INT AUTO_INCREMENT PRIMARY KEY,
    evento_id INT,
    bebida_id INT,
    FOREIGN KEY (evento_id) REFERENCES Eventos(evento_id) ON DELETE CASCADE,
    FOREIGN KEY (bebida_id) REFERENCES Bebidas(bebida_id) ON DELETE CASCADE
);
