<Query Kind="Statements">
  <IncludeWinSDK>true</IncludeWinSDK>
  <NuGetReference>System.IdentityModel.Tokens.Jwt"</NuGetReference>
</Query>

/*<ItemGroup>
  <PackageReference Include="System.IdentityModel.Tokens.Jwt" Version="6.32.1" />
</ItemGroup>*/

using System;
using System.Text;
using System.Text.Json;
using System.Security.Cryptography.X509Certificates;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

var cert = new X509Certificate2(Encoding.ASCII.GetBytes(
    """
    -----BEGIN CERTIFICATE-----
    MIIDqTCCApGgAwIBAgIJAOp315qDJ0RTMA0GCSqGSIb3DQEBCwUAMEExCzAJBgNV
    BAYTAktaMQ8wDQYDVQQIEwZBbG1hdHkxDzANBgNVBAcTBkFsbWF0eTEQMA4GA1UE
    ChMHSnd0VGVzdDAeFw0yMzA3MzEwODEyMjJaFw0zMzA3MjgwODEyMjJaMEExCzAJ
    BgNVBAYTAktaMQ8wDQYDVQQIEwZBbG1hdHkxDzANBgNVBAcTBkFsbWF0eTEQMA4G
    A1UEChMHSnd0VGVzdDCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBALHZ
    PCVdgBQruidxNtpUr5jZER9ul+hx44B3yiarsMJTPSYPwxWEspYU/cUKIpqU7YpH
    /+bdXc/O54UdBe6Vk11iXsEA/3W49U+NjkMgaY7zJ/d0NLxW/uWjwUaPj+7KCQiU
    lpO3vQzddUDhxyQNWn0dSLr6yjlrh+0B6Jk7FA2mooqfhkf3uoEQ+kRn75Xvplk/
    eUxzNsNgH0f+0dNJJ37xDpNyXFWJaAMlWSl2gzEQC4I/qu9QyPhSDgNnfPXzB+ao
    Sqr2mwL374FxwhcoPY+WgSuIAnmsWG3e0TpNfHQJQnDH0XrRXJYQb451AZYEc630
    GCLsMEFWHqEbXqhpb0kCAwEAAaOBozCBoDAdBgNVHQ4EFgQU1ufg8qEzAArU3U2W
    +d0Ww1BuUrYwcQYDVR0jBGowaIAU1ufg8qEzAArU3U2W+d0Ww1BuUrahRaRDMEEx
    CzAJBgNVBAYTAktaMQ8wDQYDVQQIEwZBbG1hdHkxDzANBgNVBAcTBkFsbWF0eTEQ
    MA4GA1UEChMHSnd0VGVzdIIJAOp315qDJ0RTMAwGA1UdEwQFMAMBAf8wDQYJKoZI
    hvcNAQELBQADggEBAI5uTXSXVM0jpDbuApKOBZsorfoV/kFj6BFLKRdOaHcWblTe
    jUgmuQdFr7QixGqh177NFdHeJlnsyw17P9LHj/ulc1ejpOlsxVKzaCKTdHlHU2Rg
    uusfu+EXxdUPMecDsJ89TgmbGaecWCzbdvJBOzydVMZnO8FDP19++UBShKUvxoYA
    TQ/y8nIBV3aWRl6rRVu1srQ8TZ7130Q26zSd6qx9QLINtymvcTClDrS+yqe7VShy
    qfLZ3/Oh7oBXHw8fam6woHnZbnso06upC4Ctq/bT6S4s445Y9k07Y0dM41wzeD+k
    EVKMTL2C8PivXhHeDpo1Mb3n1Yq3yyNMDADDi5E=
    -----END CERTIFICATE-----
    """));

/*
{
  "sub": "1234567890",
  "name": "John Doe",
  "admin": true,
  "iat": 1692495254,
  "exp": 1692495254, //Here date is 20.08.2023
  "aud": "asd",
  "iss": "https://a.sd/"
}
*/

var tokenStr = """
eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiYWRtaW4iOnRydWUsImlhdCI6MTY5MjQ5NTI1NCwiZXhwIjoxNjkyNDk1MjU0LCJhdWQiOiJhc2QiLCJpc3MiOiJodHRwczovL2Euc2QvIn0.et6nSATVB8NifY9OgLdCH2lg0r6O7o7FxQYzkhf-zYg_hnrB5oeJOOHirHaF_6HVq9UrA0ZRxtRgnm1vIvraZgL5ZHf2mFWxsXuyLXeZ3FlRxC_ZQ3BAy5861EG94MCSgc38hTFe1EZl9JW8IBjUWxY2w5W2-pP6vPCvqTT1lrRTIefx-Ehh4cW0J67iKRqA3BkdtXfnbDydT8C0m5g7YYo_SGGqTs-MstLaed_MA9K7xSP4rIHodNL9vxSdz4NgeCxJEusDrGDMbwQkSWkOk6RglLhmCU4sEr9JnJzMe4ZYzaWEkmTPOg2C3Uso7A2YxjkUlSgdvRggZGTaWc-fKw
""";

var token = new JwtSecurityToken(tokenStr);

var hndl = new JsonWebTokenHandler();
var validResp = hndl.ValidateToken(
    tokenStr,
    new TokenValidationParameters
    {
        ValidAudience = "asd",
        ValidIssuers = new[] { "https://a.sd/" },
        IssuerSigningKey = new RsaSecurityKey(cert.GetRSAPublicKey())
    });


Console.WriteLine($"{validResp.IsValid}\n{validResp.Exception}");

Console.WriteLine(JsonSerializer.Serialize((token as JwtSecurityToken)?.Payload, new JsonSerializerOptions
{
    WriteIndented = true,
}));

Console.WriteLine("token.Issuer: " + token.Issuer);