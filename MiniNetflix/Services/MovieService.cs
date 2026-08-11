using MiniNetflix.Models;
using MongoDB.Driver;

namespace MiniNetflix.Services;

public class MovieService
{
    private readonly IMongoCollection<Movie> _movies;

    public MovieService(IMongoDatabase database)
    {
        _movies = database.GetCollection<Movie>("Movies");
        CreateTextIndex();
    }

    private void CreateTextIndex()
    {
        try
        {
            var indexKeys = Builders<Movie>.IndexKeys
                .Text(m => m.Title)
                .Text(m => m.Synopsis);
            var indexOptions = new CreateIndexOptions { LanguageOverride = "none" };
            var indexModel = new CreateIndexModel<Movie>(indexKeys, indexOptions);
            _movies.Indexes.CreateOne(indexModel);
        }
        catch (MongoCommandException)
        {
            // Drop existing index if it was created with incompatible options (e.g. default language_override)
            _movies.Indexes.DropAll();
            var indexKeys = Builders<Movie>.IndexKeys
                .Text(m => m.Title)
                .Text(m => m.Synopsis);
            var indexOptions = new CreateIndexOptions { LanguageOverride = "none" };
            var indexModel = new CreateIndexModel<Movie>(indexKeys, indexOptions);
            _movies.Indexes.CreateOne(indexModel);
        }
    }

    public async Task<List<Movie>> GetAllAsync(
        string? searchText = null,
        string? genre = null,
        int? minYear = null,
        int? maxYear = null,
        decimal? minRating = null)
    {
        var filter = Builders<Movie>.Filter.Eq(m => m.IsActive, true);

        if (!string.IsNullOrWhiteSpace(searchText))
            filter &= Builders<Movie>.Filter.Text(searchText);

        if (!string.IsNullOrWhiteSpace(genre))
            filter &= Builders<Movie>.Filter.Eq(m => m.Genre, genre);

        if (minYear.HasValue)
            filter &= Builders<Movie>.Filter.Gte(m => m.ReleaseYear, minYear.Value);

        if (maxYear.HasValue)
            filter &= Builders<Movie>.Filter.Lte(m => m.ReleaseYear, maxYear.Value);

        if (minRating.HasValue)
            filter &= Builders<Movie>.Filter.Gte(m => m.Rating, minRating.Value);

        return await _movies.Find(filter).ToListAsync();
    }

    public async Task<Movie?> GetByIdAsync(string id)
    {
        return await _movies.Find(m => m.Id == id).FirstOrDefaultAsync();
    }

    public async Task CreateAsync(Movie movie)
    {
        movie.IsActive = true;
        await _movies.InsertOneAsync(movie);
    }

    public async Task UpdateAsync(string id, Movie movie)
    {
        movie.Id = id;
        await _movies.ReplaceOneAsync(m => m.Id == id, movie);
    }

    public async Task DeleteAsync(string id)
    {
        var update = Builders<Movie>.Update.Set(m => m.IsActive, false);
        await _movies.UpdateOneAsync(m => m.Id == id, update);
    }
}
