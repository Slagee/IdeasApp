namespace IdeaAppLibrary.Models;

public class BasicIdeaModel
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string Idea { get; set; }

    public BasicIdeaModel()
    { }

    public BasicIdeaModel(IdeaModel idea)
    {
        Id = idea.Id;
        Idea = idea.Idea;
    }
}