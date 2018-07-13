import numpy as np
import pandas as pd
import scipy as sp
import math
import matplotlib.pyplot as plt
import seaborn as sns
from sklearn.linear_model import LinearRegression
from sklearn.metrics import r2_score, mean_squared_error

def procesarArchivo(archivo, variation): #recibimos variacion como parametro para modificar el valor
    #Lectura del archivo
    dataset = pd.read_csv(archivo, delimiter=',') 
    current_prices = dataset.iloc[:, 4].values
    i=0
    for x in current_prices:
        # multiplicamos el valor por la variacion para cambiarlo
        current_prices[i] = x * variation 
        i=i+1

    next_prices = dataset.iloc[:, -2].values
    r2 =r2_score(current_prices, next_prices)

    print("Archivo {0}: Variacion: {1} - R2 {2}".format(archivo.replace(".csv",""), variation, r2))
    
#En el programa principal ejecutamos la funcion de procesamiento para cada archivo
if __name__ == '__main__': 
    procesarArchivo('maiz-24hs.csv',1)
    procesarArchivo('maiz-72hs.csv',1)
    procesarArchivo('maiz-120hs.csv',1)
    procesarArchivo('trigo-24hs.csv',1)
    procesarArchivo('trigo-72hs.csv',1)
    procesarArchivo('trigo-120hs.csv',1)
    procesarArchivo('soja-24hs.csv',1)
    procesarArchivo('soja-72hs.csv',1)
    procesarArchivo('soja-120hs.csv',1)
    procesarArchivo('maiz-24hs.csv',1.05)
    procesarArchivo('maiz-72hs.csv',1.05)
    procesarArchivo('maiz-120hs.csv',1.05)
    procesarArchivo('trigo-24hs.csv',1.05)
    procesarArchivo('trigo-72hs.csv',1.05)
    procesarArchivo('trigo-120hs.csv',1.05)
    procesarArchivo('soja-24hs.csv',1.05)
    procesarArchivo('soja-72hs.csv',1.05)
    procesarArchivo('soja-120hs.csv',1.05)
    procesarArchivo('maiz-24hs.csv',1.15)
    procesarArchivo('maiz-72hs.csv',1.15)
    procesarArchivo('maiz-120hs.csv',1.15)
    procesarArchivo('trigo-24hs.csv',1.15)
    procesarArchivo('trigo-72hs.csv',1.15)
    procesarArchivo('trigo-120hs.csv',1.15)
    procesarArchivo('soja-24hs.csv',1.15)
    procesarArchivo('soja-72hs.csv',1.15)
    procesarArchivo('soja-120hs.csv',1.15)





