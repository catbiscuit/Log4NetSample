简介：Log4Net日志插件的简单使用示例



一、Log4NetFile项目
项目说明：
使用Log4Net记录日志到文本文件

1、配置信息
配置信息均保存在log4net.config文件中

2、注册log4net配置信息
本例使用的是web项目。
注册配置信息有两种方式
(1)本例使用的Global.asax
protected void Application_Start(object sender, EventArgs e)
{
    //注册 log4net(或者在AssemblyInfo.cs中添加注册的方法)
    System.IO.FileInfo configFile = new System.IO.FileInfo(HttpContext.Current.Server.MapPath("log4net.config"));
    log4net.Config.XmlConfigurator.Configure(configFile);
}
(2)Properties-AssemblyInfo.cs
追加一句:
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]

3、使用：
(1)log4net.config文件使用的是root根配置
<!--根配置-->
<root>
    <!--日志级别:可选值: ERROR > WARN > INFO > DEBUG -->
    <level value="ERROR"/>
    <level value="WARN"/>
    <level value="INFO"/>
    <level value="DEBUG"/>
    <appender-ref ref="ErrorLog" />
    <appender-ref ref="WarnLog" />
    <appender-ref ref="InfoLog" />
    <appender-ref ref="DebugLog" />      
</root>
(2)在调用时使用Type获取ILog对象
public static ILog GetLogger(Type type);
示例:
//获取调用者的类属性
StackTrace trace = new StackTrace();
Type type = trace.GetFrame(1).GetMethod().ReflectedType;

log4net.ILog log = log4net.LogManager.GetLogger(type);
if (log.IsInfoEnabled)
{
    log.Info(message);
}

二、Log4NetOriginalSQL项目
项目说明：
使用Log4Net原版的数据库表进行日志的记录

可以配置日志记录的方式，下面的配置为:SqlServer和File两种方式都记录。
删除配置则不进行记录。
<appender-ref ref="AdoNetAppender_SqlServer" />
<appender-ref ref="InfoAppender" />

1、配置信息
配置信息均保存在log4net.config文件中

2、注册log4net配置信息
本例使用的是web项目。
注册配置信息有两种方式
(1)本例使用的Global.asax
protected void Application_Start(object sender, EventArgs e)
{
    //注册 log4net(或者在AssemblyInfo.cs中添加注册的方法)
    System.IO.FileInfo configFile = new System.IO.FileInfo(HttpContext.Current.Server.MapPath("log4net.config"));
    log4net.Config.XmlConfigurator.Configure(configFile);
}
(2)Properties-AssemblyInfo.cs
追加一句:
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]

3、使用
根据Log4Net.config中配置的不同获取ILog对象的方式也不同
(1)log4net.config文件使用的是root根配置
<!--根配置-->
<root>
    <!--日志级别:可选值: ERROR > WARN > INFO > DEBUG -->
    <level value="ERROR"/>
    <level value="WARN"/>
    <level value="INFO"/>
    <level value="DEBUG"/>
    <appender-ref ref="ErrorLog" />
    <appender-ref ref="WarnLog" />
    <appender-ref ref="InfoLog" />
    <appender-ref ref="DebugLog" />      
</root>

在调用时使用Type获取ILog对象
public static ILog GetLogger(Type type);
示例:
//获取调用者的类属性
StackTrace trace = new StackTrace();
Type type = trace.GetFrame(1).GetMethod().ReflectedType;

log4net.ILog log = log4net.LogManager.GetLogger(type);
if (log.IsInfoEnabled)
{
    log.Info(message);
}
插入数据库的内容不同(Logger为调用者的类的完整路径)
Id	Date					Thread	Level	Logger									Message							Exception
1	2018-05-15 16:53:39.093	8		INFO	Log4NetOriginalSQL.OriginalSQLAppend	2018/5/15 16:53:39:插入的内容  	

