using System;
using Potato.Ar.Api.Sdk;
using Potato.Ar.Api.Sdk.Common.Logging;

namespace Potato.Ar.Api.Examples.Common
{
    public class ArApiProvider
    {
        private readonly static object lockObj = new object();
        private static PotatoArApi instance = null;

        private static string _authToken = "";
        private static string _appKey = "your_key";
        private static string _appSecret = "your_searcht";
        private static string _clientInfo = "os=iphone&model=iphone11";

        static ArApiProvider()
        {
            _clientInfo = "os=iphone&model=iphone11";
            _authToken = ""; // 此处从本地读取token值
        }

        public static PotatoArApi Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObj)
                    {
                        if (instance == null)
                        {
                            instance = GetArApi();
                        }
                    }
                }
                return instance;
            }
        }

        public static void Reset(string authToken)
        {
            _authToken = authToken;
            instance = null;
        }

        public static void Reset(string appKey, string appSecret)
        {
            _appKey = appKey;
            _appSecret = appSecret;
            instance = null;
        }

        public static void Reset(string appKey, string appSecret, string authToken)
        {
            _authToken = authToken;
            _appKey = appKey;
            _appSecret = appSecret;
            instance = null;
        }

        static PotatoArApi GetArApi()
        {
            return PotatoArApi.Builder
                .WithApiKey(_appKey)
                .WithSecretKey(_appSecret)
                .WithClientInfo(_clientInfo)
                .WithAuthToken(_authToken)
                .WithLogger(new ConsoleLogger())
                .Build();
        }
    }
}
