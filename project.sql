USE [project]
GO
/****** Object:  Table [dbo].[Announcement]    Script Date: 5/3/2024 7:52:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Announcement](
	[Announcements] [text] NOT NULL,
	[AnnouncDate] [varchar](50) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[customerOrder]    Script Date: 5/3/2024 7:52:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customerOrder](
	[orderID] [varchar](50) NOT NULL,
	[customerID] [varchar](50) NOT NULL,
	[customerName] [varchar](50) NOT NULL,
	[orderDate] [varchar](50) NOT NULL,
	[totalAmount] [int] NOT NULL,
 CONSTRAINT [PK_customerOrder] PRIMARY KEY CLUSTERED 
(
	[orderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Distributor]    Script Date: 5/3/2024 7:52:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Distributor](
	[distributorID] [varchar](50) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[contact] [int] NOT NULL,
	[address] [varchar](50) NOT NULL,
	[Area] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Distributor] PRIMARY KEY CLUSTERED 
(
	[distributorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 5/3/2024 7:52:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[feedback] [text] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FreeCamp]    Script Date: 5/3/2024 7:52:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FreeCamp](
	[freeCampDate] [varchar](50) NOT NULL,
	[freeCampMsg] [text] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[items]    Script Date: 5/3/2024 7:52:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[items](
	[MedicineName] [varchar](50) NOT NULL,
	[orderID] [varchar](50) NOT NULL,
	[price] [varchar](50) NOT NULL,
	[quantity] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[medicine]    Script Date: 5/3/2024 7:52:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[medicine](
	[medicineName] [varchar](50) NOT NULL,
	[company] [varchar](50) NOT NULL,
	[Distributor] [varchar](50) NOT NULL,
	[Price] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[ExpDate] [varchar](50) NOT NULL,
 CONSTRAINT [PK_medicine] PRIMARY KEY CLUSTERED 
(
	[medicineName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

GO/****** Object:  Table [dbo].[returnedMedicines]    Script Date: 5/3/2024 7:52:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[returnedMedicines](
	[medicineName] [varchar](50) NOT NULL,
	[Distributor] [varchar](50) NOT NULL,
	[company] [varchar](50) NOT NULL,
	[Price] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[ExpDate] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 5/3/2024 7:52:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[role] [varchar](50) NOT NULL,
	[name] [varchar](50) NULL,
	[salary] [varchar](50) NULL,
	[dob] [varchar](50) NULL,
	[email] [varchar](50) NULL,
	[mobile] [varchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[items]  WITH CHECK ADD  CONSTRAINT [FK_items_customerOrder] FOREIGN KEY([orderID])
REFERENCES [dbo].[customerOrder] ([orderID])
GO
ALTER TABLE [dbo].[items] CHECK CONSTRAINT [FK_items_customerOrder]
GO
