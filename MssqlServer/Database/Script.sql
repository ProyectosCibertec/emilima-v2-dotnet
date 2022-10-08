
USE emilima
GO
 IF NOT EXISTS(SELECT * FROM sys.schemas WHERE [name] = N'db_accessadmin')      
     EXEC (N'CREATE SCHEMA db_accessadmin')                                   
 GO                                                               

USE emilima
GO
 IF NOT EXISTS(SELECT * FROM sys.schemas WHERE [name] = N'db_backupoperator')      
     EXEC (N'CREATE SCHEMA db_backupoperator')                                   
 GO                                                               

USE emilima
GO
 IF NOT EXISTS(SELECT * FROM sys.schemas WHERE [name] = N'db_datareader')      
     EXEC (N'CREATE SCHEMA db_datareader')                                   
 GO                                                               

USE emilima
GO
 IF NOT EXISTS(SELECT * FROM sys.schemas WHERE [name] = N'db_datawriter')      
     EXEC (N'CREATE SCHEMA db_datawriter')                                   
 GO                                                               

USE emilima
GO
 IF NOT EXISTS(SELECT * FROM sys.schemas WHERE [name] = N'db_ddladmin')      
     EXEC (N'CREATE SCHEMA db_ddladmin')                                   
 GO                                                               

USE emilima
GO
 IF NOT EXISTS(SELECT * FROM sys.schemas WHERE [name] = N'db_denydatareader')      
     EXEC (N'CREATE SCHEMA db_denydatareader')                                   
 GO                                                               

USE emilima
GO
 IF NOT EXISTS(SELECT * FROM sys.schemas WHERE [name] = N'db_denydatawriter')      
     EXEC (N'CREATE SCHEMA db_denydatawriter')                                   
 GO                                                               

USE emilima
GO
 IF NOT EXISTS(SELECT * FROM sys.schemas WHERE [name] = N'db_owner')      
     EXEC (N'CREATE SCHEMA db_owner')                                   
 GO                                                               

USE emilima
GO
 IF NOT EXISTS(SELECT * FROM sys.schemas WHERE [name] = N'db_securityadmin')      
     EXEC (N'CREATE SCHEMA db_securityadmin')                                   
 GO                                                               

USE emilima
GO
 IF NOT EXISTS(SELECT * FROM sys.schemas WHERE [name] = N'dbo')      
     EXEC (N'CREATE SCHEMA dbo')                                   
 GO                                                               

USE emilima
GO
 IF NOT EXISTS(SELECT * FROM sys.schemas WHERE [name] = N'emilima')      
     EXEC (N'CREATE SCHEMA emilima')                                   
 GO                                                               

USE emilima
GO
 IF NOT EXISTS(SELECT * FROM sys.schemas WHERE [name] = N'guest')      
     EXEC (N'CREATE SCHEMA guest')                                   
 GO                                                               

USE emilima
GO
 IF NOT EXISTS(SELECT * FROM sys.schemas WHERE [name] = N'INFORMATION_SCHEMA')      
     EXEC (N'CREATE SCHEMA INFORMATION_SCHEMA')                                   
 GO                                                               

USE emilima
GO
 IF NOT EXISTS(SELECT * FROM sys.schemas WHERE [name] = N'sys')      
     EXEC (N'CREATE SCHEMA sys')                                   
 GO                                                               

USE emilima
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'document'  AND sc.name = N'emilima'  AND type in (N'U'))
BEGIN

  DECLARE @drop_statement nvarchar(500)

  DECLARE drop_cursor CURSOR FOR
      SELECT 'alter table '+quotename(schema_name(ob.schema_id))+
      '.'+quotename(object_name(ob.object_id))+ ' drop constraint ' + quotename(fk.name) 
      FROM sys.objects ob INNER JOIN sys.foreign_keys fk ON fk.parent_object_id = ob.object_id
      WHERE fk.referenced_object_id = 
          (
             SELECT so.object_id 
             FROM sys.objects so JOIN sys.schemas sc
             ON so.schema_id = sc.schema_id
             WHERE so.name = N'document'  AND sc.name = N'emilima'  AND type in (N'U')
           )

  OPEN drop_cursor

  FETCH NEXT FROM drop_cursor
  INTO @drop_statement

  WHILE @@FETCH_STATUS = 0
  BEGIN
     EXEC (@drop_statement)

     FETCH NEXT FROM drop_cursor
     INTO @drop_statement
  END

  CLOSE drop_cursor
  DEALLOCATE drop_cursor

  DROP TABLE [emilima].[document]
END 
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE 
[emilima].[document]
(
   [serial_number] int IDENTITY(1, 1)  NOT NULL,
   [name] nvarchar(45)  NOT NULL,
   [description] nvarchar(max)  NULL,
   [upload_date] datetime2(0)  NULL,
   [creation_date] datetime2(0)  NULL,
   [file_id] nvarchar(48)  NOT NULL,
   [document_type_id] int  NOT NULL,
   [document_serie_id] nchar(6)  NOT NULL,
   [document_request_id] int  NULL
)
WITH (DATA_COMPRESSION = NONE)
GO
BEGIN TRY
    EXEC sp_addextendedproperty
        N'MS_SSMA_SOURCE', N'emilima.document',
        N'SCHEMA', N'emilima',
        N'TABLE', N'document'
END TRY
BEGIN CATCH
    IF (@@TRANCOUNT > 0) ROLLBACK
    PRINT ERROR_MESSAGE()
END CATCH
GO

USE emilima
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'document_request'  AND sc.name = N'emilima'  AND type in (N'U'))
BEGIN

  DECLARE @drop_statement nvarchar(500)

  DECLARE drop_cursor CURSOR FOR
      SELECT 'alter table '+quotename(schema_name(ob.schema_id))+
      '.'+quotename(object_name(ob.object_id))+ ' drop constraint ' + quotename(fk.name) 
      FROM sys.objects ob INNER JOIN sys.foreign_keys fk ON fk.parent_object_id = ob.object_id
      WHERE fk.referenced_object_id = 
          (
             SELECT so.object_id 
             FROM sys.objects so JOIN sys.schemas sc
             ON so.schema_id = sc.schema_id
             WHERE so.name = N'document_request'  AND sc.name = N'emilima'  AND type in (N'U')
           )

  OPEN drop_cursor

  FETCH NEXT FROM drop_cursor
  INTO @drop_statement

  WHILE @@FETCH_STATUS = 0
  BEGIN
     EXEC (@drop_statement)

     FETCH NEXT FROM drop_cursor
     INTO @drop_statement
  END

  CLOSE drop_cursor
  DEALLOCATE drop_cursor

  DROP TABLE [emilima].[document_request]
