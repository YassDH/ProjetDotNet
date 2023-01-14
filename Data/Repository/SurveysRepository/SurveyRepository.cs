using ProjetDotNet.Models.DBModels;
using System.Diagnostics;

namespace ProjetDotNet.Data.Repository.SurveysRepository
{
    public class SurveysRepository : Repository<Survey>, ISurveyRepository
    {
        private readonly ProjectDBContext applicationDBContext;
        public SurveysRepository(ProjectDBContext applicationDBContext) : base(applicationDBContext)
        {
            this.applicationDBContext = applicationDBContext;
        }

        public IEnumerable<Survey> GetClosedSurveys()
        {
            if (applicationDBContext.Surveys.Where(a => a.closed == 1).Count() != 0)
            {
                return applicationDBContext.Surveys.Where(a => a.closed == 1).ToList();
            }
            else
            {
                return null;
            }
        }
        public IEnumerable<Survey> GetOpenedSurveys()
        {
            if (applicationDBContext.Surveys.Where(a => a.closed == 0).Count() != 0)
            {
                return applicationDBContext.Surveys.Where(a => a.closed == 0).ToList();
            }
            else
            {
                return null;
            }
        }
        public void UpdateSurveyType(Survey survey)
        {
            survey.closed = 1;
            applicationDBContext.Surveys.Update(survey);
        }
        public void UpdateVote(Survey survey)
        {
            applicationDBContext.Surveys.Update(survey);
        }
        public IEnumerable<Survey> GetNonVotedSurveys(Guid Id)
        {
            IEnumerable<VotesDone> votes = applicationDBContext.VotedSurveys.Where(a => a.Users.Id == Id).ToList();
            IEnumerable<Survey> Voted = votes.Join(applicationDBContext.Surveys, (v => v.Survey.Id), (s => s.Id), (v, s) => s);
            Debug.WriteLine(Voted.Count());
            IEnumerable<Survey> nonClosedSurveys = applicationDBContext.Surveys.Where((a => a.closed == 0)).ToList();
            return nonClosedSurveys.Except(Voted);
        }
    }
}