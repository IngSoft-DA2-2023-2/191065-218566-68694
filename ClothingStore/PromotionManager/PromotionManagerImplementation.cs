using ClothingStore.Domain.Entities;
//using ClothingStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
            //File.Copy(pathToFile, dllPath);
            try
            {
                File.Move(pathToFile, dllPath + newName);
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.ToString());
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

        public static List<Tuple <string, string>> GetPromotionListMethods()
        {
            if (!Directory.Exists(dllPath) || Directory.GetFiles(dllPath).Length == 2)
            {
                List<Tuple<string, string>> tuple = new List<Tuple<string, string>>();
                return tuple;
            }
            else
            {
                List<Tuple<string, string>> tuple = new List<Tuple<string, string>>();
                foreach (var file in GetPromotionListNamefiles())
                {
                    Assembly assembly = Assembly.LoadFrom(file);
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
                                    if (!minfo.IsStatic && minfo.IsPublic
                                        && (mi.Module.ToString() == assembly.GetModules()[0].Name)
                                        )
                                    {
                                        if (param.ParameterType.ToString() == "ClothesShopping.Domain.Entities.ShoppingCart" ||
                                            param.ParameterType.ToString() == "List<Product>" || 
                                            param.ParameterType.ToString() == "System.Collections.Generic.List`1[ClothingStore.Domain.Entities.Product]")
                                        {
                                            /*object classInstance = Activator.CreateInstance(type, null);
                                            MethodInfo methodInfo = type.GetMethod(mi.Name);
                                            object result = methodInfo.Invoke(classInstance, parametersArray2);*/
                                            //var tupleAux = Tuple<string, string>(mi.Name, file);
                                            tuple.Add(new Tuple<string, string>(mi.Name, file));
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
        public static void RunPromotions(ShoppingCart sp)
        {            
            if(GetPromotionListMethods().Count != 0)
            {
                List<Product> products = GetPromoAvailableProducts(sp);
                if (products.Count > 0) 
                { 
                    //Console.WriteLine("Hay productos.");
                    sp.Total = sp.SubTotal;
                    //sp.AppliedPromotion = "";
                    var lm = GetPromotionListMethods();
                    foreach (var methodname in lm)
                    {
                        foreach (var file in GetPromotionListNamefiles())
                        {
                            Assembly assembly = Assembly.LoadFrom(file);
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
                                            if (!minfo.IsStatic && minfo.IsPublic
                                                && (mi.Module.ToString() == assembly.GetModules()[0].Name)
                                                )
                                            {
                                                if (param.ParameterType.ToString() == "ClothesShopping.Domain.Entities.ShoppingCart")
                                                {
                                                    object classInstance = Activator.CreateInstance(type, null);
                                                    MethodInfo methodInfo = type.GetMethod(mi.Name);
                                                    object[] parametersArray2 = new object[] { sp };
                                                    object result = methodInfo.Invoke(classInstance, parametersArray2);
                                                    //var tupleAux = Tuple<string, string>(mi.Name, file);
                                                    //tuple.Add(new Tuple<string, string>(mi.Name, file));
                                                }
                                                /*if(mi.Name == "DescuentoCuatroProductos")
                                                {
                                                    Console.WriteLine(param.ParameterType.ToString());
                                                }*/
                                                if (param.ParameterType.ToString() == "List<Product>"
                                                    || param.ParameterType.ToString() == "System.Collections.Generic.List`1[ClothingStore.Domain.Entities.Product]")
                                                {
                                                    //Console.WriteLine("Entre por lista de Productos");
                                                    object classInstance = Activator.CreateInstance(type, null);
                                                    if (mi.Name == "TotalWithDiscount") { 
                                                        MethodInfo methodInfo = type.GetMethod(mi.Name);
                                                        object[] parametersArray2 = new object[] { products };
                                                        object result = methodInfo.Invoke(classInstance, parametersArray2);
                                                        double resultado = (double)result;
                                                        if (sp.Total > resultado)
                                                        {
                                                            sp.Total = resultado;
                                                            methodInfo = type.GetMethod("GetName");
                                                            //sp.appliedPromotion = (string)methodInfo.Invoke(classInstance, null);
                                                            Console.WriteLine("El carrito con descuentos: ${0}", sp.Total);
                                                            //Console.WriteLine("El carrito uso descuento: ${0}", sp.appliedPromotion);
                                                        }
                                                }
                                                    //var tupleAux = Tuple<string, string>(mi.Name, file);
                                                    //tuple.Add(new Tuple<string, string>(mi.Name, file));
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
                   Console.WriteLine("Cantidad de productos del carro {0}", products.Count);
                }
                
            }
            else { Console.WriteLine("No hay metodos que se adapten."); }
        }
    }
    
}
