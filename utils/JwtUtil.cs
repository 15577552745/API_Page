using System;
using API_Page.Models;
using JWT;
using JWT.Algorithms;
using JWT.Builder;
using JWT.Exceptions;
using JWT.Serializers;
using JsonSerializer = System.Text.Json.JsonSerializer;



public class JwtUtil
{

    private static String secret = "GQDstcKsx0NHjPOuXOYg5MbeJ1XT0uFiwDVvVBrk";

    //jwt令牌有效期 因为是demo以天为单位  默认3天
    private static int days = 3;

    

    
    public static String generateToken(int userId,int role)
    {
      return JwtBuilder.Create()
            .WithAlgorithm(new HMACSHA256Algorithm())
            .ExpirationTime(DateTimeOffset.UtcNow.AddDays(days).ToUnixTimeSeconds())// symmetric
            .WithSecret(secret)
            .AddClaim("Id", userId)
            .AddClaim("Role",role)
            .Encode();
    }
    
    
    
    public static String generateToken(User user)
    {
        return generateToken(user.Id, user.Role);
    }


    public static bool valid(String token)
    {
        try
        {
            IJsonSerializer serializer = new JsonNetSerializer();
            IDateTimeProvider provider = new UtcDateTimeProvider();
            IJwtValidator validator = new JwtValidator(serializer, provider);
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm(); // symmetric
            IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder, algorithm);
            decoder.Decode(token, secret, verify: true);
        }
        catch (TokenExpiredException)
        {
            return false;
        }
        catch (SignatureVerificationException)
        {
            return false;
        }
        catch (InvalidTokenPartsException)
        {
            return false;
        }
        return true;
    }
    
    
    public static User getUser(String token)
    {
        String json = JwtBuilder.Create()
            .WithAlgorithm(new HMACSHA256Algorithm()) // symmetric
            .WithSecret(secret)
            .MustVerifySignature()
            .Decode(token);

        User user = JsonSerializer.Deserialize<User>(json);

        return user;
    }


    
    public static int getId(String token)
    {
        return getUser(token).Id;
    }
    
    
    
    public static int getRole(String token)
    {
        return getUser(token).Role;
    }
    
    
    
    
}