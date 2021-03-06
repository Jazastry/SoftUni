USE [master]
GO

/****** Object:  Database [AtmDb]    Script Date: 15/3/2015 10:13:41 PM ******/
CREATE DATABASE [AtmDb]
GO

USE [AtmDb]
GO
/****** Object:  Table [dbo].[CardAccounts]    Script Date: 15/3/2015 10:13:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CardAccounts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CardNumber] [nchar](10) NOT NULL,
	[CardPIN] [nchar](4) NOT NULL,
	[CardCash] [money] NULL,
 CONSTRAINT [PK_CardAccounts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [master]
GO

ALTER DATABASE [AtmDb] SET  READ_WRITE 
GO

INSERT INTO AtmDb.dbo.CardAccounts
(
    AtmDb.dbo.CardAccounts.CardNumber,
    AtmDb.dbo.CardAccounts.CardPIN,
    AtmDb.dbo.CardAccounts.CardCash
)
VALUES
(
    N'1234', -- CardNumber - nchar
    N'1111', -- CardPIN - nchar
    5000 -- CardCash - money
);

INSERT INTO AtmDb.dbo.CardAccounts
(
    AtmDb.dbo.CardAccounts.CardNumber,
    AtmDb.dbo.CardAccounts.CardPIN,
    AtmDb.dbo.CardAccounts.CardCash
)
VALUES
(
    N'2345', -- CardNumber - nchar
    N'2222', -- CardPIN - nchar
    300 -- CardCash - money
);

INSERT INTO AtmDb.dbo.CardAccounts
(
    AtmDb.dbo.CardAccounts.CardNumber,
    AtmDb.dbo.CardAccounts.CardPIN,
    AtmDb.dbo.CardAccounts.CardCash
)
VALUES
(
    N'3456', -- CardNumber - nchar
    N'3333', -- CardPIN - nchar
    10 -- CardCash - money
);

INSERT INTO AtmDb.dbo.CardAccounts
(
    AtmDb.dbo.CardAccounts.CardNumber,
    AtmDb.dbo.CardAccounts.CardPIN,
    AtmDb.dbo.CardAccounts.CardCash
)
VALUES
(
    N'5678', -- CardNumber - nchar
    N'4444', -- CardPIN - nchar
    700 -- CardCash - money
);

INSERT INTO AtmDb.dbo.CardAccounts
(
    AtmDb.dbo.CardAccounts.CardNumber,
    AtmDb.dbo.CardAccounts.CardPIN,
    AtmDb.dbo.CardAccounts.CardCash
)
VALUES
(
    N'7891', -- CardNumber - nchar
    N'5555', -- CardPIN - nchar
    1098.77 -- CardCash - money
);

INSERT INTO AtmDb.dbo.CardAccounts
(
    AtmDb.dbo.CardAccounts.CardNumber,
    AtmDb.dbo.CardAccounts.CardPIN,
    AtmDb.dbo.CardAccounts.CardCash
)
VALUES
(
    N'8901', -- CardNumber - nchar
    N'6666', -- CardPIN - nchar
    450.03 -- CardCash - money
);
GO

CREATE TABLE [dbo].[TransactionHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CardNumber] [nchar](10) NOT NULL,
	[TransactionDate] [datetime] NOT NULL,
	[Amount] [money] NULL,
 CONSTRAINT [PK_TransactionHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO