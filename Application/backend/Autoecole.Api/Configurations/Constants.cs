namespace backend.Autoecole.Api.Configurations
{
    public static class Constants
    {
        public const string Audiance = "https://localhost:5001/";
        public const string Issuer = Audiance;//"http://localhost:8088";
        public const string Secret = "azertcsdcsdcsdcsdcwcwcuycwghgjhqdgjhgj879qjzèpyuiopqsdfghj";

        #region Token
        public const int TokenExpires = 60 * 30;
        public const string RefreshToken = "RefreshTokenSampleValueSomething77";
        public const string TokenType = "Bearer";
        #endregion

       
    }
}