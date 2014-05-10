USE [master]
GO
/****** Object:  Database [sms_gateway]    Script Date: 05/08/2014 11:43:42 ******/
CREATE DATABASE [sms_gateway] ON  PRIMARY 
( NAME = N'sms_gateway', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\sms_gateway.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'sms_gateway_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\sms_gateway_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [sms_gateway] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [sms_gateway].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [sms_gateway] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [sms_gateway] SET ANSI_NULLS OFF
GO
ALTER DATABASE [sms_gateway] SET ANSI_PADDING OFF
GO
ALTER DATABASE [sms_gateway] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [sms_gateway] SET ARITHABORT OFF
GO
ALTER DATABASE [sms_gateway] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [sms_gateway] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [sms_gateway] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [sms_gateway] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [sms_gateway] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [sms_gateway] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [sms_gateway] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [sms_gateway] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [sms_gateway] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [sms_gateway] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [sms_gateway] SET  DISABLE_BROKER
GO
ALTER DATABASE [sms_gateway] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [sms_gateway] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [sms_gateway] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [sms_gateway] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [sms_gateway] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [sms_gateway] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [sms_gateway] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [sms_gateway] SET  READ_WRITE
GO
ALTER DATABASE [sms_gateway] SET RECOVERY SIMPLE
GO
ALTER DATABASE [sms_gateway] SET  MULTI_USER
GO
ALTER DATABASE [sms_gateway] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [sms_gateway] SET DB_CHAINING OFF
GO
USE [sms_gateway]
GO
/****** Object:  Table [dbo].[telcos]    Script Date: 05/08/2014 11:43:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[telcos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[telcos_name] [nvarchar](50) NOT NULL,
	[info] [nvarchar](550) NULL,
	[create_date] [datetime] NULL,
	[update_date] [datetime] NULL,
 CONSTRAINT [PK_telcos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[telcos] ON
INSERT [dbo].[telcos] ([id], [telcos_name], [info], [create_date], [update_date]) VALUES (1, N'VIETTEL', N'wwws', CAST(0x0000A32200000000 AS DateTime), CAST(0x0000A322008BCF68 AS DateTime))
INSERT [dbo].[telcos] ([id], [telcos_name], [info], [create_date], [update_date]) VALUES (2, N'VINAPHONE', N'xs', CAST(0x0000A32200000000 AS DateTime), CAST(0x0000A322008BE930 AS DateTime))
SET IDENTITY_INSERT [dbo].[telcos] OFF
/****** Object:  Table [dbo].[support]    Script Date: 05/08/2014 11:43:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[support](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[sms_send_log_id] [int] NULL,
	[active] [int] NULL,
	[create_date] [datetime] NULL,
 CONSTRAINT [PK_support] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sms_send_log]    Script Date: 05/08/2014 11:43:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sms_send_log](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[sender_number] [int] NULL,
	[service_number] [int] NULL,
	[telcos] [varchar](50) NULL,
	[cmd_id] [varchar](50) NULL,
	[messages_id] [int] NULL,
	[number_messages] [int] NULL,
	[messages_type] [bit] NULL,
	[create_date] [datetime] NULL,
 CONSTRAINT [PK_sms_send_log] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[sms_receive_log]    Script Date: 05/08/2014 11:43:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sms_receive_log](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[sender_number] [int] NULL,
	[service_number] [int] NULL,
	[telcos_id] [nvarchar](50) NULL,
	[cmd_id] [varchar](50) NULL,
	[status] [int] NULL,
	[create_date] [datetime] NULL,
 CONSTRAINT [PK_sms_receive_log] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[service_rates]    Script Date: 05/08/2014 11:43:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[service_rates](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[service_id] [int] NOT NULL,
	[telcos_id] [int] NOT NULL,
	[price] [float] NOT NULL,
 CONSTRAINT [PK_service_rates_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[service_rates] ON
INSERT [dbo].[service_rates] ([id], [service_id], [telcos_id], [price]) VALUES (2, 3, 1, 12222)
INSERT [dbo].[service_rates] ([id], [service_id], [telcos_id], [price]) VALUES (3, 3, 2, 13222)
SET IDENTITY_INSERT [dbo].[service_rates] OFF
/****** Object:  Table [dbo].[service_numbers]    Script Date: 05/08/2014 11:43:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[service_numbers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[service] [int] NOT NULL,
	[create_date] [datetime] NULL,
	[update_date] [datetime] NULL,
	[active] [bit] NULL,
 CONSTRAINT [PK_service_numbers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[service_numbers] ON
INSERT [dbo].[service_numbers] ([id], [service], [create_date], [update_date], [active]) VALUES (3, 7047, CAST(0x0000A321011826C0 AS DateTime), CAST(0x0000A32200000000 AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[service_numbers] OFF
/****** Object:  Table [dbo].[partner_service]    Script Date: 05/08/2014 11:43:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[partner_service](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[partner_id] [int] NULL,
	[server_number_id] [int] NULL,
	[price] [float] NULL,
 CONSTRAINT [PK_partner_service] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[partner]    Script Date: 05/08/2014 11:43:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[partner](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[account_id] [int] NOT NULL,
	[provider_name] [nvarchar](50) NULL,
	[email] [varchar](50) NULL,
	[phone_number] [int] NULL,
	[tel] [int] NULL,
	[info] [nvarchar](500) NULL,
	[create_date] [datetime] NULL,
	[update_date] [datetime] NULL,
 CONSTRAINT [PK_provider] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Quản lý thông tin nhà cung cấp nội dung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'partner'
GO
SET IDENTITY_INSERT [dbo].[partner] ON
INSERT [dbo].[partner] ([id], [account_id], [provider_name], [email], [phone_number], [tel], [info], [create_date], [update_date]) VALUES (1, 7, N'duy tung', N'ndtung1905@gmail.com', 98765321, 987432111, N'', CAST(0x0000A32200A32474 AS DateTime), CAST(0x0000A32200A32474 AS DateTime))
INSERT [dbo].[partner] ([id], [account_id], [provider_name], [email], [phone_number], [tel], [info], [create_date], [update_date]) VALUES (2, 8, N'5', N'ndtung1905@gmail.com', 666, 7777, N'', CAST(0x0000A322014027C4 AS DateTime), CAST(0x0000A322014027C4 AS DateTime))
SET IDENTITY_INSERT [dbo].[partner] OFF
/****** Object:  Table [dbo].[messages]    Script Date: 05/08/2014 11:43:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[messages](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cmd_id] [int] NULL,
	[msg_Content] [nvarchar](1000) NULL,
	[type] [varchar](20) NULL,
	[create_date] [datetime] NULL,
	[update_date] [datetime] NULL,
	[apply_date] [datetime] NULL,
	[active] [int] NULL,
 CONSTRAINT [PK_messages] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'`standby`,`return`' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'messages', @level2type=N'COLUMN',@level2name=N'type'
GO
/****** Object:  Table [dbo].[events]    Script Date: 05/08/2014 11:43:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[events](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[event_name] [nvarchar](50) NULL,
	[description] [nvarchar](500) NULL,
	[start_date] [datetime] NULL,
	[end_date] [datetime] NULL,
	[create_date] [datetime] NULL,
	[update_date] [datetime] NULL,
 CONSTRAINT [PK_event] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[employee]    Script Date: 05/08/2014 11:43:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[employee](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[partner_id] [int] NOT NULL,
	[account_id] [int] NOT NULL,
	[employee_name] [nvarchar](50) NULL,
	[email] [varchar](50) NULL,
	[phone] [varchar](30) NULL,
	[info] [varchar](500) NULL,
	[create_date] [datetime] NULL,
	[update_date] [datetime] NULL,
 CONSTRAINT [PK_employee] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'thông tin nhân viên' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'employee'
GO
/****** Object:  Table [dbo].[counter_partner]    Script Date: 05/08/2014 11:43:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[counter_partner](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[partner_id] [int] NULL,
	[telcos_id] [int] NULL,
	[service_number_id] [int] NULL,
	[total_mt] [int] NULL,
	[total_mo] [int] NULL,
	[total_cdr] [int] NULL,
	[create_date] [datetime] NULL,
 CONSTRAINT [PK_counter_partner] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[counter]    Script Date: 05/08/2014 11:43:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[counter](
	[int] [int] IDENTITY(1,1) NOT NULL,
	[telcos_id] [nchar](10) NULL,
	[service_number_id] [int] NULL,
	[total_mt] [int] NULL,
	[total_mo] [int] NULL,
	[total_cdr] [int] NULL,
	[create_date] [datetime] NULL,
 CONSTRAINT [PK_counter] PRIMARY KEY CLUSTERED 
(
	[int] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[command_code]    Script Date: 05/08/2014 11:43:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[command_code](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cmd_prefix_id] [int] NULL,
	[partner_id] [int] NOT NULL,
	[events_id] [int] NOT NULL,
	[service_number_id] [int] NULL,
	[cmd_code] [varchar](20) NULL,
	[info] [nvarchar](250) NULL,
	[create_date] [datetime] NULL,
	[update_date] [datetime] NULL,
	[active] [int] NOT NULL,
 CONSTRAINT [PK_command_code] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[cmd_telco_active]    Script Date: 05/08/2014 11:43:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cmd_telco_active](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cmd_id] [int] NOT NULL,
	[telcos_id] [int] NULL,
	[active] [int] NULL,
 CONSTRAINT [PK_cmd_telco_active] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cmd_prefix]    Script Date: 05/08/2014 11:43:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[cmd_prefix](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[prefix] [varchar](10) NULL,
	[create_date] [datetime] NULL,
	[update_date] [datetime] NULL,
	[active] [bit] NULL,
 CONSTRAINT [PK_cmd_prefix] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[cmd]    Script Date: 05/08/2014 11:43:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[cmd](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[command_code_id] [int] NULL,
	[cmd_prefix_id] [int] NULL,
	[cmd_name] [varchar](20) NULL,
	[active] [bit] NULL,
 CONSTRAINT [PK_cmd] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[account]    Script Date: 05/08/2014 11:43:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[account](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](40) NOT NULL,
	[password] [varchar](32) NOT NULL,
	[active] [bit] NULL,
	[role] [int] NULL,
 CONSTRAINT [PK_account] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'khóa chính' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'account', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'tài khoản đăng nhập vào hệ thống' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'account', @level2type=N'COLUMN',@level2name=N'username'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'mật khẩu truy nhập' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'account', @level2type=N'COLUMN',@level2name=N'password'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'trạng thái hoạt động hoặc khóa' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'account', @level2type=N'COLUMN',@level2name=N'active'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'phân quyền' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'account', @level2type=N'COLUMN',@level2name=N'role'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'mangement account' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'account'
GO
SET IDENTITY_INSERT [dbo].[account] ON
INSERT [dbo].[account] ([id], [username], [password], [active], [role]) VALUES (7, N'duytungnt92', N'1', 0, 2)
INSERT [dbo].[account] ([id], [username], [password], [active], [role]) VALUES (8, N'testttttttttt', N'1', 0, 2)
SET IDENTITY_INSERT [dbo].[account] OFF
