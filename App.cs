using System.Threading.Tasks;
using Potato.Ar.Api.Examples.Common;

namespace Potato.Ar.Api.Examples
{
    public class App : IExample
    {
        private ConfigProvider _configProvider;

        public async Task RunExample(string[] args)
        {
            _configProvider = new ConfigProvider(args);

            /****初始化连接器****/
            ArApiProvider.Reset(_configProvider.GetAppKey(), _configProvider.GetAppSecret());

            /****发送登陆短信验证码****/
            await ArApiProvider.Instance.App.SendLoginSmsAsync("13212345689");

            /****发送绑定手机号短信验证码****/
            await ArApiProvider.Instance.App.SendResetPhoneSmsAsync("13212345689");
        }

    }
}
