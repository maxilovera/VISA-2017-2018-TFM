#Arboles
import numpy as np
import matplotlib.pyplot as plt
import pandas as pd
from sklearn.cross_validation import train_test_split
from sklearn.neural_network import MLPRegressor

def procesarArchivo(archivo):
    print('********************')
    print('Resultados para: ', archivo)
    dataset = pd.read_csv(archivo, delimiter=',') #importamos el dataset pasado como parámetro

    X = dataset.iloc[:, :-1].values #Obtenemos la matriz de variables independientes
    y = dataset.iloc[:, 41].values #Obtenemos el vector de la variable dependiente
    
    X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state = 0)
    X_scaled_train = preprocessing.scale(X_train)
    X_scaled_test = preprocessing.scale(X_test)

    # Ajuste del modelo
    regr = MLPRegressor()    
    regr.fit(X_scaled_train, y_train)

    # Predict
    y_pred = regr.predict(X_scaled_test)

    # Plot the results
    score = regr.score(X_scaled_test, y_test)
    print(score)

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






