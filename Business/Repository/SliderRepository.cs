
using Business.Base;
using Business.Services;
using DAL.Data;
using DAL.Entity;
using DAL.Models;
using Exceptions.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    public class SliderRepository : ISliderService
    {

        private readonly AppDbContext _context;
        public SliderRepository(AppDbContext  context )
        {
            _context = context;
        }
       

        public async Task Delete(int? id)
        {
            var data = await Get(id);
            data.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task<Slider> Get(int? id)
        {
            if (id is null)
            {
               throw new ArgumentNullException(nameof(id));
            }

            var data = await _context.Sliders.Where(n => n.Id == id && n.IsDeleted)
                                                             .Include(n => n.Image)
                                                             .FirstOrDefaultAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }
            return data;
        }

        public async Task<List<Slider>> GetAll()
        {
            var data = await _context.Sliders.Where(n => !n.IsDeleted)
                                               .Include(n => n.Image)
                                                       .ToListAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }
            return data;
        }

        public async Task Update(int id, Slider entity)
        {
            var data = await Get(id);
            data.Body = entity.Body;
            data.Title = entity.Title;
            data.ImageIdc = entity.ImageIdc;
            data.UpdatedDate = DateTime.UtcNow.AddHours(4);
            await _context.SaveChangesAsync();
             
        }

        public async Task Create(Slider entity)
        {
            entity.CreatedDate = DateTime.UtcNow.AddHours(4);
            await _context.Sliders.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        Task<IEntity> IBaseService<Slider>.Get(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
