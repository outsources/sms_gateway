USE [master]
GO
/****** Object:  Database [sms_gateway]    Script Date: 05/03/2014 20:19:10 ******/
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
/****** Object:  Table [dbo].[telcos]    Script Date: 05/03/2014 20:19:12 ******/
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
/****** Object:  Table [dbo].[support]    Script Date: 05/03/2014 20:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[support](
	[id] [int] NOT NULL,
	[sms_send_log_id] [int] NULL,
	[create_date] [datetime] NULL,
 CONSTRAINT [PK_support] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sms_send_log]    Script Date: 05/03/2014 20:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sms_send_log](
	[id] [int] NOT NULL,
	[sender_number] [int] NULL,
	[service_number] [int] NULL,
	[telcos] [varchar](50) NULL,
	[command_code] [varchar](50) NULL,
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
/****** Object:  Table [dbo].[sms_receive_log]    Script Date: 05/03/2014 20:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sms_receive_log](
	[id] [int] NOT NULL,
	[sender_number] [int] NULL,
	[service_number] [int] NULL,
	[telcos] [nvarchar](50) NULL,
	[command_code] [varchar](50) NULL,
	[sender_date] [datetime] NULL,
 CONSTRAINT [PK_sms_receive_log] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[service_rates]    Script Date: 05/03/2014 20:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[service_rates](
	[service_id] [int] NOT NULL,
	[telcos_id] [int] NOT NULL,
	[price] [float] NOT NULL,
 CONSTRAINT [PK_service_rates] PRIMARY KEY CLUSTERED 
(
	[service_id] ASC,
	[telcos_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[service_numbers]    Script Date: 05/03/2014 20:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[service_numbers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[service] [int] NOT NULL,
	[create_date] [datetime] NULL,
	[update_date] [datetime] NULL,
	[active] [date] NULL,
 CONSTRAINT [PK_service_numbers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[provider]    Script Date: 05/03/2014 20:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[provider](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[account_id] [int] NOT NULL,
	[provider_name] [nvarchar](50) NULL,
	[email] [varchar](50) NULL,
	[phone_number] [int] NULL,
	[tel] [int] NULL,
	[address] [varchar](50) NULL,
	[info] [nvarchar](500) NULL,
	[create_date] [datetime] NULL,
	[update_date] [datetime] NULL,
	[active] [bit] NULL,
 CONSTRAINT [PK_provider] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Quản lý thông tin nhà cung cấp nội dung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'provider'
GO
/****** Object:  Table [dbo].[messages]    Script Date: 05/03/2014 20:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[messages](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[command_code_id] [int] NULL,
	[msg_Content] [nvarchar](1000) NULL,
	[type] [varchar](20) NULL,
	[create_date] [datetime] NULL,
	[update_date] [datetime] NULL,
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
/****** Object:  Table [dbo].[events]    Script Date: 05/03/2014 20:19:12 ******/
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
/****** Object:  Table [dbo].[employee]    Script Date: 05/03/2014 20:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[employee](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[provider_id] [int] NOT NULL,
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
/****** Object:  Table [dbo].[counter]    Script Date: 05/03/2014 20:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[counter](
	[int] [int] NOT NULL,
	[total_mt] [int] NULL,
	[total_mo] [int] NULL,
	[total_cdr] [int] NULL,
	[datetime] [datetime] NULL,
 CONSTRAINT [PK_counter] PRIMARY KEY CLUSTERED 
(
	[int] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[command_code]    Script Date: 05/03/2014 20:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[command_code](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[provider_id] [int] NOT NULL,
	[events_id] [int] NOT NULL,
	[cmd_code] [varchar](20) NULL,
	[prefix] [varchar](50) NULL,
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
/****** Object:  Table [dbo].[cmd_telco_active]    Script Date: 05/03/2014 20:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cmd_telco_active](
	[command_code_id] [int] NOT NULL,
	[telcos_id] [int] NOT NULL,
	[active] [int] NULL,
 CONSTRAINT [PK_cmd_service_active] PRIMARY KEY CLUSTERED 
(
	[command_code_id] ASC,
	[telcos_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[account]    Script Date: 05/03/2014 20:19:12 ******/
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
