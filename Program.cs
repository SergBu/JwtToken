// See https://aka.ms/new-console-template for more information
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

var token = GetJwtToken();
Console.WriteLine($"Your token is {token}");



string GetJwtToken()
{
    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("qwertyuiopasdfgh_qwertyuiopasdfgh_Secret128"));

    var tokenInfo = new JwtSecurityToken(
                issuer: "Budnikov",
                expires: DateTime.Now.AddSeconds(86400), //ttl
                signingCredentials: new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256));

    var token = new JwtSecurityTokenHandler().WriteToken(tokenInfo);
    return token;
}