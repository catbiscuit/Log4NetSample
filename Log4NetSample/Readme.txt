��飺Log4Net��־����ļ�ʹ��ʾ��



һ��Log4NetFile��Ŀ
��Ŀ˵����
ʹ��Log4Net��¼��־���ı��ļ�

1��������Ϣ
������Ϣ��������log4net.config�ļ���

2��ע��log4net������Ϣ
����ʹ�õ���web��Ŀ��
ע��������Ϣ�����ַ�ʽ
(1)����ʹ�õ�Global.asax
protected void Application_Start(object sender, EventArgs e)
{
    //ע�� log4net(������AssemblyInfo.cs�����ע��ķ���)
    System.IO.FileInfo configFile = new System.IO.FileInfo(HttpContext.Current.Server.MapPath("log4net.config"));
    log4net.Config.XmlConfigurator.Configure(configFile);
}
(2)Properties-AssemblyInfo.cs
׷��һ��:
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]

3��ʹ�ã�
(1)log4net.config�ļ�ʹ�õ���root������
<!--������-->
<root>
    <!--��־����:��ѡֵ: ERROR > WARN > INFO > DEBUG -->
    <level value="ERROR"/>
    <level value="WARN"/>
    <level value="INFO"/>
    <level value="DEBUG"/>
    <appender-ref ref="ErrorLog" />
    <appender-ref ref="WarnLog" />
    <appender-ref ref="InfoLog" />
    <appender-ref ref="DebugLog" />      
</root>
(2)�ڵ���ʱʹ��Type��ȡILog����
public static ILog GetLogger(Type type);
ʾ��:
//��ȡ�����ߵ�������
StackTrace trace = new StackTrace();
Type type = trace.GetFrame(1).GetMethod().ReflectedType;

log4net.ILog log = log4net.LogManager.GetLogger(type);
if (log.IsInfoEnabled)
{
    log.Info(message);
}

����Log4NetOriginalSQL��Ŀ
��Ŀ˵����
ʹ��Log4Netԭ������ݿ�������־�ļ�¼

����������־��¼�ķ�ʽ�����������Ϊ:SqlServer��File���ַ�ʽ����¼��
ɾ�������򲻽��м�¼��
<appender-ref ref="AdoNetAppender_SqlServer" />
<appender-ref ref="InfoAppender" />

1��������Ϣ
������Ϣ��������log4net.config�ļ���

2��ע��log4net������Ϣ
����ʹ�õ���web��Ŀ��
ע��������Ϣ�����ַ�ʽ
(1)����ʹ�õ�Global.asax
protected void Application_Start(object sender, EventArgs e)
{
    //ע�� log4net(������AssemblyInfo.cs�����ע��ķ���)
    System.IO.FileInfo configFile = new System.IO.FileInfo(HttpContext.Current.Server.MapPath("log4net.config"));
    log4net.Config.XmlConfigurator.Configure(configFile);
}
(2)Properties-AssemblyInfo.cs
׷��һ��:
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]

3��ʹ��
����Log4Net.config�����õĲ�ͬ��ȡILog����ķ�ʽҲ��ͬ
(1)log4net.config�ļ�ʹ�õ���root������
<!--������-->
<root>
    <!--��־����:��ѡֵ: ERROR > WARN > INFO > DEBUG -->
    <level value="ERROR"/>
    <level value="WARN"/>
    <level value="INFO"/>
    <level value="DEBUG"/>
    <appender-ref ref="ErrorLog" />
    <appender-ref ref="WarnLog" />
    <appender-ref ref="InfoLog" />
    <appender-ref ref="DebugLog" />      
</root>

�ڵ���ʱʹ��Type��ȡILog����
public static ILog GetLogger(Type type);
ʾ��:
//��ȡ�����ߵ�������
StackTrace trace = new StackTrace();
Type type = trace.GetFrame(1).GetMethod().ReflectedType;

log4net.ILog log = log4net.LogManager.GetLogger(type);
if (log.IsInfoEnabled)
{
    log.Info(message);
}
�������ݿ�����ݲ�ͬ(LoggerΪ�����ߵ��������·��)
Id	Date					Thread	Level	Logger									Message							Exception
1	2018-05-15 16:53:39.093	8		INFO	Log4NetOriginalSQL.OriginalSQLAppend	2018/5/15 16:53:39:���������  	

