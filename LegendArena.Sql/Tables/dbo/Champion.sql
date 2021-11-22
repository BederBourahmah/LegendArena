CREATE TABLE [dbo].[Champion]
(
	[ChampionId] INT IDENTITY (-2147483648, 1),
	[Name] VARCHAR(20) NOT NULL,
	[PlayerId] INT NOT NULL,
	CONSTRAINT [PK_dbo_Champion] PRIMARY KEY CLUSTERED ([ChampionId]),
	CONSTRAINT [UC_dbo_Champion_Name] UNIQUE ([Name]),
	CONSTRAINT [FK_dbo_Champion_PlayerId] FOREIGN KEY ([PlayerId]) REFERENCES [dbo].[Player] ([PlayerId])
)
