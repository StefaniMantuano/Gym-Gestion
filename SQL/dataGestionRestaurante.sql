#Datos de la DB gestionRestaurante

USE gestionRestaurante;

-- Insertar datos en la tabla Clientes
INSERT INTO Clientes (nombre, apellido, email, telefono)
VALUES 
('Juan', 'Perez', 'juan.perez@example.com', '123456789'),
('Maria', 'Lopez', 'maria.lopez@example.com', '987654321'),
('Carlos', 'Ramirez', 'carlos.ramirez@example.com', '456789123');

-- Insertar datos en la tabla Mesas
INSERT INTO Mesas (numero, capacidad)
VALUES 
(1, 4),
(2, 2),
(3, 6);

-- Insertar datos en la tabla Reservaciones
INSERT INTO Reservaciones (cliente_id, mesa_id, fecha_hora, numero_personas)
VALUES 
(1, 1, '2024-06-05 19:00:00', 4),
(2, 2, '2024-06-05 20:00:00', 2),
(3, 3, '2024-06-06 21:00:00', 6);

-- Insertar datos en la tabla Categorias_Menu
INSERT INTO Categorias_Menu (nombre, descripcion)
VALUES 
('Entradas', 'Aperitivos y entradas'),
('Platos Principales', 'Platos fuertes'),
('Postres', 'Dulces y postres');

-- Insertar datos en la tabla Menus
INSERT INTO Menus (categoria_id, nombre, descripcion, precio)
VALUES 
(1, 'Ensalada César', 'Ensalada clásica con pollo y aderezo César', 5.50),
(2, 'Bistec a la Parrilla', 'Bistec de res a la parrilla con guarnición', 15.00),
(3, 'Tarta de Chocolate', 'Deliciosa tarta de chocolate con crema', 4.50);

-- Insertar datos en la tabla Ingredientes
INSERT INTO Ingredientes (nombre, descripcion, stock, unidad)
VALUES 
('Lechuga', 'Lechuga fresca', 50.00, 'kg'),
('Pollo', 'Pechuga de pollo', 30.00, 'kg'),
('Chocolate', 'Chocolate para postres', 20.00, 'kg');

-- Insertar datos en la tabla Recetas
INSERT INTO Recetas (menu_id, nombre, descripcion)
VALUES 
(1, 'Receta Ensalada César', 'Preparación de la ensalada César'),
(2, 'Receta Bistec a la Parrilla', 'Preparación del bistec a la parrilla'),
(3, 'Receta Tarta de Chocolate', 'Preparación de la tarta de chocolate');

-- Insertar datos en la tabla Detalle_Recetas
INSERT INTO Detalle_Recetas (receta_id, ingrediente_id, cantidad)
VALUES 
(1, 1, 0.20), -- 200g de lechuga para la ensalada César
(1, 2, 0.15), -- 150g de pollo para la ensalada César
(3, 3, 0.25); -- 250g de chocolate para la tarta

-- Insertar datos en la tabla Proveedores
INSERT INTO Proveedores (nombre, contacto, telefono, email)
VALUES 
('Proveedor de Vegetales', 'Luis García', '555123456', 'luis.garcia@proveedor.com'),
('Proveedor de Carnes', 'Ana Morales', '555789012', 'ana.morales@proveedor.com');

-- Insertar datos en la tabla Compras
INSERT INTO Compras (proveedor_id, fecha, total)
VALUES 
(1, '2024-06-01', 200.00),
(2, '2024-06-02', 300.00);

-- Insertar datos en la tabla Detalle_Compras
INSERT INTO Detalle_Compras (compra_id, ingrediente_id, cantidad, precio)
VALUES 
(1, 1, 20.00, 2.00), -- 20kg de lechuga a 2.00 por kg
(2, 2, 15.00, 15.00); -- 15kg de pollo a 15.00 por kg

-- Insertar datos en la tabla Inventario
INSERT INTO Inventario (ingrediente_id, cantidad, unidad)
VALUES 
(1, 50.00, 'kg'),
(2, 30.00, 'kg'),
(3, 20.00, 'kg');

-- Insertar datos en la tabla Pedidos
INSERT INTO Pedidos (reservacion_id, fecha_hora, total, tipo_pedido)
VALUES 
(1, '2024-06-05 19:30:00', 40.00, 'En Establecimiento'),
(2, '2024-06-05 20:30:00', 30.00, 'En Establecimiento'),
(3, '2024-06-06 21:30:00', 45.00, 'Online');

-- Insertar datos en la tabla Detalle_Pedidos
INSERT INTO Detalle_Pedidos (pedido_id, menu_id, cantidad, precio)
VALUES 
(1, 1, 2, 5.50), -- 2 Ensaladas César a 5.50 cada una
(1, 2, 2, 15.00), -- 2 Bistecs a la Parrilla a 15.00 cada uno
(2, 3, 2, 4.50); -- 2 Tartas de Chocolate a 4.50 cada una

