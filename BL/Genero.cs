using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Genero
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            
            try
            {
                using (DL.DZamoraExamenCrudSqlClientEntities context = new DL.DZamoraExamenCrudSqlClientEntities())
                {
                    var getAllQuery = context.GeneroGetAll().ToList();

                    if (getAllQuery != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in getAllQuery)
                        {
                            ML.Genero genero = new ML.Genero();
                            genero.IdGenero = obj.IdGenero;
                            genero.Nombre = obj.Nombre;
                            result.Objects.Add(genero);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = ex.Message;

            }
            return result;
        }
    }
}
