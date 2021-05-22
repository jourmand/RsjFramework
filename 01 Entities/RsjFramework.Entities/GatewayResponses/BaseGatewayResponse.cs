using System.Collections.Generic;
using System.Linq;

namespace RsjFramework.Entities.GatewayResponses
{
    public abstract class BaseGatewayResponse
    {
        public bool Success { get; }
        public IEnumerable<Error> Errors { get; }

        protected BaseGatewayResponse(bool success = false, IEnumerable<Error> errors = null)
        {
            Success = success;
            Errors = errors;
        }

        public override string ToString()
        {
            return string.Join("<br/>", Errors.Select(o => o.Description));
        }
    }
}