END 
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE 
[emilima].[document_request]
(
   [id] int IDENTITY(1, 1)  NOT NULL,
   [name] nvarchar(45)  NOT NULL,
   [description] nvarchar(max)  NOT NULL,
   [creation_date] datetime2(0)  NULL,
   [state_id] int  NOT NULL,
   [user_id] nvarchar(45)  NOT NULL,
   [organic_unit_id] int  NOT NULL
)
WITH (DATA_COMPRESSION = NONE)
GO
BEGIN TRY
    EXEC sp_addextendedproperty
        N'MS_SSMA_SOURCE', N'emilima.document_request',
        N'SCHEMA', N'emilima',
        N'TABLE', N'document_request'
END TRY
BEGIN CATCH
    IF (@@TRANCOUNT > 0) ROLLBACK
    PRINT ERROR_MESSAGE()
END CATCH
GO

USE emilima
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'document_type'  AND sc.name = N'emilima'  AND type in (N'U'))
BEGIN

  DECLARE @drop_statement nvarchar(500)

  DECLARE drop_cursor CURSOR FOR
      SELECT 'alter table '+quotename(schema_name(ob.schema_id))+
      '.'+quotename(object_name(ob.object_id))+ ' drop constraint ' + quotename(fk.name) 
      FROM sys.objects ob INNER JOIN sys.foreign_keys fk ON fk.parent_object_id = ob.object_id
      WHERE fk.referenced_object_id = 
          (
             SELECT so.object_id 
             FROM sys.objects so JOIN sys.schemas sc
             ON so.schema_id = sc.schema_id
             WHERE so.name = N'document_type'  AND sc.name = N'emilima'  AND type in (N'U')
           )

  OPEN drop_cursor

  FETCH NEXT FROM drop_cursor
  INTO @drop_statement

  WHILE @@FETCH_STATUS = 0
  BEGIN
     EXEC (@drop_statement)

     FETCH NEXT FROM drop_cursor
     INTO @drop_statement
  END

  CLOSE drop_cursor
  DEALLOCATE drop_cursor

  DROP TABLE [emilima].[document_type]
END 
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE 
[emilima].[document_type]
(
   [id] int  NOT NULL,
   [name] nvarchar(80)  NOT NULL
)
WITH (DATA_COMPRESSION = NONE)
GO
BEGIN TRY
    EXEC sp_addextendedproperty
        N'MS_SSMA_SOURCE', N'emilima.document_type',
        N'SCHEMA', N'emilima',
        N'TABLE', N'document_type'
END TRY
BEGIN CATCH
    IF (@@TRANCOUNT > 0) ROLLBACK
    PRINT ERROR_MESSAGE()
END CATCH
GO

USE emilima
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'documental_serie'  AND sc.name = N'emilima'  AND type in (N'U'))
BEGIN

  DECLARE @drop_statement nvarchar(500)

  DECLARE drop_cursor CURSOR FOR
      SELECT 'alter table '+quotename(schema_name(ob.schema_id))+
      '.'+quotename(object_name(ob.object_id))+ ' drop constraint ' + quotename(fk.name) 
      FROM sys.objects ob INNER JOIN sys.foreign_keys fk ON fk.parent_object_id = ob.object_id
      WHERE fk.referenced_object_id = 
          (
             SELECT so.object_id 
             FROM sys.objects so JOIN sys.schemas sc
             ON so.schema_id = sc.schema_id
             WHERE so.name = N'documental_serie'  AND sc.name = N'emilima'  AND type in (N'U')
           )

  OPEN drop_cursor

  FETCH NEXT FROM drop_cursor
  INTO @drop_statement

  WHILE @@FETCH_STATUS = 0
  BEGIN
     EXEC (@drop_statement)

     FETCH NEXT FROM drop_cursor
     INTO @drop_statement
  END

  CLOSE drop_cursor
  DEALLOCATE drop_cursor

  DROP TABLE [emilima].[documental_serie]
END 
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE 
[emilima].[documental_serie]
(
   [code] nchar(6)  NOT NULL,
   [name] nvarchar(200)  NOT NULL,
   [hierarchical_dependency_id] int  NOT NULL,
   [organic_unit_id] int  NOT NULL,
   [definition] nvarchar(max)  NOT NULL,
   [service_frequency] nvarchar(45)  NOT NULL,
   [normative_scope] nvarchar(max)  NOT NULL,

   /*
   *   SSMA informational messages:
   *   M2SS0052: BIT literal was converted to BINARY literal
   */

   [is_public] binary(1)  NULL,
   [phisical_features] nvarchar(45)  NULL,
   [documental_serie_value] nchar(1)  NOT NULL,
   [years_in_management_archive] int  NOT NULL,
   [years_in_central_archive] int  NOT NULL,
   [elaboration_date] datetime2(0)  NOT NULL
)
WITH (DATA_COMPRESSION = NONE)
GO
BEGIN TRY
    EXEC sp_addextendedproperty
        N'MS_SSMA_SOURCE', N'emilima.documental_serie',
        N'SCHEMA', N'emilima',
        N'TABLE', N'documental_serie'
END TRY
BEGIN CATCH
    IF (@@TRANCOUNT > 0) ROLLBACK
    PRINT ERROR_MESSAGE()
END CATCH
GO

USE emilima
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'file'  AND sc.name = N'emilima'  AND type in (N'U'))
BEGIN

  DECLARE @drop_statement nvarchar(500)

  DECLARE drop_cursor CURSOR FOR
      SELECT 'alter table '+quotename(schema_name(ob.schema_id))+
      '.'+quotename(object_name(ob.object_id))+ ' drop constraint ' + quotename(fk.name) 
      FROM sys.objects ob INNER JOIN sys.foreign_keys fk ON fk.parent_object_id = ob.object_id
      WHERE fk.referenced_object_id = 
          (
             SELECT so.object_id 
             FROM sys.objects so JOIN sys.schemas sc
             ON so.schema_id = sc.schema_id
             WHERE so.name = N'file'  AND sc.name = N'emilima'  AND type in (N'U')
           )

  OPEN drop_cursor

  FETCH NEXT FROM drop_cursor
  INTO @drop_statement

  WHILE @@FETCH_STATUS = 0
  BEGIN
     EXEC (@drop_statement)

     FETCH NEXT FROM drop_cursor
     INTO @drop_statement
  END

  CLOSE drop_cursor
  DEALLOCATE drop_cursor

  DROP TABLE [emilima].[file]
END 
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE 
[emilima].[file]
(
   [id] nvarchar(48)  NOT NULL,
   [filename] nvarchar(max)  NOT NULL
)
WITH (DATA_COMPRESSION = NONE)
GO
BEGIN TRY
    EXEC sp_addextendedproperty
        N'MS_SSMA_SOURCE', N'emilima.file',
        N'SCHEMA', N'emilima',
        N'TABLE', N'file'