(2)log4net.config�ļ�ʹ�õ���logger����
<logger name="sqlLogger">
    <level value="INFO"/>
    <appender-ref ref="AdoNetAppender_SqlServer"/>
</logger>
�ڵ���ʱʹ��LoggerName��ȡILog����
public static ILog GetLogger(string name);
ʾ��:
log4net.ILog log = log4net.LogManager.GetLogger("sqlLogger");
log.Info(message);

�������ݿ�����ݲ�ͬ(LoggerΪ��ȡʱʹ�õ�LoggerName)
Id	Date					Thread	Level	Logger		Message							Exception
1	2018-05-15 16:53:39.093	8		INFO	sqlLogger	2018/5/15 16:53:39:���������  	

����Log4NetCustomSQL��Ŀ
��Ŀ˵��:
ʹ���Զ������־���¼Log4Net��־

����������־��¼�ķ�ʽ�����������Ϊ:SqlServer��File���ַ�ʽ����¼��
ɾ�������򲻽��м�¼��
<appender-ref ref="AdoNetAppender_SqlServer" />
<appender-ref ref="InfoAppender" />

�������Է���InfoAppender��־ֻ���¼�Զ�����־��������ռ䣬���Խ���ע�ͣ�������־��¼���뵽���ݿ��С�

1��������Ϣ
������Ϣ��������log4net.config�ļ���

2��ע��log4net������Ϣ
����ʹ�õ���web��Ŀ��
ע��������Ϣ�����ַ�ʽ
(1)����ʹ�õ�Global.asax
protected void Application_Start(object sender, EventArgs e)
{
    //ע�� log4net(������AssemblyInfo.cs�����ע��ķ���)
    System.IO.FileInfo configFile = new System.IO.FileInfo(HttpContext.Current.Server.MapPath("log4net.config"));
    log4net.Config.XmlConfigurator.Configure(configFile);
}
(2)Properties-AssemblyInfo.cs
׷��һ��:
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]

3��ʹ��
����Log4Net.config�����õĲ�ͬ��ȡILog����ķ�ʽҲ��ͬ
(1)log4net.config�ļ�ʹ�õ���root������(����ʧ�ܣ���֪���ǲ�����������)
<!--������-->
<root>
    <!--��־����:��ѡֵ: ERROR > WARN > INFO > DEBUG -->
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

������ʹ��root���ú�
ʹ��public static ILog GetLogger(Type type);
��ȡ����־���������޷�����־���뵽���ݿ��С�

(2)log4net.config�ļ�ʹ�õ���logger����
<logger name="sqlLogger">
    <level value="INFO"/>
    <appender-ref ref="AdoNetAppender_SqlServer"/>
</logger>
�ڵ���ʱʹ��LoggerName��ȡILog����
public static ILog GetLogger(string name);
ʾ��:
log4net.ILog log = log4net.LogManager.GetLogger("sqlLogger");
log.Info(message);

4��ע��ĵط�
(1)Log4Net.config�����ļ��е��Զ����ֶ�����
���е�loyout���ã��Զ����ֶε��������
��ʽ:
<layout type = "�����ռ�.����,�����ռ�">    
	<conversionPattern value = "%property{Event_Type} "/>
</layout> 

ʾ����Event_Type �ֶ�
<!-- ��־���ͣ������Ϊ3 -->
<parameter>
	<parameterName value = "@Event_Type"/>
	<dbType value = "Int32"/>
	<size value = "50"/>-->
	<layout type = "Log4NetCustomSQL.MyLayout,Log4NetCustomSQL">    
		<conversionPattern value = "%property{Event_Type} "/>
	</layout>
</parameter>

(2)Log4Net��־�Զ����ֶ�
�����е�LogContent�࣬δ�����ԡ�
�����������ݿ���־���ֶβ����(���ֶλ����ֶ�)�Ƿ�ᱨ��

(3)MyLayout��MyMessagePatternConverter �Զ����ֶε����������
����ʲô��˼�������ֱ�Ӵ�����ʾ���и��Ƶġ