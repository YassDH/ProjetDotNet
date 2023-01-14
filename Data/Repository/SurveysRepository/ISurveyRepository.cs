using ProjetDotNet.Models.DBModels;

namespace ProjetDotNet.Data.Repository.SurveysRepository
{
    public interface ISurveyRepository : IRepository<Survey>
    {
        IEnumerable<Survey> GetClosedSurveys();
        IEnumerable<Survey> GetOpenedSurveys();
        IEnumerable<Survey> GetNonVotedSurveys(Guid Id);
        void UpdateSurveyType(Survey survey);
        void UpdateVote(Survey survey);
    }
}
