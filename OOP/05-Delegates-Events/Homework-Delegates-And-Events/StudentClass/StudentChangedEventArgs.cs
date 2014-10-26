namespace StudentClass
{
    using System;
    public class StudentChangedEventArgs : EventArgs
    {
        private object oldValue;
        private object newValue;
        private string propertyName;

        public StudentChangedEventArgs(object valueChanged, object oldValue, string propertyName)
        {
            this.oldValue = oldValue;
            this.newValue = valueChanged;
            this.propertyName = propertyName;
        }

        public object NewValue
        {
            get { return newValue; }
        }

        public object OldValue
        {
            get { return oldValue; }
        }

        public string PropertyName
        {
            get { return propertyName; }
        }
    }
}
