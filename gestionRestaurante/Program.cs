using System;
using MySql.Data.MySqlClient;

using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;

using System.Text;

using System.Diagnostics;


public static class Program
{
    //Variable de conexion con MySQL
    static string connectionString = "Server=localhost;Port=3306;Database=gestionRestaurante;User Id=root;Password=admin;";

    //Construccion de salida CRUD
    static StringBuilder consoleOutput = new StringBuilder();

    //Busqueda BACKUPS
    static string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    static string backupFolder = Path.Combine(desktopPath, "BACKUPS_gestionRestaurante");


    static void Main(string[] args)
    {
        PrincipalMenu();
    }

    //MENU 0
    static void PrincipalMenu(){
                while (true)
        {
            Console.WriteLine("\n--BIENVENIDO A LA GESTION DE TU RESTAURANTE--");
            Console.WriteLine("Cuentanos. ¿Que deseas realizar?\n");
            Console.WriteLine("1. Administrar Usuarios");
            Console.WriteLine("2. Administrar Roles");
            Console.WriteLine("3. Administrar entidades y atributos");
            Console.WriteLine("4. Generar el CRUD de la Data Base");
            Console.WriteLine("5. Gestionar base de datos");
            Console.WriteLine("6. Generar Reporte");
            Console.WriteLine("7. Salir");
            Console.WriteLine("\nSelecciona una opción:");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    AdminUser();
                    break;
                case "2":
                    AdminRols();
                    break;
                case "3":
                    AdminQuerys();
                    break;
                case "4":
                    AdminCRUD();
                    break;
                case "5":
                    AdminDataBase();
                    break;
                case "6":
                    GenerateReport();
                    break;
                case "7":
                    Console.WriteLine("Saliendo, que tenga buen dia");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Seleccion incorrecta, intente nuevamente :/");
                    break;
            }
            Console.WriteLine();
        }
    }
    
    //SUB MENU 1
    static void AdminUser(){
                while (true)
        {
            Console.WriteLine("\n--Administracion de Usuarios--");
            Console.WriteLine("1. Crear nuevo usuario");
            Console.WriteLine("2. Actualizar usuario existente");
            Console.WriteLine("3. Eliminar usuario");
            Console.WriteLine("4. Listar usuario");
            Console.WriteLine("5. Regresar");
            Console.WriteLine("6. Salir");
            Console.WriteLine("\nSelecciona una opción:");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    addUser();
                    break;
                case "2":
                    updateUser();
                    break;
                case "3":
                    deleteUser();
                    break;
                case "4":
                    listUser();
                    break;
                case "5":
                    PrincipalMenu();
                    break;
                case "6":
                    Console.WriteLine("Saliendo, que tenga buen dia");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Seleccion incorrecta, intente nuevamente :/");
                    break;
            }

            Console.WriteLine();
        }
    }
    
    //SUB MENU 2
    static void AdminRols(){
                while (true)
        {
            Console.WriteLine("\n--Administracion de Roles--");
            Console.WriteLine("1. Crear nuevo rol de DB");
            Console.WriteLine("2. Eliminar rol de DB");
            Console.WriteLine("3. Listar roles creados");
            Console.WriteLine("4. Asignar rol a usuario existente");
            Console.WriteLine("5. Consultar rol de usuario existente");
            Console.WriteLine("6. Regresar");
            Console.WriteLine("7. Salir");
            Console.WriteLine("\nSelecciona una opción:");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    addRol();
                    break;
                case "2":
                    deleteRol();
                    break;
                case "3":
                    listRol();
                    break;
                case "4":
                    AssignRoleToUser();
                    break;
                case "5":
                    listRolUser();
                    break;
                case "6":
                    PrincipalMenu();
                    break;
                case "7":
                    Console.WriteLine("Saliendo, que tenga buen dia");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Seleccion incorrecta, intente nuevamente :/");
                    break;
            }

            Console.WriteLine();
        }
    }
    
    //SUB MENU 3
    static void AdminDataBase(){
                while (true)
        {
            Console.WriteLine("\n--Administracion de Datos--");
            Console.WriteLine("1. Respaldar base de datos");
            Console.WriteLine("2. Restaurar base de datos");
            Console.WriteLine("3. Mostrar registro de restauracion");
            Console.WriteLine("4. Regresar");
            Console.WriteLine("5. Salir");
            Console.WriteLine("\nSelecciona una opción:");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    saveDataBase();
                    break;
                case "2":
                    restoreDataBase();
                    break;
                case "3":
                    showDataRegister();
                    break;
                case "4":
                    PrincipalMenu();
                    break;
                case "5":
                    Console.WriteLine("Saliendo, que tenga buen dia");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Seleccion incorrecta, intente nuevamente :/");
                    break;
            }

            Console.WriteLine();
        }
    }

    //SUB MENU 4
    static void AdminQuerys(){
                while (true)
        {
            Console.WriteLine("\n--Administracion de atributos y entidades--");
            Console.WriteLine("1. Listar las entidades");
            Console.WriteLine("2. Listar atributos por entidades");
            Console.WriteLine("3. Agregar entidades a la DB");
            Console.WriteLine("4. Regresar");
            Console.WriteLine("5. Salir");
            Console.WriteLine("\nSelecciona una opción:");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    listAllTables();
                    break;
                case "2":
                    listAtributes();
                    break;
                case "3":
                    addEntities();
                    break;
                case "4":
                    PrincipalMenu();
                    break;
                case "5":
                    Console.WriteLine("Saliendo, que tenga buen dia");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Seleccion incorrecta, intente nuevamente :/");
                    break;
            }

            Console.WriteLine();
        }
    }
    
    //SUB MENU 5
    static void AdminCRUD(){
                while (true)
        {
            Console.WriteLine("\n--Generacion del CRUD en la base de datos--");
            Console.WriteLine("1. Generar el CRUD");
            Console.WriteLine("2. Eliminar el CRUD");
            Console.WriteLine("3. Regresar");
            Console.WriteLine("4. Salir");
            Console.WriteLine("\nSelecciona una opción:");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    generateCRUD();
                    break;
                case "2":
                    dropAllProcedures();
                    break;
                case "3":
                    PrincipalMenu();
                    break;
                case "4":
                    Console.WriteLine("Saliendo, que tenga buen dia");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Seleccion incorrecta, intente nuevamente :/");
                    break;
            }

            Console.WriteLine();
        }
    }

    //SUB MENU 6
    static void GenerateReport(){
                while (true)
        {
            Console.WriteLine("\n--Generar Reporte de entidades--");
            Console.WriteLine("1. Generar Reporte PDF");
            Console.WriteLine("2. Regresar");
            Console.WriteLine("3. Salir");
            Console.WriteLine("\nSelecciona una opción:");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    GeneratePDF();
                    break;
                case "2":
                    PrincipalMenu();
                    break;
                case "3":
                    Console.WriteLine("Saliendo, que tenga buen dia");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Seleccion incorrecta, intente nuevamente :/");
                    break;
            }

            Console.WriteLine();
        }
    }


