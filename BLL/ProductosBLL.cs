using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using RegistroPedidos.Models;
using RegistroPedidos.Dal;
using Microsoft.EntityFrameworkCore;

namespace RegistroPedidos.BLL
{
    public class ProductosBLL
    {
        public static Productos Buscar(int id)
        {
            Contexto db = new Contexto();
            Productos productos;

            try
            {
                productos = db.Productos.Find(id);
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return productos;
        }

        public static List<Productos> GetList(Expression<Func<Productos, bool>> productos)
        {
            Contexto db = new Contexto();
            List<Productos> Lista = new List<Productos>();

            try
            {
                Lista = db.Productos.Where(productos).ToList();
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return Lista;
        }
    }
}
