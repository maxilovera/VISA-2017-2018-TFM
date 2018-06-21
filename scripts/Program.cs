using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFM
{
    class Program
    {
        static void Main(string[] args)
        {
            using (UnirEntities entities = new UnirEntities())
            {
                //Carga de fechas
                //DateTime fechaDesde = new DateTime(2000, 1, 1);
                //DateTime fechaHasta = new DateTime(2017, 12, 31);

                //while (fechaDesde <= fechaHasta)
                //{
                //    entities.Datos.Add(new Datos() { Fecha = fechaDesde }); //Insercion de la fecha
                //    entities.SaveChanges(); //materializacion de la base de datos
                //    fechaDesde = fechaDesde.AddDays(1); //iteracion de fecha para agregar 1 dia.
                //}

                //*****
                //Obtención de registros de la tabla Datos
                //var registros = entities.Datos.ToList();

                //////Obtencion de registros de tabla CotizacionesDolar ordenados por fecha ascendente
                //var cotizaciones = entities.CotizacionesDolar.ToList().OrderBy(x => x.Fecha);

                //foreach (var item in registros) //por cada registro de datos
                //{
                //    if (item.Fecha < new DateTime(2002, 1, 11)) //si la fecha es menor a 1/11/2002
                //        item.CotizacionDolar = 1; //se carga la cotizacion = 1 => convertibilidad
                //    else
                //    {
                //        //Buscamos en las cotizaciones, la que corresponde al día que se está procesando
                //        var cotizacion = cotizaciones.Where(x => x.Fecha == item.Fecha).SingleOrDefault();
                //        //Si no encontro ninguna, puede ser fin de semana.
                //        if (cotizacion == null)
                //        {
                //            //Restamos un día a la fecha y buscamos hacia atras la primera que encontremos. 
                //            //En caso que sea sabado, el ciclo itera una vez, y al restar un día encuentra el valor del viernes.
                //            var fecha = item.Fecha.AddDays(-1);
                //            while (cotizacion == null)
                //            {
                //                cotizacion = cotizaciones.Where(x => x.Fecha == fecha).SingleOrDefault();
                //                fecha = fecha.AddDays(-1);
                //            }
                //        }
                //        //Se actualiza la cotizacion del dolar en la tabla de Datos con el valor de compra del mismo en la tabla de cotizaciones
                //        item.CotizacionDolar = cotizacion.Compra;

                //    }

                //    //Se materializan los cambios en la base de datos
                //    entities.SaveChanges();
                //}

                //lectura de datos del archivo csv descargado
                //using (StreamReader reader = new StreamReader(@"C:\Users\Maximiliano\Google Drive\Máster Visual Analytics Big Data\Trabajo de Fin de Master\Promedio precios diario maiz.csv"))
                //{
                //    int index = 0;
                //    string line = "";
                //    while ((line = reader.ReadLine()) != null) //lectura linea por linea del archivo csv
                //    {
                //        if (index > 0)
                //        {
                //            string[] datos = line.Split(',').Select(x => x.Replace("\"", "")).ToArray(); //obtencion de datos a partir del separador de campos

                //            //Armar el valor del precio anual, mensual y diario de la linea.
                //            var anual = decimal.Parse(datos[1] + "." + datos[2]);
                //            var mensual = decimal.Parse(datos[4] + "." + datos[5]);
                //            var diario = decimal.Parse(datos[7] + "." + datos[8]);
                //            //parseo exacto de la fecha con el formato definido para Argentina
                //            var fecha = DateTime.ParseExact(datos[6], "dd/MM/yyyy", new CultureInfo("es-AR"));

                //            //Creacion del objeto a guardar en DB con los valores leídos.
                //            entities.Promedio_diario_maiz.Add(new Promedio_diario_maiz()
                //            {
                //                Fecha = fecha, Precio = diario, PromedioAnual = anual, PromedioMensual = mensual
                //            });


                //            entities.SaveChanges(); //guardado en base de datos                            
                //        }

                //        index++;
                //    }                    
                //}

                //registros de datos
                //var registros = entities.Datos.ToList();

                //////Obtencion de registros de tabla CotizacionesDolar ordenados por fecha ascendente
                //var cotizaciones = entities.CotizacionesDolar.ToList().OrderBy(x => x.Fecha);

                //foreach (var item in registros)
                //{
                //    //Actualizacion del valor diario
                //    item.PrecioPromedioDiarioMaizUSD = item.PrecioPromedioDiarioMaiz / item.CotizacionDolar;
                //    item.PrecioPromedioDiarioSojaUSD = item.PrecioPromedioDiarioSoja / item.CotizacionDolar;
                //    item.PrecioPromedioDiarioTrigoUSD = item.PrecioPromedioDiarioTrigo / item.CotizacionDolar;

                //    //Actualizacion del valor mensual
                //    var datosMensuales = cotizaciones.Where(x => x.Fecha.Year == item.Fecha.Year && x.Fecha.Month == item.Fecha.Month).ToArray();
                //    var promedioMensual = datosMensuales.Length == 0 ? 1 : datosMensuales.Sum(x => x.Compra) / datosMensuales.Length;

                //    item.PrecioPromedioMensualMaizUSD = item.PrecioPromedioMensualMaiz / promedioMensual;
                //    item.PrecioPromedioMensualSojaUSD = item.PrecioPromedioMensualSoja / promedioMensual;
                //    item.PrecioPromedioMensualTrigoUSD = item.PrecioPromedioMensualTrigo / promedioMensual;

                //    //Actualizacion del valor anual
                //    var datosAnuales= cotizaciones.Where(x => x.Fecha.Year == item.Fecha.Year).ToArray();
                //    var promedioAnual= datosAnuales.Length == 0 ? 1 : datosAnuales.Sum(x => x.Compra) / datosMensuales.Length;

                //    item.PrecioPromedioAnualMaizUSD = item.PrecioPromedioAnualMaiz / promedioAnual;
                //    item.PrecioPromedioAnualSojaUSD = item.PrecioPromedioAnualSoja / promedioAnual;
                //    item.PrecioPromedioAnualTrigoUSD = item.PrecioPromedioAnualTrigo / promedioAnual;

                //    entities.SaveChanges();
                //    Console.WriteLine(item.Fecha.ToShortDateString());
                //}

                //registros de datos
                //var registros = entities.Datos.ToList();

                //foreach (var item in registros.Where(x=>x.PrecioPromedioDiarioMaizUSD!=null))
                //{
                //    //Datos del dia anterior
                //    var diaAnterior = registros.Where(x => x.PrecioPromedioDiarioTrigoUSD != null).Where(x => x.Fecha < item.Fecha).OrderByDescending(x => x.Fecha).Take(1).FirstOrDefault();
                //    //Datos de tres dias anteriores
                //    var tresDiaAnterior = registros.Where(x => x.PrecioPromedioDiarioTrigoUSD != null).Where(x => x.Fecha < item.Fecha).OrderByDescending(x => x.Fecha).Take(3).ToList();
                //    //Datos de siete dias anteriores
                //    var sieteDiaAnterior = registros.Where(x => x.PrecioPromedioDiarioTrigoUSD != null).Where(x => x.Fecha < item.Fecha).OrderByDescending(x => x.Fecha).Take(7).ToList();

                //    item.VariacionTrigoDiaAnterior = 1;
                //    item.VariacionSojaDiaAnterior = 1;
                //    item.VariacionMaizDiaAnterior = 1;

                //    if (diaAnterior != null)
                //    {
                //        item.VariacionTrigoDiaAnterior = item.PrecioPromedioDiarioTrigoUSD / diaAnterior.PrecioPromedioDiarioTrigoUSD - 1 ?? 1;
                //        item.VariacionSojaDiaAnterior = item.PrecioPromedioDiarioSojaUSD / diaAnterior.PrecioPromedioDiarioSojaUSD - 1 ?? 1;
                //        item.VariacionMaizDiaAnterior = item.PrecioPromedioDiarioMaizUSD / diaAnterior.PrecioPromedioDiarioMaizUSD - 1 ?? 1;
                //    }
                    
                //    //Calculo de la variación a tres días
                //    item.VariacionTrigoTresDias = item.PrecioPromedioDiarioTrigoUSD / tresDiaAnterior.Average(x => x.PrecioPromedioDiarioTrigoUSD) - 1 ?? 1;
                //    item.VariacionSojaTresDias = item.PrecioPromedioDiarioSojaUSD / tresDiaAnterior.Average(x => x.PrecioPromedioDiarioSojaUSD) - 1 ?? 1;
                //    item.VariacionMaizTresDia = item.PrecioPromedioDiarioMaizUSD / tresDiaAnterior.Average(x => x.PrecioPromedioDiarioMaizUSD) - 1 ?? 1;
                //    //Calculo de la variacion a siete días
                //    item.VariacionTrigoSieteDias = item.PrecioPromedioDiarioTrigoUSD / sieteDiaAnterior.Average(x => x.PrecioPromedioDiarioTrigoUSD) - 1 ?? 1;
                //    item.VariacionSojaSieteDias = item.PrecioPromedioDiarioSojaUSD / sieteDiaAnterior.Average(x => x.PrecioPromedioDiarioSojaUSD) - 1 ?? 1;
                //    item.VariacionMaizSieteDias = item.PrecioPromedioDiarioMaizUSD / sieteDiaAnterior.Average(x => x.PrecioPromedioDiarioMaizUSD) - 1 ?? 1;

                //    entities.SaveChanges(); //actualizado de registro
                //}
            }
        }
    }
}
