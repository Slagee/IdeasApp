namespace IdeaAppLibrary.DataAccess;

public interface IIdeaData
{
    Task<List<IdeaModel>> GetAllIdeas();
    Task<List<IdeaModel>> GetAllApprovedIdeas();
    Task<IdeaModel> GetIdea(string id);
    Task<List<IdeaModel>> GetAllIdeasWaitingForApproval();
    Task UpdateIdea(IdeaModel idea);
    Task UpvoteIdea(string ideaId, string userId);
    Task CreateIdea(IdeaModel idea);
}