namespace GudangApp.Api.Utils;

public static class GuidKey
{
  public static string GenerateNew()
  {
    Guid g = Guid.NewGuid();
    string GuidString = Convert.ToBase64String(g.ToByteArray());
    GuidString = GuidString.Replace("=", "");
    GuidString = GuidString.Replace("+", "");

    return GuidString;
  }
}
