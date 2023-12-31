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

### ¿Cuando usar .NET CORE?
- Vas a crear microservicios (pues las apps de .NET son de alto rendimiento).
- Vas a utilizar contenedores Docker.
- Necesitas capacidad multi-plataformas.
- Quieres utilizar un framework moderno de desarrollo.
- Necesitas una linea de comandos para automatizar procesos relacionados con el desarrollo, prueba o publicación de tus aplicaciones.

### ¿Cuando utilizar .NET Framework?
- Utilizarás una tecnología la cual no es soportada por .NET Core, como WFC o webforms.
- Necesitas utilizar APIs específicos de Windows. Dado que .NET Core es multiplataforma, este no asume el sistema operativo donde se va a ejecutar.
- Existen funcionalidades de .NET que aún no están disponibles en .NET Core.

### Comandos

Para ver las plantillas con la que podemos crear un proyecto.
```
dotnet new --list
```
Para cambiar de versión:
```
dotnet new globaljson --sdk-version 5.x.x --force
```
Listar los SDKS:
```
dotnet --list-sdks
```
### Swagger
Es una libreria de JavaScript. Se puede habilitar e integrar fácilmente en la app para mostrar y documentar las APIs de forma automática.
### Debuger
Marca el endPoint
Presionar F5
presionar F10 para avanzar
Volver a presionar F5 para continuar.
**Nota: Sin debuger seria CTRL + F5**

### ASP.NET CORE 6
Desde la versión 6 ya se elimina la clase startup. Aquí anteriormente se configuraba los servicios y el middleware de la aplicación.

### Cambiando de Versión
Dentro de la carpeta usuarios hay un archivo global.json, ahi indicar que version de dotnet
se quiere utilizar. Esta ya debe estar previamente descargada e instalada.
### Desactivando los tipos de referencia no Nulos
Abrir el csproj y encontraremos la etiqueta <Nullable> enable <Nullable>, lo cambiamos por **disable**. Sino hacemos esto vamos a tener errores al momento de crear autores o libros en el desarrollo de la web API.

### Entity Framework Core
A través del dbContext es dodne configuramos EFC en nuestra app, configurar el conexión String (representa la BD que vamos a utilizar), reglas de validación etc, es una manera tbn de crear una bd a través de código de código C#.
Instalar los paquetes para poder hacer migraciones ,etc, de manera gráfica:
> Microsoft.EntityFrameworkCore.sqlServer
> Microsoft.EntityFrameworkCore.tools
![DbdContext](img/ApplicationDvContext.png)

Ahora toca configurar el conectionString:
![dbConecction](img/conecction.png)
con Security se indica que vamos a utilizar las credenciales de windows para autenticarnos.
Initial Catalog es el nombre de la BD y Data Source es el servidor. 
Ahora para terminar de consigurar se debe de hacer en los servicios de startup:
![startup](img/startup.png)

#### Comandos:
###### Package Management Console: Herramientas > Administrador de paquetes Nuget > Consola.
Para hacer una migración y crear tu tabla en sql server:
```
Add-Migration Inicial  
```
Toma las migraciones pendientes y lo empuja a la BD. Si la BD no existe, lo crea.
```
Update-Database  
```
##### Mismos comandos con Dotnet CLI:
```
dotnet ef migrations add Inicial 
```
Toma las migraciones pendientes y lo empuja a la BD. Si la BD no existe, lo crea.
```
dotnet ef database update 
```
![Nuget Console](img/console.png)

Para visualizar la BD ir a: View > SQL Server Onject Explorer
Salida: Se creó la BD y dentro de ella la tabla.
![BD](img/2.png)