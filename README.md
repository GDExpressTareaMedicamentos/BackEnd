Drones

Introducción
Expertos en meteorología pronostican una activa próxima temporada ciclónica en el Caribe. La empresa
DronesTech ha decidido asentarse en varios países de la región para con el despliegue de su tecnología
cubrir el envío de medicamentos entre regiones que queden incomunicadas durante el paso de los
ciclones. DronesTech ha decidido contratarlo para que implemente el sistema a implantar.
Descripción
Un Dron tiene:
1 número de serie (máximo 100 caracteres);
2 modelo (peso ligero, peso medio, peso crucero, peso pesado);
3 peso límite (máximo 500gr);
4 capacidad de la bateria (en porciento);
5 estado (INACTIVO, CARGANDO, CARGADO, ENTREGANDO CARGA, CARGA ENTREGADA,
REGRESANDO).
Cada Medicamento tiene:
1 Nombre (permitido solo letras, números, ‘-‘, ‘_’);
2 Peso;
3 Código (permitido solo letra mayúscula, guión bajo y números);
4 Imagen (imagen del medicamento).

Desarrolle un servicio a través de un API REST que permita a los clientes comunicarse con los drones. La
comunicación específica con el dron está fuera del alcance de esta tarea.
El servicio debe permitir:
1. registrar un dron;
2. cargar un dron con medicamentos;
3. obtener los drones disponibles para ser cargados;
4. comprobar el nivel de batería para un dron dado;
5. comprobar el peso medicamentos cargados para un dron dado;

Requerimientos
Mientras implemente su solución tenga en cuenta los siguientes requerimientos:
Requerimientos funcionales
1 No es necesario una interfaz de usuario;
2 Debes prevenir que un dron sea cargado con más peso del que peude transportar;
3 Debe prevenir que el dron esté en estado CARGANDO si el nivel de batería está **por debajo de
25%**;

Requerimientos no funcionales
1 Desarrolle su servicio con tecnología .NET
2 Entrada/salida debe ser en formato JSON;
3 El proyecto debe ser ejecutable
4 Pruebas unitarias son opcionales pero recomendadas (si tienes tiempo);
5 Muéstranos tu trabajo a través del histórico de commits.
