using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using NLog;

namespace TestNLog
{
    /// <summary>
    /// Define the sort of DurationLogger post text geneation
    /// </summary>
    public enum ePostText
    {
        /// <summary>
        /// Noting
        /// </summary>
        None,
        /// <summary>
        /// (m_Counter) record(s)
        /// </summary>
        Records,
        /// <summary>
        /// (m_Counter) time(s)
        /// </summary>
        Times
    };

    /// <summary>
    /// Measure and log time duration
    /// </summary>
    public class DurationLogger
    {
        private DateTime m_tStart;
        private DateTime m_tStop;
        private bool     m_Running;
        private string   m_Text    = string.Empty;
        private int      m_Counter = 0;

        public int Counter
        {
            get { return m_Counter; }
            set { m_Counter = value; }
        }

        public string Text
        {
            get { return m_Text; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Text");

                m_Text = value;
            }
        }

        /// <summary>
        /// Constructor using name
        /// Output: "    0 ms for Name"
        /// </summary>
        /// <param name="Name"></param>
        public DurationLogger(string Name)
        {
            if (Name == null)
                throw new ArgumentNullException("Name");

            if (Name != string.Empty)
                m_Text = "for " + Name;

            Start();
        }

        /// <summary>
        /// Default constructor
        /// Output: "    0 ms total processing time"
        /// </summary>
        public DurationLogger()
        {
            m_Text = "total processing time";
            Start();
        }

        /// <summary>
        /// Restart of timer
        /// </summary>
        public void Start()
        {
            m_tStart = DateTime.Now;
            m_Running = true;
        }

        /// <summary>
        /// Stop/pauze timer
        /// </summary>
        public void Stop()
        {
            if (m_Running)
                m_tStop = DateTime.Now;

            m_Running = false;
        }

        /// <summary>
        /// Resume timer
        /// </summary>
        public void Resume()
        {
            m_Running = true;
        }

        /// <summary>
        /// Output dureation to logger, no PostText
        /// </summary>
        /// <param name="Lg"></param>
        public void LogDuration(Logger Lg)
        {
            LogDuration(Lg, string.Empty);
        }

        /// <summary>
        /// Output dureation to logger, PostText = --- / (m_Counter) record(s) / (m_Counter) time(s)
        /// </summary>
        /// <param name="Lg"></param>
        /// <param name="ePT"></param>
        public void LogDuration(Logger Lg, ePostText ePT)
        {
             Lg.Log(LogLevel.Info, LogDuration(ePT));
        }

        /// <summary>
        /// Output dureation to logger with own PostText
        /// /// Output: "    0 ms [for Name][PostText]"
        /// </summary>
        /// <param name="Lg"></param>
        /// <param name="PostText"></param>
        public void LogDuration(Logger Lg, string PostText)
        {
            if (Lg == null)
                throw new ArgumentNullException("Lg");

            if (PostText == null)
                throw new ArgumentNullException("PostText");

            Lg.Log(LogLevel.Info, LogDuration(PostText));
        }

        /// <summary>
        /// Output dureation to string, PostText = --- / (m_Counter) record(s) / (m_Counter) time(s)
        /// </summary>
        /// <param name="Lg"></param>
        /// <param name="ePT"></param>
        public string LogDuration(ePostText ePT)
        {
            string PostText = string.Empty;

            switch (ePT)
            {
                case ePostText.None:
                    break;

                case ePostText.Records:
                    PostText = string.Format(", {0} record{1}{2}", m_Counter, (m_Counter == 1) ? "" : "s", Average("record"));
                    break;

                case ePostText.Times:
                    PostText = string.Format(", {0} time{1}{2}", m_Counter, (m_Counter == 1) ? "" : "s", Average("event"));
                    break;
            }

            return LogDuration(PostText);
        }

        private TimeSpan TS
        {
            get
            {
                if (m_Running)
                    m_tStop = DateTime.Now;

                return m_tStop - m_tStart;
            }
        }

        private string Average(string PerEvent)
        {
            string rVal = string.Empty;

            if (m_Counter > 1)
            {
                if (m_Running)
                    m_tStop = DateTime.Now;

                rVal = string.Format(" (Average = {0:F1} ms/{1})", TS.TotalMilliseconds / m_Counter, PerEvent);
            }

            return rVal;
        }

        /// <summary>
        /// Output dureation to string with own PostText
        /// /// Output: "    0 ms [for Name][PostText]"
        /// </summary>
        /// <param name="Lg"></param>
        /// <param name="PostText"></param>
        public string LogDuration(string PostText)
        {
            if (m_Running)
                m_tStop = DateTime.Now;

            return string.Format("{0,5} ms {1}{2}", (int)TS.TotalMilliseconds, m_Text, PostText);
        }

    }
}

