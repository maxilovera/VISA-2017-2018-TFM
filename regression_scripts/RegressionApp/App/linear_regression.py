#Regresion lineal multiple
import os
import numpy as np
import matplotlib.pyplot as plt
import pandas as pd
from sklearn.cross_validation import train_test_split
from sklearn.linear_model import LinearRegression
from sklearn.metrics import mean_squared_error, r2_score

def cls():
    os.system('cls' if os.name=='nt' else 'clear')

def procesarArchivo(archivo):
    print('********************')
    print('Resultados para: ', archivo)
    dataset = pd.read_csv(archivo, delimiter=',') #importamos el dataset pasado como parámetro

    print(dataset)

    X = dataset.iloc[:, :-1].values #Obtenemos la matriz de variables independientes
    y = dataset.iloc[:, 42].values #Obtenemos el vector de la variable dependiente
    cls()
    print(X)
    print(X.shape)    
    print(y)
    print(y.shape)
    cls()
    #generamos los arreglos para entrenamiento y validación cruzada, usamos 20% de las observaciones
    # para realizar la validacion
    X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state = 0)

    #Ajustamos el algoritmo de regresión lineal múltiple a los datos de entrenamiento
    
    regr = LinearRegression()
    regr.fit(X_train, y_train)

    #Validacion cruzada de los datos indeptes de test
    y_pred = regr.predict(X_test)

    #Revisamos las métricas para analizar el resultado    
    print('Coeficientes: ', np.round_(regr.coef_, decimals=2))    
    print("Error medio cuadrado: %.2f" % mean_squared_error(y_test, y_pred))    
    print('Coeficiente de determinación: %.2f' % r2_score(y_test, y_pred))

if __name__ == '__main__':
    procesarArchivo('maiz-24hs.csv')
    procesarArchivo('maiz-72hs.csv')
    procesarArchivo('maiz-120hs.csv')
    procesarArchivo('trigo-24hs.csv')
    procesarArchivo('trigo-72hs.csv')
    procesarArchivo('trigo-120hs.csv')
    procesarArchivo('soja-24hs.csv')
    procesarArchivo('soja-72hs.csv')
    procesarArchivo('soja-120hs.csv')






