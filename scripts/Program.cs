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

                //VariacionesTrigo(entities);
                //VariacionesSoja(entities);
                //VariacionesMaiz(entities);

                var registros = entities.Datos.ToList();

                //foreach (var item in registros)
                //{
                //    //obtencion de datos historicos
                //    var valoresNoventa = registros.Where(x => x.Fecha >= item.Fecha.AddDays(-90) && x.Fecha < item.Fecha).ToList();
                //    var valoresSesenta = registros.Where(x => x.Fecha >= item.Fecha.AddDays(-60) && x.Fecha < item.Fecha).ToList();
                //    var valoresCuarentaCinco = registros.Where(x => x.Fecha >= item.Fecha.AddDays(-45) && x.Fecha < item.Fecha).ToList();
                //    var valoresTreinta = registros.Where(x => x.Fecha >= item.Fecha.AddDays(-30) && x.Fecha < item.Fecha).ToList();
                //    var valoresQuince = registros.Where(x => x.Fecha >= item.Fecha.AddDays(-15) && x.Fecha < item.Fecha).ToList();
                //    var valoresSiete = registros.Where(x => x.Fecha >= item.Fecha.AddDays(-7) && x.Fecha < item.Fecha).ToList();

                //    //Actualizacion de datos
                //    item.PrecioPromedioTreintaDiasMaiz = valoresTreinta.Where(x=>x.PrecioPromedioDiarioMaizUSD!=null)
                //        .Select(x => x.PrecioPromedioDiarioMaizUSD).Average() ?? 0;
                //    item.PrecioPromedioTreintaDiasSoja = valoresTreinta.Where(x => x.PrecioPromedioDiarioMaizUSD != null)
                //        .Select(x => x.PrecioPromedioDiarioSojaUSD).Average() ?? 0;
                //    item.PrecioPromedioTreintaDiasTrigo = valoresTreinta.Where(x => x.PrecioPromedioDiarioMaizUSD != null)
                //        .Select(x => x.PrecioPromedioDiarioTrigoUSD).Average() ?? 0;

                //    item.PrecioPromedioSesentaDiasMaiz = valoresSesenta.Where(x => x.PrecioPromedioDiarioMaizUSD != null)
                //        .Select(x => x.PrecioPromedioDiarioMaizUSD).Average() ?? 0;
                //    item.PrecioPromedioSesentaDiasSoja = valoresSesenta.Where(x => x.PrecioPromedioDiarioMaizUSD != null)
                //        .Select(x => x.PrecioPromedioDiarioSojaUSD).Average() ?? 0;
                //    item.PrecioPromedioSesentaDiasTrigo = valoresSesenta.Where(x => x.PrecioPromedioDiarioMaizUSD != null)
                //        .Select(x => x.PrecioPromedioDiarioTrigoUSD).Average() ?? 0;

                //    item.PrecioPromedioNoventaDiasMaiz = valoresNoventa.Where(x => x.PrecioPromedioDiarioMaizUSD != null)
                //        .Select(x => x.PrecioPromedioDiarioMaizUSD).Average() ?? 0;
                //    item.PrecioPromedioNoventaDiasSoja = valoresNoventa.Where(x => x.PrecioPromedioDiarioMaizUSD != null)
                //        .Select(x => x.PrecioPromedioDiarioSojaUSD).Average() ?? 0;
                //    item.PrecioPromedioNoventaDiasTrigo = valoresNoventa.Where(x => x.PrecioPromedioDiarioMaizUSD != null)
                //        .Select(x => x.PrecioPromedioDiarioTrigoUSD).Average() ?? 0;

                //    item.LluviaDiariaAcumuladaSieteDiasSantaFe = valoresSiete.Sum(x => x.LluviaDiariaSantaFe);
                //    item.LluviaDiariaAcumuladaSieteDiasBuenosAires = valoresSiete.Sum(x => x.LluviaDiariaBuenosAires);
                //    item.LluviaDiariaAcumuladaSieteDiasCordoba = valoresSiete.Sum(x => x.LluviaDiariaCordoba);

                //    item.LluviaDiariaAcumuladaQuinceDiasSantaFe = valoresQuince.Sum(x => x.LluviaDiariaSantaFe);
                //    item.LluviaDiariaAcumuladaQuinceDiasBuenosAires = valoresQuince.Sum(x => x.LluviaDiariaBuenosAires);
                //    item.LluviaDiariaAcumuladaQuinceDiasCordoba = valoresQuince.Sum(x => x.LluviaDiariaCordoba);

                //    item.LluviaDiariaAcumuladaTreintaDiasSantaFe = valoresTreinta.Sum(x => x.LluviaDiariaSantaFe);
                //    item.LluviaDiariaAcumuladaTreintaDiasBuenosAires = valoresTreinta.Sum(x => x.LluviaDiariaBuenosAires);
                //    item.LluviaDiariaAcumuladaTreintaDiasCordoba = valoresTreinta.Sum(x => x.LluviaDiariaCordoba);

                //    item.LluviaDiariaAcumuladaCuarentaCincoDiasSantaFe = valoresCuarentaCinco.Sum(x => x.LluviaDiariaSantaFe);
                //    item.LluviaDiariaAcumuladaCuarentaCincoDiasBuenosAires = valoresCuarentaCinco.Sum(x => x.LluviaDiariaBuenosAires);
                //    item.LluviaDiariaAcumuladaCuarentaCincoDiasCordoba = valoresCuarentaCinco.Sum(x => x.LluviaDiariaCordoba);

                //    item.LluviaDiariaAcumuladaSesentaDiasSantaFe =  valoresSesenta.Sum(x => x.LluviaDiariaSantaFe);
                //    item.LluviaDiariaAcumuladaSesentaDiasBuenosAires = valoresSesenta.Sum(x => x.LluviaDiariaBuenosAires);
                //    item.LluviaDiariaAcumuladaSesentaDiasCordoba = valoresSesenta.Sum(x => x.LluviaDiariaCordoba);

                //    entities.SaveChanges();

                //    Console.WriteLine(item.Fecha.ToString());
                //}
                
                //ActualizacionLluviasCordoba(entities, registros);

                GenerarArchivoMaiz24(registros);
                GenerarArchivoMaiz72(registros);
                GenerarArchivoMaiz120(registros);

                GenerarArchivoSoja24(registros);
                GenerarArchivoSoja72(registros);
                GenerarArchivoSoja120(registros);

                GenerarArchivoTrigo24(registros);
                GenerarArchivoTrigo72(registros);
                GenerarArchivoTrigo120(registros);


            }
        }

        private static void VariacionesTrigo(UnirEntities entities)
        {
            //registros de datos
            var registros = entities.Datos.ToList();

            foreach (var item in registros)
            {
                if (item.PrecioPromedioDiarioTrigoUSD == null)
                {
                    item.VariacionTrigoDiaAnterior = 0;
                    item.VariacionTrigoTresDias = 0;
                    item.VariacionTrigoSieteDias = 0;                    
                }
                else
                {
                    //Datos del dia anterior
                    var diaAnterior = registros.Where(x => x.PrecioPromedioDiarioTrigoUSD != null).Where(x => x.Fecha < item.Fecha).OrderByDescending(x => x.Fecha).Take(1).FirstOrDefault();
                    //Datos de tres dias anteriores
                    var tresDiaAnterior = registros.Where(x => x.PrecioPromedioDiarioTrigoUSD != null).Where(x => x.Fecha < item.Fecha).OrderByDescending(x => x.Fecha).Take(3).ToList();
                    //Datos de siete dias anteriores
                    var sieteDiaAnterior = registros.Where(x => x.PrecioPromedioDiarioTrigoUSD != null).Where(x => x.Fecha < item.Fecha).OrderByDescending(x => x.Fecha).Take(7).ToList();

                    item.VariacionTrigoDiaAnterior = 0;

                    if (diaAnterior != null)
                    {
                        item.VariacionTrigoDiaAnterior = item.PrecioPromedioDiarioTrigoUSD / diaAnterior.PrecioPromedioDiarioTrigoUSD - 1 ?? 0;
                    }

                    //Calculo de la variación a tres días
                    item.VariacionTrigoTresDias = item.PrecioPromedioDiarioTrigoUSD / tresDiaAnterior.Average(x => x.PrecioPromedioDiarioTrigoUSD) - 1 ?? 0;
                    //Calculo de la variacion a siete días
                    item.VariacionTrigoSieteDias = item.PrecioPromedioDiarioTrigoUSD / sieteDiaAnterior.Average(x => x.PrecioPromedioDiarioTrigoUSD) - 1 ?? 0;                    
                }

                entities.SaveChanges(); //actualizado de registro
                Console.WriteLine($"Actualizado trigo {item.Fecha.ToString()}");
            }
        }

        private static void VariacionesMaiz(UnirEntities entities)
        {
            //registros de datos
            var registros = entities.Datos.ToList();

            foreach (var item in registros)
            {
                if (item.PrecioPromedioDiarioMaizUSD == null)
                {
                    item.VariacionMaizDiaAnterior = 0;
                    item.VariacionMaizTresDia = 0;
                    item.VariacionMaizSieteDias = 0;
                }
                else
                {
                    //Datos del dia anterior
                    var diaAnterior = registros.Where(x => x.PrecioPromedioDiarioMaizUSD != null).Where(x => x.Fecha < item.Fecha).OrderByDescending(x => x.Fecha).Take(1).FirstOrDefault();
                    //Datos de tres dias anteriores
                    var tresDiaAnterior = registros.Where(x => x.PrecioPromedioDiarioMaizUSD != null).Where(x => x.Fecha < item.Fecha).OrderByDescending(x => x.Fecha).Take(3).ToList();
                    //Datos de siete dias anteriores
                    var sieteDiaAnterior = registros.Where(x => x.PrecioPromedioDiarioMaizUSD != null).Where(x => x.Fecha < item.Fecha).OrderByDescending(x => x.Fecha).Take(7).ToList();

                    item.VariacionMaizDiaAnterior = 0;

                    if (diaAnterior != null)
                    {
                        item.VariacionMaizDiaAnterior = item.PrecioPromedioDiarioMaizUSD / diaAnterior.PrecioPromedioDiarioMaizUSD - 1 ?? 0;
                    }

                    //Calculo de la variación a tres días
                    item.VariacionMaizTresDia = item.PrecioPromedioDiarioMaizUSD / tresDiaAnterior.Average(x => x.PrecioPromedioDiarioMaizUSD) - 1 ?? 0;
                    //Calculo de la variacion a siete días
                    item.VariacionMaizSieteDias = item.PrecioPromedioDiarioMaizUSD / sieteDiaAnterior.Average(x => x.PrecioPromedioDiarioMaizUSD) - 1 ?? 0;
                }

                entities.SaveChanges(); //actualizado de registro

                Console.WriteLine($"Actualizado maiz {item.Fecha.ToString()}");
            }
        }

        private static void VariacionesSoja(UnirEntities entities)
        {
            //registros de datos
            var registros = entities.Datos.ToList();

            foreach (var item in registros)
            {
                if (item.PrecioPromedioDiarioSojaUSD == null)
                {
                    item.VariacionSojaDiaAnterior = 0;
                    item.VariacionSojaTresDias = 0;
                    item.VariacionSojaSieteDias = 0;
                }
                else
                {
                    //Datos del dia anterior
                    var diaAnterior = registros.Where(x => x.PrecioPromedioDiarioSojaUSD != null).Where(x => x.Fecha < item.Fecha).OrderByDescending(x => x.Fecha).Take(1).FirstOrDefault();
                    //Datos de tres dias anteriores
                    var tresDiaAnterior = registros.Where(x => x.PrecioPromedioDiarioSojaUSD != null).Where(x => x.Fecha < item.Fecha).OrderByDescending(x => x.Fecha).Take(3).ToList();
                    //Datos de siete dias anteriores
                    var sieteDiaAnterior = registros.Where(x => x.PrecioPromedioDiarioSojaUSD != null).Where(x => x.Fecha < item.Fecha).OrderByDescending(x => x.Fecha).Take(7).ToList();

                    item.VariacionSojaDiaAnterior = 0;

                    if (diaAnterior != null)
                    {
                        item.VariacionSojaDiaAnterior = item.PrecioPromedioDiarioSojaUSD / diaAnterior.PrecioPromedioDiarioSojaUSD - 1 ?? 0;
                    }

                    //Calculo de la variación a tres días
                    item.VariacionSojaTresDias = item.PrecioPromedioDiarioSojaUSD / tresDiaAnterior.Average(x => x.PrecioPromedioDiarioSojaUSD) - 1 ?? 0;
                    //Calculo de la variacion a siete días
                    item.VariacionSojaSieteDias = item.PrecioPromedioDiarioSojaUSD / sieteDiaAnterior.Average(x => x.PrecioPromedioDiarioSojaUSD) - 1 ?? 0;
                }

                entities.SaveChanges(); //actualizado de registro

                Console.WriteLine($"Actualizado Soja {item.Fecha.ToString()}");
            }
        }

        private static void ActualizacionLluviasCordoba(UnirEntities entities, List<Datos> registros)
        {
            //Iteracion de filas
            foreach (var item in registros)
            {
                //promedio mensual
                var mensual = registros.Where(x => x.Fecha.Month == item.Fecha.Month && x.Fecha.Year == item.Fecha.Year)
                    .Select(x => x.LluviaDiariaCordoba).Average() ?? 0;

                //promedio anual
                var anual = registros.Where(x => x.Fecha.Year == item.Fecha.Year).Select(x => x.LluviaDiariaCordoba).Average() ?? 0;

                //actualizacion de datos del registro
                item.LLuviaMensualCordoba = mensual;
                item.LluviaAnualCordoba = anual;

                entities.SaveChanges();

                Console.WriteLine($"Actualizado {item.Fecha.ToString()}");
            }
        }

        private static void GenerarArchivoMaiz120(List<Datos> registros)
        {
            using (StreamWriter writer = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "maiz-120hs.csv"))
            {
                registros = registros.Where(x => x.PrecioPromedioDiarioMaizUSD != null).ToList(); //solo obtenemos los que tienen cotizacion calculada
                                                                                                  //escritura del header
                writer.WriteLine($"LluviaDiariaSantaFe,LluviaDiariaBuenosAires,LluviaDiariaCordoba,CotizacionDolar,PrecioPromedioDiarioMaizUSD,SuperficieSembradaMaizSantaFe," +
                    $"SuperficieSembradaMaizBuenosAires," +
                    $"SuperficieSembradaMaizCordoba,SuperficieCosechadaMaizSantaFe," +
                    $"SuperficieCosechadaMaizBuenosAires,SuperficieCosechadaMaizCordoba,ProduccionMaizSantaFe,ProduccionMaizBuenosAires,ProduccionMaizCordoba," +
                    $"RendimientoMaizSantaFe,RendimientoMaizBuenosAires," +
                    $"RendimientoMaizCordoba,PromedioIncendiosMensualesSantaFe,PromedioIncendiosMensualesBuenosAires,PromedioIncendioMensualesCordoba," +
                    $"VariacionMaizDiaAnterior,VariacionMaizTresDia," +
                    $"VariacionMaizSieteDias,LluviaAcumuladaSieteDiasSantaFe," +
                    $"LluviaDiariaAcumuladaSieteDiasBuenosAires,LluviaDiariaAcumuladaSieteDiasCordoba,LluviaDiariaAcumuladaSieteDiasSantaFe," +
                    $"LluviaDiariaAcumuladaSieteDiasBuenosAires,LluviaDiariaAcumuladaSieteDiasCordoba,LluviaDiariaAcumuladaTreintaDiasSantaFe," +
                    $"LluviaDiariaAcumuladaTreintaDiasBuenosAires,LluviaDiariaAcumuladaTreintaDiasCordoba," +
                    $"LluviaDiariaAcumuladaCuarentaCincoDiasSantaFe,LluviaDiariaAcumuladaCuarentaCincoDiasBuenosAires,LluviaDiariaAcumuladaCuarentaCincoDiasCordoba," +
                    $"LluviaDiariaAcumuladaSesentaDiasSantaFe,LluviaDiariaAcumuladaSesentaDiasBuenosAires,LluviaDiariaAcumuladaSesentaDiasCordoba," +
                    $"PrecioPromedioTreintaDiasMaiz,PrecioPromedioSesentaDiasMaiz,PrecioPromedioNoventaDiasMaiz,PrecioRealDiaSiguiente");

                for (int i = 0; i < registros.Count - 5; i++) //Vamos hasta el anteultimo registro para obtener el precio real del dia siguiente
                {
                    var item = registros[i];
                    var itemPredict = registros[i + 5]; //atributo de salida. Precio del cultivo a 24 horas
                                                        //Escribimos la linea del archivo
                    writer.WriteLine($"{item.LluviaDiariaSantaFe},{item.LluviaDiariaBuenosAires},{item.LluviaDiariaCordoba},{item.CotizacionDolar}," +
                        $"{item.PrecioPromedioDiarioMaizUSD}," +
                            $"{item.SuperficieSembradaMaizSantaFe},{item.SuperficieSembradaMaizBuenosAires},{item.SuperficieSembradaMaizCordoba},{item.SuperficieCosechadaMaizSantaFe}," +
                            $"{item.SuperficieCosechadaMaizBuenosAires}," +
                            $"{item.SuperficieCosechadaMaizCordoba},{item.ProduccionMaizSantaFe},{item.ProduccionMaizBuenosAires},{item.ProduccionMaizCordoba},{item.RendimientoMaizSantaFe}," +
                            $"{item.RendimientoMaizBuenosAires},{item.RendimientoMaizCordoba},{item.PromedioIncendiosMensualesSantaFe},{item.PromedioIncendiosMensualesBuenosAires}," +
                            $"{item.PromedioIncendiosMensualesCordoba},{item.VariacionMaizDiaAnterior},{item.VariacionMaizTresDia},{item.VariacionMaizSieteDias},{item.LluviaDiariaAcumuladaSieteDiasSantaFe}," +
                            $"{item.LluviaDiariaAcumuladaSieteDiasBuenosAires},{item.LluviaDiariaAcumuladaSieteDiasCordoba},{item.LluviaDiariaAcumuladaSieteDiasSantaFe}," +
                            $"{item.LluviaDiariaAcumuladaSieteDiasBuenosAires},{item.LluviaDiariaAcumuladaSieteDiasCordoba},{item.LluviaDiariaAcumuladaTreintaDiasSantaFe}," +
                            $"{item.LluviaDiariaAcumuladaTreintaDiasBuenosAires},{item.LluviaDiariaAcumuladaTreintaDiasCordoba},{item.LluviaDiariaAcumuladaCuarentaCincoDiasSantaFe}," +
                            $"{item.LluviaDiariaAcumuladaCuarentaCincoDiasBuenosAires},{item.LluviaDiariaAcumuladaCuarentaCincoDiasCordoba},{item.LluviaDiariaAcumuladaSesentaDiasSantaFe}," +
                            $"{item.LluviaDiariaAcumuladaSesentaDiasBuenosAires},{item.LluviaDiariaAcumuladaSesentaDiasCordoba},{item.PrecioPromedioTreintaDiasMaiz}," +
                            $"{item.PrecioPromedioSesentaDiasMaiz},{item.PrecioPromedioNoventaDiasMaiz},{itemPredict.PrecioPromedioDiarioMaizUSD}");
                }
            }
        }

        private static void GenerarArchivoMaiz72(List<Datos> registros)
        {
            using (StreamWriter writer = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "maiz-72hs.csv"))
            {
                registros = registros.Where(x => x.PrecioPromedioDiarioMaizUSD != null).ToList(); //solo obtenemos los que tienen cotizacion calculada
                                                                                                  //escritura del header
                writer.WriteLine($"LluviaDiariaSantaFe,LluviaDiariaBuenosAires,LluviaDiariaCordoba,CotizacionDolar,PrecioPromedioDiarioMaizUSD,SuperficieSembradaMaizSantaFe," +
                    $"SuperficieSembradaMaizBuenosAires," +
                    $"SuperficieSembradaMaizCordoba,SuperficieCosechadaMaizSantaFe," +
                    $"SuperficieCosechadaMaizBuenosAires,SuperficieCosechadaMaizCordoba,ProduccionMaizSantaFe,ProduccionMaizBuenosAires,ProduccionMaizCordoba," +
                    $"RendimientoMaizSantaFe,RendimientoMaizBuenosAires," +
                    $"RendimientoMaizCordoba,PromedioIncendiosMensualesSantaFe,PromedioIncendiosMensualesBuenosAires,PromedioIncendioMensualesCordoba," +
                    $"VariacionMaizDiaAnterior,VariacionMaizTresDia," +
                    $"VariacionMaizSieteDias,LluviaAcumuladaSieteDiasSantaFe," +
                    $"LluviaDiariaAcumuladaSieteDiasBuenosAires,LluviaDiariaAcumuladaSieteDiasCordoba,LluviaDiariaAcumuladaSieteDiasSantaFe," +
                    $"LluviaDiariaAcumuladaSieteDiasBuenosAires,LluviaDiariaAcumuladaSieteDiasCordoba,LluviaDiariaAcumuladaTreintaDiasSantaFe," +
                    $"LluviaDiariaAcumuladaTreintaDiasBuenosAires,LluviaDiariaAcumuladaTreintaDiasCordoba," +
                    $"LluviaDiariaAcumuladaCuarentaCincoDiasSantaFe,LluviaDiariaAcumuladaCuarentaCincoDiasBuenosAires,LluviaDiariaAcumuladaCuarentaCincoDiasCordoba," +
                    $"LluviaDiariaAcumuladaSesentaDiasSantaFe,LluviaDiariaAcumuladaSesentaDiasBuenosAires,LluviaDiariaAcumuladaSesentaDiasCordoba," +
                    $"PrecioPromedioTreintaDiasMaiz,PrecioPromedioSesentaDiasMaiz,PrecioPromedioNoventaDiasMaiz,PrecioRealDiaSiguiente");

                for (int i = 0; i < registros.Count - 3; i++) //Vamos hasta el anteultimo registro para obtener el precio real del dia siguiente
                {
                    var item = registros[i];
                    var itemPredict = registros[i + 3]; //atributo de salida. Precio del cultivo a 24 horas
                                                        //Escribimos la linea del archivo
                    writer.WriteLine($"{item.LluviaDiariaSantaFe},{item.LluviaDiariaBuenosAires},{item.LluviaDiariaCordoba},{item.CotizacionDolar},{item.PrecioPromedioDiarioMaizUSD}," +
                            $"{item.SuperficieSembradaMaizSantaFe},{item.SuperficieSembradaMaizBuenosAires},{item.SuperficieSembradaMaizCordoba},{item.SuperficieCosechadaMaizSantaFe}," +
                            $"{item.SuperficieCosechadaMaizBuenosAires}," +
                            $"{item.SuperficieCosechadaMaizCordoba},{item.ProduccionMaizSantaFe},{item.ProduccionMaizBuenosAires},{item.ProduccionMaizCordoba},{item.RendimientoMaizSantaFe}," +
                            $"{item.RendimientoMaizBuenosAires},{item.RendimientoMaizCordoba},{item.PromedioIncendiosMensualesSantaFe},{item.PromedioIncendiosMensualesBuenosAires}," +
                            $"{item.PromedioIncendiosMensualesCordoba},{item.VariacionMaizDiaAnterior},{item.VariacionMaizTresDia},{item.VariacionMaizSieteDias},{item.LluviaDiariaAcumuladaSieteDiasSantaFe}," +
                            $"{item.LluviaDiariaAcumuladaSieteDiasBuenosAires},{item.LluviaDiariaAcumuladaSieteDiasCordoba},{item.LluviaDiariaAcumuladaSieteDiasSantaFe}," +
                            $"{item.LluviaDiariaAcumuladaSieteDiasBuenosAires},{item.LluviaDiariaAcumuladaSieteDiasCordoba},{item.LluviaDiariaAcumuladaTreintaDiasSantaFe}," +
                            $"{item.LluviaDiariaAcumuladaTreintaDiasBuenosAires},{item.LluviaDiariaAcumuladaTreintaDiasCordoba},{item.LluviaDiariaAcumuladaCuarentaCincoDiasSantaFe}," +
                            $"{item.LluviaDiariaAcumuladaCuarentaCincoDiasBuenosAires},{item.LluviaDiariaAcumuladaCuarentaCincoDiasCordoba},{item.LluviaDiariaAcumuladaSesentaDiasSantaFe}," +
                            $"{item.LluviaDiariaAcumuladaSesentaDiasBuenosAires},{item.LluviaDiariaAcumuladaSesentaDiasCordoba},{item.PrecioPromedioTreintaDiasMaiz}," +
                            $"{item.PrecioPromedioSesentaDiasMaiz},{item.PrecioPromedioNoventaDiasMaiz},{itemPredict.PrecioPromedioDiarioMaizUSD}");
                }                
            }
        }

        private static void GenerarArchivoMaiz24(List<Datos> registros)
        {
            using (StreamWriter writer = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "maiz-24hs.csv"))
            {
                registros = registros.Where(x => x.PrecioPromedioDiarioMaizUSD != null).ToList(); //solo obtenemos los que tienen cotizacion calculada
                                                                                                  //escritura del header
                writer.WriteLine($"LluviaDiariaSantaFe,LluviaDiariaBuenosAires,LluviaDiariaCordoba,CotizacionDolar,PrecioPromedioDiarioMaizUSD,SuperficieSembradaMaizSantaFe," +
                    $"SuperficieSembradaMaizBuenosAires," +
                    $"SuperficieSembradaMaizCordoba,SuperficieCosechadaMaizSantaFe," +
                    $"SuperficieCosechadaMaizBuenosAires,SuperficieCosechadaMaizCordoba,ProduccionMaizSantaFe,ProduccionMaizBuenosAires,ProduccionMaizCordoba," +
                    $"RendimientoMaizSantaFe,RendimientoMaizBuenosAires," +
                    $"RendimientoMaizCordoba,PromedioIncendiosMensualesSantaFe,PromedioIncendiosMensualesBuenosAires,PromedioIncendioMensualesCordoba," +
                    $"VariacionMaizDiaAnterior,VariacionMaizTresDia," +
                    $"VariacionMaizSieteDias,LluviaAcumuladaSieteDiasSantaFe," +
                    $"LluviaDiariaAcumuladaSieteDiasBuenosAires,LluviaDiariaAcumuladaSieteDiasCordoba,LluviaDiariaAcumuladaSieteDiasSantaFe," +
                    $"LluviaDiariaAcumuladaSieteDiasBuenosAires,LluviaDiariaAcumuladaSieteDiasCordoba,LluviaDiariaAcumuladaTreintaDiasSantaFe," +
                    $"LluviaDiariaAcumuladaTreintaDiasBuenosAires,LluviaDiariaAcumuladaTreintaDiasCordoba," +
                    $"LluviaDiariaAcumuladaCuarentaCincoDiasSantaFe,LluviaDiariaAcumuladaCuarentaCincoDiasBuenosAires,LluviaDiariaAcumuladaCuarentaCincoDiasCordoba," +
                    $"LluviaDiariaAcumuladaSesentaDiasSantaFe,LluviaDiariaAcumuladaSesentaDiasBuenosAires,LluviaDiariaAcumuladaSesentaDiasCordoba," +
                    $"PrecioPromedioTreintaDiasMaiz,PrecioPromedioSesentaDiasMaiz,PrecioPromedioNoventaDiasMaiz,PrecioRealDiaSiguiente");

                for (int i = 0; i < registros.Count - 1; i++) //Vamos hasta el anteultimo registro para obtener el precio real del dia siguiente
                {
                    var item = registros[i];
                    var itemPredict = registros[i + 1]; //atributo de salida. Precio del cultivo a 24 horas
                                                        //Escribimos la linea del archivo
                    writer.WriteLine($"{item.LluviaDiariaSantaFe},{item.LluviaDiariaBuenosAires},{item.LluviaDiariaCordoba},{item.CotizacionDolar},{item.PrecioPromedioDiarioMaizUSD}," +
                            $"{item.SuperficieSembradaMaizSantaFe},{item.SuperficieSembradaMaizBuenosAires},{item.SuperficieSembradaMaizCordoba},{item.SuperficieCosechadaMaizSantaFe}," +
                            $"{item.SuperficieCosechadaMaizBuenosAires}," +
                            $"{item.SuperficieCosechadaMaizCordoba},{item.ProduccionMaizSantaFe},{item.ProduccionMaizBuenosAires},{item.ProduccionMaizCordoba},{item.RendimientoMaizSantaFe}," +
                            $"{item.RendimientoMaizBuenosAires},{item.RendimientoMaizCordoba},{item.PromedioIncendiosMensualesSantaFe},{item.PromedioIncendiosMensualesBuenosAires}," +
                            $"{item.PromedioIncendiosMensualesCordoba},{item.VariacionMaizDiaAnterior},{item.VariacionMaizTresDia},{item.VariacionMaizSieteDias},{item.LluviaDiariaAcumuladaSieteDiasSantaFe}," +
                            $"{item.LluviaDiariaAcumuladaSieteDiasBuenosAires},{item.LluviaDiariaAcumuladaSieteDiasCordoba},{item.LluviaDiariaAcumuladaSieteDiasSantaFe}," +
                            $"{item.LluviaDiariaAcumuladaSieteDiasBuenosAires},{item.LluviaDiariaAcumuladaSieteDiasCordoba},{item.LluviaDiariaAcumuladaTreintaDiasSantaFe}," +
                            $"{item.LluviaDiariaAcumuladaTreintaDiasBuenosAires},{item.LluviaDiariaAcumuladaTreintaDiasCordoba},{item.LluviaDiariaAcumuladaCuarentaCincoDiasSantaFe}," +
                            $"{item.LluviaDiariaAcumuladaCuarentaCincoDiasBuenosAires},{item.LluviaDiariaAcumuladaCuarentaCincoDiasCordoba},{item.LluviaDiariaAcumuladaSesentaDiasSantaFe}," +
                            $"{item.LluviaDiariaAcumuladaSesentaDiasBuenosAires},{item.LluviaDiariaAcumuladaSesentaDiasCordoba},{item.PrecioPromedioTreintaDiasMaiz}," +
                            $"{item.PrecioPromedioSesentaDiasMaiz},{item.PrecioPromedioNoventaDiasMaiz},{itemPredict.PrecioPromedioDiarioMaizUSD}");
                }
            }
        }

        //Soja
        private static void GenerarArchivoSoja120(List<Datos> registros)
        {
            using (StreamWriter writer = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "Soja-120hs.csv"))
            {
                registros = registros.Where(x => x.PrecioPromedioDiarioSojaUSD != null).ToList(); //solo obtenemos los que tienen cotizacion calculada
                                                                                                  //escritura del header
                writer.WriteLine($"LluviaDiariaSantaFe,LluviaDiariaBuenosAires,LluviaDiariaCordoba,CotizacionDolar,PrecioPromedioDiarioSojaUSD,SuperficieSembradaSojaSantaFe," +
                    $"SuperficieSembradaSojaBuenosAires," +
                    $"SuperficieSembradaSojaCordoba,SuperficieCosechadaSojaSantaFe," +
                    $"SuperficieCosechadaSojaBuenosAires,SuperficieCosechadaSojaCordoba,ProduccionSojaSantaFe,ProduccionSojaBuenosAires,ProduccionSojaCordoba," +
                    $"RendimientoSojaSantaFe,RendimientoSojaBuenosAires," +
                    $"RendimientoSojaCordoba,PromedioIncendiosMensualesSantaFe,PromedioIncendiosMensualesBuenosAires,PromedioIncendioMensualesCordoba," +
                    $"VariacionSojaDiaAnterior,VariacionSojaTresDia," +
                    $"VariacionSojaSieteDias,LluviaAcumuladaSieteDiasSantaFe," +
                    $"LluviaDiariaAcumuladaSieteDiasBuenosAires,LluviaDiariaAcumuladaSieteDiasCordoba,LluviaDiariaAcumuladaSieteDiasSantaFe," +
                    $"LluviaDiariaAcumuladaSieteDiasBuenosAires,LluviaDiariaAcumuladaSieteDiasCordoba,LluviaDiariaAcumuladaTreintaDiasSantaFe," +
                    $"LluviaDiariaAcumuladaTreintaDiasBuenosAires,LluviaDiariaAcumuladaTreintaDiasCordoba," +
                    $"LluviaDiariaAcumuladaCuarentaCincoDiasSantaFe,LluviaDiariaAcumuladaCuarentaCincoDiasBuenosAires,LluviaDiariaAcumuladaCuarentaCincoDiasCordoba," +
                    $"LluviaDiariaAcumuladaSesentaDiasSantaFe,LluviaDiariaAcumuladaSesentaDiasBuenosAires,LluviaDiariaAcumuladaSesentaDiasCordoba," +
                    $"PrecioPromedioTreintaDiasSoja,PrecioPromedioSesentaDiasSoja,PrecioPromedioNoventaDiasSoja,PrecioRealDiaSiguiente");

                for (int i = 0; i < registros.Count - 5; i++) //Vamos hasta el anteultimo registro para obtener el precio real del dia siguiente
                {
                    var item = registros[i];
                    var itemPredict = registros[i + 5]; //atributo de salida. Precio del cultivo a 24 horas
                                                        //Escribimos la linea del archivo
                    writer.WriteLine($"{item.LluviaDiariaSantaFe},{item.LluviaDiariaBuenosAires},{item.LluviaDiariaCordoba},{item.CotizacionDolar}," +
                        $"{item.PrecioPromedioDiarioSojaUSD}," +
                            $"{item.SuperficieSembradaSojaSantaFe},{item.SuperficieSembradaSojaBuenosAires},{item.SuperficieSembradaSojaCordoba},{item.SuperficieCosechadaSojaSantaFe}," +
                            $"{item.SuperficieCosechadaSojaBuenosAires}," +
                            $"{item.SuperficieCosechadaSojaCordoba},{item.ProduccionSojaSantaFe},{item.ProduccionSojaBuenosAires},{item.ProduccionSojaCordoba},{item.RendimientoSojaSantaFe}," +
                            $"{item.RendimientoSojaBuenosAires},{item.RendimientoSojaCordoba},{item.PromedioIncendiosMensualesSantaFe},{item.PromedioIncendiosMensualesBuenosAires}," +
                            $"{item.PromedioIncendiosMensualesCordoba},{item.VariacionSojaDiaAnterior},{item.VariacionSojaTresDias},{item.VariacionSojaSieteDias},{item.LluviaDiariaAcumuladaSieteDiasSantaFe}," +
                            $"{item.LluviaDiariaAcumuladaSieteDiasBuenosAires},{item.LluviaDiariaAcumuladaSieteDiasCordoba},{item.LluviaDiariaAcumuladaSieteDiasSantaFe}," +
                            $"{item.LluviaDiariaAcumuladaSieteDiasBuenosAires},{item.LluviaDiariaAcumuladaSieteDiasCordoba},{item.LluviaDiariaAcumuladaTreintaDiasSantaFe}," +
                            $"{item.LluviaDiariaAcumuladaTreintaDiasBuenosAires},{item.LluviaDiariaAcumuladaTreintaDiasCordoba},{item.LluviaDiariaAcumuladaCuarentaCincoDiasSantaFe}," +
                            $"{item.LluviaDiariaAcumuladaCuarentaCincoDiasBuenosAires},{item.LluviaDiariaAcumuladaCuarentaCincoDiasCordoba},{item.LluviaDiariaAcumuladaSesentaDiasSantaFe}," +
                            $"{item.LluviaDiariaAcumuladaSesentaDiasBuenosAires},{item.LluviaDiariaAcumuladaSesentaDiasCordoba},{item.PrecioPromedioTreintaDiasSoja}," +
                            $"{item.PrecioPromedioSesentaDiasSoja},{item.PrecioPromedioNoventaDiasSoja},{itemPredict.PrecioPromedioDiarioSojaUSD}");
                }
            }
        }

        private static void GenerarArchivoSoja72(List<Datos> registros)
        {
            using (StreamWriter writer = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "Soja-72hs.csv"))
            {
                registros = registros.Where(x => x.PrecioPromedioDiarioSojaUSD != null).ToList(); //solo obtenemos los que tienen cotizacion calculada
                                                                                                  //escritura del header
                writer.WriteLine($"LluviaDiariaSantaFe,LluviaDiariaBuenosAires,LluviaDiariaCordoba,CotizacionDolar,PrecioPromedioDiarioSojaUSD,SuperficieSembradaSojaSantaFe," +
                    $"SuperficieSembradaSojaBuenosAires," +
                    $"SuperficieSembradaSojaCordoba,SuperficieCosechadaSojaSantaFe," +
                    $"SuperficieCosechadaSojaBuenosAires,SuperficieCosechadaSojaCordoba,ProduccionSojaSantaFe,ProduccionSojaBuenosAires,ProduccionSojaCordoba," +
                    $"RendimientoSojaSantaFe,RendimientoSojaBuenosAires," +
                    $"RendimientoSojaCordoba,PromedioIncendiosMensualesSantaFe,PromedioIncendiosMensualesBuenosAires,PromedioIncendioMensualesCordoba," +
                    $"VariacionSojaDiaAnterior,VariacionSojaTresDia," +
                    $"VariacionSojaSieteDias,LluviaAcumuladaSieteDiasSantaFe," +
                    $"LluviaDiariaAcumuladaSieteDiasBuenosAires,LluviaDiariaAcumuladaSieteDiasCordoba,LluviaDiariaAcumuladaSieteDiasSantaFe," +
                    $"LluviaDiariaAcumuladaSieteDiasBuenosAires,LluviaDiariaAcumuladaSieteDiasCordoba,LluviaDiariaAcumuladaTreintaDiasSantaFe," +
                    $"LluviaDiariaAcumuladaTreintaDiasBuenosAires,LluviaDiariaAcumuladaTreintaDiasCordoba," +
                    $"LluviaDiariaAcumuladaCuarentaCincoDiasSantaFe,LluviaDiariaAcumuladaCuarentaCincoDiasBuenosAires,LluviaDiariaAcumuladaCuarentaCincoDiasCordoba," +
                    $"LluviaDiariaAcumuladaSesentaDiasSantaFe,LluviaDiariaAcumuladaSesentaDiasBuenosAires,LluviaDiariaAcumuladaSesentaDiasCordoba," +
                    $"PrecioPromedioTreintaDiasSoja,PrecioPromedioSesentaDiasSoja,PrecioPromedioNoventaDiasSoja,PrecioRealDiaSiguiente");

                for (int i = 0; i < registros.Count - 3; i++) //Vamos hasta el anteultimo registro para obtener el precio real del dia siguiente
                {
                    var item = registros[i];
                    var itemPredict = registros[i + 3]; //atributo de salida. Precio del cultivo a 24 horas
                                                        //Escribimos la linea del archivo
                    writer.WriteLine($"{item.LluviaDiariaSantaFe},{item.LluviaDiariaBuenosAires},{item.LluviaDiariaCordoba},{item.CotizacionDolar},{item.PrecioPromedioDiarioSojaUSD}," +
                            $"{item.SuperficieSembradaSojaSantaFe},{item.SuperficieSembradaSojaBuenosAires},{item.SuperficieSembradaSojaCordoba},{item.SuperficieCosechadaSojaSantaFe}," +
                            $"{item.SuperficieCosechadaSojaBuenosAires}," +
                            $"{item.SuperficieCosechadaSojaCordoba},{item.ProduccionSojaSantaFe},{item.ProduccionSojaBuenosAires},{item.ProduccionSojaCordoba},{item.RendimientoSojaSantaFe}," +
                            $"{item.RendimientoSojaBuenosAires},{item.RendimientoSojaCordoba},{item.PromedioIncendiosMensualesSantaFe},{item.PromedioIncendiosMensualesBuenosAires}," +
                            $"{item.PromedioIncendiosMensualesCordoba},{item.VariacionSojaDiaAnterior},{item.VariacionSojaTresDias},{item.VariacionSojaSieteDias},{item.LluviaDiariaAcumuladaSieteDiasSantaFe}," +
                            $"{item.LluviaDiariaAcumuladaSieteDiasBuenosAires},{item.LluviaDiariaAcumuladaSieteDiasCordoba},{item.LluviaDiariaAcumuladaSieteDiasSantaFe}," +
                            $"{item.LluviaDiariaAcumuladaSieteDiasBuenosAires},{item.LluviaDiariaAcumuladaSieteDiasCordoba},{item.LluviaDiariaAcumuladaTreintaDiasSantaFe}," +
                            $"{item.LluviaDiariaAcumuladaTreintaDiasBuenosAires},{item.LluviaDiariaAcumuladaTreintaDiasCordoba},{item.LluviaDiariaAcumuladaCuarentaCincoDiasSantaFe}," +
                            $"{item.LluviaDiariaAcumuladaCuarentaCincoDiasBuenosAires},{item.LluviaDiariaAcumuladaCuarentaCincoDiasCordoba},{item.LluviaDiariaAcumuladaSesentaDiasSantaFe}," +
                            $"{item.LluviaDiariaAcumuladaSesentaDiasBuenosAires},{item.LluviaDiariaAcumuladaSesentaDiasCordoba},{item.PrecioPromedioTreintaDiasSoja}," +
                            $"{item.PrecioPromedioSesentaDiasSoja},{item.PrecioPromedioNoventaDiasSoja},{itemPredict.PrecioPromedioDiarioSojaUSD}");
                }
            }
        }

        private static void GenerarArchivoSoja24(List<Datos> registros)
        {
            using (StreamWriter writer = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "Soja-24hs.csv"))
            {
                registros = registros.Where(x => x.PrecioPromedioDiarioSojaUSD != null).ToList(); //solo obtenemos los que tienen cotizacion calculada
                                                                                                  //escritura del header
                writer.WriteLine($"LluviaDiariaSantaFe,LluviaDiariaBuenosAires,LluviaDiariaCordoba,CotizacionDolar,PrecioPromedioDiarioSojaUSD,SuperficieSembradaSojaSantaFe," +
                    $"SuperficieSembradaSojaBuenosAires," +
                    $"SuperficieSembradaSojaCordoba,SuperficieCosechadaSojaSantaFe," +
                    $"SuperficieCosechadaSojaBuenosAires,SuperficieCosechadaSojaCordoba,ProduccionSojaSantaFe,ProduccionSojaBuenosAires,ProduccionSojaCordoba," +
                    $"RendimientoSojaSantaFe,RendimientoSojaBuenosAires," +
                    $"RendimientoSojaCordoba,PromedioIncendiosMensualesSantaFe,PromedioIncendiosMensualesBuenosAires,PromedioIncendioMensualesCordoba," +
                    $"VariacionSojaDiaAnterior,VariacionSojaTresDia," +
                    $"VariacionSojaSieteDias,LluviaAcumuladaSieteDiasSantaFe," +
                    $"LluviaDiariaAcumuladaSieteDiasBuenosAires,LluviaDiariaAcumuladaSieteDiasCordoba,LluviaDiariaAcumuladaSieteDiasSantaFe," +
                    $"LluviaDiariaAcumuladaSieteDiasBuenosAires,LluviaDiariaAcumuladaSieteDiasCordoba,LluviaDiariaAcumuladaTreintaDiasSantaFe," +
                    $"LluviaDiariaAcumuladaTreintaDiasBuenosAires,LluviaDiariaAcumuladaTreintaDiasCordoba," +
                    $"LluviaDiariaAcumuladaCuarentaCincoDiasSantaFe,LluviaDiariaAcumuladaCuarentaCincoDiasBuenosAires,LluviaDiariaAcumuladaCuarentaCincoDiasCordoba," +
                    $"LluviaDiariaAcumuladaSesentaDiasSantaFe,LluviaDiariaAcumuladaSesentaDiasBuenosAires,LluviaDiariaAcumuladaSesentaDiasCordoba," +
                    $"PrecioPromedioTreintaDiasSoja,PrecioPromedioSesentaDiasSoja,PrecioPromedioNoventaDiasSoja,PrecioRealDiaSiguiente");

                for (int i = 0; i < registros.Count - 1; i++) //Vamos hasta el anteultimo registro para obtener el precio real del dia siguiente
                {
                    var item = registros[i];
                    var itemPredict = registros[i + 1]; //atributo de salida. Precio del cultivo a 24 horas
                                                        //Escribimos la linea del archivo
                    writer.WriteLine($"{item.LluviaDiariaSantaFe},{item.LluviaDiariaBuenosAires},{item.LluviaDiariaCordoba},{item.CotizacionDolar},{item.PrecioPromedioDiarioSojaUSD}," +
                            $"{item.SuperficieSembradaSojaSantaFe},{item.SuperficieSembradaSojaBuenosAires},{item.SuperficieSembradaSojaCordoba},{item.SuperficieCosechadaSojaSantaFe}," +
                            $"{item.SuperficieCosechadaSojaBuenosAires}," +
                            $"{item.SuperficieCosechadaSojaCordoba},{item.ProduccionSojaSantaFe},{item.ProduccionSojaBuenosAires},{item.ProduccionSojaCordoba},{item.RendimientoSojaSantaFe}," +
                            $"{item.RendimientoSojaBuenosAires},{item.RendimientoSojaCordoba},{item.PromedioIncendiosMensualesSantaFe},{item.PromedioIncendiosMensualesBuenosAires}," +
                            $"{item.PromedioIncendiosMensualesCordoba},{item.VariacionSojaDiaAnterior},{item.VariacionSojaTresDias},{item.VariacionSojaSieteDias},{item.LluviaDiariaAcumuladaSieteDiasSantaFe}," +
                            $"{item.LluviaDiariaAcumuladaSieteDiasBuenosAires},{item.LluviaDiariaAcumuladaSieteDiasCordoba},{item.LluviaDiariaAcumuladaSieteDiasSantaFe}," +
                            $"{item.LluviaDiariaAcumuladaSieteDiasBuenosAires},{item.LluviaDiariaAcumuladaSieteDiasCordoba},{item.LluviaDiariaAcumuladaTreintaDiasSantaFe}," +
                            $"{item.LluviaDiariaAcumuladaTreintaDiasBuenosAires},{item.LluviaDiariaAcumuladaTreintaDiasCordoba},{item.LluviaDiariaAcumuladaCuarentaCincoDiasSantaFe}," +
                            $"{item.LluviaDiariaAcumuladaCuarentaCincoDiasBuenosAires},{item.LluviaDiariaAcumuladaCuarentaCincoDiasCordoba},{item.LluviaDiariaAcumuladaSesentaDiasSantaFe}," +
                            $"{item.LluviaDiariaAcumuladaSesentaDiasBuenosAires},{item.LluviaDiariaAcumuladaSesentaDiasCordoba},{item.PrecioPromedioTreintaDiasSoja}," +
                            $"{item.PrecioPromedioSesentaDiasSoja},{item.PrecioPromedioNoventaDiasSoja},{itemPredict.PrecioPromedioDiarioSojaUSD}");
                }
            }
        }

        //Trigo        
        private static void GenerarArchivoTrigo120(List<Datos> registros)
        {
            using (StreamWriter writer = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "Trigo-120hs.csv"))
            {
                registros = registros.Where(x => x.PrecioPromedioDiarioTrigoUSD != null).ToList(); //solo obtenemos los que tienen cotizacion calculada
                                                                                                   //escritura del header
                writer.WriteLine($"LluviaDiariaSantaFe,LluviaDiariaBuenosAires,LluviaDiariaCordoba,CotizacionDolar,PrecioPromedioDiarioTrigoUSD,SuperficieSembradaTrigoSantaFe," +
                    $"SuperficieSembradaTrigoBuenosAires," +
                    $"SuperficieSembradaTrigoCordoba,SuperficieCosechadaTrigoSantaFe," +
                    $"SuperficieCosechadaTrigoBuenosAires,SuperficieCosechadaTrigoCordoba,ProduccionTrigoSantaFe,ProduccionTrigoBuenosAires,ProduccionTrigoCordoba," +
                    $"RendimientoTrigoSantaFe,RendimientoTrigoBuenosAires," +
                    $"RendimientoTrigoCordoba,PromedioIncendiosMensualesSantaFe,PromedioIncendiosMensualesBuenosAires,PromedioIncendioMensualesCordoba," +
                    $"VariacionTrigoDiaAnterior,VariacionTrigoTresDia," +
                    $"VariacionTrigoSieteDias,LluviaAcumuladaSieteDiasSantaFe," +
                    $"LluviaDiariaAcumuladaSieteDiasBuenosAires,LluviaDiariaAcumuladaSieteDiasCordoba,LluviaDiariaAcumuladaSieteDiasSantaFe," +
                    $"LluviaDiariaAcumuladaSieteDiasBuenosAires,LluviaDiariaAcumuladaSieteDiasCordoba,LluviaDiariaAcumuladaTreintaDiasSantaFe," +
                    $"LluviaDiariaAcumuladaTreintaDiasBuenosAires,LluviaDiariaAcumuladaTreintaDiasCordoba," +
                    $"LluviaDiariaAcumuladaCuarentaCincoDiasSantaFe,LluviaDiariaAcumuladaCuarentaCincoDiasBuenosAires,LluviaDiariaAcumuladaCuarentaCincoDiasCordoba," +
                    $"LluviaDiariaAcumuladaSesentaDiasSantaFe,LluviaDiariaAcumuladaSesentaDiasBuenosAires,LluviaDiariaAcumuladaSesentaDiasCordoba," +
                    $"PrecioPromedioTreintaDiasTrigo,PrecioPromedioSesentaDiasTrigo,PrecioPromedioNoventaDiasTrigo,PrecioRealDiaSiguiente");

                for (int i = 0; i < registros.Count - 5; i++) //Vamos hasta el anteultimo registro para obtener el precio real del dia siguiente
                {
                    var item = registros[i];
                    var itemPredict = registros[i + 5]; //atributo de salida. Precio del cultivo a 24 horas
                                                        //Escribimos la linea del archivo
                    writer.WriteLine($"{item.LluviaDiariaSantaFe},{item.LluviaDiariaBuenosAires},{item.LluviaDiariaCordoba},{item.CotizacionDolar}," +
                        $"{item.PrecioPromedioDiarioTrigoUSD}," +
                            $"{item.SuperficieSembradaTrigoSantaFe},{item.SuperficieSembradaTrigoBuenosAires},{item.SuperficieSembradaTrigoCordoba},{item.SuperficieCosechadaTrigoSantaFe}," +
                            $"{item.SuperficieCosechadaTrigoBuenosAires}," +
                            $"{item.SuperficieCosechadaTrigoCordoba},{item.ProduccionTrigoSantaFe},{item.ProduccionTrigoBuenosAires},{item.ProduccionTrigoCordoba},{item.RendimientoTrigoSantaFe}," +
                            $"{item.RendimientoTrigoBuenosAires},{item.RendimientoTrigoCordoba},{item.PromedioIncendiosMensualesSantaFe},{item.PromedioIncendiosMensualesBuenosAires}," +
                            $"{item.PromedioIncendiosMensualesCordoba},{item.VariacionTrigoDiaAnterior},{item.VariacionTrigoTresDias},{item.VariacionTrigoSieteDias},{item.LluviaDiariaAcumuladaSieteDiasSantaFe}," +
                            $"{item.LluviaDiariaAcumuladaSieteDiasBuenosAires},{item.LluviaDiariaAcumuladaSieteDiasCordoba},{item.LluviaDiariaAcumuladaSieteDiasSantaFe}," +
                            $"{item.LluviaDiariaAcumuladaSieteDiasBuenosAires},{item.LluviaDiariaAcumuladaSieteDiasCordoba},{item.LluviaDiariaAcumuladaTreintaDiasSantaFe}," +
                            $"{item.LluviaDiariaAcumuladaTreintaDiasBuenosAires},{item.LluviaDiariaAcumuladaTreintaDiasCordoba},{item.LluviaDiariaAcumuladaCuarentaCincoDiasSantaFe}," +
                            $"{item.LluviaDiariaAcumuladaCuarentaCincoDiasBuenosAires},{item.LluviaDiariaAcumuladaCuarentaCincoDiasCordoba},{item.LluviaDiariaAcumuladaSesentaDiasSantaFe}," +
                            $"{item.LluviaDiariaAcumuladaSesentaDiasBuenosAires},{item.LluviaDiariaAcumuladaSesentaDiasCordoba},{item.PrecioPromedioTreintaDiasTrigo}," +
                            $"{item.PrecioPromedioSesentaDiasTrigo},{item.PrecioPromedioNoventaDiasTrigo},{itemPredict.PrecioPromedioDiarioTrigoUSD}");
                }
            }
        }

        private static void GenerarArchivoTrigo72(List<Datos> registros)
        {
            using (StreamWriter writer = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "Trigo-72hs.csv"))
            {
                registros = registros.Where(x => x.PrecioPromedioDiarioTrigoUSD != null).ToList(); //solo obtenemos los que tienen cotizacion calculada
                                                                                                   //escritura del header
                writer.WriteLine($"LluviaDiariaSantaFe,LluviaDiariaBuenosAires,LluviaDiariaCordoba,CotizacionDolar,PrecioPromedioDiarioTrigoUSD,SuperficieSembradaTrigoSantaFe," +
                    $"SuperficieSembradaTrigoBuenosAires," +
                    $"SuperficieSembradaTrigoCordoba,SuperficieCosechadaTrigoSantaFe," +
                    $"SuperficieCosechadaTrigoBuenosAires,SuperficieCosechadaTrigoCordoba,ProduccionTrigoSantaFe,ProduccionTrigoBuenosAires,ProduccionTrigoCordoba," +
                    $"RendimientoTrigoSantaFe,RendimientoTrigoBuenosAires," +
                    $"RendimientoTrigoCordoba,PromedioIncendiosMensualesSantaFe,PromedioIncendiosMensualesBuenosAires,PromedioIncendioMensualesCordoba," +
                    $"VariacionTrigoDiaAnterior,VariacionTrigoTresDia," +
                    $"VariacionTrigoSieteDias,LluviaAcumuladaSieteDiasSantaFe," +
                    $"LluviaDiariaAcumuladaSieteDiasBuenosAires,LluviaDiariaAcumuladaSieteDiasCordoba,LluviaDiariaAcumuladaSieteDiasSantaFe," +
                    $"LluviaDiariaAcumuladaSieteDiasBuenosAires,LluviaDiariaAcumuladaSieteDiasCordoba,LluviaDiariaAcumuladaTreintaDiasSantaFe," +
                    $"LluviaDiariaAcumuladaTreintaDiasBuenosAires,LluviaDiariaAcumuladaTreintaDiasCordoba," +
                    $"LluviaDiariaAcumuladaCuarentaCincoDiasSantaFe,LluviaDiariaAcumuladaCuarentaCincoDiasBuenosAires,LluviaDiariaAcumuladaCuarentaCincoDiasCordoba," +
                    $"LluviaDiariaAcumuladaSesentaDiasSantaFe,LluviaDiariaAcumuladaSesentaDiasBuenosAires,LluviaDiariaAcumuladaSesentaDiasCordoba," +
                    $"PrecioPromedioTreintaDiasTrigo,PrecioPromedioSesentaDiasTrigo,PrecioPromedioNoventaDiasTrigo,PrecioRealDiaSiguiente");

                for (int i = 0; i < registros.Count - 3; i++) //Vamos hasta el anteultimo registro para obtener el precio real del dia siguiente
                {
                    var item = registros[i];
                    var itemPredict = registros[i + 3]; //atributo de salida. Precio del cultivo a 24 horas
                                                        //Escribimos la linea del archivo
                    writer.WriteLine($"{item.LluviaDiariaSantaFe},{item.LluviaDiariaBuenosAires},{item.LluviaDiariaCordoba},{item.CotizacionDolar},{item.PrecioPromedioDiarioTrigoUSD}," +
                            $"{item.SuperficieSembradaTrigoSantaFe},{item.SuperficieSembradaTrigoBuenosAires},{item.SuperficieSembradaTrigoCordoba},{item.SuperficieCosechadaTrigoSantaFe}," +
                            $"{item.SuperficieCosechadaTrigoBuenosAires}," +
                            $"{item.SuperficieCosechadaTrigoCordoba},{item.ProduccionTrigoSantaFe},{item.ProduccionTrigoBuenosAires},{item.ProduccionTrigoCordoba},{item.RendimientoTrigoSantaFe}," +
                            $"{item.RendimientoTrigoBuenosAires},{item.RendimientoTrigoCordoba},{item.PromedioIncendiosMensualesSantaFe},{item.PromedioIncendiosMensualesBuenosAires}," +
                            $"{item.PromedioIncendiosMensualesCordoba},{item.VariacionTrigoDiaAnterior},{item.VariacionTrigoTresDias},{item.VariacionTrigoSieteDias},{item.LluviaDiariaAcumuladaSieteDiasSantaFe}," +
                            $"{item.LluviaDiariaAcumuladaSieteDiasBuenosAires},{item.LluviaDiariaAcumuladaSieteDiasCordoba},{item.LluviaDiariaAcumuladaSieteDiasSantaFe}," +
                            $"{item.LluviaDiariaAcumuladaSieteDiasBuenosAires},{item.LluviaDiariaAcumuladaSieteDiasCordoba},{item.LluviaDiariaAcumuladaTreintaDiasSantaFe}," +
                            $"{item.LluviaDiariaAcumuladaTreintaDiasBuenosAires},{item.LluviaDiariaAcumuladaTreintaDiasCordoba},{item.LluviaDiariaAcumuladaCuarentaCincoDiasSantaFe}," +
                            $"{item.LluviaDiariaAcumuladaCuarentaCincoDiasBuenosAires},{item.LluviaDiariaAcumuladaCuarentaCincoDiasCordoba},{item.LluviaDiariaAcumuladaSesentaDiasSantaFe}," +
                            $"{item.LluviaDiariaAcumuladaSesentaDiasBuenosAires},{item.LluviaDiariaAcumuladaSesentaDiasCordoba},{item.PrecioPromedioTreintaDiasTrigo}," +
                            $"{item.PrecioPromedioSesentaDiasTrigo},{item.PrecioPromedioNoventaDiasTrigo},{itemPredict.PrecioPromedioDiarioTrigoUSD}");
                }
            }
        }

        private static void GenerarArchivoTrigo24(List<Datos> registros)
        {
            using (StreamWriter writer = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "Trigo-24hs.csv"))
            {
                registros = registros.Where(x => x.PrecioPromedioDiarioTrigoUSD != null).ToList(); //solo obtenemos los que tienen cotizacion calculada
                                                                                                   //escritura del header
                writer.WriteLine($"LluviaDiariaSantaFe,LluviaDiariaBuenosAires,LluviaDiariaCordoba,CotizacionDolar,PrecioPromedioDiarioTrigoUSD,SuperficieSembradaTrigoSantaFe," +
                    $"SuperficieSembradaTrigoBuenosAires," +
                    $"SuperficieSembradaTrigoCordoba,SuperficieCosechadaTrigoSantaFe," +
                    $"SuperficieCosechadaTrigoBuenosAires,SuperficieCosechadaTrigoCordoba,ProduccionTrigoSantaFe,ProduccionTrigoBuenosAires,ProduccionTrigoCordoba," +
                    $"RendimientoTrigoSantaFe,RendimientoTrigoBuenosAires," +
                    $"RendimientoTrigoCordoba,PromedioIncendiosMensualesSantaFe,PromedioIncendiosMensualesBuenosAires,PromedioIncendioMensualesCordoba," +
                    $"VariacionTrigoDiaAnterior,VariacionTrigoTresDia," +
                    $"VariacionTrigoSieteDias,LluviaAcumuladaSieteDiasSantaFe," +
                    $"LluviaDiariaAcumuladaSieteDiasBuenosAires,LluviaDiariaAcumuladaSieteDiasCordoba,LluviaDiariaAcumuladaSieteDiasSantaFe," +
                    $"LluviaDiariaAcumuladaSieteDiasBuenosAires,LluviaDiariaAcumuladaSieteDiasCordoba,LluviaDiariaAcumuladaTreintaDiasSantaFe," +
                    $"LluviaDiariaAcumuladaTreintaDiasBuenosAires,LluviaDiariaAcumuladaTreintaDiasCordoba," +
                    $"LluviaDiariaAcumuladaCuarentaCincoDiasSantaFe,LluviaDiariaAcumuladaCuarentaCincoDiasBuenosAires,LluviaDiariaAcumuladaCuarentaCincoDiasCordoba," +
                    $"LluviaDiariaAcumuladaSesentaDiasSantaFe,LluviaDiariaAcumuladaSesentaDiasBuenosAires,LluviaDiariaAcumuladaSesentaDiasCordoba," +
                    $"PrecioPromedioTreintaDiasTrigo,PrecioPromedioSesentaDiasTrigo,PrecioPromedioNoventaDiasTrigo,PrecioRealDiaSiguiente");

                for (int i = 0; i < registros.Count - 1; i++) //Vamos hasta el anteultimo registro para obtener el precio real del dia siguiente
                {
                    var item = registros[i];
                    var itemPredict = registros[i + 1]; //atributo de salida. Precio del cultivo a 24 horas
                                                        //Escribimos la linea del archivo
                    writer.WriteLine($"{item.LluviaDiariaSantaFe},{item.LluviaDiariaBuenosAires},{item.LluviaDiariaCordoba},{item.CotizacionDolar}," +
                        $"{item.PrecioPromedioDiarioTrigoUSD}," +
                            $"{item.SuperficieSembradaTrigoSantaFe},{item.SuperficieSembradaTrigoBuenosAires},{item.SuperficieSembradaTrigoCordoba},{item.SuperficieCosechadaTrigoSantaFe}," +
                            $"{item.SuperficieCosechadaTrigoBuenosAires}," +
                            $"{item.SuperficieCosechadaTrigoCordoba},{item.ProduccionTrigoSantaFe},{item.ProduccionTrigoBuenosAires},{item.ProduccionTrigoCordoba},{item.RendimientoTrigoSantaFe}," +
                            $"{item.RendimientoTrigoBuenosAires},{item.RendimientoTrigoCordoba},{item.PromedioIncendiosMensualesSantaFe},{item.PromedioIncendiosMensualesBuenosAires}," +
                            $"{item.PromedioIncendiosMensualesCordoba},{item.VariacionTrigoDiaAnterior},{item.VariacionTrigoTresDias},{item.VariacionTrigoSieteDias}," +
                            $"{item.LluviaDiariaAcumuladaSieteDiasSantaFe}," +
                            $"{item.LluviaDiariaAcumuladaSieteDiasBuenosAires},{item.LluviaDiariaAcumuladaSieteDiasCordoba},{item.LluviaDiariaAcumuladaSieteDiasSantaFe}," +
                            $"{item.LluviaDiariaAcumuladaSieteDiasBuenosAires},{item.LluviaDiariaAcumuladaSieteDiasCordoba},{item.LluviaDiariaAcumuladaTreintaDiasSantaFe}," +
                            $"{item.LluviaDiariaAcumuladaTreintaDiasBuenosAires},{item.LluviaDiariaAcumuladaTreintaDiasCordoba},{item.LluviaDiariaAcumuladaCuarentaCincoDiasSantaFe}," +
                            $"{item.LluviaDiariaAcumuladaCuarentaCincoDiasBuenosAires},{item.LluviaDiariaAcumuladaCuarentaCincoDiasCordoba},{item.LluviaDiariaAcumuladaSesentaDiasSantaFe}," +
                            $"{item.LluviaDiariaAcumuladaSesentaDiasBuenosAires},{item.LluviaDiariaAcumuladaSesentaDiasCordoba},{item.PrecioPromedioTreintaDiasTrigo}," +
                            $"{item.PrecioPromedioSesentaDiasTrigo},{item.PrecioPromedioNoventaDiasTrigo},{itemPredict.PrecioPromedioDiarioTrigoUSD}");
                }
            }
        }
    }
}
