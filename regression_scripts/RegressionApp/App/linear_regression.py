#Regresion lineal multiple
import os
import math
import numpy as np
import matplotlib.pyplot as plt
import pandas as pd
from sklearn.cross_validation import train_test_split
from sklearn.linear_model import LinearRegression
from sklearn.metrics import mean_squared_error, r2_score
from sklearn import preprocessing

def cls():
    os.system('cls' if os.name=='nt' else 'clear')

def procesarArchivo(archivo):
    print('********************')
    print('Resultados para: ', archivo)
    dataset = pd.read_csv(archivo, delimiter=',') #importamos el dataset pasado como parámetro

    X = dataset.iloc[:, :-1].values #Obtenemos la matriz de variables independientes
    y = dataset.iloc[:, 41].values #Obtenemos el vector de la variable dependiente
        
    #generamos los arreglos para entrenamiento y validación cruzada, usamos 20% de las observaciones
    # para realizar la validacion
    X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state = 0)
    X_scaled_train = preprocessing.scale(X_train)
    X_scaled_test = preprocessing.scale(X_test)

    #Ajustamos el algoritmo de regresión lineal múltiple a los datos de entrenamiento    
    regr = LinearRegression()
    regr.fit(X_scaled_train, y_train)

    #Validacion cruzada de los datos indeptes de test
    y_pred = regr.predict(X_scaled_test)

    #Grafica 
    plt.scatter(y_test, y_pred, c='g',linewidths=1,marker='x')
    plt.xlabel("Precios test")
    plt.ylabel("Precios en predicción")
    plt.title("Precios reales vs Precios de predicción - {0}".format(archivo.replace('.csv','')))
    plt.show()

    #Grafico de residuos
    plt.scatter(regr.predict(X_scaled_train), regr.predict(X_scaled_train) - y_train, c='r', s=15, alpha=0.4)
    plt.scatter(regr.predict(X_scaled_test), regr.predict(X_scaled_test) - y_test, c='g', s=15, alpha=0.4)
    plt.hlines(y=0, xmin=0, xmax=50)
    plt.title("Gráfico de residuos usando entrenamiento (rojo) y test (verde)")
    plt.ylabel("Residuos")
    plt.show()

    #Revisamos las métricas para analizar el resultado    
    print ("Fit a model X_train, and calculate MSE with Y_train:", np.mean(y_train - regr.predict(X_scaled_train)) ** 2)
    print ("Fit a model X_train, and calculate MSE with X_test, Y_test:", np.mean(y_test - regr.predict(X_scaled_test)) ** 2)
    print('Coeficientes: ', np.round_(regr.coef_, decimals=2))    
    print("RMSE: %.2f" % math.sqrt(mean_squared_error(y_test, y_pred)))    
    print('Coeficiente de determinación: %.2f' % r2_score(y_test, y_pred))

if __name__ == '__main__':
    procesarArchivo('maiz-24hs.csv')
    #procesarArchivo('maiz-72hs.csv')
    #procesarArchivo('maiz-120hs.csv')
    #procesarArchivo('trigo-24hs.csv')
    #procesarArchivo('trigo-72hs.csv')
    #procesarArchivo('trigo-120hs.csv')
    #procesarArchivo('soja-24hs.csv')
    #procesarArchivo('soja-72hs.csv')
    #procesarArchivo('soja-120hs.csv')






