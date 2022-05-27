using System;

namespace VideoStore.Infrastructure.CrossCutting.Commons
{
    public static class StringExtenssion
    {
        public static string DbStringFormat(this string value, string host, string user, string secret)
                 => value.Replace("{Host}", host).Replace("{User}", user).Replace("{Secret}", secret);

        public static string JwtKeyStringFormat(this string value, string key)
            => value.Replace("{Key}", key);

        public static string JwtIssuerStringFormat(this string value, string issuer)
             => value.Replace("{Issuer}", issuer);

        public static string JwtAudienceStringFormat(this string value, string audience)
                => value.Replace("{Audience}", audience);
    }
}
