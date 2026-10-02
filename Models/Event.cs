using System.ComponentModel.DataAnnotations;

namespace CourseraEventApp.Models;

public sealed record Event(
    int Id,
    string Name,
    DateTime Date,
    string Location,
    string Category,
    string Description) : IValidatableObject
{
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Id <= 0)
        {
            yield return new ValidationResult("Event ID must be a positive number.", [nameof(Id)]);
        }

        if (Date == default)
        {
            yield return new ValidationResult("Event date is required.", [nameof(Date)]);
        }

        if (string.IsNullOrWhiteSpace(Name))
        {
            yield return new ValidationResult("Event name is required.", [nameof(Name)]);
        }

        if (string.IsNullOrWhiteSpace(Location))
        {
            yield return new ValidationResult("Event location is required.", [nameof(Location)]);
        }

        if (string.IsNullOrWhiteSpace(Category))
        {
            yield return new ValidationResult("Event category is required.", [nameof(Category)]);
        }

        if (string.IsNullOrWhiteSpace(Description))
        {
            yield return new ValidationResult("Event description is required.", [nameof(Description)]);
        }
    }
}
