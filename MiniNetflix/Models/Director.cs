using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace MiniNetflix.Models;

public class Director
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [Required(ErrorMessage = "First name is required")]
    [BsonElement("firstName")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Last name is required")]
    [BsonElement("lastName")]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Birth date is required")]
    [BsonElement("birthDate")]
    public DateTime BirthDate { get; set; }

    [Required(ErrorMessage = "Nationality is required")]
    [BsonElement("nationality")]
    public string Nationality { get; set; } = string.Empty;

    [Required(ErrorMessage = "Biography is required")]
    [BsonElement("biography")]
    public string Biography { get; set; } = string.Empty;

    [Required(ErrorMessage = "Film count is required")]
    [Range(0, 500, ErrorMessage = "Film count must be non-negative")]
    [BsonElement("filmCount")]
    public int FilmCount { get; set; }

    [Required(ErrorMessage = "Specialization is required")]
    [BsonElement("specialization")]
    public string Specialization { get; set; } = string.Empty;

    [BsonElement("isActive")]
    public bool IsActive { get; set; } = true;
}
