using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace MiniNetflix.Models;

public class Movie
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [Required(ErrorMessage = "Title is required")]
    [BsonElement("title")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Genre is required")]
    [BsonElement("genre")]
    public string Genre { get; set; } = string.Empty;

    [Required(ErrorMessage = "Release year is required")]
    [Range(1888, 2100, ErrorMessage = "Enter a valid year")]
    [BsonElement("releaseYear")]
    public int ReleaseYear { get; set; }

    [Required(ErrorMessage = "Duration is required")]
    [Range(1, 1000, ErrorMessage = "Duration must be positive")]
    [BsonElement("durationMinutes")]
    public int DurationMinutes { get; set; }

    [Required(ErrorMessage = "Synopsis is required")]
    [BsonElement("synopsis")]
    public string Synopsis { get; set; } = string.Empty;

    [Required(ErrorMessage = "Rating is required")]
    [Range(0.0, 10.0, ErrorMessage = "Rating must be between 0 and 10")]
    [BsonElement("rating")]
    public decimal Rating { get; set; }

    [Required(ErrorMessage = "Language is required")]
    [BsonElement("language")]
    public string Language { get; set; } = string.Empty;

    [BsonElement("isActive")]
    public bool IsActive { get; set; } = true;
}
