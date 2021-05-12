#include <iostream>
using namespace std;
/**
 * @class persona
 * @brief Representa a una clase. Tiene una serie de funciones y un atributo con los cuales va a desempeñar varias acciones.
 * 
 * Tiene un atributo privado nombre de tipo char con un máximo de 40 caracteres, también tiene 5 funciones/métodos públicos de tipo Void:
 * dormir, hablar, contar (la cual tiene un parámetro de entrada), adquirirNombre y decirNombre.
 */
class persona
{
    public:
        void dormir();
        void hablar();
        void contar(int);
        void adquirirNombre();
        void decirNombre();

    private:
        char nombre[40];
};
/**
* @brief Método que se usa para dormir al personaje. 
*
* El método saca por pantalla una cadena de caracteres 
* formada por una secuencia de “z”
*/
void persona::dormir()
{
    cout << "zzzzzzzzz" << endl;
}
/**
* @brief Método que se usa para que el personaje hable.
*
* El método saca por pantalla una cadena de caracteres 
* formada por una secuencia de “bla”
*/
void persona::hablar()
{
    cout << "bla bla bla bla" << endl;
}
/**
* @brief Método que se usa para contar. 
*
* El método recibe parámetro (un entero) y saca por pantalla la
* serie de incrementos desde el número 0 hasta el que indique el parametro de entrada
* @param limite número entero hasta el que se va a poder contar.
*/
void persona::contar(int limite)
{
    for (int i = 0; i < limite; i++)
    {
        cout << i << endl;
    }
}
/**
* @brief Método que se usa para guardar nombre. 
*
* El método saca por pantalla (output) una cadena de caracteres en la que le pide ingresar el nombre. 
* El usuario tiene que introducir su nombre (input).
*/
void persona::adquirirNombre()
{
    cout << "Soy una persona. Ingrese mi nombre: ";
    cin >> nombre;
}
/**
 * @brief Método que se usa para mostrar por pantalla el nombre.
 * 
 * Se va a mostrar por pantalla la cadena de caracteres "Mi nombre es: " 
 * seguido del contenido que haya guardado en la variable nombre en el método
 * adquirirNombre()
 */
void persona::decirNombre()
{
    cout << "Mi nombre es: " << nombre << endl;
}
/**
 * @class main
 * @return 0
 * @brief Representa a la clase principal. Se creará un nuevo objeto persona o no, dependiendo de lo que introduzca el usuario.
 * Si se crea un nuevo objeto, el usuario podrá elegir una serie de acciones, si quiere que se vaya a la cama o que cuente hasta cierto numero.
 * 
 * Se muestra por pantalla si desea crear una persona con dos posibles opciones. El usuario introducirá 1 si sí quiere crearla o 2 si no. 
 * Si introduce 1 crea un nuevo objeto persona. De nuevo el usuario tendrá que elegir.
 * Se muestra por pantalla si el usuario quiere que el nuevo objeto persona creado quiere que se vaya a dormir dejando claro que 
 * introduzca 1 para sí y 2 para no. Si introduce 1 el objeto persona iniciará la función dormir.
 * A continuación muestra por pantalla otra actividad con 2 posibles respuestas 1 si sí, 2 si no.
 * Si introduce sí el nuevo objeto iniciará la funcion contar, con un límite como parámetro de entrada.
 */
int main()
{
    int respuesta = 0;
    cout << "Desea crear una persona? 1=Si, 0=No: ";
    cin >> respuesta;
    if (respuesta == 1)
    {
        persona *p = new persona();
        cout << "Desea que vaya a dormir? 1=Si, 0=No: ";
        cin >> respuesta;
        if (respuesta == 1)
        {
            p->dormir();
        }
        cout << "Desea oirme contar? 1=Si, 0=No: ";
        cin >> respuesta;
        if (respuesta == 1)
        {
            p->contar(20);
        }
    }
    system("pause");
    return 0;
}