END TRY
BEGIN CATCH
    IF (@@TRANCOUNT > 0) ROLLBACK
    PRINT ERROR_MESSAGE()
END CATCH
GO

USE emilima
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'hierarchical_dependency'  AND sc.name = N'emilima'  AND type in (N'U'))
BEGIN

  DECLARE @drop_statement nvarchar(500)

  DECLARE drop_cursor CURSOR FOR
      SELECT 'alter table '+quotename(schema_name(ob.schema_id))+
      '.'+quotename(object_name(ob.object_id))+ ' drop constraint ' + quotename(fk.name) 
      FROM sys.objects ob INNER JOIN sys.foreign_keys fk ON fk.parent_object_id = ob.object_id
      WHERE fk.referenced_object_id = 
          (
             SELECT so.object_id 
             FROM sys.objects so JOIN sys.schemas sc
             ON so.schema_id = sc.schema_id
             WHERE so.name = N'hierarchical_dependency'  AND sc.name = N'emilima'  AND type in (N'U')
           )

  OPEN drop_cursor

  FETCH NEXT FROM drop_cursor
  INTO @drop_statement

  WHILE @@FETCH_STATUS = 0
  BEGIN
     EXEC (@drop_statement)

     FETCH NEXT FROM drop_cursor
     INTO @drop_statement
  END

  CLOSE drop_cursor
  DEALLOCATE drop_cursor

  DROP TABLE [emilima].[hierarchical_dependency]
END 
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE 
[emilima].[hierarchical_dependency]
(
   [id] int  NOT NULL,
   [name] nvarchar(200)  NOT NULL
)
WITH (DATA_COMPRESSION = NONE)
GO
BEGIN TRY
    EXEC sp_addextendedproperty
        N'MS_SSMA_SOURCE', N'emilima.hierarchical_dependency',
        N'SCHEMA', N'emilima',
        N'TABLE', N'hierarchical_dependency'
END TRY
BEGIN CATCH
    IF (@@TRANCOUNT > 0) ROLLBACK
    PRINT ERROR_MESSAGE()
END CATCH
GO

USE emilima
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'organic_unit'  AND sc.name = N'emilima'  AND type in (N'U'))
BEGIN

  DECLARE @drop_statement nvarchar(500)

  DECLARE drop_cursor CURSOR FOR
      SELECT 'alter table '+quotename(schema_name(ob.schema_id))+
      '.'+quotename(object_name(ob.object_id))+ ' drop constraint ' + quotename(fk.name) 
      FROM sys.objects ob INNER JOIN sys.foreign_keys fk ON fk.parent_object_id = ob.object_id
      WHERE fk.referenced_object_id = 
          (
             SELECT so.object_id 
             FROM sys.objects so JOIN sys.schemas sc
             ON so.schema_id = sc.schema_id
             WHERE so.name = N'organic_unit'  AND sc.name = N'emilima'  AND type in (N'U')
           )

  OPEN drop_cursor

  FETCH NEXT FROM drop_cursor
  INTO @drop_statement

  WHILE @@FETCH_STATUS = 0
  BEGIN
     EXEC (@drop_statement)

     FETCH NEXT FROM drop_cursor
     INTO @drop_statement
  END

  CLOSE drop_cursor
  DEALLOCATE drop_cursor

  DROP TABLE [emilima].[organic_unit]
END 
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE 
[emilima].[organic_unit]
(
   [id] int IDENTITY(1, 1)  NOT NULL,
   [name] nvarchar(80)  NOT NULL
)
WITH (DATA_COMPRESSION = NONE)
GO
BEGIN TRY
    EXEC sp_addextendedproperty
        N'MS_SSMA_SOURCE', N'emilima.organic_unit',
        N'SCHEMA', N'emilima',
        N'TABLE', N'organic_unit'
END TRY
BEGIN CATCH
    IF (@@TRANCOUNT > 0) ROLLBACK
    PRINT ERROR_MESSAGE()
END CATCH
GO

USE emilima
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'request_state'  AND sc.name = N'emilima'  AND type in (N'U'))
BEGIN

  DECLARE @drop_statement nvarchar(500)

  DECLARE drop_cursor CURSOR FOR
      SELECT 'alter table '+quotename(schema_name(ob.schema_id))+
      '.'+quotename(object_name(ob.object_id))+ ' drop constraint ' + quotename(fk.name) 
      FROM sys.objects ob INNER JOIN sys.foreign_keys fk ON fk.parent_object_id = ob.object_id
      WHERE fk.referenced_object_id = 
          (
             SELECT so.object_id 
             FROM sys.objects so JOIN sys.schemas sc
             ON so.schema_id = sc.schema_id
             WHERE so.name = N'request_state'  AND sc.name = N'emilima'  AND type in (N'U')
           )

  OPEN drop_cursor

  FETCH NEXT FROM drop_cursor
  INTO @drop_statement

  WHILE @@FETCH_STATUS = 0
  BEGIN
     EXEC (@drop_statement)

     FETCH NEXT FROM drop_cursor
     INTO @drop_statement
  END

  CLOSE drop_cursor
  DEALLOCATE drop_cursor

  DROP TABLE [emilima].[request_state]
END 
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE 
[emilima].[request_state]
(
   [id] int IDENTITY(1, 1)  NOT NULL,
   [name] nvarchar(45)  NOT NULL
)
WITH (DATA_COMPRESSION = NONE)
GO
BEGIN TRY
    EXEC sp_addextendedproperty
        N'MS_SSMA_SOURCE', N'emilima.request_state',
        N'SCHEMA', N'emilima',
        N'TABLE', N'request_state'
END TRY
BEGIN CATCH
    IF (@@TRANCOUNT > 0) ROLLBACK
    PRINT ERROR_MESSAGE()
END CATCH
GO

USE emilima
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'User'  AND sc.name = N'dbo'  AND type in (N'U'))
BEGIN

  DECLARE @drop_statement nvarchar(500)

  DECLARE drop_cursor CURSOR FOR
      SELECT 'alter table '+quotename(schema_name(ob.schema_id))+
      '.'+quotename(object_name(ob.object_id))+ ' drop constraint ' + quotename(fk.name) 
      FROM sys.objects ob INNER JOIN sys.foreign_keys fk ON fk.parent_object_id = ob.object_id
      WHERE fk.referenced_object_id = 
          (
             SELECT so.object_id 
             FROM sys.objects so JOIN sys.schemas sc
             ON so.schema_id = sc.schema_id
             WHERE so.name = N'User'  AND sc.name = N'dbo'  AND type in (N'U')
           )

  OPEN drop_cursor

  FETCH NEXT FROM drop_cursor
  INTO @drop_statement

  WHILE @@FETCH_STATUS = 0
  BEGIN
     EXEC (@drop_statement)

     FETCH NEXT FROM drop_cursor
     INTO @drop_statement
  END

  CLOSE drop_cursor
  DEALLOCATE drop_cursor

  DROP TABLE [dbo].[User]
