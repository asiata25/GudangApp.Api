using System.ComponentModel.DataAnnotations;

namespace GudangApp.Api.Dtos;

public record class BarangUpdateDto(
  string Kode,
  [Required][StringLength(100)] string Name,
  [Required][Range(1, int.MaxValue)] int Harga,
  [Required][Range(1, int.MaxValue)] int Jumlah,
  DateOnly Expired,
  string KodeGudang
);
