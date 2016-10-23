using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange.Common
{
    public class NotificationCollection : IFormattable, IEnumerable<Notification>
    {
        private readonly List<Notification> messages = new List<Notification>();

        #region Methods

        /// <summary>
        /// Gets a value indicating whether this instance has <see cref="Notification"/>.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has <see cref="Notification"/>; otherwise, <c>false</c>.
        /// </value>
        public bool HasMessages()
        {
            return messages.Count > 0;
        }

        /// <summary>
        /// Gets a value indicating whether this instance contains <see cref="Notification"/> with a severity of Information.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has information; otherwise, <c>false</c>.
        /// </value>
        public bool HasInformation()
        {
            return messages.Contains(m => m.Severity == NotificationSeverity.Information);
        }

        /// <summary>
        /// Gets a value indicating whether this instance contains <see cref="Notification"/> with a severity of Warning.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has warnings; otherwise, <c>false</c>.
        /// </value>
        public bool HasWarnings()
        {
            return messages.Contains(m => m.Severity == NotificationSeverity.Warning);
        }

        /// <summary>
        /// Indicates whether the notificaiton has errors
        /// </summary>
        /// <returns></returns>
        public bool HasErrors()
        {
            return messages.Contains(m => m.Severity == NotificationSeverity.Error);
        }

        /// <summary>
        /// Adds a <see cref="Notification"/> to the <see cref="NotificationCollection"/>
        /// </summary>
        /// <param name="notification">The message to add</param>
        public void AddMessage(Notification notification)
        {
            if (notification != null)
            {
                messages.Add(notification);
            }
        }

        /// <summary>
        /// Adds a <see cref="Notification"/> to the <see cref="NotificationCollection"/> at the specified index
        /// </summary>
        /// <param name="notification">The <see cref="Notification"/> to add</param>
        /// <param name="index">The index to insert the message at</param>
        public void AddMessage(Notification notification, int index)
        {
            if (notification != null)
            {
                messages.Insert(index, notification);
            }
        }


        /// <summary>
        /// Adds a <see cref="Notification"/> list to the <see cref="NotificationCollection"/>
        /// </summary>
        /// <param name="notifications">The message to add</param>
        public void AddMessage(IEnumerable<Notification> notifications)
        {
            if (notifications != null)
            {
                messages.AddRange(notifications);
            }
        }


        /// <summary>
        /// Adds a error notification to the collection.
        /// </summary>
        /// <param name="message"></param>
        public void AddError(string message)
        {
            AddMessage(new Notification(message) { Severity = NotificationSeverity.Error });
        }

        /// <summary>
        /// Formats the value of the current instance using the specified format.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> containing the value of the current instance in the specified format.
        /// </returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            var builder = new StringBuilder();
            foreach (Notification message in messages)
            {
                builder.Append(string.Format(CultureInfo.InvariantCulture, "{0}{1}", builder.Length > 0 ? Environment.NewLine : null, message));
            }
            return builder.ToString();
        }


        /// <summary>
        /// Creates an empty <see cref="NotificationCollection"/>.
        /// </summary>
        /// <returns></returns>
        public static NotificationCollection CreateEmpty()
        {
            return new NotificationCollection();
        }

        /// <summary>
        /// Creates a <see cref="NotificationCollection"/> that contains <paramref name="notification"/>
        /// </summary>
        /// <param name="notification">The notification.</param>
        /// <returns></returns>
        public static NotificationCollection Create(Notification notification)
        {
            NotificationCollection notificationCollection = CreateEmpty();
            notificationCollection.AddMessage(notification);
            return notificationCollection;
        }

        /// <summary>
        /// Creates a <see cref="NotificationCollection"/> that contains the entire list from <paramref name="notifications"/>
        /// </summary>
        /// <param name="notifications">The notifications.</param>
        /// <returns></returns>
        public static NotificationCollection Create(IList<Notification> notifications)
        {
            NotificationCollection notificationCollection = CreateEmpty();
            notificationCollection.AddMessage(notifications);
            return notificationCollection;
        }

        #endregion

        #region Operator Overloads

        /// <summary>
        /// Adds one <see cref="NotificationCollection"/> to another <see cref="NotificationCollection"/>
        /// </summary>
        /// <param name="left">The first <see cref="NotificationCollection"/></param>
        /// <param name="right">The second <see cref="NotificationCollection"/></param>
        /// <returns></returns>
        public static NotificationCollection Add(NotificationCollection left, NotificationCollection right)
        {
            return left + right;
        }

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="left">The result1.</param>
        /// <param name="right">The result2.</param>
        /// <returns>The result of the operator.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1013:OverloadOperatorEqualsOnOverloadingAddAndSubtract", Justification = "Not interested to verify equality")]
        public static NotificationCollection operator +(NotificationCollection left, NotificationCollection right)
        {
            ArgumentGuard<ArgumentException>.Verify(
                          () => left == null,
                          () => new ArgumentNullException("left", "Parameter cannot be null"));

            if (right != null)
            {
                left.AddMessage(right);
            }
            return left;
        }

        /// <summary>
        /// Implements the operator + on a <see cref="NotificationCollection"/> and a <see cref="Notification"/>.
        /// </summary>
        /// <param name="left">The result1.</param>
        /// <param name="right">The result2.</param>
        /// <returns>The result of the operator.</returns>
        public static NotificationCollection operator +(NotificationCollection left, Notification right)
        {
            ArgumentGuard<ArgumentException>.Verify(
                          () => left == null,
                          () => new ArgumentNullException("left", "Parameter cannot be null"));

            if (right != null)
            {
                left.AddMessage(right);
            }
            return left;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="NotificationCollection"/> to <see cref="System.String"/>.
        /// </summary>
        /// <param name="notification">The notification.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator string(NotificationCollection notification)
        {
            return notification.ToString();
        }

        #endregion

        #region IEnumerable Members

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        IEnumerator<Notification> IEnumerable<Notification>.GetEnumerator()
        {
            for (int i = 0; i < messages.Count; i++)
            {
                yield return messages[i];
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Notification>)this).GetEnumerator();
        }

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
            return ToString(null, null);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets and sets the Payload
        /// </summary>
        public object Payload { get; set; }

        #endregion
    }
}