END 
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE 
[dbo].[User]
(
   [Username] nchar(45)  NOT NULL,
   [Password] nchar(45)  NOT NULL,
   [Email] nvarchar(10)  NOT NULL,
   [RoleId] int  NOT NULL,
   [PhotoId] nchar(45)  NOT NULL,
   [PositionId] int  NOT NULL
)
WITH (DATA_COMPRESSION = NONE)
GO
GO

USE emilima
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'user'  AND sc.name = N'emilima'  AND type in (N'U'))
BEGIN

  DECLARE @drop_statement nvarchar(500)

  DECLARE drop_cursor CURSOR FOR
      SELECT 'alter table '+quotename(schema_name(ob.schema_id))+
      '.'+quotename(object_name(ob.object_id))+ ' drop constraint ' + quotename(fk.name) 
      FROM sys.objects ob INNER JOIN sys.foreign_keys fk ON fk.parent_object_id = ob.object_id
      WHERE fk.referenced_object_id = 
          (
             SELECT so.object_id 
             FROM sys.objects so JOIN sys.schemas sc
             ON so.schema_id = sc.schema_id
             WHERE so.name = N'user'  AND sc.name = N'emilima'  AND type in (N'U')
           )

  OPEN drop_cursor

  FETCH NEXT FROM drop_cursor
  INTO @drop_statement

  WHILE @@FETCH_STATUS = 0
  BEGIN
     EXEC (@drop_statement)

     FETCH NEXT FROM drop_cursor
     INTO @drop_statement
  END

  CLOSE drop_cursor
  DEALLOCATE drop_cursor

  DROP TABLE [emilima].[user]
END 
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE 
[emilima].[user]
(
   [username] nvarchar(45)  NOT NULL,
   [password] nvarchar(45)  NOT NULL,
   [email] nvarchar(100)  NOT NULL,
   [role_id] int  NOT NULL,
   [photo_id] nvarchar(48)  NOT NULL,
   [position_id] int  NOT NULL
)
WITH (DATA_COMPRESSION = NONE)
GO
BEGIN TRY
    EXEC sp_addextendedproperty
        N'MS_SSMA_SOURCE', N'emilima.`user`',
        N'SCHEMA', N'emilima',
        N'TABLE', N'user'
END TRY
BEGIN CATCH
    IF (@@TRANCOUNT > 0) ROLLBACK
    PRINT ERROR_MESSAGE()
END CATCH
GO

USE emilima
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'user_position'  AND sc.name = N'emilima'  AND type in (N'U'))
BEGIN

  DECLARE @drop_statement nvarchar(500)

  DECLARE drop_cursor CURSOR FOR
      SELECT 'alter table '+quotename(schema_name(ob.schema_id))+
      '.'+quotename(object_name(ob.object_id))+ ' drop constraint ' + quotename(fk.name) 
      FROM sys.objects ob INNER JOIN sys.foreign_keys fk ON fk.parent_object_id = ob.object_id
      WHERE fk.referenced_object_id = 
          (
             SELECT so.object_id 
             FROM sys.objects so JOIN sys.schemas sc
             ON so.schema_id = sc.schema_id
             WHERE so.name = N'user_position'  AND sc.name = N'emilima'  AND type in (N'U')
           )

  OPEN drop_cursor

  FETCH NEXT FROM drop_cursor
  INTO @drop_statement

  WHILE @@FETCH_STATUS = 0
  BEGIN
     EXEC (@drop_statement)

     FETCH NEXT FROM drop_cursor
     INTO @drop_statement
  END

  CLOSE drop_cursor
  DEALLOCATE drop_cursor

  DROP TABLE [emilima].[user_position]
END 
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE 
[emilima].[user_position]
(
   [id] int  NOT NULL,
   [name] nvarchar(200)  NOT NULL,
   [organic_unit_id] int  NOT NULL,
   [hierarchical_dependency_id] int  NOT NULL
)
WITH (DATA_COMPRESSION = NONE)
GO
BEGIN TRY
    EXEC sp_addextendedproperty
        N'MS_SSMA_SOURCE', N'emilima.user_position',
        N'SCHEMA', N'emilima',
        N'TABLE', N'user_position'
END TRY
BEGIN CATCH
    IF (@@TRANCOUNT > 0) ROLLBACK
    PRINT ERROR_MESSAGE()
END CATCH
GO

USE emilima
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'user_role'  AND sc.name = N'emilima'  AND type in (N'U'))
BEGIN

  DECLARE @drop_statement nvarchar(500)

  DECLARE drop_cursor CURSOR FOR
      SELECT 'alter table '+quotename(schema_name(ob.schema_id))+
      '.'+quotename(object_name(ob.object_id))+ ' drop constraint ' + quotename(fk.name) 
      FROM sys.objects ob INNER JOIN sys.foreign_keys fk ON fk.parent_object_id = ob.object_id
      WHERE fk.referenced_object_id = 
          (
             SELECT so.object_id 
             FROM sys.objects so JOIN sys.schemas sc
             ON so.schema_id = sc.schema_id
             WHERE so.name = N'user_role'  AND sc.name = N'emilima'  AND type in (N'U')
           )

  OPEN drop_cursor

  FETCH NEXT FROM drop_cursor
  INTO @drop_statement

  WHILE @@FETCH_STATUS = 0
  BEGIN
     EXEC (@drop_statement)

     FETCH NEXT FROM drop_cursor
     INTO @drop_statement
  END

  CLOSE drop_cursor
  DEALLOCATE drop_cursor

  DROP TABLE [emilima].[user_role]
END 
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE 
[emilima].[user_role]
(
   [id] int IDENTITY(1, 1)  NOT NULL,
   [name] nvarchar(45)  NOT NULL,
   [description] nvarchar(max)  NULL
)
WITH (DATA_COMPRESSION = NONE)
GO
BEGIN TRY
    EXEC sp_addextendedproperty
        N'MS_SSMA_SOURCE', N'emilima.user_role',
        N'SCHEMA', N'emilima',
        N'TABLE', N'user_role'
END TRY
BEGIN CATCH
    IF (@@TRANCOUNT > 0) ROLLBACK
    PRINT ERROR_MESSAGE()
END CATCH
GO

