<Query Kind="Expression">
  <Connection>
    <ID>49f53550-e1ab-4b16-b6e5-4587025a8e3c</ID>
    <Persist>true</Persist>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <Database>AdventureWorks2016</Database>
  </Connection>
</Query>

ProductSubcategories

ProductCategories

ProductCategories.Where(ps => ps.Name == "Clothing").Select( ps => new
{
	ProductSubcategories = ps.ProductSubcategories.Where(sc => sc.Name == "Caps").Select(sc => new
	{
		Product = sc.Products
	})
}).ToList()


ProductSubcategories.Select(ps => ps.ProductCategoryID, ps.Name).Where(Name == "Mountain Bikes")

ProductSubcategories.ProductSubcategoryID

ProductCategories.Where(p => p.Name == "Bikes")

ProductCategories.Where(pc => pc.Name == "Gloves").ProductCategoryID

ProductSubcategories.Where(ps => ps.Name == "Mountain Bikes").Select(ps1 => new { Products = ps1.Products.ToList()})

Products.Where(p => p.ProductSubcategoryID == (ProductSubcategories.Where(ps => ps.Name == "Mountain Bikes" ).Select(ps => ps.ProductSubcategoryID)))


Products.Join(ProductSubcategories.Where(ps => ps.Name == "Gloves"),
	p => p.ProductSubcategoryID,
	ps1 => ps1.ProductSubcategoryID,
	(p, ps1) => new {table = p})

Products.Where(p => p.ProductSubcategoryID ==
	(ProductSubcategories.Where(ps => ps.Name == "Mountain Bikes" && ps.ProductCategoryID == (ProductCategories.ProductCategoryID.Where(pc => pc.Name == "Bike")
	.Select(pc2 => new { ProductCategoryID = pc2.ProductCategoryID })))
	.Select(ps2 => new { ProductSubcategoryID = ps2.ProductSubcategoryID} )))

ProductSubcategories.Where(p => p.ProductCategory.ProductCategoryID == 2).Select(
					p => new 
					{
						ProductCategoryID = p.ProductCategoryID,
						Name = p.Name
					})
					
Customers

Products.Where(p => p.