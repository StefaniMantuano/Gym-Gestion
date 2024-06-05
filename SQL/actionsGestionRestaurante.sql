##Acciones de tablas y datos de la DB gestionRestaurante

USE gestionRestaurante;

-- Eliminar las tablas
DROP TABLE IF EXISTS Eventos_Bebidas;
DROP TABLE IF EXISTS Pedidos_Online;
DROP TABLE IF EXISTS Clientes_Frecuentes;
DROP TABLE IF EXISTS Roles_Permisos;
DROP TABLE IF EXISTS Detalle_Cocteles;
DROP TABLE IF EXISTS Turnos;
DROP TABLE IF EXISTS Detalle_Pedidos;
DROP TABLE IF EXISTS Pedidos;
DROP TABLE IF EXISTS Inventario;
DROP TABLE IF EXISTS Detalle_Compras;
DROP TABLE IF EXISTS Compras;
DROP TABLE IF EXISTS Detalle_Recetas;
DROP TABLE IF EXISTS Recetas;
DROP TABLE IF EXISTS Ingredientes;
DROP TABLE IF EXISTS Menus;
DROP TABLE IF EXISTS Reservaciones;
DROP TABLE IF EXISTS Clientes;
DROP TABLE IF EXISTS Mesas;
DROP TABLE IF EXISTS Bebidas;
DROP TABLE IF EXISTS Categorias_Bebidas;
DROP TABLE IF EXISTS Categorias_Menu;
DROP TABLE IF EXISTS Programas_Fidelidad;
DROP TABLE IF EXISTS Permisos;
DROP TABLE IF EXISTS Roles;
DROP TABLE IF EXISTS Cocteles;
DROP TABLE IF EXISTS Proveedores;
DROP TABLE IF EXISTS Empleados;
DROP TABLE IF EXISTS Eventos;

-- Tabla de respaldoDB
CREATE TABLE registros_restauracion (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    fecha_restauracion TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);














