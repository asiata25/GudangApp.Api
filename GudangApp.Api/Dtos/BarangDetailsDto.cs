namespace GudangApp.Api.Dtos;

public record class BarangDetailsDto(string Kode, string Name, int Harga, int Jumlah, DateOnly Expired, GudangDetailsDto Gudang);
