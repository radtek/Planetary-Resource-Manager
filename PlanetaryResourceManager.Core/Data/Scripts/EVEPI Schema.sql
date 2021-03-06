ALTER TABLE [dbo].[Product] DROP CONSTRAINT [FK_Product_Item]
GO
ALTER TABLE [dbo].[Product] DROP CONSTRAINT [FK_Product_Input]
GO
ALTER TABLE [dbo].[Group] DROP CONSTRAINT [FK_Group_Category]
GO
ALTER TABLE [dbo].[Commodity] DROP CONSTRAINT [FK_Commodity_Group]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 16/09/2015 07:36:22 ******/
DROP TABLE [dbo].[Product]
GO
/****** Object:  Table [dbo].[Item]    Script Date: 16/09/2015 07:36:22 ******/
DROP TABLE [dbo].[Item]
GO
/****** Object:  Table [dbo].[Group]    Script Date: 16/09/2015 07:36:22 ******/
DROP TABLE [dbo].[Group]
GO
/****** Object:  Table [dbo].[Commodity]    Script Date: 16/09/2015 07:36:22 ******/
DROP TABLE [dbo].[Commodity]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 16/09/2015 07:36:22 ******/
DROP TABLE [dbo].[Category]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 16/09/2015 07:36:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[LastScanDate] [datetime] NULL,
	[TradeScore] [int] NOT NULL CONSTRAINT [DF_Category_TradeScore]  DEFAULT ((0)),
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Commodity]    Script Date: 16/09/2015 07:36:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Commodity](
	[Id] [int] NOT NULL,
	[GroupId] [int] NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Commodity] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Group]    Script Date: 16/09/2015 07:36:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Group](
	[Id] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Item]    Script Date: 16/09/2015 07:36:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Item](
	[ItemId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ProductionLevel] [int] NOT NULL,
 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 16/09/2015 07:36:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ItemId] [int] NOT NULL,
	[InputId] [int] NOT NULL,
	[InputLevel] [int] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC,
	[InputId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Commodity]  WITH CHECK ADD  CONSTRAINT [FK_Commodity_Group] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Group] ([Id])
GO
ALTER TABLE [dbo].[Commodity] CHECK CONSTRAINT [FK_Commodity_Group]
GO
ALTER TABLE [dbo].[Group]  WITH CHECK ADD  CONSTRAINT [FK_Group_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Group] CHECK CONSTRAINT [FK_Group_Category]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Input] FOREIGN KEY([InputId])
REFERENCES [dbo].[Item] ([ItemId])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Input]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Item] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item] ([ItemId])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Item]
GO
