using EuroFurnish.ApplicationCore.Providers.Interfaces;

namespace EuroFurnish.ApplicationCore.Providers.Abstract
{
    public class ResponseProvider : IResponseProvider
    {
        public bool IsSuccess { get; private set; }
        public string Message { get; private set; }
        public object Data { get; private set; }
        public ResponseProvider()
        {
            Message = null;
            Data = null;
            IsSuccess = true;
        }
        public void Error(string message)
        {
            Message = message;
            Data = null;
            IsSuccess = false;
        }
      
        public void Success(object data)
        {
            Message = null;
            Data = data;
            IsSuccess = true;
        }

        public void Success(string message, object data)
        {
            Message = message;
            Data = data;
            IsSuccess = true;
        }

       
    }
}
