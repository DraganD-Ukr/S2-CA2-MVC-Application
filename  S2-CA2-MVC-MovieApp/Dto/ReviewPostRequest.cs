using System.ComponentModel.DataAnnotations;

namespace S2_CA2_MVC_MovieApp.Dto;

public class ReviewPostRequest {
    [Required]
    public int MovieId { get; set; }
    [Required]
    [Range(1, 10)]
    public int Rating { get; set; }
    [StringLength(500)]
    public string Comment { get; set; }
}