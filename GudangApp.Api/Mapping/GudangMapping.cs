using GudangApp.Api.Dtos;
using GudangApp.Api.Entities;
using GudangApp.Api.Utils;

namespace GudangApp.Api.Mapping;

public static class GudangMapping
{
  public static Gudang ToEntity(this GudangCreateDto gudang)
  {
    return new() { Nama = gudang.Name, Kode = GuidKey.GenerateNew() };
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
