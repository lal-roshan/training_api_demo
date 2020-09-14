using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingAPI.Models;

namespace TrainingAPI.Repositories
{
    public class TrainingRepository : ITrainingRepository
    {
        readonly TrainingDbContext context;

        public TrainingRepository(TrainingDbContext context)
        {
            this.context = context;
        }

        public async Task AddTraining(Training training)
        {
            int trainingId = 101;
            if (context.Trainings.Count() > 0)
                trainingId = context.Trainings.Max(t => t.TrainingId) + 1;

            training.TrainingId = trainingId;

            context.Trainings.Add(training);

            await context.SaveChangesAsync();
        }

        public async Task<List<Training>> GetTrainings() => await context.Trainings.ToListAsync();

        public async Task<Training> GetTraining(int trainingId) =>
            await context.Trainings
            .Where(t => t.TrainingId == trainingId)
            .FirstOrDefaultAsync();
        public async Task<Training> GetTraining(string title) =>
            await context.Trainings
            .Where(t => t.Title == title)
            .FirstOrDefaultAsync();

        public async Task<bool> DeleteTraining(Training training)
        {
            context.Entry<Training>(training).State = EntityState.Deleted;
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateTraining(Training training)
        {
            context.Entry<Training>(training).State = EntityState.Modified;
            return await context.SaveChangesAsync() > 0;
        }

    }
}
