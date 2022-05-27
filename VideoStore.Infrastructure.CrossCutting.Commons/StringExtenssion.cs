using System;

namespace VideoStore.Infrastructure.CrossCutting.Commons
{
    public static class StringExtenssion
    {
        public static string DbStringFormat(this string value, string host, string user, string secret)
                 => value.Replace("{Host}", host).Replace("{User}", user).Replace("{Secret}", secret);
    }
}
