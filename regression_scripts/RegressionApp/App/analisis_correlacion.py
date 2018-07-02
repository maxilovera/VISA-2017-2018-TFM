import os
import numpy as np
import pandas as pd
import scipy as sp
from sklearn.linear_model import LinearRegression

def procesarArchivo(archivo):
    dataset = pd.read_csv(archivo, delimiter=',') #importamos el dataset pasado como parámetro
    size = dataset.columns.size #definimos el tamaño de las columnas de datos
    index = 0 
    file = open("analisis_regresion-{0}".format(archivo),"w") #creacion del archivo de respuesta
    while index < (size - 1): #No contamos la ultima columna de la variable dependiente
        v1 = dataset.iloc[:, index].values #obtenemos el arreglo de datos de la columna inicial
        nIndex = index + 1
        while nIndex < (size - 1): #iteramos sobre las columnas siguientes
            v2 = dataset.iloc[:, nIndex].values
            print("Evaluacion {0}:{1} - {2}:{3}".format(index, dataset.columns[index], nIndex, dataset.columns[nIndex]))
            coef = sp.stats.pearsonr(v1, v2) #obtenemos el resultado de la funcion que calcula el coef de correlación de Pearson

            print("Coeficiente de correlación {0} / p-valor: {1}".format(coef[0], coef[1])) #Imprimimos
            nIndex = nIndex + 1
            file.write("{0},{1},{2},{3},{4},{5}\n".format(index, dataset.columns[index], nIndex, dataset.columns[nIndex],coef[0], coef[1]))

        index = index + 1

if __name__ == '__main__': #En el programa principal ejecutamos la funcion de procesamiento para cada archivo
    procesarArchivo('maiz-24hs.csv')
    procesarArchivo('maiz-72hs.csv')
    procesarArchivo('maiz-120hs.csv')
    procesarArchivo('trigo-24hs.csv')
    procesarArchivo('trigo-72hs.csv')
    procesarArchivo('trigo-120hs.csv')
    procesarArchivo('soja-24hs.csv')
    procesarArchivo('soja-72hs.csv')
    procesarArchivo('soja-120hs.csv')





