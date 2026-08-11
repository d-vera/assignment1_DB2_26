using MiniNetflix.Models;
using MongoDB.Driver;

namespace MiniNetflix.Services;

public class DirectorService
{
    private readonly IMongoCollection<Director> _directors;

    public DirectorService(IMongoDatabase database)
    {
        _directors = database.GetCollection<Director>("Directors");
        CreateTextIndex();
    }

    private void CreateTextIndex()
    {
        var indexKeys = Builders<Director>.IndexKeys
            .Text(d => d.FirstName)
            .Text(d => d.LastName)
            .Text(d => d.Biography);
        var indexModel = new CreateIndexModel<Director>(indexKeys);
        _directors.Indexes.CreateOne(indexModel);
    }

    public async Task<List<Director>> GetAllAsync(
        string? searchText = null,
        string? specialization = null)
    {
        var filter = Builders<Director>.Filter.Eq(d => d.IsActive, true);

        if (!string.IsNullOrWhiteSpace(searchText))
        {
            var escapedText = System.Text.RegularExpressions.Regex.Escape(searchText);
            var regex = new MongoDB.Bson.BsonRegularExpression(escapedText, "i");
            filter &= Builders<Director>.Filter.Or(
                Builders<Director>.Filter.Regex(d => d.FirstName, regex),
                Builders<Director>.Filter.Regex(d => d.LastName, regex),
                Builders<Director>.Filter.Regex(d => d.Biography, regex)
            );
        }

        if (!string.IsNullOrWhiteSpace(specialization))
            filter &= Builders<Director>.Filter.Eq(d => d.Specialization, specialization);

        return await _directors.Find(filter).ToListAsync();
    }

    public async Task<Director?> GetByIdAsync(string id)
    {
        return await _directors.Find(d => d.Id == id).FirstOrDefaultAsync();
    }

    public async Task CreateAsync(Director director)
    {
        director.IsActive = true;
        await _directors.InsertOneAsync(director);
    }

    public async Task UpdateAsync(string id, Director director)
    {
        director.Id = id;
        await _directors.ReplaceOneAsync(d => d.Id == id, director);
    }

    public async Task DeleteAsync(string id)
    {
        var update = Builders<Director>.Update.Set(d => d.IsActive, false);
        await _directors.UpdateOneAsync(d => d.Id == id, update);
    }
}
