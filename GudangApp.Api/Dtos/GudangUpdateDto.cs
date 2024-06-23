using System.ComponentModel.DataAnnotations;

namespace GudangApp.Api.Dtos;

public record class GudangUpdateDto(
 [Required][StringLength(100)]  string Name
);