//////////////////////////////////////////////////////////

    static void addUser()
    {
        try
        {
            Console.WriteLine("\nIngrese el nombre del usuario a crear:");
            string nombreUsuario = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nombreUsuario))
            {
                Console.WriteLine("El campo no puede estar vacio!!!");
                return;
            }

            Console.WriteLine("Ingrese la contraseña:");
            string contraseña = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(contraseña))
            {
                Console.WriteLine("El campo no puede estar vacio!!!");
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                
                // Crear el usuario en la base de datos
                string createUserQuery = $"CREATE USER '{nombreUsuario}'@'localhost' IDENTIFIED BY '{contraseña}'";
                using (MySqlCommand command = new MySqlCommand(createUserQuery, connection))
                {
                    command.ExecuteNonQuery();
                }

                Console.WriteLine("\n*Usuario agregado exitosamente al registro*");
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("\nError al crear el usuario: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("\nError inesperado al crear el usuario: " + ex.Message);
        }
    }

    static void updateUser()
    {
        try
        {
            Console.WriteLine("\nIngrese el usuario a actualizar:");
            string nombreUsuario = Console.ReadLine();

            Console.WriteLine("Ingrese el nuevo nombre de usuario:");
            string nuevoNombreUsuario = Console.ReadLine();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string alterUserQuery = $"RENAME USER '{nombreUsuario}'@'localhost' TO '{nuevoNombreUsuario}'@'localhost'";
                using (MySqlCommand command = new MySqlCommand(alterUserQuery, connection))
                {
                    command.ExecuteNonQuery();
                }

                Console.WriteLine("\n*Usuario actualizado exitosamente en el registro*");
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("\nError al actualizar el usuario: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("\nError inesperado al actualizar el usuario: " + ex.Message);
        }
    }

    static void deleteUser()
    {
        try
        {
            Console.WriteLine("\nIngrese el usuario a eliminar:");
            string nombreUsuario = Console.ReadLine();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Verificar si el usuario existe
                string checkUserQuery = $"SELECT COUNT(*) FROM mysql.user WHERE user = '{nombreUsuario}'";
                using (MySqlCommand checkCommand = new MySqlCommand(checkUserQuery, connection))
                {
                    int userCount = Convert.ToInt32(checkCommand.ExecuteScalar());

                    if (userCount == 0)
                    {
                        Console.WriteLine("\nEl usuario no existe dentro de la base de datos.");
                        Console.WriteLine("\nIntente nuevamente");
                        return;
                    }
                }

                // Eliminar el usuario de la base de datos
                string dropUserQuery = $"DROP USER IF EXISTS '{nombreUsuario}'@'localhost'";
                using (MySqlCommand dropCommand = new MySqlCommand(dropUserQuery, connection))
                {
                    dropCommand.ExecuteNonQuery();
                }

                Console.WriteLine("\n*Usuario eliminado exitosamente del registro*");
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("\nError al borrar el usuario: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("\nError inesperado al borrar el usuario: " + ex.Message);
        }
    }

    static void listUser()
    {
        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Consultar los usuarios de la base de datos
                string selectUsersQuery = "SELECT DISTINCT `User` FROM `mysql`.`user` WHERE `Host` != '%' AND `User` != 'root'";
                using (MySqlCommand command = new MySqlCommand(selectUsersQuery, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine("\n*Usuarios Disponibles en el registro*");
                        while (reader.Read())
                        {
                            Console.WriteLine(reader["User"]);
                        }
                    }
                }
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("\nError al consultar los usuarios: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("\nError inesperado al consultar los usuarios: " + ex.Message);
        }
    }


//////////////////////////////////////////////////////////

static void addRol()
    {
        try
        {
            Console.WriteLine("\nIngrese el nombre del nuevo rol:");
            string roleName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(roleName))
            {
                Console.WriteLine("\nEl nombre del rol no puede estar vacío.");
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string createRoleQuery = $"CREATE ROLE `{roleName}`";
                using (MySqlCommand command = new MySqlCommand(createRoleQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
                Console.WriteLine($"\n*Rol '{roleName}' creado exitosamente*");
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("\nError al crear el rol: " + ex.Message);
        }
    }

static void deleteRol()
{
    Console.WriteLine("\n*Ingrese el nombre del rol a eliminar*");
    string nombreRol = Console.ReadLine();

    try
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            string dropRoleQuery = $"DROP ROLE IF EXISTS `{nombreRol}`";
            using (MySqlCommand command = new MySqlCommand(dropRoleQuery, connection))
            {
                command.ExecuteNonQuery();
            }
            Console.WriteLine("\n*Rol eliminado exitosamente*");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("\nError al borrar el rol: " + ex.Message);
    }
}

static void listRol()
{
    try
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand("SELECT `User` FROM `mysql`.`user` WHERE `Host` = '%' AND `User` != 'root'", connection);
            MySqlDataReader reader = command.ExecuteReader();

            if (!reader.HasRows)
            {
                Console.WriteLine("\n*No hay roles disponibles*");
                return;
            }

            Console.WriteLine("\n*Roles Disponibles*");
            while (reader.Read())
            {
                Console.WriteLine(reader["User"]);
            }
        }
    }
    catch (MySqlException ex)
    {
        Console.WriteLine("\nError al consultar roles: " + ex.Message);
    }
    catch (Exception ex)
    {
        Console.WriteLine("\nError inesperado al consultar roles: " + ex.Message);
    }
}

static void AssignRoleToUser()
{
    try
    {
        Console.WriteLine("\nIngrese el nombre del usuario:");
        string userName = Console.ReadLine();

        Console.WriteLine("Ingrese el nombre del rol:");
        string roleName = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(roleName))
        {
            Console.WriteLine("El nombre de usuario y el nombre del rol no pueden estar vacíos.");
            return;
        }


        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            
            // Asignar el rol al usuario
            string assignRoleQuery = $"GRANT {roleName} TO '{userName}'@'localhost'";
            using (MySqlCommand command = new MySqlCommand(assignRoleQuery, connection))
            {
                command.ExecuteNonQuery();
            }

            Console.WriteLine($"Se asignó el rol '{roleName}' al usuario '{userName}'.");
        }
    }
    catch (MySqlException ex)
    {
        Console.WriteLine("Error al asignar el rol al usuario: " + ex.Message);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error inesperado al asignar el rol al usuario: " + ex.Message);
    }
}

