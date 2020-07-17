using System.Collections.Generic;
using System.Threading.Tasks;
using Potato.Ar.Api.Sdk.Models;
using Potato.Ar.Api.Examples.Common;

namespace Potato.Ar.Api.Examples
{
    public class Album : IExample
    {
        private ConfigProvider _configProvider;

        public async Task RunExample(string[] args)
        {
            _configProvider = new ConfigProvider(args);

            /****初始化连接器****/
            ArApiProvider.Reset(_configProvider.GetAppKey(), _configProvider.GetAppSecret());

            /****登陆****/
            AccountInfo loginAccount = await ArApiProvider.Instance.Account.LoginAsync("13123456789", "123789");
            ArApiProvider.Reset(loginAccount.AuthToken);

            /****图录详情****/
            var album = await ArApiProvider.Instance.Album.GetAsync("album_num");
        }

    }
}