-- Insertar datos en la tabla Empleados
INSERT INTO Empleados (nombre, apellido, puesto, telefono)
VALUES 
('Pedro', 'Martinez', 'Mesero', '555111222'),
('Laura', 'Gomez', 'Cocinero', '555333444'),
('Miguel', 'Diaz', 'Bartender', '555555666');

-- Insertar datos en la tabla Turnos
INSERT INTO Turnos (empleado_id, fecha_hora_inicio, fecha_hora_fin)
VALUES 
(1, '2024-06-05 18:00:00', '2024-06-05 22:00:00'),
(2, '2024-06-05 16:00:00', '2024-06-05 23:00:00'),
(3, '2024-06-05 18:00:00', '2024-06-05 23:00:00');

-- Insertar datos en la tabla Categorias_Bebidas
INSERT INTO Categorias_Bebidas (nombre, descripcion)
VALUES 
('Refrescos', 'Bebidas gaseosas'),
('Jugos', 'Jugos naturales y artificiales'),
('Batidos', 'Batidos de frutas y lácteos'),
('Infusiones', 'Tés y otras infusiones'),
('Bebidas Alcoholizadas', 'Bebidas con contenido alcohólico');

-- Insertar datos en la tabla Bebidas
INSERT INTO Bebidas (categoria_bebida_id, nombre, descripcion, stock, unidad, horario_disponible)
VALUES 
(1, 'Coca-Cola', 'Refresco de cola', 100.00, 'L', 'Ambos'),
(2, 'Jugo de Naranja', 'Jugo natural de naranja', 50.00, 'L', 'Ambos'),
(3, 'Batido de Fresa', 'Batido de fresa con leche', 30.00, 'L', 'Ambos'),
(4, 'Té Verde', 'Infusión de té verde', 20.00, 'L', 'Ambos'),
(5, 'Cerveza', 'Cerveza rubia', 200.00, 'L', 'Nocturno');

-- Insertar datos en la tabla Cocteles
INSERT INTO Cocteles (nombre, descripcion, precio)
VALUES 
('Mojito', 'Coctel de ron con menta y limón', 8.00),
('Margarita', 'Coctel de tequila con limón y sal', 10.00);

-- Insertar datos en la tabla Detalle_Cocteles
INSERT INTO Detalle_Cocteles (coctel_id, bebida_id, cantidad)
VALUES 
(1, 5, 0.10), -- Mojito lleva 100ml de ron
(2, 5, 0.10); -- Margarita lleva 100ml de tequila

-- Insertar datos en la tabla Roles
INSERT INTO Roles (nombre, descripcion)
VALUES 
('Mesero', 'Atiende las mesas'),
('Cocinero', 'Prepara los alimentos'),
('Bartender', 'Prepara las bebidas');

-- Insertar datos en la tabla Permisos
INSERT INTO Permisos (nombre, descripcion)
VALUES 
('Ver_Menu', 'Puede ver el menú'),
('Tomar_Pedido', 'Puede tomar pedidos'),
('Preparar_Alimentos', 'Puede preparar alimentos'),
('Preparar_Bebidas', 'Puede preparar bebidas');

-- Insertar datos en la tabla Roles_Permisos
INSERT INTO Roles_Permisos (rol_id, permiso_id)
VALUES 
(1, 1), -- Mesero puede ver el menú
(1, 2), -- Mesero puede tomar pedidos
(2, 3), -- Cocinero puede preparar alimentos
(3, 4); -- Bartender puede preparar bebidas

-- Insertar datos en la tabla Clientes_Frecuentes
INSERT INTO Clientes_Frecuentes (cliente_id, puntos)
VALUES 
(1, 100),
(2, 50);

-- Insertar datos en la tabla Programas_Fidelidad
INSERT INTO Programas_Fidelidad (nombre, descripcion, puntos_requeridos)
VALUES 
('Descuento del 10%', 'Obtén un 10% de descuento acumulando 100 puntos', 100),
('Postre Gratis', 'Obtén un postre gratis acumulando 50 puntos', 50);

-- Insertar datos en la tabla Pedidos_Online
INSERT INTO Pedidos_Online (pedido_id, direccion_entrega, estado)
VALUES 
(3, '123 Calle Principal, Ciudad', 'Pendiente');

-- Insertar datos en la tabla Eventos
INSERT INTO Eventos (nombre, descripcion, fecha_hora_inicio, fecha_hora_fin)
VALUES 
('Noche de Karaoke', 'Evento especial con karaoke', '2024-06-06 20:00:00', '2024-06-06 23:59:00'),
('Cata de Vinos', 'Evento especial con cata de vinos', '2024-06-07 18:00:00', '2024-06-07 21:00:00');

-- Insertar datos en la tabla Eventos_Bebidas
INSERT INTO Eventos_Bebidas (evento_id, bebida_id)
VALUES 
(1, 5), -- Cerveza permitida en Noche de Karaoke
(2, 5); -- Cerveza permitida en Cata de Vinos
