namespace EventClasswork
{
    /// <summary>
    ///The  publisher
    /// </summary>
    internal class Alarm
    {
        public delegate void AlarmHandler();        //delegate
        public event AlarmHandler NotifyScreen;     //event
        /// <summary>
        /// This method checks if the time is 7am. 
        /// </summary>
        public void AlarmCheck()
        {
            try
            {

                if (DateTime.Now.Hour == 07)        //checks if the current time is 7
                {
                    OnAlarmTime();
                }
            }
            catch (Exception e)
            {
                var error = e.Message;
            }


        }
        /// <summary>
        /// This method invokes the event
        /// </summary>
        protected virtual void OnAlarmTime()
        {
            NotifyScreen?.Invoke();
        }
        static void Main(string[] args)
        {
            Screen screen = new Screen();
            screen.Waker();
        }

    }
    /// <summary>
    /// Subscriber
    /// </summary>
    public class Screen
    {
        /// <summary>
        /// This method notifies the user when it is time.
        /// </summary>
        public void Waker()
        {
            var time = new Alarm();
            time.NotifyScreen += () => Console.WriteLine("It is time to wake up");        //Lambda to declare the method in the subscriber 
            time.AlarmCheck();
        }
    }
}