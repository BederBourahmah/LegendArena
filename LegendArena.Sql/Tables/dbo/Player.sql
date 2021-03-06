CREATE TABLE [dbo].[Player]
(
	[PlayerId] INT IDENTITY (-2147483648, 1),
	[Guid] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT [PK_dbo_Player] PRIMARY KEY CLUSTERED ([PlayerId]),
	CONSTRAINT [UC_dbo_Player_Guid] UNIQUE ([Guid])
)
