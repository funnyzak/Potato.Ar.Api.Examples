using System.Collections.Generic;
using System.Threading.Tasks;
using Potato.Ar.Api.Sdk.Models;
using Potato.Ar.Api.Examples.Common;

namespace Potato.Ar.Api.Examples
{
    public class Account : IExample
    {
        private ConfigProvider _configProvider;

        public async Task RunExample(string[] args)
        {
            _configProvider = new ConfigProvider(args);

            /****初始化连接器****/
            ArApiProvider.Reset(_configProvider.GetAppKey(), _configProvider.GetAppSecret());

            /****登陆****/
            AccountInfo loginAccount = await ArApiProvider.Instance.Account.LoginAsync("13123456789", "123789");

            /****登陆需要设置链接期用户令牌****/
            ArApiProvider.Reset(loginAccount.AuthToken);

            /****绑定手机号****/
            await ArApiProvider.Instance.Account.BindPhoneAsync("13212345689", "123789");

            /****我的信息****/
            AccountInfo accountInfo = await ArApiProvider.Instance.Account.ProfileAsync();

            /****我购买的图录****/
            List<ArAlbum> buyAlbums = await ArApiProvider.Instance.Account.MyBuyAlbumsAsync(1, 200);

            /****我收藏的图录****/
            List<ArAlbum> favAlbums = await ArApiProvider.Instance.Account.MyFavAlbumsAsync(1, 200);

            /****退出****/
            await ArApiProvider.Instance.Account.LogoutAsync();
        }

    }
}
