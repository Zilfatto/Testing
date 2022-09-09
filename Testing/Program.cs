using Utils;
using Utils.Shapes;

var circle = new Circle(2);

var triangle = new Triangle(3, 4, 5);

ShapeHandler.PrintOutShapeAreas(new Shape[] { circle, triangle });

const string query = @"
	CREATE TABLE Categories (
		Id INT PRIMARY KEY IDENTITY(1, 1),
		Name VARCHAR(255) NOT NULL
	)

	CREATE TABLE Products (
		Id INT PRIMARY KEY IDENTITY(1, 1),
		Name VARCHAR(255) NOT NULL
	)

	CREATE TABLE ProductCategories (
		ProductId INT NOT NULL FOREIGN KEY REFERENCES Products(Id),
		CategoryId INT NOT NULL FOREIGN KEY REFERENCES Categories(Id)
	)

	-- Getting all products with optional Categories
	SELECT [Products].[Name], [Categories].[Name] FROM [Products]
		LEFT JOIN [ProductCategories] ON [Products].[Id] = [ProductCategories].[ProductId]
		LEFT JOIN [Categories] ON [ProductCategories].[CategoryId] = [Categories].[Id];
";