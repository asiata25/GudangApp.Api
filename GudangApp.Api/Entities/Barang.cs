using GudangApp.Api.Entities;

namespace GudangApp.Api;

public class Barang
{
  public string? Kode { get; set; }
  public required string Nama { get; set; }
  public int Harga { get; set; }
  public int Jumlah { get; set; }
  public DateOnly Expired { get; set; }
  public required string KodeGudang { get; set; }
  public Gudang? Gudang { get; set; }
}
