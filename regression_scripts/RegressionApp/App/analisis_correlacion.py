import numpy as np
import pandas as pd
import scipy as sp
import matplotlib.pyplot as plt
import seaborn as sns
from sklearn.linear_model import LinearRegression

def generarCorrelacion(dataset, archivo):
    #calculo del coeficiente de correlacion de pearson para cada variable independiente.
    corr = dataset.iloc[:, :-1].corr()
    #generacion del mapa de calor
    plot = sns.heatmap(corr, xticklabels=corr.columns.values, yticklabels=corr.columns.values)
    fig = plot.get_figure()
    fig.savefig("correlacion-"+archivo.replace(".csv","") + ".png")
    fig.clf()

def procesarArchivoMaiz(archivo):
    #Lectura del archivo
    dataset = pd.read_csv(archivo, delimiter=',') 
    #definicio de las columnas que nos interesaran para el analisis
    cols_of_interest=["CotizacionDolar","SuperficieSembradaMaizSantaFe","SuperficieSembradaMaizBuenosAires","SuperficieSembradaMaizCordoba","SuperficieCosechadaMaizSantaFe","SuperficieCosechadaMaizBuenosAires","SuperficieCosechadaMaizCordoba","ProduccionMaizSantaFe","ProduccionMaizBuenosAires","ProduccionMaizCordoba","RendimientoMaizSantaFe","RendimientoMaizBuenosAires","RendimientoMaizCordoba","PromedioIncendiosMensualesSantaFe","PromedioIncendiosMensualesBuenosAires","PromedioIncendioMensualesCordoba","VariacionMaizDiaAnterior","VariacionMaizTresDia","VariacionMaizSieteDias", "LluviaAcumuladaSieteDiasSantaFe","LluviaDiariaAcumuladaSieteDiasBuenosAires","LluviaDiariaAcumuladaSieteDiasCordoba","LluviaDiariaAcumuladaSieteDiasSantaFe","LluviaDiariaAcumuladaSieteDiasBuenosAires","LluviaDiariaAcumuladaSieteDiasCordoba","LluviaDiariaAcumuladaTreintaDiasSantaFe","LluviaDiariaAcumuladaTreintaDiasBuenosAires","LluviaDiariaAcumuladaTreintaDiasCordoba","LluviaDiariaAcumuladaCuarentaCincoDiasSantaFe","LluviaDiariaAcumuladaCuarentaCincoDiasBuenosAires","LluviaDiariaAcumuladaCuarentaCincoDiasCordoba","LluviaDiariaAcumuladaSesentaDiasSantaFe","LluviaDiariaAcumuladaSesentaDiasBuenosAires","LluviaDiariaAcumuladaSesentaDiasCordoba","PrecioPromedioTreintaDiasMaiz","PrecioPromedioSesentaDiasMaiz","PrecioPromedioNoventaDiasMaiz"]
    dataset = dataset[cols_of_interest]
    #generacion del mapa de calor según el nivel de correlacion de variables
    generarCorrelacion(dataset,archivo)

