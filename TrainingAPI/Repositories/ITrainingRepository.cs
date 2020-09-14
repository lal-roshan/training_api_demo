using System.Collections.Generic;
using System.Threading.Tasks;
using TrainingAPI.Models;

namespace TrainingAPI.Repositories
{
    public interface ITrainingRepository
    {
        Task AddTraining(Training training);
        Task<bool> DeleteTraining(Training training);
        Task<Training> GetTraining(int trainingId);
        Task<Training> GetTraining(string title);
        Task<List<Training>> GetTrainings();
        Task<bool> UpdateTraining(Training training);
    }
}