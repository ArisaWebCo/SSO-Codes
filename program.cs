 public static class Program
    {
        public static void Main(string[] args)
        {
          builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = "oidc";

            }).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
           .AddOpenIdConnect("oidc", options =>
           {
               options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
               options.Authority = "https://localhost:7234/";
               options.ClientId = "1";
               options.ClientSecret = "secret";

               options.TokenValidationParameters = new TokenValidationParameters
               { 
                   NameClaimType = JwtClaimTypes.GivenName,
                   RoleClaimType = JwtClaimTypes.Role
               };

               options.ResponseType = "code";
               options.SaveTokens = true;

               options.Scope.Clear();
               options.Scope.Add("openid");
               options.Scope.Add("profile");
               options.Scope.Add("phone");
               options.Scope.Add("email");
               options.Scope.Add("address");

 
               options.GetClaimsFromUserInfoEndpoint = true;
               options.RequireHttpsMetadata = true;
           });
        }
 }
