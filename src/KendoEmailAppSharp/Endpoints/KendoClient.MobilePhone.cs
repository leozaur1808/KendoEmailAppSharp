using KendoEmailAppSharp.Models;

namespace KendoEmailAppSharp;

public partial class KendoClient 
{
    public Task<string?> MobileByLinkedin(string linkedin)
    {
        Dictionary<string, string> queryParams = new() { { "linkedin", linkedin } };
        var phone = GetAsync<KendoPhone>("/mobilebylinkedin", queryParams);
        return phone.ContinueWith(t => t.Result?.PhoneNumber);
    }

    public async Task<PhoneStatus?> VerifyPhoneNumber(string phoneNumber)
    {
        Dictionary<string, string> queryParams = new() { { "phonenumber", phoneNumber } };
        var response = GetAsync<KendoPhoneVerification>("/verifyphonenumber", queryParams);
        return await response.ContinueWith(t => t.Result?.Results switch
        {
            "FIXED" => (PhoneStatus?)PhoneStatus.Fixed,
            "MOBILE" => (PhoneStatus?)PhoneStatus.Mobile,
            "INVALID" => (PhoneStatus?)PhoneStatus.Invalid,
            "N/A" => (PhoneStatus?)PhoneStatus.Unknown,
            _ => null,
        });
    }

}