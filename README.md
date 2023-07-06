# Construyendo Web APIs RESTfull con ASP.NET Core 6

### ¿Qué es una web API?
- Una web API expone un conjunto de funciones de una aplicación web, los cuales podrán ser consumidos por aplicaciones de cualquier plataforma. 
- Una API permite que dos aplicaciones completamente distintas puedan comunicarse entre si.
- Otra Importancia de los APIS, a nivel general, es permitir realizar abstracciones, es decir, no necesitas conocer como funciona internamente, basta con consumir las funciones que expone.
  
*Existen ciertos estilos para hacer web APIS, uno es REST.*

### REST (Representational State Transfer)
Es un estilo de construir servicios web los cuales se adhieren a un conjunto de principios establecidos. Cuando consumimos una web API, es porque queremos acceder a sus recursos.
Una idea que se relaciona con REST es utilizar métodos HTTP sobre una URl para ejecutar
funciones de la web API, por ejemplo si hacemos un GET sobre https://miWebApi.com/api/usuario nos devolverá la lista de usuarios.

Para que una API sea RESTFULL se debe de cumplir 6 condiciones:
  - Arquitectura Cliente Servidor: El servidor es la web API y el cliente es cualquier software
    que se pueda comunicar con http con el servidor, ejemplo, un app movil, web, etc.
  - Interfaz Uniforme: La idea de la IU es tener una forma estandarizada de transmisión información, es decir, si ya sabes como consumir una API, que las otras no se te sea muy dificil.
    Nos pide *4 subs condiciones:*
    - Identificacion del recurso: Para esto utilizamos las URL.
    - Manipulación de recursos usando representaciones: Si el cliente tiene una manera de acceder
      al recurso, tipicamente una URL, entonces ya con esto se puede utilizar el recurso.
    - Mensajes autodescriptivos: Todos los mensajes deben indicar toda la información necesaria
      para que sean trabajados por el servidor de manera satisfactoria. Estos mensajes son los HTTP, algo que un mensaje puede indicar es el formato en el que quiere la información del servidor, para eso se puede utilizar midio tips. Son indicadores de formato para indicar que la información de la web API se nos de en formato JSON, XML, PDF, etc.
    - HATEOAS: Hipermedia como motor del estado de la app (en español). La información que nos da la web API cuando hacemos una petición debe incluir links para poder seguir explorando los recursos de la web API.
-  Protocolos sin estado: Cada una de las peticiones realizadas a la web API tienen toda la 
        información necesaria para que la petición sea resuelta de manera satisfactoria. 
- Cache: Las respuestas de la web API deben indicar cuando se deben guardar en cache, osea el recurso dado por una URL de manera local. De tal manera que en sus siguientes peticiones el recurso ya no debe de ser pedido a la web API. Esto disminuye el tiempo de respuesta que deben esperar los clientes al usar la aplicación. 
- Sistema de capas: El servicio del servidor debe tener una arquitectura de capas, donde su evolución sea completamente transparente para el cliente. Por ejemplo, si los servicios web va a utilizar los balances o balanceadores de carga, tus clientes no tienen porque tener presente este detalle, sino que debe ser transparente.
- Código en demanda (Opcional): El servicio web tiene la opción de enviar código fuente el cual se va a ejecutar en el cliente. Tipicamente este código es JavaScript.

### Métodos HTTP
- Es para hacer manipulaciones de recursos a través de una URL
- Los métodos HTTP, son un mecanismo del protocolo HTTP los cuales nos permiten expresar una acción que queremos ejercer sobre el recurso. Estos métodos son:
  - GET: Este se utiliza para pedir datos del servidor.
  - HEAD: Hace lo mismo que el método GET, sin embargo, no nos trae el cuerpo de la respuesta, sino solamente la cabecera.
  - POST: Sirve para indicar que queremos enviar información al servidor, tipicamente a través del cuerpo de la petición HTTP. El uso común que se le da al post es insertar la información enviada al web API en una base de datos.
  - PUT: Normalmente utilizamos put casi de la misma manera que post, con la diferencia de que put tbn sirve para actualizar un recurso existente en la base de datos.
  - DELETE: Sirve para expresar que queremos borrar un recurso determinado.
  - PACH: Este se utiliza para realizar actualizaciones parciales a un recurso. La ventaja es que es relativamente rápida comparada con el método put. 

### Anatomía de una petición HTTP
Una petición http se divide en tres partes:
- Una línea de petición:
  - Aquí se coloca el método http a utilizar, la URI de la petición y el protoclo http a utilizar.
    Ejemplo: POST/api/autores HTTP/1.1
- Un conjunto de campos de cabecera.
  - Aquí se envian metadatos para brindar información sobre la petición. En la cabecera puede haber multiples cabeceras.
- Un cuerpo (opcional): Aquí es donde podemos colocar información adicional que se va a enviar al servidor. Lo métodos que usan esto son el POST, el get no envia nada.
  
Cuando el cliente envia una petición el servidor da una *RESPUESTA* HTTP. Su estructura es la siguiente:
 - Línea de status: Aquí se indica el status de la petición, es decir, si fue exitoso, si hubo un error ó si se requiere que tomemos algún tipo de acción.
 - Cabecera: Es un conjunto de cabeceras.
 - Cuerpo (opcional): es la data que el servidor quiere transmitir.

### Códigos de status HTTP
Cuando se hace una petición http a un servidor web, eventualmente recibiremos una respuesta HTTP y entre ella se encuentra el código del status. Este es un número que indica el resultado de la operación y unas frases, por ejemplo: Error 404 - Not Found.

La naturaleza del error es determinada por el código de status. Existen 5 categorias
| Código | Categoría          |
| -----: | ------------------ |
|    1xx | Informacional      |
|    2xx | Exitoso            |
|    3xx | Redirección        |
|    4xx | Error del cliente  |
|    5xx | Error del servidor |

- Informacional: Cuando se envia una petición http al servidor, este verifica si va a procesar la solicitud y de ser asi devuelve una respuesta de que la petición será procesada y que deeb de esperar la respuesta final más adelante, osea da una respuesta provisional.
- Exitoso: Es para indicar que la petición ha sido exitosa.
- Redirección: Este indica que el lciente toma acciones adicionales para completar la petición. En ocasiones ocurre de manera automatica sin necesidad de que accione el usuario.
- Error del Cliente: Indica que el cliente ha cometido un error al momento de hacer la petición.
- Error del servidor: Este indica que el servidor ha fallado en poder satisfacer la petición.Sin embargo el error ha ocurrido por un problema en el servidor, que para nada es culpa del usuario.
> Los errores 400 son culpa del usuario y los 500 son culpa del developer.
> 



