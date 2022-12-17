namespace BookStoreApp.Blazor.Server.UI.Services.Base
{
    public partial class Client : IClient 
    { 
        public  HttpClient HttpClient
        {
            set { _httpClient = value;  }
            get
            {
                return _httpClient;
            }
        }
    }
}
