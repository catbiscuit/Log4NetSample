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
(1)log4net.config文件使用的是root跟配置
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
(1)log4net.config文件使用的是root跟配置
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

(2)log4net.config文件使用的是logger跟配置
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