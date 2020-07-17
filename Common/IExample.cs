using System.Threading.Tasks;

namespace Potato.Ar.Api.Examples.Common
{
    public interface IExample
    {
        Task RunExample(string[] args);
    }
}
