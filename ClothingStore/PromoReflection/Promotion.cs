using ClothingStore.Domain.Entities;

namespace PromoReflection
{
    public class Promotion
    {
        private static string name = "Promo 30 Off";
        private static string description = "Si tiene más de 2 productos se descuenta el 20%";

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

            if (products.Count <= 1)
            {
                return 0;
            }
            else
            {
                double mayor = 0;
                int productPromoAvailableQuantity = 0;
                foreach (var product in products)
                {
                    if (product.PromoAvailable)
                    {
                        productPromoAvailableQuantity++;
                        if (product.Price > mayor)
                        {
                            mayor = product.Price;
                        }
                    }
                }
                if (productPromoAvailableQuantity >= 2)
                {
                    return (mayor * 0.3);
                }
                else
                {
                    return 0;
                }
            }

            //Calculate here your discount over products and return it
            //The list contains only available products for discount

            return discount;
        }

    }
}