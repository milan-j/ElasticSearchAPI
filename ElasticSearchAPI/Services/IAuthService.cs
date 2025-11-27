namespace ElasticSearchAPI
{
    /// <summary>
    /// Defines a service for user authentication and JWT token generation.
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Generates a JWT token for the specified username.
        /// </summary>
        string GenerateJwtToken(string username);

        /// <summary>
        /// Validates the provided username and password.
        /// </summary>
        bool ValidateCretentials(string username, string password);
    }
}
