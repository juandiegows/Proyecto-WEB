# Prueba  Proyecto WEB para Digital Bankst

## 1) instalar la base de datos que esta en Proyecto-WEB/Servicio WCF/SQL Script/DBDigitalBankst.sql
<a id="raw-url" href="https://github.com/juandiegows/Proyecto-WEB/blob/dbf5875b88c8488ecc2855cb72b3a6bc3aacceeb/Servicio%20WCF/SQL%20Script/DBDigitalBankst.sql" download>Download FILE</a><br/>
![image](https://user-images.githubusercontent.com/65135568/225974625-f13558bb-be7a-42e7-b4e4-fad4b3feb1a6.png)

si necesita datos en la tabla usuario hay un archivo en Proyecto-WEB/Servicio WCF/SQL Script/DBDigitalBankst Data.sql
con 200 registros en bloques de 10, para realizar pruebas en caso que necesite muchos datos.

<a id="raw-url" href="https://github.com/juandiegows/Proyecto-WEB/blob/master/Servicio%20WCF/SQL%20Script/DBDigitalBankst%20Data.sql" download>Download FILE</a><br/>


## 2) Cambiar la cadena de conexion que esta en Proyecto-WEB/Servicio WCF/app.setting
![image](https://user-images.githubusercontent.com/65135568/225972978-2a04e112-4af2-47ed-8042-b00d64dee913.png)


colocar lo que necesita para conectarse a la base de datos que necesita.
la cadenad de conexion se asignar en el archivo Proyecto-WEB/Servicio WCF/Models/DBDigitalBankstContext.cs linea 28.

y listo, deberia funcionar con normalidad

# Explicacion de Proyecto

## Base de datos

![image](https://user-images.githubusercontent.com/65135568/225978733-a06fc96e-0459-4371-90d7-96c012cbc98e.png)

la tabla que era necesario crear con los tipos de datos que pideron y un Id para identificar el registro,
una tabla Sexo para limitar los caracteres que se puedan ingresa, ejemplo que solo puedan poner 'F' y 'M', y no 'X', 'Y' , 'G' , '6' '<' '"'
y ademas permite llenar el combo


## Proyectos

![image](https://user-images.githubusercontent.com/65135568/225979261-d8812911-6610-4f78-a1ce-fe43ec8bf18b.png)

dos capaz, uno se encarga de manejar los datos
y la otra de manejar las vista, tal y como lo pidieron

## Librerias y herramientas Utilizadas

* EntityFramework
* .Net Core 7
* swift alert 2
* JQuery
* Boostrap
