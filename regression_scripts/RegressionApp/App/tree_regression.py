#Arboles
import numpy as np
import matplotlib.pyplot as plt
import pandas as pd
from sklearn.cross_validation import train_test_split
from sklearn.tree import DecisionTreeRegressor

def procesarArchivo(archivo):
    print('********************')
    print('Resultados para: ', archivo)
    dataset = pd.read_csv(archivo, delimiter=',') #importamos el dataset pasado como parámetro

    X = dataset.iloc[:, :-1].values #Obtenemos la matriz de variables independientes
    y = dataset.iloc[:, 42].values #Obtenemos el vector de la variable dependiente
    
    X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state = 0)

    # Ajuste del modelo
    regr_1 = DecisionTreeRegressor(max_depth=2)
    regr_2 = DecisionTreeRegressor(max_depth=5)
    regr_1.fit(X, y)
    regr_2.fit(X, y)

    # Predict
    y_1 = regr_1.predict(X_test)
    y_2 = regr_2.predict(X_test)

    # Plot the results
    plt.figure()
    plt.scatter(X, y, s=20, edgecolor="black", c="darkorange", label="data")
    plt.plot(X_test, y_1, color="cornflowerblue", label="max_depth=2", linewidth=2)
    plt.plot(X_test, y_2, color="yellowgreen", label="max_depth=5", linewidth=2)
    plt.xlabel("data")
    plt.ylabel("target")
    plt.title("Regresión con árboles")
    plt.legend()
    plt.show()

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






