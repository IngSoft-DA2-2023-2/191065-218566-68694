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
            double discount = TotalAmount(products);

            //Calculate here your discount over products and return it
            //The list contains only available products for discount
            
            return discount;
        }

    }
}