USE emilima
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'usuario'  AND sc.name = N'emilima'  AND type in (N'U'))
BEGIN

  DECLARE @drop_statement nvarchar(500)

  DECLARE drop_cursor CURSOR FOR
      SELECT 'alter table '+quotename(schema_name(ob.schema_id))+
      '.'+quotename(object_name(ob.object_id))+ ' drop constraint ' + quotename(fk.name) 
      FROM sys.objects ob INNER JOIN sys.foreign_keys fk ON fk.parent_object_id = ob.object_id
      WHERE fk.referenced_object_id = 
          (
             SELECT so.object_id 
             FROM sys.objects so JOIN sys.schemas sc
             ON so.schema_id = sc.schema_id
             WHERE so.name = N'usuario'  AND sc.name = N'emilima'  AND type in (N'U')
           )

  OPEN drop_cursor

  FETCH NEXT FROM drop_cursor
  INTO @drop_statement

  WHILE @@FETCH_STATUS = 0
  BEGIN
     EXEC (@drop_statement)

     FETCH NEXT FROM drop_cursor
     INTO @drop_statement
  END

  CLOSE drop_cursor
  DEALLOCATE drop_cursor

  DROP TABLE [emilima].[usuario]
END 
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE 
[emilima].[usuario]
(
   [id] int  NOT NULL
)
WITH (DATA_COMPRESSION = NONE)
GO
BEGIN TRY
    EXEC sp_addextendedproperty
        N'MS_SSMA_SOURCE', N'emilima.usuario',
        N'SCHEMA', N'emilima',
        N'TABLE', N'usuario'
END TRY
BEGIN CATCH
    IF (@@TRANCOUNT > 0) ROLLBACK
    PRINT ERROR_MESSAGE()
END CATCH
GO

USE emilima
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'PK_document_serial_number'  AND sc.name = N'emilima'  AND type in (N'PK'))
ALTER TABLE [emilima].[document] DROP CONSTRAINT [PK_document_serial_number]
 GO



ALTER TABLE [emilima].[document]
 ADD CONSTRAINT [PK_document_serial_number]
   PRIMARY KEY
   CLUSTERED ([serial_number] ASC)

GO


USE emilima
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'PK_document_request_id'  AND sc.name = N'emilima'  AND type in (N'PK'))
ALTER TABLE [emilima].[document_request] DROP CONSTRAINT [PK_document_request_id]
 GO



ALTER TABLE [emilima].[document_request]
 ADD CONSTRAINT [PK_document_request_id]
   PRIMARY KEY
   CLUSTERED ([id] ASC)

GO


USE emilima
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'PK_document_type_id'  AND sc.name = N'emilima'  AND type in (N'PK'))
ALTER TABLE [emilima].[document_type] DROP CONSTRAINT [PK_document_type_id]
 GO



ALTER TABLE [emilima].[document_type]
 ADD CONSTRAINT [PK_document_type_id]
   PRIMARY KEY
   CLUSTERED ([id] ASC)

GO


USE emilima
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'PK_documental_serie_code'  AND sc.name = N'emilima'  AND type in (N'PK'))
ALTER TABLE [emilima].[documental_serie] DROP CONSTRAINT [PK_documental_serie_code]
 GO



ALTER TABLE [emilima].[documental_serie]
 ADD CONSTRAINT [PK_documental_serie_code]
   PRIMARY KEY
   CLUSTERED ([code] ASC)

GO


USE emilima
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'PK_file_id'  AND sc.name = N'emilima'  AND type in (N'PK'))
ALTER TABLE [emilima].[file] DROP CONSTRAINT [PK_file_id]
 GO



ALTER TABLE [emilima].[file]
 ADD CONSTRAINT [PK_file_id]
   PRIMARY KEY
   CLUSTERED ([id] ASC)

GO


USE emilima
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'PK_hierarchical_dependency_id'  AND sc.name = N'emilima'  AND type in (N'PK'))
ALTER TABLE [emilima].[hierarchical_dependency] DROP CONSTRAINT [PK_hierarchical_dependency_id]
 GO



ALTER TABLE [emilima].[hierarchical_dependency]
 ADD CONSTRAINT [PK_hierarchical_dependency_id]
   PRIMARY KEY
   CLUSTERED ([id] ASC)

GO


USE emilima
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'PK_organic_unit_id'  AND sc.name = N'emilima'  AND type in (N'PK'))
ALTER TABLE [emilima].[organic_unit] DROP CONSTRAINT [PK_organic_unit_id]
 GO



ALTER TABLE [emilima].[organic_unit]
 ADD CONSTRAINT [PK_organic_unit_id]
   PRIMARY KEY
   CLUSTERED ([id] ASC)

GO


USE emilima
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'PK_request_state_id'  AND sc.name = N'emilima'  AND type in (N'PK'))
ALTER TABLE [emilima].[request_state] DROP CONSTRAINT [PK_request_state_id]
 GO



ALTER TABLE [emilima].[request_state]
 ADD CONSTRAINT [PK_request_state_id]
   PRIMARY KEY
   CLUSTERED ([id] ASC)

GO


USE emilima
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'PK_user_username'  AND sc.name = N'emilima'  AND type in (N'PK'))
ALTER TABLE [emilima].[user] DROP CONSTRAINT [PK_user_username]
 GO



ALTER TABLE [emilima].[user]
 ADD CONSTRAINT [PK_user_username]
   PRIMARY KEY
   CLUSTERED ([username] ASC)

GO


USE emilima
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'PK_user_position_id'  AND sc.name = N'emilima'  AND type in (N'PK'))
ALTER TABLE [emilima].[user_position] DROP CONSTRAINT [PK_user_position_id]
 GO



ALTER TABLE [emilima].[user_position]
 ADD CONSTRAINT [PK_user_position_id]
   PRIMARY KEY
   CLUSTERED ([id] ASC)

GO


USE emilima
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'PK_user_role_id'  AND sc.name = N'emilima'  AND type in (N'PK'))
ALTER TABLE [emilima].[user_role] DROP CONSTRAINT [PK_user_role_id]
 GO



ALTER TABLE [emilima].[user_role]
 ADD CONSTRAINT [PK_user_role_id]
   PRIMARY KEY
   CLUSTERED ([id] ASC)

GO


USE emilima
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'PK_usuario_id'  AND sc.name = N'emilima'  AND type in (N'PK'))
ALTER TABLE [emilima].[usuario] DROP CONSTRAINT [PK_usuario_id]
 GO



ALTER TABLE [emilima].[usuario]
 ADD CONSTRAINT [PK_usuario_id]
   PRIMARY KEY
   CLUSTERED ([id] ASC)

GO


