#Arboles
import math
import numpy as np
import matplotlib.pyplot as plt
import pandas as pd
from sklearn.cross_validation import train_test_split
from sklearn.metrics import mean_squared_error, r2_score
from sklearn.tree import DecisionTreeRegressor, export_graphviz
from sklearn.preprocessing import StandardScaler

def procesarArchivo(archivo):
    print('********************')
    print('Resultados para: ', archivo)

    dataset = pd.read_csv(archivo, delimiter=',') #importamos el dataset pasado como parámetro
    X = dataset.iloc[:, :-1].values #Obtenemos la matriz de variables independientes
    y = dataset.iloc[:, -1].values #Obtenemos el vector de la variable dependiente
    
    X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state = 0)
    
    # Definicion de los modelos, tenemos un nombre y un objeto DecisionTreeRegressor con parámetros modificados
    regs =[('dep_defecto - mse ', DecisionTreeRegressor()),
           ('Max_depth=2 - mse ', DecisionTreeRegressor(random_state=0,max_depth=2)),
           ('Max_depth=5 - mse ', DecisionTreeRegressor(random_state=0,max_depth=5)),
           ('Max_depth=15 - mse ', DecisionTreeRegressor(random_state=0,max_depth=15)),
           ('dep_defecto - fman_mse', DecisionTreeRegressor(random_state=0,criterion="friedman_mse")),
           ('dep_defecto - mae ', DecisionTreeRegressor(random_state=0,criterion="mae")),
           ('max_depth=5 - fman_mse', DecisionTreeRegressor(random_state=0,max_depth=5,criterion="friedman_mse")),
           ('max_depth=5 - mae ', DecisionTreeRegressor(random_state=0,max_depth=5,criterion="mae")),
           ('max_depth=15 - fman_mse', DecisionTreeRegressor(random_state=0,max_depth=15,criterion="friedman_mse")),
           ('max_depth=15 - mae ', DecisionTreeRegressor(random_state=0,max_depth=15,criterion="mae"))]
   
    best_regr="" #Valores por defecto para graficar el mejor resultado
    min_error=90000 #Valores por defecto para graficar el mejor resultado
    y_best_pred=[] #Valores por defecto para graficar el mejor resultado

    #Por cada regresor ejecutamos el ajuste del modelo a los datos de entrenamiento y predecimos con la matriz de test
    for x in regs: 
        regr = x[1]
        regr.fit(X_train, y_train)
        y_pred = regr.predict(X_test)    
        #metricas         
        rmse = math.sqrt(mean_squared_error(y_test, y_pred))
        print(x[0] + '\t\tCoeficiente de determinación: %.2f' % r2_score(y_test, y_pred) + "\t\tRMSE: %.2f" % rmse)        
        if (rmse < min_error): #si minimizamos el error, usamos la predicción actual como posible mejor prediccion
            min_error = rmse
            y_best_pred = y_pred
            best_regr=x
                    
    # Plot best results    
    export_graphviz(best_regr[1], out_file=archivo + '.dot', filled=True, rounded=True, special_characters=True)
    plt.scatter(y_test, y_pred, c='g',linewidths=1,marker='x')
    plt.xlabel("Precios test")
    plt.ylabel("Precios en predicción")
    plt.title("Precios reales vs Precios de predicción - '{0}' {1}".format(best_regr[0],archivo.replace('.csv','')))
    #plt.show()
    plt.savefig("tree-regr-"+archivo.replace(".csv","") + ".png")
    

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






