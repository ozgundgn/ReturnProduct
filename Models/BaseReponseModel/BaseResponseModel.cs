namespace Models.BaseReponseModel
{
    public class BaseResponseModel
    {
        public string Message { get; set; }
        public bool Success { get { return true; } set { } }
    }
}