static void listRolUser()
{
    try
    {
        //validar el campo vacio
        Console.WriteLine("\nIngrese el nombre del usuario del que desea ver los roles:");
        string userName = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(userName))
        {
            Console.WriteLine("\nEl nombre del usuario no puede estar vacío.");
            return;
        }

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            // Validar si el usuario existe
            string checkUserQuery = $"SELECT 1 FROM mysql.user WHERE User = @userName AND Host = 'localhost'";
            bool userExists = false;
            using (MySqlCommand checkUserCommand = new MySqlCommand(checkUserQuery, connection))
            {
                checkUserCommand.Parameters.AddWithValue("@userName", userName);
                using (MySqlDataReader userReader = checkUserCommand.ExecuteReader())
                {
                    userExists = userReader.HasRows;
                }
            }

            if (!userExists)
            {
                Console.WriteLine($"\nEl usuario '{userName}' no existe.");
                return;
            }

            // Consultar los roles asignados al usuario
            string userRolesQuery = $"SHOW GRANTS FOR '{userName}'@'localhost'";
            using (MySqlCommand command = new MySqlCommand(userRolesQuery, connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine($"\n*Roles asignados al usuario '{userName}'*");
                    bool firstLineSkipped = false;
                    bool userHasRoles = false;
                    while (reader.Read())
                    {
                        if (!firstLineSkipped)
                        {
                            firstLineSkipped = true;
                            continue;
                        }
                        userHasRoles = true;
                        string grant = reader.GetString(0);
                        string[] roles = grant.Split(',');
                        foreach (var role in roles)
                        {
                            string roleName = role.Split('@')[0].Replace("`", "").Trim();
                            roleName = roleName.Replace("GRANT", "").Trim();
                            Console.WriteLine(roleName);
                        }
                    }

                    if (!userHasRoles)
                    {
                        Console.WriteLine($"\nEl usuario '{userName}' no tiene roles asignados.");
                    }
                }
            }
        }
    }
    catch (MySqlException ex)
    {
        Console.WriteLine("\nError al consultar los roles del usuario: " + ex.Message);
    }
    catch (Exception ex)
    {
        Console.WriteLine("\nError inesperado al consultar los roles del usuario: " + ex.Message);
    }
}

