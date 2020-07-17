using System.Collections.Generic;
using System.Threading.Tasks;
using Potato.Ar.Api.Sdk.Models;
using Potato.Ar.Api.Examples.Common;

namespace Potato.Ar.Api.Examples
{
    public class ArCard : IExample
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

            /****卡片详情****/
            var arCard = await ArApiProvider.Instance.ArCard.GetAsync("card_num");

            /****卡片扫描记录****/
            var scanCards = await ArApiProvider.Instance.ArCard.ScanHistoryAsync(1, 100);
        }

    }
}
