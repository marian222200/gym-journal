﻿using GymJournal.Data.Context.IContext;
using GymJournal.Data.Entities;
using GymJournal.Domain.Commands.WorkoutPlanCommands;
using GymJournal.Domain.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymJournal.Data.Repositories
{
    public class WorkoutPlanRepository : IWorkoutPlanRepository
	{
		private readonly IApplicationDbContext _dbContext;

		public WorkoutPlanRepository(IApplicationDbContext dbContext)
		{
			_dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
		}
		public async Task<WorkoutPlanDto> Add(AddWorkoutPlanCommand command, CancellationToken cancellationToken = default)
		{
			var entity = new WorkoutPlan
			{
				//Id = Guid.NewGuid(),
				Name = command.Name,
				Description = command.Description,
				Workouts = await _dbContext.Workouts.Where(w => command.WorkoutIds.Contains(w.Id)).ToListAsync(),
			};

			await _dbContext.WorkoutPlans.AddAsync(entity, cancellationToken);
			await SaveChanges(cancellationToken);

			return new WorkoutPlanDto
			{
				Id = entity.Id,
				Name = entity.Name,
				Description = entity.Description,
				Workouts = entity.Workouts.Select(w => new WorkoutDto
				{
					Id = w.Id,
					Name = w.Name,
					Description = w.Description,
					Exercises = new List<ExerciseDto>(),
					WorkoutPlans = new List<WorkoutPlanDto>(),
				}).ToList(),
			};
		}

		public async Task<IEnumerable<WorkoutPlanDto>> GetAll(CancellationToken cancellationToken = default)
		{
			var dtos = await _dbContext.WorkoutPlans
				.AsNoTracking()
				.Select(entity => new WorkoutPlanDto
				{
					Id = entity.Id,
					Name = entity.Name,
					Description = entity.Description,
					Workouts = entity.Workouts.Select(w => new WorkoutDto
					{
						Id = w.Id,
						Name = w.Name,
						Description = w.Description,
						Exercises = new List<ExerciseDto>(),
						WorkoutPlans = new List<WorkoutPlanDto>(),
					}).ToList(),
				})
				.ToListAsync(cancellationToken);

			return dtos;
		}

		public async Task<WorkoutPlanDto?> GetById(Guid? guid, CancellationToken cancellationToken = default)
		{
			if (guid == null)
			{
				throw new ArgumentNullException(nameof(guid));
			}

			var entity = await _dbContext.WorkoutPlans
				.Include(w => w.Workouts)
				.FirstOrDefaultAsync(w => w.Id == guid, cancellationToken);

			if (entity == null)
			{
				throw new ArgumentException("The WorkoutPlan you want to GetById does not exist.");
			}

			return new WorkoutPlanDto
			{
				Id = entity.Id,
				Name = entity.Name,
				Description = entity.Description,
				Workouts = entity.Workouts.Select(w => new WorkoutDto
				{
					Id = w.Id,
					Name = w.Name,
					Description = w.Description,
					Exercises = new List<ExerciseDto>(),
					WorkoutPlans = new List<WorkoutPlanDto>(),
				}).ToList(),
			};
		}

		public async Task Remove(Guid? id, CancellationToken cancellationToken = default)
		{
			if (id == null)
			{
				throw new ArgumentNullException(nameof(id));
			}

			var entity = await _dbContext.WorkoutPlans
				.Include(w => w.Workouts)
				.FirstOrDefaultAsync(w => w.Id == id, cancellationToken);

			if (entity == null)
			{
				throw new ArgumentException("The WorkoutPlan you want to delete does not exist.");
			}

			_dbContext.WorkoutPlans.Remove(entity);
			await SaveChanges(cancellationToken);
		}

		public async Task SaveChanges(CancellationToken cancellationToken = default)
		{
			await _dbContext.SaveChangesAsync(cancellationToken);
		}

		public async Task<WorkoutPlanDto> Update(UpdateWorkoutPlanCommand command, CancellationToken cancellationToken = default)
		{
			var entity = new WorkoutPlan
			{
				Id = command.Id,
				Name = command.Name,
				Description = command.Description,
				Workouts = await _dbContext.Workouts.Where(w => command.WorkoutIds.Contains(w.Id)).ToListAsync(),
			};

			var entityToUpdate = await _dbContext.WorkoutPlans
				.Include(w => w.Workouts)
				.FirstOrDefaultAsync(w => w.Id == entity.Id, cancellationToken);

			if (entityToUpdate == null)
			{
				throw new ArgumentException("The workoutPlan you want to update does not exist.");
			}

			entityToUpdate.Name = entity.Name;
			entityToUpdate.Description = entity.Description;
			entityToUpdate.Workouts = entity.Workouts;

			await SaveChanges(cancellationToken);

			return new WorkoutPlanDto
			{
				Id = entityToUpdate.Id,
				Name = entityToUpdate.Name,
				Description = entityToUpdate.Description,
				Workouts = entityToUpdate.Workouts.Select(w => new WorkoutDto
				{
					Id = w.Id,
					Name = w.Name,
					Description = w.Description,
					Exercises = new List<ExerciseDto>(),
					WorkoutPlans = new List<WorkoutPlanDto>(),
				}).ToList(),
			}; ;
		}
	}
}
