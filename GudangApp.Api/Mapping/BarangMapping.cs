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

    public static Barang ToEntity(this BarangUpdateDto barang, string kode)
  {
    return new()
    {
      Kode = kode,
      Nama = barang.Name,
      Harga = barang.Harga,
      Jumlah = barang.Jumlah,
      Expired = barang.Expired,
      KodeGudang = barang.KodeGudang
    };
  }

  public static BarangDetailsDto ToBarangDetailsDto(this Barang barang)
  {
    return new(barang.Kode!, barang.Nama, barang.Harga, barang.Jumlah, barang.Expired, new(barang.Gudang!.Kode!, barang.Gudang.Nama));
  }
}
