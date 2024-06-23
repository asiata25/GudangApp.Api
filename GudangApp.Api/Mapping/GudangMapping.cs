using GudangApp.Api.Dtos;
using GudangApp.Api.Entities;

namespace GudangApp.Api.Mapping;

public static class GudangMapping
{
  public static GudangDetailsDto ToGudangDetailDto(this Gudang gudang) {
    return new(gudang.Id, gudang.Nama);
  }
}
