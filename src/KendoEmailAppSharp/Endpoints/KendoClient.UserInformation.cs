namespace KendoEmailAppSharp;

public partial class KendoClient 
{
    public async Task<uint?> GetCredit()
    {
        var creditDict = await GetAsync<Dictionary<string, uint>>("/getcredit");
        return creditDict?["credit"];
    }
}