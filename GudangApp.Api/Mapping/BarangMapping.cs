using GudangApp.Api.Dtos;
using GudangApp.Api.Utils;

namespace GudangApp.Api.Mapping;

public static class BarangMapping
{
  public static Barang ToEntity(this BarangCreateDto barang)
  {
    return new()
    {
      Kode = GuidKey.GenerateNew(),
      Nama = barang.Name,
      Harga = barang.Harga,
      Jumlah = barang.Jumlah,
      Expired = barang.Expired,
      KodeGudang = barang.KodeGudang
    };
  }
}
