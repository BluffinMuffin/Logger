SET IDENTITY_INSERT [Control.GameTypes] ON 
INSERT [Control.GameTypes] ([Id], [Name], [Description]) VALUES (1, N'CommunityCardsPoker', N'Community Cards Poker (Hold''Em)')
INSERT [Control.GameTypes] ([Id], [Name], [Description]) VALUES (2, N'StudPoker', N'Stud Poker')
INSERT [Control.GameTypes] ([Id], [Name], [Description]) VALUES (3, N'DrawPoker', N'Draw Poker')
SET IDENTITY_INSERT [Control.GameTypes] OFF

SET IDENTITY_INSERT [Control.GameSubTypes] ON 
INSERT [Control.GameSubTypes] ([Id], [GameTypeId], [Name], [Description]) VALUES (1, 1, N'TexasHoldem', N'Texas Hold''em')
INSERT [Control.GameSubTypes] ([Id], [GameTypeId], [Name], [Description]) VALUES (2, 1, N'OmahaHoldem', N'Omaha Hold''em')
INSERT [Control.GameSubTypes] ([Id], [GameTypeId], [Name], [Description]) VALUES (3, 1, N'Pineapple', N'Pineapple')
INSERT [Control.GameSubTypes] ([Id], [GameTypeId], [Name], [Description]) VALUES (4, 1, N'CrazyPineapple', N'Crazy Pineapple')
INSERT [Control.GameSubTypes] ([Id], [GameTypeId], [Name], [Description]) VALUES (5, 1, N'LazyPineapple', N'Lazy Pineapple')
INSERT [Control.GameSubTypes] ([Id], [GameTypeId], [Name], [Description]) VALUES (6, 1, N'ThreeCardsHoldem', N'Three Cards Hold''em')
INSERT [Control.GameSubTypes] ([Id], [GameTypeId], [Name], [Description]) VALUES (7, 1, N'IrishPoker', N'Irish Poker')
INSERT [Control.GameSubTypes] ([Id], [GameTypeId], [Name], [Description]) VALUES (8, 1, N'SpanishPoker', N'Spanish Poker')
INSERT [Control.GameSubTypes] ([Id], [GameTypeId], [Name], [Description]) VALUES (9, 1, N'ManilaPoker', N'Manila Poker')
INSERT [Control.GameSubTypes] ([Id], [GameTypeId], [Name], [Description]) VALUES (10, 2, N'FiveCardsStud', N'Five Cards Stud')
INSERT [Control.GameSubTypes] ([Id], [GameTypeId], [Name], [Description]) VALUES (11, 2, N'SevenCardsStud', N'Seven Cards Stud')
INSERT [Control.GameSubTypes] ([Id], [GameTypeId], [Name], [Description]) VALUES (12, 3, N'FiveCardsDraw', N'Five Cards Draw')
SET IDENTITY_INSERT [Control.GameSubTypes] OFF

SET IDENTITY_INSERT [Control.BlindTypes] ON 
INSERT [Control.BlindTypes] ([Id], [Name], [Description]) VALUES (1, N'Blinds', N'Blinds')
INSERT [Control.BlindTypes] ([Id], [Name], [Description]) VALUES (2, N'Antes', N'Antes')
INSERT [Control.BlindTypes] ([Id], [Name], [Description]) VALUES (3, N'None', N'None')
SET IDENTITY_INSERT [Control.BlindTypes] OFF

SET IDENTITY_INSERT [Control.LimitTypes] ON 
INSERT [Control.LimitTypes] ([Id], [Name], [Description]) VALUES (1, N'NoLimit', N'No Limit')
INSERT [Control.LimitTypes] ([Id], [Name], [Description]) VALUES (2, N'FixedLimit', N'Fixed Limit')
INSERT [Control.LimitTypes] ([Id], [Name], [Description]) VALUES (3, N'PotLimit', N'Pot Limit')
SET IDENTITY_INSERT [Control.LimitTypes] OFF

SET IDENTITY_INSERT [Control.LobbyTypes] ON 
INSERT [Control.LobbyTypes] ([Id], [Name], [Description]) VALUES (1, N'QuickMode', N'Quick Mode')
INSERT [Control.LobbyTypes] ([Id], [Name], [Description]) VALUES (2, N'RegisteredMode', N'Registered Mode')
SET IDENTITY_INSERT [Control.LobbyTypes] OFF