using System.Collections.Generic;
using System.Threading.Tasks;
using TrainingAPI.Models;

namespace TrainingAPI.Services
{
    public interface ITrainingService
    {
        Task AddTraining(Training training);
        Task<bool> Delete(int trainingId);
        Task<Training> GetTraining(int id);
        Task<Training> GetTraining(string title);
        Task<List<Training>> GetTrainings();
        Task<bool> Update(int trainingId, Training training);
    }
}