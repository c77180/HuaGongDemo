USE [HuaGongDB]
GO
/****** Object:  Table [dbo].[T_SysUsers]    Script Date: 11/15/2013 22:25:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_SysUsers](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Password] [nvarchar](250) NOT NULL,
	[RealName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_T_SysUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[T_SysUsers] ON
INSERT [dbo].[T_SysUsers] ([Id], [Name], [Password], [RealName]) VALUES (1, N'admin', N'123456', N'管理员')
INSERT [dbo].[T_SysUsers] ([Id], [Name], [Password], [RealName]) VALUES (2, N'yzk', N'56789', N'杨中科')
SET IDENTITY_INSERT [dbo].[T_SysUsers] OFF
/****** Object:  Table [dbo].[T_Settings]    Script Date: 11/15/2013 22:25:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Settings](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Value] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_T_Settings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[T_Settings] ON
INSERT [dbo].[T_Settings] ([Id], [Name], [Value]) VALUES (1, N'SiteName', N'中科牛叉软件公司')
INSERT [dbo].[T_Settings] ([Id], [Name], [Value]) VALUES (2, N'SiteURL', N'http://www.zhongke.com')
INSERT [dbo].[T_Settings] ([Id], [Name], [Value]) VALUES (3, N'Address', N'北京市海淀区知春路118号')
INSERT [dbo].[T_Settings] ([Id], [Name], [Value]) VALUES (4, N'PostCode', N'110110')
INSERT [dbo].[T_Settings] ([Id], [Name], [Value]) VALUES (5, N'ContactPerson', N'杨中科')
INSERT [dbo].[T_Settings] ([Id], [Name], [Value]) VALUES (6, N'TelPhone', N'010-8888888')
INSERT [dbo].[T_Settings] ([Id], [Name], [Value]) VALUES (7, N'Fax', N'918918918')
INSERT [dbo].[T_Settings] ([Id], [Name], [Value]) VALUES (9, N'Mobile', N'138888888')
INSERT [dbo].[T_Settings] ([Id], [Name], [Value]) VALUES (10, N'Email', N'yzk365@qq.com')
SET IDENTITY_INSERT [dbo].[T_Settings] OFF
/****** Object:  Table [dbo].[T_Products]    Script Date: 11/15/2013 22:25:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Products](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[ImagePath] [nvarchar](max) NOT NULL,
	[Msg] [nvarchar](max) NOT NULL,
	[CategoryId] [bigint] NOT NULL,
	[IsRecommend] [bit] NULL,
 CONSTRAINT [PK_T_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[T_Products] ON
INSERT [dbo].[T_Products] ([Id], [Name], [ImagePath], [Msg], [CategoryId], [IsRecommend]) VALUES (2, N'覆盆子酮', N'/uploadfile/20110611014993929392.jpg', N'覆盆子酮是一种牛逼的<span>化工</span>原料', 1, 1)
INSERT [dbo].[T_Products] ([Id], [Name], [ImagePath], [Msg], [CategoryId], [IsRecommend]) VALUES (4, N'氯霉素', N'/uploadfile/201311151619151083169.jpg', N'<p>
	氯霉素真<font color="green">绿</font>呀，你被绿了！</p>
', 2, NULL)
INSERT [dbo].[T_Products] ([Id], [Name], [ImagePath], [Msg], [CategoryId], [IsRecommend]) VALUES (5, N'利巴韦林(病毒唑）', N'/uploadfile/20110611022328652865.jpg', N'<p>
	美女<span style="background-color:#ff0000;">一个</span></p>
', 5, NULL)
INSERT [dbo].[T_Products] ([Id], [Name], [ImagePath], [Msg], [CategoryId], [IsRecommend]) VALUES (9, N'土霉素', N'/uploadfile/20110611021745864586.jpg', N'土霉素', 2, 0)
INSERT [dbo].[T_Products] ([Id], [Name], [ImagePath], [Msg], [CategoryId], [IsRecommend]) VALUES (11, N'盐酸特比奈芬', N'/uploadfile/20110611014993929392.jpg', N'盐酸特比奈芬', 3, NULL)
INSERT [dbo].[T_Products] ([Id], [Name], [ImagePath], [Msg], [CategoryId], [IsRecommend]) VALUES (12, N'氯化钾', N'/uploadfile/20110611032733583358.jpg', N'氯化钾', 3, NULL)
INSERT [dbo].[T_Products] ([Id], [Name], [ImagePath], [Msg], [CategoryId], [IsRecommend]) VALUES (14, N'磷酸二氢钾', N'/uploadfile/20110611032516391639.jpg', N'磷酸二氢钾', 5, 1)
INSERT [dbo].[T_Products] ([Id], [Name], [ImagePath], [Msg], [CategoryId], [IsRecommend]) VALUES (15, N'微晶纤维素', N'/uploadfile/20110611032067186718.jpg', N'微晶纤维素', 5, 1)
INSERT [dbo].[T_Products] ([Id], [Name], [ImagePath], [Msg], [CategoryId], [IsRecommend]) VALUES (16, N'氢化铝锂', N'/uploadfile/2011061103180984984.jpg', N'氢化铝锂', 3, NULL)
INSERT [dbo].[T_Products] ([Id], [Name], [ImagePath], [Msg], [CategoryId], [IsRecommend]) VALUES (17, N'淀粉酶', N'/uploadfile/2011061103170236236.jpg', N'淀粉酶', 1, NULL)
INSERT [dbo].[T_Products] ([Id], [Name], [ImagePath], [Msg], [CategoryId], [IsRecommend]) VALUES (19, N'抗氧剂BHT', N'/uploadfile/20110611031576567656.jpg', N'抗氧剂BHT', 1, 1)
INSERT [dbo].[T_Products] ([Id], [Name], [ImagePath], [Msg], [CategoryId], [IsRecommend]) VALUES (20, N'香兰素', N'/uploadfile/20110611031134093409.jpg', N'香兰素', 2, NULL)
INSERT [dbo].[T_Products] ([Id], [Name], [ImagePath], [Msg], [CategoryId], [IsRecommend]) VALUES (22, N'丁香罗勒油', N'/uploadfile/20110611031086798679.jpg', N'丁香罗勒油', 1, 1)
INSERT [dbo].[T_Products] ([Id], [Name], [ImagePath], [Msg], [CategoryId], [IsRecommend]) VALUES (23, N'聚乙烯醇', N'/uploadfile/20110611030589108910.jpg', N'聚乙烯醇', 1, NULL)
INSERT [dbo].[T_Products] ([Id], [Name], [ImagePath], [Msg], [CategoryId], [IsRecommend]) VALUES (24, N'次磷酸', N'/uploadfile/20110611025642914291.jpg', N'次磷酸', 2, 1)
INSERT [dbo].[T_Products] ([Id], [Name], [ImagePath], [Msg], [CategoryId], [IsRecommend]) VALUES (25, N'二铵', N'/uploadfile/201311151632272504018.jpg', N'<p>
	很好的肥料</p>
', 6, NULL)
INSERT [dbo].[T_Products] ([Id], [Name], [ImagePath], [Msg], [CategoryId], [IsRecommend]) VALUES (26, N'牛粪', N'/uploadfile/201311151632478544999.jpg', N'<p>
	营养丰富</p>
', 6, NULL)
INSERT [dbo].[T_Products] ([Id], [Name], [ImagePath], [Msg], [CategoryId], [IsRecommend]) VALUES (27, N'三聚氰胺', N'/uploadfile/201311151633053595096.jpg', N'<p>
	牛奶最佳伴侣</p>
', 4, NULL)
INSERT [dbo].[T_Products] ([Id], [Name], [ImagePath], [Msg], [CategoryId], [IsRecommend]) VALUES (28, N'一滴香', N'/uploadfile/201311151633303765326.jpg', N'<p>
	美味秘诀</p>
', 4, 1)
INSERT [dbo].[T_Products] ([Id], [Name], [ImagePath], [Msg], [CategoryId], [IsRecommend]) VALUES (29, N'杜冷丁', N'/uploadfile/201311151633480828908.jpg', N'<p>
	超级毒品</p>
', 1, NULL)
INSERT [dbo].[T_Products] ([Id], [Name], [ImagePath], [Msg], [CategoryId], [IsRecommend]) VALUES (30, N'硫酸', N'/uploadfile/201311151634089594387.jpg', N'<p>
	烧死你！</p>
', 2, NULL)
INSERT [dbo].[T_Products] ([Id], [Name], [ImagePath], [Msg], [CategoryId], [IsRecommend]) VALUES (31, N'二氧化碳', N'/uploadfile/201311151634284064701.jpg', N'<p>
	CO2</p>
', 2, NULL)
SET IDENTITY_INSERT [dbo].[T_Products] OFF
/****** Object:  Table [dbo].[T_ProductComments]    Script Date: 11/15/2013 22:25:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_ProductComments](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductId] [bigint] NOT NULL,
	[Title] [nvarchar](250) NOT NULL,
	[Msg] [nvarchar](max) NOT NULL,
	[CreateDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_T_ProductComments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[T_ProductComments] ON
INSERT [dbo].[T_ProductComments] ([Id], [ProductId], [Title], [Msg], [CreateDateTime]) VALUES (1, 2, N'我想卖100桶，能便宜吗？', N'我是江苏的买家！', CAST(0x0000A27701429151 AS DateTime))
INSERT [dbo].[T_ProductComments] ([Id], [ProductId], [Title], [Msg], [CreateDateTime]) VALUES (2, 2, N'反反复复', N'啊啊啊啊', CAST(0x0000A277014498F4 AS DateTime))
INSERT [dbo].[T_ProductComments] ([Id], [ProductId], [Title], [Msg], [CreateDateTime]) VALUES (3, 2, N'测试一下', N'测试一下测试一下测试一下测试一下', CAST(0x0000A2770144E6B0 AS DateTime))
INSERT [dbo].[T_ProductComments] ([Id], [ProductId], [Title], [Msg], [CreateDateTime]) VALUES (4, 2, N'3333', N'33333', CAST(0x0000A2770144EDAC AS DateTime))
INSERT [dbo].[T_ProductComments] ([Id], [ProductId], [Title], [Msg], [CreateDateTime]) VALUES (5, 2, N'不错的东西', N'免费送我吧', CAST(0x0000A27701450892 AS DateTime))
INSERT [dbo].[T_ProductComments] ([Id], [ProductId], [Title], [Msg], [CreateDateTime]) VALUES (6, 2, N'我黑你', N'<script type="text/javascript">alert("恭喜中奖，请拨打110110110");</script>', CAST(0x0000A27701462AC8 AS DateTime))
INSERT [dbo].[T_ProductComments] ([Id], [ProductId], [Title], [Msg], [CreateDateTime]) VALUES (7, 2, N'fffffff', N'fffffffffffffffffffffff', CAST(0x0000A277014778B6 AS DateTime))
SET IDENTITY_INSERT [dbo].[T_ProductComments] OFF
/****** Object:  Table [dbo].[T_ProductCategories]    Script Date: 11/15/2013 22:25:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_ProductCategories](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_T_ProductCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[T_ProductCategories] ON
INSERT [dbo].[T_ProductCategories] ([Id], [Name]) VALUES (1, N'医药原料及中间体')
INSERT [dbo].[T_ProductCategories] ([Id], [Name]) VALUES (2, N'无机化工产品')
INSERT [dbo].[T_ProductCategories] ([Id], [Name]) VALUES (3, N'香精香料及植物提取物')
INSERT [dbo].[T_ProductCategories] ([Id], [Name]) VALUES (4, N'食品化工产品')
INSERT [dbo].[T_ProductCategories] ([Id], [Name]) VALUES (5, N'有机化工产品')
INSERT [dbo].[T_ProductCategories] ([Id], [Name]) VALUES (6, N'农资化工产品')
INSERT [dbo].[T_ProductCategories] ([Id], [Name]) VALUES (8, N'塑料周边产品')
SET IDENTITY_INSERT [dbo].[T_ProductCategories] OFF
