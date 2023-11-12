using ClothingStore.Domain.Entities;

namespace PromoReflection
{
    public class Promotion
    {
        private static string name = "Descuento de muestra";
        private static string description = "Descripcion de muestra";

        public string GetName() { return name; }
        public string GetDescription() { return description; }
        private double TotalAmount(List<Product> products)
        {
            double totalactual = 0;
            foreach (Product product in products)
            {
                totalactual = totalactual + product.Price;
            }
            return totalactual;
        }
        public double TotalWithDiscount(List<Product> products)
        {
            var subtotal = TotalAmount(products);
            subtotal = subtotal * 0.6;

            //Calculate discount over products and return total with discount
            
            return subtotal;
        }

    }
}