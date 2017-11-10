<Query Kind="Expression">
  <Connection>
    <ID>cce46324-1db9-43d2-b0e3-afb826184060</ID>
    <Persist>true</Persist>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <Database>AdventureWorks2016</Database>
  </Connection>
</Query>

ProductSubcategories

ProductCategories

Products.Where(p => p.ProductID

ProductSubcategories.Where(p => p.ProductCategory.ProductCategoryID == 2).Select(
					p => new 
					{
						ProductCategoryID = p.ProductCategoryID,
						Name = p.Name
					})