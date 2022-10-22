USE [emilima]
GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_SSMA_SOURCE' , N'SCHEMA',N'emilima', N'TABLE',N'user_role', NULL,NULL))
EXEC sys.sp_dropextendedproperty @name=N'MS_SSMA_SOURCE' , @level0type=N'SCHEMA',@level0name=N'emilima', @level1type=N'TABLE',@level1name=N'user_role'
GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_SSMA_SOURCE' , N'SCHEMA',N'emilima', N'TABLE',N'user_position', NULL,NULL))
EXEC sys.sp_dropextendedproperty @name=N'MS_SSMA_SOURCE' , @level0type=N'SCHEMA',@level0name=N'emilima', @level1type=N'TABLE',@level1name=N'user_position'
GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_SSMA_SOURCE' , N'SCHEMA',N'emilima', N'TABLE',N'user', NULL,NULL))
EXEC sys.sp_dropextendedproperty @name=N'MS_SSMA_SOURCE' , @level0type=N'SCHEMA',@level0name=N'emilima', @level1type=N'TABLE',@level1name=N'user'
GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_SSMA_SOURCE' , N'SCHEMA',N'emilima', N'TABLE',N'request_state', NULL,NULL))
EXEC sys.sp_dropextendedproperty @name=N'MS_SSMA_SOURCE' , @level0type=N'SCHEMA',@level0name=N'emilima', @level1type=N'TABLE',@level1name=N'request_state'
GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_SSMA_SOURCE' , N'SCHEMA',N'emilima', N'TABLE',N'organic_unit', NULL,NULL))
EXEC sys.sp_dropextendedproperty @name=N'MS_SSMA_SOURCE' , @level0type=N'SCHEMA',@level0name=N'emilima', @level1type=N'TABLE',@level1name=N'organic_unit'
GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_SSMA_SOURCE' , N'SCHEMA',N'emilima', N'TABLE',N'hierarchical_dependency', NULL,NULL))
EXEC sys.sp_dropextendedproperty @name=N'MS_SSMA_SOURCE' , @level0type=N'SCHEMA',@level0name=N'emilima', @level1type=N'TABLE',@level1name=N'hierarchical_dependency'
GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_SSMA_SOURCE' , N'SCHEMA',N'emilima', N'TABLE',N'file', NULL,NULL))
EXEC sys.sp_dropextendedproperty @name=N'MS_SSMA_SOURCE' , @level0type=N'SCHEMA',@level0name=N'emilima', @level1type=N'TABLE',@level1name=N'file'
GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_SSMA_SOURCE' , N'SCHEMA',N'emilima', N'TABLE',N'documental_serie', NULL,NULL))
EXEC sys.sp_dropextendedproperty @name=N'MS_SSMA_SOURCE' , @level0type=N'SCHEMA',@level0name=N'emilima', @level1type=N'TABLE',@level1name=N'documental_serie'
GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_SSMA_SOURCE' , N'SCHEMA',N'emilima', N'TABLE',N'document_type', NULL,NULL))
EXEC sys.sp_dropextendedproperty @name=N'MS_SSMA_SOURCE' , @level0type=N'SCHEMA',@level0name=N'emilima', @level1type=N'TABLE',@level1name=N'document_type'
GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_SSMA_SOURCE' , N'SCHEMA',N'emilima', N'TABLE',N'document_request', NULL,NULL))
EXEC sys.sp_dropextendedproperty @name=N'MS_SSMA_SOURCE' , @level0type=N'SCHEMA',@level0name=N'emilima', @level1type=N'TABLE',@level1name=N'document_request'
GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_SSMA_SOURCE' , N'SCHEMA',N'emilima', N'TABLE',N'document', NULL,NULL))
EXEC sys.sp_dropextendedproperty @name=N'MS_SSMA_SOURCE' , @level0type=N'SCHEMA',@level0name=N'emilima', @level1type=N'TABLE',@level1name=N'document'
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[emilima].[user_position]') AND type in (N'U'))
ALTER TABLE [emilima].[user_position] DROP CONSTRAINT IF EXISTS [user_position$fk_user_position_organic_unit]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[emilima].[user_position]') AND type in (N'U'))
ALTER TABLE [emilima].[user_position] DROP CONSTRAINT IF EXISTS [user_position$fk_user_position_hierarchical_dependency]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[emilima].[user]') AND type in (N'U'))
ALTER TABLE [emilima].[user] DROP CONSTRAINT IF EXISTS [user$fk_user_user_role]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[emilima].[user]') AND type in (N'U'))
ALTER TABLE [emilima].[user] DROP CONSTRAINT IF EXISTS [user$fk_user_user_position]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[emilima].[user]') AND type in (N'U'))
ALTER TABLE [emilima].[user] DROP CONSTRAINT IF EXISTS [user$fk_user_file]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[emilima].[documental_serie]') AND type in (N'U'))
ALTER TABLE [emilima].[documental_serie] DROP CONSTRAINT IF EXISTS [documental_serie$fk_documental_serie_organic_unit]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[emilima].[documental_serie]') AND type in (N'U'))
ALTER TABLE [emilima].[documental_serie] DROP CONSTRAINT IF EXISTS [documental_serie$fk_documental_serie_hierarchical_dependency]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[emilima].[document_request]') AND type in (N'U'))
ALTER TABLE [emilima].[document_request] DROP CONSTRAINT IF EXISTS [document_request$fk_request_user]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[emilima].[document_request]') AND type in (N'U'))
ALTER TABLE [emilima].[document_request] DROP CONSTRAINT IF EXISTS [document_request$fk_request_request_state]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[emilima].[document_request]') AND type in (N'U'))
ALTER TABLE [emilima].[document_request] DROP CONSTRAINT IF EXISTS [document_request$fk_request_organic_unit]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[emilima].[document]') AND type in (N'U'))
ALTER TABLE [emilima].[document] DROP CONSTRAINT IF EXISTS [document$fk_document_file]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[emilima].[document]') AND type in (N'U'))
ALTER TABLE [emilima].[document] DROP CONSTRAINT IF EXISTS [document$fk_document_documental_serie]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[emilima].[document]') AND type in (N'U'))
ALTER TABLE [emilima].[document] DROP CONSTRAINT IF EXISTS [document$fk_document_document_type]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[emilima].[document]') AND type in (N'U'))
ALTER TABLE [emilima].[document] DROP CONSTRAINT IF EXISTS [document$fk_document_document_request]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[emilima].[user]') AND type in (N'U'))
ALTER TABLE [emilima].[user] DROP CONSTRAINT IF EXISTS [DF__user__photo_id__534D60F1]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[emilima].[documental_serie]') AND type in (N'U'))
ALTER TABLE [emilima].[documental_serie] DROP CONSTRAINT IF EXISTS [DF__documenta__phisi__52593CB8]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[emilima].[documental_serie]') AND type in (N'U'))
ALTER TABLE [emilima].[documental_serie] DROP CONSTRAINT IF EXISTS [DF__documenta__is_pu__5165187F]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[emilima].[document_request]') AND type in (N'U'))
ALTER TABLE [emilima].[document_request] DROP CONSTRAINT IF EXISTS [DF__document___creat__5070F446]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[emilima].[document]') AND type in (N'U'))
ALTER TABLE [emilima].[document] DROP CONSTRAINT IF EXISTS [DF__document__docume__4F7CD00D]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[emilima].[document]') AND type in (N'U'))
ALTER TABLE [emilima].[document] DROP CONSTRAINT IF EXISTS [DF__document__creati__4E88ABD4]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[emilima].[document]') AND type in (N'U'))
ALTER TABLE [emilima].[document] DROP CONSTRAINT IF EXISTS [DF__document__upload__4D94879B]
GO
/****** Object:  Table [emilima].[user_role]    Script Date: 10/22/2022 12:24:53 PM ******/
DROP TABLE IF EXISTS [emilima].[user_role]
GO
/****** Object:  Table [emilima].[user_position]    Script Date: 10/22/2022 12:24:53 PM ******/
DROP TABLE IF EXISTS [emilima].[user_position]
GO
/****** Object:  Table [emilima].[user]    Script Date: 10/22/2022 12:24:53 PM ******/
DROP TABLE IF EXISTS [emilima].[user]
GO
/****** Object:  Table [emilima].[request_state]    Script Date: 10/22/2022 12:24:53 PM ******/
DROP TABLE IF EXISTS [emilima].[request_state]
GO
/****** Object:  Table [emilima].[organic_unit]    Script Date: 10/22/2022 12:24:53 PM ******/
DROP TABLE IF EXISTS [emilima].[organic_unit]
GO
/****** Object:  Table [emilima].[hierarchical_dependency]    Script Date: 10/22/2022 12:24:53 PM ******/
DROP TABLE IF EXISTS [emilima].[hierarchical_dependency]
GO
/****** Object:  Table [emilima].[file]    Script Date: 10/22/2022 12:24:53 PM ******/
DROP TABLE IF EXISTS [emilima].[file]
GO
/****** Object:  Table [emilima].[documental_serie]    Script Date: 10/22/2022 12:24:53 PM ******/
DROP TABLE IF EXISTS [emilima].[documental_serie]
GO
/****** Object:  Table [emilima].[document_type]    Script Date: 10/22/2022 12:24:53 PM ******/
DROP TABLE IF EXISTS [emilima].[document_type]
GO
/****** Object:  Table [emilima].[document_request]    Script Date: 10/22/2022 12:24:53 PM ******/
DROP TABLE IF EXISTS [emilima].[document_request]
GO
/****** Object:  Table [emilima].[document]    Script Date: 10/22/2022 12:24:53 PM ******/
DROP TABLE IF EXISTS [emilima].[document]
GO
/****** Object:  Schema [emilima]    Script Date: 10/22/2022 12:24:53 PM ******/
DROP SCHEMA IF EXISTS [emilima]
GO
/****** Object:  Schema [emilima]    Script Date: 10/22/2022 12:24:53 PM ******/
CREATE SCHEMA [emilima]
GO
/****** Object:  Table [emilima].[document]    Script Date: 10/22/2022 12:24:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [emilima].[document](
	[serial_number] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](45) NOT NULL,
	[description] [nvarchar](max) NULL,
	[upload_date] [datetime2](0) NULL,
	[creation_date] [datetime2](0) NULL,
	[file_id] [nvarchar](48) NOT NULL,
	[document_type_id] [int] NOT NULL,
	[document_serie_id] [nchar](6) NOT NULL,
	[document_request_id] [int] NULL,
 CONSTRAINT [PK_document_serial_number] PRIMARY KEY CLUSTERED 
(
	[serial_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [document$name_UNIQUE] UNIQUE NONCLUSTERED 
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [emilima].[document_request]    Script Date: 10/22/2022 12:24:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [emilima].[document_request](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](45) NOT NULL,
	[description] [nvarchar](max) NOT NULL,
	[creation_date] [datetime2](0) NULL,
	[state_id] [int] NOT NULL,
	[user_id] [nvarchar](45) NOT NULL,
	[organic_unit_id] [int] NOT NULL,
 CONSTRAINT [PK_document_request_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [emilima].[document_type]    Script Date: 10/22/2022 12:24:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [emilima].[document_type](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](80) NOT NULL,
 CONSTRAINT [PK_document_type_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [emilima].[documental_serie]    Script Date: 10/22/2022 12:24:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [emilima].[documental_serie](
	[code] [nchar](6) NOT NULL,
	[name] [nvarchar](200) NOT NULL,
	[hierarchical_dependency_id] [int] NOT NULL,
	[organic_unit_id] [int] NOT NULL,
	[definition] [nvarchar](max) NOT NULL,
	[service_frequency] [nvarchar](45) NOT NULL,
	[normative_scope] [nvarchar](max) NOT NULL,
	[is_public] [binary](1) NULL,
	[phisical_features] [nvarchar](45) NULL,
	[documental_serie_value] [nchar](1) NOT NULL,
	[years_in_management_archive] [int] NOT NULL,
	[years_in_central_archive] [int] NOT NULL,
	[elaboration_date] [datetime2](0) NOT NULL,
 CONSTRAINT [PK_documental_serie_code] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [documental_serie$name_UNIQUE] UNIQUE NONCLUSTERED 
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [emilima].[file]    Script Date: 10/22/2022 12:24:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [emilima].[file](
	[id] [nvarchar](48) NOT NULL,
	[filename] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_file_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [emilima].[hierarchical_dependency]    Script Date: 10/22/2022 12:24:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [emilima].[hierarchical_dependency](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_hierarchical_dependency_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [hierarchical_dependency$name_UNIQUE] UNIQUE NONCLUSTERED 
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [emilima].[organic_unit]    Script Date: 10/22/2022 12:24:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [emilima].[organic_unit](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](80) NOT NULL,
 CONSTRAINT [PK_organic_unit_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [emilima].[request_state]    Script Date: 10/22/2022 12:24:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [emilima].[request_state](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](45) NOT NULL,
 CONSTRAINT [PK_request_state_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [request_state$name_UNIQUE] UNIQUE NONCLUSTERED 
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [emilima].[user]    Script Date: 10/22/2022 12:24:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [emilima].[user](
	[username] [nvarchar](45) NOT NULL,
	[password] [nvarchar](45) NOT NULL,
	[email] [nvarchar](100) NOT NULL,
	[role_id] [int] NOT NULL,
	[photo_id] [nvarchar](48) NOT NULL,
	[position_id] [int] NOT NULL,
 CONSTRAINT [PK_user_username] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [emilima].[user_position]    Script Date: 10/22/2022 12:24:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [emilima].[user_position](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](200) NOT NULL,
	[organic_unit_id] [int] NOT NULL,
	[hierarchical_dependency_id] [int] NOT NULL,
 CONSTRAINT [PK_user_position_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [user_position$name_UNIQUE] UNIQUE NONCLUSTERED 
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [emilima].[user_role]    Script Date: 10/22/2022 12:24:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [emilima].[user_role](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](45) NOT NULL,
	[description] [nvarchar](max) NULL,
 CONSTRAINT [PK_user_role_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [user_role$name_UNIQUE] UNIQUE NONCLUSTERED 
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [emilima].[document] ADD  DEFAULT (getdate()) FOR [upload_date]
GO
ALTER TABLE [emilima].[document] ADD  DEFAULT (getdate()) FOR [creation_date]
GO
ALTER TABLE [emilima].[document] ADD  DEFAULT (NULL) FOR [document_request_id]
GO
ALTER TABLE [emilima].[document_request] ADD  DEFAULT (getdate()) FOR [creation_date]
GO
ALTER TABLE [emilima].[documental_serie] ADD  DEFAULT (0x01) FOR [is_public]
GO
ALTER TABLE [emilima].[documental_serie] ADD  DEFAULT (N'ND') FOR [phisical_features]
GO
ALTER TABLE [emilima].[user] ADD  DEFAULT (N'c4042c2a-f106-11ec-8ea0-0242ac120002') FOR [photo_id]
GO
ALTER TABLE [emilima].[document]  WITH CHECK ADD  CONSTRAINT [document$fk_document_document_request] FOREIGN KEY([document_request_id])
REFERENCES [emilima].[document_request] ([id])
GO
ALTER TABLE [emilima].[document] CHECK CONSTRAINT [document$fk_document_document_request]
GO
ALTER TABLE [emilima].[document]  WITH CHECK ADD  CONSTRAINT [document$fk_document_document_type] FOREIGN KEY([document_type_id])
REFERENCES [emilima].[document_type] ([id])
GO
ALTER TABLE [emilima].[document] CHECK CONSTRAINT [document$fk_document_document_type]
GO
ALTER TABLE [emilima].[document]  WITH CHECK ADD  CONSTRAINT [document$fk_document_documental_serie] FOREIGN KEY([document_serie_id])
REFERENCES [emilima].[documental_serie] ([code])
GO
ALTER TABLE [emilima].[document] CHECK CONSTRAINT [document$fk_document_documental_serie]
GO
ALTER TABLE [emilima].[document]  WITH CHECK ADD  CONSTRAINT [document$fk_document_file] FOREIGN KEY([file_id])
REFERENCES [emilima].[file] ([id])
GO
ALTER TABLE [emilima].[document] CHECK CONSTRAINT [document$fk_document_file]
GO
ALTER TABLE [emilima].[document_request]  WITH CHECK ADD  CONSTRAINT [document_request$fk_request_organic_unit] FOREIGN KEY([organic_unit_id])
REFERENCES [emilima].[organic_unit] ([id])
GO
ALTER TABLE [emilima].[document_request] CHECK CONSTRAINT [document_request$fk_request_organic_unit]
GO
ALTER TABLE [emilima].[document_request]  WITH CHECK ADD  CONSTRAINT [document_request$fk_request_request_state] FOREIGN KEY([state_id])
REFERENCES [emilima].[request_state] ([id])
GO
ALTER TABLE [emilima].[document_request] CHECK CONSTRAINT [document_request$fk_request_request_state]
GO
ALTER TABLE [emilima].[document_request]  WITH CHECK ADD  CONSTRAINT [document_request$fk_request_user] FOREIGN KEY([user_id])
REFERENCES [emilima].[user] ([username])
GO
ALTER TABLE [emilima].[document_request] CHECK CONSTRAINT [document_request$fk_request_user]
GO
ALTER TABLE [emilima].[documental_serie]  WITH CHECK ADD  CONSTRAINT [documental_serie$fk_documental_serie_hierarchical_dependency] FOREIGN KEY([hierarchical_dependency_id])
REFERENCES [emilima].[hierarchical_dependency] ([id])
GO
ALTER TABLE [emilima].[documental_serie] CHECK CONSTRAINT [documental_serie$fk_documental_serie_hierarchical_dependency]
GO
ALTER TABLE [emilima].[documental_serie]  WITH CHECK ADD  CONSTRAINT [documental_serie$fk_documental_serie_organic_unit] FOREIGN KEY([organic_unit_id])
REFERENCES [emilima].[organic_unit] ([id])
GO
ALTER TABLE [emilima].[documental_serie] CHECK CONSTRAINT [documental_serie$fk_documental_serie_organic_unit]
GO
ALTER TABLE [emilima].[user]  WITH CHECK ADD  CONSTRAINT [user$fk_user_file] FOREIGN KEY([photo_id])
REFERENCES [emilima].[file] ([id])
GO
ALTER TABLE [emilima].[user] CHECK CONSTRAINT [user$fk_user_file]
GO
ALTER TABLE [emilima].[user]  WITH CHECK ADD  CONSTRAINT [user$fk_user_user_position] FOREIGN KEY([position_id])
REFERENCES [emilima].[user_position] ([id])
GO
ALTER TABLE [emilima].[user] CHECK CONSTRAINT [user$fk_user_user_position]
GO
ALTER TABLE [emilima].[user]  WITH CHECK ADD  CONSTRAINT [user$fk_user_user_role] FOREIGN KEY([role_id])
REFERENCES [emilima].[user_role] ([id])
GO
ALTER TABLE [emilima].[user] CHECK CONSTRAINT [user$fk_user_user_role]
GO
ALTER TABLE [emilima].[user_position]  WITH CHECK ADD  CONSTRAINT [user_position$fk_user_position_hierarchical_dependency] FOREIGN KEY([hierarchical_dependency_id])
REFERENCES [emilima].[hierarchical_dependency] ([id])
GO
ALTER TABLE [emilima].[user_position] CHECK CONSTRAINT [user_position$fk_user_position_hierarchical_dependency]
GO
ALTER TABLE [emilima].[user_position]  WITH CHECK ADD  CONSTRAINT [user_position$fk_user_position_organic_unit] FOREIGN KEY([organic_unit_id])
REFERENCES [emilima].[organic_unit] ([id])
GO
ALTER TABLE [emilima].[user_position] CHECK CONSTRAINT [user_position$fk_user_position_organic_unit]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'emilima.document' , @level0type=N'SCHEMA',@level0name=N'emilima', @level1type=N'TABLE',@level1name=N'document'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'emilima.document_request' , @level0type=N'SCHEMA',@level0name=N'emilima', @level1type=N'TABLE',@level1name=N'document_request'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'emilima.document_type' , @level0type=N'SCHEMA',@level0name=N'emilima', @level1type=N'TABLE',@level1name=N'document_type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'emilima.documental_serie' , @level0type=N'SCHEMA',@level0name=N'emilima', @level1type=N'TABLE',@level1name=N'documental_serie'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'emilima.file' , @level0type=N'SCHEMA',@level0name=N'emilima', @level1type=N'TABLE',@level1name=N'file'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'emilima.hierarchical_dependency' , @level0type=N'SCHEMA',@level0name=N'emilima', @level1type=N'TABLE',@level1name=N'hierarchical_dependency'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'emilima.organic_unit' , @level0type=N'SCHEMA',@level0name=N'emilima', @level1type=N'TABLE',@level1name=N'organic_unit'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'emilima.request_state' , @level0type=N'SCHEMA',@level0name=N'emilima', @level1type=N'TABLE',@level1name=N'request_state'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'emilima.`user`' , @level0type=N'SCHEMA',@level0name=N'emilima', @level1type=N'TABLE',@level1name=N'user'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'emilima.user_position' , @level0type=N'SCHEMA',@level0name=N'emilima', @level1type=N'TABLE',@level1name=N'user_position'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'emilima.user_role' , @level0type=N'SCHEMA',@level0name=N'emilima', @level1type=N'TABLE',@level1name=N'user_role'
GO