USE emilima
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'document$name_UNIQUE'  AND sc.name = N'emilima'  AND type in (N'UQ'))
ALTER TABLE [emilima].[document] DROP CONSTRAINT [document$name_UNIQUE]
 GO



ALTER TABLE [emilima].[document]
 ADD CONSTRAINT [document$name_UNIQUE]
 UNIQUE 
   NONCLUSTERED ([name] ASC)

GO


USE emilima
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'documental_serie$name_UNIQUE'  AND sc.name = N'emilima'  AND type in (N'UQ'))
ALTER TABLE [emilima].[documental_serie] DROP CONSTRAINT [documental_serie$name_UNIQUE]
 GO



ALTER TABLE [emilima].[documental_serie]
 ADD CONSTRAINT [documental_serie$name_UNIQUE]
 UNIQUE 
   NONCLUSTERED ([name] ASC)

GO


USE emilima
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'hierarchical_dependency$name_UNIQUE'  AND sc.name = N'emilima'  AND type in (N'UQ'))
ALTER TABLE [emilima].[hierarchical_dependency] DROP CONSTRAINT [hierarchical_dependency$name_UNIQUE]
 GO



ALTER TABLE [emilima].[hierarchical_dependency]
 ADD CONSTRAINT [hierarchical_dependency$name_UNIQUE]
 UNIQUE 
   NONCLUSTERED ([name] ASC)

GO


USE emilima
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'request_state$name_UNIQUE'  AND sc.name = N'emilima'  AND type in (N'UQ'))
ALTER TABLE [emilima].[request_state] DROP CONSTRAINT [request_state$name_UNIQUE]
 GO



ALTER TABLE [emilima].[request_state]
 ADD CONSTRAINT [request_state$name_UNIQUE]
 UNIQUE 
   NONCLUSTERED ([name] ASC)

GO


USE emilima
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'user_position$name_UNIQUE'  AND sc.name = N'emilima'  AND type in (N'UQ'))
ALTER TABLE [emilima].[user_position] DROP CONSTRAINT [user_position$name_UNIQUE]
 GO



ALTER TABLE [emilima].[user_position]
 ADD CONSTRAINT [user_position$name_UNIQUE]
 UNIQUE 
   NONCLUSTERED ([name] ASC)

GO


USE emilima
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'user_role$name_UNIQUE'  AND sc.name = N'emilima'  AND type in (N'UQ'))
ALTER TABLE [emilima].[user_role] DROP CONSTRAINT [user_role$name_UNIQUE]
 GO



ALTER TABLE [emilima].[user_role]
 ADD CONSTRAINT [user_role$name_UNIQUE]
 UNIQUE 
   NONCLUSTERED ([name] ASC)

GO


USE emilima
GO
IF EXISTS (
       SELECT * FROM sys.objects  so JOIN sys.indexes si
       ON so.object_id = si.object_id
       JOIN sys.schemas sc
       ON so.schema_id = sc.schema_id
       WHERE so.name = N'documental_serie'  AND sc.name = N'emilima'  AND si.name = N'fk_documental_serie_hierarchical_dependency_idx' AND so.type in (N'U'))
   DROP INDEX [fk_documental_serie_hierarchical_dependency_idx] ON [emilima].[documental_serie] 
GO
CREATE NONCLUSTERED INDEX [fk_documental_serie_hierarchical_dependency_idx] ON [emilima].[documental_serie]
(
   [hierarchical_dependency_id] ASC
)
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY] 
GO
GO

USE emilima
GO
IF EXISTS (
       SELECT * FROM sys.objects  so JOIN sys.indexes si
       ON so.object_id = si.object_id
       JOIN sys.schemas sc
       ON so.schema_id = sc.schema_id
       WHERE so.name = N'documental_serie'  AND sc.name = N'emilima'  AND si.name = N'fk_documental_serie_organic_unit_idx' AND so.type in (N'U'))
   DROP INDEX [fk_documental_serie_organic_unit_idx] ON [emilima].[documental_serie] 
GO
CREATE NONCLUSTERED INDEX [fk_documental_serie_organic_unit_idx] ON [emilima].[documental_serie]
(
   [organic_unit_id] ASC
)
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY] 
GO
GO

USE emilima
GO
IF EXISTS (
       SELECT * FROM sys.objects  so JOIN sys.indexes si
       ON so.object_id = si.object_id
       JOIN sys.schemas sc
       ON so.schema_id = sc.schema_id
       WHERE so.name = N'document'  AND sc.name = N'emilima'  AND si.name = N'fk_documentation_document_request_idx' AND so.type in (N'U'))
   DROP INDEX [fk_documentation_document_request_idx] ON [emilima].[document] 
GO
CREATE NONCLUSTERED INDEX [fk_documentation_document_request_idx] ON [emilima].[document]
(
   [document_request_id] ASC
)
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY] 
GO
GO

USE emilima
GO
IF EXISTS (
       SELECT * FROM sys.objects  so JOIN sys.indexes si
       ON so.object_id = si.object_id
       JOIN sys.schemas sc
       ON so.schema_id = sc.schema_id
       WHERE so.name = N'document'  AND sc.name = N'emilima'  AND si.name = N'fk_documentation_documental_serie_idx' AND so.type in (N'U'))
   DROP INDEX [fk_documentation_documental_serie_idx] ON [emilima].[document] 
GO
CREATE NONCLUSTERED INDEX [fk_documentation_documental_serie_idx] ON [emilima].[document]
(
   [document_serie_id] ASC
)
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY] 
GO
GO

USE emilima
GO
IF EXISTS (
       SELECT * FROM sys.objects  so JOIN sys.indexes si
       ON so.object_id = si.object_id
       JOIN sys.schemas sc
       ON so.schema_id = sc.schema_id
       WHERE so.name = N'document'  AND sc.name = N'emilima'  AND si.name = N'fk_documentation_documentation_type_idx' AND so.type in (N'U'))
   DROP INDEX [fk_documentation_documentation_type_idx] ON [emilima].[document] 
GO
CREATE NONCLUSTERED INDEX [fk_documentation_documentation_type_idx] ON [emilima].[document]
(
   [document_type_id] ASC
)
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY] 
GO
GO

USE emilima
GO
IF EXISTS (
       SELECT * FROM sys.objects  so JOIN sys.indexes si
       ON so.object_id = si.object_id
       JOIN sys.schemas sc
       ON so.schema_id = sc.schema_id
       WHERE so.name = N'document'  AND sc.name = N'emilima'  AND si.name = N'fk_documentation_file1_idx' AND so.type in (N'U'))
   DROP INDEX [fk_documentation_file1_idx] ON [emilima].[document] 
