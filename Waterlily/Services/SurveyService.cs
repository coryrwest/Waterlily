using Microsoft.EntityFrameworkCore;

namespace Waterlily;

public class SurveyService {
    public AppDbContext _db;

    public SurveyService(AppDbContext db) {
        _db = db;

        // Build with a ContextFactory for each unit of work. 
    }

    public async Task<List<Survey>> GetSurveyList() {
        return await _db.Surveys.Include(x => x.Questions).ToListAsync();
    }

    public async Task<Survey> GetSurveyDetails(Guid id) {
        return await _db.Surveys.Include(x => x.Questions).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<SurveyResponse>> GetSurveyResponsesForUser(Guid surveyId, Guid userId) {
        return await _db.SurveyResponses.Where(x => x.SurveyId == surveyId && x.UserId == userId).ToListAsync();
    }

    public async Task AddResponse(SurveyResponse response) {
        _db.SurveyResponses.Add(response);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateResponse(List<SurveyResponse> responses) {
        // Do nothing but save changes, because the EF Core change tracker is keeping track of the updates under the hood.
        // UPDATE MERGE. Existing object in the db and new object, update merge to update changed fields. 
        // In this case, this would only be the response. Question details and FKs can't be changed by the user. 
        foreach (var response in responses) {
            _db.SurveyResponses.Update(response);
            // Maybe change the entitystate manually.
        }
        await _db.SaveChangesAsync();
    }
}