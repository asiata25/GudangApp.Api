using System.ComponentModel.DataAnnotations;

namespace GudangApp.Api;

public record class GudangCreateDto(
 [Required][StringLength(100)]  string Name
);