GO
CREATE NONCLUSTERED INDEX [fk_documentation_file1_idx] ON [emilima].[document]
(
   [file_id] ASC
)
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY] 
GO
GO

USE emilima
GO
IF EXISTS (
       SELECT * FROM sys.objects  so JOIN sys.indexes si
       ON so.object_id = si.object_id
       JOIN sys.schemas sc
       ON so.schema_id = sc.schema_id
       WHERE so.name = N'document_request'  AND sc.name = N'emilima'  AND si.name = N'fk_request_organic_unit_idx' AND so.type in (N'U'))
   DROP INDEX [fk_request_organic_unit_idx] ON [emilima].[document_request] 
GO
CREATE NONCLUSTERED INDEX [fk_request_organic_unit_idx] ON [emilima].[document_request]
(
   [organic_unit_id] ASC
)
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY] 
GO
GO

USE emilima
GO
IF EXISTS (
       SELECT * FROM sys.objects  so JOIN sys.indexes si
       ON so.object_id = si.object_id
       JOIN sys.schemas sc
       ON so.schema_id = sc.schema_id
       WHERE so.name = N'document_request'  AND sc.name = N'emilima'  AND si.name = N'fk_request_request_state_idx' AND so.type in (N'U'))
   DROP INDEX [fk_request_request_state_idx] ON [emilima].[document_request] 
GO
CREATE NONCLUSTERED INDEX [fk_request_request_state_idx] ON [emilima].[document_request]
(
   [state_id] ASC
)
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY] 
GO
GO

USE emilima
GO
IF EXISTS (
       SELECT * FROM sys.objects  so JOIN sys.indexes si
       ON so.object_id = si.object_id
       JOIN sys.schemas sc
       ON so.schema_id = sc.schema_id
       WHERE so.name = N'user_position'  AND sc.name = N'emilima'  AND si.name = N'fk_user_position_hierarchical_dependency_idx' AND so.type in (N'U'))
   DROP INDEX [fk_user_position_hierarchical_dependency_idx] ON [emilima].[user_position] 
GO
CREATE NONCLUSTERED INDEX [fk_user_position_hierarchical_dependency_idx] ON [emilima].[user_position]
(
   [hierarchical_dependency_id] ASC
)
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY] 
GO
GO

USE emilima
GO
IF EXISTS (
       SELECT * FROM sys.objects  so JOIN sys.indexes si
       ON so.object_id = si.object_id
       JOIN sys.schemas sc
       ON so.schema_id = sc.schema_id
       WHERE so.name = N'user_position'  AND sc.name = N'emilima'  AND si.name = N'fk_user_position_organic_unit_idx' AND so.type in (N'U'))
   DROP INDEX [fk_user_position_organic_unit_idx] ON [emilima].[user_position] 
GO
CREATE NONCLUSTERED INDEX [fk_user_position_organic_unit_idx] ON [emilima].[user_position]
(
   [organic_unit_id] ASC
)
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY] 
GO
GO

USE emilima
GO
IF EXISTS (
       SELECT * FROM sys.objects  so JOIN sys.indexes si
       ON so.object_id = si.object_id
       JOIN sys.schemas sc
       ON so.schema_id = sc.schema_id
       WHERE so.name = N'user'  AND sc.name = N'emilima'  AND si.name = N'fk_user_user_position_idx' AND so.type in (N'U'))
   DROP INDEX [fk_user_user_position_idx] ON [emilima].[user] 
GO
CREATE NONCLUSTERED INDEX [fk_user_user_position_idx] ON [emilima].[user]
(
   [position_id] ASC
)
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY] 
GO
GO

USE emilima
GO
IF EXISTS (
       SELECT * FROM sys.objects  so JOIN sys.indexes si
       ON so.object_id = si.object_id
       JOIN sys.schemas sc
       ON so.schema_id = sc.schema_id
       WHERE so.name = N'user'  AND sc.name = N'emilima'  AND si.name = N'photo_idx' AND so.type in (N'U'))
   DROP INDEX [photo_idx] ON [emilima].[user] 
GO
CREATE NONCLUSTERED INDEX [photo_idx] ON [emilima].[user]
(
   [photo_id] ASC
)
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY] 
GO
GO

USE emilima
GO
IF EXISTS (
       SELECT * FROM sys.objects  so JOIN sys.indexes si
       ON so.object_id = si.object_id
       JOIN sys.schemas sc
       ON so.schema_id = sc.schema_id
       WHERE so.name = N'user'  AND sc.name = N'emilima'  AND si.name = N'role_idx' AND so.type in (N'U'))
   DROP INDEX [role_idx] ON [emilima].[user] 
GO
CREATE NONCLUSTERED INDEX [role_idx] ON [emilima].[user]
(
   [role_id] ASC
)
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY] 
GO
GO

USE emilima
GO
IF EXISTS (
       SELECT * FROM sys.objects  so JOIN sys.indexes si
       ON so.object_id = si.object_id
       JOIN sys.schemas sc
       ON so.schema_id = sc.schema_id
       WHERE so.name = N'document_request'  AND sc.name = N'emilima'  AND si.name = N'user_id_idx' AND so.type in (N'U'))
   DROP INDEX [user_id_idx] ON [emilima].[document_request] 
GO
CREATE NONCLUSTERED INDEX [user_id_idx] ON [emilima].[document_request]
(
   [user_id] ASC
)
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY] 
GO
GO

USE emilima
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'document$fk_document_document_request'  AND sc.name = N'emilima'  AND type in (N'F'))
ALTER TABLE [emilima].[document] DROP CONSTRAINT [document$fk_document_document_request]
 GO



ALTER TABLE [emilima].[document]
 ADD CONSTRAINT [document$fk_document_document_request]
 FOREIGN KEY 
   ([document_request_id])
 REFERENCES 
   [emilima].[emilima].[document_request]     ([id])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION

GO

IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'document$fk_document_document_type'  AND sc.name = N'emilima'  AND type in (N'F'))
ALTER TABLE [emilima].[document] DROP CONSTRAINT [document$fk_document_document_type]
 GO



ALTER TABLE [emilima].[document]
 ADD CONSTRAINT [document$fk_document_document_type]
 FOREIGN KEY 
   ([document_type_id])
 REFERENCES 
   [emilima].[emilima].[document_type]     ([id])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION

GO

IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'document$fk_document_documental_serie'  AND sc.name = N'emilima'  AND type in (N'F'))
ALTER TABLE [emilima].[document] DROP CONSTRAINT [document$fk_document_documental_serie]
 GO



ALTER TABLE [emilima].[document]
 ADD CONSTRAINT [document$fk_document_documental_serie]
 FOREIGN KEY 
   ([document_serie_id])
 REFERENCES 
   [emilima].[emilima].[documental_serie]     ([code])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION

