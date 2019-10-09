db.Products.insertMany([
	{
        _id: 1,
        sku: “111”,
        description: “Óleo Diesel 1L”,
        createdAt: "2019-10-08",
        bundleId: 1,
        salesPrice: 1.5
    },
	{
        _id: 2,
        sku: “222”,
        description: “Caixa de Pregos”,
        createdAt: "2019-10-08",
        bundleId: 2,
        salesPrice: 3.5
    },
	{
        _id: 3,
        sku: “333”,
        description: "Saco Arroz”,
        createdAt: "2019-10-08",
        bundleId: 3,
        salesPrice: 0.5
	}
]);