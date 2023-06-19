namespace Events
{
    /// <summary>
    /// Responsible for handling an event published by <see cref="EventAggregator"/>.
    /// </summary>
    /// <typeparam name="TEvent"></typeparam>
    public interface IEventHandler<in TEvent>
    {
        /// <summary>
        /// Handles an event.
        /// </summary>
        /// <param name="value">The event.</param>
        /// <remarks>The execution is done in the publisher's thread (usually the Unity main thread).</remarks>
        void Handle(TEvent value);
    }
}