GO

IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'document$fk_document_file'  AND sc.name = N'emilima'  AND type in (N'F'))
ALTER TABLE [emilima].[document] DROP CONSTRAINT [document$fk_document_file]
 GO



ALTER TABLE [emilima].[document]
 ADD CONSTRAINT [document$fk_document_file]
 FOREIGN KEY 
   ([file_id])
 REFERENCES 
   [emilima].[emilima].[file]     ([id])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION

GO


USE emilima
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'document_request$fk_request_organic_unit'  AND sc.name = N'emilima'  AND type in (N'F'))
ALTER TABLE [emilima].[document_request] DROP CONSTRAINT [document_request$fk_request_organic_unit]
 GO



ALTER TABLE [emilima].[document_request]
 ADD CONSTRAINT [document_request$fk_request_organic_unit]
 FOREIGN KEY 
   ([organic_unit_id])
 REFERENCES 
   [emilima].[emilima].[organic_unit]     ([id])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION

GO

IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'document_request$fk_request_request_state'  AND sc.name = N'emilima'  AND type in (N'F'))
ALTER TABLE [emilima].[document_request] DROP CONSTRAINT [document_request$fk_request_request_state]
 GO



ALTER TABLE [emilima].[document_request]
 ADD CONSTRAINT [document_request$fk_request_request_state]
 FOREIGN KEY 
   ([state_id])
 REFERENCES 
   [emilima].[emilima].[request_state]     ([id])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION

GO

IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'document_request$fk_request_user'  AND sc.name = N'emilima'  AND type in (N'F'))
ALTER TABLE [emilima].[document_request] DROP CONSTRAINT [document_request$fk_request_user]
 GO



ALTER TABLE [emilima].[document_request]
 ADD CONSTRAINT [document_request$fk_request_user]
 FOREIGN KEY 
   ([user_id])
 REFERENCES 
   [emilima].[emilima].[user]     ([username])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION

GO


USE emilima
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'documental_serie$fk_documental_serie_hierarchical_dependency'  AND sc.name = N'emilima'  AND type in (N'F'))
ALTER TABLE [emilima].[documental_serie] DROP CONSTRAINT [documental_serie$fk_documental_serie_hierarchical_dependency]
 GO



ALTER TABLE [emilima].[documental_serie]
 ADD CONSTRAINT [documental_serie$fk_documental_serie_hierarchical_dependency]
 FOREIGN KEY 
   ([hierarchical_dependency_id])
 REFERENCES 
   [emilima].[emilima].[hierarchical_dependency]     ([id])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION

GO

IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'documental_serie$fk_documental_serie_organic_unit'  AND sc.name = N'emilima'  AND type in (N'F'))
ALTER TABLE [emilima].[documental_serie] DROP CONSTRAINT [documental_serie$fk_documental_serie_organic_unit]
 GO



ALTER TABLE [emilima].[documental_serie]
 ADD CONSTRAINT [documental_serie$fk_documental_serie_organic_unit]
 FOREIGN KEY 
   ([organic_unit_id])
 REFERENCES 
   [emilima].[emilima].[organic_unit]     ([id])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION

GO


USE emilima
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'user$fk_user_file'  AND sc.name = N'emilima'  AND type in (N'F'))
ALTER TABLE [emilima].[user] DROP CONSTRAINT [user$fk_user_file]
 GO



ALTER TABLE [emilima].[user]
 ADD CONSTRAINT [user$fk_user_file]
 FOREIGN KEY 
   ([photo_id])
 REFERENCES 
   [emilima].[emilima].[file]     ([id])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION

GO

IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'user$fk_user_user_position'  AND sc.name = N'emilima'  AND type in (N'F'))
ALTER TABLE [emilima].[user] DROP CONSTRAINT [user$fk_user_user_position]
 GO



ALTER TABLE [emilima].[user]
 ADD CONSTRAINT [user$fk_user_user_position]
 FOREIGN KEY 
   ([position_id])
 REFERENCES 
   [emilima].[emilima].[user_position]     ([id])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION

GO

IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'user$fk_user_user_role'  AND sc.name = N'emilima'  AND type in (N'F'))
ALTER TABLE [emilima].[user] DROP CONSTRAINT [user$fk_user_user_role]
 GO



ALTER TABLE [emilima].[user]
 ADD CONSTRAINT [user$fk_user_user_role]
 FOREIGN KEY 
   ([role_id])
 REFERENCES 
   [emilima].[emilima].[user_role]     ([id])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION

GO


USE emilima
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'user_position$fk_user_position_hierarchical_dependency'  AND sc.name = N'emilima'  AND type in (N'F'))
ALTER TABLE [emilima].[user_position] DROP CONSTRAINT [user_position$fk_user_position_hierarchical_dependency]
 GO



ALTER TABLE [emilima].[user_position]
 ADD CONSTRAINT [user_position$fk_user_position_hierarchical_dependency]
 FOREIGN KEY 
   ([hierarchical_dependency_id])
 REFERENCES 
   [emilima].[emilima].[hierarchical_dependency]     ([id])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION

GO

IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'user_position$fk_user_position_organic_unit'  AND sc.name = N'emilima'  AND type in (N'F'))
ALTER TABLE [emilima].[user_position] DROP CONSTRAINT [user_position$fk_user_position_organic_unit]
 GO



ALTER TABLE [emilima].[user_position]
 ADD CONSTRAINT [user_position$fk_user_position_organic_unit]
 FOREIGN KEY 
   ([organic_unit_id])
 REFERENCES 
   [emilima].[emilima].[organic_unit]     ([id])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION

GO


USE emilima
GO
ALTER TABLE  [emilima].[document]
 ADD DEFAULT getdate() FOR [upload_date]
GO

ALTER TABLE  [emilima].[document]
 ADD DEFAULT getdate() FOR [creation_date]
GO

ALTER TABLE  [emilima].[document]
 ADD DEFAULT NULL FOR [document_request_id]
GO


USE emilima
GO
ALTER TABLE  [emilima].[document_request]
 ADD DEFAULT getdate() FOR [creation_date]
GO


USE emilima
GO
ALTER TABLE  [emilima].[documental_serie]
 ADD DEFAULT 0x1 FOR [is_public]
GO

ALTER TABLE  [emilima].[documental_serie]
 ADD DEFAULT N'ND' FOR [phisical_features]
GO


USE emilima
GO
ALTER TABLE  [emilima].[user]
 ADD DEFAULT N'c4042c2a-f106-11ec-8ea0-0242ac120002' FOR [photo_id]
GO

