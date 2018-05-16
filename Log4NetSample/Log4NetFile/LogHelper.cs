using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Log4NetFile
{
    /// <summary>
    /// Log4Net日志操作类
    /// </summary>
    public class LogHelper
    {
        public LogHelper()
        { }

        /// <summary>
        /// Error日志
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        public static void ErrorLogWrite(object message)
        {
            //获取调用者的类属性
            StackTrace trace = new StackTrace();
            Type type = trace.GetFrame(1).GetMethod().ReflectedType;

            log4net.ILog log = log4net.LogManager.GetLogger(type);
            if (log.IsErrorEnabled)
            {
                log.Error(message);
            }
        }
        /// <summary>
        /// Error日志
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public static void ErrorLogWrite(object message, Exception ex)
        {
            //获取调用者的类属性
            StackTrace trace = new StackTrace();
            Type type = trace.GetFrame(1).GetMethod().ReflectedType;

            log4net.ILog log = log4net.LogManager.GetLogger(type);
            if (log.IsErrorEnabled)
            {
                log.Error(message, ex);
            }
        }

        /// <summary>
        /// Warn日志
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        public static void WarnLogWrite(object message)
        {
            //获取调用者的类属性
            StackTrace trace = new StackTrace();
            Type type = trace.GetFrame(1).GetMethod().ReflectedType;

            log4net.ILog log = log4net.LogManager.GetLogger(type);
            if (log.IsWarnEnabled)
            {
                log.Warn(message);
            }
        }
        /// <summary>
        /// Warn日志
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public static void WarnLogWrite(object message, Exception ex)
        {
            //获取调用者的类属性
            StackTrace trace = new StackTrace();
            Type type = trace.GetFrame(1).GetMethod().ReflectedType;

            log4net.ILog log = log4net.LogManager.GetLogger(type);
            if (log.IsWarnEnabled)
            {
                log.Warn(message, ex);
            }
        }

        /// <summary>
        /// Info日志
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        public static void InfoLogWrite(object message)
        {
            //获取调用者的类属性
            StackTrace trace = new StackTrace();
            Type type = trace.GetFrame(1).GetMethod().ReflectedType;

            log4net.ILog log = log4net.LogManager.GetLogger(type);
            if (log.IsInfoEnabled)
            {
                log.Info(message);
            }
        }
        /// <summary>
        /// Info日志
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public static void InfoLogWrite(object message, Exception ex)
        {
            //获取调用者的类属性
            StackTrace trace = new StackTrace();
            Type type = trace.GetFrame(1).GetMethod().ReflectedType;

            log4net.ILog log = log4net.LogManager.GetLogger(type);
            if (log.IsInfoEnabled)
            {
                log.Info(message, ex);
            }
        }

        /// <summary>
        /// Debug日志
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        public static void DebugLogWrite(object message)
        {
            //获取调用者的类属性
            StackTrace trace = new StackTrace();
            Type type = trace.GetFrame(1).GetMethod().ReflectedType;

            log4net.ILog log = log4net.LogManager.GetLogger(type);
            if (log.IsDebugEnabled)
            {
                log.Debug(message);
            }
        }
        /// <summary>
        /// Debug日志
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public static void DebugLogWrite(object message, Exception ex)
        {
            //获取调用者的类属性
            StackTrace trace = new StackTrace();
            Type type = trace.GetFrame(1).GetMethod().ReflectedType;

            log4net.ILog log = log4net.LogManager.GetLogger(type);
            if (log.IsDebugEnabled)
            {
                log.Debug(message, ex);
            }
        }
    }
}