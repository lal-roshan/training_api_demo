using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingAPI.Exceptions;
using TrainingAPI.Models;
using TrainingAPI.Repositories;

namespace TrainingAPI.Services
{
    public class TrainingService : ITrainingService
    {
        readonly ITrainingRepository repository;
        public TrainingService(ITrainingRepository repository)
        {
            this.repository = repository;
        }

        public async Task AddTraining(Training training)
        {
            var _training = await repository.GetTraining(training.Title);
            if (_training == null)
                await repository.AddTraining(training);
            else
                throw new DuplicateTrainingTitleExistsException($"Training with Title {training.Title} Already Taken");
        }

        public async Task<List<Training>> GetTrainings() => await repository.GetTrainings();

        public async Task<Training> GetTraining(int id)
        {
            var _training = await repository.GetTraining(id);
            if (_training != null)
                return _training;
            throw new TrainingNotFoundException($"Training with Id {id} does not exist !!");
        }

        public async Task<Training> GetTraining(string title)
        {
            var _training = await repository.GetTraining(title);
            if (_training != null)
                return _training;
            throw new TrainingNotFoundException($"Training with Title {title} does not exist !!");
        }
        //api/trainings/101 (Body :: TrainingData)
        public async Task<bool> Update(int trainingId, Training training)
        {
            var _training = await repository.GetTraining(trainingId);
            if (_training != null)
            {
                _training.Duration = training.Duration;
                return await repository.UpdateTraining(_training);
            }
            throw new TrainingNotFoundException($"Training with Id {trainingId} does not exist !!");
        }
        //api/trainings/101
        public async Task<bool> Delete(int trainingId)
        {
            var _training = await repository.GetTraining(trainingId);
            if (_training != null)
            {
                return await repository.DeleteTraining(_training);
            }
            throw new TrainingNotFoundException($"Training with Id {trainingId} does not exist !!");
        }
    }
}
