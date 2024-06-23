using System.ComponentModel.DataAnnotations;

namespace GudangApp.Api.Dtos;

public record class GudangCreateDto(
 [Required][StringLength(100)]  string Name
);
