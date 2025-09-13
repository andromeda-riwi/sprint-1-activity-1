Realizado por Abrahan taborda echavarria 

🎬 Calculadora de Precios de Cine (Versión para Principiantes)
Este es un programa de consola interactivo desarrollado en C# que calcula el precio de una entrada de cine. Su principal objetivo es servir como una herramienta de aprendizaje para programadores principiantes. El código es completamente secuencial, sin el uso de funciones auxiliares, lo que facilita el seguimiento del flujo del programa línea por línea para entender conceptos básicos como variables, bucles y condicionales.

🌟 Características Principales
Totalmente Interactivo: El programa solicita todos los datos necesarios para el cálculo directamente al usuario.

Validación de Datos Integrada: Cada entrada del usuario se valida para asegurar que sea correcta antes de continuar.

Lógica de Negocio Clara: Aplica un conjunto de reglas de descuento complejas de forma ordenada y explícita.

Estructura Secuencial: El código fluye de arriba hacia abajo sin saltos a funciones, ideal para depurar y entender la lógica paso a paso.

Resultados Detallados: Al final, muestra un resumen claro con el precio base, todos los descuentos aplicados y el costo final.

🚀 ¿Cómo Ejecutar el Programa?
Para compilar y ejecutar este proyecto, necesitas tener instalado el SDK de .NET.

Guarda el código: Guarda el código en un archivo con la extensión .cs, por ejemplo, CineParaPrincipiantes.cs.

Abre una terminal: Abre una terminal o línea de comandos (como PowerShell, CMD o Terminal).

Navega al directorio: Usa el comando cd para moverte a la carpeta donde guardaste el archivo.

Bash

cd ruta/a/tu/carpeta
Ejecuta el programa: Utiliza el siguiente comando. .NET compilará y ejecutará el archivo automáticamente.

Bash

dotnet run
Sigue las instrucciones: La consola te pedirá que ingreses los datos uno por uno.

💻 Estructura y Flujo del Código
El programa está organizado en 5 pasos lógicos y secuenciales que facilitan su comprensión:

1. Pedir Datos al Usuario
El programa solicita cada pieza de información necesaria: edad, tipo_pelicula, dia, hora, membresia, estudiante, pareja y promo_activa. Se utiliza un bucle while(true) para cada dato, que solo se rompe cuando el usuario ingresa una opción válida.

2. Variables y Lógica de Cálculo
Se inicializan las variables clave para el cálculo, como precio_base ($10,000), precioFinal y un acumulador para los descuentos (porcentajeDescuentoTotal).

3. Casos Especiales
El código verifica primero si existen reglas únicas que terminan la ejecución de forma inmediata, como:

Edad prohibida: Si el usuario no tiene la edad mínima, el programa termina.

Maratón: Aplica un descuento fijo y el programa termina.

El uso de return; en estos bloques detiene la ejecución inmediatamente.

4. Lógica Principal de Descuentos
Si no es un caso especial, el programa evalúa todas las demás reglas de descuento en un orden específico. Cada bloque if verifica una condición (edad, día, membresía, etc.) y, si se cumple, suma un porcentaje al total de descuentos y añade una descripción a una lista de descuentos aplicados.

5. Cálculo Final y Resultado
Finalmente, el precioFinal se calcula aplicando el porcentajeDescuentoTotal acumulado al precio_base. Se añade un recargo si la película es 3D. El programa imprime un resumen claro y detallado de todo el proceso.

📄 Ejemplo de Uso
Aquí tienes un ejemplo de cómo se vería una interacción con el programa en la consola:

--- BIENVENIDO A LA CALCULADORA DE PRECIOS DEL CINE ---
Por favor, ingrese los siguientes datos.

Ingrese su edad: 65
Ingrese el tipo de película (Opciones: estreno, clasico, 3D, maraton, funcion_especial):> clasico
Ingrese el día de la semana (Opciones: lunes, martes, miercoles, jueves, viernes, sabado, domingo):> domingo
Ingrese la hora de la función (Opciones: mañana, tarde, noche):> tarde
Ingrese su tipo de membresía (Opciones: ninguna, silver, gold, platino):> gold
¿Es estudiante? (s/n): n
¿Compran como pareja (2 boletos)? (s/n): n
¿Hay alguna promoción general activa? (s/n): s

--- Calculando precio... ---

Precio Base: $10.000
Descuentos Aplicados: Descuento Senior + 25% Gold + 10% Extra Promo Domingo
Precio Final a Pagar: $2.000
