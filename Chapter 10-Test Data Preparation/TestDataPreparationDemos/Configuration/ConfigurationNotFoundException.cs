using System;
using System.Runtime.Serialization;

namespace TestDataPreparationDemos.Configuration
{
    [Serializable]
    public class ConfigurationNotFoundException : Exception
    {
        public ConfigurationNotFoundException()
        {
        }

        public ConfigurationNotFoundException(string configurationType)
            : base($"Configuration section for {configurationType} was not found. Please add the section.")
        {
        }

        public ConfigurationNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected ConfigurationNotFoundException(SerializationInfo serializationInfo, StreamingContext streamingContext)
        {
        }
    }
}
