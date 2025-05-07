namespace Platinus.Application.DTOs.Response
{
    public class ResponseErrorMessages
    {
        public List<string> Errors { get; private set; }

        public ResponseErrorMessages(string message)
        {
            Errors = [message];
        }

        public ResponseErrorMessages(List<string> messages)
        {
            Errors = messages;
        }
    }
}
