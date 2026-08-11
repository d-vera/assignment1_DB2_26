using MiniNetflix.Models;
using MongoDB.Driver;

namespace MiniNetflix.Services;

public class ActorService
{
    private readonly IMongoCollection<Actor> _actors;

    public ActorService(IMongoDatabase database)
    {
        _actors = database.GetCollection<Actor>("Actors");
        CreateTextIndex();
    }

    private void CreateTextIndex()
    {
        var indexKeys = Builders<Actor>.IndexKeys
            .Text(a => a.FirstName)
            .Text(a => a.LastName)
            .Text(a => a.Biography);
        var indexModel = new CreateIndexModel<Actor>(indexKeys);
        _actors.Indexes.CreateOne(indexModel);
    }

    public async Task<List<Actor>> GetAllAsync(
        string? searchText = null,
        string? nationality = null)
    {
        var filter = Builders<Actor>.Filter.Eq(a => a.IsActive, true);

        if (!string.IsNullOrWhiteSpace(searchText))
        {
            var escapedText = System.Text.RegularExpressions.Regex.Escape(searchText);
            var regex = new MongoDB.Bson.BsonRegularExpression(escapedText, "i");
            filter &= Builders<Actor>.Filter.Or(
                Builders<Actor>.Filter.Regex(a => a.FirstName, regex),
                Builders<Actor>.Filter.Regex(a => a.LastName, regex),
                Builders<Actor>.Filter.Regex(a => a.Biography, regex)
            );
        }

        if (!string.IsNullOrWhiteSpace(nationality))
            filter &= Builders<Actor>.Filter.Eq(a => a.Nationality, nationality);

        return await _actors.Find(filter).ToListAsync();
    }

    public async Task<Actor?> GetByIdAsync(string id)
    {
        return await _actors.Find(a => a.Id == id).FirstOrDefaultAsync();
    }

    public async Task CreateAsync(Actor actor)
    {
        actor.IsActive = true;
        await _actors.InsertOneAsync(actor);
    }

    public async Task UpdateAsync(string id, Actor actor)
    {
        actor.Id = id;
        await _actors.ReplaceOneAsync(a => a.Id == id, actor);
    }

    public async Task DeleteAsync(string id)
    {
        var update = Builders<Actor>.Update.Set(a => a.IsActive, false);
        await _actors.UpdateOneAsync(a => a.Id == id, update);
    }
}
