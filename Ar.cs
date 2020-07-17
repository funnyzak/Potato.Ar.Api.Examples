using System.Collections.Generic;
using System.Threading.Tasks;
using Potato.Ar.Api.Sdk.Models;
using Potato.Ar.Api.Examples.Common;

namespace Potato.Ar.Api.Examples
{
    public class Ar : IExample
    {
        private ConfigProvider _configProvider;

        public async Task RunExample(string[] args)
        {
            _configProvider = new ConfigProvider(args);

            /****初始化连接器****/
            ArApiProvider.Reset(_configProvider.GetAppKey(), _configProvider.GetAppSecret());

            /****登陆并设置AuthToken****/
            AccountInfo loginAccount = await ArApiProvider.Instance.Account.LoginAsync("13123456789", "123789");
            ArApiProvider.Reset(loginAccount.AuthToken);

            /****识别图搜索****/
            var arCard = await ArApiProvider.Instance.Ar.ImageSearchAsync("image_base64_code");

            /****根据授权码获取可激活的图录列表****/
            var albums = await ArApiProvider.Instance.Ar.CanActiveAsync("code_num");
        }

    }
}
