using GudangApp.Api.Dtos;
using GudangApp.Api.Entities;

namespace GudangApp.Api.Mapping;

public static class GudangMapping
{
  public static Gudang ToEntity(this GudangCreateDto gudang)
  {
    Guid g = Guid.NewGuid();
    string GuidString = Convert.ToBase64String(g.ToByteArray());
    GuidString = GuidString.Replace("=", "");
    GuidString = GuidString.Replace("+", "");

    return new() { Nama = gudang.Name, Kode = GuidString };
  }

  public static Gudang ToEntity(this GudangUpdateDto gudang, string kode)
  {
    return new() { Nama = gudang.Name, Kode = kode };
  }

  public static GudangDetailsDto ToGudangDetailDto(this Gudang gudang)
  {
    return new(gudang.Kode!, gudang.Nama);
  }
}
