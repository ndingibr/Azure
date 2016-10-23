using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange.Common.Notifications
{
    public class Notification
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Notification"/> class.
        /// </summary>
        /// <param name="text">The text.</param>
        public Notification(string text)
        {
            ArgumentGuard<ArgumentException>.Verify(
                          () => string.IsNullOrEmpty(text),
                          () => new ArgumentNullException("text", "Parameter cannot be null"));
            Text = text;
            Severity = NotificationSeverity.Information;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Notification"/> class.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="severity">The severity.</param>
        public Notification(string text, NotificationSeverity severity)
        {
            ArgumentGuard<ArgumentException>.Verify(
                           () => string.IsNullOrEmpty(text),
                           () => new ArgumentNullException("text", "Parameter cannot be null"));
            Text = text;
            Severity = severity;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The <see cref="NotificationSeverity"/> of the message
        /// </summary>
        public NotificationSeverity Severity { get; set; }

        /// <summary>
        /// The <see cref="Notification"/> text.
        /// </summary>
        public string Text { get; set; }

        #endregion

        #region Virtual Methods

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "{0} : {1}", Severity, Text);
        }

        #endregion

        #region Static Methods
        /// <summary>
        /// Creates a new instabce of <see cref="Notification"/>.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="notificationSeverity">The notification severity.</param>
        /// <returns></returns>
        public static Notification Create(string message, NotificationSeverity notificationSeverity)
        {
            return new Notification(message, notificationSeverity);
        }

        #endregion
    }
}
