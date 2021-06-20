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
    public class OrdenesBLL
    {
        public static bool Guardar(Ordenes ordenes)
        {
            if (!Existe(ordenes.OrdenId))
            {
                return Insertar(ordenes);
            }
            else
            {
                return Modificar(ordenes);
            }
        }

        private static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Ordenes.Any(o => o.OrdenId == id);
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

        private static bool Insertar(Ordenes ordenes)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {

                foreach (var item in ordenes.OrdenesDetalle)
                {
                    var auxOrden = contexto.Productos.Find(item.ProductoId);
                    if (auxOrden != null)
                    {
                        auxOrden.Inventario += item.Cantidad;
                    }
                }

                contexto.Ordenes.Add(ordenes);
                paso = (contexto.SaveChanges() > 0);
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        private static bool Modificar(Ordenes ordenes)
        {
            Contexto contexto = new Contexto();
            var AuxOrden = Buscar(ordenes.OrdenId);
            bool paso = false;

            try
            {
                foreach (var item in AuxOrden.OrdenesDetalle)
                {
                    var auxProducto = contexto.Productos.Find(item.ProductoId);
                    if (!ordenes.OrdenesDetalle.Exists(d => d.OrdenId == item.OrdenId))
                    {
                        if (auxProducto != null)
                        {
                            auxProducto.Inventario -= item.Cantidad;
                        }

                        contexto.Entry(item).State = EntityState.Deleted;
                    }

                }

                foreach (var item in ordenes.OrdenesDetalle)
                {
                    var auxProducto = contexto.Productos.Find(item.ProductoId);
                    if (item.Id == 0)
                    {
                        contexto.Entry(item).State = EntityState.Added;
                        if (auxProducto != null)
                        {
                            auxProducto.Inventario += item.Cantidad;
                        }
                    }
                    else
                        contexto.Entry(item).State = EntityState.Modified;
                }

            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            var AuxOrden = Buscar(id);

            try
            {


                if (Existe(id))
                {
                    //resta las cantidades correspondientes a los producto
                    foreach (var item in AuxOrden.OrdenesDetalle)
                    {
                        var auxProducto = contexto.Productos.Find(item.ProductoId);
                        if (auxProducto != null)
                        {
                            auxProducto.Inventario -= item.Cantidad;
                        }
                    }

                    //remueve la entidad
                    var eliminado = contexto.Ordenes.Find(id);
                    if (eliminado != null)
                    {
                        contexto.Ordenes.Remove(eliminado);
                        paso = contexto.SaveChanges() > 0;
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static Ordenes Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Ordenes ordenes = new Ordenes();

            try
            {
                ordenes = contexto.Ordenes.
                    Where(o => o.OrdenId == id).
                    Include(o => o.OrdenesDetalle).
                    FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return ordenes;
        }

       

        public static List<Ordenes> GetOrdenes()
        {
            List<Ordenes> Lista = new List<Ordenes>();
            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Ordenes.ToList();
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return Lista;
        }

        public static List<Ordenes> GetList(Expression<Func<Ordenes, bool>> ordenes)
        {
            Contexto contexto = new Contexto();
            List<Ordenes> Lista = new List<Ordenes>();

            try
            {
                Lista = contexto.Ordenes.Where(ordenes).ToList();
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return Lista;
        }
    }
}
