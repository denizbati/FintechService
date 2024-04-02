namespace FintechService.ApiContract
{
    public class ResponseBaseModel
    {
        public string Version { get; set; } = "";
        public int Status { get; set; } = 200;
        public string Message { get; set; } = "";

        public ResponseBaseModel()
        {
        }

        public ResponseBaseModel SetVersion(string version)
        {
            Version = version;

            return this;
        }

        public ResponseBaseModel SetStatus(int status)
        {
            Status = status;

            return this;
        }

        public ResponseBaseModel SetMessage(string message)
        {
            Message = message;

            return this;
        }
    }
}