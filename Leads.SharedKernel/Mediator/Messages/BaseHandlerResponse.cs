namespace Leads.SharedKernel.Mediator.Messages
{
    public class BaseHandlerResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; private set; }

        public BaseHandlerResponse()
        {
            Success = true;
            Message = string.Empty;
            Errors = new List<string>();
        }

        public BaseHandlerResponse(bool success, string message = "")
        {
            Success = success;
            Message = message;
            Errors = new List<string>();
        }

        public void AddError(string error, string message)
        {
            Errors.Add(error);
            Success = false;
            Message = message;  
        }

        public void AddErrors(List<string>erros, string message)
        {
            Errors.AddRange(erros);
            Success = false;
            Message = message;
        }
    }
}
