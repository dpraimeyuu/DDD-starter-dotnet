using System;

namespace MyCompany.Crm.TechnicalStuff
{
    public class TemporaryInfrastructureError : InfrastructureError
    {
        public TemporaryInfrastructureError() { }
        
        public TemporaryInfrastructureError(string message) : base(message) { }

        public TemporaryInfrastructureError(string message, Exception innerException) :
            base(message, innerException) { }
    }
}