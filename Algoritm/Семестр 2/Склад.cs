namespace storage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>
            {
                new Product { Name = "Кофе", Category = "Пищевые продукты", Count = 150, Price = 279.99, Storage = "Склад 1" },
                new Product { Name = "Шоколад", Category = "Пищевые продукты", Count = 200, Price = 79.99, Storage = "Склад 1" },
                new Product { Name = "Колбаса", Category = "Пищевые продукты", Count = 300, Price = 359.99, Storage = "Склад 2" },
                new Product { Name = "Пельмени", Category = "Пищевые продукты", Count = 250, Price = 359.99, Storage = "Склад 2" },
                new Product { Name = "Наушники", Category = "Электроника", Count = 45, Price = 9999.99, Storage = "Склад 3" },
                new Product { Name = "Ноутбук", Category = "Электроника", Count = 30, Price = 99999.99, Storage = "Склад 3" },
                new Product { Name = "Микрофон", Category = "Электроника", Count = 28, Price = 7899.99, Storage = "Склад 4" },
                new Product { Name = "Харуки Мураками 'Мой любимый Sputnik'", Category = "Книги", Count = 40, Price = 499.99, Storage = "Склад 4" },
                new Product { Name = "Фрэнсис Скотт 'Великий Гэтсби'", Category = "Книги", Count = 20, Price = 599.99, Storage = "Склад 1" },
                new Product { Name = "Фостер Уоллес 'Бесконечная шутка'", Category = "Книги", Count = 15, Price = 459.99, Storage = "Склад 2" },
                new Product { Name = "Настольная лампа", Count = 16, Price = 1799.99, Storage = "Склад 3" },
                new Product { Name = "Ароматические свечи", Count = 79, Price = 299.99, Storage = "Склад 1" }
            };


            var storageCount = from product in products
                               group product by product.Storage into g
                               select new { Name = g.Key, Count = g.Select(x => x.Count).Sum() };


            var maxCategoryPrice = from product in products
                                   where product.Category != null
                                   group product by product.Category into g
                                   select new { Category = g.Key, MaxPrice = g.Select(x => x.Price).Max() };


            var AvgWithEmptyCategory = (from product in products
                                        where product.Category == null
                                        select product.Price).Average();


            var MinPrice = (from product in products
                            select product.Price).Min();


            var SumPrice = (from product in products
                            select product.Price).Sum();

            Console.WriteLine("Объём товаров по каждому из складов");
            foreach (var i in storageCount) Console.WriteLine($"Склад: {i.Name}. Количество товара на складе: {i.Count}");

            Console.WriteLine("\nМаксимальная цена по каждой категории");
            foreach (var i in maxCategoryPrice) Console.WriteLine($"Категория: {i.Category}. Максимальная цена: {i.MaxPrice}");

            Console.WriteLine($"\nСредняя цена товаров без категории: {AvgWithEmptyCategory}");
            Console.WriteLine($"\nМинимальная цена со всех складов: {MinPrice}");
            Console.WriteLine($"\nОбщая стоимость товаров со всех складов: {SumPrice}");
        }
    }

    struct Product
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public string Storage { get; set; }
    }
}
