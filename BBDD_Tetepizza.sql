-- Crear la base de datos PizzaDB
CREATE DATABASE PizzasDB;

-- Usar la base de datos PizzaDB
USE PizzasDB;

-- Crear la tabla Pizzas
CREATE TABLE Pizzas (
    IdPizza INT PRIMARY KEY,
    NamePizza VARCHAR(255),
    Price DECIMAL(8, 2)
);

-- Insertar ejemplos de pizzas
INSERT INTO Pizzas (IdPizza, NamePizza, Price) VALUES
(1, 'Classic Italian', 7.02),
(2, 'Vegetariana', 6.77),
(3, 'Pepperoni', 9.12),
(4, '8 Quesos', 10.5);

-- Crear la tabla Ingredientes
CREATE TABLE Ingredientes (
    IdIngredient INT PRIMARY KEY,
    PizzaId INT,
    NameIngredient VARCHAR(255),
    Type VARCHAR(255),
    Quantity INT,
    Calories VARCHAR(255),
    ExpiryDate VARCHAR(255),
    Origin VARCHAR(255),
    Price DECIMAL(10, 2),
    NutritionalInfo VARCHAR(1000),
    IsGlutenFree BIT
);

CREATE TABLE Pedidos
(
    IdOrder INT PRIMARY KEY IDENTITY(1,1),
    Price DECIMAL NOT NULL,
    UserId INT, 
    FOREIGN KEY (UserId) REFERENCES Usuarios(IdUsuario)
);


-- Insertar ingredientes para la pizza "Classic Italian"
-- Ingredientes para la pizza "Classic Italian"
INSERT INTO Ingredientes (IdIngredient, PizzaId, NameIngredient, Type, Quantity, Calories, ExpiryDate, Origin, Price, NutritionalInfo, IsGlutenFree)
VALUES
    (1, 1, 'Tomate', 'Fruta', 2, 'Cada Tomate contiene dos 22 calorías.', '2024-02-20', 'Andalucía', 0.22, 'Consumir tomates es beneficioso para la salud debido a la amplia variedad de nutrientes y compuestos bioactivos que ofrecen.', 1),
    (2, 1, 'Prosciutto', 'Carne', 3, 'Aproximadamente 200 calorías por cada 100 gramos de prosciutto.', '2024-02-22', 'Italia', 1.3, 'Rico en grasas saludables y proteínas.', 1),
    (3, 1, 'Queso Parmesano', 'Lácteo', 4, 'Aproximadamente 110 calorías por cada 28 gramos de queso Parmesano.', '2024-02-25', 'Italia', 2.5, 'Alto contenido de calcio y proteínas.', 1),
    (4, 1, 'Aceite de Oliva', 'Condimento', 1, 'No tiene calorías.', '2024-03-01', 'Región Mediterránea', 3.0, 'Rico en grasas saludables.', 1);

-- Ingredientes para la pizza "Vegetariana"
INSERT INTO Ingredientes (IdIngredient, PizzaId, NameIngredient, Type, Quantity, Calories, ExpiryDate, Origin, Price, NutritionalInfo, IsGlutenFree)
VALUES
    (5, 2, 'Tomate', 'Fruta', 2, 'Cada tomate contiene aproximadamente 22 calorías.', '2024-02-20', 'Andalucía', 0.22, 'Beneficioso para la salud debido a la variedad de nutrientes y compuestos bioactivos que ofrece.', 1),
    (6, 2, 'Espinaca', 'Vegetal', 1, 'Aproximadamente 7 calorías por cada taza de espinacas.', '2024-02-18', 'Local', 0.3, 'Rica en vitaminas y minerales, baja en calorías.', 1),
    (7, 2, 'Champiñones', 'Hongos', 2, 'Aproximadamente 11 calorías por cada 100 gramos de champiñones.', '2024-02-15', 'Cultivados', 0.25, 'Buena fuente de proteínas, vitaminas y minerales.', 1);

-- Ingredientes para la pizza "Pepperoni"
INSERT INTO Ingredientes (IdIngredient, PizzaId, NameIngredient, Type, Quantity, Calories, ExpiryDate, Origin, Price, NutritionalInfo, IsGlutenFree)
VALUES
    (8, 3, 'Tomate', 'Fruta', 2, 'Cada Tomate contiene dos 22 calorías.', '2024-02-20', 'Andalucía', 0.22, 'Consumir tomates es beneficioso para la salud debido a la amplia variedad de nutrientes y compuestos bioactivos que ofrecen.', 1),
    (9, 3, 'Pepperoni', 'Carne', 3, 'Aproximadamente 250 calorías por cada 100 gramos de pepperoni.', '2024-02-22', 'Estados Unidos', 1.5, 'Rico en grasas y proteínas, pero consumir con moderación debido a su contenido calórico.', 1),
    (10, 3, 'Oregano', 'Hierba', 1, 'Aporta insignificantes calorías.', '2024-02-10', 'Mediterráneo', 0.1, 'Aporta sabor y aroma a la pizza, sin calorías significativas.', 1);

-- Ingredientes para la pizza "8 Quesos"
INSERT INTO Ingredientes (IdIngredient, PizzaId, NameIngredient, Type, Quantity, Calories, ExpiryDate, Origin, Price, NutritionalInfo, IsGlutenFree)
VALUES
    (11, 4, 'Tomate', 'Fruta', 2, 'Cada Tomate contiene dos 22 calorías.', '2024-02-20', 'Andalucía', 0.22, 'Consumir tomates es beneficioso para la salud debido a la amplia variedad de nutrientes y compuestos bioactivos que ofrecen.', 1),
    (12, 4, 'Queso Mozzarella', 'Lácteo', 3, 'Aproximadamente 80 calorías por cada 28 gramos de queso mozzarella.', '2024-02-25', 'Italia', 2.0, 'Bajo contenido de grasa y alto contenido de proteínas y calcio.', 1),
    (13, 4, 'Queso Cheddar', 'Lácteo', 2, 'Aproximadamente 110 calorías por cada 28 gramos de queso cheddar.', '2024-02-25', 'Inglaterra', 1.5, 'Sabor fuerte y color naranja distintivo.', 1),
    (14, 4, 'Queso Gouda', 'Lácteo', 2, 'Aproximadamente 101 calorías por cada 28 gramos de queso Gouda.', '2024-02-25', 'Países Bajos', 1.8, 'Sabor suave y cremoso.', 1),
    (15, 4, 'Queso Brie', 'Lácteo', 2, 'Aproximadamente 95 calorías por cada 28 gramos de queso Brie.', '2024-02-25', 'Francia', 2.2, 'Textura suave y sabor a nuez.', 1),
    (16, 4, 'Queso Roquefort', 'Lácteo', 2, 'Aproximadamente 66 calorías por cada 28 gramos de queso Roquefort.', '2024-02-25', 'Francia', 3.5, 'Sabor fuerte y textura desmenuzable.', 1),
    (17, 4, 'Queso Gruyere', 'Lácteo', 2, 'Aproximadamente 117 calorías por cada 28 gramos de queso Gruyere.', '2024-02-25', 'Suiza', 2.6, 'Sabor a nuez y textura cremosa.', 1),
    (18, 4, 'Queso Emmental', 'Lácteo', 2, 'Aproximadamente 98 calorías por cada 28 gramos de queso Emmental.', '2024-02-25', 'Suiza', 2.3, 'Sabor suave y textura elástica.', 1);

-- Verificar si los ingredientes se han insertado correctamente
SELECT * FROM Ingredientes;

-- Verificar si las pizzas se han insertado correctamente
SELECT * FROM Pizzas;



