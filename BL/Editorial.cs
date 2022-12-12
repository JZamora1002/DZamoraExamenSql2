using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Editorial
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            
            try
            {
                using (DL.DZamoraExamenCrudSqlClientEntities context = new DL.DZamoraExamenCrudSqlClientEntities())
                {
                    var getAllQuery = context.EditorialGetAll().ToList();

                    if (getAllQuery != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in getAllQuery)
                        {
                            ML.Editorial editorial = new ML.Editorial();
                            editorial.IdEditorial = obj.IdEditorial;
                            editorial.Nombre = obj.Nombre;
                            result.Objects.Add(editorial);
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