def procesarArchivoTrigo(archivo):
    #Lectura del archivo
    dataset = pd.read_csv(archivo, delimiter=',') 
    #definicio de las columnas que nos interesaran para el analisis
    cols_of_interest=["CotizacionDolar","SuperficieSembradaTrigoSantaFe","SuperficieSembradaTrigoBuenosAires","SuperficieSembradaTrigoCordoba","SuperficieCosechadaTrigoSantaFe","SuperficieCosechadaTrigoBuenosAires","SuperficieCosechadaTrigoCordoba","ProduccionTrigoSantaFe","ProduccionTrigoBuenosAires","ProduccionTrigoCordoba","RendimientoTrigoSantaFe","RendimientoTrigoBuenosAires","RendimientoTrigoCordoba","PromedioIncendiosMensualesSantaFe","PromedioIncendiosMensualesBuenosAires","PromedioIncendioMensualesCordoba","VariacionTrigoDiaAnterior","VariacionTrigoTresDia","VariacionTrigoSieteDias", "LluviaAcumuladaSieteDiasSantaFe","LluviaDiariaAcumuladaSieteDiasBuenosAires","LluviaDiariaAcumuladaSieteDiasCordoba","LluviaDiariaAcumuladaSieteDiasSantaFe","LluviaDiariaAcumuladaSieteDiasBuenosAires","LluviaDiariaAcumuladaSieteDiasCordoba","LluviaDiariaAcumuladaTreintaDiasSantaFe","LluviaDiariaAcumuladaTreintaDiasBuenosAires","LluviaDiariaAcumuladaTreintaDiasCordoba","LluviaDiariaAcumuladaCuarentaCincoDiasSantaFe","LluviaDiariaAcumuladaCuarentaCincoDiasBuenosAires","LluviaDiariaAcumuladaCuarentaCincoDiasCordoba","LluviaDiariaAcumuladaSesentaDiasSantaFe","LluviaDiariaAcumuladaSesentaDiasBuenosAires","LluviaDiariaAcumuladaSesentaDiasCordoba","PrecioPromedioTreintaDiasTrigo","PrecioPromedioSesentaDiasTrigo","PrecioPromedioNoventaDiasTrigo"]
    dataset = dataset[cols_of_interest]
    #generacion del mapa de calor según el nivel de correlacion de variables
    generarCorrelacion(dataset,archivo)

def procesarArchivoSoja(archivo):
    #Lectura del archivo
    dataset = pd.read_csv(archivo, delimiter=',') 
    #definicio de las columnas que nos interesaran para el analisis
    cols_of_interest=["CotizacionDolar","SuperficieSembradaSojaSantaFe","SuperficieSembradaSojaBuenosAires","SuperficieSembradaSojaCordoba","SuperficieCosechadaSojaSantaFe","SuperficieCosechadaSojaBuenosAires","SuperficieCosechadaSojaCordoba","ProduccionSojaSantaFe","ProduccionSojaBuenosAires","ProduccionSojaCordoba","RendimientoSojaSantaFe","RendimientoSojaBuenosAires","RendimientoSojaCordoba","PromedioIncendiosMensualesSantaFe","PromedioIncendiosMensualesBuenosAires","PromedioIncendioMensualesCordoba","VariacionSojaDiaAnterior","VariacionSojaTresDia","VariacionSojaSieteDias", "LluviaAcumuladaSieteDiasSantaFe","LluviaDiariaAcumuladaSieteDiasBuenosAires","LluviaDiariaAcumuladaSieteDiasCordoba","LluviaDiariaAcumuladaSieteDiasSantaFe","LluviaDiariaAcumuladaSieteDiasBuenosAires","LluviaDiariaAcumuladaSieteDiasCordoba","LluviaDiariaAcumuladaTreintaDiasSantaFe","LluviaDiariaAcumuladaTreintaDiasBuenosAires","LluviaDiariaAcumuladaTreintaDiasCordoba","LluviaDiariaAcumuladaCuarentaCincoDiasSantaFe","LluviaDiariaAcumuladaCuarentaCincoDiasBuenosAires","LluviaDiariaAcumuladaCuarentaCincoDiasCordoba","LluviaDiariaAcumuladaSesentaDiasSantaFe","LluviaDiariaAcumuladaSesentaDiasBuenosAires","LluviaDiariaAcumuladaSesentaDiasCordoba","PrecioPromedioTreintaDiasSoja","PrecioPromedioSesentaDiasSoja","PrecioPromedioNoventaDiasSoja"]
    dataset = dataset[cols_of_interest]
    #generacion del mapa de calor según el nivel de correlacion de variables
    generarCorrelacion(dataset,archivo)

if __name__ == '__main__': #En el programa principal ejecutamos la funcion de procesamiento para cada archivo
    procesarArchivoMaiz('maiz-24hs.csv')
    procesarArchivoMaiz('maiz-72hs.csv')
    procesarArchivoMaiz('maiz-120hs.csv')
    procesarArchivoTrigo('trigo-24hs.csv')
    procesarArchivoTrigo('trigo-72hs.csv')
    procesarArchivoTrigo('trigo-120hs.csv')
    procesarArchivoSoja('soja-24hs.csv')
    procesarArchivoSoja('soja-72hs.csv')
    procesarArchivoSoja('soja-120hs.csv')