//////////////////////////////////////////////////////////

private static void saveDataBase()
{
    // Crear la carpeta de backup si no existe
    if (!Directory.Exists(backupFolder))
    {
        Console.WriteLine("\n--El directorio no existe, creando la carpeta--");
        Directory.CreateDirectory(backupFolder);
    }

    // Contar el número de backups existentes para determinar el próximo número
    string[] existingBackups = Directory.GetFiles(backupFolder, "backup_*.sql");
    int nextBackupNumber = existingBackups.Length;

    // Crear el nombre del archivo de backup
    string backupFileName = $"backup_{nextBackupNumber}.sql";
    string backupFilePath = Path.Combine(backupFolder, backupFileName);

    // Respaldar la base de datos, excluyendo la tabla registros_restauracion
    string backupCommand = $"mysqldump -u root -padmin --ignore-table=gestionRestaurante.registros_restauracion gestionRestaurante -r \"{backupFilePath}\"";
    try
    {
        // Configurar el proceso para ejecutar el comando de respaldo
        ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd.exe")
        {
            Arguments = $"/C {backupCommand}",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using (Process process = new Process())
        {
            process.StartInfo = processStartInfo;
            process.Start();

            // Capturar la salida estándar y de error
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            process.WaitForExit();

            if (process.ExitCode == 0)
            {
                Console.WriteLine($"\nBackup creado exitosamente en la ruta: {backupFilePath}");
            }
            else
            {
                Console.WriteLine($"\nError al crear el backup: {error}");
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"\nError al crear el backup: {ex.Message}");
    }
}

private static void restoreDataBase()
{
    // Verificar si la carpeta de backups existe
    if (!Directory.Exists(backupFolder))
    {
        Console.WriteLine("\n*No se encontró la carpeta, intenta nuevamente*");
        return;
    }

    // Obtener el archivo de backup más reciente
    string[] existingBackups = Directory.GetFiles(backupFolder, "backup_*.sql");
    if (existingBackups.Length == 0)
    {
        Console.WriteLine("\n*No se encontraron backups a restaurar*");
        return;
    }

    // Ordenar los respaldos por fecha de creación para obtener el más reciente
    Array.Sort(existingBackups);

    // Obtener el archivo de backup más reciente
    string mostRecentBackup = existingBackups[existingBackups.Length - 1];

    // Restaurar la base de datos
    string restoreCommand = $"mysql -u root -padmin gestionRestaurante < \"{mostRecentBackup}\"";

    // Configurar proceso para ejecutar el comando
    ProcessStartInfo startInfo = new ProcessStartInfo()
    {
        FileName = "cmd.exe",
        Arguments = $"/C {restoreCommand}",
        RedirectStandardInput = false,
        UseShellExecute = false,
        CreateNoWindow = true
    };

    // Ejecutar el comando para restaurar la base de datos
    try
    {
        using (Process process = new Process())
        {
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();

            if (process.ExitCode == 0)
            {
                Console.WriteLine($"\n****Base de datos restaurada exitosamente desde: {mostRecentBackup}****");

                // Insertar registro en la tabla de registros de restauración
                insertRegister(DateTime.Now);
            }
            else
            {
                Console.WriteLine($"\n****Error al restaurar la base de datos****");
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"\n****Error al restaurar la base de datos: {ex.Message}****");
    }
}

private static void insertRegister(DateTime fechaRestauracion)
{
    try
    {
        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            Console.WriteLine("Conexión a la base de datos abierta.");
            string insertQuery = "INSERT INTO registros_restauracion (fecha_restauracion) VALUES (@FechaRestauracion)";
            using (var cmd = new MySqlCommand(insertQuery, connection))
            {
                cmd.Parameters.AddWithValue("@FechaRestauracion", fechaRestauracion);
                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine($"Filas afectadas: {rowsAffected}"); // Debugging line
                if (rowsAffected > 0)
                {
                    Console.WriteLine("\n****Registro de restauración insertado correctamente****");
                }
                else
                {
                    Console.WriteLine("\n****No se pudo insertar el registro de restauración****");
                }
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"\n****Error al insertar el registro de restauración: {ex.Message}****");
    }
}

private static void showDataRegister()
{
    try
    {
        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            Console.WriteLine("Conexión a la base de datos abierta.");
            string selectQuery = "SELECT id, fecha_restauracion FROM registros_restauracion ORDER BY fecha_restauracion DESC";
            using (var cmd = new MySqlCommand(selectQuery, connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    Console.WriteLine("\n****Registros de restauración****");
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        DateTime fechaRestauracion = reader.GetDateTime(1);
                        Console.WriteLine($"ID: {id}, Fecha y hora de restauración: {fechaRestauracion}");
                    }
                }
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"\n****Error al mostrar los registros de restauración: {ex.Message}****");
    }
}






//////////////////////////////////////////////////////////

    static void listAllTables()
{
    try
    {
        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string query = "SHOW TABLES;";

            using (var command = new MySqlCommand(query, connection))
            using (var reader = command.ExecuteReader())
            {
                Console.WriteLine("\n*Tablas existentes en la base de datos*");
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(0));
                }
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("\nError al consultar las tablas: " + ex.Message);
    }
}

    static void listAtributes()
{
    try
    {
        Console.WriteLine("\nIngrese el nombre de la tabla para consultar sus atributos:");
        string tabla = Console.ReadLine();

        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            string query = $"DESCRIBE {tabla};";
            
            using (var command = new MySqlCommand(query, connection))
            using (var reader = command.ExecuteReader())
            {
                Console.WriteLine($"\n*Atributos de la tabla '{tabla}'*");
                while (reader.Read())
                {
                    Console.WriteLine($"Atribute: {reader.GetString(0)}, Tipo de dato: {reader.GetString(1)}");
                }
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("\nError al consultar los atributos de la tabla: " + ex.Message);
    }
}

    static void addEntities()
{
    try
    {
        Console.WriteLine("\n*Generando la nueva tabla*");
        Console.WriteLine("\nIngrese el nombre:");
        string nombreTabla = Console.ReadLine();

        Console.WriteLine("\nIngrese el número de columnas:");
        if (!int.TryParse(Console.ReadLine(), out int numeroColumnas) || numeroColumnas <= 0)
        {
            Console.WriteLine("\nNúmero de columnas inválido");
            return;
        }

        Console.WriteLine("\n*Generando su estructura*");
        List<string> columnas = new List<string>();
        for (int i = 0; i < numeroColumnas; i++)
        {
            Console.WriteLine($"\nIngrese el nombre de la columna {i + 1}:");
            string nombreColumna = Console.ReadLine();
            Console.WriteLine($"\nIngrese el tipo de dato para la columna {nombreColumna}:");
            string tipoDato = Console.ReadLine();
            columnas.Add($"{nombreColumna} {tipoDato}");
        }

        string query = $"CREATE TABLE {nombreTabla} ({string.Join(", ", columnas)});";

        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            using (var command = new MySqlCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        Console.WriteLine($"\n*Tabla '{nombreTabla}' creada satisfactoriamente*");
    }
    catch (Exception ex)
    {
        Console.WriteLine("\nError al agregar la nueva tabla: " + ex.Message);
    }
}

//////////////////////////////////////////////////////////

//CRUD MEDIENTE EL PROGRAMA
    public static void generateCRUD()
    {
        using (MySqlConnection con = new MySqlConnection(connectionString))
        {
            con.Open();
            string obtenerTablasQuery = "SHOW TABLES;";
            MySqlCommand obtenerTablasCmd = new MySqlCommand(obtenerTablasQuery, con);
            MySqlDataReader tablasReader = obtenerTablasCmd.ExecuteReader();

            List<string> tablas = new List<string>();

            while (tablasReader.Read())
            {
                tablas.Add(tablasReader[0].ToString());
            }

            tablasReader.Close();

            Console.WriteLine("\n--AGREGANDO EL CRUD--");
            
            foreach (string tabla in tablas)
            {
                // Generar procedimientos almacenados CRUD para cada tabla
                string insertProcedure = generateInsertProcedure(con, tabla);
                executeScriptCRUD(insertProcedure, con);

                string updateProcedure = generateUpdateProcedure(con, tabla);
                executeScriptCRUD(updateProcedure, con);

                string deleteProcedure = generateDeleteProcedure(con, tabla);
                executeScriptCRUD(deleteProcedure, con);

                string selectProcedure = generateSelectProcedure(tabla);
                executeScriptCRUD(selectProcedure, con);
            }
        }
        Console.WriteLine("\n*Se han agregado todos los procedimientos almacenados correctamente*");
    }

    private static string generateInsertProcedure(MySqlConnection con, string tabla)
    {
        StringBuilder insertProcedure = new StringBuilder();
        insertProcedure.AppendLine($"DROP PROCEDURE IF EXISTS Insert_{tabla};");
        insertProcedure.AppendLine($"CREATE PROCEDURE Insert_{tabla}(");

        // Obtener los atributos de la tabla
        List<string> atributos = new List<string>();

        string describeQuery = $"DESCRIBE {tabla};";
        MySqlCommand describeCmd = new MySqlCommand(describeQuery, con);
        MySqlDataReader describeReader = describeCmd.ExecuteReader();

        while (describeReader.Read())
        {
            string columna = describeReader["Field"].ToString();
            string tipoDato = describeReader["Type"].ToString();

            // Si el tipo de dato es ENUM, reemplazar con VARCHAR
            if (tipoDato.StartsWith("enum"))
            {
                tipoDato = "VARCHAR(255)";
            }

            if (!columna.Equals("ID", StringComparison.OrdinalIgnoreCase))
            {
                atributos.Add($"{columna} {tipoDato}");
            }
        }

        describeReader.Close();

        // Concatenar los parámetros
        insertProcedure.AppendLine(string.Join(", ", atributos.Select(a => $"IN p_{a.Split(' ')[0]} {a.Split(' ')[1]}")));
        insertProcedure.AppendLine(")");
        insertProcedure.AppendLine("BEGIN");
        insertProcedure.AppendLine($"INSERT INTO {tabla}");

        // Lista de columnas
        insertProcedure.AppendLine($"({string.Join(", ", atributos.Select(a => a.Split(' ')[0]))})");

        // Lista de valores
        insertProcedure.AppendLine($"VALUES ({string.Join(", ", atributos.Select(a => $"p_{a.Split(' ')[0]}"))});");
        insertProcedure.AppendLine("END;");

        return insertProcedure.ToString();
    }

    private static string generateUpdateProcedure(MySqlConnection con, string tabla)
    {
        StringBuilder updateProcedure = new StringBuilder();
        updateProcedure.AppendLine($"DROP PROCEDURE IF EXISTS Update_{tabla};");
        updateProcedure.AppendLine($"CREATE PROCEDURE Update_{tabla}(");

        // Obtener los atributos de la tabla
        List<string> atributos = new List<string>();

        string describeQuery = $"DESCRIBE {tabla};";
        MySqlCommand describeCmd = new MySqlCommand(describeQuery, con);
        MySqlDataReader describeReader = describeCmd.ExecuteReader();

        while (describeReader.Read())
        {
            string columna = describeReader["Field"].ToString();
            string tipoDato = describeReader["Type"].ToString();

            // Si el tipo de dato es ENUM, reemplazar con VARCHAR
            if (tipoDato.StartsWith("enum"))
            {
                tipoDato = "VARCHAR(255)";
            }

            atributos.Add($"{columna} {tipoDato}");
        }

        describeReader.Close();

        // Concatenar los parámetros
        updateProcedure.AppendLine(string.Join(", ", atributos.Select(a => $"IN p_{a.Split(' ')[0]} {a.Split(' ')[1]}")));
        updateProcedure.AppendLine(")");
        updateProcedure.AppendLine("BEGIN");
        updateProcedure.AppendLine($"UPDATE {tabla} SET");

        // Lista de asignaciones de columnas
        updateProcedure.AppendLine(string.Join(", ", atributos.Select(a => $"{a.Split(' ')[0]} = p_{a.Split(' ')[0]}")));

        // Condición para la clave primaria
        updateProcedure.AppendLine($"WHERE ID = p_ID;");
        updateProcedure.AppendLine("END;");

        return updateProcedure.ToString();
    }

    private static string generateDeleteProcedure(MySqlConnection con, string tabla)
    {
        StringBuilder deleteProcedure = new StringBuilder();
        deleteProcedure.AppendLine($"DROP PROCEDURE IF EXISTS Delete_{tabla};");
        deleteProcedure.AppendLine($"CREATE PROCEDURE Delete_{tabla}(p_ID INT)");
        deleteProcedure.AppendLine("BEGIN");
        deleteProcedure.AppendLine($"DELETE FROM {tabla} WHERE ID = p_ID;");
        deleteProcedure.AppendLine("END;");

        return deleteProcedure.ToString();
    }

    private static string generateSelectProcedure(string tabla)
    {
        StringBuilder selectProcedure = new StringBuilder();
        selectProcedure.AppendLine($"DROP PROCEDURE IF EXISTS Select_{tabla};");
        selectProcedure.AppendLine($"CREATE PROCEDURE Select_{tabla}()");
        selectProcedure.AppendLine("BEGIN");
        selectProcedure.AppendLine($"SELECT * FROM {tabla};");
        selectProcedure.AppendLine("END;");

        return selectProcedure.ToString();
    }

    private static void executeScriptCRUD(string script, MySqlConnection con)
    {
        try
        {
            using (MySqlCommand cmd = new MySqlCommand(script, con))
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine("Script SQL ejecutado correctamente.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al ejecutar el script SQL: {ex.Message}");
        }
    }


    public static void dropAllProcedures()
    {
        using (MySqlConnection con = new MySqlConnection(connectionString))
        {
            con.Open();
            string obtenerProcedimientosQuery = "SELECT SPECIFIC_NAME FROM information_schema.ROUTINES WHERE ROUTINE_TYPE='PROCEDURE' AND ROUTINE_SCHEMA=DATABASE();";
            MySqlCommand obtenerProcedimientosCmd = new MySqlCommand(obtenerProcedimientosQuery, con);
            
            // Usar una lista para almacenar los nombres de los procedimientos
            List<string> procedimientos = new List<string>();
            using (MySqlDataReader procedimientosReader = obtenerProcedimientosCmd.ExecuteReader())
            {
                while (procedimientosReader.Read())
                {
                    procedimientos.Add(procedimientosReader["SPECIFIC_NAME"].ToString());
                }
            }

            Console.WriteLine("\n--ELIMINANDO EL CRUD--");

            // Eliminar cada procedimiento almacenado
            foreach (string nombreProcedimiento in procedimientos)
            {
                dropProcedure(nombreProcedimiento, con);
            }
        }
        Console.WriteLine("\n*Se han eliminado todos los procedimientos almacenados correctamente*");
    }

    private static void dropProcedure(string nombreProcedimiento, MySqlConnection con)
    {
        try
        {
            string dropProcedureQuery = $"DROP PROCEDURE IF EXISTS {nombreProcedimiento};";
            using (MySqlCommand cmd = new MySqlCommand(dropProcedureQuery, con))
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine($"Procedimiento almacenado {nombreProcedimiento} eliminado correctamente.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError al eliminar el procedimiento almacenado {nombreProcedimiento}: {ex.Message}");
        }
    }

//////////////////////////////////////////////////////////

    private static void GeneratePDF()
    {
        List<string> entidades = obtainEntities();
        if (entidades.Count == 0)
        {
            Console.WriteLine("\n*No se encontraron entidades disponibles para el reporte*\n");
            return;
        }

        Console.WriteLine("\n--Entidades disponibles--\n");
        for (int i = 0; i < entidades.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {entidades[i]}");
        }

        Console.Write("\nSelecciona el número de la entidad que deseas incluir en el reporte\n");
        if (!int.TryParse(Console.ReadLine(), out int seleccion) || seleccion < 1 || seleccion > entidades.Count)
        {
            Console.WriteLine("\n*Selección no válida*\n");
            return;
        }

        string entidadSeleccionada = entidades[seleccion - 1];
        List<Atribute> atributos = obtainAtributes(entidadSeleccionada);
        if (atributos.Count == 0)
        {
            Console.WriteLine($"*No se encontraron atributos para la entidad '{entidadSeleccionada}'*\n");
            return;
        }

        Console.WriteLine("\n*Atributos disponibles*\n");
        for (int i = 0; i < atributos.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {atributos[i].Nombre}");
        }

        Console.WriteLine("\n*Selecciona los números de los atributos que deseas incluir en el reporte, separados por comas*\n");
        string seleccionAtributos = Console.ReadLine();
        List<int> indicesAtributos = seleccionAtributos.Split(',').Select(s => int.Parse(s.Trim()) - 1).ToList();

        if (indicesAtributos.Any(i => i < 0 || i >= atributos.Count))
        {
            Console.WriteLine("\n*Una o más selecciones no son válidas*\n");
            return;
        }

        List<Atribute> atributosSeleccionados = indicesAtributos.Select(i => atributos[i]).ToList();
        List<Dictionary<string, string>> datosTabla = obtainDataEntities(entidadSeleccionada, atributosSeleccionados);
        if (datosTabla.Count == 0)
        {
            Console.WriteLine($"\n*No se encontraron datos para la entidad '{entidadSeleccionada}'*\n");
            return;
        }

        // Generar el PDF
        string rutaDirectorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string rutaArchivoPDF = $@"{rutaDirectorio}\Reporte_{entidadSeleccionada}.pdf";
        using (FileStream fs = new FileStream(rutaArchivoPDF, FileMode.Create, FileAccess.Write, FileShare.None))
        {
            Document doc = new Document(PageSize.A4, 25, 25, 30, 30);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();

            // Agregar título
            Font tituloFont = new Font(Font.FontFamily.HELVETICA, 18, Font.BOLD, BaseColor.BLUE);
            Paragraph titulo = new Paragraph($"Reporte de la entidad: {entidadSeleccionada}", tituloFont);
            titulo.Alignment = Element.ALIGN_CENTER;
            doc.Add(titulo);
            doc.Add(new Paragraph("\n"));

            // Agregar tabla con los datos de la entidad seleccionada
            PdfPTable table = new PdfPTable(atributosSeleccionados.Count);
            table.WidthPercentage = 100;
            table.SpacingBefore = 10;
            table.SpacingAfter = 10;

            // Encabezados de la tabla (nombres de las columnas)
            Font headerFont = new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD, BaseColor.WHITE);
            foreach (var Atribute in atributosSeleccionados)
            {
                PdfPCell headerCell = new PdfPCell(new Phrase(Atribute.Nombre, headerFont))
                {
                    BackgroundColor = BaseColor.GRAY,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    Padding = 5
                };
                table.AddCell(headerCell);
            }

            // Agregar los datos de la tabla
            Font dataFont = new Font(Font.FontFamily.HELVETICA, 10, Font.NORMAL, BaseColor.BLACK);
            foreach (var fila in datosTabla)
            {
                foreach (var Atribute in atributosSeleccionados)
                {
                    PdfPCell dataCell = new PdfPCell(new Phrase(fila[Atribute.Nombre], dataFont))
                    {
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        Padding = 5
                    };
                    table.AddCell(dataCell);
                }
            }

            doc.Add(table);
            doc.Close();
            writer.Close();
        }

        Console.WriteLine($"\n*Reporte generado con éxito: {rutaArchivoPDF}*\n");
        PrincipalMenu();
    }

    private static List<string> obtainEntities()
    {
        List<string> entidades = new List<string>();

        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT table_name FROM information_schema.tables WHERE table_schema = 'gestionRestaurante' AND table_type = 'BASE TABLE';";
            using (var command = new MySqlCommand(query, connection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    entidades.Add(reader["table_name"].ToString());
                }
            }
        }

        return entidades;
    }

    private static List<Atribute> obtainAtributes(string entidad)
    {
        List<Atribute> atributos = new List<Atribute>();

        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            string query = $"SELECT column_name, data_type FROM information_schema.columns WHERE table_name = '{entidad}'";
            using (var command = new MySqlCommand(query, connection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    atributos.Add(new Atribute
                    {
                        Nombre = reader["column_name"].ToString(),
                        Tipo = reader["data_type"].ToString()
                    });
                }
            }
        }

        return atributos;
    }

    private static List<Dictionary<string, string>> obtainDataEntities(string entidad, List<Atribute> atributosSeleccionados)
    {
        List<Dictionary<string, string>> datos = new List<Dictionary<string, string>>();

        string columnas = string.Join(", ", atributosSeleccionados.Select(a => a.Nombre));
        string query = $"SELECT {columnas} FROM {entidad}";

        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            using (var command = new MySqlCommand(query, connection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Dictionary<string, string> fila = new Dictionary<string, string>();
                    foreach (var Atribute in atributosSeleccionados)
                    {
                        fila[Atribute.Nombre] = reader[Atribute.Nombre].ToString();
                    }
                    datos.Add(fila);
                }
            }
        }

        return datos;
    }

    private class Atribute
    {
        public string Nombre { get; set; }
        public string Tipo { get; set; }
    }





}