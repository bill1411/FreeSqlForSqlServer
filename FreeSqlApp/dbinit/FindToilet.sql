Create database FindToilet
go

USE [FindToilet]
GO
/****** Object:  Table [dbo].[T_City]    Script Date: 2020-04-06 22:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_City](
	[city_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NULL,
	[f_id] [int] NULL,
	[create_date] [datetime] NULL,
	[create_id] [int] NULL,
	[modify_date] [datetime] NULL,
	[modify_id] [int] NULL,
	[delete_flag] [int] NULL,
 CONSTRAINT [PK_T_CITY] PRIMARY KEY CLUSTERED 
(
	[city_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Content]    Script Date: 2020-04-06 22:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Content](
	[t_con_id] [int] IDENTITY(1,1) NOT NULL,
	[city_id] [int] NULL,
	[name] [nvarchar](100) NULL,
	[address] [nvarchar](200) NULL,
	[longitude] [float] NULL,
	[latitude] [float] NULL,
	[img] [nvarchar](100) NULL,
	[create_date] [datetime] NULL,
	[create_id] [int] NULL,
	[modify_date] [datetime] NULL,
	[modify_id] [int] NULL,
	[delete_flag] [int] NULL,
 CONSTRAINT [PK_T_CONTENT] PRIMARY KEY CLUSTERED 
(
	[t_con_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_User]    Script Date: 2020-04-06 22:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_User](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NULL,
	[create_date] [datetime] NULL,
	[create_id] [int] NULL,
	[modify_date] [datetime] NULL,
	[modify_id] [int] NULL,
	[delete_flag] [int] NULL,
 CONSTRAINT [PK_T_USER] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
