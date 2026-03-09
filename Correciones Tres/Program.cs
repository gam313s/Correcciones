using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int cantidadProductos = ObtenerCantidadProductos();

        List<string> nombres = new List<string>();
        List<double> precios = new List<double>();

        for (int i = 0; i < cantidadProductos; i++)
        {
            Console.Write($"\nNombre del producto #{i + 1}: ");
            string nombre = Console.ReadLine();
            nombres.Add(nombre);

            double precio = ObtenerPrecio();
            precios.Add(precio);
        }

        MostrarProductos(nombres, precios, cantidadProductos); //el orden va nombres precios no precios nombres 
    }

    // FUNCION 1
    static int ObtenerCantidadProductos()
    {
        int cantidadProductos = 0;

        while (true) //cambiar a true 
        {
            Console.Write("¿Cuántos productos desea registrar?: ");
            string entrada = Console.ReadLine();

            try
            {
                cantidadProductos = int.Parse(entrada);

                if (cantidadProductos < 1)
                {
                    Console.WriteLine("Debe ingresar un número igual o mayor a 1.\n");
                    // aqui si no va el return cantidadProductso;
                }
                else
                {
                    return cantidadProductos;//se coloca aqui el return
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Entrada no válida. Debe ingresar un número entero.\n");
            }
        }
    }

    // FUNCION 2
    static double ObtenerPrecio()
    {
        while (true) //eliminar la ! no va
        {
            Console.Write("Precio del producto: ");
            string entradaPrecio = Console.ReadLine();

            // no va aqui el return y hay que agregar el precio;
            try
            {
                double precio = double.Parse(entradaPrecio);
                return precio;//se coloca aqui el retunr de precio 
            }
            catch (FormatException)
            {
                Console.WriteLine("Precio inválido. Intente nuevamente.");
            }
        }
    }

    // PROCEDIMIENTO cambiar a void ya que esta en int
    static void MostrarProductos(List<string> nombres, List<double> precios, int cantidadProductos)
    {
        if (cantidadProductos == 1)
        {
            Console.WriteLine("\nProducto registrado:");
            Console.WriteLine($"{nombres[0]} - ${precios[0]}");

            if (precios[0] >= 100)
                Console.WriteLine("Es un producto caro.");
            else
                Console.WriteLine("Es un producto económico.");
        }
        else
        {
            //eliminar i=1 si no se rompe el codigo 
            List<string> productosCaros = new List<string>();
            List<string> productosEconomicos = new List<string>();

            Console.WriteLine("\nLista general de productos:");
            //poner int i = 0 
            for (int i = 0; i < nombres.Count; i++)
            {
                Console.WriteLine($"{nombres[i]} - ${precios[i]}");

                if (precios[i] >= 100)
                    productosCaros.Add($"{nombres[i]} - ${precios[i]}");
                else
                    productosEconomicos.Add($"{nombres[i]} - ${precios[i]}");
            }

            if (productosCaros.Count > 0)
            {
                Console.WriteLine("\nProductos caros:");
                foreach (string producto in productosCaros)
                    Console.WriteLine(producto);
            }

            if (productosEconomicos.Count > 0)
            {
                Console.WriteLine("\nProductos económicos:");
                foreach (string producto in productosEconomicos)
                    Console.WriteLine(producto);
            }
        }
    }
}