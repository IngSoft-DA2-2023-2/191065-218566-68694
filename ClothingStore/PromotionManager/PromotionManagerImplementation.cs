using ClothingStore.Domain.Entities;
using System.Reflection;
namespace PromotionManager
{
    public class PromotionManagerImplementation
    {
        private static string dllPath = "C:/windows/temp/Promotions";
        public static void PromotionDllLoad(string pathToFile)
        {
            if (!Directory.Exists(dllPath))
            {
                Directory.CreateDirectory(dllPath);
            }
            string newName = DateTime.Now.ToString("/yyyyddMHHmmss") + ".dll";
            try
            {
                File.Copy(pathToFile, dllPath + newName);
            }
            catch (Exception e) 
            {

            }
            
        }

        public static void PromotionDllUnload(string filename)
        {
            if (Directory.Exists(dllPath))
            {
                File.Delete(dllPath + "/" + filename);
            }
        }
        
        public static List <string> GetPromotionListNamefiles()
        {
            if (Directory.Exists(dllPath))
                return Directory.GetFiles(dllPath).ToList<string>();
            return new List<string>();
        }

        public static List<Tuple<string, string, string>> GetPromotionListMethods()
        {
            List<Tuple<string, string, string>> tuple = new List<Tuple<string, string, string>>();
            int dllquantity = Directory.GetFiles(dllPath).Length;

            if (!Directory.Exists(dllPath) || dllquantity == 0)
            {                
                return tuple;
            }
            else
            {
                foreach (var file in GetPromotionListNamefiles())
                {
                    Assembly assembly = Assembly.Load(File.ReadAllBytes(file));

                    Type[] types = assembly.GetTypes();
                    foreach (Type type in types)
                    {
                        MemberInfo[] mb = type.GetMembers();
                        foreach (MemberInfo mi in mb)
                        {
                            if (mi.MemberType == MemberTypes.Method)
                            {
                                var minfo = (MethodInfo)mi;
                                ParameterInfo[] pi = minfo.GetParameters();
                                foreach (var param in pi)
                                {
                                    if (!minfo.IsStatic && minfo.IsPublic)
                                    {
                                        if (param.ParameterType.ToString() == "ClothesShopping.Domain.Entities.ShoppingCart" ||
                                            param.ParameterType.ToString() == "List<Product>" ||
                                            param.ParameterType.ToString() == "System.Collections.Generic.List`1[ClothingStore.Domain.Entities.Product]")
                                        {
                                            object classInstance = Activator.CreateInstance(type, null);
                                            MethodInfo promoname = type.GetMethod("GetName");
                                            MethodInfo promodesc = type.GetMethod("GetDescription");
                                            string promonamestring = (string)promoname.Invoke(classInstance, null);
                                            string promodescstring = (string)promodesc.Invoke(classInstance, null);

                                            tuple.Add(new Tuple<string, string, string>(promonamestring, promodescstring, file));
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                return tuple;
            }
        }
        public static List<Product> GetPromoAvailableProducts(ShoppingCart sp)
        {
            List<Product> products = new List<Product>();
            foreach(var p in sp.Products)
            {
                if (p.PromoAvailable)
                {
                    products.Add(p);
                }
            }
            return products;
        }

        private static Assembly LoadAssembly(string assemblyfile)
        {
            Assembly assembly = Assembly.Load(File.ReadAllBytes(assemblyfile));
            return assembly;
        }
        public static void RunPromotions(ShoppingCart sp)
        {
            List<Product> products = GetPromoAvailableProducts(sp);
            if (products.Count > 0) 
            {
                sp.Total = sp.SubTotal;
                    var lplnf = GetPromotionListNamefiles();
                    foreach (var file in lplnf)
                    {
                        Assembly assembly = LoadAssembly((string)file);
                        Type[] types = assembly.GetTypes();
                        foreach (Type type in types)
                        {
                            MemberInfo[] mb = type.GetMembers();
                            foreach (MemberInfo mi in mb)
                            {
                                if (mi.MemberType == MemberTypes.Method)
                                {
                                    var minfo = (MethodInfo)mi;
                                    ParameterInfo[] pi = minfo.GetParameters();
                                    foreach (var param in pi)
                                    {
                                        string moduleceroname = assembly.GetModules()[0].Name;
                                        string mimodule = mi.Module.ToString();
                                        if (!minfo.IsStatic && minfo.IsPublic
                                            )
                                        {
                                            if (param.ParameterType.ToString() == "ClothesShopping.Domain.Entities.ShoppingCart")
                                            {
                                                object classInstance = Activator.CreateInstance(type, null);
                                                MethodInfo methodInfo = type.GetMethod(mi.Name);
                                                object[] parametersArray2 = new object[] { sp };
                                                object result = methodInfo.Invoke(classInstance, parametersArray2);
                                            }
                                            if (param.ParameterType.ToString() == "List<Product>"
                                                || param.ParameterType.ToString() == "System.Collections.Generic.List`1[ClothingStore.Domain.Entities.Product]")
                                            {
                                                object classInstance = Activator.CreateInstance(type, null);
                                                if (mi.Name == "TotalWithDiscount") { 
                                                    MethodInfo methodInfo = type.GetMethod(mi.Name);
                                                    object[] parametersArray2 = new object[] { products };
                                                    object result = methodInfo.Invoke(classInstance, parametersArray2);
                                                    double resultado = (double)result;
                                                    if (resultado > sp.Discount)
                                                    {
                                                        sp.Total = sp.SubTotal - resultado;
                                                        sp.Discount = resultado;
                                                        methodInfo = type.GetMethod("GetName");
                                                        sp.PromotionName = (string)methodInfo.Invoke(classInstance, null);
                                                    }
                                            }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                    }

            }
            else 
            { 
               //Console.WriteLine("Cantidad de productos del carro {0}", products.Count);
            }
        }
    }    
}
