#Regresion lineal multiple
import os
import math
import numpy as np
import matplotlib.pyplot as plt
import pandas as pd
from sklearn.cross_validation import train_test_split
from sklearn.linear_model import LinearRegression
from sklearn.metrics import mean_squared_error, r2_score
from sklearn.preprocessing import StandardScaler

def cls():
    os.system('cls' if os.name=='nt' else 'clear')

def procesarArchivo(archivo):    
    print('Resultados para: ', archivo)
    
    dataset = pd.read_csv(archivo, delimiter=',') #importación del dataset de datos        
    X = dataset.iloc[:, :-1].values #Obtenemos la matriz de variables independientes
    y = dataset.iloc[:, -1].values #Obtenemos el vector de la variable dependiente
        
    # generación de matriz y vector para entrenamiento y validación cruzada, 
    # usamos 20% de las observaciones para realizar la validacion y 80% para entrenamiento.
    X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state = 0)
    
    scaler = StandardScaler() #Escalado de las variables independientes
    X_train = scaler.fit_transform(X_train) 
    X_test = scaler.transform(X_test)

    #Ajustamos el algoritmo de regresión lineal a los datos de entrenamiento    
    regr = LinearRegression()
    regr.fit(X_train, y_train)

    #Validacion cruzada de los datos indeptes de test
    y_pred = regr.predict(X_test)

    #Revisamos las métricas para analizar el resultado    
    print ("Error medio con datos de entrenamiento:", mean_squared_error(y_train, regr.predict(X_train)))
    print ("Error medio con datos de test:", mean_squared_error(y_test, y_pred)) 
        
    print('Coeficiente de determinación: %.2f' % r2_score(y_test, y_pred)) 
    
    #Desvio estandar de las predicciones 5 = 5 dolares
    print("**********************************")
    print("***** Raiz del error medio (RSME): %.2f" % math.sqrt(mean_squared_error(y_test, y_pred))) 
    print("**********************************")

    #coeficientes para la recta de regresion para cada var indepte.   
    #print('Coeficientes para recta de regresión: ', np.round_(regr.coef_, decimals=2))  

    #Gráfico de dispersión de puntos obtenidos
    plt.scatter(y_test, y_pred, c='g',linewidths=1,marker='x')
    plt.xlabel("Precios test")
    plt.ylabel("Precios en predicción")
    plt.title("Precios reales vs Precios de predicción - {0}".format(archivo.replace('.csv','')))
    #plt.show()
    plt.savefig("lineal-regr-"+archivo.replace(".csv","") + ".png")


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






