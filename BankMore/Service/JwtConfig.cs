namespace BankMore.Account.API.Service
{
    public class JwtConfig
    {
        /// <summary>
        /// Chave secreta do token
        /// </summary>
        public string SecretKey { get; set; }

        /// <summary>
        /// Indica quem emitiu o token JWT
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// Indica para quem o token JWT é destinado.
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// Tempo de expiração do token
        /// </summary>
        public int TempoDeExpiracao { get; set; }
    }
}
