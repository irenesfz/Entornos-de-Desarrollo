/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package TablaEnteros;

/**
 * @author Irene Sánchez
 * @version 1
 */

public class TablaEnteros {
   private Integer[] tabla;

   TablaEnteros (Integer[] tabla) {
      if (tabla==null || tabla.length==0)
         throw new IllegalArgumentException("No hay elementos");
     this.tabla=tabla;
   }

   /** 
    * devuelve la suma de los elementos de la tabla
    * @return suma
    */
  public int sumaTabla() {
    int suma=0;
    for (int i=0; i<tabla.length; i++)
       suma+=tabla[i];
   return suma;
  }

  /**
   * devuelve el mayor elemento de la tabla
   * @return max
   */
  public int mayorTabla() {
    int max=-999;
    for (int i=0; i<tabla.length; i++)
       if (tabla[i]> max)
          max=tabla[i];
   return max;
  }

  /**
   * devuelve la posición de un elemento cuyo valor se pasa
   * @param n
   * @return i
   * @throws java.util.NoSuchElementException
   */
  public int posicionTabla(int n) {
    int suma=0;
    for (int i=0; i<tabla.length; i++)
       if (tabla[i]==n)
          return i;
    throw new java.util.NoSuchElementException("No existe" + n);

  }
}