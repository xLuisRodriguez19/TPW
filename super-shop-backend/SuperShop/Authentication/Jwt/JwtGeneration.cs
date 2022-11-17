using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace SuperShop.Authentication.Jwt;
public class JwtGeneration
{
    private JwtConfig _jwtTokenConfig;
        
    private const long JwtTtl = 3600;

    public JwtGeneration(
        IOptions<JwtConfig> jwtConfigOptions
    )
    {
        _jwtTokenConfig = jwtConfigOptions.Value;
    }

    public JwtGeneration()
    {
    }

    public string GenerateJwt(Dictionary<string, string> payload)
    {
        try
        {
            var securityToken = new JwtSecurityToken(GetJwtHeader(), GetJwtPayload(payload));
            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
        catch (Exception ex)
        {
            throw new Exception($"Client: {ex.Message} \n {ex.InnerException}");
        }
    }

    private JwtHeader GetJwtHeader()
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtTokenConfig.JwtKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        return new JwtHeader(credentials);
    }
        
    private static JwtPayload GetJwtPayload(Dictionary<string, string> extraPayload)
    {
        var epoch = (long) (DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
            
        var jwtPayload = new JwtPayload
        {
            {"nbf", epoch},
            {"exp", epoch + JwtTtl},
        };
            
        jwtPayload.AddClaims(DictionaryToClaims(extraPayload));
            
        return jwtPayload;
    }
        
    private static IEnumerable<Claim> DictionaryToClaims(Dictionary<string, string> payload)
    {
        return payload.Select(pair => new Claim(pair.Key, pair.Value));
    }
}