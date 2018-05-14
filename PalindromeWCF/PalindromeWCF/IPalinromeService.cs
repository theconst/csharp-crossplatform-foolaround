using System.ServiceModel;

namespace PalindromeWCF
{
    [ServiceContract]
    public interface IPalindromeService
    {

        [OperationContract]
        string GetLongestPalindromePrefix(string input);
    }
}