(2)log4net.config文件使用的是logger配置
<logger name="sqlLogger">
    <level value="INFO"/>
    <appender-ref ref="AdoNetAppender_SqlServer"/>
</logger>
在调用时使用LoggerName获取ILog对象
public static ILog GetLogger(string name);
示例:
log4net.ILog log = log4net.LogManager.GetLogger("sqlLogger");
log.Info(message);

插入数据库的内容不同(Logger为获取时使用的LoggerName)
Id	Date					Thread	Level	Logger		Message							Exception
1	2018-05-15 16:53:39.093	8		INFO	sqlLogger	2018/5/15 16:53:39:插入的内容  	

三、Log4NetCustomSQL项目
项目说明:
使用自定义的日志类记录Log4Net日志

可以配置日志记录的方式，下面的配置为:SqlServer和File两种方式都记录。
删除配置则不进行记录。
<appender-ref ref="AdoNetAppender_SqlServer" />
<appender-ref ref="InfoAppender" />

经过测试发现InfoAppender日志只会记录自定义日志类的命名空间，所以将其注释，仅将日志记录插入到数据库中。

1、配置信息
配置信息均保存在log4net.config文件中

2、注册log4net配置信息
本例使用的是web项目。
注册配置信息有两种方式
(1)本例使用的Global.asax
protected void Application_Start(object sender, EventArgs e)
{
    //注册 log4net(或者在AssemblyInfo.cs中添加注册的方法)
    System.IO.FileInfo configFile = new System.IO.FileInfo(HttpContext.Current.Server.MapPath("log4net.config"));
    log4net.Config.XmlConfigurator.Configure(configFile);
}
(2)Properties-AssemblyInfo.cs
追加一句:
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]

3、使用
根据Log4Net.config中配置的不同获取ILog对象的方式也不同
(1)log4net.config文件使用的是root根配置(测试失败，不知道是不是配置问题)
<!--根配置-->
<root>
    <!--日志级别:可选值: ERROR > WARN > INFO > DEBUG -->
    <level value="ERROR"/>
    <level value="WARN"/>
    <level value="INFO"/>
    <level value="DEBUG"/>
    <appender-ref ref="ErrorLog" />
    <appender-ref ref="WarnLog" />
    <appender-ref ref="InfoLog" />
    <appender-ref ref="DebugLog" />
    <appender-ref ref="ADONetAppender_SqlServer"/>
</root>

经测试使用root配置后，
使用public static ILog GetLogger(Type type);
获取的日志操作对象，无法将日志插入到数据库中。

(2)log4net.config文件使用的是logger配置
<logger name="sqlLogger">
    <level value="INFO"/>
    <appender-ref ref="AdoNetAppender_SqlServer"/>
</logger>
在调用时使用LoggerName获取ILog对象
public static ILog GetLogger(string name);
示例:
log4net.ILog log = log4net.LogManager.GetLogger("sqlLogger");
log.Info(message);

4、注意的地方
(1)Log4Net.config配置文件中的自定义字段配置
其中的loyout配置，自定义字段的类的属性
格式:
<layout type = "命名空间.类名,命名空间">    
	<conversionPattern value = "%property{Event_Type} "/>
</layout> 

示例：Event_Type 字段
<!-- 日志类型，这里均为3 -->
<parameter>
	<parameterName value = "@Event_Type"/>
	<dbType value = "Int32"/>
	<size value = "50"/>-->
	<layout type = "Log4NetCustomSQL.MyLayout,Log4NetCustomSQL">    
		<conversionPattern value = "%property{Event_Type} "/>
	</layout>
</parameter>

(2)Log4Net日志自定义字段
本例中的LogContent类，未做测试。
类属性与数据库日志表字段不相符(多字段或少字段)是否会报错。

(3)MyLayout和MyMessagePatternConverter 自定义字段的相关配置类
不懂什么意思，这个是直接从网上示例中复制的。